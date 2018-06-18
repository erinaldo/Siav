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
    public partial class frmDesconto : Form
    {
        public frmDesconto()
        {
            InitializeComponent();
        }
        public decimal valorTotal { get; set; }
        public decimal valorDesconto { get; set; }
        public decimal TotalDescontoReais { get; set; }

        private void frmDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        break;

                    case Keys.Enter:

                        if (txtDescontoPer.Text != String.Empty)
                        {
                            // throw new Exception("Informe o valor de desconto ou ESC para sair.");


                            valorDesconto = decimal.Parse(txtDescontoPer.Text);
                            string autoriza = "não";

                            if (valorDesconto > 0)
                            {

                                if (valorDesconto > 20)
                                {
                                    verificacaoUsuario frm = new verificacaoUsuario();
                                    frm.ShowDialog();
                                    if (frm.permissao != "Gerente")
                                    {
                                        throw new Exception("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                                        frm = null;
                                        autoriza = "Sim";
                                    }
                                    else
                                    {

                                        //TotalDescontoReais = valorDesconto * valorTotal / 100;

                                        TotalDescontoReais = Math.Round(((valorTotal * valorDesconto) / 100), 2);
                                        this.Close();
                                    }

                                }
                                else
                                {

                                    TotalDescontoReais = Math.Round(((valorTotal * valorDesconto) / 100), 2);
                                    this.Close();
                                }
                            }
                        }
                        else
                        {
                            if (txtDescontoValor.Text != String.Empty)
                            {
                                TotalDescontoReais = Math.Round((decimal.Parse(txtDescontoValor.Text)), 2);                               
                                //autoriza = "Sim";
                                this.Close();
                            }
                            else
                            {
                                throw new Exception("Nenhum desconto Informado !");
                            }
                        }

                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtDescontoPer_TextChanged(object sender, EventArgs e)
        {



        }

        private void pnlDinheiro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDesconto_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Moeda(ref txtDescontoValor);
                decimal totalvenda = decimal.Parse(txtDescontoValor.Text);

            }
            catch
            {
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

    }
}
