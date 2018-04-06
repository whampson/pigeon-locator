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
using System.Runtime.InteropServices;
using System.Text;

namespace WHampson.PigeonLocator
{
    internal class IniFile
    {
        private const int MaxValueLength = 255;

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string sec, string key, string def, StringBuilder ret, int size, string path);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string sec, string key, string val, string path);

        public IniFile(string path)
        {
            FilePath = Path.GetFullPath(path);
        }

        public string FilePath { get; }

        public string Read(string key, string section = null)
        {
            StringBuilder retval = new StringBuilder(MaxValueLength);
            GetPrivateProfileString(
                section ?? Program.GetAssemblyName(),
                key, string.Empty, retval, MaxValueLength, FilePath);

            return retval.ToString();
        }

        public void Write(string key, string value, string section = null)
        {
            WritePrivateProfileString(section ?? Program.GetAssemblyName(), key, value, FilePath);
        }

        public void DeleteKey(string key, string section = null)
        {
            Write(key, null, section);
        }

        public void DeleteSection(string section = null)
        {
            Write(null, null, section);
        }
    }
}
