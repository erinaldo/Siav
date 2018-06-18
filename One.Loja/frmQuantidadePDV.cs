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
    public partial class frmQuantidadePDV : Form
    {
        public string Qtd { get; set; }
       
        public frmQuantidadePDV()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Qtd = textBox1.Text.ToString();
                this.Close();
            }
        }

        private void frmQuantidadePDV_Load(object sender, EventArgs e)
        {

        }
    }
}
