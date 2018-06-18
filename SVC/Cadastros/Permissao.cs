using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using System.Data.SqlClient;
using View;
namespace One.CADASTROS
{
    public partial class Permissao : Form
    {
        public Permissao()
        {
            InitializeComponent();
        }

        PermissaoBLL objPer = new PermissaoBLL();
        TelasBLL objTel = new TelasBLL();

        public void stiloGrid()
        {

            int i = 0;
            if (gvPesquisa.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in gvPesquisa.Rows)
                {
                    if (i % 2 != 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromName("ActiveCaption");
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    i++;
                }
                gvPesquisa.ClearSelection();
                objPer.limpar();
                objTel.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
                txtPesquisar.Text = "";

                txtDescricao.Enabled = true;
                txtDescricao.ReadOnly = false;
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;                
                //checkbox
                Categoria.Checked = false;
                Cidade.Checked = false;
                Cliente.Checked = false;
                Compras.Checked = false;
                ContasAPagar.Checked = false;
                ContasAReceber.Checked = false;
                Empresa.Checked = false;
                EntradaMercadoria.Checked = false;
                Estado.Checked = false;
                Forma_Pagamento.Checked = false;
                Fornecedor.Checked = false;
                frm_CodigoBarra.Checked = false;
                frm_Fechamento.Checked = false;
                Grupo.Checked = false;
                Marca.Checked = false;
                Permissa.Checked = false;
                Produto.Checked = false;
                Subgrupo.Checked = false;
                TrocaDeProdutos.Checked = false;
                Unidades.Checked = false;
                Usuario.Checked = false;
                Vendas.Checked = false;
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;
                tab = objPer.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["per_codigo"].HeaderText = "Código";
                gvPesquisa.Columns["per_nome"].HeaderText = "Nome";
                gvPesquisa.Columns[1].Width = gvPesquisa.Width - 103;
                stiloGrid();
                gvPesquisa.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void carregaPropriedades()
        {
            try
            {
                if (txtCodigo.Text != "")
                    objPer.per_codigo = int.Parse(txtCodigo.Text);
                else
                    objPer.per_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objPer.per_nome= txtDescricao.Text;
                else
                    throw new Exception("O campo descrição é de preenchimento obrigatório");


            }
            catch (Exception )
            {
                throw;
            }
        }

        public void TelasInserir()
        {
            try
            {
                objTel.per_codigo = objPer.per_codigo;
                // vamos percorrer todos os controles do formulário
                for (int i = 0; i < groupBox1.Controls.Count; i++)
                {
                    // vamos testar se o controle é do tipo CheckBox
                    if (groupBox1.Controls[i] is System.Windows.Forms.CheckBox)
                    {
                        // é do tipo CheckBox. Vamos marcar
                        objTel.ct_name = groupBox1.Controls[i].Name;
                        objTel.ct_nome= groupBox1.Controls[i].Text;
                        if ((groupBox1.Controls[i] as CheckBox).Checked == true)
                            objTel.ct_status = "true";
                        else
                            objTel.ct_status = "false";

                        objTel.inserir();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void TelasAlterar()
        {
            try
            {
                objTel.per_codigo = objPer.per_codigo;
                objTel.excluir();
                objTel.per_codigo = objPer.per_codigo;
                // vamos percorrer todos os controles do formulário
                for (int i = 0; i < groupBox1.Controls.Count; i++)
                {
                    // vamos testar se o controle é do tipo CheckBox
                    if (groupBox1.Controls[i] is System.Windows.Forms.CheckBox)
                    {
                        // é do tipo CheckBox. Vamos marcar
                        objTel.ct_name = groupBox1.Controls[i].Name;
                        objTel.ct_nome = groupBox1.Controls[i].Text;
                        if ((groupBox1.Controls[i] as CheckBox).Checked == true)
                            objTel.ct_status = "true";
                        else
                            objTel.ct_status = "false";

                        objTel.inserir();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void carregaCampos()
        {
            try
            {
                objTel.per_codigo = objPer.per_codigo;
                objPer.localizar(objTel.per_codigo.ToString(), "per_codigo");
                txtDescricao.Text = objPer.per_nome;
                DataTable tab = objTel.localizarComRetorno(objPer.per_codigo.ToString(),"per_codigo");
                int j = 0;
                do
                {
                    for (int i = 0; i < groupBox1.Controls.Count; i++)
                    {
                        if (j < tab.Rows.Count)
                        {
                            if (groupBox1.Controls[i].Name == tab.Rows[j][3].ToString())
                            {
                                (groupBox1.Controls[i] as CheckBox).Checked = bool.Parse(tab.Rows[j][2].ToString());
                                j++;
                            }
                        }
                        else
                            break;
                    }
                }
                while (j < tab.Rows.Count);
                j = 0;
                tab = null;
                txtDescricao.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void Permissao_Load(object sender, EventArgs e)
        {
            try
            {
                this.MaximumSize = new Size(this.Width, this.Height);
                this.MinimumSize = new Size(this.Width, this.Height);
                TabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }   
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 1)
            {
                objPer.limpar();
                objTel.limpar();
                limpar();
                carregaGrid();
                txtPesquisar.Focus();
                this.MaximumSize = new Size(this.Width, this.Height + 100);
                this.MinimumSize = new Size(this.Width, this.Height + 100);
                this.Size = new Size(this.Width, this.Height + 100);
                //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
            }
            else if (TabControl1.SelectedIndex == 0)
            {
                objPer.limpar();
                objTel.limpar();
                this.MaximumSize = new Size(this.Width, this.Height - 50);
                this.MinimumSize = new Size(this.Width, this.Height - 50);
                this.Size = new Size(this.Width, this.Height - 50);
                //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);                
            }
        }

        private void gvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
            //    {
            //        int cod = 0;
            //        cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
            //        if (cod != 0)
            //        {
            //            TabControl1.SelectedIndex = 0;
            //            txtPesquisar.Text = "";
            //            objPer.per_codigo = cod;
            //            objPer.localizar(objPer.per_codigo.ToString(), "per_codigo");
            //            txtCodigo.Text = objPer.per_codigo.ToString();
            //            txtCodigo.Enabled = false;
            //            carregaCampos();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int catcod;
                int.TryParse(txtCodigo.Text, out catcod);
                if (catcod != 0)
                {
                    objPer.limpar();
                    objPer.localizarLeave(catcod.ToString(), "per_codigo");
                    if (objPer.per_codigo != 0)
                    {
                        carregaCampos();
                        txtCodigo.Enabled = false;
                    }
                    else
                        limpar();
                }
                else
                    limpar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                carregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gvPesquisa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                {
                    objPer.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "per_codigo");
                    //objTel.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "per_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void gvPesquisa_Sorted(object sender, EventArgs e)
        {
            try
            {
                stiloGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }   

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                carregaPropriedades();

                if (objPer.per_codigo == 0)
                {
                    objPer.localizarLeave(txtDescricao.Text, "per_nome");
                    if (objPer.per_codigo != 0)
                        throw new Exception("Perfil já existente, selecione outor nome por favor");
                    objPer.inserir();
                    objPer.localizarLeave(txtDescricao.Text, "per_nome");
                    TelasInserir();
                    MessageBox.Show("Perfil incluído com sucesso", "Sucesso");
                }
                else
                {
                    objPer.localizar();
                    objPer.alterar();
                    TelasAlterar();
                    MessageBox.Show("Perfil alterado com sucesso", "Sucesso");
                }

                limpar();
                objPer.limpar();
                objTel.limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (objPer.per_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objTel.per_codigo = objPer.per_codigo;
                        objTel.excluir();
                        objPer.excluir();
                        objTel.limpar();
                        objPer.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Permissão excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma permissão na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta permissão está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {

           printDGV.Print_DataGridView(gvPesquisa);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                carregaPropriedades();

                if (objPer.per_codigo == 0)
                {
                    objPer.localizarLeave(txtDescricao.Text, "per_nome");
                    if (objPer.per_codigo != 0)
                        throw new Exception("Perfil já existente, selecione outor nome por favor");
                    objPer.inserir();
                    objPer.localizarLeave(txtDescricao.Text, "per_nome");
                    TelasInserir();
                    MessageBox.Show("Perfil incluído com sucesso", "Sucesso");
                }
                else
                {
                    objPer.localizar();
                    objPer.alterar();
                    TelasAlterar();
                    MessageBox.Show("Perfil alterado com sucesso", "Sucesso");
                }

                limpar();
                objPer.limpar();
                objTel.limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (objPer.per_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objTel.per_codigo = objPer.per_codigo;
                        objTel.excluir();
                        objPer.excluir();
                        objTel.limpar();
                        objPer.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Permissão excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma permissão na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta permissão está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
