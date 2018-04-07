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

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace WHampson.PigeonLocator
{
    /// <summary>
    /// Represents a Windows .ini configuration file.
    /// </summary>
    internal class IniFile
    {
        private const int MaxValueLength = 255;

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string sec, string key, string def, StringBuilder ret, int size, string path);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string sec, string key, string val, string path);

        /// <summary>
        /// Instantiates a new <see cref="IniFile"/> object.
        /// </summary>
        /// <param name="path">The path to the .ini file on disk.</param>
        public IniFile(string path)
        {
            FilePath = Path.GetFullPath(path);
        }

        /// <summary>
        /// Gets the path to the .ini file on disk.
        /// </summary>
        public string FilePath { get; }

        /// <summary>
        /// Reads a value from the .ini file.
        /// </summary>
        /// <param name="key">The key to read.</param>
        /// <param name="section">The section containing the key to read.</param>
        /// <returns>
        /// The value of the key read.
        /// If the key doesn't exist, <see cref="String.Empty"/> is returned.
        /// </returns>
        public string Read(string key, string section = null)
        {
            StringBuilder retval = new StringBuilder(MaxValueLength);
            GetPrivateProfileString(
                section ?? Program.GetAssemblyName(),
                key, string.Empty, retval, MaxValueLength, FilePath);

            return retval.ToString();
        }

        /// <summary>
        /// Writes a value to the .ini file.
        /// </summary>
        /// <param name="key">The key to write.</param>
        /// <param name="value">The new value.</param>
        /// <param name="section">The section containing the key to write.</param>
        public void Write(string key, string value, string section = null)
        {
            WritePrivateProfileString(section ?? Program.GetAssemblyName(), key, value, FilePath);
        }

        /// <summary>
        /// Checks whether a key-value pare exists in the .ini file.
        /// </summary>
        /// <param name="key">The key to check for existence.</param>
        /// <param name="section">The section containing the key to check for.</param>
        /// <returns>True if the key-value pair exists, False otherwise.</returns>
        public bool ContainsKey(string key, string section = null)
        {
            return Read(key, section) != string.Empty;
        }

        /// <summary>
        /// Deletes a key-value pair.
        /// </summary>
        /// <param name="key">The key to delete.</param>
        /// <param name="section">The section containing the key to delete.</param>
        public void DeleteKey(string key, string section = null)
        {
            Write(key, null, section);
        }

        /// <summary>
        /// Deletes a section of key-value pairs.
        /// </summary>
        /// <param name="section">The section to delete.</param>
        public void DeleteSection(string section = null)
        {
            Write(null, null, section);
        }
    }
}
