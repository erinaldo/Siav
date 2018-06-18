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
    public partial class frmPesquisaProdutoNovo : Form
    {
        public frmPesquisaProdutoNovo(Form parent)
        {
            InitializeComponent();
            //this.Parent = parent;
            ProdutosBLL objPro = new ProdutosBLL();
            DataTable tab = null;

            tab = objPro.localizarEmTudoLITE(txtProdutos.Text, false);
            if (tab.Rows.Count > 0)
            {
                dgDados.DataSource = tab;
            }
            dgDados.Rows[0].Selected = true;
        }

        public String Codigo;
        public String id_produto;

        private void txtProdutos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                DataTable tab = null;
                DataTable tab1 = null;
                tab1 = objPro.localizarEmTudoLITE(txtProdutos.Text,false);
                tab = objPro.localizarEmTudoLITE(txtProdutos.Text,false);
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

                dgDados.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Erro ao pesquisar o produto!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try{            
                this.Codigo = dgDados.CurrentRow.Cells[7].Value.ToString();
                this.id_produto = dgDados.CurrentRow.Cells[0].Value.ToString();
                this.Dispose();
         
            }catch (Exception ee){

                String depura = "";
            
            }

        }

        private void frmPesquisaProdutoNovo_Load(object sender, EventArgs e)
        {
            txtProdutos.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
