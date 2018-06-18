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
using LFi.Control.Laçanmento_Financeiro;

namespace One.MOVIMENTACOES
{
    public partial class ContasAPagar : Form
    {
        public ContasAPagar()
        {
            InitializeComponent();
        }
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public string codigo = "";
        Lancamento Lan = new Lancamento();

        ContasAPagarBLL objCAP = new ContasAPagarBLL();
        ComprasBLL objCom = null;
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
                objCAP.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtNumPedido.Text = "";
                txtCodigo.Enabled = true;
                txtCompra.ReadOnly = false;
                txtCompra.Text = "";
                txtCompra.Enabled = true;
                txtCompra.ReadOnly = false;
                //cbPessoaJuridica.Checked = false;
                cbPrestServ.Checked = false;
                cbFornPresServ.Enabled = true;
                cbFornPresServ.SelectedIndex = -1;
                //cbPessoaJuridica.Enabled = true;
                cbPrestServ.Enabled = true;                
                txtTitulo.Text = "";
                txtSerie.Text = "";
                txtDataEmissao.Text = "";
                txtDataValidade.Text = "";
                txtValor.Text = "";
                cbSituacao.SelectedIndex = 0;
                txtObservacoes.Text = "";
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
                    objCAP.cp_codigo = int.Parse(txtCodigo.Text);
                else
                    objCAP.cp_codigo = 0;
                 if (!cbPrestServ.Checked) //Fornecedores
                 {
                     if (txtCompra.Text != "")
                     {
                         objCom = new ComprasBLL();
                         objCom.localizar(txtCompra.Text, "com_codigo");
                         if (objCom.com_codigo == 0)
                             throw new Exception("Compra inexistente, por favor, selecione uma compra válida");
                         objCAP.cp_compras = objCom.com_codigo;
                         objCom = null;
                     }
                     else
                         throw new Exception("Não é possível gerar uma conta a pagar sem o número da compra do Fornecedor");
                 }
                 else //Prestadores de Serviço
                     if (txtCompra.Text != "")
                         throw new Exception("Não é possivel referenciar uma compra para um prestador de serviço");
                     else
                         objCAP.cp_compras = 0;
                 if (cbFornPresServ.SelectedValue == null)
                     throw new Exception("Fornecedor não encontrado na base de dados");
                 else
                     objCAP.cp_fornecedor = int.Parse(cbFornPresServ.SelectedValue.ToString());
                 txtTitulo.Text = txtTitulo.Text.Trim();
                 if (txtTitulo.Text != "")
                     objCAP.cp_titulo = txtTitulo.Text;
                 else
                     throw new Exception("Título é um campo obrigatório");
                 if (txtSerie.Text != "")
                     objCAP.cp_serie = txtSerie.Text;
                 else
                     throw new Exception("Série é um campo obrigatório");
                if(txtDataEmissao.Text!="  /  /")                    
                    objCAP.cp_emissao = DateTime.Parse(txtDataEmissao.Text);
                else
                    throw new Exception("Date de emissão é um campo obrigatório");
                if (txtDataValidade.Text != "  /  /")
                    objCAP.cp_vencimento = DateTime.Parse(txtDataValidade.Text);
                else
                    throw new Exception("Date de vencimento é um campo obrigatório");

                String x = "";
                for (int i = 0; i <= txtValor.Text.Length - 1; i++)
                {
                    if ((txtValor.Text[i] >= '0' &&
                    txtValor.Text[i] <= '9') ||
                    txtValor.Text[i] == ',')
                    {
                        x += txtValor.Text[i];
                    }
                }
                txtValor.Text = x;

                if (txtValor.Text != "")
                    objCAP.cp_valor = decimal.Parse(txtValor.Text);
                else
                    throw new Exception("Valor é um campo obrigatório");
                if (cbSituacao.SelectedIndex == -1)
                    throw new Exception("Por favor, selecione a situação da conta");
                else
                    objCAP.cp_status = cbSituacao.SelectedItem.ToString();
                if (objCAP.cp_status == "Aberto")
                    objCAP.cp_dataPagamento = null;
                else
                    objCAP.cp_dataPagamento = DateTime.Now.Date;
                txtObservacoes.Text = txtObservacoes.Text.Trim();
                objCAP.cp_observacao = txtObservacoes.Text;
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
                txtCodigo.Text = objCAP.cp_codigo.ToString();
                if (objCAP.cp_compras == 0)
                    txtCompra.Text = "";
                else
                    txtCompra.Text = objCAP.cp_compras.ToString();

                cbSituacao.SelectedItem = objCAP.cp_status;

                FornecedoresBLL objFor = new FornecedoresBLL();
                objFor.localizar(objCAP.cp_fornecedor.ToString(), "for_codigo");
                if (objFor.for_tipo == "Não")
                    cbPrestServ.Checked = false;
                else
                    cbPrestServ.Checked = true;

                cbFornPresServ.SelectedValue = objCAP.cp_fornecedor;

