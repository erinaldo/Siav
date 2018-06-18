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
    public partial class Unidades : Form
    {
        public Unidades()
        {
            InitializeComponent();
        }

        UnidadesBLL objUni = new UnidadesBLL();

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
                gvPesquisa.ClearSelection();
                objUni.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtDescricao.Text = "";
                txtPesquisar.Text = "";
                txtCodigo.ReadOnly = false;
                txtCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void carregaPropriedades()
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    objUni.uni_codigo = int.Parse(txtCodigo.Text);
                    txtCodigo.Enabled = false;
                }
                else
                    objUni.uni_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objUni.uni_descricao = txtDescricao.Text;
                else
                    throw new Exception("O campo descrição é de preenchimento obrigatório");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaCampos()
        {
            try
            {
                if (objUni.uni_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objUni.uni_codigo.ToString();
                txtDescricao.Text = objUni.uni_descricao;

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
                tab = objUni.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["uni_codigo"].HeaderText = "Código";
                gvPesquisa.Columns["uni_descricao"].HeaderText = "Nome";
                gvPesquisa.Columns[1].Width = gvPesquisa.Width - 103;
               //;/; stiloGrid();
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

        private void Unidades_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode =
             DataGridViewAutoSizeColumnsMode.AllCells;
            
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

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objUni.limpar();
                    objUni.localizarLeave(cod.ToString(), "uni_codigo");
                    if (objUni.uni_codigo != 0)
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
                        objUni.uni_codigo = cod;
                        objUni.localizar(objUni.uni_codigo.ToString(), "uni_codigo");
                        txtCodigo.Text = objUni.uni_codigo.ToString();
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
                    objUni.limpar();
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
                    objUni.limpar();
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
                    objUni.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "uni_codigo");
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

                if (objUni.uni_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se categoria já existe
                    objUni.localizarLeave(objUni.uni_descricao, "uni_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objUni.uni_codigo != 0) // se o código retornar um número acima de 0, significa que a categoria já está cadastrada
                        throw new Exception("Esta unidade já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objUni.inserir();
                    objUni.limpar();
                    limpar();
                    MessageBox.Show("Unidade incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objUni.alterar();
                    objUni.limpar();
                    limpar();
                    MessageBox.Show("Unidade alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objUni.limpar();
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
                if (objUni.uni_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objUni.excluir();
                        objUni.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Unidade excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma unidade na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta unidade está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                objUni.localizarPrimeiroUltimo("primeiro");
                if (objUni.uni_codigo != 0)
                {
                    objUni.localizar(objUni.uni_codigo.ToString(), "uni_codigo");
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
                    objUni.localizarProxAnterior("anterior", 0);
                else
                    objUni.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objUni.uni_codigo != 0)
                {
                    objUni.localizar(objUni.uni_codigo.ToString(), "uni_codigo");
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
                    objUni.localizarProxAnterior("proximo", 0);
                else
                    objUni.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objUni.uni_codigo != 0)
                {
                    objUni.localizar(objUni.uni_codigo.ToString(), "uni_codigo");
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
                objUni.localizarPrimeiroUltimo("ultimo");
                if (objUni.uni_codigo != 0)
                {
                    objUni.localizar(objUni.uni_codigo.ToString(), "uni_codigo");
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

                if (objUni.uni_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se categoria já existe
                    objUni.localizarLeave(objUni.uni_descricao, "uni_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objUni.uni_codigo != 0) // se o código retornar um número acima de 0, significa que a categoria já está cadastrada
                        throw new Exception("Esta unidade já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objUni.inserir();
                    objUni.limpar();
                    limpar();
                    MessageBox.Show("Unidade incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objUni.alterar();
                    objUni.limpar();
                    limpar();
                    MessageBox.Show("Unidade alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objUni.limpar();
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
                if (objUni.uni_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objUni.excluir();
                        objUni.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Unidade excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma unidade na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta unidade está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
