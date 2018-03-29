#region License
/* Copyright (c) 2018 W. Hampson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace WHampson.PigeonLocator
{
    internal unsafe class IvSavegame : IDisposable
    {
        private const string HeaderSignature = "SAVE";
        private const string FoooterSignature = "END";
        private const string BlockSignature = "BLOCK";

        private const int PickupsBlock = 7;
        private const int BlockCount = 32;

        private const int PickupCount = 419;

        public static IvSavegame Load(string path)
        {
            FileHeader* header;
            IntPtr fileStartPtr;
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File does not exist.", path);
            }

            using (FileStream fs = File.OpenRead(path))
            {
                int bytesRead;
                byte[] buf;
                IntPtr blockStartPtr;
                int headerLen;
                long fileLen;
                string sig;

                headerLen = Marshal.SizeOf(typeof(FileHeader));
                fileLen = fs.Length;
                fileStartPtr = Marshal.AllocHGlobal(headerLen);
                header = (FileHeader*) fileStartPtr;

                // Check for valid header
                buf = new byte[headerLen];
                bytesRead = fs.Read(buf, 0, headerLen);
                Marshal.Copy(buf, 0, fileStartPtr, buf.Length);

                sig = Marshal.PtrToStringAnsi((IntPtr) header->Signature, HeaderSignature.Length);
                if (bytesRead != headerLen || sig != HeaderSignature)
                {
                    Marshal.FreeHGlobal(fileStartPtr);
                    throw new InvalidDataException("Not a valid GTA IV savegame file.");
                }

                if (header->FileSize != fileLen)
                {
                    Marshal.FreeHGlobal(fileStartPtr);
                    throw new InvalidDataException("Invalid savegame header.");
                }

                // Read the rest of the file
                fileStartPtr = Marshal.ReAllocHGlobal(fileStartPtr, (IntPtr) fileLen);
                blockStartPtr = AdvancePointer(fileStartPtr, headerLen);
                buf = new byte[fileLen - headerLen];
                bytesRead = fs.Read(buf, 0, buf.Length);
                Marshal.Copy(buf, 0, blockStartPtr, buf.Length);

                // Sanity check: 'BLOCK' should immediately follow the header
                sig = Marshal.PtrToStringAnsi(blockStartPtr, BlockSignature.Length);
                if (sig != BlockSignature)
                {
                    throw new InvalidDataException("Savegame data misaligned in memory.");
                }

                // Reassign header pointer because we re-allocated the buffer
                header = (FileHeader*) fileStartPtr;
            }

            return new IvSavegame(fileStartPtr, header);
        }

        private IntPtr dataPtr;
        private FileHeader* fileInfo;
        private bool hasBeenDisposed;

        private IvSavegame(IntPtr dataPtr, FileHeader* fileInfo)
        {
            this.dataPtr = dataPtr;
            this.fileInfo = fileInfo;
            hasBeenDisposed = false;
        }

        public uint FileVersion
        {
            get { return fileInfo->FileVersion; }
        }

        public uint FileSize
        {
            get { return fileInfo->FileSize; }
        }

        public uint GlobalVarsSize
        {
            get { return fileInfo->GlobalVarsSize; }
        }

        public string LastMissionName
        {
            get { return new string(fileInfo->LastMissionName); }
        }
        //public int Timestamp { get; }


        public Vect3d[] GetRemainingPigeonLocations()
        {
            List<Vect3d> pigeonLocations = new List<Vect3d>();
            IntPtr cursor = LocateBlock(PickupsBlock);
            cursor = AdvancePointer(cursor, Marshal.SizeOf(typeof(BlockHeader)));

            for (int i = 0; i < PickupCount; i++)
            {
                Pickup* pPickup = (Pickup*) cursor;

                if (pPickup->ObjectId == ObjectType.Pigeon)
                {
                    pigeonLocations.Add(pPickup->Location);
                }

                cursor = AdvancePointer(cursor, Marshal.SizeOf(typeof(Pickup)));
            }

            return pigeonLocations.ToArray();
        }

        private IntPtr LocateBlock(int index)
        {
            if (index < 0 || index > BlockCount - 1)
            {
                return IntPtr.Zero;
            }


            IntPtr cursor = dataPtr;
            int i = -1;
            BlockHeader* pBlockHeader = null;

            do
            {
                cursor = (i == -1)
                    ? AdvancePointer(cursor, Marshal.SizeOf(typeof(FileHeader)))    // Skip file header
                    : AdvancePointer(cursor, (int) pBlockHeader->BlockSize);        // Skip block

                pBlockHeader = (BlockHeader*) cursor;

                if (cursor.ToInt64() < dataPtr.ToInt64())
                {
                    throw new InvalidDataException("Reached end of buffer when locating block.");
                }

                // Sanity check
                string sig = Marshal.PtrToStringAnsi((IntPtr) pBlockHeader->Signature, BlockSignature.Length);
                if (sig != BlockSignature)
                {
                    string fmt = "Expected block signature not present for block {0}.";
                    throw new InvalidDataException(string.Format(fmt, i + 1));
                }
            } while (++i != index);



            return cursor;
        }

        #region Disposal
        protected virtual void Dispose(bool isDisposing)
        {
            if (!hasBeenDisposed)
            {
                if (isDisposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                if (dataPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(dataPtr);
                    dataPtr = IntPtr.Zero;
                }
                hasBeenDisposed = true;
            }
        }


        ~IvSavegame()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        public override string ToString()
        {
            string[] properties = {
                nameof(LastMissionName),
                //nameof(Timestamp),
                nameof(FileVersion),
                nameof(FileSize),
                nameof(GlobalVarsSize)
            };

            return ObjectUtilities.GenerateToString(this, properties);
        }

        private static IntPtr AdvancePointer(IntPtr ptr, int offset)
        {
            return new IntPtr(ptr.ToInt64() + offset);
        }
    }
}
