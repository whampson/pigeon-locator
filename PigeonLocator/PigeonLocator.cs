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
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace WHampson.PigeonLocator
{
    internal static class PigeonLocator
    {
        [STAThread]
        internal static void Main(string[] args)
        {
            InitializeUhandledExceptionHandler();

            Application.EnableVisualStyles();
            Application.Run(new PigeonLocatorForm());
        }

        internal static void InitializeUhandledExceptionHandler()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException
                += new ThreadExceptionEventHandler(UI_OnUnhandledException);
            AppDomain.CurrentDomain.UnhandledException
                += new UnhandledExceptionEventHandler(App_OnUnhandledException);
        }

        internal static void UI_OnUnhandledException(object sender, ThreadExceptionEventArgs e)
        {
            DisplayUnhandledException(e.Exception);
            Environment.Exit(1);
        }

        internal static void App_OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DisplayUnhandledException((Exception) e.ExceptionObject);
            Environment.Exit(1);
        }

        internal static void DisplayUnhandledException(Exception e)
        {
            Console.WriteLine("[UNHANDLED EXCEPTON]: {0}", e);

            string msg = "A fatal exception has occurred and the program must be terminated.\n\n" +
                e.GetType().FullName + ": " + e.Message;
            MessageBox.Show(msg, "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static string GetProgramName()
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

        internal static FileVersionInfo GetProgramVersion()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            if (asm == null) {
                return null;
            }

            return FileVersionInfo.GetVersionInfo(asm.Location);
        }

        internal static string GetCopyrightString()
        {
            return "Copyright (C) 2018 W. Hampson";
        }
    }
}
