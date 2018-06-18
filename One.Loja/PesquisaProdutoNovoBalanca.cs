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
    public partial class PesquisaProdutoNovoBalanca : Form
    {

        public String produto = "0";
        public decimal valor_produto = 0;
        public decimal valor = 0;
        public Boolean finalizado = false;
        public String nome_produto = "";
        public decimal quantidade = 0;

        public PesquisaProdutoNovoBalanca()
        {
            InitializeComponent();
        }

        private void peso_gramas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 gramas = Int32.Parse(peso_gramas.Text);
                this.valor = (gramas * this.valor_produto) / 1000;
                lbl_valor_final.Text = "R$ " + Math.Round(this.valor, 2);
            }
            catch
            {

            }
        }

        private void peso_gramas_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                int grama = int.Parse(peso_gramas.Text);
                





            }
            catch
            {
                lbl_valor_final.Text = "R$ 0.00";

            }
        }

        private void txtProdutos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                DataTable tab = null;
                tab = objPro.localizarEmTudo_Balanca(txtProdutos.Text);
                if (tab.Rows.Count > 0)
                {
                    dgDados.DataSource = tab;
                }
                // if(tab1.Rows.Count > 0 )
                // {
                //     txtDescricao.Text = tab1.Rows[0][4].ToString();
                //     txtBarra.Text = tab1.Rows[0][3].ToString();
                //     txtUND.Text = tab1.Rows[0][2].ToString();
                //     txtValor.Text = tab1.Rows[0][1].ToString();
                //     //if (tab1.Rows[0]["Imagem"].ToString() != "")
                //     //{
                //     //    byte[] data0 = (byte[])tab1.Rows[0]["Imagem"];
                //     //    MemoryStream ms0 = new MemoryStream(data0);
                //     //    pictImageProduto.Image = Image.FromStream(ms0);
                //     //}
                //
                // }
                // else
                // {
                //     txtDescricao.Text = string.Empty;
                //     txtBarra.Text = string.Empty;
                //     txtUND.Text = string.Empty;
                //     txtValor.Text = string.Empty;
                // }

                //dgDados.ClearSelection();
                
                //dgDados.Rows[0].Selected = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao pesquisar o produto!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDados_DoubleClick(object sender, EventArgs e)
        {
            try{
                this.produto = dgDados.CurrentRow.Cells[0].Value.ToString();
                ProdutosBLL cmd = new ProdutosBLL();
                DataTable tb = cmd.localizarComRetorno(this.produto, "pro_codigo");

                this.nome_produto = tb.Rows[0].ItemArray[1].ToString();
                this.valor_produto = decimal.Parse(tb.Rows[0].ItemArray[4].ToString());
                lbl_valor_kg.Text = "R$ " + tb.Rows[0].ItemArray[4].ToString();
                peso_gramas.Text = "";
                peso_gramas.Focus();
            }
            catch (Exception ee)
            {
                String depura = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 x = Int32.Parse(peso_gramas.Text);

                if (x > 0 && this.produto != "" && this.produto != "0")
                {
                    this.quantidade = (decimal.Parse(peso_gramas.Text)) / 1000;
                    this.finalizado = true;
                    this.Dispose();
                    //this.produto 
                        
                }else{
                    MessageBox.Show("Você precisa informar um produto e um peso em gramas para inserir o produto !");
                }
            }
            catch
            {

            }
        }
    }
}
