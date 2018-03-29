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

        public static IvSavegame Load(string path)
        {
            FileHeader* header;
            int headerLen;
            long fileLen;
            string sig;
            IntPtr data;
            byte[] buf;
            int bytesRead;
            
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File does not exist.", path);
            }

            using (FileStream fs = File.OpenRead(path))
            {
                headerLen = Marshal.SizeOf(typeof(FileHeader));
                fileLen = fs.Length;
                data = Marshal.AllocHGlobal(headerLen);
                header = (FileHeader*) data;

                // Check for valid header
                buf = new byte[headerLen];
                bytesRead = fs.Read(buf, 0, headerLen);
                Marshal.Copy(buf, 0, data, buf.Length);

                sig = Marshal.PtrToStringAnsi((IntPtr) header->Signature, HeaderSignature.Length);
                if (bytesRead != headerLen || sig != HeaderSignature)
                {
                    Marshal.FreeHGlobal(data);
                    throw new InvalidDataException("Not a valid GTA IV savegame file.");
                }

                if (header->FileSize != fileLen)
                {
                    Marshal.FreeHGlobal(data);
                    throw new InvalidDataException("Invalid savegame header.");
                }

                // Read the rest of the file
                data = Marshal.ReAllocHGlobal(data, (IntPtr) fileLen);
                buf = new byte[fileLen - headerLen];
                bytesRead = fs.Read(buf, 0, buf.Length);
                Marshal.Copy(buf, 0, new IntPtr(data.ToInt64() + headerLen), buf.Length);

                // Sanity check: 'BLOCK' should immediately follow the header
                sig = Marshal.PtrToStringAnsi(new IntPtr(data.ToInt64() + headerLen), BlockSignature.Length);
                if (sig != BlockSignature)
                {
                    throw new InvalidDataException("Savegame data misaligned in memory!");
                }

                // Reassign header pointer because we re-allocated the buffer
                header = (FileHeader*) data;
            }

            return new IvSavegame(data, header);
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
            return new Vect3d[0];
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
    }
}