                txtDataEmissao.Text = objCAP.cp_emissao.ToString();
                txtDataValidade.Text = objCAP.cp_vencimento.ToString();
                txtObservacoes.Text = objCAP.cp_observacao;
                txtTitulo.Text = objCAP.cp_titulo;
                txtSerie.Text = objCAP.cp_serie;
                txtValor.Text = objCAP.cp_valor.ToString();
                txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("C");
                
                //if (objFor.for_tipo_fornecedor == "Pessoa Jurídica")
                //    cbPessoaJuridica.Checked = true;
                //else
                //    cbPessoaJuridica.Checked = false;

               

                //cbPessoaJuridica.Enabled = false;
                cbPrestServ.Enabled = false;
                cbFornPresServ.Enabled = false;
                txtCompra.Enabled = false;

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
                tab = objCAP.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns["cp_codigo"].HeaderText = "Código";
                gvPesquisa.Columns["cp_compras"].HeaderText = "Compra";
                gvPesquisa.Columns["com_numPedido"].HeaderText = "Pedido";
                gvPesquisa.Columns["cp_titulo"].HeaderText = "Título";
                gvPesquisa.Columns["cp_serie"].HeaderText = "Série";
                gvPesquisa.Columns["cp_emissao"].HeaderText = "Data de Emissão";
                gvPesquisa.Columns["cp_vencimento"].HeaderText = "Data de Vencimento";
                gvPesquisa.Columns["cp_valor"].HeaderText = "Valor";
                gvPesquisa.Columns["cp_status"].HeaderText = "Status";
                gvPesquisa.Columns["cp_observacao"].HeaderText = "observação";
                gvPesquisa.Columns["cp_dataPagamento"].HeaderText = "Data do Pagamento";
                gvPesquisa.Columns["cp_fornecedor"].Visible = false;
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

