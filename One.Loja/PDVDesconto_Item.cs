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
    public partial class PDVDesconto_Item : Form
    {

        decimal valorDesconto = 0;
        decimal TotalDescontoReais = 0;
        decimal valorTotal = 0;

        public PDVDesconto_Item()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescontoPer_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDescontoPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDescontoPer_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        this.Close();
                        break;

                    case Keys.Enter:

                        if (txtDescontoPer.Text == String.Empty)
                        {
                            throw new Exception("Informe o valor de desconto ou ESC para sair.");
                        }

                        valorDesconto = decimal.Parse(txtDescontoPer.Text);
                        string autoriza = "não";
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


                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
