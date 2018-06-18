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
using System.Reflection;
using View;

namespace One.CADASTROS
{
    public partial class Cliente : Form
    {
        ClienteBLL clienteBll = new ClienteBLL();

        public Cliente()
        {
            InitializeComponent();
        }
        private void Cliente_Load(object sender, EventArgs e)
        {
          
            
        }
        private void LoadCliente(){
            dgvClientes.AutoSizeColumnsMode =
        DataGridViewAutoSizeColumnsMode.AllCells;
            //CarregarEstado();
            //cbCidade.SelectedIndex = -1;
            //cboUF.SelectedIndex = -1;
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboUF, "estado", "est_codigo_IBGE", "est_nome", "", "est_nome"); 
        }
        private void CarregarCidade( int EstadoID)
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    contexto.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome","cid_estado ="+ EstadoID.ToString(), "cid_nome");
                    cbTipo.SelectedIndex = 0;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void CarregarEstadoPorID( int EstadoID)
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    //contexto.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome", "", "cid_nome");
                    contexto.PreencheComboBox(cboUF, "Estado", "est_codigo", "est_sigla", "est_codigo = "+EstadoID, "est_sigla");
                    cbTipo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void CarregarEstado()
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    //contexto.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome", "", "cid_nome");
                    contexto.PreencheComboBox(cboUF, "Estado", "est_codigo", "est_sigla", "", "est_sigla");
                    cbTipo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

