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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WHampson.PigeonLocator
{
    internal static class Program
    {
        public const string ConfigRecentFileKey = "recentFile";

        [STAThread]
        public static void Main(string[] args)
        {
            FatalExceptionHandler.Initialize();
            Application.EnableVisualStyles();

            if (args.Length > 0) {
                Application.Run(new PigeonLocatorForm(args[0]));
            } else {
                Application.Run(new PigeonLocatorForm());
            }
        }

        public static string GetAssemblyName()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (asm == null) {
                return "null";
            }

            return asm.GetName().Name;
        }

        public static string GetAssemblyTitle()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (asm == null) {
                return "null";
            }

            AssemblyTitleAttribute attr = (AssemblyTitleAttribute)
                Attribute.GetCustomAttribute(asm, typeof(AssemblyTitleAttribute), false);
            if (attr == null) {
                return "null";
            }

            return attr.Title;
        }

        public static string GetExeName()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (asm == null) {
                return "null";
            }

            string path = asm.Location;
            if (string.IsNullOrWhiteSpace(path)) {
                return "null";
            }

            return Path.GetFileNameWithoutExtension(path);
        }

        public static FileVersionInfo GetProgramVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (asm == null) {
                return null;
            }

            return FileVersionInfo.GetVersionInfo(asm.Location);
        }

        public static string GetCopyrightString()
        {
            return "Copyright (C) 2018 W. Hampson";
        }

        public static IniFile GetConfig()
        {
            return new IniFile(GetAssemblyName() + ".ini");
        }

        public static void LogException(LogLevel l, Exception ex)
        {
            TextWriter w;
            switch (l) {
                case LogLevel.Error:
                    w = Console.Error;
                    break;
                default:
                    w = Console.Out;
                    break;
            }

            w.WriteLine("[{0}]: {1}: {2}",
                l.ToString(), ex.GetType().FullName, ex.Message);
        }
    }

    internal enum LogLevel
    {
        Info,
        Warning,
        Error
    }
}
