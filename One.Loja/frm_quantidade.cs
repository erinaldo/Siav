using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frm_quantidade : Form
    {
        public Int32 quantidade = 0;
        public frm_quantidade()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.quantidade = Int32.Parse(textBox1.Text);
            }
            catch(Exception ee) {
                MessageBox.Show("A quantidade só pode conter numeros inteiros !");
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.quantidade = Int32.Parse(textBox1.Text);

                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("A quantidade só pode conter numeros inteiros !");
            }
        }
    }
}
