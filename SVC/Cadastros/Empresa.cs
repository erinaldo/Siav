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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using View;

namespace One.CADASTROS
{
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }

        EmpresaBLL objEmp = new EmpresaBLL();

        public void stiloGrid()
        {

            int i = 0;
            // if (gvPesquisa.Rows.Count != 0)
            // {
            //     foreach (DataGridViewRow row in gvPesquisa.Rows)
            //     {
            //         if (i % 2 != 0)
            //         {
            //             row.DefaultCellStyle.BackColor = Color.FromName("ActiveCaption");
            //             row.DefaultCellStyle.ForeColor = Color.White;
            //         }
            //         i++;
            //     }
            // //    gvPesquisa.ClearSelection();
            //     objEmp.limpar();
            // }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                txtBairro.Text = "";
                txtCnpj.Text = "";
                txtCnpj.Enabled = true;
                txtFax.Text = "";
                txtIE.Text = "";
                txtLogradouro.Text = "";
                txtNomeFantasia.Text = "";
                txtRazaoSocial.Text = "";
                txtTelefone.Text = "";
                //txtPesquisar.Text = "";
                txtNumero.Text = "";
                txtCep.Text = "";
                txtJuros.Text = "";
                txtMulta.Text = "";
                txtDiaVencimento.Text = "";
                cbCidade.SelectedIndex = -1;
                //   btSalvar.Enabled = false;
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
                try{

                    if (cbRegime.Items[cbRegime.SelectedIndex].ToString() == "" || cbRegime.Items[cbRegime.SelectedIndex].ToString() == null)
                        throw new Exception("O campo 'Regime tributario' é de preenchimento obrigatório");
                    else
                    {
                        String xreg = cbRegime.SelectedItem.ToString();

                        if (xreg == "Simples Nacional")
                            objEmp.emp_regime = regime_tributario.simples_nacional;
                        else
                            objEmp.emp_regime = regime_tributario.tributacao_normal;

                    }
                }
                catch {
                    throw new Exception("O campo 'Regime tributario' é de preenchimento obrigatório");
                }

                if (txtCodigo.Text != "")
                    objEmp.emp_codigo = int.Parse(txtCodigo.Text);
                else
                    objEmp.emp_codigo = 0;
                txtRazaoSocial.Text = txtRazaoSocial.Text.Trim();
                if (txtRazaoSocial.Text != "")
                    objEmp.emp_razaoSocial = txtRazaoSocial.Text;
                else
                    throw new Exception("O campo 'Razão Social' é de preenchimento obrigatório");
                txtNomeFantasia.Text = txtNomeFantasia.Text.Trim();
                if (txtNomeFantasia.Text != "")
                    objEmp.emp_nomeFantasia = txtNomeFantasia.Text;
                else
                    throw new Exception("O campo 'Nome Fantasia' é de preenchimento obrigatório");
                txtLogradouro.Text = txtLogradouro.Text.Trim();
                if (txtLogradouro.Text != "")
                    objEmp.emp_logradouro = txtLogradouro.Text;
                else
                    throw new Exception("O campo 'Logradouro' é de preenchimento obrigatório");
                txtNumero.Text = txtNumero.Text.Trim();
                if (txtNumero.Text != "")
                    objEmp.emp_numero = txtNumero.Text;
                else
                    throw new Exception("O campo 'Número' é de preenchimento obrigatório");
                txtBairro.Text = txtBairro.Text.Trim();
                if (txtBairro.Text != "")
                    objEmp.emp_bairro = txtBairro.Text;
                else
                    throw new Exception("O campo 'Bairro' é de preenchimento obrigatório");
                txtCep.Text = txtCep.Text.Trim();
                if (txtCep.Text != "_____-__")
                    objEmp.emp_cep = txtCep.Text;
                else
                    throw new Exception("O campo 'Cep' é de preenchimento obrigatório");

                if (cbCidade.SelectedValue != null)
                    objEmp.emp_estado = int.Parse(cbEstado.SelectedValue.ToString());
                else
                    throw new Exception("Estado não encontrada na base de dados");

                if (cbCidade.SelectedValue != null)
                    objEmp.emp_cidade = int.Parse(cbCidade.SelectedValue.ToString());
                else
                    throw new Exception("Cidade não encontrada na base de dados");
                //txtIE.Text = txtIE.Text.Trim();
                if (txtIE.Text != "")
                objEmp.emp_inscricaoEstadual = txtIE.Text;
                else
                    throw new Exception("O campo 'Inscrição Estadual' é de preenchimento obrigatório");

                if (txtIM.Text != "")
                    objEmp.emp_inscricaoMunicipal = txtIM.Text;

                

                txtCnpj.Text = txtCnpj.Text.Trim();
                if (txtCnpj.Text != "")
                    objEmp.emp_cnpj = txtCnpj.Text;
                else
                    throw new Exception("O campo 'CNPJ' é de preenchimento obrigatório");

                objEmp.emp_telefone = txtTelefone.Text;
                objEmp.emp_fax = txtFax.Text;

                if (txtJuros.Text != "")
                    objEmp.emp_valorJuros = Decimal.Parse(txtJuros.Text);
                else
                    objEmp.emp_valorJuros = 0;

                String x = "";
                for (int i = 0; i <= txtMulta.Text.Length - 1; i++)
                {
                    if ((txtMulta.Text[i] >= '0' &&
                    txtMulta.Text[i] <= '9') ||
                    txtMulta.Text[i] == ',')
                    {
                        x += txtMulta.Text[i];
                    }
                }
                txtMulta.Text = x;

                if (txtMulta.Text != "")
                    objEmp.emp_multa = Decimal.Parse(txtMulta.Text);
                else
                    objEmp.emp_multa = 0;
                if (txtDiaVencimento.Text != "")
                    objEmp.emp_qtdDias = int.Parse(txtDiaVencimento.Text);
                else
                    objEmp.emp_qtdDias = 0;
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
                if (objEmp.emp_codigo == 0)
                    throw new Exception("Registro não encontrado");
                else
                    txtCodigo.Text = objEmp.emp_codigo.ToString();
                txtRazaoSocial.Text = objEmp.emp_razaoSocial;
                txtNomeFantasia.Text = objEmp.emp_nomeFantasia;
                txtLogradouro.Text = objEmp.emp_logradouro;
                txtNumero.Text = objEmp.emp_numero;
                txtBairro.Text = objEmp.emp_bairro;
                txtCep.Text = objEmp.emp_cep;

                cbEstado.SelectedValue = objEmp.emp_estado;

                cbCidade.SelectedValue = objEmp.emp_cidade;
                txtIE.Text = objEmp.emp_inscricaoEstadual;
                txtIM.Text = objEmp.emp_inscricaoMunicipal;
                txtCnpj.Text = objEmp.emp_cnpj;
                txtTelefone.Text = objEmp.emp_telefone;
                txtFax.Text = objEmp.emp_fax;
                txtJuros.Text = objEmp.emp_valorJuros.ToString();
                txtMulta.Text = objEmp.emp_multa.ToString();
                txtDiaVencimento.Text = objEmp.emp_qtdDias.ToString();

                if (objEmp.emp_regime == regime_tributario.simples_nacional)
                    cbRegime.SelectedText = "Simples Nacional";
                else
                    cbRegime.SelectedText = "Tributação Normal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public void carregaGrid()
        //{
        //    try
        //    {
        //        DataTable tab = null;
        //        tab = objEmp.localizarEmTudo(txtPesquisar.Text);
        //        gvPesquisa.DataSource = tab;
        //        gvPesquisa.Columns["emp_codigo"].HeaderText = "Código";
        //        gvPesquisa.Columns["emp_razaoSocial"].HeaderText = "Razão Social";
        //        gvPesquisa.Columns["emp_nomeFantasia"].HeaderText = "Nome Fantasia";
        //        gvPesquisa.Columns["emp_logradouro"].HeaderText = "Logradouro";
        //        gvPesquisa.Columns["emp_numero"].HeaderText = "Número";
        //        gvPesquisa.Columns["emp_bairro"].HeaderText = "Bairro";
        //        gvPesquisa.Columns["emp_cep"].HeaderText = "CEP";
        //        gvPesquisa.Columns["emp_cidade"].HeaderText = "Cidade";
        //        gvPesquisa.Columns["emp_inscricaoEstadual"].HeaderText = "Inscrição Estadual";
        //        gvPesquisa.Columns["emp_cnpj"].HeaderText = "CNPJ";
        //        gvPesquisa.Columns["emp_telefone"].HeaderText = "Telefone";
        //        gvPesquisa.Columns["emp_fax"].HeaderText = "Fax";
        //        gvPesquisa.Columns[0].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[1].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[2].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[3].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[4].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[5].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[6].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[7].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[8].Width = gvPesquisa.Width / 12 + 4;
        //        gvPesquisa.Columns[9].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[10].Width = gvPesquisa.Width / 12;
        //        gvPesquisa.Columns[11].Width = gvPesquisa.Width / 12;

        //        //Remover colunas que não são necessárias para a equipamentos e cia
        //        gvPesquisa.Columns.Remove("emp_valorJuros");
        //        gvPesquisa.Columns.Remove("emp_multa");
        //        gvPesquisa.Columns.Remove("emp_qtdDias");

        //        // stiloGrid();
        //        gvPesquisa.ClearSelection();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public void Salvar()
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objEmp.emp_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se categoria já existe
                    objEmp.localizarLeave(objEmp.emp_razaoSocial, "emp_razaoSocial"); //Pesquisa por descrição, na coluna descrição
                    if (objEmp.emp_codigo != 0) // se o código retornar um número acima de 0, significa que a categoria já está cadastrada
                        throw new Exception("Esta empresa já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objEmp.inserir();
                    //  objEmp.limpar();
                    //limpar();
                    MessageBox.Show("Empresa cadastrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objEmp.alterar();
                    objEmp.limpar();
                    //  limpar();
                    MessageBox.Show("Empresa alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public void Cancelar()
        {
            try
            {
                objEmp.limpar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {

        }
        public void Excluir()
        {
            try
            {
                if (objEmp.emp_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objEmp.excluir();
                        objEmp.limpar();
                        limpar();
                        //carregaGrid();
                        MessageBox.Show("Empresa excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma Empresa na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Esta empresa está vinculada a alguma movimentação do sistema e não pode ser excluída", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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
                    objEmp.limpar();
                    objEmp.localizarLeave(cod.ToString(), "emp_codigo");
                    if (objEmp.emp_codigo != 0)
                    {
                        carregaCampos();
                        // txtCnpj.Enabled = false;
                        txtCodigo.Enabled = false;
                        btSalvar.Enabled = true;

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
                //carregaGrid();
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
                    objEmp.limpar();
                    limpar();
                    //carregaGrid();
                    //  txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);  

                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objEmp.limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    groupBox1.Visible = true;
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

        private void Empresa_Load(object sender, EventArgs e)
        {
            //           gvPesquisa.AutoSizeColumnsMode =
            //       DataGridViewAutoSizeColumnsMode.AllCells;
            try
            {
                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbEstado, "estado", "est_codigo_IBGE", "est_nome", "", "est_nome");
                objD = null;

                TabControl1.SelectedIndex = 0;

                DataTable tab = null;



                DataTable dt = objEmp.localizarEmTudo("");
                Int32 x = dt.Rows.Count;

                // Se não houver nenhum registo ele cria o primeiro para ser o unico registro sobre a empresa
                if (x > 0)
                {
                    String codigo = dt.Rows[0].ItemArray[0].ToString();
                    objEmp.limpar();
                    objEmp.localizarLeave(codigo, "emp_codigo");
                    if (objEmp.emp_codigo != 0)
                    {
                        carregaCampos();
                        // txtCnpj.Enabled = false;
                        txtCodigo.Enabled = false;
                        btSalvar.Enabled = true;
                    }
                    else
                        limpar();
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
                //if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                //{
                //    objEmp.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "emp_codigo");
                //}
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
                //  if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                //  {
                //      int cod = 0;
                //     cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
                //     if (cod != 0)
                //     {
                //         TabControl1.SelectedIndex = 0;
                //         txtPesquisar.Text = "";
                //         objEmp.emp_codigo = cod;
                //         objEmp.localizar(objEmp.emp_codigo.ToString(), "emp_codigo");
                //         txtCodigo.Text = objEmp.emp_codigo.ToString();
                //         txtCodigo.Enabled = false;
                //         carregaCampos();
                //         btSalvar.Enabled = true;
                //         //   txtCnpj.Enabled = false;
                //     }
                //  }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtCnpj.Text != "  .   .   /    -")
            //    {
            //        if (!verificaCNPJ(txtCnpj.Text))
            //        {
            //            txtCnpj.Text = "";
            //            txtCnpj.Focus();
            //            throw new Exception("CNPJ inválido");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        //public bool verificaCNPJ(string cnpj)
        //{

        //    //if (string.IsNullOrEmpty(cnpj))
        //    //    return false;
        //    //else
        //    //{
        //    //    int[] d = new int[14];
        //    //    int[] v = new int[2];
        //    //    int j, i, soma;
        //    //    string Sequencia, SoNumero;

        //    //    SoNumero = Regex.Replace(cnpj, "[^0-9]", string.Empty);

        //    //    //verificando se todos os numeros são iguais
        //    //    if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
        //    //    if (SoNumero.Length == 14)
        //    //    {
        //    //        Sequencia = "6543298765432";
        //    //        for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
        //    //        for (i = 0; i <= 1; i++)
        //    //        {
        //    //            soma = 0;
        //    //            for (j = 0; j <= 11 + i; j++)
        //    //                soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

        //    //            v[i] = (soma * 10) % 11;
        //    //            if (v[i] == 10) v[i] = 0;
        //    //        }
        //    //        return (v[0] == d[12] & v[1] == d[13]);
        //    //    }
        //    //    // CPF ou CNPJ inválido se
        //    //    // a quantidade de dígitos numérios for diferente de 11 e 14
        //         return true;
        //    }
        //}

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMulta_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtMulta.Text.Length - 1; i++)
                {
                    if ((txtMulta.Text[i] >= '0' &&
                    txtMulta.Text[i] <= '9') ||
                    txtMulta.Text[i] == ',')
                    {
                        x += txtMulta.Text[i];
                    }
                }
                txtMulta.Text = x;
                txtMulta.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') &&
              (e.KeyChar != ',' && e.KeyChar != '.' &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtJuros.Text.Contains(','))
                        {
                            e.KeyChar = ',';
                        }
                        else
                        {
                            e.KeyChar = (Char)0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') &&
              (e.KeyChar != ',' && e.KeyChar != '.' &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtMulta.Text.Contains(','))
                        {
                            e.KeyChar = ',';
                        }
                        else
                        {
                            e.KeyChar = (Char)0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objEmp.localizarPrimeiroUltimo("primeiro");
                if (objEmp.emp_codigo != 0)
                {
                    objEmp.localizar(objEmp.emp_codigo.ToString(), "emp_codigo");
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
                    objEmp.localizarProxAnterior("anterior", 0);
                else
                    objEmp.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objEmp.emp_codigo != 0)
                {
                    objEmp.localizar(objEmp.emp_codigo.ToString(), "emp_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
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
                if (txtCodigo.Text == "")
                    objEmp.localizarProxAnterior("proximo", 0);
                else
                    objEmp.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objEmp.emp_codigo != 0)
                {
                    objEmp.localizar(objEmp.emp_codigo.ToString(), "emp_codigo");
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
                objEmp.localizarPrimeiroUltimo("ultimo");
                if (objEmp.emp_codigo != 0)
                {
                    objEmp.localizar(objEmp.emp_codigo.ToString(), "emp_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btImprimir_Click(object sender, EventArgs e)
        {

            //  printDGV.Print_DataGridView(gvPesquisa);

        }

        private void button1_Click_1(object sender, EventArgs e){
            Salvar();
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Excluir();
        }

        private void txtCnpj_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;

                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome", "cid_estado = " + selectedValue, "cid_nome");
                objD = null;


            }
            catch
            {

            }
        }

    }
}
