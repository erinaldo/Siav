using One.Bll;
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
    public partial class devolucao_troca : Form
    {
        public string codigo_cupom;

        public devolucao_troca()
        {
            InitializeComponent();
           // textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        break;

                    case Keys.Enter:
                        this.Close();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.codigo_cupom = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            VendasBLL c = new VendasBLL();
            c.Data_inicial = dateTimePicker1.Value.ToShortDateString();
            c.Data_final = dateTimePicker2.Value.ToShortDateString();
            dataGridView1.DataSource = c.Localiza_Cupom();
            }
            catch (Exception ee){
                MessageBox.Show(ee.Message);
            }
        }
    }
}
