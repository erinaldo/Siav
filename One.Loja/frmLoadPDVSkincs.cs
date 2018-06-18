using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmLoadPDVSkincs : Form
    {
        public frmLoadPDVSkincs()
        {
            InitializeComponent();
        }

        private void frmLoadPDVSkincs_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\One\image.jpg");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
