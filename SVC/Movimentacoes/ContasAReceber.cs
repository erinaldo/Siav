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
using ImprimeCupom;
using View;
using LFi.Control.Laçanmento_Financeiro;
using System.Data.SqlClient;
namespace One.MOVIMENTACOES
{
    public partial class frmContasAReceber : Form
    {
        public frmContasAReceber()
        {
            InitializeComponent();
        }
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public string codigo = "";
        public int CodigoCliente = 0;


        ContasAReceberBLL objCR = new ContasAReceberBLL();
        ContasAReceberDAL dal = new ContasAReceberDAL();

        public void calculaValor()
        {
            try
            {
                Decimal valorAlterado = 0, valorOriginal, juros = 0, desconto = 0, totalPago = 0, multa = 0;

                String x = "";
                for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                {
                    if ((txtValorOriginal.Text[i] >= '0' &&
                    txtValorOriginal.Text[i] <= '9') ||
                    txtValorOriginal.Text[i] == ',')
                    {
                        x += txtValorOriginal.Text[i];
                    }
                }
                valorOriginal = Decimal.Parse(x);

                if (txtJuros.Text != "")
                    juros = Decimal.Parse(txtJuros.Text);

                if (txtDesconto.Text != "")
                {
                    x = "";
                    for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
                    {
                        if ((txtDesconto.Text[i] >= '0' &&
                        txtDesconto.Text[i] <= '9') ||
                        txtDesconto.Text[i] == ',')
                        {
                            x += txtDesconto.Text[i];
                        }
                    }
                    desconto = Decimal.Parse(x);
                }

                if (txtTotalPago.Text != "")
                {
                    x = "";
                    for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
                    {
                        if ((txtTotalPago.Text[i] >= '0' &&
                        txtTotalPago.Text[i] <= '9') ||
                        txtTotalPago.Text[i] == ',')
                        {
                            x += txtTotalPago.Text[i];
                        }
                    }
                    totalPago = Decimal.Parse(x);
                }

                x = "";
                for (int i = 0; i <= txtMulta.Text.Length - 1; i++)
                {
                    if ((txtMulta.Text[i] >= '0' &&
                    txtMulta.Text[i] <= '9') ||
                    txtMulta.Text[i] == ',')
                    {
                        x += txtMulta.Text[i];
                    }
                }
                if (x != "")
                    multa = Decimal.Parse(x);
                else
                    multa = 0;

                if (txtValorAlterado.Text != "")
                {
                    x = "";
                    for (int i = 0; i <= txtValorAlterado.Text.Length - 1; i++)
                    {
                        if ((txtValorAlterado.Text[i] >= '0' &&
                        txtValorAlterado.Text[i] <= '9') ||
                        txtValorAlterado.Text[i] == ',')
                        {
                            x += txtValorAlterado.Text[i];
                        }
                    }
                    valorAlterado = Decimal.Parse(x);
                }

                if (juros > 0)
                    valorAlterado = (objCR.alterado) + (objCR.alterado) * (juros / 100);//(valorAlterado) + (valorAlterado) * (juros / 100);
                else
                    valorAlterado = objCR.alterado;

                if (multa != 0)
                    valorAlterado += multa;


                if (desconto != 0)
                    valorAlterado -= desconto;

                txtValorAlterado.Text = valorAlterado.ToString();


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
                tab = objCR.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                gvPesquisa.Columns[1].ReadOnly = true;
                gvPesquisa.Columns[2].ReadOnly = true;
                gvPesquisa.Columns[3].ReadOnly = true;
                gvPesquisa.Columns[4].ReadOnly = true;
                gvPesquisa.Columns[5].ReadOnly = true;
                gvPesquisa.Columns[6].ReadOnly = true;
                gvPesquisa.Columns[7].ReadOnly = false;
                gvPesquisa.Columns[8].ReadOnly = false;
                gvPesquisa.Columns[9].ReadOnly = false;
                gvPesquisa.Columns[10].ReadOnly = true;

                gvPesquisa.Columns["Forma Pagamento"].Visible = false;

                // stiloGrid();
                gvPesquisa.ClearSelection();
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
                objCR.limpar();
                //objVI.limpar();
            }
        }


        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtCodParcela.Text = "";
                txtDataPagamento.Text = DateTime.Now.ToString();
                txtDataVencimento.Text = "";
                txtDesconto.Text = "";
                txtJuros.Text = "";
                txtObservacao.Text = "";
                txtParcela.Text = "";
                txtPesquisar.Text = "";
                txtValorAlterado.Text = "";
                txtValorOriginal.Text = "";
                txtTotalPago.Text = "";
                txtValorRecebido.Text = "";
                gvPesquisa.DataSource = null;
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
                String x = "";
                for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                {
                    if ((txtValorOriginal.Text[i] >= '0' &&
                    txtValorOriginal.Text[i] <= '9') ||
                    txtValorOriginal.Text[i] == ',')
                    {
                        x += txtValorOriginal.Text[i];
                    }
                }
                txtValorOriginal.Text = x;

