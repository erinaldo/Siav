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
    public partial class frmAberturaDeCaixa : Form
    {
        public frmAberturaDeCaixa()
        {
            InitializeComponent();
        }
        public decimal ValorInicial { get; set; }

        private void txtValorInicial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (MessageBox.Show("Tem certeza que deseja iniciar o caixa com valor de R$" + txtValorInicial.Text.ToString() + " ?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (txtValorInicial.Text != "")
                            ValorInicial = decimal.Parse(txtValorInicial.Text);
                        else
                            throw new Exception("`Por favor informe o valor inicial!");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static void Moeda(ref TextBox txt)
        {
            string m = string.Empty;
            decimal v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(",", "");
                if (m.Equals(""))
                {
                    m = "";
                }
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                {
                    m = m.Substring(1, m.Length - 1);
                }
                v = Convert.ToDecimal(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {
                throw;
            }

        }
        private void frmAberturaDeCaixa_Load(object sender, EventArgs e)
        {

        }

        private void txtValorInicial_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorInicial);
        }
    }
}