                if (cbTipo.SelectedIndex == 0){

                    this.panelFisica.Visible = true;
                    this.panelJur.Visible = false;

                }else{

                    this.panelFisica.Visible = false;
                    this.panelJur.Visible = true;

                }                
            
            }catch (Exception){
                
                throw;

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }        
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgvClientes.Rows.Count)
                {
                    int cod = cod = int.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (cod != 0)
                    {
                        clienteBll.Localizar(cod.ToString(), "cli_codigo");

                        txtPesquisar.Text = "";
                        CarregaCampos();

                        txtCodigo.Text = clienteBll.cli_codigo.ToString();                        
                        txtCodigo.Enabled = false;

                        if (clienteBll.cli_tipo_pessoa == "Pessoa Física")
                        {
                            cbTipo.SelectedIndex = 0;
                        }
                        else
                        {
                            cbTipo.SelectedIndex = 1;
                        }

                        cbTipo.Enabled = false;

                        TabControl1.SelectedIndex = 0;
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
                    clienteBll.LimparCliente();
                    LimparCamposFormulario();
                    CarregaGridCliente();
                    txtPesquisar.Focus();

                    btSalvar.Enabled = false;
                    btCancelar.Enabled = false;

               
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    gbMenu.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    clienteBll.LimparCliente();

                    btSalvar.Enabled = true;
                    btCancelar.Enabled = true;

               
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    gbMenu.Visible = true;
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
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void txtIdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=(char)8)
            {
                e.Handled = true;
            }
        }
        private void txtLimiteCredito_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtLimiteCredito.Text.Length - 1; i++)
                {
                    if ((txtLimiteCredito.Text[i] >= '0' && txtLimiteCredito.Text[i] <= '9') || txtLimiteCredito.Text[i] == ',')
                    {
                        x += txtLimiteCredito.Text[i];
                    }
                }
                txtLimiteCredito.Text = x;
                txtLimiteCredito.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }
        private void txtLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtLimiteCredito.Text.Contains(','))
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
        private void txtLimiteCreditoMensal_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";

                for (int i = 0; i <= txtLimiteCreditoMensal.Text.Length - 1; i++)
                {
                    if ((txtLimiteCreditoMensal.Text[i] >= '0' && txtLimiteCreditoMensal.Text[i] <= '9') || txtLimiteCreditoMensal.Text[i] == ',')
                    {
                        x += txtLimiteCreditoMensal.Text[i];
                    }
                }

                txtLimiteCreditoMensal.Text = x;
                txtLimiteCreditoMensal.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }
        private void txtLimiteCreditoMensal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txtLimiteCreditoMensal.Text.Contains(','))
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
        private void btImprimir_Click(object sender, EventArgs e)
        {
          
            printDGV.Print_DataGridView(dgvClientes);
        }
        private void btnBuscarEndereco_Click(object sender, EventArgs e)
        {
            string erro = string.Empty;
            UtilBll.EnderecoByJG enderecoByjg = UtilBll.ObterEnderecoPorCEPAutomatico(this.mtxtCep.Text, out erro);

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
        
        #region Métodos de Leave

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo.Text, out cod);

                if (cod != 0)
                {
                    clienteBll.LocalizarLeave(cod.ToString(), "cli_codigo");

                    if (clienteBll.cli_codigo != 0)
                    {
                        CarregaCampos();

                        txtCodigo.Enabled = false;

                        if (clienteBll.cli_tipo_pessoa == "Pessoa Física")
                        {
                            cbTipo.SelectedIndex = 0;
                        }
                        else
                        {
                            cbTipo.SelectedIndex = 1;
                        }

                        cbTipo.Enabled = false;
                    }
                    else
                    {
                        LimparCamposFormulario();
                    }
                }
                else
                {
                    LimparCamposFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLimiteCreditoMensal_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtLimiteCreditoMensal.Text != "")
                {
                    txtLimiteCreditoMensal.Text = Convert.ToDouble(txtLimiteCreditoMensal.Text).ToString("C");
                }
            }
            catch (Exception)
            {
                txtLimiteCreditoMensal.Text = "";
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLimiteCredito_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtLimiteCredito.Text != "")
                {
                    txtLimiteCredito.Text = Convert.ToDouble(txtLimiteCredito.Text).ToString("C");
                }
            }
            catch (Exception)
            {
                txtLimiteCredito.Text = "";
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtDtNasc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDtNasc.Text != "  /  /")
                {
                    DateTime data;
                    DateTime.TryParse(txtDtNasc.Text, out data);

                    if (data == DateTime.MinValue)
                    {
                        txtDtNasc.Focus();
                        txtDtNasc.Text = "";

                        throw new Exception("Data de nascimento inválida");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtDataFundacao_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDataFundacao.Text != "  /  /")
                {
                    DateTime data;
                    DateTime.TryParse(txtDataFundacao.Text, out data);

                    if (data == DateTime.MinValue)
                    {
                        txtDataFundacao.Text = "";
                        txtDataFundacao.Focus();

                        throw new Exception("Data de fundação inválida");
                    }
                }
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
            //    if (txtCpf.Text != string.Empty)
            //    {
            //        if (!UtilBll.VerificaCPF(txtCpf.Text))
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
            //try
            //{
            //    if (txtCnpj.Text != string.Empty)
            //    {
            //        if (!UtilBll.VerificaCNPJ(txtCnpj.Text))
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

        #endregion

        #region Botões de Ação

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.clienteBll.LimparCliente();

                //Carregar os campos no objeto
                CarregaPropriedades();

                //Se o código for 0, significa que não é alteração, mas sim inserção 
                if (clienteBll.cli_codigo == 0)
                {
                    //Verificar se cliente já existe
                    if (cbTipo.SelectedIndex == 0)
                    {
                        //Pesquisa por descrição, na coluna descrição
                        clienteBll.LocalizarLeave(clienteBll.cli_nome, "cli_nome");

                        // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                        if (clienteBll.cli_codigo != 0)
                        {
                            // Se cair no throw automaticamente os comandos de inserção são cancelados
                            throw new Exception("Este cliente já existe no sistema");
                        }
                    }
                    else
                    {
                        //Pesquisa por descrição, na coluna descrição
                        clienteBll.LocalizarLeave(clienteBll.cli_razao_social, "cli_razao_social");

                        // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                        if (clienteBll.cli_codigo != 0)
                        {
                            throw new Exception("Este cliente já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                        }
                    }

                    clienteBll.InserirCliente();

                    clienteBll.LimparCliente();

                    LimparCamposFormulario();

                    MessageBox.Show("Cliente incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    clienteBll.AlterarCliente();

                    clienteBll.LimparCliente();

                    LimparCamposFormulario();

                    MessageBox.Show("Cliente alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                clienteBll.LimparCliente();
                LimparCamposFormulario();
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
                if (txtCodigo.Text != "")
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ClienteDAL cli = new ClienteDAL();
                        //clienteBll.ExcluirCliente();
                        cli.ExcluirCliente(int.Parse(txtCodigo.Text));
                        clienteBll.LimparCliente();
                        LimparCamposFormulario();
                        CarregaGridCliente();
                        MessageBox.Show("Cliente excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um cliente na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este cliente está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region Localizar cliente

        /// <summary>
        /// Localizar primeiro cliente
        /// </summary>
        private void btPrimeiro_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    CarregaPropriedades();
                else
                    LimparCamposFormulario();
                clienteBll.LocalizarPrimeiroUltimo("primeiro");
                if (clienteBll.cli_codigo != 0)
                {
                    clienteBll.Localizar(clienteBll.cli_codigo.ToString(), "cli_codigo");
                    CarregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Localizar cliente anterior
        /// </summary>
        private void btAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "")
                {
                    clienteBll.LocalizarProxAnterior("anterior", 0);
                }
                else
                {
                    clienteBll.LocalizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                }

                if (clienteBll.cli_codigo != 0)
                {
                    clienteBll.Localizar(clienteBll.cli_codigo.ToString(), "cli_codigo");

                    CarregaCampos();

                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Localizar proximo cliente
        /// </summary>
        private void btProximo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    CarregaPropriedades();
                else
                    LimparCamposFormulario();
                if (txtCodigo.Text == "")
                    clienteBll.LocalizarProxAnterior("proximo", 0);
                else
                    clienteBll.LocalizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (clienteBll.cli_codigo != 0)
                {
                    clienteBll.Localizar(clienteBll.cli_codigo.ToString(), "cli_codigo");
                    CarregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Localizar ultimo cliente
        /// </summary>
        private void btUltimo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    CarregaPropriedades();
                else
                    LimparCamposFormulario();
                clienteBll.LocalizarPrimeiroUltimo("ultimo");
                if (clienteBll.cli_codigo != 0)
                {
                    clienteBll.Localizar(clienteBll.cli_codigo.ToString(), "cli_codigo");
                    CarregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region Métodos Auxiliares

        public void LimparCamposFormulario()
        {
            try
            {
                txtBairro.Text = "";
                txtCelular.Text = "";
                txtCnpj.Text = "";
                txtCodigo.Text = "";
                txtComplemento.Text = "";
                txtCpf.Text = "";
                txtDataFundacao.Text = "";
                txtDtNasc.Text = "";
                txtIdade.Text = "";
                txtInscrEstadual.Text = "";
                mtxtCep.Text = "";
                txtLogradouro.Text = "";
                txtNome.Text = "";
                txtNumero.Text = "";
                txtPesquisar.Text = "";
                txtRazaoSocial.Text = "";
                txtRg.Text = "";
                txtTelefone.Text = "";
                cbCidade.SelectedIndex = -1;
                cbOpcao.SelectedIndex = 0;
                cbTipo.SelectedIndex = 0;
                cbCalculaJuros.Checked = false;
                txtLimiteCredito.Text = "";
                txtLimiteCreditoMensal.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                cbTipo.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CarregaGridCliente()
        {
            try
            {
                DataTable tab = null;

                tab = clienteBll.LocalizarEmTudo(txtPesquisar.Text, cbOpcao.SelectedItem.ToString());

                dgvClientes.DataSource = tab;

                dgvClientes.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CarregaPropriedades()
        {
            try
            {
                if (txtCodigo.Text != string.Empty)
                {
                    clienteBll.cli_codigo = int.Parse(txtCodigo.Text);
                }
                else
                {
                    clienteBll.cli_codigo = 0;
                }
                
                //cbTipo.SelectedIndex
                if (true)
                {
                    //Dados pessoa fisica
                    if (txtNome.Text != string.Empty)
                    {
                        clienteBll.cli_nome = txtNome.Text;
                    }
                    else
                    {
                        throw new Exception("O campo nome é de preenchimento obrigatório.");
                    }

                    if (txtCpf.Text != string.Empty)
                    {
                        clienteBll.cli_cpf = txtCpf.Text;
                    }

                    if (txtIdade.Text != string.Empty)
                    {
                        clienteBll.cli_idade = int.Parse(txtIdade.Text);
                    }

                    DateTime dtNascimento = new DateTime();
                    if (DateTime.TryParse(txtDtNasc.Text, out dtNascimento))
                    {
                        clienteBll.cli_data_nascimento = dtNascimento;
                    }

                    if (txtRg.Text != string.Empty)
                    {
                        clienteBll.cli_rg = txtRg.Text;
                    }
                }
                else
                {
                    //Dados pessoa juridica
                    if (txtRazaoSocial.Text != string.Empty)
                    {
                        clienteBll.cli_razao_social = txtRazaoSocial.Text;
                    }
                    else
                    {
                        throw new Exception("o campo 'Razão Social' é de preenchimento obrigatório.");
                    }

                    if (txtCnpj.Text != string.Empty)
                    {
                        clienteBll.cli_cnpj = txtCnpj.Text;
                    }


                    DateTime dtFundacao = new DateTime();
                    if (DateTime.TryParse(txtDataFundacao.Text, out dtFundacao))
                    {
                        clienteBll.cli_data_fundacao = dtFundacao;
                    }

                    if (txtInscrEstadual.Text != string.Empty)
                    {
                        clienteBll.cli_ie = txtInscrEstadual.Text;
                    }
                }

                //cbTipo.SelectedIndex == 0
                if (true)
                {
                    clienteBll.cli_tipo_pessoa = "Pessoa Física";
                }
                else
                {
                    clienteBll.cli_tipo_pessoa = "Pessoa Jurídica";
                }

                if (mtxtCep.Text != string.Empty)
                {
                    clienteBll.cli_cep = mtxtCep.Text;
                }

                if (txtLogradouro.Text != string.Empty)
                {
                    clienteBll.cli_logradouro = txtLogradouro.Text;
                }
                else
                {
                    //throw new Exception("O campo logradouro é de preenchimento obrigatório.");
                    clienteBll.cli_logradouro = "s/l";
                }

                if (txtNumero.Text != string.Empty)
                {
                    clienteBll.cli_numero = txtNumero.Text;
                }
                else
                {
                    //throw new Exception("O campo número é de preenchimento obrigatório.");
                    clienteBll.cli_numero = "S/M";
                }

                clienteBll.cli_complemento = txtComplemento.Text;

                if (txtBairro.Text != string.Empty)
                {
                    clienteBll.cli_bairro = txtBairro.Text;
                }
                else
                {
                    // throw new Exception("O campo bairro é de preenchimento obrigatório.");
                    clienteBll.cli_bairro = ".";
                }

                if (cbCidade.SelectedValue != null)
                {
                    clienteBll.cid_codigo = int.Parse(cbCidade.SelectedValue.ToString());
                }
                else
                {
                   // throw new Exception("Cidade não encontrada na base de dados.");
                    clienteBll.cid_codigo = 1;
                }

                if (txtCelular.Text != string.Empty)
                {
                    clienteBll.cli_celular = txtCelular.Text;
                }

                if (txtTelefone.Text != string.Empty)
                {
                    clienteBll.cli_telefone = txtTelefone.Text;
                }
                else
                {
                    //throw new Exception("Telefone deve ser informadoo.");
                    clienteBll.cli_telefone = ".";
                }

                if (cbCalculaJuros.Checked == true)
                {
                    clienteBll.cli_calJuros = "Sim";
                }
                else
                {
                    clienteBll.cli_calJuros = "Não";
                }

                String x = "";

                for (int i = 0; i <= txtLimiteCredito.Text.Length - 1; i++)
                {
                    if ((txtLimiteCredito.Text[i] >= '0' && txtLimiteCredito.Text[i] <= '9') || txtLimiteCredito.Text[i] == ',')
                    {
                        x += txtLimiteCredito.Text[i];
                    }
                }

                txtLimiteCredito.Text = x;

                if (txtLimiteCredito.Text != string.Empty)
                {
                    clienteBll.cli_limiteCredito = Double.Parse(txtLimiteCredito.Text);
                }
                else
                {
                    clienteBll.cli_limiteCredito = 0;
                }

                x = "";

                for (int i = 0; i <= txtLimiteCreditoMensal.Text.Length - 1; i++)
                {
                    if ((txtLimiteCreditoMensal.Text[i] >= '0' && txtLimiteCreditoMensal.Text[i] <= '9') || txtLimiteCreditoMensal.Text[i] == ',')
                    {
                        x += txtLimiteCreditoMensal.Text[i];
                    }
                }

                txtLimiteCreditoMensal.Text = x;

                if (txtLimiteCreditoMensal.Text != "")
                {
                    clienteBll.cli_limiteMensal = Double.Parse(txtLimiteCreditoMensal.Text);
                }
                else
                {
                    clienteBll.cli_limiteMensal = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CarregaCampos()
        {
            try
            {
                if (clienteBll.cli_codigo == 0)
                {
                    txtCodigo.Text = "";
                }
                else
                {
                    txtCodigo.Text = clienteBll.cli_codigo.ToString();
                }

                if (clienteBll.cli_tipo_pessoa == "Pessoa Física")
                {
                    this.cbTipo.SelectedIndex = 0;

                    txtNome.Text = clienteBll.cli_nome;

                    if (clienteBll.cli_idade != 0)
                    {
                        txtIdade.Text = clienteBll.cli_idade.ToString();
                    }
                    
                    if (clienteBll.cli_data_nascimento != DateTime.MinValue)
                    {
                        txtDtNasc.Text = clienteBll.cli_data_nascimento.ToString();
                    }
                    
                    txtRg.Text = clienteBll.cli_rg;
                    txtCpf.Text = clienteBll.cli_cpf;
                }
                else
                {
                    this.cbTipo.SelectedIndex = 1;

                    txtRazaoSocial.Text = clienteBll.cli_razao_social;

                    if (clienteBll.cli_data_fundacao != DateTime.MinValue)
                    {
                        txtDataFundacao.Text = clienteBll.cli_data_fundacao.ToString();
                    }
                    
                    txtInscrEstadual.Text = clienteBll.cli_ie;
                    txtCnpj.Text = clienteBll.cli_cnpj;
                }

                mtxtCep.Text = clienteBll.cli_cep;
                txtLogradouro.Text = clienteBll.cli_logradouro;
                txtNumero.Text = clienteBll.cli_numero;
                txtComplemento.Text = clienteBll.cli_complemento;
                txtBairro.Text = clienteBll.cli_bairro;
                //CarregarCidade(1);
                //cboUF.SelectedValue = 8;
                cboUF.SelectedValue = clienteBll.cli_estado;
                cbCidade.SelectedValue = clienteBll.cid_codigo;
                txtTelefone.Text = clienteBll.cli_telefone;
                txtCelular.Text = clienteBll.cli_celular;

                if (clienteBll.cli_calJuros == "Sim")
                {
                    cbCalculaJuros.Checked = true;
                }
                else
                {
                    cbCalculaJuros.Checked = false;
                }

                if (clienteBll.cli_limiteCredito != (Double)0)
                {
                    txtLimiteCredito.Text = clienteBll.cli_limiteCredito.ToString();
                }

                if (clienteBll.cli_limiteMensal != (Double)0)
                {
                    txtLimiteCreditoMensal.Text = clienteBll.cli_limiteMensal.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void dgvClientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgvClientes.Rows.Count)
                {
                    int cod = cod = int.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    clienteBll.cli_codigo = cod;
                    if (cod != 0)
                    {
                        clienteBll.Localizar(clienteBll.cli_codigo.ToString(), "cli_codigo");
                        
                        txtPesquisar.Text = "";
                        CarregaCampos();

                        txtCodigo.Text = clienteBll.cli_codigo.ToString();
                        txtCodigo.Enabled = false;

                        if (clienteBll.cli_tipo_pessoa == "Pessoa Física")
                        {
                            cbTipo.SelectedIndex = 0;
                        }
                        else
                        {
                            cbTipo.SelectedIndex = 1;
                        }

                        cbTipo.Enabled = false;

                        TabControl1.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void txtCpf_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {

        }
        private void txtCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void TabPage6_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.clienteBll.LimparCliente();
                //Carregar os campos no objeto
                CarregaPropriedades();

                //Se o código for 0, significa que não é alteração, mas sim inserção 
                if (clienteBll.cli_codigo == 0)
                {
                    //Verificar se cliente já existe
                    //cbTipo.SelectedIndex == 0
                    if (true)
                    {
                        //Pesquisa por descrição, na coluna descrição
                        clienteBll.LocalizarLeave(clienteBll.cli_nome, "cli_nome");

                        // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                        if (clienteBll.cli_codigo != 0)
                        {
                            // Se cair no throw automaticamente os comandos de inserção são cancelados
                            throw new Exception("Este cliente já existe no sistema");
                        }
                    }
                    else
                    {
                        //Pesquisa por descrição, na coluna descrição
                        clienteBll.LocalizarLeave(clienteBll.cli_razao_social, "cli_razao_social");

                        // se o código retornar um número acima de 0, significa que a cliente já está cadastrada
                        if (clienteBll.cli_codigo != 0)
                        {
                            throw new Exception("Este cliente já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                        }
                    }
                    
                    clienteBll.InserirCliente();
                    clienteBll.LimparCliente();
                    LimparCamposFormulario();
                    
                    MessageBox.Show("Cliente incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    clienteBll.AlterarCliente();
                    clienteBll.LimparCliente();
                    LimparCamposFormulario();

                    MessageBox.Show("Cliente alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                clienteBll.LimparCliente();
                LimparCamposFormulario();
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
                if (txtCodigo.Text != "")
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ClienteDAL cli = new ClienteDAL();
                        //clienteBll.ExcluirCliente();
                        cli.ExcluirCliente(int.Parse(txtCodigo.Text));
                        clienteBll.LimparCliente();
                        LimparCamposFormulario();
                        CarregaGridCliente();
                        MessageBox.Show("Cliente excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um cliente na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este cliente está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        private void gbMenu_Enter(object sender, EventArgs e)
        {

        }
        private void cboUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{

                ComboBox cmb = (ComboBox)sender;
                int selectedIndex = cmb.SelectedIndex;
                int selectedValue = (int)cmb.SelectedValue;

                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbCidade, "Cidade", "cid_codigo", "cid_nome", "cid_estado = " + selectedValue, "cid_nome");
                objD = null;

            }catch{

            }
        }
        private void dgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Cliente_Shown(object sender, EventArgs e)
        {
            LoadCliente();
        }
        private void Label49_Click(object sender, EventArgs e)
        {

        }
        private void label32_Click(object sender, EventArgs e)
        {

        }
        
                

    }
}