                x = "";
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


                x = "";
                for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
                {
                    if ((txtDesconto.Text[i] >= '0' &&
                    txtDesconto.Text[i] <= '9') ||
                    txtDesconto.Text[i] == ',')
                    {
                        x += txtDesconto.Text[i];
                    }
                }
                txtDesconto.Text = x;

                x = "";
                for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
                {
                    if ((txtTotalPago.Text[i] >= '0' &&
                    txtTotalPago.Text[i] <= '9') ||
                    txtTotalPago.Text[i] == ',')
                    {
                        x += txtTotalPago.Text[i];
                    }
                }
                txtTotalPago.Text = x;

                x = "";
                for (int i = 0; i <= txtValorRecebido.Text.Length - 1; i++)
                {
                    if ((txtValorRecebido.Text[i] >= '0' &&
                    txtValorRecebido.Text[i] <= '9') ||
                    txtValorRecebido.Text[i] == ',')
                    {
                        x += txtValorRecebido.Text[i];
                    }
                }
                txtValorRecebido.Text = x;

                if (txtCodigo.Text != "")
                    objCR.vendas = int.Parse(txtCodigo.Text);
                else
                    throw new Exception("Por favor especifique uma venda antes de quitar uma parcela");

                if (txtCodParcela.Text != "")
                    objCR.codigo = int.Parse(txtCodParcela.Text);
                else
                    throw new Exception("Não há parcelas a serem quitadas para esta venda");

                if (txtDataVencimento.Text != "  /  /       :")
                    objCR.vencimento = DateTime.Parse(txtDataVencimento.Text);
                else
                    throw new Exception("Data de Vencimento Inválida");

                if (txtDataPagamento.Text != "  /  /       :")
                    objCR.pagamento = DateTime.Parse(txtDataPagamento.Text);
                else
                    throw new Exception("Data de Pagamento Inválida");
                objCR.parcela = txtParcela.Text;

                objCR.original = Decimal.Parse(txtValorOriginal.Text);
                if (txtJuros.Text != "")
                    objCR.juros = Decimal.Parse(txtJuros.Text);
                else
                    objCR.juros = 0;
                if (txtDesconto.Text != "")
                    objCR.desconto = Decimal.Parse(txtDesconto.Text);
                else
                    objCR.desconto = 0;

                if (txtMulta.Text != "")
                    objCR.cr_multa = Decimal.Parse(txtMulta.Text);
                else
                    objCR.cr_multa = 0;

                x = "";
                for (int i = 0; i <= txtValorAlterado.Text.Length - 1; i++)
                {
                    if ((txtValorAlterado.Text[i] >= '0' &&
                    txtValorAlterado.Text[i] <= '9') ||
                    txtValorAlterado.Text[i] == ',')
                    {
                        x += txtValorAlterado.Text[i];
                    }
                }
                txtValorAlterado.Text = x;

