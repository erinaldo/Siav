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
using View;

namespace One.CADASTROS
{
	public partial class Forma_Pagamento: Form
	{
		public Forma_Pagamento()
		{
			InitializeComponent();
        }

        FormaPagamentoBLL objFP = new FormaPagamentoBLL();

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
                objFP.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                txtDescricao.Text = "";
                txtPesquisar.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaPropriedades()
        {
            try
            {
                if (txtCodigo.Text != "")
                    objFP.fp_codigo = int.Parse(txtCodigo.Text);
                else
                    objFP.fp_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objFP.fp_descricao = txtDescricao.Text;
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
                if (objFP.fp_codigo== 0)
                    throw new Exception("Registro não encontrado");
                else
                    txtCodigo.Text = objFP.fp_codigo.ToString();
                txtDescricao.Text = objFP.fp_descricao;

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
                tab = objFP.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["fp_codigo"].HeaderText = "Código";
                gvPesquisa.Columns["fp_descricao"].HeaderText = "Nome";
                gvPesquisa.Columns[1].Width = gvPesquisa.Width - 103;
               // stiloGrid();
                gvPesquisa.ClearSelection();
            }
            catch (Exception)
            {

                throw;
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
                    objFP.limpar();
                    objFP.localizarLeave(cod.ToString(), "fp_codigo");
                    if (objFP.fp_codigo != 0)
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
                        objFP.fp_codigo = cod;
                        objFP.localizar(objFP.fp_codigo.ToString(), "fp_codigo");
                        txtCodigo.Text = objFP.fp_codigo.ToString();
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
                    objFP.limpar();
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
                    objFP.limpar();
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void Forma_Pagamento_Load(object sender, EventArgs e)
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
                    objFP.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "fp_codigo");
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

                if (objFP.fp_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se Forma de Pagamento já existe
                    objFP.localizarLeave(objFP.fp_descricao, "fp_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objFP.fp_codigo != 0) // se o código retornar um número acima de 0, significa que a categoria já está cadastrada
                        throw new Exception("Esta forma de pagamento já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objFP.inserir();
                    objFP.limpar();
                    limpar();
                    MessageBox.Show("Forma de pagamento incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objFP.alterar();
                    objFP.limpar();
                    limpar();
                    MessageBox.Show("Forma de pagamento alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objFP.limpar();
                limpar();
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
                if (objFP.fp_codigo != 0)
                {
                    if (objFP.fp_descricao == "Dinheiro" || objFP.fp_descricao == "Cheque" || objFP.fp_descricao == "Cartão de Crédito" || objFP.fp_descricao == "Cartão de Débito" || objFP.fp_descricao == "A Prazo")
                        throw new Exception("Esta forma de pagamento é padrão do sistema e não pode ser excluída");
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objFP.excluir();
                        objFP.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Forma de pagamento excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma forma de pagamento na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta forma de pagamento está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                objFP.localizarPrimeiroUltimo("primeiro");
                if (objFP.fp_codigo != 0)
                {
                    objFP.localizar(objFP.fp_codigo.ToString(), "fp_codigo");
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
                    objFP.localizarProxAnterior("anterior", 0);
                else
                    objFP.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objFP.fp_codigo != 0)
                {
                    objFP.localizar(objFP.fp_codigo.ToString(), "fp_codigo");
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
                    objFP.localizarProxAnterior("proximo", 0);
                else
                    objFP.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objFP.fp_codigo != 0)
                {
                    objFP.localizar(objFP.fp_codigo.ToString(), "fp_codigo");
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
                objFP.localizarPrimeiroUltimo("ultimo");
                if (objFP.fp_codigo != 0)
                {
                    objFP.localizar(objFP.fp_codigo.ToString(), "fp_codigo");
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

        private void gbMenu_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objFP.fp_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se Forma de Pagamento já existe
                    objFP.localizarLeave(objFP.fp_descricao, "fp_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objFP.fp_codigo != 0) // se o código retornar um número acima de 0, significa que a categoria já está cadastrada
                        throw new Exception("Esta forma de pagamento já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objFP.inserir();
                    objFP.limpar();
                    limpar();
                    MessageBox.Show("Forma de pagamento incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objFP.alterar();
                    objFP.limpar();
                    limpar();
                    MessageBox.Show("Forma de pagamento alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objFP.limpar();
                limpar();
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
                if (objFP.fp_codigo != 0)
                {
                    if (objFP.fp_descricao == "Dinheiro" || objFP.fp_descricao == "Cheque" || objFP.fp_descricao == "Cartão de Crédito" || objFP.fp_descricao == "Cartão de Débito" || objFP.fp_descricao == "A Prazo")
                        throw new Exception("Esta forma de pagamento é padrão do sistema e não pode ser excluída");
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objFP.excluir();
                        objFP.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Forma de pagamento excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma forma de pagamento na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta forma de pagamento está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
	}
}