        private void ContasAPagar_Load(object sender, EventArgs e)
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cboTpo, "TipoDeOperacao", "ID", "Nome", "Sinal = 'D'", "Nome");
                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
                carregaCombo();
                limpar();
                TabControl1.SelectedIndex = 0;
                gvPesquisa.AutoSizeColumnsMode =
               DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btExcluir_Click_1(object sender, EventArgs e)
        {
          
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
                        objCAP.cp_codigo = cod;
                        objCAP.localizar(objCAP.cp_codigo.ToString(), "cp_codigo");
                        txtCodigo.Text = objCAP.cp_codigo.ToString();
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
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objCAP.limpar();
                    objCAP.localizarLeave(cod.ToString(), "cp_codigo");
                    if (objCAP.cp_codigo != 0)
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

        private void txtCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCompra.Text, out cod);
                if (cod != 0)
                {
                    objCAP.limpar();
                    objCAP.localizarLeave(cod.ToString(), "cp_compras");
                    //if (objCAP.cp_codigo != 0)
                    //{
                    //    carregaCampos();
                    //    txtCodigo.Enabled = false;
                    //}
                    //else //não há registros em contas a pagar, mas pode ter uma compra
                    //{
                        objCom = new ComprasBLL();//
                        objCom.localizar(cod.ToString(), "com_codigo");
                        if (objCom.com_codigo != 0)
                        {
                            FornecedoresBLL objFor = new FornecedoresBLL();
                            objFor.localizar(objCom.com_fornecedor.ToString(), "for_codigo");
                            if (objFor.for_tipo == "Não")
                                cbPrestServ.Checked = false;
                            else
                                cbPrestServ.Checked = true;
                            //if (objFor.for_tipo_fornecedor == "Pessoa Jurídica")
                            //    cbPessoaJuridica.Checked = true;
                            //else
                            //    cbPessoaJuridica.Checked = false;
                            cbFornPresServ.SelectedValue = objFor.for_codigo;
                            //cbPessoaJuridica.Enabled = false;
                            cbPrestServ.Enabled = false;
                            cbFornPresServ.Enabled = false;
                        //}
                    }
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
                    objCAP.limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    btAnterior.Enabled = false;
                    btPrimeiro.Enabled = false;
                    btProximo.Enabled = false;
                    btUltimo.Enabled = false;
                    btSalvar.Enabled = false;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objCAP.limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    btAnterior.Enabled = true;
                    btPrimeiro.Enabled = true;
                    btProximo.Enabled = true;
                    btUltimo.Enabled = true;
                    btSalvar.Enabled = true;
                    groupBox1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btPrimeiro_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btUltimo_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btAnterior_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btProximo_Click_1(object sender, EventArgs e)
        {
            
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
                    objCAP.localizar(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "cp_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void cbForPresServ_CheckedChanged(object sender, EventArgs e)
        {
            carregaCombo();
        }

        public void carregaCombo()
        {
            try
            {
                cbFornPresServ.SelectedIndex = -1;
                Contexto objDAL = new Contexto();
                if (cbPrestServ.Checked)
                    objDAL.PreencheComboBoxFornecedores(cbFornPresServ, "Fornecedores", "for_codigo", "Fornecedores", "for_tipo='Sim'", "Fornecedores");
                else if(!cbPrestServ.Checked)
                    objDAL.PreencheComboBoxFornecedores(cbFornPresServ, "Fornecedores", "for_codigo", "Fornecedores", "for_tipo='Não'", "Fornecedores");
                //else if (cbPrestServ.Checked && !cbPessoaJuridica.Checked)
                //    objDAL.preencheComboBox(cbFornPresServ, "Fornecedores", "for_codigo", "for_nome", "for_tipo='Sim' and for_tipo_fornecedor='Pessoa Física'", "for_nome");
                //else if (!cbPrestServ.Checked && cbPessoaJuridica.Checked)
                //    objDAL.preencheComboBox(cbFornPresServ, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo='Não' and for_tipo_fornecedor='Pessoa Jurídica'", "for_razaoSocial");
                objDAL = null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void cbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            carregaCombo();
        }

        private void txtValor_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValor.Text.Length - 1; i++)
                {
                    if ((txtValor.Text[i] >= '0' &&
                    txtValor.Text[i] <= '9') ||
                    txtValor.Text[i] == ',')
                    {
                        x += txtValor.Text[i];
                    }
                }
                txtValor.Text = x;
                txtValor.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtValor.Text.Contains(','))
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

        private void txtValor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtValor.Text != "")
                    txtValor.Text = Convert.ToDecimal(txtValor.Text).ToString("C");
            }
            catch (Exception)
            {
                txtValor.Text = "";
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            } 
        }

        private void txtNumPedido_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar pedido
                int cod;
                int.TryParse(txtNumPedido.Text, out cod);
                if (cod != 0)
                {
                    ComprasBLL objBLL = new ComprasBLL();

                    objCAP.limpar();
                    objBLL.localizarLeave(cod.ToString(), "com_numPedido");
                    if (objBLL.com_codigo != 0)
                    {
                        objCAP.localizarLeave(objBLL.com_codigo.ToString(), "cp_codigo");
                        if (objCAP.cp_codigo != 0)
                        {
                            carregaCampos();
                            txtCodigo.Enabled = false;
                        }
                       
                    }
                    objBLL = null;
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

                if (objCAP.cp_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                {
                    objCAP.inserir();
                    objCAP.limpar();
                    limpar();
                   if(cbSituacao.SelectedIndex ==1)
                    Lan.Inserir(txtDataEmissao.Value, int.Parse(cboTpo.SelectedValue.ToString()), cboTpo.Text, "D", decimal.Parse(txtValor.Text.ToString()), int.Parse(txtCodigo.Text.ToString()));
                    MessageBox.Show("Conta a pagar incluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else //Alteração
                {
                    objCAP.alterar();
                    objCAP.limpar();
                    limpar();
                    if (cbSituacao.SelectedIndex == 1)
                    Lan.Inserir(txtDataEmissao.Value, int.Parse(cboTpo.SelectedValue.ToString()), cboTpo.Text, "D", decimal.Parse(txtValor.Text.ToString()), int.Parse(txtCodigo.Text.ToString()));
                    MessageBox.Show("Conta a pagar alterada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
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
                objCAP.limpar();
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
                if (objCAP.cp_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objCAP.excluir();
                        objCAP.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Conta a pagar excluída com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma conta a pagar na aba 'Pesquisar', ou escolher um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objCAP.localizarPrimeiroUltimo("primeiro");
                if (objCAP.cp_codigo != 0)
                {
                    objCAP.localizar(objCAP.cp_codigo.ToString(), "cp_codigo");
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
                    objCAP.localizarProxAnterior("anterior", 0);
                else
                    objCAP.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objCAP.cp_codigo != 0)
                {
                    objCAP.localizar(objCAP.cp_codigo.ToString(), "cp_codigo");
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
                    objCAP.localizarProxAnterior("proximo", 0);
                else
                    objCAP.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objCAP.cp_codigo != 0)
                {
                    objCAP.localizar(objCAP.cp_codigo.ToString(), "cp_codigo");
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
                objCAP.localizarPrimeiroUltimo("ultimo");
                if (objCAP.cp_codigo != 0)
                {
                    objCAP.localizar(objCAP.cp_codigo.ToString(), "cp_codigo");
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
           printDGV.Print_DataGridView(gvPesquisa);


        }

        private void gvPesquisa_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            /* Pegando valor de uma celula do DataGridView */
            String valor = dgv.Rows[e.RowIndex].Cells[7].Value.ToString();
            if (valor == "Pago")
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
            }
            else
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cboFornecedor.SelectedIndex > -1)
                {
                    codigo = cboFornecedor.SelectedValue.ToString();
                }
                else
                {
                    codigo = "0";
                }

                DataTable tab = null;
                dataInicial = txtDtInicial.Value;
                dataFinal = txtDtFinal.Value;

                tab = tab = objCAP.localizarComFiltro(int.Parse(codigo), dataInicial, dataFinal);
                gvPesquisa.DataSource = tab;
                //if (tab.Rows.Count > 0)
                //{
                //    pictureBox1.Visible = true;
                //    btnver.Visible = true;
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCliente_MouseClick(object sender, MouseEventArgs e)
        {
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboFornecedor, "Fornecedores", "for_codigo", "for_nome", "", "");
            objD = null;
            cboFornecedor.SelectedIndex = -1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }        
    }
}