                if (txtValorRecebido.Text == "")
                    throw new Exception("Por favor, informe o valor recebido pelo cliente");

                objCR.alterado = Decimal.Parse(txtValorAlterado.Text) - Decimal.Parse(txtValorRecebido.Text); //Valor restante a ser pago
                if (txtTotalPago.Text == "")
                    throw new Exception("Favor, informe o valor pago pelo cliente");
                if (txtValorRecebido.Text != "")
                    objCR.pago += Decimal.Parse(txtValorRecebido.Text);

                if (Decimal.Parse(txtValorAlterado.Text) - Decimal.Parse(txtValorRecebido.Text) == 0)
                    objCR.status = "Pago";
                else
                    objCR.status = "Aberto";
                //if (objCR.cr_valorRestante == 0)
                //{
                //    if (objCR.pago >= objCR.original)
                //        objCR.status = "Pago";
                //    else
                //        objCR.status = "Aberto";

                //    objCR.cr_valorRestante = objCR.alterado - Decimal.Parse(txtValorRecebido.Text);
                //}
                //else
                //{
                //    objCR.cr_valorRestante += objCR.alterado - Decimal.Parse(txtValorRecebido.Text);
                //    if (objCR.pago >= objCR.cr_valorRestante)
                //        objCR.status = "Pago";
                //    else
                //        objCR.status = "Aberto";
                //}


                objCR.observacao = txtObservacao.Text;
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
                EmpresaBLL objEmp = new EmpresaBLL();
                objEmp.localizar("1", "emp_codigo");

                txtCodigo.Text = objCR.vendas.ToString();
                txtCodParcela.Text = objCR.codigo.ToString();
                txtDataVencimento.Text = objCR.vencimento.ToString();
                txtDataPagamento.Text = DateTime.Now.ToString();
                txtParcela.Text = objCR.parcela;

                //if(objCR.desconto != 0.0)
                //txtDesconto.Text = "0";//objCR.desconto.ToString();
                //if (txtDesconto.Text != "" )//&& txtDesconto.Text != "0")
                //txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("C");

                txtTotalPago.Text = objCR.pago.ToString();
                if (txtTotalPago.Text != "")
                    txtTotalPago.Text = Convert.ToDecimal(txtTotalPago.Text).ToString("C");

                txtValorOriginal.Text = objCR.original.ToString();
                if (txtValorOriginal.Text != "")
                    txtValorOriginal.Text = Convert.ToDecimal(txtValorOriginal.Text).ToString("C");

                if (DateTime.Now.Date > (objCR.vencimento.Date.AddDays(objEmp.emp_qtdDias)) && objCR.pago == 0) //Adicionar jurosJuros 
                {
                    //localizar se deve ser cobrado juros do cliente
                    VendasBLL objVen = new VendasBLL();
                    ClienteBLL objCli = new ClienteBLL();
                    objVen.localizar(objCR.vendas.ToString(), "ven_codigo");
                    objCli.Localizar(objVen.cliente.ToString(), "cli_codigo");

                    if (objCli.cli_calJuros == "Sim")
                    {
                        objCR.juros = objEmp.emp_valorJuros; //Número personalizado pelo cliente
                        txtJuros.Text = objCR.juros.ToString();
                        objCR.cr_multa = objEmp.emp_multa; //Número personalizado pelo cliente
                        txtMulta.Text = objCR.cr_multa.ToString();
                        txtMulta.Text = Convert.ToDecimal(txtMulta.Text).ToString("C");
                    }
                    else
                    {
                        objCR.juros = 0; //Número personalizado pelo cliente
                        txtJuros.Text = objCR.juros.ToString();
                        objCR.cr_multa = objEmp.emp_multa; //Número personalizado pelo cliente
                        txtMulta.Text = objCR.cr_multa.ToString();
                        txtMulta.Text = Convert.ToDecimal(txtMulta.Text).ToString("C");
                    }
                    objVen = null;
                    objCli = null;
                }
                else
                {
                    //if (objCR.juros != 0)
                    //txtJuros.Text = objCR.juros.ToString();
                    //else
                    txtJuros.Text = "0";
                    txtMulta.Text = "0";
                }
                //if (objCR.cr_valorRestante != null && objCR.cr_valorRestante != 0)
                //    txtValorTotalParcela.Text = objCR.cr_valorRestante.ToString();
                //else
                //    txtValorTotalParcela.Text = "";

