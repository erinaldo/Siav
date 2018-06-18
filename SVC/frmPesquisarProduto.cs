using One.Bll;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.FrenteDeLoja
{
    public partial class frmPesquisarProduto : Form
    {
        public string Codigo { get; set; }
        public frmPesquisarProduto()
        {
            InitializeComponent();
        }
 
        private void txtCodigoDeBarras_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                DataTable tab = null;
                DataTable tab1 = null;
                tab1 = objPro.localizarProdutoCodigoBarra(txtProdutos.Text);
                tab = objPro.localizarEmTudo(txtProdutos.Text);
                if (tab.Rows.Count > 0)
                {
                   
                    dgDados.DataSource = tab;
                }
                if(tab1.Rows.Count > 0 )
                {
                    txtDescricao.Text = tab1.Rows[0][4].ToString();
                    txtBarra.Text = tab1.Rows[0][3].ToString();
                    txtUND.Text = tab1.Rows[0][2].ToString();
                    txtValor.Text = tab1.Rows[0][1].ToString();
                    if (tab1.Rows[0]["Imagem"].ToString() != "")
                    {
                        byte[] data0 = (byte[])tab1.Rows[0]["Imagem"];
                        MemoryStream ms0 = new MemoryStream(data0);
                        pictImageProduto.Image = Image.FromStream(ms0);
                    }

                }
                else
                {
                    txtDescricao.Text = string.Empty;
                    txtBarra.Text = string.Empty;
                    txtUND.Text = string.Empty;
                    txtValor.Text = string.Empty;
                }
                
                //dgDados.ClearSelection();
                dgDados.Rows[0].Selected = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao pesquisar o produto!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
     
        private void dgDados_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgDados.SelectedRows[0];
                txtBarra.Text = dr.Cells[4].Value.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPesquisarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                dgDados.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
                ProdutosBLL objPro = new ProdutosBLL();
                DataTable tab = null;
                tab = objPro.localizarEmTudo(txtProdutos.Text);
                dgDados.DataSource = tab;
                //dgDados.ClearSelection();
                //dgDados.Rows[0].Selected = true;
                //dgDados.Columns[2].Visible = false;
                //dgDados.Columns[3].DefaultCellStyle.BackColor = Color.Yellow;
                //dgDados.Columns[3].DefaultCellStyle.ForeColor = Color.Red;
                //dgDados.Columns[4].Visible = false;
                //dgDados.Columns[5].Visible = false;
                //dgDados.Columns[6].Visible = false;
                //dgDados.Columns[7].Visible = false;
                //dgDados.Columns[8].Visible = false;
                //dgDados.Columns[9].Visible = false;
                //dgDados.Columns[10].Visible = false;
                //dgDados.Columns[11].Visible = false;
                //dgDados.Columns[12].Visible = false;
                //dgDados.Columns[13].Visible = false;
                //dgDados.Columns[14].Visible = false;
                //dgDados.Columns[15].Visible = false;
                //dgDados.Columns[16].Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Atribuir valor na propriedade
            Codigo = txtBarra.Text.ToString();
            //Fechar este Form
            this.Close();
        }

        private void dgDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataGridViewRow dr = dgDados.SelectedRows[0];
                    txtBarra.Text = dr.Cells[5].Value.ToString();
                    //button1.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtProdutos_Enter(object sender, EventArgs e)
        {
            //\\dgDados.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtProdutos.Focus();
            txtBarra.Text = "";
            txtProdutos.Text = "";
            dgDados.DataSource = null;
            
        }
        public void limpar()
        {
            dgDados.Rows.Clear();
            txtBarra.Text = String.Empty;
            txtUND.Text = String.Empty;
            txtValor.Text = String.Empty;
            txtDescricao.Text = String.Empty;
        }
        private void frmPesquisarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                    case Keys.F3:
                    limpar();
                    break;
                    
                   case Keys.F12:
                    this.Close();
                    break;
                   case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Codigo = txtBarra.Text.ToString();
                //Fechar este Form
                this.Close();
            }
        }

        private void dgDados_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            /* Pegando valor de uma celula do DataGridView */
            int quantidade = int.Parse(dgv.Rows[e.RowIndex].Cells[7].Value.ToString());
            int quantidadeMin = int.Parse(dgv.Rows[e.RowIndex].Cells[8].Value.ToString());
            if (quantidade == 0)
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
            }
            else if (quantidadeMin >= quantidade)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
        }
    }
}

