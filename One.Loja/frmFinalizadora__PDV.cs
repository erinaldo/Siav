using One.Bll;
using One.Dal;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using MGMPDV;
using SVC_BLL;
using System.Xml;
namespace One.Loja
{
    public partial class frmFinalizadora__PDV : Form
    {
        private Form Parent { get; set; }

        public frmFinalizadora__PDV(Form parent)
        {
            InitializeComponent();
            this.Parent = parent;
            this.FormClosing += frmFinalizadora__PDV_FormClosing;
            parent.Visible = false;
            _Arrendodamento.Text = valorTroca.ToString();
        }

        void frmFinalizadora__PDV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Parent != null)
            {
                Parent.Visible = true;
                var codigobarra = Parent.Controls.Find("txtCodigoBarra", true)[0] as TextBox;
                codigobarra.Focus();
            }
            else
            {
                MessageBox.Show("Erro", "Erro de aplicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public String Encerrou = "Não";
        string str = "";
        public int formaPagamento = 0;
        public String valorTroco = "";
        public String valorRecebido = "";
        public int qtdParcelas = 1;
        public bool cancelar = false;
        Contexto objD = null;
        public String cpf;
        public decimal ValorTotal { get; set; }
        public decimal totaldinheiro { get; set; }
        public decimal totalcartaocredito { get; set; }
        public decimal totalcartaodebito { get; set; }
        public decimal totalcheque { get; set; }
        public decimal totalrevenda { get; set; }
        public decimal totalticket { get; set; }
        public decimal totaldesconto { get; set; }
        public decimal arrendomento { get; set; }
        public decimal totalvenda { get; set; }
        public decimal valorTroca { get; set; }

        public int CodigoFormaPagamento { get; set; }

        public decimal ValorFormaPagamento { get; set; }

        private DataTable OnePDV_Config()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("Select * From OnePDV");
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

        public void AplicarCoresEncerramento()
        {
            //this.panelInfo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        }

        //public void OnePDV()
        //{
        //    DataTable tab = null;
        //    tab = OnePDV_Config();

        //    if (tab.Rows.Count > 0)
        //    {
        //        //Mensagem PDV 
        //        // lblmsg.Text = tab.Rows[0]["MensagemPDV"].ToString();

        //        #region Setar Cores Paneis
        //        if (tab.Rows[0]["CorPDV"].ToString() == "Azul ")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.Color.SteelBlue;
        //        }

        //        else if (tab.Rows[0]["CorPDV"].ToString() == "Padrão")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        //        }

        //        else if (tab.Rows[0]["CorPDV"].ToString() == "Açai")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));

        //        }
        //        else if (tab.Rows[0]["CorPDV"].ToString() == "Preto")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.Color.Black;
        //        }
        //        else if (tab.Rows[0]["CorPDV"].ToString() == "Verde")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.Color.Green;
        //        }
        //        else if (tab.Rows[0]["CorPDV"].ToString() == "Branco")
        //        {
        //            this.panelInfo.BackColor = System.Drawing.Color.White;
        //        }
        //        #endregion
        //        #region Setar Cores Fundo
        //        //if (tab.Rows[0]["CorFundo"].ToString() == "Azul ")
        //        //{
        //        //    this.BackColor = System.Drawing.Color.SteelBlue;
        //        //}
        //        //else if (tab.Rows[0]["CorFundo"].ToString() == "Padrão")
        //        //{
        //        //    this.BackColor = System.Drawing.Color.Gainsboro;
        //        //}

        //        //else if (tab.Rows[0]["CorFundo"].ToString() == "Açai")
        //        //{
        //        //    this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(14)))), ((int)(((byte)(75)))));
        //        //}
        //        //else if (tab.Rows[0]["CorFundo"].ToString() == "Branco")
        //        //{
        //        //    this.BackColor = System.Drawing.Color.White;
        //        //}
        //        #endregion
        //    }
        //}

        public void limpar()
        {
            _Dinheiro.Text = "";
            _CartaoCredito.Text = "";
            _CartaoDebito.Text = "";
            _Cheque.Text = "";
            _Arrendodamento.Text = "";
            _Desconto.Text = "";

            _Dinheiro.BackColor = Color.White;
            _CartaoCredito.BackColor = Color.White;
            _CartaoDebito.BackColor = Color.White;
            _Cheque.BackColor = Color.White;
            _Arrendodamento.BackColor = Color.White;
            _Desconto.BackColor = Color.White;

            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.White;
            pnlDesconto.BackColor = Color.White;
            pnlReveda.BackColor = Color.White;

            //textBox1.Focus();
            ValorTotal = 0;
            totaldinheiro = 0;
            totalcartaocredito = 0;
            totalcartaodebito = 0;
            totalcheque = 0;
            totalrevenda = 0;
            totalticket = 0;
            totaldesconto = 0;
            arrendomento = 0;
            totalvenda = 0;
            CalcularValores();
            _Dinheiro.Focus();
        }

        public static void Moeda(ref TextBox txt)
        {
            string m = string.Empty;
            decimal v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(",", "");
                if (m.Equals(""))
                {
                    m = "";
                }
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                {
                    m = m.Substring(1, m.Length - 1);
                }
                v = Convert.ToDecimal(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CalcularValores()
        {
            try
            {
                totalvenda = decimal.Parse(txtTotalGeralVendaBruto.Text);

                if (_Dinheiro.Text != "")
                {
                    totaldinheiro = decimal.Parse(_Dinheiro.Text.ToString());
                }

                if (_CartaoCredito.Text != "")
                {
                    totalcartaocredito = decimal.Parse(_CartaoCredito.Text);
                }

                if (_CartaoDebito.Text != "")
                {
                    totalcartaodebito = decimal.Parse(_CartaoDebito.Text);
                }

                if (_Cheque.Text != "")
                {
                    totalcheque = decimal.Parse(_Cheque.Text);
                }

                //if (_Arrendodamento.Text != "")
                //{
                //    totalrevenda = decimal.Parse(_Arrendodamento.Text);
                //}
                if (_Desconto.Text != "")
                {
                    totaldesconto = decimal.Parse(_Desconto.Text);
                }

                if (_Arrendodamento.Text != "")
                {
                    arrendomento = decimal.Parse(_Arrendodamento.Text);
                }
                decimal subtotal = totalvenda;// Convert.ToDecimal(txtTotalGeralVendaBruto.Text);
                decimal pgto = totaldinheiro + totalcartaocredito + totalcartaodebito + totalcheque + arrendomento + totaldesconto;
                decimal totalpago = totaldinheiro + totalcartaocredito + totalcartaodebito + totalcheque;
                lblTotalPago.Text = totalpago.ToString();
                ValorTotal = pgto - subtotal;
                ValorTotal = ValorTotal;//- (totaldesconto + arrendomento);

                if (ValorTotal < 0)
                {
                    lblResult.Text = "Falta";
                    //  lblResult.ForeColor = Color.Red;
                    //  txtTotalRestante.ForeColor = Color.Red;
                }
                else if (ValorTotal > 0)
                {
                    lblResult.Text = "Troco";
                    //lblResult.ForeColor = Color.Green;
                    //txtTotalRestante.ForeColor = Color.Green;
                }
                else if (ValorTotal == 0)
                {
                    lblResult.Text = "Está Pago ; ) Obrigado!";
                    //lblResult.ForeColor = SystemColors.HotTrack;
                    //txtTotalRestante.ForeColor = SystemColors.HotTrack;
                }
                txtTotalRestante.Text = ValorTotal.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref _Dinheiro);
            pnlDinheiro.BackColor = Color.Yellow;
            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.White;
            pnlReveda.BackColor = Color.White;
            _Dinheiro.BackColor = Color.Yellow;
            CalcularValores();

        }

        private void txtCartaoCredito_TextChanged(object sender, EventArgs e)
        {
            pnlDinheiro.BackColor = Color.White;
            pnlCartaoCredito.BackColor = Color.Yellow;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.White;
            pnlReveda.BackColor = Color.White;
            Moeda(ref _CartaoCredito);
            _CartaoCredito.BackColor = Color.Yellow;
            CalcularValores();
        }

        private void txtCartaoDebito_TextChanged(object sender, EventArgs e)
        {
            pnlDinheiro.BackColor = Color.White;
            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.Yellow;
            pnlCheque.BackColor = Color.White;
            pnlReveda.BackColor = Color.White;
            Moeda(ref _CartaoDebito);
            _CartaoDebito.BackColor = Color.Yellow;
            CalcularValores();
        }

        private void txtCheque_TextChanged(object sender, EventArgs e)
        {
            pnlDinheiro.BackColor = Color.White;
            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.Yellow;
            pnlReveda.BackColor = Color.White;
            _Cheque.BackColor = Color.Yellow;
            Moeda(ref _Cheque);

            CalcularValores();
        }

        private void txtRevenda_TextChanged(object sender, EventArgs e)
        {
            pnlDinheiro.BackColor = Color.White;
            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.White;
            pnlReveda.BackColor = Color.Yellow;
            _Arrendodamento.BackColor = Color.Yellow;
            Moeda(ref _Arrendodamento);
            CalcularValores();
        }

        public void InserirFormaDePagamentovenda(int FormaDePagamentoID, decimal ValorDaFormaDePagamento, int ObjAber)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                   "INSERT INTO VendasFormasDePagamento",
                       "(   VendaID",
                       ",   Data",
                       ",   FormaDePagamentoID",
                       ",   ValorFormaDePagamento",
                       ",   ValorTotal",
                       ",   ValorTotalTroco",
                       ",   IDAber",
                       ",   Usuario)",
                 "VALUES",
                       "(   @VendaID",
                       ",   @Data",
                       ",   @FormaDePagamentoID",
                       ",   @ValorFormaDePagamento",
                       ",   @ValorTotal",
                       ",   @ValorTotalTroco",
                         ",   @IDAber",
                       ",   @Usuario)"
                    );
                cmd.Parameters.Add(new SqlParameter("@VendaID", SqlDbType.Int)).Value = int.Parse(txtVendaID.Text);
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@FormaDePagamentoID", SqlDbType.Int)).Value = FormaDePagamentoID;
                cmd.Parameters.Add(new SqlParameter("@ValorFormaDePagamento", SqlDbType.Decimal)).Value = ValorDaFormaDePagamento;
                cmd.Parameters.Add(new SqlParameter("@ValorTotal", SqlDbType.Decimal)).Value = decimal.Parse(txtTotalGeralVendaBruto.Text);
                cmd.Parameters.Add(new SqlParameter("@ValorTotalTroco", SqlDbType.Decimal)).Value = decimal.Parse(txtTotalRestante.Text);
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = txtUsuario.Text;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = ObjAber;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void IncluirMovimentoPgamento()
        {
            try
            {
                decimal valorFinal = 0;
                valorFinal = decimal.Parse(txtTotalRestante.Text);
                if (valorFinal < 0)
                {
                    throw new Exception("Informe o valor restante!");
                }
                foreach (Control ctl in this.Controls)
                {
                    if (ctl is TextBox)
                    {
                        if (ctl.Name == "_Dinheiro" && ctl.Text != "")
                        {
                            CodigoFormaPagamento = 1;
                        }
                        else if (ctl.Name == "_CartaoCredito" && ctl.Text != "")
                        {
                            CodigoFormaPagamento = 2;
                        }
                        if (ctl.Name == "_CartaoDebito" && ctl.Text != "")
                        {
                            CodigoFormaPagamento = 3;
                        }
                        else if (ctl.Name == "_Cheque" && ctl.Text != "")
                        {
                            CodigoFormaPagamento = 4;
                        }
                        //else if (ctl.Name == "_Revenda" && ctl.Text != "")
                        //{
                        //    CodigoFormaPagamento = 5;
                        //}
                        if (ctl.Text != String.Empty && ctl.Name != "_Desconto")
                        {
                            ValorFormaPagamento = decimal.Parse(ctl.Text);
                            InserirFormaDePagamentovenda(CodigoFormaPagamento, ValorFormaPagamento, int.Parse(lblCodigoAbertura.Text));
                            //Contas a receber 
                            #region Formas de pagamento
                            FormaPagamentoBLL objFP = new FormaPagamentoBLL();
                            objFP.localizar(CodigoFormaPagamento.ToString(), "fp_codigo");
                            if (CodigoFormaPagamento == 4 || CodigoFormaPagamento == 5)
                            {
                                ContasAReceberBLL objCR = new ContasAReceberBLL();
                                objCR.vendas = int.Parse(txtVendaID.Text.ToString());
                                DateTime dtDataInicial = Convert.ToDateTime(DateTime.Now.ToString());
                                // objCR.excluirVenda();
                                objCR = null;
                                objCR = new ContasAReceberBLL();
                                objCR.vendas = int.Parse(txtVendaID.Text.ToString());
                                objCR.pago = 0;
                                objCR.status = "Aberto";
                                objCR.pagamento = null;
                                objCR.juros = 0;
                                objCR.desconto = 0;
                                objCR.observacao = "";
                                objCR.parcela = 1 + "/" + 1;
                                objCR.formaPagamento = CodigoFormaPagamento;
                                objCR.original = ValorFormaPagamento;
                                objCR.alterado = ValorFormaPagamento;
                                objCR.vencimento = dtDataInicial.AddMonths(1);
                                objCR.inserir();
                                objCR = null;
                            }
                            else //Pagamento A Vista
                            {
                                ContasAReceberBLL objCR = new ContasAReceberBLL();
                                objCR.vendas = int.Parse(txtVendaID.Text);
                                //   objCR.excluirVenda();
                                objCR = null;
                                objCR = new ContasAReceberBLL();
                                objCR.vendas = int.Parse(txtVendaID.Text);
                                DateTime dtDataInicial = Convert.ToDateTime(DateTime.Now.ToString());
                                objCR.vencimento = dtDataInicial.AddMonths(1 - 1);
                                objCR.original = ValorFormaPagamento;
                                objCR.alterado = ValorFormaPagamento;
                                objCR.pago = objCR.original;
                                objCR.status = "Pago";
                                objCR.pagamento = DateTime.Now.Date;
                                objCR.juros = 0;
                                objCR.desconto = 0;
                                objCR.observacao = "";
                                objCR.parcela = 1 + "/" + 1;
                                objCR.formaPagamento = CodigoFormaPagamento;
                                objCR.inserir();
                            }
                            #endregion

                            decimal TotalDesconto = 0;
                            decimal ValorDescontoPer = 0;
                            decimal ValorDescontoArre = 0;
                            if (_Desconto.Text != String.Empty)
                            {
                                ValorDescontoPer = decimal.Parse(_Desconto.Text.ToString());
                            }
                            if (_Arrendodamento.Text != String.Empty)
                            {
                                ValorDescontoArre = decimal.Parse(_Arrendodamento.Text.ToString());
                            }
                            TotalDesconto = ValorDescontoPer + ValorDescontoArre;

                            AplicarDesconto(int.Parse(txtVendaID.Text.ToString()), TotalDesconto, decimal.Parse(txtTotalGeralVendaBruto.Text.ToString().Replace("R$", "")));

                        }
                    }
                }
                //   btnFechar.Enabled = true;
                btnFecharTela.Visible = true;
                btnFecharTela.Enabled = true;
                Encerrou = "Sim";
                #region Abrir Gaveta
                int iRetorno = 0;
                int charCode = 27;
                int charCode2 = 118;
                int charCode3 = 140;
                Char specialChar = Convert.ToChar(charCode);
                Char specialChar2 = Convert.ToChar(charCode2);
                Char specialChar3 = Convert.ToChar(charCode3);
                string s_cmdTX = "" + specialChar + specialChar2 + specialChar3;
               // iRetorno = MP2032.ComandoTX(s_cmdTX, s_cmdTX.Length);
                #endregion
                AplicarCoresEncerramento();
                Encerrou = "Sim";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetarMesaPraZero(int VendaID)
        {
            //Seta Ticket para zero
            SqlCommand cmd = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Update Vendas Set ven_ticket = 0 Where ven_codigo = @Codigo");
                cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.Int)).Value = VendaID;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        private void frmFinalizadora_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        finaliza();
                        break;
                    case Keys.F3:
                        limpar();
                        break;

                    case Keys.F4:
                        limpar();
                        frmDesconto frm = new frmDesconto();
                        frm.valorTotal = decimal.Parse(txtTotalGeralVendaBruto.Text);
                        frm.ShowDialog();
                        _Desconto.Text = "0";
                        decimal valorDesconto = decimal.Parse(_Desconto.Text);
                        valorDesconto = frm.TotalDescontoReais;
                        _Desconto.Text = valorDesconto.ToString();
                        break;
                    case Keys.F12:
                        if (Encerrou == "Sim")
                        {
                            //SetarMesaPraZero(int.Parse(txtVendaID.Text.ToString()));
                            this.Close();
                        }
                        break;
                    case Keys.Escape:
                        if (Encerrou != "Sim")
                        {
                            this.Close();
                            cancelar = true;
                        }
                        else
                        {
                            MessageBox.Show("Clique em F12 para concluir.");
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            pnlDinheiro.BackColor = Color.White;
            pnlCartaoCredito.BackColor = Color.White;
            pnlCartaoDebito.BackColor = Color.White;
            pnlCheque.BackColor = Color.White;
            pnlReveda.BackColor = Color.White;
            pnlDesconto.BackColor = Color.Yellow;
            _Desconto.BackColor = Color.Yellow;
            Moeda(ref _Desconto);
            CalcularValores();
        }

        private void txtDesconto_Enter(object sender, EventArgs e)
        {

        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Enter:
            //        frmDesconto frm = new frmDesconto();
            //        frm.valorTotal = decimal.Parse(txtTotalGeralVenda.Text);
            //        frm.ShowDialog();
            //        _Desconto.Text = frm.TotalDescontoReais.ToString();
            //        break;
            //}
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void AplicarDesconto(int VendaID, decimal vrDesconto, decimal ValorFinal)
        {

            SqlCommand cmd = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Update Vendas Set ven_desconto = @Desconto",
                    ", ven_valorfinal = @valorfinal -  @Desconto ",
                    " Where ven_codigo = @Codigo"
                    );
                cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.Int)).Value = VendaID;
                cmd.Parameters.Add(new SqlParameter("@Desconto", SqlDbType.Decimal)).Value = vrDesconto;
                cmd.Parameters.Add(new SqlParameter("@valorfinal", SqlDbType.Decimal)).Value = ValorFinal;

                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        private void frmFinalizadora_Load(object sender, EventArgs e)
        {
            //  OnePDV();
            limpar();
            if (lblCodigoCliente.Text != "1")
            {
                _Cheque.Text = txtTotalGeralVendaBruto.Text.ToString();
            }

            _Arrendodamento.Text = valorTroca.ToString();

            _Dinheiro.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void pnlFormasPagamento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Dinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void _CartaoCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void _CartaoDebito_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void _Cheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void _Revenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void _Dinheiro_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (textBox1.Text == "1")
                        {
                            _Dinheiro.Text = txtTotalRestante.Text.Replace("-", "");
                            _Dinheiro.Focus();
                        }
                        else if (textBox1.Text == "2")
                        {
                            _CartaoCredito.Text = txtTotalRestante.Text.Replace("-", "");
                            _CartaoCredito.Focus();
                        }
                        else if (textBox1.Text == "3")
                        {
                            _CartaoDebito.Text = txtTotalRestante.Text.Replace("-", "");
                            _CartaoDebito.Focus();
                        }
                        else if (textBox1.Text == "4")
                        {
                            _Cheque.Text = txtTotalRestante.Text.Replace("-", "");
                            _Cheque.Focus();
                        }
                        else if (textBox1.Text == "5")
                        {
                            _Arrendodamento.Text = txtTotalRestante.Text.Replace("-", "");
                            _Arrendodamento.Focus();
                        }
                        else
                        {
                            textBox1.SelectAll();
                            throw new Exception("Não existe essa forma de pagamento cadastrada no sistema!");
                        }
                        //else if (textBox1.Text == "6")
                        //{
                        //    _Desconto.Focus();
                        //}
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void _Dinheiro_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void _CartaoCredito_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void _CartaoDebito_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void _Cheque_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void _Revenda_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    textBox1.Focus();
                    textBox1.SelectAll();
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }




        private Boolean criarSAT()
        {

            int sleep = 3000;
            try
            {
                sleep = int.Parse(parametroSat("sleep"));
            }
            catch { MessageBox.Show("Sleep padrao = 3000, favor configurar!"); }



            Double aliquota = 0;
            Double aliquotatotal = 0;
            int sessao = 0;
            string texto = "";
            try
            {
                texto = "SAT.Inicializar";
                System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto);
            }
            catch { }
            System.Threading.Thread.Sleep(500);
            string[] lines;// File.ReadAllLines(@"C:\ACBrMonitorPLUS\SAI.txt");

            EmpresaBLL empresa = new EmpresaBLL();
            DataTable tb_empresa = empresa.localizarEmTudo("");

            vendaItensBLL tb_venda_itens = new vendaItensBLL();
            DataTable tb_venda = tb_venda_itens.localizarComRetorno(this.txtVendaID.Text.ToString(), "ven_codigo");
            // DataTable table3 = this.objVe.localizarComRetorno(this.txtVendaID.Text.ToString(), "ven_codigo");

            String caixanumero = "1";
            // empresa.emp_cnpj

            //
            //
            // tb_empresa.Rows[0]["emp_cnpj"]
            // tb_empresa.Rows[0]["emp_cnpj"]
            // tb_empresa.Rows[0]["emp_cnpj"]

            //parametroSat("cnpjsh") 
            //parametroSat("assinaturaac")

            //11111111111111
            //111111111111
            //11111

            ConfiguracoesBLL entidade = new ConfiguracoesBLL();
            entidade.localizar();

            texto = @"
            SAT.CriarEnviarCfe(""[infCFe]
            versao = " + parametroSat("versao") + @"
            [Identificacao]
            CNPJ = " + entidade.cnpj_softwarehouse.Replace(".", "").Replace("/", "") + @"
            signAC = " + entidade.codigo_vinculacao.Trim() + @"
            numeroCaixa = " + caixanumero + @"
            [Emitente]
            CNPJ = " + tb_empresa.Rows[0]["emp_cnpj"].ToString() + @"
            IE = " + tb_empresa.Rows[0]["emp_inscricaoEstadual"].ToString() + @"
            IM = " + tb_empresa.Rows[0]["emp_inscricaoMunicipal"].ToString() + @"
            indRatISSQN = S
            [Destinatario]
            CNPJCPF = " + this.cpf;

            //if (ckbcpf.Checked){
            //  texto += cliente.cpf;
            /*if (cliente.id > 0)
            {
                texto += cliente.cpf;
            }
            else
                texto += lblclienteendereco.Text;*/
            //}

            texto += @"
  xNome = ";
            //if (ckbcpf.Checked)
            //{
            //    //texto += cliente.nome;
            //    if (cliente.id > 0)
            //    {
            //        texto += cliente.nome;
            //    }
            //    else
            //        texto += "Cliente";
            //}

            // if (ckbentrega.Checked)
            // {
            //     texto += @"
            //          [Entrega]
            //       xLgr = " + cliente.endereco + @"
            //        nro = " + cliente.numero + @"
            //       xCpl =
            //       xBairro = " + cliente.bairro + @"
            //       xMun = " + cliente.cid_nome + @"
            //       UF = " + cliente.cid_uf;
            //
            // }

            for (int i = 0; i < tb_venda.Rows.Count; i++)
            {
                DataTable tb_produto = new ProdutosDAL().localizarLeave(tb_venda.Rows[i]["pro_codigo"].ToString(), "pro_codigo");

                Double quantidade_item = Double.Parse(tb_venda.Rows[i]["vi_quantidade"].ToString());
                double valor_unitario = double.Parse(tb_venda.Rows[i]["vi_valorUnitario"].ToString());

                Double porcentagem_aliquota = Double.Parse(entidade.emp_tributos);
                Double reducao_aliquota = Double.Parse(entidade.emp_reducao);



                if (porcentagem_aliquota > 0)
                {
                    // procentagem_aliquota = procentagem_aliquota / 100;
                    aliquota = quantidade_item * valor_unitario;

                    if (totaldesconto > 0){

                        Double aux_desc = 0;
                        if(tb_venda.Rows.Count == 1)
                            aux_desc = Convert.ToDouble(totaldesconto);
                        else
                            aux_desc = Convert.ToDouble((totaldesconto)) / (tb_venda.Rows.Count);
                        
                        aliquota = aliquota - aux_desc;
                    }

                    if (reducao_aliquota > 0)
                    {
                        aliquota = aliquota * (reducao_aliquota / 100);
                    }

                    aliquota = aliquota * (porcentagem_aliquota / 100);
                }
                else
                {
                    throw new Exception("Nenhuma porcentagem de aliquota cadastrada !");
                }



                //aliquota = (quantidade_item * valor_unitario) * (8.28 / 100);
                aliquotatotal += aliquota;

                texto += @"
                         [Produto" + ((i + 1).ToString("000")) + @"]
                          cProd = " + tb_venda.Rows[i]["pro_codigo"] + @"
                          infAdProd = 
                          cEAN = 
                          xProd = " + tb_produto.Rows[0]["pro_nome"] + @"
                          NCM = " + tb_produto.Rows[0]["pro_ncm"] + @"
                          CFOP = " + tb_produto.Rows[0]["pro_cfop"] + @"
                          uCom = UN" + @"
                          Combustivel = 0
                          qCom = " + tb_venda.Rows[i]["vi_quantidade"] + @"
                          vUnCom = " + tb_venda.Rows[i]["vi_valorUnitario"] + @"
                          indRegra = A
                          vDesc = 0
                          vOutro = 0
                          vItem12741 = " + aliquota + @"
                          [ObsFiscoDet" + ((i + 1).ToString("000")) + @"]
                          xCampoDet = Cod. CEST
                          xTextoDet = ";

                // ACIMA ESTAVAO CEST produto.pro_cest
                texto += @"
                            [ICMS" + ((i + 1).ToString("000")) + @"]
                            Orig = 10";
                //Orig = " + produto.pro_origem.ToString();

                //if (configuracao.regime == "S")
                if (true)
                {
                    String cson = "900";
                    //String produto.pro_csosn;
                    texto += @"
                                CSOSN=" + cson;
                    if (cson == "900")
                    {
                        texto += @"
                                    pICMS=" + aliquota;
                    }
                    texto += @"
                                    [PIS" + ((i + 1).ToString("000")) + @"]
                                    CST = 49
                                    [COFINS" + ((i + 1).ToString("000")) + @"]
                                    CST = 49";
                }
                else
                {


                    // string cst = "";
                    //         pis = pisempresa / 100
                    //         pis = if (wpPIS = 0, 0.0065, wpPIS)
                    //         if (cst = "00"|| cst = "20" || cst = "90")
                    //           "CST=01"
                    //           "vBC=" + (quant * valor)
                    //           "pPIS=" + pis
                    //         else
                    //           if (cst = "40" || cst = "41" || cst = "50")
                    //           "CST=07"
                    //           else
                    //           if (cst = "60")
                    //           "CST=05"
                    //           "vBC=" 0
                    //           "pPIS=" pis
                    //
                    //           "[PISST" + strzero(wseq, 3) + "]"
                    //           "vBC=" + ltrim(transf(quant * valor, "@E 999999.99"))
                    //           "pPIS=" + ltrim(transf(wpPIS, "@E 999999.9999"))




                    texto += @"[ICMS" + ((i + 1).ToString("000")) + @"]
                                    Orig = 0
                                    CST = 40
                                    [PIS" + ((i + 1).ToString("000")) + @"]
                                    CST = 01
                                    [COFINS" + ((i + 1).ToString("000")) + @"]
                                    CST = 01";
                }
            }

            texto += @"
            [Total]
            vCFeLei12741 = " + aliquotatotal + @"
              [DescAcrEntr]
            vDescSubtot = " + this.totaldesconto;

            Int32 x = 1;

            //       if(total)
            //
            //          public decimal totaldinheiro { get; set; }
            //   public decimal totalcartaocredito { get; set; }
            //   public decimal totalcartaodebito { get; set; }
            //   public decimal totalcheque { get; set; }
            //   public decimal totalrevenda { get; set; }
            //   public decimal totalticket { get; set; }
            //   public decimal totaldesconto { get; set; }
            //   public decimal arrendomento { get; set; }
            //   public decimal totalvenda { get; set; }
            //   public decimal valorTroca { get; set; }
            //
            int pgto = 1;

            if (this.totaldinheiro > 0)
            {
                texto += @"
            [Pagto" + ((pgto).ToString("000")) + @"]
            cMP = " + int.Parse("1").ToString("00") + @"
            vMP = " + this.totaldinheiro;
                pgto++;
            }

            if (this.totalcheque > 0)
            {
                texto += @"
            [Pagto" + ((pgto).ToString("000")) + @"]
            cMP = " + int.Parse("2").ToString("00") + @"
            vMP = " + this.totalcheque;
                pgto++;
            }

            if (this.totalcartaocredito > 0)
            {
                texto += @"
            [Pagto" + ((pgto).ToString("000")) + @"]
            cMP = " + int.Parse("3").ToString("00") + @"
            vMP = " + this.totalcartaocredito;
                pgto++;
            }

            if (this.totalcartaodebito > 0)
            {
                texto += @"
            [Pagto" + ((pgto).ToString("000")) + @"]
            cMP = " + int.Parse("4").ToString("00") + @"
            vMP = " + this.totalcartaodebito;
                pgto++;
            }

            if (this.valorTroca > 0)
            {
                texto += @"
            [Pagto" + ((pgto).ToString("000")) + @"]
            cMP = " + int.Parse("5").ToString("00") + @"
            vMP = " + _Arrendodamento.Text.Replace(',', '.');
                pgto++;
            }

            String mensagem = "Este campo é o teste de informações adicionais.";

            ClienteBLL cliente = new ClienteBLL();
            cliente.cli_cpf = this.cpf;
            cliente.LocalizarEmTudo(this.cpf, "Pessoa Física");

            if (cliente.cli_nome != "" && cliente.cli_nome != null)
                mensagem = "Cumpom impresso para o cliente " + cliente.cli_nome;

            texto += @"
      [DadosAdicionais]
      infCpl = " + mensagem + @"
        [ObsFisco001]
      xCampo = 
      xTexto = "")";

            File.Delete(parametroSat("caminhosaitxt"));

            //MessageBox.Show("Vai escrever o arquivo TXT");
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto, Encoding.UTF8);

            //System.IO.File.WriteAllText(@"D:\ENT.txt", texto); //  
            //MessageBox.Show("Vai iniciar o Sleep para aguardar o processamento do acbr");
            System.Threading.Thread.Sleep(sleep);

            //pnlcarregando.Visible = false;
            //MessageBox.Show("Coletar o XML");
            string xml = retornoSAT("XML");
            //MessageBox.Show("Verifica se deu erro :" + xml);
            if (xml.Contains("Erro Monitor"))
            {
                File.Delete(parametroSat("caminhocupomtxt"));
                //fmok.Mostrar("Erro!. Monitor não encontrado!");
                return false;
            }

            //xml = File.ReadAllText("C:/Users/Natanniel/Desktop/AD35170802309287000161590003552650001498261624.xml").ToString();

            string xmlpuro = xml;
            //MessageBox.Show("monta string para impressão");
            xml = "SAT.ImprimirExtratoVenda(\"" + xml + "\");";

            //MessageBox.Show("ler código de retorno");
            string codigoDeRetorno = retornoSAT("codigoDeRetorno");
            //MessageBox.Show("código retorno" + codigoDeRetorno + " vai ler numero da sessão");
            string numeroSessao = retornoSAT("numeroSessao");
            //MessageBox.Show("Numero sessão " + numeroSessao + " vai escrever o arquivo para impressão");

            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", xml);

            System.Threading.Thread.Sleep(3000);
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", xml);

            //  bool via2 = false;
            //  for (int i = 0; i < dtparcelas.Rows.Count; i++)
            //  {
            //      if (dtparcelas.Rows[i]["par_descricao"].ToString().ToUpper().Contains("MARCAR"))
            //      {
            //          via2 = true;
            //      }
            //  }

            //  if (via2)
            //  {
            //      System.Threading.Thread.Sleep(sleep);
            //      System.IO.File.WriteAllText(@"C:\ACBrMonitorPLUS\ENT.txt", xml);
            //  }
            //MessageBox.Show("Verifica código do retorno se é diferente de 6000 .. código de retorno " + codigoDeRetorno);
            if (codigoDeRetorno != "6000")
            {
                sessao = 0;
                int retorno = 0;
                try
                {
                    retorno = int.Parse(codigoDeRetorno);
                }
                catch { }
                MessageBox.Show(retornaMSGSat(retorno));
            }
            else
                try
                {
                    //MessageBox.Show("Instancia obj de venda");
                    VendasBLL objVen = new VendasBLL();
                    //MessageBox.Show("inclui movimento de venda");
                    IncluirMovimentoPgamento();
                    //SetarMesaPraZero(int.Parse(txtVendaID.Text.ToString()));
                    // MessageBox.Show("Escrevendo mensagens na tela");
                    valorTroco = txtTotalRestante.Text;
                    lblStatus.Text = "Pagamento Efetuado...Aperte F12";
                    SystemSounds.Asterisk.Play();

                    String nsat = "";
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xmlpuro);
                        System.Xml.XmlElement root = doc.DocumentElement;
                        System.Xml.XmlNodeList nodeList = root.GetElementsByTagName("ide");
                        nsat = (int.Parse(nodeList[0]["nserieSAT"].InnerText)).ToString();

                    }
                    catch
                    {
                        int index = xmlpuro.IndexOf("<nserieSAT>") + 11;
                        int index_end = xmlpuro.IndexOf("</nserieSAT>");
                        nsat = xmlpuro.Substring(index, index_end - index);
                    }
                    try
                    {
                        sessao = int.Parse(numeroSessao);
                    }
                    catch { }

                    //   MessageBox.Show("Vincular a venda ao XML .. Sessão :" + sessao + "");
                    //   MessageBox.Show("Vincular a venda ao XML .. id venda :" + this.txtVendaID.ToString() + "");
                    //   MessageBox.Show("Vincular a venda ao XML .. xml :" + xmlpuro + "");
                    //   MessageBox.Show("Vincular a venda ao XML .. data :" + DateTime.Now.ToString() + "");
                    //   MessageBox.Show("Vincular a venda ao XML .. data :" + nsat + "");

                    String xxx = objVen.vincula_xml_venda(int.Parse(this.txtVendaID.ToString()), sessao, xmlpuro, DateTime.Now.ToString(), (int.Parse(nsat)).ToString());
                    //MessageBox.Show(xxx);

                    //CSat sat = new CSat();
                    //  sat.inserir(venda.ven_id, sessao, xmlpuro);
                }
                catch (Exception exception)
                {
                    sessao = 0;
                    MessageBox.Show("Erro ao vincular XML : " + exception.Message);
                }
            return false;
        }

