#region License
/* Copyright (c) 2018-2026 Wes Hampson
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
using System.Threading;
using System.Windows.Forms;

namespace WHampson.PigeonLocator
{
    internal static class FatalExceptionHandler
    {
        private const string TimestampFormatNumeric = "yyyyMMddHHmmss";
        private const string TimestampFormatAbbreviated = "dd MMM yyyy HH:mm:ss";
        private const string DumpFileNameFormat = "{0}-crash-{1}.txt";

        public static void Initialize()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException
                += new ThreadExceptionEventHandler(UI_OnUnhandledException);
            AppDomain.CurrentDomain.UnhandledException
                += new UnhandledExceptionEventHandler(App_OnUnhandledException);
        }

        private static void HandleFatalException(Exception e)
        {
            string trace = e.ToString();
            DateTime timestamp = DateTime.Now;

            // Write trace to console
            Console.Error.WriteLine("[FATAL EXCEPTION]: {0}", trace);

            // Write trace to file
            string dumpFileName = string.Format(DumpFileNameFormat,
                Program.GetExeName(), timestamp.ToString(TimestampFormatNumeric));

            using (StreamWriter w = new StreamWriter(dumpFileName)) {
                string header = string.Format("{0} Crash Dump", Program.GetAssemblyTitle());
                FileVersionInfo vers = Program.GetVersion();
                w.WriteLine(header);
                w.WriteLine(new string('-', header.Length));
                w.WriteLine("Version: {0}", vers.ProductVersion);
                w.WriteLine("Build: {0}", vers.FilePrivatePart);
                w.WriteLine("Date: {0}", timestamp.ToString(TimestampFormatAbbreviated));
                w.WriteLine();
                w.WriteLine(trace);
            }
            Console.Error.WriteLine("Crash dump written to {0}", Path.GetFullPath(dumpFileName));

#if DEBUG
            Debugger.Break();
#else
            // Display error dialog
            DisplayFatalExceptionMessage(e, dumpFileName);
#endif
        }

        private static void DisplayFatalExceptionMessage(Exception e, string crashDumpFileName)
        {
            string msg = string.Format(
                "A fatal exception has occurred and the program must be terminated.\n\n" +
                "{0}:\n{1}\n\n" +
                "A crash dump has been written to {2}.\n" +
                "Please provide this crash dump when filing a bug report.",
                e.GetType().FullName, e.Message,
                crashDumpFileName);

            MessageBox.Show(msg, "Unhandled Exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void UI_OnUnhandledException(object sender, ThreadExceptionEventArgs e)
        {
            HandleFatalException(e.Exception);
            Environment.Exit(1);
        }

        private static void App_OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleFatalException((Exception) e.ExceptionObject);
            Environment.Exit(1);
        }
    }
}
