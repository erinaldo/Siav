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
    public partial class FrmBackground : Form
    {
        public FrmBackground()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += FrmBackground_FormClosing;
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.CornflowerBlue;
                    // 4#
                    break;
                }
            }
        }

        void FrmBackground_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLoadCaixa frm = new frmLoadCaixa();
            frm.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