        private string parametroSat(string chave)
        {

            string retorno = "";
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\SAT.ini");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(chave + "="))
                {
                    retorno = lines[i].Substring(chave.Length + 1);
                }
            }
            return retorno;
        }

        private string retornaMSGSat(int codigodeRetorno)
        {
            string msg = "";
            string[] msgSat = new string[20000];

            msgSat[100] = "CF-e-SAT processado com sucesso";
            msgSat[101] = "CF-e-SAT de cancelamento processado com sucesso";
            msgSat[102] = "CF-e-SAT processado – verificar inconsistências";
            msgSat[103] = "CF-e-SAT de cancelamento processado – verificar inconsistências";
            msgSat[104] = "Não Existe Atualização do Software";
            msgSat[105] = "Lote recebido com sucesso";
            msgSat[106] = "Lote Processado";
            msgSat[107] = "Lote em Processamento";
            msgSat[108] = "Lote não localizado";
            msgSat[109] = "Serviço em Operação";
            msgSat[110] = "Status SAT recebido com sucesso";
            msgSat[112] = "Assinatura do AC Registrada";
            msgSat[113] = "Consulta cadastro com uma ocorrência";
            msgSat[114] = "Consulta cadastro com mais de uma ocorrência";
            msgSat[115] = "Solicitação de dados efetuada com sucesso";
            msgSat[116] = "Atualização do SB pendente";
            msgSat[117] = "Solicitação de Arquivo de Parametrização efetuada com sucesso";
            msgSat[118] = "Logs extraídos com sucesso";
            msgSat[119] = "Comandos da SEFAZ pendentes";
            msgSat[120] = "Não existem comandos da SEFAZ pendentes";
            msgSat[121] = "Certificado Digital criado com sucesso";
            msgSat[122] = "CRT recebido com sucesso";
            msgSat[123] = "Adiar transmissão do lote";
            msgSat[124] = "Adiar transmissão do CF-e";
            msgSat[125] = "CF-e de teste de produção emitido com sucesso";
            msgSat[126] = "CF-e de teste de ativação emitido com sucesso";
            msgSat[127] = "Erro na emissão de CF-e de teste de produção";
            msgSat[128] = "Erro na emissão de CF-e de teste de ativação";
            msgSat[129] = "Solicitações de emissão de certificados excedidas. (Somente ocorrerá no ambiente de testes)";
            msgSat[200] = "Rejeição: Status do equipamento SAT difere do esperado";
            msgSat[201] = "Rejeição: Falha na Verificação da Assinatura do Número de segurança";
            msgSat[202] = "Rejeição: Falha no reconhecimento da autoria ou integridade do arquivo digital";
            msgSat[203] = "Rejeição: Emissor não Autorizado para emissão da CF-e-SAT";
            msgSat[204] = "Rejeição: Duplicidade de CF-e-SAT";
            msgSat[205] = "Rejeição: Equipamento SAT encontra-se Ativo";
            msgSat[206] = "Rejeição: Hora de Emissão do CF-e-SAT posterior à hora de recebimento.";
            msgSat[207] = "Rejeição: CNPJ do emitente inválido";
            msgSat[208] = "Rejeição: Equipamento SAT encontra-se Desativado";
            msgSat[209] = "Rejeição: IE do emitente inválida";
            msgSat[210] = "Rejeição: Intervalo de tempo entre o CF-e-SAT emitido e a emissão do respectivo CF-e-SAT de cancelamento é maior que 30 (trinta) minutos.";
            msgSat[211] = "Rejeição: CNPJ não corresponde ao informado no processo de transferência.";
            msgSat[212] = "Rejeição: Data de Emissão do CF-e-SAT posterior à data de recebimento.";
            msgSat[213] = "Rejeição: CNPJ-Base do Emitente difere do CNPJ-Base do Certificado Digital";
            msgSat[214] = "Rejeição: Tamanho da mensagem excedeu o limite estabelecido";
            msgSat[215] = "Rejeição: Falha no schema XML";
            msgSat[216] = "Rejeição: Chave de Acesso difere da cadastrada";
            msgSat[217] = "Rejeição: CF-e-SAT não consta na base de dados da SEFAZ";
            msgSat[218] = "Rejeição: CF-e-SAT já esta cancelado na base de dados da SEFAZ";
            msgSat[219] = "Rejeição: CNPJ não corresponde ao informado no processo de declaração de posse.";
            msgSat[220] = "Rejeição: Valor do rateio do desconto sobre subtotal do item (N) inválido.";
            msgSat[221] = "Rejeição: Aplicativo Comercial não vinculado ao SAT";
            msgSat[222] = "Rejeição: Assinatura do Aplicativo Comercial inválida";
            msgSat[223] = "Rejeição: CNPJ do transmissor do lote difere do CNPJ do transmissor da consulta";
            msgSat[224] = "Rejeição: CNPJ da Software House inválido";
            msgSat[225] = "Rejeição: Falha no Schema XML do lote de CFe";
            msgSat[226] = "Rejeição: Código da UF do Emitente diverge da UF receptora";
            msgSat[227] = "Rejeição: Erro na Chave de Acesso - Campo Id – falta a literal CFe";
            msgSat[228] = "Rejeição: Valor do rateio do acréscimo sobre subtotal do item (N) inválido.";
            msgSat[229] = "Rejeição: IE do emitente não informada";
            msgSat[230] = "Rejeição: IE do emitente não autorizada para uso do SAT";
            msgSat[231] = "Rejeição: IE do emitente não vinculada ao CNPJ";
            msgSat[232] = "Rejeição: CNPJ do destinatário do CF-e-SAT de cancelamento diferente daquele do CF-e-SAT a ser cancelado.";
            msgSat[233] = "Rejeição: CPF do destinatário do CF-e-SAT de cancelamento diferente daquele do CF-e-SAT a ser cancelado.";
            msgSat[234] = "Alerta: Razão Social/Nome do destinatário em branco";
            msgSat[235] = "Rejeição: CNPJ do destinatario Invalido";
            msgSat[236] = "Rejeição: Chave de Acesso com dígito verificador inválido";
            msgSat[237] = "Rejeição: CPF do destinatario Invalido";
            msgSat[238] = "Rejeição: CNPJ do emitente do CF-e-SAT de cancelamento diferente do CNPJ do CF-e-SAT a ser cancelado.";
            msgSat[239] = "Rejeição: Versão do arquivo XML não suportada";
            msgSat[240] = "Rejeição: Valor total do CF-e-SAT de cancelamento diferente do Valor total do CF-e-SAT a ser cancelado.";
            msgSat[241] = "Rejeição: diferença de transmissão e recebimento da mensagem superior a 5 minutos.";
            msgSat[242] = "Alerta: CFe dentro do lote estão fora de ordem.";
            msgSat[243] = "Rejeição: XML Mal Formado";
            msgSat[244] = "Rejeição: CNPJ do Certificado Digital difere do CNPJ da Matriz e do CNPJ do Emitente";
            msgSat[245] = "Rejeição: CNPJ Emitente não autorizado para uso do SAT";
            msgSat[246] = "Rejeição: Campo cUF inexistente no elemento cfeCabecMsg do SOAP Header";
            msgSat[247] = "Rejeição: Sigla da UF do Emitente diverge da UF receptora";
            msgSat[248] = "Rejeição: UF do Recibo diverge da UF autorizadora";
            msgSat[249] = "Rejeição: UF da Chave de Acesso diverge da UF receptora";
            msgSat[250] = "Rejeição: UF informada pelo SAT, não é atendida pelo Web Service";
            msgSat[251] = "Rejeição: Certificado enviado não confere com o escolhido na declaração de posse";
            msgSat[252] = "Rejeição: Ambiente informado diverge do Ambiente de recebimento";
            msgSat[253] = "Rejeição: Digito Verificador da chave de acesso composta inválida";
            msgSat[254] = "Rejeição: Elemento cfeCabecMsg inexistente no SOAP Header";
            msgSat[255] = "Rejeição: CSR enviado inválido";
            msgSat[256] = "Rejeição: CRT enviado inválido";
            msgSat[257] = "Rejeição: Número do série do equipamento inválido";
            msgSat[258] = "Rejeição: Data e/ou hora do envio inválida";
            msgSat[259] = "Rejeição: Versão do leiaute inválida";
            msgSat[260] = "Rejeição: UF inexistente";
            msgSat[261] = "Rejeição: Assinatura digital não encontrada";
            msgSat[262] = "Rejeição: CNPJ da software house não está ativo";
            msgSat[263] = "Rejeição: CNPJ do contribuinte não está ativo";
            msgSat[264] = "Rejeição: Base da receita federal está indisponível";
            msgSat[265] = "Rejeição: Número de série inexistente no cadastro do equipamento";
            msgSat[266] = "Falha na comunicação com a AC-SAT";
            msgSat[267] = "Erro desconhecido na geração do certificado pela AC-SAT";
            msgSat[268] = "Rejeição: Certificado está fora da data de validade.";
            msgSat[269] = "Rejeição: Tipo de atividade inválida";
            msgSat[270] = "Rejeição: Chave de acesso do CFe a ser cancelado inválido.";
            msgSat[271] = "Rejeição: Ambiente informado no CF-e difere do Ambiente de recebimento cadastrado.";
            msgSat[272] = "Rejeição: Valor do troco negativo.";
            msgSat[273] = "Rejeição: Serviço Solicitado Inválido";
            msgSat[274] = "Rejeição: Equipamento não possui declaração de posse";
            msgSat[275] = "Rejeição: Status do equipamento diferente de Fabricado";
            msgSat[276] = "Rejeição: Diferença de dias entre a data de emissão e de recepção maior que o prazo legal";
            msgSat[277] = "Rejeição: CNPJ do emitente não está ativo junto à Sefaz na data de emissão";
            msgSat[278] = "Rejeição: IE do emitente não está ativa junto à Sefaz na data de emissão";
            msgSat[280] = "Rejeição: Certificado Transmissor Inválido";
            msgSat[281] = "Rejeição: Certificado Transmissor Data Validade";
            msgSat[282] = "Rejeição: Certificado Transmissor sem CNPJ";
            msgSat[283] = "Rejeição: Certificado Transmissor - erro Cadeia de Certificação";
            msgSat[284] = "Rejeição: Certificado Transmissor revogado";
            msgSat[285] = "Rejeição: Certificado Transmissor difere ICP-Brasil";
            msgSat[286] = "Rejeição: Certificado Transmissor erro no acesso a LCR";
            msgSat[287] = "Rejeição: Código Município do FG - ISSQN: dígito inválido. Exceto os códigos descritos no Anexo 2 que apresentam dígito inválido.";
            msgSat[288] = "Rejeição: Data de emissão do CF-e-SAT a ser cancelado inválida";
            msgSat[289] = "Rejeição: Código da UF informada diverge da UF solicitada";
            msgSat[290] = "Rejeição: Certificado Assinatura inválido";
            msgSat[291] = "Rejeição: Certificado Assinatura Data Validade";
            msgSat[292] = "Rejeição: Certificado Assinatura sem CNPJ";
            msgSat[293] = "Rejeição: Certificado Assinatura - erro Cadeia de Certificação";
            msgSat[294] = "Rejeição: Certificado Assinatura revogado";
            msgSat[295] = "Rejeição: Certificado Raiz difere dos Válidos";
            msgSat[296] = "Rejeição: Certificado Assinatura erro no acesso a LCR";
            msgSat[297] = "Rejeição: Assinatura difere do calculado";
            msgSat[298] = "Rejeição: Assinatura difere do padrão do Projeto";
            msgSat[299] = "Rejeição: Hora de emissão do CF-e-SAT a ser cancelado inválida";
            msgSat[402] = "Rejeição: XML da área de dados com codificação diferente de UTF-8";
            msgSat[403] = "Rejeição: Versão do leiaute do CF-e-SAT não é válida";
            msgSat[404] = "Rejeição: Uso de prefixo de namespace não permitido";
            msgSat[405] = "Alerta: Versão do leiaute do CF-e-SAT não é a mais atual";
            msgSat[406] = "Rejeição: Versão do Software Básico do SAT não é valida.";
            msgSat[407] = "Rejeição: Indicador de CF-e-SAT cancelamento inválido (diferente de „C? e „?)";
            msgSat[408] = "Rejeição: Valor total do CF-e-SAT maior que o somatório dos valores de Meio de Pagamento empregados em seu pagamento.";
            msgSat[409] = "Rejeição: Valor total do CF-e-SAT supera o máximo permitido no arquivo de Parametrização de Uso";
            msgSat[410] = "Rejeição: UF informada no campo cUF não é atendida pelo Web Service";
            msgSat[411] = "Rejeição: Campo versaoDados inexistente no elemento cfeCabecMsg do SOAP Header";
            msgSat[412] = "Rejeição: CFe de cancelamento não corresponde ao CFe anteriormente gerado";
            msgSat[420] = "Rejeição: Cancelamento para CF-e-SAT já cancelado";
            msgSat[450] = "Rejeição: Modelo da CF-e-SAT diferente de 59";
            msgSat[452] = "Rejeição: número de série do SAT inválido ou não autorizado.";
            msgSat[453] = "Rejeição: Ambiente de processamento inválido (diferente de 1 e 2)";
            msgSat[454] = "Rejeição: CNPJ da Software House inválido";
            msgSat[455] = "Rejeição: Assinatura do Aplicativo Comercial não é válida.";
            msgSat[456] = "Rejeição: Código de Regime tributário invalido";
            msgSat[457] = "Rejeição: Código de Natureza da Operação para ISSQN inválido";
            msgSat[458] = "Rejeição: Razão Social/Nome do destinatário em branco";
            msgSat[459] = "Rejeição: Código do produto ou serviço em branco";
            msgSat[460] = "Rejeição: GTIN do item (N) inválido";
            msgSat[461] = "Rejeição: Descrição do produto ou serviço em branco";
            msgSat[462] = "Rejeição: CFOP não é de operação de saída prevista para CF-e-SAT";
            msgSat[463] = "Rejeição: Unidade comercial do produto ou serviço em branco";
            msgSat[464] = "Rejeição: Quantidade Comercial do item (N) inválido";
            msgSat[465] = "Rejeição: Valor unitário do item (N) inválido";
            msgSat[466] = "Rejeição: Valor bruto do item (N) difere de quantidade * Valor Unitário, considerando regra de arred/trunc.";
            msgSat[467] = "Rejeição: Regra de calculo do item (N) inválida";
            msgSat[468] = "Rejeição: Valor do desconto do item (N) inválido";
            msgSat[469] = "Rejeição: Valor de outras despesas acessórias do item (N) inválido.";
            msgSat[470] = "Rejeição: Valor líquido do Item do CF-e difere de Valor Bruto de Produtos e Serviços - desconto + Outras Despesas Acessórias – rateio do desconto sobre subtotal + rateio do acréscimo sobre subtotal ";
            msgSat[471] = "Rejeição: origem da mercadoria do item (N) inválido (difere de 0, 1, 2, 3, 4, 5, 6 e 7)";
            msgSat[472] = "Rejeição: CST do Item (N) inválido (diferente de 00, 20, 90)";
            msgSat[473] = "Rejeição: Alíquota efetiva do ICMS do item (N) inválido.";
            msgSat[474] = "Rejeição: Valor líquido do ICMS do Item (N) difere de Valor do Item * Aliquota Efetiva";
            msgSat[475] = "Rejeição: CST do Item (N) inválido (diferente de 40 e 41 e 50 e 60)";
            msgSat[476] = "Rejeição: Código de situação da operação - Simples Nacional - do Item (N) inválido (diferente de 102, 300 e 500)";
            msgSat[477] = "Rejeição: Código de situação da operação - Simples Nacional - do Item (N) inválido (diferente de 900)";
            msgSat[478] = "Rejeição: Código de Situação Tributária do PIS Inválido (diferente de 01 e 02)";
            msgSat[479] = "Rejeição: Base de cálculo do PIS do item (N) inválido.";
            msgSat[480] = "Rejeição: Alíquota do PIS do item (N) inválido.";
            msgSat[481] = "Rejeição: Valor do PIS do Item (N) difere de Base de Calculo * Aliquota do PIS";
            msgSat[482] = "Rejeição: Código de Situação Tributária do PIS Inválido (diferente de 03)";
            msgSat[483] = "Rejeição: Qtde Vendida do item (N) inválido.";
            msgSat[484] = "Rejeição: Alíquota do PIS em R$ do item (N) inválido.";
            msgSat[485] = "Rejeição: Valor do PIS do Item (N) difere de Qtde Vendida* Aliquota do PIS em R$";
            msgSat[486] = "Rejeição: Código de Situação Tributária do PIS Inválido (diferente de 04, 06, 07, 08 e 09)";
            msgSat[487] = "Rejeição: Código de Situação Tributária do PIS inválido (diferente de 49)";
            msgSat[488] = "Rejeição: Código de Situação Tributária do PIS Inválido (diferente de 99)";
            msgSat[489] = "Rejeição: Valor do PIS do Item (N) difere de Qtde Vendida* Aliquota do PIS em R$ e difere de Base de Calculo * Aliquota do PIS";
            msgSat[490] = "Rejeição: Código de Situação Tributária da COFINS Inválido (diferente de 01 e 02)";
            msgSat[491] = "Rejeição: Base de cálculo do COFINS do item (N) inválido.";
            msgSat[492] = "Rejeição: Alíquota da COFINS do item (N) inválido.";
            msgSat[493] = "Rejeição: Valor da COFINS do Item (N) difere de Base de Calculo * Aliquota da COFINS";
            msgSat[494] = "Rejeição: Código de Situação Tributária da COFINS Inválido (diferente de 03)";
            msgSat[495] = "Rejeição: Valor do COFINS do Item (N) difere de Qtde Vendida* Aliquota do COFINS em R$ e difere de Base de Calculo * Aliquota do COFINS";
            msgSat[496] = "Rejeição: Alíquota da COFINS em R$ do item (N) inválido.";
            msgSat[497] = "Rejeição: Valor da COFINS do Item (N) difere de Qtde Vendida* Aliquota da COFINS em R$";
            msgSat[498] = "Rejeição: Código de Situação Tributária da COFINS Inválido (diferente de 04, 06, 07, 08 e 09)";
            msgSat[499] = "Rejeição: Código de Situação Tributária da COFINS Inválido (diferente de 49)";
            msgSat[500] = "Rejeição: Código de Situação Tributária da COFINS Inválido (diferente de 99)";
            msgSat[501] = "Rejeição: Operação com tributação de ISSQN sem informar a Inscrição Municipal";
            msgSat[502] = "Rejeição: Erro na Chave de Acesso - Campo Id não corresponde à concatenação dos campos correspondentes";
            msgSat[503] = "Rejeição: Valor das deduções para o ISSQN do item (N) inválido.";
            msgSat[504] = "Rejeição: Valor da Base de Calculo do ISSQN do Item (N) difere de Valor do Item - Valor das deduções";
            msgSat[505] = "Rejeição: Alíquota efetiva do ISSQN do item (N) não é maior ou igual a 2,00 (2%) e menor ou igual a 5,00 (5%).";
            msgSat[506] = "Valor do ISSQN do Item (N) difere de Valor da Base de Calculo do ISSQN * Alíquota Efetiva do ISSQN";
            msgSat[507] = "Rejeição: Indicador de rateio para ISSQN inválido";
            msgSat[508] = "Rejeição: Item da lista de Serviços do ISSQN do item (N) inválido.";
            msgSat[509] = "Rejeição: Código municipal de Tributação do ISSQN do Item (N) em branco.";
            msgSat[510] = "Rejeição: Código de Natureza da Operação para ISSQN inválido";
            msgSat[511] = "Rejeição: Indicador de Incentivo Fiscal do ISSQN do item (N) inválido (diferente de 1 e 2)";
            msgSat[512] = "Rejeição: Total do PIS difere do somatório do PIS dos itens";
            msgSat[513] = "Rejeição: Total do COFINS difere do somatório do COFINS dos itens";
            msgSat[514] = "Rejeição: Total do PIS-ST difere do somatório do PIS-ST dos itens";
            msgSat[515] = "Rejeição: Total do COFINS-STdifere do somatório do COFINS-ST dos itens";
            msgSat[516] = "Rejeição: Total de Outras Despesas Acessórias difere do somatório de Outras Despesas Acessórias (acréscimo) dos itens";
            msgSat[517] = "Rejeição: Total dos Itens difere do somatório do valor líquido dos itens";
            msgSat[518] = "Rejeição: Informado grupo de totais do ISSQN sem informar grupo de valores de ISSQN";
            msgSat[519] = "Rejeição: Total da BC do ISSQN difere do somatório da BC do ISSQN dos itens";
            msgSat[520] = "Rejeição: Total do ISSQN difere do somatório do ISSQN dos itens";
            msgSat[521] = "Rejeição: Total do PIS sobre serviços difere do somatório do PIS dos itens de serviços";
            msgSat[522] = "Rejeição: Total do COFINS sobre serviços difere do somatório do COFINS dos itens de serviços";
            msgSat[523] = "Rejeição: Total do PIS-ST sobre serviços difere do somatório do PIS-ST dos itens de serviços";
            msgSat[524] = "Rejeição: Total do COFINS-ST sobre serviços difere do somatório do COFINS-ST dos itens de serviços";
            msgSat[525] = "Rejeição: Valor de Desconto sobre total inválido.";
            msgSat[526] = "Rejeição: Valor de Acréscimo sobre total inválido.";
            msgSat[527] = "Rejeição: Código do Meio de Pagamento inválido";
            msgSat[528] = "Rejeição: Valor do Meio de Pagamento inválido.";
            msgSat[529] = "Rejeição: Valor de desconto sobre subtotal difere do somatório dos seus rateios nos itens.";
            msgSat[530] = "Rejeição: Operação com tributação de ISSQN sem informar a Inscrição Municipal";
            msgSat[531] = "Rejeição: Valor de acréscimo sobre subtotal difere do somatório dos seus rateios nos itens.";
            msgSat[532] = "Rejeição: Total do ICMS difere do somatório dos itens";
            msgSat[533] = "Rejeição: Valor aproximado dos tributos do CF-e-SAT – Lei 12741/12 inválido";
            msgSat[534] = "Rejeição: Valor aproximado dos tributos do Produto ou serviço – Lei 12741/12 inválido.";
            msgSat[535] = "Rejeição: código da credenciadora de cartão de débito ou crédito inválido";
            msgSat[537] = "Rejeição: Total do Desconto difere do somatório dos itens";
            msgSat[539] = "Rejeição: Duplicidade de CF-e-SAT, com diferença na Chave de Acesso [99999999999999999999999999999999999999999]";
            msgSat[540] = "Rejeição: CNPJ da Software House + CNPJ do emitente assinado no campo “signAC” difere do informado no campo “CNPJvalue” ";
            msgSat[555] = "Rejeição: Tipo autorizador do protocolo diverge do Órgão Autorizador";
            msgSat[564] = "Rejeição: Total dos Produtos ou Serviços difere do somatório do valor dos Produtos ou Serviços dos itens";
            msgSat[600] = "Serviço Temporariamente Indisponível";
            msgSat[601] = "CF-e-SAT inidôneo por recepção fora do prazo";
            msgSat[602] = "Rejeição: Status do equipamento não permite ativação";
            msgSat[603] = "Arquivo inválido";
            msgSat[604] = "Erro desconhecido na verificação de comandos";
            msgSat[605] = "Tamanho do arquivo inválido";
            msgSat[999] = "Rejeição: Erro não catalogado";

            msgSat[04000] = "Ativado corretamente SAT Ativado com Sucesso.";
            msgSat[04001] = "Erro na criação do certificado processo de ativação foi interrompido.";
            msgSat[04002] = "SEFAZ não reconhece este SAT (CNPJ inválido) Verificar junto a SEFAZ o CNPJ cadastrado.";
            msgSat[04003] = "SAT já ativado SAT disponível para uso.";
            msgSat[04004] = "SAT com uso cessado SAT bloqueado por cessação de uso.";
            msgSat[04005] = "Erro de comunicação com a SEFAZ Tentar novamente.";
            msgSat[04006] = "CSR ICP-BRASIL criado com sucesso Processo de criação do CSR para certificação ICP-BRASIL com sucesso";
            msgSat[04007] = "Erro na criação do CSR ICP-BRASIL Processo de criação do CSR para certificação ICP-BRASIL com erro";
            msgSat[04098] = "SAT em processamento. Tente novamente.";
            msgSat[04099] = "Erro desconhecido na ativação Informar ao administrador.";
            msgSat[05000] = "Certificado transmitido com Sucesso ";
            msgSat[05001] = "Código de ativação inválido.";
            msgSat[05002] = "Erro de comunicação com a SEFAZ. Tentar novamente.";
            msgSat[05003] = "Certificado Inválido ";
            msgSat[05098] = "SAT em processamento.";
            msgSat[05099] = "Erro desconhecido Informar o administrador.";
            msgSat[06000] = "Emitido com sucesso + conteúdo notas. Retorno CF-e-SAT ao AC para contingência.";
            msgSat[06001] = "Código de ativação inválido.";
            msgSat[06002] = "SAT ainda não ativado. Efetuar ativação.";
            msgSat[06003] = "SAT não vinculado ao AC Efetuar vinculação";
            msgSat[06004] = "Vinculação do AC não confere Efetuar vinculação";
            msgSat[06005] = "Tamanho do CF-e-SAT superior a 1.500KB";
            msgSat[06006] = "SAT bloqueado pelo contribuinte";
            msgSat[06007] = "SAT bloqueado pela SEFAZ";
            msgSat[06008] = "SAT bloqueado por falta de comunicação";
            msgSat[06009] = "SAT bloqueado, código de ativação incorreto";
            msgSat[06010] = "Erro de validação do conteúdo.";
            msgSat[06098] = "SAT em processamento.";
            msgSat[06099] = "Erro desconhecido na emissão. Informar o administrador.";
            msgSat[07000] = "Cupom cancelado com sucesso + conteúdo CF-eSAT cancelado.";
            msgSat[07001] = "Código ativação inválido Verificar o código e tentar mais uma vez.";
            msgSat[07002] = "Cupom inválido Informar o administrador.";
            msgSat[07003] = "SAT bloqueado pelo contribuinte";
            msgSat[07004] = "SAT bloqueado pela SEFAZ";
            msgSat[07005] = "SAT bloqueado por falta de comunicação";
            msgSat[07006] = "SAT bloqueado, código de ativação incorreto";
            msgSat[07007] = "Erro de validação do conteúdo";
            msgSat[07098] = "SAT em processamento.";
            msgSat[07099] = "Erro desconhecido no cancelamento.";
            msgSat[08000] = "SAT em operação. Verifica se o SAT está ativo.";
            msgSat[08098] = "SAT em processamento.";
            msgSat[08099] = "Erro desconhecido. Informar o administrador.";
            msgSat[09000] = "Emitido com sucesso Gera e envia um cupom de teste para SEFAZ, para verificar a comunicação.";
            msgSat[09001] = "código ativação inválido Verificar o código e tentar mais uma vez.";
            msgSat[09002] = "SAT ainda não ativado. Efetuar ativação ";
            msgSat[09098] = "SAT em processamento.";
            msgSat[09099] = "Erro desconhecido Informar o ";
            msgSat[10000] = "Resposta com Sucesso. Informações de status do SAT.";
            msgSat[10001] = "Código de ativação inválido";
            msgSat[10098] = "SAT em processamento.";
            msgSat[10099] = "Erro desconhecido Informar o administrador.";
            msgSat[11000] = "Emitido com sucesso Retorna o conteúdo do CF-ao AC.";
            msgSat[11001] = "código ativação inválido Verificar o código e tentar mais uma vez.";
            msgSat[11002] = "SAT ainda não ativado. Efetuar ativação.";
            msgSat[11003] = "Sessão não existe. AC deve executar a sessão novamente.";
            msgSat[11098] = "SAT em processamento.";
            msgSat[11099] = "Erro desconhecido. Informar o administrador.";
            msgSat[12000] = "Rede Configurada com Sucesso";
            msgSat[12001] = "código ativação inválido Verificar o código e tentar mais uma vez.";
            msgSat[12002] = "Dados fora do padrão a ser informado Corrigir dados";
            msgSat[12098] = "SAT em processamento.";
            msgSat[12099] = "Erro desconhecido Informar o administrador.";
            msgSat[13000] = "Assinatura do AC";
            msgSat[13001] = "código ativação inválido Verificar o código e tentar mais uma vez.";
            msgSat[13002] = "Erro de comunicação com a SEFAZ";
            msgSat[13003] = "Assinatura fora do padrão informado Corrigir dados";
            msgSat[13004] = "CNPJ da Software House + CNPJ do emitente assinado no campo “signAC” difere do informado no campo “CNPJvalue” Corrigir dados";
            msgSat[13098] = "SAT em processamento.";
            msgSat[13099] = "Erro desconhecido Informar o administrador.";
            msgSat[14000] = "Software Atualizado com Sucesso ";
            msgSat[14001] = "Código de ativação inválido.";
            msgSat[14002] = "Atualização em Andamento";
            msgSat[14003] = "Erro na atualização Não foi possível Atualizar o SAT.";
            msgSat[14004] = "Arquivo de atualização inválido";
            msgSat[14098] = "SAT em processamento.";
            msgSat[14099] = "Erro desconhecido Informar o administrador.";
            msgSat[15000] = "Transferência completa Arquivos de Logs extraídos";
            msgSat[15001] = "Código de ativação inválido.";
            msgSat[15002] = "Transferência em andamento";
            msgSat[15098] = "SAT em processamento.";
            msgSat[15099] = "Erro desconhecido Informar o administrador.";
            msgSat[16000] = "Equipamento SAT bloqueado com sucesso.";
            msgSat[16001] = "Código de ativação inválido.";
            msgSat[16002] = "Equipamento SAT já está bloqueado.";
            msgSat[16003] = "Erro de comunicação com a SEFAZ";
            msgSat[16004] = "Não existe parametrização de bloqueio disponível.";
            msgSat[16098] = "SAT em processamento.";
            msgSat[16099] = "Erro desconhecido Informar o administrador.";
            msgSat[17000] = "Equipamento SAT desbloqueado com sucesso.";
            msgSat[17001] = "Código de ativação inválido.";
            msgSat[17002] = "SAT bloqueado pelo contribuinte. Verifique configurações na SEFAZ";
            msgSat[17003] = "SAT bloqueado pela SEFAZ";
            msgSat[17004] = "Erro de comunicação com a SEFAZ";
            msgSat[17098] = "SAT em processamento.";
            msgSat[17099] = "Erro desconhecido Informar o administrador.";
            msgSat[18000] = "Código de ativação alterado com sucesso.";
            msgSat[18001] = "Código de ativação inválido.";
            msgSat[18002] = "Código de ativação de emergência Incorreto.";
            msgSat[18098] = "SAT em processamento.";
            msgSat[18099] = "Erro desconhecido Informar o administrador.";

            try
            {
                msg = msgSat[codigodeRetorno];
            }
            catch { }

            return msg;

        }

        private string retornoSAT(string chave)
        {
            string retorno = "";
            try
            {
                string[] lines = File.ReadAllLines(parametroSat("caminhosaitxt"));
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(chave + "="))
                    {
                        retorno = lines[i].Substring(chave.Length + 1);
                    }
                }
            }
            catch { retorno = "Erro Monitor"; }

            return retorno;
        }

        public void finaliza()
        {
            if (Encerrou != "Sim")
            {
                if (decimal.Parse(txtTotalRestante.Text) < 0)
                {
                    throw new Exception("Faça o pagamento TOTAL!");
                }
                else
                {
                    Boolean emissao_cupom = criarSAT();

                }
            }
            Parent.Controls.Find("lblCpf", false).First().Text = "";
        }

    }
}
