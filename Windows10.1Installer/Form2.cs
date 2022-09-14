using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows10._1Installer
{
    public partial class Form2 : Form
    {
        public Form2()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var temp = Path.GetTempPath();
            File.WriteAllBytes(temp + @"\tmpinstall4657.rtf",Properties.Resources.license);
            richTextBox1.LoadFile(temp + @"\tmpinstall4657.rtf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("This update needs to restart the computer to complete, please save your work and press yes to start the installation","Redress Windows 10.1 Update Assistant",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (msgbox == DialogResult.Yes)
            {
                this.Hide();
                var f2 = new Form3();
                f2.ShowDialog();
                this.Close();
            }
        }
    }
}
