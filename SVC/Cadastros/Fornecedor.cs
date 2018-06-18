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
using System.Text.RegularExpressions;
using View;

namespace One.CADASTROS
{
    public partial class Fornecedor : Form
    {
        public Fornecedor()
        {
            InitializeComponent();
        }

        FornecedoresBLL objFor = new FornecedoresBLL();

        public bool verificaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string SoNumero;

                SoNumero = Regex.Replace(cpf, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

                // se a quantidade de dígitos numérios for igual a 11
                // iremos verificar como CPF
                if (SoNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }
                else
                    return false;
            }
        }

        public bool verificaCNPJ(string cnpj)
        {

            if (string.IsNullOrEmpty(cnpj))
                return false;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string Sequencia, SoNumero;

                SoNumero = Regex.Replace(cnpj, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
                if (SoNumero.Length == 14)
                {
                    Sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }
                // CPF ou CNPJ inválido se
                // a quantidade de dígitos numérios for diferente de 11 e 14
                else return false;
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
                gvPesquisa.ClearSelection();
                objFor.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtBairro.Text = "";
                txtCnpj.Text = "";
                txtCodigo.Text = "";
                txtComplemento.Text = "";
                txtCpf.Text = "";
                txtInscrEstadual.Text = "";
                txtLogradouro.Text = "";
                txtNome.Text = "";
                txtNumero.Text = "";
                txtPesquisar.Text = "";
                txtRazaoSocial.Text = "";
                txtRg.Text = "";
                txtTelefone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
                txtCEP.Text = "";
                cbCidade.SelectedIndex = -1;
                //cbOpcao.SelectedIndex = 0;
                //cbTipo.SelectedIndex = 0;
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                cbTipo.Enabled = true;
                //cbPrestadorServico.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;

                
                    try {
                        tab = objFor.localizarEmTudo(txtPesquisar.Text, cbOpcao.SelectedItem.ToString());
                    }
                    catch
                    {
                        cbOpcao.SelectedIndex = cbOpcao.FindStringExact("Pessoa Jurídica");
                        tab = objFor.localizarEmTudo(txtPesquisar.Text, cbOpcao.SelectedItem.ToString());
                    }
                gvPesquisa.DataSource = tab;
                if (cbOpcao.SelectedIndex == 0)
                {
                    //gvPesquisa.Columns[0].Width = gvPesquisa.Width /13;
                    //gvPesquisa.Columns[1].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[2].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[3].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[4].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[5].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[6].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[7].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[8].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[9].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[10].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[11].Width = gvPesquisa.Width / 13;
                    //gvPesquisa.Columns[12].Width = gvPesquisa.Width / 13;
                }
                else
                {
                    //gvPesquisa.Columns[0].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[1].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[2].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[3].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[4].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[5].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[6].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[7].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[8].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[9].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[10].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[11].Width = gvPesquisa.Width / 12;
                    //gvPesquisa.Columns[12].Width = gvPesquisa.Width / 12;
                }
                //  stiloGrid();
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
                    objFor.for_codigo = int.Parse(txtCodigo.Text);
                else
                    objFor.for_codigo = 0;
                if (cbTipo.SelectedIndex == 0)
                {
                    txtNome.Text = txtNome.Text.Trim();
                    if (txtNome.Text != "")
                        objFor.for_nome = txtNome.Text;
                    else
                        throw new Exception("O campo nome é de preenchimento obrigatório");

                    txtRg.Text = txtRg.Text.Trim();
                    if (txtRg.Text != "")
                        objFor.for_rg = txtRg.Text;
                    else
                        objFor.for_rg = "";
                    if (txtCpf.Text != "   .   .   -")
                        objFor.for_cpf = txtCpf.Text;
                    else
                        throw new Exception("O campo cpf é de preenchimento obrigatório");
                }
                else
                {
                    txtRazaoSocial.Text = txtRazaoSocial.Text.Trim();
                    if (txtRazaoSocial.Text != "")
                        objFor.for_razaoSocial = txtRazaoSocial.Text;
                    else
                        throw new Exception("o campo 'Razão Social' é de preenchimento obrigatório");

                    txtInscrEstadual.Text = txtInscrEstadual.Text.Trim();
                    if (txtInscrEstadual.Text != "")
                        objFor.for_ie = txtInscrEstadual.Text;
                    else
                        objFor.for_ie = "";

                    if (txtCnpj.Text != "  .   .   /    -")
                        objFor.for_cnpj = txtCnpj.Text;
                    else
                        throw new Exception("O campo CNPJ é de preenchimento obrigatório");
                }
                //parte genérica
                if (txtEmail.Text != "")
                    objFor.for_email = txtEmail.Text;
                else
                    objFor.for_email = "";

                if (txtCEP.Text != "")
                    objFor.for_cep = txtCEP.Text;
                else
                    throw new Exception("O campo CEP é de preenchimento obrigatório");

                if (cbTipo.SelectedIndex == 0)
                    objFor.for_tipo_fornecedor = "Pessoa Física";
                else
                    objFor.for_tipo_fornecedor = "Pessoa Jurídica";
                txtLogradouro.Text = txtLogradouro.Text.Trim();
                if (txtLogradouro.Text != "")
                    objFor.for_logradouro = txtLogradouro.Text;
                else
                    throw new Exception("O campo logradouro é de preenchimento obrigatório");
                txtNumero.Text = txtNumero.Text.Trim();
                if (txtNumero.Text != "")
                    objFor.for_numero = txtNumero.Text;
                else
                    throw new Exception("O campo número é de preenchimento obrigatório");
                txtComplemento.Text = txtComplemento.Text.Trim();//Não é campo obrigatório
                objFor.for_complemento = txtComplemento.Text;
                txtBairro.Text = txtBairro.Text.Trim();
                if (txtBairro.Text != "")
                    objFor.for_bairro = txtBairro.Text;
                else
                    throw new Exception("O campo bairro é de preenchimento obrigatório");
                if (cbCidade.SelectedValue != null)
                    objFor.for_cidade = int.Parse(cbCidade.SelectedValue.ToString());
                else
                    throw new Exception("Cidade não encontrada na base de dados");

                if (txtTelefone.Text != "(  )    -")
                    objFor.for_telefone = txtTelefone.Text;
                else
                    throw new Exception("Telefone deve ser informado");
                //objFor.for_telefone = "";                    

                if (txtFax.Text != "(  )    -")
                    objFor.for_fax = txtFax.Text;
                else
                    objFor.for_fax = "";

                objFor.for_status = "";

                if (cbPrestadorServico.SelectedIndex == 1)
                    objFor.for_tipo = "Sim";
                else
                    objFor.for_tipo = "Não";

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
                if (objFor.for_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objFor.for_codigo.ToString();
                if (cbTipo.SelectedIndex == 0)
                {
                    txtNome.Text = objFor.for_nome;
                    txtRg.Text = objFor.for_rg;
                    txtCpf.Text = objFor.for_cpf;

                }
                else
                {
                    txtRazaoSocial.Text = objFor.for_razaoSocial;
                    txtInscrEstadual.Text = objFor.for_ie;
                    txtCnpj.Text = objFor.for_cnpj;
                }
                txtEmail.Text = objFor.for_email;
                txtCEP.Text = objFor.for_cep;
                txtLogradouro.Text = objFor.for_logradouro;
                txtNumero.Text = objFor.for_numero;
                txtComplemento.Text = objFor.for_complemento;
                txtBairro.Text = objFor.for_bairro;
                cbCidade.SelectedValue = objFor.for_cidade;
                txtTelefone.Text = objFor.for_telefone;
                txtFax.Text = objFor.for_fax;

                if (objFor.for_tipo == "Sim")
                    cbPrestadorServico.SelectedIndex = 1;
                else
                    cbPrestadorServico.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e){
       
            
        }

        private void txtFax_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells;
            try
            {
                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
                limpar();
                Contexto objDAL = new Contexto();
                objDAL.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome", "", "cid_nome");
                objDAL = null;
                TabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTipo.SelectedIndex == 0){

                    panelFisica.Visible = true;
                    panelJur.Visible = false;
                
                }else{
                
                    panelFisica.Visible = false;
                    panelJur.Visible = true;
                
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTipo.SelectedIndex > -1)
                {
                    panelJur.Visible = true;
                    panelFisica.Visible = false;
                }
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
                    objFor.limpar();
                    objFor.localizarLeave(cod.ToString(), "for_codigo");
                    if (objFor.for_codigo != 0)
                    {
                        carregaCampos();
                        txtCodigo.Enabled = false;
                        if (objFor.for_tipo_fornecedor == "Pessoa Física")
                            cbTipo.SelectedIndex = 0;
                        else
                            cbTipo.SelectedIndex = 1;
                        cbTipo.Enabled = false;
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
                        objFor.for_codigo = cod;
                        objFor.localizar(objFor.for_codigo.ToString(), "for_codigo");
                        //objFor2 = objFor;
                        txtCodigo.Text = objFor.for_codigo.ToString();
                        txtCodigo.Enabled = false;
                        if (objFor.for_tipo_fornecedor == "Pessoa Física")
                            cbTipo.SelectedIndex = 0;
                        else
                            cbTipo.SelectedIndex = 1;
                        cbTipo.Enabled = false;
                        //objFor = objFor2;
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
                    objFor.limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100); 
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objFor.limpar();
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
                    objFor.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "for_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtCpf.Text != "   .   .   -")
            //    {
            //        if (!verificaCPF(txtCpf.Text))
            //        {
            //            txtCpf.Focus();
            //            txtCpf.Text = "";
            //            throw new Exception("CPF inválido");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void txtCnpj_Leave(object sender, EventArgs e)
        {
            //    try
            //    {
            //        if (txtCnpj.Text != "  .   .   /    -")
            //        {
            //            if (!verificaCNPJ(txtCnpj.Text))
            //            {
            //                txtCnpj.Text = "";
            //                txtCnpj.Focus();
            //                throw new Exception("CNPJ inválido");
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objFor.for_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se fornecedor já existe
                    if (cbTipo.SelectedIndex == 0)
                    {
                        objFor.localizarLeave(objFor.for_nome, "for_nome"); //Pesquisa por descrição, na coluna descrição
                        if (objFor.for_codigo != 0) // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                            throw new Exception("Este fornecedor já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                    }
                    else
                    {
                        objFor.localizarLeave(objFor.for_razaoSocial, "for_razaoSocial"); //Pesquisa por descrição, na coluna descrição
                        if (objFor.for_codigo != 0) // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                            throw new Exception("Este fornecedor já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                    }
                    objFor.inserir();
                    objFor.limpar();
                    limpar();
                    MessageBox.Show("Fornecedor incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objFor.alterar();
                    objFor.limpar();
                    limpar();
                    MessageBox.Show("Fornecedor alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objFor.limpar();
                limpar();
                txtCodigo.Enabled = true;
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
                if (objFor.for_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objFor.excluir();
                        objFor.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Cliente excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um cliente na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este fornecedor está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objFor.localizarPrimeiroUltimo("primeiro");
                if (objFor.for_codigo != 0)
                {
                    objFor.localizar(objFor.for_codigo.ToString(), "for_codigo");
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
                    objFor.localizarProxAnterior("anterior", 0);
                else
                    objFor.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objFor.for_codigo != 0)
                {
                    objFor.localizar(objFor.for_codigo.ToString(), "for_codigo");
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
                    objFor.localizarProxAnterior("proximo", 0);
                else
                    objFor.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objFor.for_codigo != 0)
                {
                    objFor.localizar(objFor.for_codigo.ToString(), "for_codigo");
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
                objFor.localizarPrimeiroUltimo("ultimo");
                if (objFor.for_codigo != 0)
                {
                    objFor.localizar(objFor.for_codigo.ToString(), "for_codigo");
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

        private void btnBuscarEndereco_Click(object sender, EventArgs e)
        {
            string erro = string.Empty;
            UtilBll.EnderecoByJG enderecoByjg = UtilBll.ObterEnderecoPorCEPAutomatico(this.txtCEP.Text, out erro);

            if (enderecoByjg.Logradouro != null)
            {
                this.txtLogradouro.Text = enderecoByjg.Logradouro;
                this.txtBairro.Text = enderecoByjg.Bairro;
                this.cbCidade.SelectedIndex = cbCidade.FindString(enderecoByjg.Cidade.Trim());
            }
            else
            {
                MessageBox.Show(erro, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e){
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objFor.for_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se fornecedor já existe
               //   if (cbTipo.SelectedIndex == 0)
               //   {
               //       objFor.localizarLeave(objFor.for_nome, "for_nome"); //Pesquisa por descrição, na coluna descrição
               //       if (objFor.for_codigo != 0) // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
               //           throw new Exception("Este fornecedor já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
               //   }
               //   else
               //   {
               //       objFor.localizarLeave(objFor.for_razaoSocial, "for_razaoSocial"); //Pesquisa por descrição, na coluna descrição
               //       if (objFor.for_codigo != 0) // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
               //           throw new Exception("Este fornecedor já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
               //   }

                    objFor.inserir();
                    objFor.limpar();
                    limpar();
                    MessageBox.Show("Fornecedor incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objFor.alterar();
                    objFor.limpar();
                    limpar();
                    MessageBox.Show("Fornecedor alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objFor.limpar();
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
                if (objFor.for_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objFor.excluir();
                        objFor.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Cliente excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um cliente na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este fornecedor está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
