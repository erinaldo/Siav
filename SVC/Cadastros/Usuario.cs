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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        UsuarioBLL objUsu = new UsuarioBLL();

        public void carregaCombo()
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbEmpresa, "Empresa", "emp_codigo", "emp_razaoSocial", "", "emp_razaoSocial");
                objD = null;
                objD = new Contexto();
                objD.PreencheComboBox(cbPermissao, "Permissao", "per_codigo", "per_nome", "", "per_nome");
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
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    i++;
                }
                gvPesquisa.ClearSelection();
                objUsu.Limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtLogin.Text = "";
                txtNome.Text = "";
                txtSenha.Text = "";
                cbEmpresa.SelectedIndex = -1;
                cbPermissao.SelectedIndex = -1;
                cbStatus.SelectedIndex = -1;
                txtPesquisar.Text = "";
                txtCodigo.ReadOnly = false;
                txtCodigo.Enabled = true;
                txtLogin.Enabled = true;
                txtLogin.ReadOnly = false;
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
                    objUsu.usu_codigo = int.Parse(txtCodigo.Text);
                else
                    objUsu.usu_codigo = 0;
                txtNome.Text = txtNome.Text.Trim();
                if (txtNome.Text != "")
                    objUsu.usu_nome = txtNome.Text;
                else
                    throw new Exception("O campo nome é de preenchimento obrigatório");
                txtLogin.Text = txtLogin.Text.Trim();
                if (txtLogin.Text != "")
                    objUsu.usu_login= txtLogin.Text;
                else
                    throw new Exception("O campo login é de preenchimento obrigatório");
                txtSenha.Text = txtSenha.Text.Trim();
                if (txtSenha.Text != "")
                {
                    if(txtSenha.TextLength <3)
                        throw new Exception("O campo senha deve ter 3 caracteres ou mais");    
                    objUsu.usu_senha= txtSenha.Text;
                }
                else
                    throw new Exception("O campo senha é de preenchimento obrigatório");
                if (cbEmpresa.SelectedValue != null)
                    objUsu.emp_codigo = int.Parse(cbEmpresa.SelectedValue.ToString());
                else
                    throw new Exception("Não foi possível encontrar esta empresa na base de dados");
                if (cbPermissao.SelectedValue != null)
                    objUsu.per_codigo = int.Parse(cbPermissao.SelectedValue.ToString());
                else
                    throw new Exception("Não foi possível encontrar esta permissão na base de dados");
                if (cbStatus.SelectedIndex == 0)
                        objUsu.usu_status = "Ativo";
                else if (cbStatus.SelectedIndex == 1)
                    objUsu.usu_status = "Inativo";
                else
                    throw new Exception("O campo status é de preenchimento obrigatório");

                if (txtEmail.Text == "")
                {
                    objUsu.usu_email = "sememail@trendsis.com.br";
                    //throw new Exception("O campo e-mail é de preenchimento obrigatório");
                }
                else
                {
                    objUsu.usu_email = txtEmail.Text;
                }
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
                if (objUsu.usu_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objUsu.usu_codigo.ToString();
                txtNome.Text = objUsu.usu_nome;
                txtLogin.Text = objUsu.usu_login;
                cbEmpresa.SelectedValue = objUsu.emp_codigo;
                cbPermissao.SelectedValue = objUsu.per_codigo;
                
                if(objUsu.usu_status == "Ativo")
                    cbStatus.SelectedIndex= 0;
                else
                    cbStatus.SelectedIndex = 1;
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
                tab = objUsu.LocalizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns[0].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[1].Width = gvPesquisa.Width / 6+2;
                gvPesquisa.Columns[2].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[3].Width = gvPesquisa.Width / 6 ;
                gvPesquisa.Columns[4].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[5].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[6].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[7].Width = gvPesquisa.Width / 6;
                gvPesquisa.Columns[6].Visible = false;
                gvPesquisa.Columns[7].Visible = false;
               // stiloGrid();
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

        private void Usuario_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode =
             DataGridViewAutoSizeColumnsMode.AllCells;
            
            try
            {
                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
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
                    objUsu.Limpar();
                    objUsu.LocalizarLeave(cod.ToString(), "usu_codigo");
                    if (objUsu.usu_codigo != 0)
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
                        objUsu.usu_codigo = cod;
                        objUsu.Localizar(objUsu.usu_codigo.ToString(), "usu_codigo");
                        txtCodigo.Text = objUsu.usu_codigo.ToString();
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
                    objUsu.Limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100); 
                    btAnterior.Enabled = false;
                    btPrimeiro.Enabled = false;
                    btProximo.Enabled = false;
                    btUltimo.Enabled = false;
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objUsu.Limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    btAnterior.Enabled = true;
                    btPrimeiro.Enabled = true;
                    btProximo.Enabled = true;
                    btUltimo.Enabled = true;
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    groupBox1.Visible = true;
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
                    objUsu.Localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "usu_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void gvPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objUsu.usu_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se subgrupo já existe
                    objUsu.LocalizarLeave(objUsu.usu_login, "usu_login"); //Pesquisa por descrição, na coluna descrição
                    if (objUsu.usu_codigo != 0) // se o código retornar um número acima de 0, significa que a subgrupo já está cadastrada
                        throw new Exception("Este login já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objUsu.Inserir();
                    objUsu.Limpar();
                    limpar();
                    MessageBox.Show("Usuário incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objUsu.Alterar();
                    objUsu.Limpar();
                    limpar();
                    MessageBox.Show("Usuário alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objUsu.Limpar();
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
                if (objUsu.usu_codigo != 0)
                {
                    if (objUsu.usu_codigo == global.codUsuario)
                        throw new Exception("Este usuário está em uso, por favor, desconecte-o para poder excluí-lo");
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objUsu.Excluir();
                        objUsu.Limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Usuário excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um Usuário na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este usuário está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                objUsu.LocalizarPrimeiroUltimo("primeiro");
                if (objUsu.usu_codigo != 0)
                {
                    objUsu.Localizar(objUsu.usu_codigo.ToString(), "usu_codigo");
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
                    objUsu.LocalizarProxAnterior("anterior", 0);
                else
                    objUsu.LocalizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objUsu.usu_codigo != 0)
                {
                    objUsu.Localizar(objUsu.usu_codigo.ToString(), "usu_codigo");
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
                    objUsu.LocalizarProxAnterior("proximo", 0);
                else
                    objUsu.LocalizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objUsu.usu_codigo != 0)
                {
                    objUsu.Localizar(objUsu.usu_codigo.ToString(), "usu_codigo");
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
                objUsu.LocalizarPrimeiroUltimo("ultimo");
                if (objUsu.usu_codigo != 0)
                {
                    objUsu.Localizar(objUsu.usu_codigo.ToString(), "usu_codigo");
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objUsu.usu_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se subgrupo já existe
                    objUsu.LocalizarLeave(objUsu.usu_login, "usu_login"); //Pesquisa por descrição, na coluna descrição
                    if (objUsu.usu_codigo != 0) // se o código retornar um número acima de 0, significa que a subgrupo já está cadastrada
                        throw new Exception("Este login já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objUsu.Inserir();
                    objUsu.Limpar();
                    limpar();
                    MessageBox.Show("Usuário incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objUsu.Alterar();
                    objUsu.Limpar();
                    limpar();
                    MessageBox.Show("Usuário alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objUsu.Limpar();
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
                if (objUsu.usu_codigo != 0)
                {
                    if (objUsu.usu_codigo == global.codUsuario)
                        throw new Exception("Este usuário está em uso, por favor, desconecte-o para poder excluí-lo");
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objUsu.Excluir();
                        objUsu.Limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Usuário excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um Usuário na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este usuário está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
