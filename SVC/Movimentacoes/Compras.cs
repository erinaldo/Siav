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
using View;
using System.Data.SqlClient;
using LFi.Control.Laçanmento_Financeiro;
using LFi;

namespace One.MOVIMENTACOES
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        ComprasBLL objCom = new ComprasBLL();
        comprasProdutoBLL objCP = new comprasProdutoBLL();
        Lancamento Lan = new Lancamento();

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;
                tab = objCom.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;              
             //   stiloGrid();
                gvPesquisa.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void carregacombo()
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBoxFornecedores(cbFornecedor, "Fornecedores", "for_codigo", "Fornecedores", "", "Fornecedores");
                objD.PreencheComboBox(cbFuncionario, "Usuario", "usu_codigo", "usu_nome", "", "usu_nome");
                objD.PreencheComboBox(cboFpg, "FormaPagamento", "fp_codigo", "fp_descricao", "", "fp_descricao");
                objD.PreencheComboBox(cboTpo, "TipoDeOperacao", "ID", "Nome", "Sinal = 'D'", "Nome");
                objD.PreencheComboBox(cboPrazo, "Prazo", "ID", "Prazo", "", "Prazo");
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
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
                objCom.limpar();
                objCP.limpar();
            }
        }

        private void btInserirFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Fornecedor frm = new CADASTROS.Fornecedor();
                frm.ShowDialog();
                frm = null;
                carregacombo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnInserirFormaPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Forma_Pagamento frm = new CADASTROS.Forma_Pagamento();
                frm.ShowDialog();
                frm = null;
                carregacombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtNumPedido.Text = "";
                txtData.Text = DateTime.Now.ToString();
                txtObservacoes.Text = "";
                txtQuantidade.Text = "";
                txtParcelasTitulos.Text = "";
                txtSubtotal.Text = "";
                txtTotal.Text = "";                
                txtTotalItens.Text = "";
                txtValorUnitario.Text = "";
                cbFornecedor.SelectedIndex = -1;
                //cbEmpresa.SelectedIndex = -1;
                //cbFormaPagamento.SelectedIndex = -1;
                //cbFuncionario.SelectedIndex = -1;
                cbProdutos.SelectedIndex = -1;
                dgDados.Rows.Clear();
                txtPesquisar.Text = "";
                txtCodigo.ReadOnly = false;
                txtCodigo.Enabled = true;
                //cbFormaPagamento.Enabled = true;
                cbFuncionario.SelectedValue = global.codUsuario;
                cbProdutos.Enabled = true;
                cbProdutos.DataSource = null;
                cbProdutos.Items.Clear();
                cbFornecedor.Enabled = true;
                //cbEmpresa.Enabled = true;

                txtValorUnitario.Enabled = true;
                txtQuantidade.Enabled = true;

                lCompraCancelada.Visible = false;
                cbRenovarCompra.Visible = false;
                cbRenovarCompra.Checked = true;
                //cbPessoa.Checked = false;
                btSalvar.Enabled = true;
                btExcluir.Enabled = true;
                cboFpg.SelectedIndex = -1;
                cboTpo.SelectedIndex = -1;
                cboPrazo.SelectedIndex = -1;
                cbProdutos.SelectedIndex = -1;
                cbFornecedor.SelectedIndex = -1;

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
                String x = "";
                for (int i = 0; i <= txtValorUnitario.Text.Length - 1; i++)
                {
                    if ((txtValorUnitario.Text[i] >= '0' &&
                    txtValorUnitario.Text[i] <= '9') ||
                    txtValorUnitario.Text[i] == ',')
                    {
                        x += txtValorUnitario.Text[i];
                    }
                }
                txtValorUnitario.Text = x;

                x = "";
                for (int i = 0; i <= txtSubtotal.Text.Length - 1; i++)
                {
                    if ((txtSubtotal.Text[i] >= '0' &&
                    txtSubtotal.Text[i] <= '9') ||
                    txtSubtotal.Text[i] == ',')
                    {
                        x += txtSubtotal.Text[i];
                    }
                }
                txtSubtotal.Text = x;

                x = "";
                for (int i = 0; i <= txtTotal.Text.Length - 1; i++)
                {
                    if ((txtTotal.Text[i] >= '0' &&
                    txtTotal.Text[i] <= '9') ||
                    txtTotal.Text[i] == ',')
                    {
                        x += txtTotal.Text[i];
                    }
                }
                txtTotal.Text = x;

                x = "";
                for (int i = 0; i <= txtTotal.Text.Length - 1; i++)
                {
                    if ((txtTotal.Text[i] >= '0' &&
                    txtTotal.Text[i] <= '9') ||
                    txtTotal.Text[i] == ',')
                    {
                        x += txtTotal.Text[i];
                    }
                }
                txtTotal.Text = x;


                //Compras
                if (txtCodigo.Text != "")
                    objCom.com_codigo = int.Parse(txtCodigo.Text);
                else
                    objCom.com_codigo= 0;
                if (txtNumPedido.Text != "")
                    objCom.com_numPedido= int.Parse(txtNumPedido.Text);
                else
                    objCom.com_numPedido = 0;
                txtData.Text = txtData.Text.Trim();
                if (txtData.Text != "")
                    objCom.com_dataCompra= DateTime.Parse(txtData.Text);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacoes.Text = txtObservacoes.Text.Trim();
                if (txtObservacoes.Text != "")
                    objCom.com_observacao = txtObservacoes.Text;
                else
                    objCom.com_observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a compra");
                else
                    objCom.com_usario = int.Parse(cbFuncionario.SelectedValue.ToString());
                if (cbFornecedor.SelectedValue == null)
                    throw new Exception("Por favor, informe qual o fornecedor será utilizado nesta compra");
                else
                    objCom.com_fornecedor = int.Parse(cbFornecedor.SelectedValue.ToString());
                //if (cbFormaPagamento.SelectedValue == null)
                //    throw new Exception("Por favor, informe qual a forma de pagamento que será utilizado nesta compra");
                //else
                //    objCom.com_formaPagamento = int.Parse(cbFormaPagamento.SelectedValue.ToString());
                txtParcelasTitulos.Text = txtParcelasTitulos.Text.Trim();
                if (txtParcelasTitulos.Text != "" && int.Parse(txtParcelasTitulos.Text) > 0)
                    objCom.com_quantidade = int.Parse(txtParcelasTitulos.Text);
                else
                    objCom.com_quantidade = 0;
                    //throw new Exception("Por favor, informe a quantidade de parcelas (acima de 0), que será utilizada nesta compra");
                objCom.com_valorTotal = decimal.Parse(txtTotal.Text);
                if (cbRenovarCompra.Checked == true)
                    objCom.com_status = "Ativo";
                else if (cbRenovarCompra.Checked == false)
                    objCom.com_status = "Cancelado";   
                if(cboFpg.SelectedValue == null)
                    throw new Exception("Informe a forma de pagamento.");
                if(cboPrazo.SelectedValue == null)
                    throw new Exception("Informe o prazo.");
                if(cboTpo.SelectedValue == null)
                {
                    throw new Exception("Informe o tipo de operação.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inserirComprasProduto()
        { 
            try
            {
                
                //altera (exclui)
                objCP.cp_compras = objCom.com_codigo;
                objCP.excluir();

                //ComprasProduto
                for (int i = 0; i < dgDados.Rows.Count; i++)
                {
                   
                    //e depois insere
                    objCP.cp_compras = objCom.com_codigo;
                    objCP.cp_produtos = int.Parse(dgDados.Rows[i].Cells[1].Value.ToString());

                    String valorUnitario = dgDados.Rows[i].Cells[3].Value.ToString();
                    String x = "";
                    for (int j = 0; j <= valorUnitario.Length - 1; j++)
                    {
                        if ((valorUnitario[j] >= '0' &&
                        valorUnitario[j] <= '9') ||
                        valorUnitario[j] == ',')
                        {
                            x += valorUnitario[j];
                        }
                    }
                    valorUnitario = x;

                    objCP.cp_valorUnitario = decimal.Parse(valorUnitario);
                    objCP.cp_quantidade = int.Parse(dgDados.Rows[i].Cells[4].Value.ToString());
                    String subtotal = dgDados.Rows[i].Cells[5].Value.ToString();
                    x = "";
                    for (int j = 0; j <= subtotal.Length - 1; j++)
                    {
                        if ((subtotal[j] >= '0' &&
                        subtotal[j] <= '9') ||
                        subtotal[j] == ',')
                        {
                            x += subtotal[j];
                        }
                    }
                    subtotal = x;

                    objCP.cp_subtotal = decimal.Parse(subtotal);
                    objCP.inserir();
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
                dgDados.Rows.Clear();
                 if (objCom.com_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objCom.com_codigo.ToString();
                 DataTable tab1 = null;
                 tab1 = carregarDadosCp(objCom.com_codigo);
                if (tab1.Rows.Count > 0)
                {
                    cboTpo.SelectedValue = tab1.Rows[0]["TipodeoperacaoID"].ToString();
                    cboFpg.SelectedValue = tab1.Rows[0]["formadepagamentoID"].ToString();
                    cboPrazo.SelectedValue = tab1.Rows[0]["Prazo"].ToString();
                }


                 txtData.Text = objCom.com_dataCompra.ToString();
                 cbFuncionario.SelectedValue = objCom.com_usario;

                 FornecedoresBLL objFor = new FornecedoresBLL();
                 objFor.localizar(objCom.com_fornecedor.ToString(), "for_codigo");
                 //if (objFor.for_tipo_fornecedor == "Pessoa Jurídica")
                 //{
                 //    cbPessoa.Checked = true;
                 //    Dados objD = new Dados();
                 //    objD.preencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
                 //    objD = null;
                 //}
                 //else
                 //{
                 //    cbPessoa.Checked = false;
                 //    Dados objD = new Dados();
                 //    objD.preencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                 //    objD = null;
                 //}
                 Contexto objD = new Contexto();
                 objD.PreencheComboBoxFornecedores(cbFornecedor, "Fornecedores", "for_codigo", "Fornecedores", "", "Fornecedores");
                 objD = null;

                 cbFornecedor.SelectedValue = objCom.com_fornecedor;
                 //cbFormaPagamento.SelectedValue = objCom.com_formaPagamento;
                 txtParcelasTitulos.Text = objCom.com_quantidade.ToString();
                 txtTotal.Text = objCom.com_valorTotal.ToString();
                 txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("C");
                 //cbEmpresa.SelectedValue = objCom.com_empresa;

                //carrega ComprasProduto
                DataTable tab =  objCP.localizarComRetorno(objCom.com_codigo.ToString(), "cp_compras");
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    ProdutosBLL objPro = new ProdutosBLL();
                    objPro.localizar(tab.Rows[i][1].ToString(), "pro_codigo");

                    dgDados.Rows.Add(tab.Rows[i][0].ToString(), tab.Rows[i][1].ToString(), objPro.pro_nome, Convert.ToDecimal(tab.Rows[i][2].ToString()).ToString("C"), tab.Rows[i][3].ToString(), Convert.ToDecimal(tab.Rows[i][4].ToString()).ToString("C"));

                    objPro = null;
                }

                txtObservacoes.Text = objCom.com_observacao;

                decimal qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += decimal.Parse(dgDados.Rows[i].Cells[4].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();

                if (objCom.com_status == "Cancelado")
                {
                    lCompraCancelada.Visible = true;
                    cbRenovarCompra.Visible = true;
                    cbRenovarCompra.Checked = false;
                }
                else
                {
                    lCompraCancelada.Visible = false;
                    cbRenovarCompra.Visible = false;
                    cbRenovarCompra.Checked = true;
                }
                if (objCom.com_numPedido != 0)
                    txtNumPedido.Text = objCom.com_numPedido.ToString();
                else
                    txtNumPedido.Text = "";

                if (global.permissao != "Gerente" && global.codUsuario.ToString() != cbFuncionario.SelectedValue.ToString())
                {
                    btSalvar.Enabled = false;
                    btExcluir.Enabled = false;
                }
                else
                {
                    btSalvar.Enabled = true;
                    btExcluir.Enabled = true;
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private DataTable carregarDadosCp(int compraID)
        {
            Contexto objD = null;
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select TipodeoperacaoID ,formadepagamentoID ,Prazo  from contasapagar where cp_compras = @ID";
                            
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = compraID;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void Compras_Load(object sender, EventArgs e)
        {
           
        }

        private void CarregarLoad()
        {
            gvPesquisa.AutoSizeColumnsMode =
              DataGridViewAutoSizeColumnsMode.AllCells; try
            {
                carregacombo();
                limpar();
                txtData.Text = DateTime.Now.ToString();
                txtData.ReadOnly = false;

                dgDados.Columns.Add("cp_compras", "Código da Compra");
                dgDados.Columns.Add("cp_produtos", "Código do Produto");
                dgDados.Columns.Add("pro_nome", "Produto");
                dgDados.Columns.Add("cp_valorUnitario", "Valor Unitário");
                dgDados.Columns.Add("cp_quantidade", "Quantidade");
                dgDados.Columns.Add("cp_subtotal", "Subtotal");

                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
                TabControl1.SelectedIndex = 0;

                //Mostrar Usuário logado e travar
                cbFuncionario.SelectedValue = global.codUsuario;
                cbFuncionario.Enabled = false;
                cboFpg.SelectedIndex = -1;
                cboTpo.SelectedIndex = -1;
                cboPrazo.SelectedIndex = -1;
                cbProdutos.SelectedIndex = -1;
                cbFornecedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btInserirProduto_Click(object sender, EventArgs e)
        {
           
        }

        private void btIncluirProduto_Click(object sender, EventArgs e)
        {
           
        }

        private void btExcluirProduto_Click(object sender, EventArgs e)
        {
           

        }

        private void txtParcelasTitulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValorUnitario.Text.Contains(','))
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

        private void txtValorUnitario_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValorUnitario.Text.Length - 1; i++)
                {
                    if ((txtValorUnitario.Text[i] >= '0' &&
                    txtValorUnitario.Text[i] <= '9') ||
                    txtValorUnitario.Text[i] == ',')
                    {
                        x += txtValorUnitario.Text[i];
                    }
                }
                txtValorUnitario.Text = x;
                txtValorUnitario.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void txtValorUnitario_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantidade.Text != "" && txtValorUnitario.Text != "")
                {
                    int qtd = int.Parse(txtQuantidade.Text);
                    decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                    decimal subtotal = qtd * valorUnitario;


                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
                    txtSubtotal.ReadOnly = false;
                    txtSubtotal.Text = subtotal.ToString();
                    txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString("C");
                    txtSubtotal.ReadOnly = true;
                }
                else if (txtValorUnitario.Text != "")
                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbProdutos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                if (cbProdutos.Text == "" || cbProdutos.Text == "System.Data.DataRowView")
                    objPro.localizarLeave("0", "pro_codigo");
                else
                objPro.localizarLeave(cbProdutos.Text, "pro_nome");
                
                if (objPro.pro_codigo != 0)
                    {
                        txtValorUnitario.Enabled = true;
                        txtQuantidade.Enabled = true;

                        txtValorUnitario.Text = objPro.pro_precoCusto.ToString();
                        if (txtQuantidade.Text != "")
                        {
                            int qtd = int.Parse(txtQuantidade.Text);
                            decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                            decimal Subtotal = qtd * valorUnitario;

                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
                            txtSubtotal.ReadOnly = false;
                            txtSubtotal.Text = Subtotal.ToString();
                            txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString("C");
                            txtSubtotal.ReadOnly = true;
                        }
                        else if (txtValorUnitario.Text != "")
                            txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
                    }
                    else
                    {
                        txtValorUnitario.Text = "";
                        txtQuantidade.Text = "";
                        txtValorUnitario.Enabled = false;
                        txtQuantidade.Enabled = false;
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public void InserirContasAPagar()
        {
            ContasAPagarBLL objCtap = new ContasAPagarBLL();
            
            DateTime dtDataInicial = Convert.ToDateTime(DateTime.Now.ToString());
            objCtap.cp_compras = objCom.com_codigo;
            objCtap = null;
            if (int.Parse(cboPrazo.SelectedValue.ToString()) == 1)
            {
                objCtap = new ContasAPagarBLL();
                objCtap.cp_vencimento = dtDataInicial;
                //cp_compras, cp_titulo, cp_serie,cp_emissao, cp_vencimento,cp_valor, cp_status,cp_observacao,cp_fornecedor,cp_dataPagamento
                objCtap.cp_compras = objCom.com_codigo;
                objCtap.cp_titulo = Convert.ToString(objCom.com_codigo) + 1;//Convert.ToInt32(txtParcelasTitulos.Text);
                objCtap.cp_serie = "1";
                objCtap.cp_emissao = dtDataInicial;
                objCtap.cp_valor = Math.Round((objCom.com_valorTotal / 1), 2);
                string status = "Pago";
                objCtap.cp_status = status;
                objCtap.cp_observacao = objCom.com_observacao;
                objCtap.cp_fornecedor = objCom.com_fornecedor;
                objCtap.TipoDeOperacaoID = int.Parse(cboTpo.SelectedValue.ToString());
                objCtap.FormaDePagamentoID = int.Parse(cboFpg.SelectedValue.ToString());
                objCtap.PrazoID = int.Parse(cboPrazo.SelectedValue.ToString());
                objCtap.inserir();
                Lan.Inserir(dtDataInicial, int.Parse(cboTpo.SelectedValue.ToString()), cboTpo.Text, "D", objCtap.cp_valor, objCom.com_codigo);
            }
            else
            {
                for (int i = 1; i <= Convert.ToInt32(txtParcelasTitulos.Text); i++)
                {
                    objCtap = new ContasAPagarBLL();
                    objCtap.cp_vencimento = dtDataInicial.AddMonths(i);
                    objCtap.cp_compras = objCom.com_codigo;
                    objCtap.cp_titulo = Convert.ToString(objCom.com_codigo) + Convert.ToInt32(txtParcelasTitulos.Text);
                    objCtap.cp_serie = "1";
                    objCtap.cp_emissao = dtDataInicial;
                    objCtap.cp_valor = Math.Round((objCom.com_valorTotal / Convert.ToInt32(txtParcelasTitulos.Text)), 2);
                    string status = "aberto";
                    objCtap.cp_status = status;
                    objCtap.cp_observacao = objCom.com_observacao;
                    objCtap.cp_fornecedor = objCom.com_fornecedor;
                    objCtap.TipoDeOperacaoID = int.Parse(cboTpo.SelectedValue.ToString());
                    objCtap.FormaDePagamentoID = int.Parse(cboFpg.SelectedValue.ToString());
                    objCtap.PrazoID = int.Parse(cboPrazo.SelectedValue.ToString());
                    objCtap.inserir();
                }
            }

        }
       
        private void btSalvar_Click(object sender, EventArgs e)
        {
           
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "" && txtValorUnitario.Text != "")
            {
                String x = "";
                for (int i = 0; i <= txtValorUnitario.Text.Length - 1; i++)
                {
                    if ((txtValorUnitario.Text[i] >= '0' &&
                    txtValorUnitario.Text[i] <= '9') ||
                    txtValorUnitario.Text[i] == ',')
                    {
                        x += txtValorUnitario.Text[i];
                    }
                }
                txtValorUnitario.Text = x;

                int qtd = int.Parse(txtQuantidade.Text);
                decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                decimal subtotal = qtd * valorUnitario;


                txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
                txtSubtotal.ReadOnly = false;
                txtSubtotal.Text = subtotal.ToString();
                txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString("C");
                txtSubtotal.ReadOnly = true;
            }
            else
            {
                txtSubtotal.Text = "0";
                txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString("C");
                if (txtQuantidade.Text == "")
                {
                    txtQuantidade.Text = "0";
                    txtQuantidade.SelectAll();
                }
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
           
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            try
            {
                //if (txtQuantidade.Text != "" && txtValorUnitario.Text != "")
                //{
                //    int qtd = int.Parse(txtQuantidade.Text);
                //    decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                //    valorUnitario = qtd * valorUnitario;



                //    txtSubtotal.ReadOnly = false;
                //    txtSubtotal.Text = valorUnitario.ToString();
                //    txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString("C");
                //    txtSubtotal.ReadOnly = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbPessoa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cbPessoa.Checked == true)
                //{
                //    Dados objD = new Dados();
                //    objD.preencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
                //    objD = null;
                //    cbFornecedor.SelectedIndex = -1;
                //}
                //else
                //{
                //    Dados objD = new Dados();
                //    objD.preencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                //    objD = null;
                //    cbFornecedor.SelectedIndex = -1;
                //}

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

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int comcod;
                int.TryParse(txtCodigo.Text, out comcod);
                if (comcod != 0)
                {
                    objCom.limpar();
                    objCom.localizarLeave(comcod.ToString(), "com_codigo");
                    if (objCom.com_codigo != 0)
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

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objCom.limpar();
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
                    groupBox2.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objCom.limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    btAnterior.Enabled = true;
                    btPrimeiro.Enabled = true;
                    btProximo.Enabled = true;
                    btUltimo.Enabled = true;
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    groupBox2.Visible = true;
                }
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
                        objCom.com_codigo = cod;
                        objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                        txtCodigo.Text = objCom.com_codigo.ToString();
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
                    objCom.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "com_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void cbRenovarCompra_CheckedChanged(object sender, EventArgs e)
        {
            if(cbRenovarCompra.Checked)
                objCom.com_status = "Ativo";
            else
                objCom.com_status = "Cancelado";
        }

        private void cbFornecedor_Leave(object sender, EventArgs e)
        {
            if (cbFornecedor.SelectedValue != null)
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbProdutos, "Produtos", "pro_codigo", "pro_nome", "pro_fornecedor = " + cbFornecedor.SelectedValue, "pro_nome");
                objD = null;
            }
            else
            {
                cbProdutos.DataSource = null;
                cbProdutos.Items.Clear();
            }
        }

        private void Label23_Click(object sender, EventArgs e)
        {

        }

        private void txtNumPedido_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int numPedido;
                int.TryParse(txtNumPedido.Text, out numPedido);
                if (numPedido != 0)
                {
                    objCom.limpar();
                    objCom.localizarLeave(numPedido.ToString(), "com_numPedido");
                    if (objCom.com_codigo != 0)
                    {
                        carregaCampos();
                        txtCodigo.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


        public ContasAPagar objCp { get; set; }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Carregar os campos no objeto
                carregaPropriedades();

                if (objCom.com_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    //Verificar se compra já existe
                    //objCat.localizar(objCat.cat_descricao, "cat_descricao"); //Pesquisa por descrição, na coluna descrição
                    //if (objCat.cat_codigo != 0) // se o código retornar um número acima de 0, significa que a compra já está cadastrada
                    //  throw new Exception("Esta compra já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                    objCom.inserir();
                    InserirContasAPagar();
                    inserirComprasProduto();
                    objCom.limpar();
                    objCP.limpar();
                    limpar();
                    MessageBox.Show("Compra incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                }
                else //Alteração
                {
                    objCom.alterar();
                    inserirComprasProduto();
                    objCom.limpar();
                    objCP.limpar();
                    limpar();

                    MessageBox.Show("Compra alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                 if (MessageBox.Show("Deseja dar Entrada dessa mercadoria?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                 {
                     EntradaMercadoria frm = new EntradaMercadoria();
                     frm.ShowDialog();
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
                objCom.limpar();
                objCP.limpar();
                limpar();
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
                if (objCom.com_codigo != 0)
                {
                    if (global.permissao != "Gerente" && global.codUsuario != objCom.com_usario)
                        throw new Exception("Você não tem permissão para cancelar esta compra");


                    if (MessageBox.Show("Deseja realmente cancelar esta compra?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objCom.com_status = "Cancelado";
                        objCom.cancelarCompra();
                        Lan.Excluir(int.Parse(txtCodigo.Text));
                        objCom.limpar();
                        objCP.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Compra cancelada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma Compra na aba 'Pesquisar', ou escolher um código válido para poder cancelar a compra", "Cancelar Compra", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objCom.localizarPrimeiroUltimo("primeiro");
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
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
                    objCom.localizarProxAnterior("anterior", 0);
                else
                    objCom.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
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
                    objCom.localizarProxAnterior("proximo", 0);
                else
                    objCom.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
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
                objCom.localizarPrimeiroUltimo("ultimo");
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Produto frm = new CADASTROS.Produto();
                frm.ShowDialog();
                if (cbFornecedor.SelectedValue != null)
                {
                    Contexto objD = new Contexto();
                    objD.PreencheComboBox(cbProdutos, "Produtos", "pro_codigo", "pro_nome", "pro_fornecedor = " + cbFornecedor.SelectedValue, "pro_nome");
                    objD = null;
                    cbProdutos.SelectedValue = frm.proCompra;
                }
                frm = null;
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
                String achou = "";

                String x = "";
                for (int j = 0; j <= txtValorUnitario.Text.Length - 1; j++)
                {
                    if ((txtValorUnitario.Text[j] >= '0' &&
                    txtValorUnitario.Text[j] <= '9') ||
                    txtValorUnitario.Text[j] == ',')
                    {
                        x += txtValorUnitario.Text[j];
                    }
                }
                txtValorUnitario.Text = x;

                if (cbProdutos.SelectedValue == null)
                    throw new Exception("Produto não encontrado na base de dados");

                if (txtValorUnitario.Text == "")
                    throw new Exception("O valor unitário deve possuir um valor numérico");

                if (txtQuantidade.Text == "" || txtQuantidade.Text.Equals("0"))
                    throw new Exception("O campo quantidade deve possuir um número inteiro maior que 0");

                if (txtSubtotal.Text == "" || txtSubtotal.Text.Equals("R$ 0,00"))
                    throw new Exception("O campo subtotal deve possui um número real maior que 0");

                //Verificar se já existe o produto inserido
                for (int i = 0; i < dgDados.Rows.Count; i++)
                {
                    if (dgDados.Rows[i].Cells[1].Value.ToString() == cbProdutos.SelectedValue.ToString())
                    {
                        ProdutosBLL objPro = new ProdutosBLL();
                        objPro.localizarLeave(cbProdutos.SelectedValue.ToString(), "pro_codigo");

                        int qtd = int.Parse(dgDados.Rows[i].Cells[4].Value.ToString());
                        String subtotal = "";
                        dgDados.Rows[i].Cells[4].Value = qtd + int.Parse(txtQuantidade.Text);
                        subtotal = (int.Parse(dgDados.Rows[i].Cells[4].Value.ToString()) * decimal.Parse(txtValorUnitario.Text)).ToString();
                        subtotal = Convert.ToDecimal(subtotal).ToString("C");
                        dgDados.Rows[i].Cells[5].Value = subtotal;
                        achou = "Sim";
                    }
                }
                if (achou == "Sim")
                {
                    decimal total = 0;
                    for (int k = 0; k < dgDados.Rows.Count; k++)
                    {
                        String subtotal = dgDados.Rows[k].Cells[5].Value.ToString();

                        x = "";
                        for (int j = 0; j <= subtotal.Length - 1; j++)
                        {
                            if ((subtotal[j] >= '0' &&
                            subtotal[j] <= '9') ||
                            subtotal[j] == ',')
                            {
                                x += subtotal[j];
                            }
                        }
                        subtotal = x;

                        total += decimal.Parse(subtotal);
                    }
                    txtTotal.Text = total.ToString();
                    txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("C");
                }

                //Primeira vez que está inserindo o produto
                if (achou != "Sim")
                {
                    if (txtCodigo.Text != "")
                    {
                        ProdutosBLL objPro = new ProdutosBLL();
                        objPro.localizar(cbProdutos.SelectedValue.ToString(), "pro_codigo");

                        dgDados.Rows.Add(txtCodigo.Text, cbProdutos.SelectedValue.ToString(), objPro.pro_nome, txtValorUnitario.Text, txtQuantidade.Text, txtSubtotal.Text);

                        objPro = null;

                    }
                    else
                    {
                        ProdutosBLL objPro = new ProdutosBLL();
                        objPro.localizar(cbProdutos.SelectedValue.ToString(), "pro_codigo");

                        dgDados.Rows.Add("", cbProdutos.SelectedValue.ToString(), objPro.pro_nome, txtValorUnitario.Text, txtQuantidade.Text, txtSubtotal.Text);

                        objPro = null;
                    }

                    decimal total = 0;
                    for (int k = 0; k < dgDados.Rows.Count; k++)
                    {

                        String valorUnitario = dgDados.Rows[k].Cells[5].Value.ToString();

                        x = "";
                        for (int j = 0; j <= valorUnitario.Length - 1; j++)
                        {
                            if ((valorUnitario[j] >= '0' &&
                            valorUnitario[j] <= '9') ||
                            valorUnitario[j] == ',')
                            {
                                x += valorUnitario[j];
                            }
                        }
                        valorUnitario = x;


                        String subtotal = decimal.Parse(valorUnitario).ToString();



                        //total += int.Parse(dgDados.Rows[k].Cells[4].Value.ToString()) * decimal.Parse(subtotal);
                        total += decimal.Parse(subtotal);
                    }
                    txtTotal.Text = total.ToString();
                    txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("C");

                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");


                }
                int qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += int.Parse(dgDados.Rows[i].Cells[4].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();
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
                if (this.dgDados.CurrentRow != null)
                {
                    this.dgDados.Rows.Remove(this.dgDados.CurrentRow);
                    if (dgDados.Rows.Count > 0)
                    {
                        decimal total = 0;
                        for (int k = 0; k < dgDados.Rows.Count; k++)
                        {
                            String subtotal = dgDados.Rows[k].Cells[5].Value.ToString();

                            String x = "";
                            for (int j = 0; j <= subtotal.Length - 1; j++)
                            {
                                if ((subtotal[j] >= '0' &&
                                subtotal[j] <= '9') ||
                                subtotal[j] == ',')
                                {
                                    x += subtotal[j];
                                }
                            }
                            subtotal = x;

                            //total += int.Parse(dgDados.Rows[k].Cells[4].Value.ToString()) * decimal.Parse(subtotal);
                            total += decimal.Parse(subtotal);
                        }
                        txtTotal.Text = total.ToString();
                        txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("C");

                        // txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString("C");
                    }
                    else
                    {
                        txtTotal.Text = "0";
                        txtTotal.Text = Convert.ToDecimal(txtTotal.Text).ToString("C");
                    }
                }

                int qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += int.Parse(dgDados.Rows[i].Cells[4].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();
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

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Compras_Shown(object sender, EventArgs e)
        {
            CarregarLoad();
        }

        private void cboPrazo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cboPrazo_DropDown(object sender, EventArgs e)
        {
            //int prazo = int.Parse(cboPrazo.SelectedValue.ToString());
            //if (prazo == 2)
            //    txtParcelasTitulos.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            frmTipoDeOperacao frm = new frmTipoDeOperacao();
            frm.ShowDialog();
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboTpo, "TipoDeOperacao", "ID", "Nome", "Sinal = 'D'", "Nome");
            objD = null;
            frm = null;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            EntradaMercadoria frm = new EntradaMercadoria();
            frm.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ContasAPagar frm = new ContasAPagar();
            frm.ShowDialog();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
