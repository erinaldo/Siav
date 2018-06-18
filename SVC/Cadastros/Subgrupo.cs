using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using One.Dal;
using System.Data.SqlClient;
using View;

namespace One.CADASTROS
{
    public partial class Sub_Grupo : Form
    {
        public Sub_Grupo()
        {
            InitializeComponent();
        }

        SubGrupoBLL objSG = new SubGrupoBLL();

        public void carregaCombo()
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbGrupo, "Grupo", "gru_codigo", "gru_descricao", "", "gru_descricao");
                objD = null;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

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
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    i++;
                }
            }
            gvPesquisa.ClearSelection();
            objSG.limpar();
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                cbGrupo.SelectedIndex = -1;
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
                {
                    objSG.sg_codigo = int.Parse(txtCodigo.Text);
                    txtCodigo.Enabled = false;
                }
                else
                    objSG.sg_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objSG.sg_descricao = txtDescricao.Text;
                else
                    throw new Exception("O campo descrição é de preenchimento obrigatório");
                if (cbGrupo.SelectedValue == null)
                    throw new Exception("Grupo não encontrado na base de dados");
                objSG.sg_grupo = int.Parse(cbGrupo.SelectedValue.ToString());
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
                if (objSG.sg_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objSG.sg_codigo.ToString();
                txtDescricao.Text = objSG.sg_descricao;
                cbGrupo.SelectedValue = objSG.sg_grupo;

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
                tab = objSG.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["sg_codigo"].HeaderText = "Código do Subgrupo";
                gvPesquisa.Columns["sg_descricao"].HeaderText = "Nome";
                gvPesquisa.Columns["gru_descricao"].HeaderText = "Grupo";
                gvPesquisa.Columns["gru_codigo"].HeaderText = "Código do Grupo";
                gvPesquisa.Columns[0].Width = gvPesquisa.Width/4;
                gvPesquisa.Columns[1].Width = gvPesquisa.Width / 4;
                gvPesquisa.Columns[2].Width = gvPesquisa.Width / 4;
                gvPesquisa.Columns[3].Width = gvPesquisa.Width / 4-2;
                //stiloGrid();
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

        private void Sub_Grupo_Load(object sender, EventArgs e)
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
                    objSG.limpar();
                    objSG.localizarLeave(cod.ToString(), "sg_codigo");
                    if (objSG.sg_codigo != 0)
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
                        objSG.sg_codigo = cod;
                        objSG.localizar(objSG.sg_codigo.ToString(), "sg_codigo");
                        txtCodigo.Text = objSG.sg_codigo.ToString();
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
                    objSG.limpar();
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
                    objSG.limpar();
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
                    objSG.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "sg_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objSG.sg_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se subgrupo já existe
                    //objSG.localizarLeave(objSG.sg_descricao, "sg_descricao"); //Pesquisa por descrição, na coluna descrição
                    //if (objSG.sg_codigo != 0) // se o código retornar um número acima de 0, significa que a subgrupo já está cadastrada
                    //    throw new Exception("Este subgrupo já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objSG.inserir();
                    objSG.limpar();
                    limpar();
                    MessageBox.Show("Subgrupo incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objSG.alterar();
                    objSG.limpar();
                    limpar();
                    MessageBox.Show("Subgrupo alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                objSG.limpar();
                limpar();
                txtCodigo.Enabled = true;
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
                if (objSG.sg_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objSG.excluir();
                        objSG.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Subgrupo excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um subgrupo na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este subgrupo está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objSG.localizarPrimeiroUltimo("primeiro");
                if (objSG.sg_codigo != 0)
                {
                    objSG.localizar(objSG.sg_codigo.ToString(), "sg_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objSG.localizarProxAnterior("anterior", 0);
                else
                    objSG.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objSG.sg_codigo != 0)
                {
                    objSG.localizar(objSG.sg_codigo.ToString(), "sg_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objSG.localizarProxAnterior("proximo", 0);
                else
                    objSG.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objSG.sg_codigo != 0)
                {
                    objSG.localizar(objSG.sg_codigo.ToString(), "sg_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
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
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objSG.localizarPrimeiroUltimo("ultimo");
                if (objSG.sg_codigo != 0)
                {
                    objSG.localizar(objSG.sg_codigo.ToString(), "sg_codigo");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objSG.sg_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se subgrupo já existe
                    //objSG.localizarLeave(objSG.sg_descricao, "sg_descricao"); //Pesquisa por descrição, na coluna descrição
                    //if (objSG.sg_codigo != 0) // se o código retornar um número acima de 0, significa que a subgrupo já está cadastrada
                    //    throw new Exception("Este subgrupo já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objSG.inserir();
                    objSG.limpar();
                    limpar();
                    MessageBox.Show("Subgrupo incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objSG.alterar();
                    objSG.limpar();
                    limpar();
                    MessageBox.Show("Subgrupo alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
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
                objSG.limpar();
                limpar();
                txtCodigo.Enabled = true;
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
                if (objSG.sg_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objSG.excluir();
                        objSG.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Subgrupo excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um subgrupo na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este subgrupo está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
