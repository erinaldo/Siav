using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One
{
    public partial class Atualizacao : Form
    {
        public Atualizacao()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sPath = System.AppDomain.CurrentDomain.BaseDirectory;

            System.Diagnostics.Process.Start(sPath + "Patcher//SAT_Patcher.exe");
            //System.Threading.Thread.CurrentThread.Abort();
            Application.Exit();
        }
    }
}
