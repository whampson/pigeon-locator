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
    /// <summary>
    /// Represents a GTA IV savedata file.
    /// </summary>
    internal unsafe class IvSavegame : IDisposable
    {
        private const string HeaderSignature = "SAVE";
        private const string FoooterSignature = "END";
        private const string BlockSignature = "BLOCK";

        private const int PickupsBlock = 7;
        private const int BlockCount = 32;

        private const int PickupCount = 419;

        /// <summary>
        /// Creates a new <see cref="IvSavegame"/> object and loads the savegame
        /// data from the specified file.
        /// </summary>
        /// <param name="path">
        /// The path to the file to load.
        /// </param>
        /// <returns>
        /// A <see cref="IvSavegame"/> object containing the savegame data.
        /// </returns>
        /// <exception cref="FileNotFoundException">
        /// Thrown if the specified file does not exist.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// Thrown if the file is not a valid GTA IV savegame file.
        /// </exception>
        public static IvSavegame Load(string path)
        {
            FileHeader* header;
            IntPtr fileStartPtr;
            DateTime timestamp;

            if (!File.Exists(path)) {
                throw new FileNotFoundException("File does not exist.", path);
            }
            timestamp = File.GetLastWriteTime(path);

            using (FileStream fs = File.OpenRead(path)) {
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
                if (bytesRead != headerLen || sig != HeaderSignature) {
                    Marshal.FreeHGlobal(fileStartPtr);
                    throw new InvalidDataException("Not a valid GTA IV savegame file.");
                }

                if (header->FileSize != fileLen) {
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
                if (sig != BlockSignature) {
                    throw new InvalidDataException("Savegame data misaligned in memory.");
                }

                // Reassign header pointer because we re-allocated the buffer
                header = (FileHeader*) fileStartPtr;
            }

            return new IvSavegame(fileStartPtr, header, timestamp);
        }

        private IntPtr dataPtr;
        private FileHeader* fileInfo;
        private bool hasBeenDisposed;

        private IvSavegame(IntPtr dataPtr, FileHeader* fileInfo, DateTime timestamp)
        {
            this.dataPtr = dataPtr;
            this.fileInfo = fileInfo;
            hasBeenDisposed = false;
            Timestamp = timestamp;
        }

        /// <summary>
        /// Gets the file version.
        /// </summary>
        public uint FileVersion
        {
            get { return fileInfo->FileVersion; }
        }

        /// <summary>
        /// Gets the file size in bytes.
        /// </summary>
        public uint FileSize
        {
            get { return fileInfo->FileSize; }
        }

        /// <summary>
        /// Gets the size of the global variables pool in bytes.
        /// </summary>
        public uint GlobalVarsSize
        {
            get { return fileInfo->GlobalVarsSize; }
        }

        /// <summary>
        /// Gets the name of the last mission passed.
        /// </summary>
        public string LastMissionName
        {
            get { return new string(fileInfo->LastMissionName); }
        }

        public DateTime Timestamp
        {
            get;
        }


        /// <summary>
        /// Returns an array of map coordinates for each remaining pigeon.
        /// </summary>
        /// <returns>
        /// An array of <see cref="Vect3d"/> values, each corresponding to a pigeon location.
        /// </returns>
        public Vect3d[] GetRemainingPigeonLocations()
        {
            List<Vect3d> pigeonLocations = new List<Vect3d>();
            IntPtr cursor = LocateBlock(PickupsBlock);
            cursor = AdvancePointer(cursor, Marshal.SizeOf(typeof(BlockHeader)));

            for (int i = 0; i < PickupCount; i++) {
                Pickup* pPickup = (Pickup*) cursor;

                if (pPickup->Object == ObjectId.Pigeon) {
                    pigeonLocations.Add(pPickup->Location);
                }

                cursor = AdvancePointer(cursor, Marshal.SizeOf(typeof(Pickup)));
            }

            return pigeonLocations.ToArray();
        }

        /// <summary>
        /// Gets a pointer to a data block.
        /// </summary>
        /// <param name="index">
        /// The index of the data block.
        /// </param>
        /// <returns>
        /// An <see cref="IntPtr"/> to the data block.
        /// If the index is out of range, <see cref="IntPtr.Zero"/> is returned.
        /// </returns>
        private IntPtr LocateBlock(int index)
        {
            if (index < 0 || index > BlockCount - 1) {
                return IntPtr.Zero;
            }


            IntPtr cursor = dataPtr;
            int i = -1;
            BlockHeader* pBlockHeader = null;

            do {
                if (i == -1) {
                    // Skip file header
                    cursor = AdvancePointer(cursor, Marshal.SizeOf(typeof(FileHeader)));
                } else {
                    // Skip block
                    cursor = AdvancePointer(cursor, (int) pBlockHeader->BlockSize);
                }

                pBlockHeader = (BlockHeader*) cursor;

                if (cursor.ToInt64() < dataPtr.ToInt64()) {
                    throw new InvalidDataException("Reached end of buffer when locating block.");
                }

                // Sanity check
                string sig = Marshal.PtrToStringAnsi((IntPtr) pBlockHeader->Signature, BlockSignature.Length);
                if (sig != BlockSignature) {
                    string fmt = "Expected block signature not present for block {0}.";
                    throw new InvalidDataException(string.Format(fmt, i + 1));
                }
            } while (++i != index);

            return cursor;
        }

        #region Disposal
        protected virtual void Dispose(bool isDisposing)
        {
            if (!hasBeenDisposed) {
                if (isDisposing) {
                    // TODO: dispose managed state (managed objects).
                }

                if (dataPtr != IntPtr.Zero) {
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
                nameof(Timestamp),
                nameof(FileVersion),
                nameof(FileSize),
                nameof(GlobalVarsSize)
            };

            return ObjectUtilities.GenerateToString(this, properties);
        }

        /// <summary>
        /// Adds an offset to an <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="ptr">
        /// The base address.
        /// </param>
        /// <param name="offset">
        /// The offset to add to the base address.
        /// </param>
        /// <returns>
        /// The new <see cref="IntPtr"> that is the sum of the old pointer and the offset.
        /// </returns>
        private static IntPtr AdvancePointer(IntPtr ptr, int offset)
        {
            return new IntPtr(ptr.ToInt64() + offset);
        }
    }
}
