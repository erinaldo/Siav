using One.Dal;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmAdicionarDinheiroCaixa_ : Form
    {
        public frmAdicionarDinheiroCaixa_()
        {
            InitializeComponent();
        }
        public void AdicionarDinheioCaixa()
        {
            SqlCommand cmd = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                   "INSERT INTO  MovimentoCaixa ",
                       "(   Data",
                       ",   Usuario",
                       ",   NumeroCaixa",
                       ",   TipoMovimento",
                       ",   ValorMovimento",
                       ",   Motivo",
                       ",  IDAber",
                       "  )",
                 "VALUES",
                       "(   @Data",
                       ",   @Usuario",
                       ",   @NumeroCaixa",
                       ",   @TipoMovimento",
                       ",   @ValorMovimento",
                        ",  @Motivo",
                         ",  @IDAber",
                       "  )"
                    );
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = txtUsuario.Text;
                cmd.Parameters.Add(new SqlParameter("@NumeroCaixa", SqlDbType.VarChar)).Value = "01";
                cmd.Parameters.Add(new SqlParameter("@TipoMovimento", SqlDbType.VarChar)).Value = "Crédito Caixa";
                cmd.Parameters.Add(new SqlParameter("@ValorMovimento", SqlDbType.Decimal)).Value = decimal.Parse(txtValorAdicionado.Text);
                cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar)).Value = txtMotivo.Text;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = int.Parse(lblCodigoAbertura.Text.ToString());
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void maskedTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void txtValorAdicionado_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtValorAdicionado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtValorAdicionado.Text == "")
                {
                    throw new Exception("Informe o valor que será adicionado!");
                }
                if (MessageBox.Show("Tem Certezza que deseja adicionar o valor de R$ " + txtValorAdicionado.Text.ToString() + " no caixa? Confira os valores e veja se realmente estão corretos.", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    AdicionarDinheioCaixa();
                    MessageBox.Show("Valor inserido no caixa com sucesso!");
                    #region Abrir Gaveta

                    int iRetorno = 0;
                    int charCode = 27;
                    int charCode2 = 118;
                    int charCode3 = 140;
                    Char specialChar = Convert.ToChar(charCode);
                    Char specialChar2 = Convert.ToChar(charCode2);
                    Char specialChar3 = Convert.ToChar(charCode3);
                    string s_cmdTX = "" + specialChar + specialChar2 + specialChar3;
                    //iRetorno = MP2032.ComandoTX(s_cmdTX, s_cmdTX.Length);

                    #endregion
                    this.Close();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAdicionarDinheiroCaixa__Load(object sender, EventArgs e)
        {
            txtMotivo.Focus();
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
        private void txtValorAdicionado_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtValorAdicionado);
        }

        private void txtValorAdicionado_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtValorAdicionado.Text == "")
                {
                    throw new Exception("Informe o valor que será adicionado!");
                }
                if (txtMotivo.Text == "")
                {
                    throw new Exception("Informe o motivo.");
                }
                if (MessageBox.Show("Tem Certezza que deseja adicionar o valor de R$ " + txtValorAdicionado.Text.ToString() + " no caixa? Confira os valores e veja se realmente estão corretos.", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    AdicionarDinheioCaixa();
                    MessageBox.Show("Valor inserido no caixa com sucesso!");
                    #region Abrir Gaveta

                    int iRetorno = 0;
                    int charCode = 27;
                    int charCode2 = 118;
                    int charCode3 = 140;
                    Char specialChar = Convert.ToChar(charCode);
                    Char specialChar2 = Convert.ToChar(charCode2);
                    Char specialChar3 = Convert.ToChar(charCode3);
                    string s_cmdTX = "" + specialChar + specialChar2 + specialChar3;
                    //iRetorno = MP2032.ComandoTX(s_cmdTX, s_cmdTX.Length);

                    #endregion
                    this.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
