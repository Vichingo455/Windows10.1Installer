using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows10._1Installer
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Check for Windows 11 operating system
            RegistryKey rk;
            rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            var build = rk.GetValue("CurrentBuild");
            int build_int = Convert.ToInt32(build);
            if (Environment.Is64BitOperatingSystem && build_int >= 22000)
            {
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("The Redress Windows 10.1 Installer needs a x64 operating system with Windows 11");
                Environment.Exit(1);
            }
        }
    }
}