                txtValorAlterado.Text = objCR.alterado.ToString();

                calculaValor();

                //if (txtValorTotalParcela.Text != "")
                //    txtValorTotalParcela.Text = Convert.ToDecimal(txtValorTotalParcela.Text).ToString("C");

                //txtValorAlterado.Text = (objCR.original - objCR.pago).ToString();
                if (txtValorAlterado.Text != "")
                    txtValorAlterado.Text = Convert.ToDecimal(txtValorAlterado.Text).ToString("C");
                objEmp = null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void carregaCombo()
        {
            try
            {
                cboCliente.SelectedIndex = -1;
                Contexto objDAL = new Contexto();
                //ComboBox cb, String nometabela, String campocodigo, String descricao, String filtro, String ordem)
                objDAL.PreencheComboBoxCliente(cboCliente, "Cliente", "cli_codigo", "Cliente", "cli_tipo_pessoa = 'Pessoa Física'", "Cliente");

                objDAL = null;
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

        private void ContasAReceber_Load(object sender, EventArgs e)
        {
            try
            {
                limpar();
                carregaCombo();
                TabControl1.SelectedIndex = 1;
                gvPesquisa.AutoSizeColumnsMode =
                  DataGridViewAutoSizeColumnsMode.AllCells;
                // this.MinimumSize = new Size(this.Width, this.Height);
                cboCliente.SelectedValue = CodigoCliente;
                LocalizarPagamentoContasReceber();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
            {
                if ((txtTotalPago.Text[i] >= '0' &&
                txtTotalPago.Text[i] <= '9') ||
                txtTotalPago.Text[i] == ',')
                {
                    x += txtTotalPago.Text[i];
                }
            }
            txtTotalPago.Text = x;
            txtTotalPago.SelectAll();
        }

        private void txtValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //keypress
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
                        if (!txtTotalPago.Text.Contains(','))
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

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            if (txtTotalPago.Text != "")
                txtTotalPago.Text = Convert.ToDecimal(txtTotalPago.Text).ToString("C");
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
            {
                if ((txtDesconto.Text[i] >= '0' &&
                txtDesconto.Text[i] <= '9') ||
                txtDesconto.Text[i] == ',')
                {
                    x += txtDesconto.Text[i];
                }
            }
            txtDesconto.Text = x;
            txtDesconto.SelectAll();
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //keypress
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
                        if (!txtDesconto.Text.Contains(','))
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

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if (txtDesconto.Text != "")
                txtDesconto.Text = Convert.ToDecimal(txtDesconto.Text).ToString("C");
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtValorOriginal_Leave(object sender, EventArgs e)
        {
            if (txtValorOriginal.Text != "")
            {
                String x = "";
                for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                {
                    if ((txtValorOriginal.Text[i] >= '0' &&
                    txtValorOriginal.Text[i] <= '9') ||
                    txtValorOriginal.Text[i] == ',')
                    {
                        x += txtValorOriginal.Text[i];
                    }
                }
                txtValorOriginal.Text = x;
                txtValorOriginal.Text = Convert.ToDecimal(txtValorOriginal.Text).ToString("C");
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //keypress
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
        public void CalcularValorTotalGrid()
        {
            decimal valorTotal = 0;
            foreach (DataGridViewRow col in gvPesquisa.Rows)
            {
                valorTotal = valorTotal + Convert.ToDecimal(col.Cells[6].Value);
            }

            txtValorTotal.Text = Convert.ToString(valorTotal);

        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                carregaGrid();
                CalcularValorTotalGrid();
                //Obtendo o Valor Total do COntas a Receber



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
                        objCR.codigo = cod;
                        objCR.localizar(objCR.codigo.ToString(), "cr_codigo");
                        txtCodigo.Text = objCR.codigo.ToString();
                        txtValorRecebido.Text = objCR.original.ToString("C");
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

        private void txtValorAlterado_Leave(object sender, EventArgs e)
        {
            if (txtValorAlterado.Text != "")
            {
                String x = "";
                for (int i = 0; i <= txtValorAlterado.Text.Length - 1; i++)
                {
                    if ((txtValorAlterado.Text[i] >= '0' &&
                    txtValorAlterado.Text[i] <= '9') ||
                    txtValorAlterado.Text[i] == ',')
                    {
                        x += txtValorAlterado.Text[i];
                    }
                }
                txtValorAlterado.Text = x;
                txtValorAlterado.Text = Convert.ToDecimal(txtValorAlterado.Text).ToString("C");
            }
        }

        private void txtJuros_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Decimal valorAlterado, valorOriginal, juros=0, desconto=0, totalPago=0;

                //String x = "";
                //for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                //{
                //    if ((txtValorOriginal.Text[i] >= '0' &&
                //    txtValorOriginal.Text[i] <= '9') ||
                //    txtValorOriginal.Text[i] == ',')
                //    {
                //        x += txtValorOriginal.Text[i];
                //    }
                //}
                //valorOriginal = Decimal.Parse(x);

                //if(txtJuros.Text !="")
                //    juros = Decimal.Parse(txtJuros.Text);

                //if (txtDesconto.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
                //    {
                //        if ((txtDesconto.Text[i] >= '0' &&
                //        txtDesconto.Text[i] <= '9') ||
                //        txtDesconto.Text[i] == ',')
                //        {
                //            x += txtDesconto.Text[i];
                //        }
                //    }
                //    desconto = Decimal.Parse(x);
                //}

                //if (txtTotalPago.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
                //    {
                //        if ((txtTotalPago.Text[i] >= '0' &&
                //        txtTotalPago.Text[i] <= '9') ||
                //        txtTotalPago.Text[i] == ',')
                //        {
                //            x += txtTotalPago.Text[i];
                //        }
                //    }
                //    totalPago = Decimal.Parse(x);
                //}


                //if (juros > 0)
                //    valorAlterado = (valorOriginal - totalPago) + (valorOriginal - totalPago)* (juros / 100);
                //else
                //    valorAlterado = valorOriginal - totalPago;

                //if (desconto != 0)
                //    valorAlterado -= desconto;

                //txtValorAlterado.Text = valorAlterado.ToString();
                calculaValor();
                txtValorAlterado_Leave(sender, e);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Decimal valorAlterado, valorOriginal, juros=0, desconto = 0, totalPago=0;

                //String x = "";
                //for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                //{
                //    if ((txtValorOriginal.Text[i] >= '0' &&
                //    txtValorOriginal.Text[i] <= '9') ||
                //    txtValorOriginal.Text[i] == ',')
                //    {
                //        x += txtValorOriginal.Text[i];
                //    }
                //}
                //valorOriginal = Decimal.Parse(x);

                //if(txtJuros.Text != "")
                //    juros = Decimal.Parse(txtJuros.Text);

                //if (txtDesconto.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
                //    {
                //        if ((txtDesconto.Text[i] >= '0' &&
                //        txtDesconto.Text[i] <= '9') ||
                //        txtDesconto.Text[i] == ',')
                //        {
                //            x += txtDesconto.Text[i];
                //        }
                //    }
                //    desconto = Decimal.Parse(x);
                //}

                //if (txtTotalPago.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
                //    {
                //        if ((txtTotalPago.Text[i] >= '0' &&
                //        txtTotalPago.Text[i] <= '9') ||
                //        txtTotalPago.Text[i] == ',')
                //        {
                //            x += txtTotalPago.Text[i];
                //        }
                //    }
                //    totalPago = Decimal.Parse(x);
                //}


                //if (juros > 0)
                //    valorAlterado = (valorOriginal - totalPago) + (valorOriginal - totalPago) * (juros / 100);
                //else
                //    valorAlterado = valorOriginal - totalPago;

                //if (desconto != 0)
                //    valorAlterado -= desconto;

                //txtValorAlterado.Text = valorAlterado.ToString();
                calculaValor();
                txtValorAlterado_Leave(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gvPesquisa_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtValorRecebido_Enter(object sender, EventArgs e)
        {
            String x = "";
            for (int i = 0; i <= txtValorRecebido.Text.Length - 1; i++)
            {
                if ((txtValorRecebido.Text[i] >= '0' &&
                 txtValorRecebido.Text[i] <= '9') ||
                 txtValorRecebido.Text[i] == ',')
                {
                    x += txtValorRecebido.Text[i];
                }
            }
            txtValorRecebido.Text = x;
            txtValorRecebido.SelectAll();
        }

        private void txtValorRecebido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                //keypress
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
                        if (!txtValorRecebido.Text.Contains(','))
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

        private void txtValorRecebido_Leave_1(object sender, EventArgs e)
        {
            if (txtValorRecebido.Text != "")
                txtValorRecebido.Text = Convert.ToDecimal(txtValorRecebido.Text).ToString("C");
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objCR.limpar();
                    limpar();
                    //carregaGrid();
                    LocalizarPagamentoContasReceber();
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox2.Visible = false;
                    lblRecTudo.Visible = true;
                    btnRecTudo.Visible = true;

                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objCR.limpar();
                    limpar();
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    groupBox2.Visible = true;
                    lblRecTudo.Visible = false;
                    btnRecTudo.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJuros_Leave(object sender, EventArgs e)
        {
            //calculaValor();
            //txtValorAlterado_Leave(sender, e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
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

        private void txtMulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //keypress
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

        private void txtMulta_Leave(object sender, EventArgs e)
        {
            if (txtMulta.Text != "")
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

                txtMulta.Text = Convert.ToDecimal(txtMulta.Text).ToString("C");
            }
        }

        private void txtMulta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Decimal valorAlterado, valorOriginal, juros=0, desconto = 0, totalPago=0;

                //String x = "";
                //for (int i = 0; i <= txtValorOriginal.Text.Length - 1; i++)
                //{
                //    if ((txtValorOriginal.Text[i] >= '0' &&
                //    txtValorOriginal.Text[i] <= '9') ||
                //    txtValorOriginal.Text[i] == ',')
                //    {
                //        x += txtValorOriginal.Text[i];
                //    }
                //}
                //valorOriginal = Decimal.Parse(x);

                //if(txtJuros.Text != "")
                //    juros = Decimal.Parse(txtJuros.Text);

                //if (txtDesconto.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtDesconto.Text.Length - 1; i++)
                //    {
                //        if ((txtDesconto.Text[i] >= '0' &&
                //        txtDesconto.Text[i] <= '9') ||
                //        txtDesconto.Text[i] == ',')
                //        {
                //            x += txtDesconto.Text[i];
                //        }
                //    }
                //    desconto = Decimal.Parse(x);
                //}

                //if (txtTotalPago.Text != "")
                //{
                //    x = "";
                //    for (int i = 0; i <= txtTotalPago.Text.Length - 1; i++)
                //    {
                //        if ((txtTotalPago.Text[i] >= '0' &&
                //        txtTotalPago.Text[i] <= '9') ||
                //        txtTotalPago.Text[i] == ',')
                //        {
                //            x += txtTotalPago.Text[i];
                //        }
                //    }
                //    totalPago = Decimal.Parse(x);
                //}


                //if (juros > 0)
                //    valorAlterado = (valorOriginal - totalPago) + (valorOriginal - totalPago) * (juros / 100);
                //else
                //    valorAlterado = valorOriginal - totalPago;

                //if (desconto != 0)
                //    valorAlterado -= desconto;

                //txtValorAlterado.Text = valorAlterado.ToString();
                calculaValor();
                txtValorAlterado_Leave(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Lancamento Lan = new Lancamento();
                //Carregar os campos no objeto
                carregaPropriedades();

                if (Decimal.Parse(txtValorRecebido.Text) > Decimal.Parse(txtValorAlterado.Text))
                {
                    throw new Exception("Não é possível receber mais do que é devido pelo cliente");
                }

                objCR.alterar();

                //Gravar Recebimentos(R$) Diários
                PagamentoDiaBLL objPD = new PagamentoDiaBLL();
                objPD.cr_codigo = objCR.codigo;
                objPD.pd_valor = objCR.pago;
                objPD.pd_data = DateTime.Now.Date;
                objPD.inserir();
                Lan.Inserir(objPD.pd_data, 1, "Recebimento de Títulos", "C", objCR.pago, objCR.codigo);
                objPD = null;

                #region Imprimir cupom de pagamento

                //if (MessageBox.Show("Deseja Imprimir o recido da parcela paga?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                //{

                //    String impressora = "LPT";
                //    int tentativa = 0;
                //    int COM = 0;
                //loop:
                //    ImprimeTexto imp = new ImprimeTexto();
                //    if (tentativa == 3)
                //    {
                //        COM++;
                //        impressora = "COM";
                //        imp.Inicio(impressora + tentativa.ToString());
                //    }
                //    else
                //    {
                //        tentativa++;
                //        imp.Inicio(impressora + tentativa.ToString());
                //    }

                //    imp.ImpLF("Código da Venda: " + objCR.vendas);
                //    imp.ImpLF("Data: " + DateTime.Now.ToString());
                //    imp.ImpLF("Parcela: " + objCR.parcela);
                //    imp.ImpLF("Valor Pago: " + objCR.pago.ToString());
                //    imp.Pula(10);
                //    if (!imp.Fim())
                //    {
                //        //if (tentativa < 3)
                //        //{
                //        //    imp = null;
                //        //    goto loop;
                //        //}
                //        if (COM < 5)
                //        {
                //            imp = null;
                //            goto loop;
                //        }
                //        else
                //        {
                //            if (MessageBox.Show("Nenhuma impressora foi localizada. Deseja tentar novamente?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                //                goto loop;
                //            else
                //            {
                //                objCR.limpar();
                //                limpar();
                //                imp = null;
                //                MessageBox.Show("Parcela salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //                throw new Exception("Mas impressora não foi reconhecida");
                //            }
                //        }
                //    }
                //    imp = null;
                //}

                //if (objCR.pago > objCR.alterado)
                //{
                //    /* Localizar a próxima conta a ser paga e descontar caso o 
                //        * dinheiro pago seja maior que o valor da parcela, para isso é necessário
                //        * verificar se a próxima parcela possui juros a serem acrescidos ou descontos */
                //}

                #endregion

                objCR.limpar();
                limpar();

                MessageBox.Show("Parcela salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                objCR.limpar();
                limpar();
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

        private void txtCodigoCr_TextChanged(object sender, EventArgs e)
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

        private void txtVenda_TextChanged(object sender, EventArgs e)
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

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {

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

            LocalizarPagamentoContasReceber();
        }

        private void LocalizarPagamentoContasReceber()
        {
            try
            {
                if (cboCliente.SelectedIndex > -1)
                {
                    codigo = cboCliente.SelectedValue.ToString();
                }
                else
                {
                    codigo = "0";
                }
                string pago = "";
                if (ckPago.Checked == true)
                {
                    pago = "Pago";
                }
                else
                {
                    pago = "Aberto";
                }
                DataTable tab = null;
                dataInicial = txtDtInicial.Value;
                dataFinal = txtDtFinal.Value;
                tab = tab = dal.localizarEmTudoFiltro(int.Parse(codigo), dataInicial, dataFinal, pago);
                gvPesquisa.DataSource = tab;
                CalcularValorTotalGrid();
                //if (tab.Rows.Count > 0)
                //{
                //    pictureBox1.Visible = true;
                //    btnver.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente baixar todos os pagamentos do  Sr(a) " + cboCliente.Text + " ?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (cboCliente.SelectedIndex > -1)
                    {
                        codigo = cboCliente.SelectedValue.ToString();
                    }
                    else
                    {
                        codigo = "0";
                    }
                    dal.RecebimentoTitulosContasAReceber(int.Parse(codigo));
                    LocalizarPagamentoContasReceber();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }

        }
        public void AdicionarDinheioCaixa(decimal valor, string motivo)
        {
            SqlCommand cmd = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                   "INSERT INTO  MovimentoCaixa ",
                       "(   Data",
                       ",   Usuario",
                       ",   NumeroCaixa",
                       ",   TipoMovimento",
                       ",   ValorMovimento",
                       ",   Motivo",
                       ",  IDAber",
                       "  )",
                 "VALUES",
                       "(   @Data",
                       ",   @Usuario",
                       ",   @NumeroCaixa",
                       ",   @TipoMovimento",
                       ",   @ValorMovimento",
                        ",  @Motivo",
                         ",  @IDAber",
                       "  )"
                    );
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = txtUsuario.Text;
                cmd.Parameters.Add(new SqlParameter("@NumeroCaixa", SqlDbType.VarChar)).Value = "01";
                cmd.Parameters.Add(new SqlParameter("@TipoMovimento", SqlDbType.VarChar)).Value = "Crédito Caixa";
                cmd.Parameters.Add(new SqlParameter("@ValorMovimento", SqlDbType.Decimal)).Value = valor;
                cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar)).Value = motivo;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = int.Parse(lblCodigoAbertura.Text.ToString());
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Lancamento Lan = new Lancamento();
                //Carregar os campos no objeto
                carregaPropriedades();

                if (Decimal.Parse(txtValorRecebido.Text) > Decimal.Parse(txtValorAlterado.Text))
                {
                    throw new Exception("Não é possível receber mais do que é devido pelo cliente");
                }

                objCR.alterar();

                //Gravar Recebimentos(R$) Diários
                PagamentoDiaBLL objPD = new PagamentoDiaBLL();
                objPD.cr_codigo = objCR.codigo;
                objPD.pd_valor = objCR.pago;
                objPD.pd_data = DateTime.Now.Date;
                objPD.inserir();
                Lan.Inserir(objPD.pd_data, 1, "Recebimento de Títulos", "C", objCR.pago, objCR.codigo);
                objPD = null;

                #region Imprimir cupom de pagamento

                //if (MessageBox.Show("Deseja Imprimir o recido da parcela paga?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                //{

                //    String ImpLF = "";
                //    ImpLF += "****RECIBO DE PAGAMENTO**********" + Environment.NewLine;
                //    ImpLF += ("Código da Venda: " + objCR.vendas) + Environment.NewLine;
                //    ImpLF += ("Data: " + DateTime.Now.ToString()) + Environment.NewLine;
                //    ImpLF += ("Parcela: " + objCR.parcela) + Environment.NewLine;
                //    ImpLF += ("Valor Pago: " + objCR.pago.ToString()) + Environment.NewLine;
                //    int Imp;
                //    Imp = MP2032.FormataTX(ImpLF + "\r\n\r\n", 2, 0, 0, 0, 1);
                //   MessageBox.Show("Parcela salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                               
                //}

                //if (objCR.pago > objCR.alterado)
                //{
                //    /* Localizar a próxima conta a ser paga e descontar caso o 
                //        * dinheiro pago seja maior que o valor da parcela, para isso é necessário
                //        * verificar se a próxima parcela possui juros a serem acrescidos ou descontos */
                //}

                #endregion

                objCR.limpar();
                limpar();

                MessageBox.Show("Parcela salva com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                objCR.limpar();
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
