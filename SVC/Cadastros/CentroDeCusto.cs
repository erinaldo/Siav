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
    public partial class CentroDeCusto : Form
    {
        //Zitelli

        public CentroDeCusto()
        {
            InitializeComponent();
        }
        
        CentroDeCustoBLL objCat = new CentroDeCustoBLL();

        //public void stiloGrid()
        //{

        //    int i = 0;
        //    if (gvPesquisa.Rows.Count != 0)
        //    {
        //        foreach (DataGridViewRow row in gvPesquisa.Rows)
        //        {
        //            if (i % 2 != 0)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromName("ActiveCaption");
        //                row.DefaultCellStyle.ForeColor = Color.Black;
        //            }
        //            i++;
        //        }
        //        gvPesquisa.ClearSelection();
        //        objCat.limpar();
        //    }
        //}
        
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
                    objCat.ccs_codigo = int.Parse(txtCodigo.Text);
                else
                    objCat.ccs_codigo = 0;
                txtDescricao.Text = txtDescricao.Text.Trim();
                if (txtDescricao.Text != "")
                    objCat.ccs_descricao = txtDescricao.Text;
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
                if (objCat.ccs_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objCat.ccs_codigo.ToString();
                txtDescricao.Text = objCat.ccs_descricao;

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
                tab = objCat.localizarEmTudo(txtPesquisar.Text);

                gvPesquisa.DataSource = tab;

                gvPesquisa.Columns["ccs_codigo"].HeaderText = "Código";
                gvPesquisa.Columns["ccs_descricao"].HeaderText = "Nome";
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
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();
                
                if (objCat.ccs_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se CentroDeCusto já existe
                    objCat.localizarLeave(objCat.ccs_descricao, "ccs_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objCat.ccs_codigo != 0) // se o código retornar um número acima de 0, significa que a CentroDeCusto já está cadastrada
                        throw new Exception("Esta CentroDeCusto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                    
                    objCat.inserir();
                    objCat.limpar();
                    limpar();
                    MessageBox.Show("CentroDeCusto incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objCat.alterar();
                    objCat.limpar();
                    limpar();
                    MessageBox.Show("CentroDeCusto alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                   
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                objCat.limpar();
                limpar();
                txtCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (objCat.ccs_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objCat.excluir();
                        objCat.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("CentroDeCusto excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma CentroDeCusto na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);                    
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta CentroDeCusto está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                    int cod=0;
                    cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {
                        TabControl1.SelectedIndex = 0;
                        txtPesquisar.Text = "";
                        objCat.ccs_codigo = cod;
                        objCat.localizar(objCat.ccs_codigo.ToString(),"ccs_codigo");
                        txtCodigo.Text = objCat.ccs_codigo.ToString();
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

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                 // Localizar usuário
                    int catcod;
                    int.TryParse(txtCodigo.Text, out catcod);
                    if (catcod != 0)
                    {
                        objCat.limpar();
                        objCat.localizarLeave(catcod.ToString(), "ccs_codigo");
                        if (objCat.ccs_codigo != 0)
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

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objCat.limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    this.MaximumSize = new Size(this.Width, this.Height+100);
                    this.MinimumSize = new Size(this.Width, this.Height+100);                 
                    this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
                    btAnterior.Enabled = false;
                    btPrimeiro.Enabled = false;
                    btProximo.Enabled = false;
                    btUltimo.Enabled = false;
                }
                else if (TabControl1.SelectedIndex ==0)
                {
                    objCat.limpar();
                    this.MaximumSize = new Size(this.Width, this.Height-50);
                    this.MinimumSize = new Size(this.Width, this.Height-50);
                    this.Size = new Size(this.Width, this.Height-50);
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
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objCat.localizarPrimeiroUltimo("primeiro");
                if(objCat.ccs_codigo !=0)
                {
                    objCat.localizar(objCat.ccs_codigo.ToString(),"ccs_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objCat.localizarPrimeiroUltimo("ultimo");
                if (objCat.ccs_codigo != 0)
                {
                    objCat.localizar(objCat.ccs_codigo.ToString(), "ccs_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if(txtCodigo.Text == "")
                    objCat.localizarProxAnterior("anterior",0);
                else
                    objCat.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objCat.ccs_codigo != 0)
                {
                    objCat.localizar(objCat.ccs_codigo.ToString(), "ccs_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objCat.localizarProxAnterior("proximo", 0);
                else
                    objCat.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objCat.ccs_codigo != 0)
                {
                    objCat.localizar(objCat.ccs_codigo.ToString(), "ccs_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }   
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void CentroDeCusto_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode = 
                DataGridViewAutoSizeColumnsMode.AllCells;

            try
            {
                this.MaximumSize = new Size(this.Width,this.Height);
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
                    objCat.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "ccs_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void btAjuda_Click(object sender, EventArgs e)
        {

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(gvPesquisa);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gbMenu_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objCat.ccs_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se CentroDeCusto já existe
                    objCat.localizarLeave(objCat.ccs_descricao, "ccs_descricao"); //Pesquisa por descrição, na coluna descrição
                    if (objCat.ccs_codigo != 0) // se o código retornar um número acima de 0, significa que a CentroDeCusto já está cadastrada
                        throw new Exception("Esta CentroDeCusto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objCat.inserir();
                    objCat.limpar();
                    limpar();
                    MessageBox.Show("CentroDeCusto incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objCat.alterar();
                    objCat.limpar();
                    limpar();
                    MessageBox.Show("CentroDeCusto alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objCat.limpar();
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
                if (objCat.ccs_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objCat.excluir();
                        objCat.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("CentroDeCusto excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma CentroDeCusto na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta CentroDeCusto está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
