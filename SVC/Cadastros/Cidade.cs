using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using One.Bll;
using One.Dal;
using View;
namespace One.CADASTROS
{
    public partial class Cidade : Form
    {
        public Cidade()
        {
            InitializeComponent();
        }

        CidadeBLL objCid = new CidadeBLL();

        public void carregaCombo()
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbEstado, "Estado", "est_codigo", "est_sigla", "", "est_sigla");
                objD = null;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void stiloGrid()
        {

            //int i = 0;
            //if (gvPesquisa.Rows.Count != 0)
            //{
            //    foreach (DataGridViewRow row in gvPesquisa.Rows)
            //    {
            //        if (i % 2 != 0)
            //        {
            //            row.DefaultCellStyle.BackColor = Color.FromName("ActiveCaption");
            //            row.DefaultCellStyle.ForeColor = Color.White;
            //        }
            //        i++;
            //    }
            //}
            //gvPesquisa.ClearSelection();
            //objCid.limpar();
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                cbEstado.SelectedIndex = -1;
                txtDescricao.Text = "";
                txtPesquisar.Text = "";
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
                    objCid.cid_codigo = int.Parse(txtCodigo.Text);                
                else
                    objCid.cid_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objCid.cid_nome = txtDescricao.Text;
                else
                    throw new Exception("O campo cidade é de preenchimento obrigatório");
                if (cbEstado.SelectedValue == null)
                    throw new Exception("Estado não encontrado na base de dados");
                objCid.cid_estado = int.Parse(cbEstado.SelectedValue.ToString());
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
                if (objCid.cid_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objCid.cid_codigo.ToString();
                txtDescricao.Text = objCid.cid_nome;
                cbEstado.SelectedValue = objCid.cid_estado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;
                tab = objCid.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["cid_codigo"].HeaderText = "Código da Cidade";
                gvPesquisa.Columns["cid_nome"].HeaderText = "Nome";
                gvPesquisa.Columns["est_sigla"].HeaderText = "Estado";
                gvPesquisa.Columns["est_codigo"].HeaderText = "Código do Estado";
                gvPesquisa.Columns[0].Width = gvPesquisa.Width / 4;
                gvPesquisa.Columns[1].Width = gvPesquisa.Width / 4;
                gvPesquisa.Columns[2].Width = gvPesquisa.Width / 4;
                gvPesquisa.Columns[3].Width = gvPesquisa.Width / 4 -19;
              //  stiloGrid();
                gvPesquisa.ClearSelection();
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
        
        private void Cidade_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode =
              DataGridViewAutoSizeColumnsMode.AllCells;
            try
            {
                this.MaximumSize = new Size(this.Width, this.Height);
                this.MinimumSize = new Size(this.Width, this.Height);
                carregaCombo();
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

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objCid.limpar();
                    objCid.localizarLeave(cod.ToString(), "cid_codigo");
                    if (objCid.cid_codigo != 0)
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

        private void btPrimeiro_Click(object sender, EventArgs e)
        {
          
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
           
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            
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

        private void gvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                {
                    int cod = 0;
                    cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {
                        TabControl1.SelectedIndex = 0;
                        txtPesquisar.Text = "";
                        objCid.cid_codigo = cod;
                        objCid.localizar(objCid.cid_codigo.ToString(), "cid_codigo");
                        txtCodigo.Text = objCid.cid_codigo.ToString();
                        txtCodigo.Enabled = false;
                        carregaCampos();
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objCid.limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    this.MaximumSize = new Size(this.Width, this.Height + 100);
                    this.MinimumSize = new Size(this.Width, this.Height + 100);
                    this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
                    btAnterior.Enabled = false;
                    btPrimeiro.Enabled = false;
                    btProximo.Enabled = false;
                    btUltimo.Enabled = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objCid.limpar();
                    this.MaximumSize = new Size(this.Width, this.Height - 50);
                    this.MinimumSize = new Size(this.Width, this.Height - 50);
                    this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    btAnterior.Enabled = true;
                    btPrimeiro.Enabled = true;
                    btProximo.Enabled = true;
                    btUltimo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gvPesquisa_Sorted(object sender, EventArgs e)
        {
            //try
            //{
            //    stiloGrid();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //} 
        }

        private void gvPesquisa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                {
                    objCid.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "cid_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objCid.cid_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se cidade já existe
                    objCid.localizarLeave(objCid.cid_nome, "cid_nome"); //Pesquisa por descrição, na coluna descrição
                    if (objCid.cid_codigo != 0) // se o código retornar um número acima de 0, significa que a cidade já está cadastrada
                        throw new Exception("Esta cidade já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objCid.inserir();
                    objCid.limpar();
                    limpar();
                    MessageBox.Show("Cidade incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objCid.alterar();
                    objCid.limpar();
                    limpar();
                    MessageBox.Show("Cidade alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            try
            {
                objCid.limpar();
                limpar();
                txtCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (objCid.cid_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objCid.excluir();
                        objCid.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Cidade excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma cidade na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta cidade está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btPrimeiro_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objCid.localizarPrimeiroUltimo("primeiro");
                if (objCid.cid_codigo != 0)
                {
                    objCid.localizar(objCid.cid_codigo.ToString(), "cid_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btAnterior_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objCid.localizarProxAnterior("anterior", 0);
                else
                    objCid.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objCid.cid_codigo != 0)
                {
                    objCid.localizar(objCid.cid_codigo.ToString(), "cid_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btProximo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objCid.localizarProxAnterior("proximo", 0);
                else
                    objCid.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objCid.cid_codigo != 0)
                {
                    objCid.localizar(objCid.cid_codigo.ToString(), "cid_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btUltimo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objCid.localizarPrimeiroUltimo("ultimo");
                if (objCid.cid_codigo != 0)
                {
                    objCid.localizar(objCid.cid_codigo.ToString(), "cid_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objCid.cid_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se cidade já existe
                    objCid.localizarLeave(objCid.cid_nome, "cid_nome"); //Pesquisa por descrição, na coluna descrição
                    if (objCid.cid_codigo != 0) // se o código retornar um número acima de 0, significa que a cidade já está cadastrada
                        throw new Exception("Esta cidade já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objCid.inserir();
                    objCid.limpar();
                    limpar();
                    MessageBox.Show("Cidade incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objCid.alterar();
                    objCid.limpar();
                    limpar();
                    MessageBox.Show("Cidade alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
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
                objCid.limpar();
                limpar();
                txtCodigo.Enabled = true;
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
                if (objCid.cid_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objCid.excluir();
                        objCid.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Cidade excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma cidade na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta cidade está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
