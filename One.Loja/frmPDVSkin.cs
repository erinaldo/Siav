using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using One.Bll;
using One.Dal;
//using ImprimeCupom;
using One.FrenteDeLoja;
using One.RELATORIOS;
using System.Globalization;
using One.Loja;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
//using One.CADASTROS;
using One.Cadastros_Casa_De_Negocio;
//using LFi.Control.Laçanmento_Financeiro;
using DataAccessLayer.Dal;
using System.Text.RegularExpressions;
using System.Threading;
using System.Media;
//using ImprimeCupom;

namespace One.MOVIMENTACOES
{
    public partial class frmPDVSkin : Form
    {
        Contexto con = null;
        #region Conecta na dll para buscar dos dados da balança

        [DllImport("P05.dll")]
        public static extern int AbrePorta(int Porta, int BaudRate, int DataBits, int Paridade);

        [DllImport("P05.dll")]
        public static extern int FechaPorta();

        [DllImport("P05.dll")]
        public static extern int PegaPeso(int OpcaoEscrita, byte[] DadosPeso, string Local);

        private static bool PortaAberta = false;
        public int EnterMesa = 0;
        private struct CONSTANTES
        {
            public const int porta = 2; //COM2
            public const int baudRate = 2; //9600
            public const int dataBits = 1; // 8 Bits
            public const int paridade = 0; //Nenhum
            public const string ArquivoSinalizacao = "OK.TXT";

        }
        //Lancamento lan = new Lancamento();
        public static string ListaBytesParaString(byte[] lista)
        {
            char[] retornoChar = new char[lista.Length];
            for (int i = 0; i < lista.Length; i++)
                retornoChar[i] = (char)lista[i];
            string retorno = new string(retornoChar);
            return retorno;
        }


        /*
         * 
            1o. Parâmetro = Porta COM => 1=COM 1, 2=COM 2, 3=COM 3, 4=COM 4
            2o. Parâmetro = BaudRate => 0 = 2400, 1 = 4800, 2 = 9600, 3 = 1200
            3o. Parâmetro = Data Bits=> 0 = 7 bits, 1 = 8 bits
            4o. Parâmetro = Paridade=> 0=Nenhum, 1=Ímpar, 2=Par, 3=Espaço
            5o. Parâmetro = Disponibilizar em => 0 = Arq Texto, 1 = Área de Transferência
            6o. Parâmetro = Diretório onde será gravado o arquivo.
            7o. Parâmetro = Tipo de leitura => 0=P05/P05A, 1=P05B sem tara, 2=P05B com tara
            8o. Parâmetro = Utilizar 1 stop bit => 0=não utiliza; 1=utliliza (Opcional)
         * 
        [DllImport(@"C:\One\DllToledo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int Open(int ComNumber, int Baud, string Parity, int StopBits, int TriggerLength);

        [DllImport(@"C:\One\DllToledo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern float Get();

        [DllImport(@"C:\One\DllToledo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern float Close();

        [DllImport(@"C:\One\DllToledo.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        static extern int Test(int ComNumber, int Baud, string Parity, int StopBits, int TriggerLength);
       
        
           comandos     
         * private void abrir porta(object sender, EventArgs e)
                {
                    Open(1, 4800, "Even", 1, 17);
                }

                private void pegapeso(object sender, EventArgs e)
                {
                    float Peso = Get();
                }

                private void fechaporta(object sender, EventArgs e)
                {
                    Close();
                }

                private void teste(object sender, EventArgs e)
                {
                    Test(1, 4800, "Even", 1, 17);
                }

                 * */


        #endregion

        bool podeAlterar = false;
        public bool epeso = false;
        public bool AlterarPeso = false;
        public bool javiu { get; set; }
        public decimal Tara { get; set; }
        public bool cancelouFpg { get; set; }
        public string NumeroDoPedido { get; set; }
        public int ItemRemove { get; set; }
        public int CountItem { get; set; }

        //controle de inserção no grid
        private bool Inserindo = false;

        #region Configurações do PDV
        public void OnePDV()
        {
            DataTable tab = null;
            tab = OnePDV_ConfigSQL();
            if (tab.Rows[0]["Impressora"].ToString() == "Outras")
            {
                ckModoImpressao.Checked = false;
            }
            else if (tab.Rows[0]["Impressora"].ToString() != "Outras")
            {
                ckModoImpressao.Checked = true;
            }
            if (tab.Rows[0]["Balança"].ToString() != "")
            {
                lblNomeBalanca.Text = tab.Rows[0]["Balança"].ToString();
            }
            if (tab.Rows[0]["MensagemCupom"].ToString() != "")
            {
                lblMsgCupom.Text = tab.Rows[0]["MensagemCupom"].ToString();
            }
            tab = null;
        }

        private DataTable OnePDV_ConfigSQL()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("Select * From OnePDV");
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            con = null;
            return tab;
        }

        #endregion

        public frmPDVSkin(string Pedido)
        {
            InitializeComponent();
            NumeroDoPedido = Pedido;

            #region Carregar PDV 1280 X 720
            //this.WindowState = FormWindowState.Maximized;
            //this.Width = 1280;
            //this.Height = 720;

            //Point point = new Point(431, 34);
            //lblInfo.Location = point;

            //Point p1 = new Point(635, 143);
            //txtCabecalhoCupom.Location = p1;

            //Point p2 = new Point(644, 212);
            //lblLinhaCupom.Location = p2;

            //Point p3 = new Point(632, 233);
            //lblDataEHora.Location = p3;

            //Point p4 = new Point(866, 230);
            //lblCupom.Location = p1;

            //Point p5 = new Point(1082, 232);
            //lblTot.Location = p5;

            //Point p6 = new Point(1147, 229);
            //txtTotalItens.Location = p6;

            //Point p7 = new Point(210, 353);
            //txtTotalFinal.Location = p7;

            //Point p8 = new Point(633, 250);
            //dgDados.Location = p8;

            //Point p9 = new Point(61, 522);
            //txtCodigoBarra.Location = p9;

            //Point p10 = new Point(450, 503);
            //txtQuantidade.Location = p10;

            //Point p11 = new Point(624, 503);
            //txtValorUnitario.Location = p11;

            //Point p12 = new Point(946, 503);
            //txtSubtotal.Location = p12;

            //Point p13 = new Point(138, 618);
            //txtNomeProduto.Location = p13;

            //Point p14 = new Point(55, 618);
            //txtDinamic.Location = p14;
            #endregion

            //this.WindowState = FormWindowState.Maximized;


        }

        VendasBLL objVen = new VendasBLL();
        vendaItensBLL objVI = new vendaItensBLL();

        public void SetaCodigovenda()
        {
            txtCodigo.Text = NumeroDoPedido;
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Visible = false;
                cancelouFpg = false;
                txtLocalizarMesa.Text = "";
                txtPesoBruto.Text = "";
                cbFuncionario.SelectedValue = global.codUsuario;
                txtObservacao.Visible = false;
                txtCodigo.Text = "";
                txtData.Text = DateTime.Now.ToString();
                txtObservacao.Text = "";
                txtQuantidade.Text = "";
                txtSubtotal.Text = "";
                txtTotalFinal.Text = "";
                txtTotalItens.Text = "";
                txtValorUnitario.Text = "";
                txtNomeProduto.Text = "";
                dgDados.Rows.Clear();
                txtDescontoValor.Text = "";
                txtDesconto.Text = "";
                txtValorTotal.Text = "";
                txtDescontoPercentual.Text = "";
                txtDescontoValor.Text = "";
                txtSubtotal.Text = "";
                txtPercentual.Text = "";
                txtQuantidade.Text = "";
                txtQuantidadeTotal.Text = "";
                txtCodigoBarra.Text = "";
                cbTipoVenda.SelectedIndex = 0;
                btnAlterarTipoVenda.Enabled = true;
                cbTipoVenda.Enabled = true;
                txtValorUnitario.Enabled = true;
                txtQuantidade.Enabled = true;
                cbRenovarVenda.Checked = true;
                txtDescontoPercentual.Enabled = true;
                txtDescontoValor.Enabled = true;
                txtTicket.Text = "0";
                txtTara.Text = "0";
                txtCodigoCliente.Text = "1";
                txtDinamic.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void carregaPropriedadesAntProxPrimUlt()
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValorTotal.Text.Length - 1; i++)
                {
                    if ((txtValorTotal.Text[i] >= '0' &&
                    txtValorTotal.Text[i] <= '9') ||
                    txtValorTotal.Text[i] == ',')
                    {
                        x += txtValorTotal.Text[i];
                    }
                }
                txtValorTotal.Text = x;

                x = "";
                for (int i = 0; i <= txtTotalFinal.Text.Length - 1; i++)
                {
                    if ((txtTotalFinal.Text[i] >= '0' &&
                    txtTotalFinal.Text[i] <= '9') ||
                    txtTotalFinal.Text[i] == ',')
                    {
                        x += txtTotalFinal.Text[i];
                    }
                }
                txtTotalFinal.Text = x;

                x = "";
                for (int i = 0; i <= txtDescontoValor.Text.Length - 1; i++)
                {
                    if ((txtDescontoValor.Text[i] >= '0' &&
                    txtDescontoValor.Text[i] <= '9') ||
                    txtDescontoValor.Text[i] == ',')
                    {
                        x += txtDescontoValor.Text[i];
                    }
                }
                txtDescontoValor.Text = x;


                //Vendas
                if (txtCodigo.Text != "")
                    objVen.codigo = int.Parse(txtCodigo.Text);
                else
                    objVen.codigo = 0;
                txtData.Text = txtData.Text.Trim();
                if (txtData.Text != "")
                    objVen.data = DateTime.Parse(txtData.Text);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacao.Text = txtObservacao.Text.Trim();
                if (txtObservacao.Text != "")
                    objVen.observacao = txtObservacao.Text;
                else
                    objVen.observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a venda");
                else
                    objVen.usuario = int.Parse(cbFuncionario.SelectedValue.ToString());

                if (txtDescontoPercentual.Text == "")
                    objVen.percentual = 0;
                else
                    objVen.percentual = decimal.Parse(txtDescontoPercentual.Text);

                if (txtDescontoValor.Text == "")
                    objVen.desconto = 0;
                else
                    objVen.desconto = decimal.Parse(txtDescontoValor.Text);


                objVen.valor = decimal.Parse(txtValorTotal.Text);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text);

                objVen.ven_ticket = int.Parse(txtTicket.Text);

                if (cbRenovarVenda.Checked == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda.Checked == false)
                    objVen.ven_status = "Cancelado";
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
                for (int i = 0; i <= txtValorTotal.Text.Length - 1; i++)
                {
                    if ((txtValorTotal.Text[i] >= '0' &&
                    txtValorTotal.Text[i] <= '9') ||
                    txtValorTotal.Text[i] == ',')
                    {
                        x += txtValorTotal.Text[i];
                    }
                }
                txtValorTotal.Text = x;

                x = "";
                for (int i = 0; i <= txtTotalFinal.Text.Length - 1; i++)
                {
                    if ((txtTotalFinal.Text[i] >= '0' &&
                    txtTotalFinal.Text[i] <= '9') ||
                    txtTotalFinal.Text[i] == ',')
                    {
                        x += txtTotalFinal.Text[i];
                    }
                }
                txtTotalFinal.Text = x;

                x = "";
                for (int i = 0; i <= txtDescontoValor.Text.Length - 1; i++)
                {
                    if ((txtDescontoValor.Text[i] >= '0' &&
                    txtDescontoValor.Text[i] <= '9') ||
                    txtDescontoValor.Text[i] == ',')
                    {
                        x += txtDescontoValor.Text[i];
                    }
                }
                txtDescontoValor.Text = x;


                //Vendas
                if (txtCodigo.Text != "")
                    objVen.codigo = int.Parse(txtCodigo.Text);
                else
                    objVen.codigo = 0;
                txtData.Text = txtData.Text.Trim();
                if (txtData.Text != "")
                    objVen.data = DateTime.Parse(txtData.Text);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacao.Text = txtObservacao.Text.Trim();
                if (txtObservacao.Text != "")
                    objVen.observacao = txtObservacao.Text;
                else
                    objVen.observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a venda");
                else
                    objVen.usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
                //if (cbCliente.SelectedValue == null)
                objVen.cliente = int.Parse(txtCodigoCliente.Text);//int.Parse("23");


                if (txtDescontoPercentual.Text == "")
                    objVen.percentual = 0;
                else
                    objVen.percentual = decimal.Parse(txtDescontoPercentual.Text);

                if (txtDescontoValor.Text == "")
                    objVen.desconto = 0;
                else
                    objVen.desconto = decimal.Parse(txtDescontoValor.Text);

                objVen.valor = decimal.Parse(txtValorTotal.Text);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text);

                objVen.ven_ticket = int.Parse(txtTicket.Text);

                lblInfo.Text = "V E N D A  F I N A L I Z A";
                if (cbRenovarVenda.Checked == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda.Checked == false)
                    objVen.ven_status = "Cancelado";

                objVen.ven_tipo = cbTipoVenda.SelectedItem.ToString();

                objVen.IDAber = int.Parse(lblCodigoAbertura.Text.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaPropriedadesCondicional()
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValorTotal.Text.Length - 1; i++)
                {
                    if ((txtValorTotal.Text[i] >= '0' &&
                    txtValorTotal.Text[i] <= '9') ||
                    txtValorTotal.Text[i] == ',')
                    {
                        x += txtValorTotal.Text[i];
                    }
                }
                txtValorTotal.Text = x;

                x = "";
                for (int i = 0; i <= txtTotalFinal.Text.Length - 1; i++)
                {
                    if ((txtTotalFinal.Text[i] >= '0' &&
                    txtTotalFinal.Text[i] <= '9') ||
                    txtTotalFinal.Text[i] == ',')
                    {
                        x += txtTotalFinal.Text[i];
                    }
                }
                txtTotalFinal.Text = x;

                x = "";
                for (int i = 0; i <= txtDescontoValor.Text.Length - 1; i++)
                {
                    if ((txtDescontoValor.Text[i] >= '0' &&
                    txtDescontoValor.Text[i] <= '9') ||
                    txtDescontoValor.Text[i] == ',')
                    {
                        x += txtDescontoValor.Text[i];
                    }
                }
                txtDescontoValor.Text = x;
                //Vendas
                if (txtCodigo.Text != "")
                    objVen.codigo = int.Parse(txtCodigo.Text);
                else
                    objVen.codigo = 0;
                txtData.Text = txtData.Text.Trim();
                if (txtData.Text != "")
                    objVen.data = DateTime.Parse(txtData.Text);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacao.Text = txtObservacao.Text.Trim();
                if (txtObservacao.Text != "")
                    objVen.observacao = txtObservacao.Text;
                else
                    objVen.observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a venda");
                else
                    objVen.usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
                if (txtCodigoCliente.Text != "")
                    objVen.cliente = int.Parse(txtCodigoCliente.Text);

                if (txtDescontoPercentual.Text == "")
                    objVen.percentual = 0;
                else
                    objVen.percentual = decimal.Parse(txtDescontoPercentual.Text);

                if (txtDescontoValor.Text == "")
                    objVen.desconto = 0;
                else
                    objVen.desconto = decimal.Parse(txtDescontoValor.Text);

                objVen.valor = decimal.Parse(txtValorTotal.Text);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text);

                objVen.ven_ticket = int.Parse(txtTicket.Text);


                objVen.forma_pagamento = 0;
                objVen.parcelas = 0;
                objVen.cliente = int.Parse(txtCodigoCliente.Text);

                if (cbRenovarVenda.Checked == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda.Checked == false)
                    objVen.ven_status = "Cancelado";

                objVen.ven_tipo = cbTipoVenda.SelectedItem.ToString();
                objVen.IDAber = int.Parse(lblCodigoAbertura.Text.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaPropriedadesAlterar()
        {
            // Cria uma instância com as configurações da cultura brasileira (formatos)
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
            //objVen.valorFinal = decimal.Parse(txtTotalFinal.Text, NumberStyles.Currency, culturaBrasileira);
            try
            {
                if (txtCodigo.Text != "")
                    objVen.codigo = int.Parse(txtCodigo.Text);
                else
                    objVen.codigo = 0;
                objVen.localizar(objVen.codigo.ToString(), "ven_codigo");
                //setando valores originais da venda e não da consulta 
                objVen.cliente = int.Parse(txtCodigoCliente.Text);
                objVen.valor = decimal.Parse(txtValorTotal.Text, NumberStyles.Currency, culturaBrasileira);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text, NumberStyles.Currency, culturaBrasileira);
                //
                if (cbRenovarVenda.Checked == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda.Checked == false)
                    objVen.ven_status = "Cancelado";
                if (cbTipoVenda.SelectedIndex == 0)
                    objVen.ven_tipo = "Venda";
                else if (cbTipoVenda.SelectedIndex == 1)
                    objVen.ven_tipo = "Orçamento";
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
                txtCodigo.Text = objVen.codigo.ToString();
                txtData.Text = objVen.data.ToString();
                txtCodigoCliente.Text = objVen.cliente.ToString();
                cbFuncionario.SelectedValue = objVen.usuario;
                //objVen.forma_pagamento;
                //objVen.parcelas = 0;
                txtValorTotal.Text = objVen.valor.ToString();
                txtTotalFinal.Text = objVen.valorFinal.ToString();
                txtObservacao.Text = objVen.observacao;
                txtDescontoValor.Text = objVen.desconto.ToString();
                txtDescontoPercentual.Text = objVen.percentual.ToString();

                //carrega produtos Venda
                DataTable tab = objVI.localizarLeaveComRetorno(objVen.codigo.ToString(), "ven_codigo");
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    ProdutosBLL objPro = new ProdutosBLL();
                    objPro.localizar(tab.Rows[i][1].ToString(), "pro_codigo");

                    dgDados.Rows.Add(
                        tab.Rows[i][0].ToString(),
                        tab.Rows[i][1].ToString(),
                        objPro.pro_nome, tab.Rows[i][2].ToString(),
                        Convert.ToDecimal(tab.Rows[i][3].ToString()).ToString(),
                        Convert.ToDecimal(tab.Rows[i][4].ToString()).ToString(),
                        //  Convert.ToDecimal(tab.Rows[i][5].ToString()).ToString(),
                        tab.Rows[i][8].ToString()
                        );

                    objPro = null;
                }

                decimal qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += decimal.Parse(dgDados.Rows[i].Cells[3].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();

                txtDescontoValor.Text = Convert.ToDecimal(txtDescontoValor.Text).ToString();
                txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString();
                txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();

                txtTicket.Text = objVen.ven_ticket.ToString();

                if (objVen.ven_ticket.ToString() != "0")
                {
                    lblMsgMesa.Text = String.Concat("Mesa|Ticket Número : ", objVen.ven_ticket.ToString(), " selecionado");
                }

                if (objVen.ven_status == "Cancelado")
                {
                    lblInfo.Visible = true;
                    // cbRenovarVenda.Visible = true;
                    cbRenovarVenda.Checked = false;
                }
                else
                {
                    //lblInfo.Visible = false;
                    cbRenovarVenda.Visible = false;
                    //cbRenovarVenda.Checked = true;
                }

                cbTipoVenda.SelectedItem = objVen.ven_tipo;
                if (cbTipoVenda.SelectedIndex == 0)
                {
                    btnAlterarTipoVenda.Enabled = false;
                    //  cbTipoVenda.Enabled = false;
                }
                else if (cbTipoVenda.SelectedIndex == 1)
                {
                    btnAlterarTipoVenda.Enabled = true;
                    ckdVendaPendente.Checked = true;
                    ckdVenda.Checked = false;
                    // cbTipoVenda.Enabled = false;
                }

                txtDescontoPercentual.Enabled = false;
                txtDescontoValor.Enabled = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void LançamentoEstoqueProduto(string Tipo, int produtoID, DateTime DataLancamento, string DescricaoProduto, int UsuarioID, string NomeUsuario, decimal? Quantidade, string Motivo)
        {
            try
            {
                SqlCommand cmd = null;

                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Insert into EstoqueProdutos (Tipo,DataLancamento,ProdutoID,DescricaoProduto,UsuarioID,NomeUsuario,Quantidade,Motivo)"
                    , "values (@Tipo,@DataLancamento,@ProdutoID,@DescricaoProduto,@UsuarioID,@NomeUsuario,@Quantidade,@Motivo)"
                    );
                cmd.Parameters.Add(new SqlParameter("@DataLancamento", SqlDbType.DateTime)).Value = DataLancamento;
                cmd.Parameters.Add(new SqlParameter("@ProdutoID", SqlDbType.Int)).Value = produtoID;
                cmd.Parameters.Add(new SqlParameter("@DescricaoProduto", SqlDbType.VarChar)).Value = DescricaoProduto;
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = UsuarioID;
                cmd.Parameters.Add(new SqlParameter("@NomeUsuario", SqlDbType.VarChar)).Value = NomeUsuario;
                cmd.Parameters.Add(new SqlParameter("@Quantidade", SqlDbType.Int)).Value = Quantidade;
                cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar)).Value = Motivo;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar)).Value = Tipo;

                con.ExecutaComando(cmd);
                cmd = null;
                con = null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void insereProdutosVenda()
        {
            try
            {
                //altera (exclui)
                objVI.ven_codigo = objVen.codigo;
                objVI.excluir();

                //itensVendas
                for (int i = 0; i < dgDados.Rows.Count; i++)
                {

                    //e depois insere
                    objVI.ven_codigo = objVen.codigo;
                    objVI.pro_codigo = int.Parse(dgDados.Rows[i].Cells[1].Value.ToString());
                    objVI.vi_quantidade = decimal.Parse(dgDados.Rows[i].Cells[3].Value.ToString());

                    String valorUnitario = dgDados.Rows[i].Cells[4].Value.ToString();

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
                    objVI.vi_valorUnitario = decimal.Parse(valorUnitario);

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
                    objVI.vi_subtotal = decimal.Parse(subtotal);

                    // Inserir a tara 
                    if (dgDados.Rows[i].Cells[6].Value.ToString() == "")
                    {
                        objVI.vi_tara = "0,0g";
                    }
                    else
                    {
                        objVI.vi_tara = dgDados.Rows[i].Cells[6].Value.ToString();
                    }


                    objVI.inserir(); //inserir Produtos da Venda
                    //Lancamento Estoque
                    LançamentoEstoqueProduto("SAIDA", objVI.pro_codigo, DateTime.Now, txtNomeProduto.Text, global.codUsuario, global.nomeUsuario, objVI.vi_quantidade, "VENDA PDV");

                    if (objVen.ven_tipo == "Venda")
                    {
                        ProdutosBLL objPro = new ProdutosBLL();
                        objPro.localizar(objVI.pro_codigo.ToString(), "pro_codigo");
                        objPro.pro_quantidade = objPro.pro_quantidade - objVI.vi_quantidade;
                        objPro.alterarQuantidade();
                        objPro = null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ajustarColunasGrid()
        {
            dgDados.AutoResizeColumns();
            dgDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            foreach (DataGridViewColumn column in dgDados.Columns)
            {
                if (column.DataPropertyName == "DESCRIÇÂO")
                    column.Width = 150; //tamanho fixo da primeira coluna

                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public void AbriCaixa()
        {
            try
            {
                //AbrircaixaAntigo();
                AberturaCaixaBLL objAber = new AberturaCaixaBLL();
                int usuario = objAber.usuario = global.codUsuario;
                objAber.usuario = global.codUsuario;
                objAber.data = DateTime.Now.Date;
                objAber.hora = TimeSpan.FromHours(DateTime.Now.Hour) + TimeSpan.FromMinutes(DateTime.Now.Minute) + TimeSpan.FromSeconds(DateTime.Now.Second);
                String valorString = "";
                decimal valor = 0;
                frmAberturaDeCaixa frm = new frmAberturaDeCaixa();
                frm.ShowDialog();
                valorString = frm.ValorInicial.ToString();
                do
                {
                    if (valorString == "")
                        MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                    else
                    {
                        decimal.TryParse(valorString, out valor);
                        if (valor == 0)
                            MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                    }
                } while (valorString == "" || valor == 0);
                objAber.usuario = global.codUsuario;
                objAber.data = DateTime.Now.Date;
                String hora = DateTime.Now.TimeOfDay.ToString();
                objAber.hora = TimeSpan.Parse(hora);
                objAber.valor = valor;
                objAber.caixa = lblNumerCaixa.Text.ToString();
                objAber.inserir();
                //if (MessageBox.Show("Deseja Imprimir o valor do Fundo de Caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                //{
                //
                //    ImprimeTexto imp = new ImprimeTexto();
                //    //
                //    //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
                //    imp.Inicio("LPT1");
                //    //
                //    imp.ImpLF(imp.NegritoOn + "ABERTURA DE CAIXA" + imp.NegritoOff);
                //    imp.ImpLF("-------------------------------------");
                //    imp.Pula(1);
                //    imp.ImpLF("Valor Inicial:" + valor.ToString());
                //    imp.ImpLF("Usuário: " + global.nomeUsuario);
                //    imp.ImpLF("Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString());
                //    imp.Pula(2);
                //    imp.Fim();
                //
                //    // String aux = "Data: " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year
                //    //    + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //    // imp.ImpLF(aux);
                //    // imp.ImpLF("Operador:" + lUsuario.Text);
                //
                //  // DataTable tab = null;
                //  // tab = carregaeEncerramentoCaixa();
                //  //
                //  // if (tab.Rows.Count > 0)
                //  // {
                //  //     //TotalFinal = decimal.Parse(tab.Rows[3]["Tipo"].ToString());
                //  //     for (int i = 0; i <= tab.Rows.Count - 1; i++)
                //  //     {
                //  //
                //  //         String v = tab.Rows[i]["Tipo"].ToString().Replace("*", "");
                //  //         v = v.Replace("$ )", "$)");
                //  //
                //  //         imp.ImpLF(v);
                //  //         imp.ImpLF(tab.Rows[i]["Valor R$"].ToString());
                //  //     }
                //  //     imp.ImpLF("---------------------");
                //  //     imp.Pula(2);
                //  //     imp.Fim();
                //  // }
                //
                //
                //
                //
                //
                //
                //    //int iRetorno;
                //    //String impressora;
                //    //iRetorno = MP2032.ConfiguraModeloImpressora(8);
                //    //string porta = "USB";//cbPorta.SelectedItem.ToString(); //pega a seleção da combo 
                //    //if (porta == "ETHERNET")
                //    //{
                //    //    iRetorno = MP2032.IniciaPorta(""); //inicia a porta com o IP digitado
                //    //}
                //    //else
                //    //{
                //    //    iRetorno = MP2032.IniciaPorta("USB");//inicia a porta com o valor da combo (exceto ethernet)
                //    //}
                //    //
                //    //if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
                //    //{
                //    //    //  lblInfo.Text = ("Não foi possível conectar com a impressora!!!");
                //    //    // Application.Exit();
                //    //}
                //    //else
                //    //{
                //    //    // lblInfo.Text = ("Impressora conectada!!!");
                //    //}
                //    //ImprimeTexto imp = new ImprimeTexto();
                //    //impressora = "Abertura do Caixa " + Environment.NewLine;
                //    //impressora += "Valor Inicial:" + valor.ToString() + Environment.NewLine;
                //    //// impressora += "_______________________" + Environment.NewLine;
                //    //impressora += "Usuário: " + global.nomeUsuario + Environment.NewLine;
                //    //impressora += "Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString() + Environment.NewLine;
                //    //impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                //    //impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                //    //
                //    //iRetorno = MP2032.FormataTX(impressora + "\r\n\r\n", 3, 0, 0, 1, 1);
                //    //// iRetorno = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AbrircaixaAntigo()
        {
            //Se lo caixa estiver encerrado que pode abrir outro
            lblNumerCaixa.Text = global.NumeroCaixa.ToString();

            // throw new Exception("Fechamento diário já foi realizado");
            AberturaCaixaBLL objAber = new AberturaCaixaBLL();
            int usuario = objAber.usuario = global.codUsuario;
            //verifica se nunca entrou no sistema (1º vez geral)
            //Metodo pega o codigo da abertura do caixa
            objAber.isPrimeiraVez(usuario);
            if (objAber.codigo > 0)
            {
                objAber.limpar();
                //não é a primeira vez geral
                objAber.isPrimeiraVezDia(usuario);
                objAber.isPrimeiraVezFechou(usuario);
                if (objAber.codigo != 0 || objAber.fechou == "1") //é a primeira vez do dia
                {
                    objAber.usuario = global.codUsuario;
                    objAber.data = DateTime.Now.Date;
                    objAber.hora = TimeSpan.FromHours(DateTime.Now.Hour) + TimeSpan.FromMinutes(DateTime.Now.Minute) + TimeSpan.FromSeconds(DateTime.Now.Second);

                    String valorString = "";
                    decimal valor = 0;
                    frmAberturaDeCaixa frm = new frmAberturaDeCaixa();
                    frm.ShowDialog();
                    valorString = frm.ValorInicial.ToString();
                    do
                    {
                        //valorString = Interaction.InputBox("Informe o Fundo de Caixa", "Abertura de Caixa", "", this.Width - this.Width / 2 - 200, this.Height - this.Height / 2 - 150);
                        if (valorString == "")
                            MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                        else
                        {
                            decimal.TryParse(valorString, out valor);
                            if (valor == 0)
                                MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                        }
                    } while (valorString == "" || valor == 0);
                    objAber.usuario = global.codUsuario;
                    objAber.data = DateTime.Now.Date;
                    String hora = DateTime.Now.TimeOfDay.ToString();
                    objAber.hora = TimeSpan.Parse(hora);
                    objAber.valor = valor;
                    objAber.caixa = lblNumerCaixa.Text.ToString();
                    objAber.inserir();
                    //if (MessageBox.Show("Deseja Imprimir o valor do Fundo de Caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    //{
                    //    int iRetorno;
                    //    String impressora;
                    //    iRetorno = MP2032.ConfiguraModeloImpressora(8);
                    //    string porta = "USB";//cbPorta.SelectedItem.ToString(); //pega a seleção da combo 
                    //    if (porta == "ETHERNET")
                    //    {
                    //        iRetorno = MP2032.IniciaPorta(""); //inicia a porta com o IP digitado
                    //    }
                    //    else
                    //    {
                    //        iRetorno = MP2032.IniciaPorta("USB");//inicia a porta com o valor da combo (exceto ethernet)
                    //    }
                    //
                    //    if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
                    //    {
                    //        // lblInfo.Text = ("Não foi possível conectar com a impressora!!!");
                    //        // Application.Exit();
                    //    }
                    //    else
                    //    {
                    //        // lblInfo.Text = ("Impressora conectada!!!");
                    //    }
                    //
                    //    ImprimeTexto imp = new ImprimeTexto();
                    //    //
                    //    //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
                    //    imp.Inicio("LPT1");
                    //    //
                    //    imp.ImpLF(imp.NegritoOn + "ABERTURA DE CAIXA" + imp.NegritoOff);
                    //    imp.ImpLF("-------------------------------------");
                    //    imp.Pula(1);
                    //    imp.ImpLF("Valor Inicial:" + valor.ToString());
                    //    imp.ImpLF("Usuário: " + global.nomeUsuario);
                    //    imp.ImpLF("Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString());
                    //    imp.Pula(2);
                    //    imp.Fim();
                    //
                    //   // ImprimeTexto imp = new ImprimeTexto();
                    //   // impressora = "Abertura do Caixa " + Environment.NewLine;
                    //   // impressora += "Valor Inicial:" + valor.ToString() + Environment.NewLine;
                    //   // // impressora += "_______________________" + Environment.NewLine;
                    //   // impressora += "Usuário: " + global.nomeUsuario + Environment.NewLine;
                    //   // impressora += "Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString() + Environment.NewLine;
                    //   // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                    //   // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                    //   //
                    //   // iRetorno = MP2032.FormataTX(impressora + "\r\n\r\n", 3, 0, 0, 1, 1);
                    //    // iRetorno = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
                    //}
                }
            }
            else //primeira vez!!!!!!!!
            {

                //primeira vez, então registrar um insert
                String valorString = "";
                decimal valor = 0;
                frmAberturaDeCaixa frm = new frmAberturaDeCaixa();
                frm.ShowDialog();
                valorString = frm.ValorInicial.ToString();
                do
                {
                    //  valorString = Interaction.InputBox("Informe o Fundo de Caixa", "Abertura de Caixa", "", this.Width - this.Width / 2 - 200, this.Height - this.Height / 2 - 150);
                    if (valorString == "")
                        MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                    else
                    {
                        decimal.TryParse(valorString, out valor);
                        if (valor == 0)
                            MessageBox.Show("Valor de abertura deve ser um número maior do que 0");
                    }
                }
                while (valorString == "" || valor == 0);
                objAber.usuario = global.codUsuario;
                objAber.data = DateTime.Now.Date;
                String hora = DateTime.Now.TimeOfDay.ToString();
                objAber.hora = TimeSpan.Parse(hora);
                objAber.valor = valor;
                objAber.caixa = lblNumerCaixa.Text;
                objAber.inserir();
               // if (MessageBox.Show("Deseja Imprimir o valor do Fundo de Caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
               // {
               //     //Declarando as Variaveis 
               //     int iRetorno; // Configurar Modelo da Impressora
               //     String impressora; // Impressora
               //     iRetorno = MP2032.ConfiguraModeloImpressora(8); // Configurar Modelo da Impressora 
               //     string porta = "USB";//cbPorta.SelectedItem.ToString(); //pega a seleção da combo 
               //     if (porta == "ETHERNET")
               //     {
               //         iRetorno = MP2032.IniciaPorta(""); //inicia a porta com o IP digitado
               //     }
               //     else
               //     {
               //         iRetorno = MP2032.IniciaPorta("USB");//inicia a porta com o valor da combo (exceto ethernet)
               //     }
               //
               //     if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
               //     {
               //         //  lblInfo.Text = ("Não foi possível conectar com a impressora!!!");
               //         // Application.Exit();
               //     }
               //     else
               //     {
               //         //lblInfo.Text = ("Impressora conectada!!!");
               //     }
               //
               //     ImprimeTexto imp = new ImprimeTexto();
               //     //
               //     //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
               //     imp.Inicio("LPT1");
               //     //
               //     imp.ImpLF(imp.NegritoOn + "ABERTURA DE CAIXA" + imp.NegritoOff);
               //     imp.ImpLF("-------------------------------------");
               //     imp.Pula(1);
               //     imp.ImpLF("Valor Inicial:" + valor.ToString());
               //     imp.ImpLF("Usuário: " + global.nomeUsuario);
               //     imp.ImpLF("Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString());
               //     imp.Pula(2);
               //     imp.Fim();
               //
               //     //ImprimeTexto imp = new ImprimeTexto();
               //     //impressora = "Abertura do Caixa " + Environment.NewLine;
               //     //impressora += "Valor Inicial:" + valor.ToString() + Environment.NewLine;
               //     //// impressora += "_______________________" + Environment.NewLine;
               //     //impressora += "Usuário: " + global.nomeUsuario + Environment.NewLine;
               //     //impressora += "Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString() + Environment.NewLine;
               //     //impressora += "               " + Environment.NewLine;  //+ valor.ToString();
               //     //impressora += "               " + Environment.NewLine;  //+ valor.ToString();
               //     //
               //     //iRetorno = MP2032.FormataTX(impressora + "\r\n\r\n", 3, 0, 0, 1, 1);
               //     // iRetorno = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
               // }
            }
            ObterIDAbertura();
        }

        public void carregacombo()
        {
            try
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbFuncionario, "Usuario", "usu_codigo", "usu_nome", "", "usu_nome");
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        Button btn = null;
        Button btnCat = null;
        Label label = null;
        int posVert = 0;

        public DataTable CarregarProdutosPesoSQL(int ProdutoID)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * From Produtos prod ",
                    " join unidades unid on unid.uni_codigo = prod.pro_unidade where prod.pro_quantidade > 0 and prod.pro_codigo = @ProdutoID ",
                " and UNID.uni_descricao = 'KG'");
                //" Where pro_codigo = @id");
                cmd.Parameters.Add(new SqlParameter("@ProdutoID", SqlDbType.Int)).Value = ProdutoID;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable CarregarProdutosSQL(int CatID)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * From Produtos where pro_quantidade > 0 and pro_categoria = @CatID");
                //" Where pro_codigo = @id");
                cmd.Parameters.Add(new SqlParameter("@CatID", SqlDbType.Int)).Value = CatID;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public DataTable CarregarCategoriasSQL()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * From Categoria");
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        public void ObterPesoMagna()
        {
            try
            {
                ACBrFramework.BAL.ACBrBAL Balanca = new ACBrFramework.BAL.ACBrBAL();
                Balanca.Modelo = (ACBrFramework.BAL.ModeloBal.Magna);
                Balanca.Porta = "COM2";  //(string)portabalanca //
                // MessageBox.Show("Achei a porta");
                Balanca.Device.Baud = 9600;
                // MessageBox.Show("Coloquei a velocidade");
                Balanca.Ativar();
                // MessageBox.Show("Eu ativei");
                decimal peso = Balanca.LePeso();
                // MessageBox.Show("Eu peguei o peso");
                txtQuantidade.Text = (peso.ToString());
                //txtQuantidade.Text = string.Format("{0:#,###,###.##}", (ListaBytesParaString(peso)));
                Balanca.Desativar();
                // MessageBox.Show("Eu fiz sucesso!!!!!!!!!!!!!!!!!!!!!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            //LoadPDV();
        }
        private DataTable ConsultaContarEmpresa()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                        " Select ",
                    "    Empresa			= emp.emp_nomefantasia ",
                    ",	Endereco		= emp.emp_logradouro + ' , ' + emp.emp_numero + ' - ' + emp.emp_bairro ",
                    ",	CidadeEstado	= cid.cid_nome + ' - ' + est.est_sigla + ' - ' + emp.emp_cep ",
                    ",   CNPJ			= 'CNPJ: ' + emp.emp_cnpj +'         IE:' + emp.emp_inscricaoEstadual",
                    ",   IE				= emp.emp_inscricaoEstadual ",
                   " From Empresa emp ",
                   " join Cidade cid on cid.cid_codigo = emp.emp_cidade ",
                   " join Estado est on est.est_codigo = cid.cid_estado "
                    );
                tab = con.ExecutaConsulta(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        private void ValidarLicenca()
        {

        }
        private void LoadPDV()
        {
            try
            {
                carregacombo();
                cbFuncionario.SelectedValue = global.codUsuario;
                AbrircaixaAntigo();
                OnePDV();
                dgDados.Columns.Add("ven_codigo", "ITEM");
                dgDados.Columns.Add("pro_codigo", "COD.");
                dgDados.Columns.Add("pro_nome", "DESCRIÇÂO");
                dgDados.Columns.Add("vi_quantidade", "QTD");
                dgDados.Columns.Add("vi_valorUnitario", "PREÇO");
                dgDados.Columns.Add("vi_subtotal", "SUBTOTAL");
                dgDados.Columns.Add("vi_tara", "TARA");
                ajustarColunasGrid();
                //  ckModoImpressao.Checked = true;
                ckdVenda.Checked = true;
                txtCodigoCliente.Text = "1";
                // imageSystemLOgo.Image = Image.FromFile(@"C:\One\image.jpg");
                //  timer1.Start();
                FechamentoCaixaBLL objFCm = new FechamentoCaixaBLL();
                if (objFCm.JaFechou(int.Parse(cbFuncionario.SelectedValue.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
                {
                    lblInfo.Visible = true;
                    lblInfo.Text = "FECHAMENTO JÁ FOI REALIZADO!";
                }
                else
                {
                    lblInfo.Text = "C A I X A  L I V R E ";
                }

                limpar();
                txtData.ReadOnly = true;
                txtNomeProduto.Text = "";
                txtCodigoBarra.Select();
                txtQuantidade.Text = "1";
                lblInfo.Text = "C A I X A  L I V R E";
                SetaCodigovenda();
                if (txtCodigo.Text != "")
                {
                    LocalizarPedido();
                }
                txtNomeProduto.Text = "";
                DataTable tabLicença = null;
                tabLicença = ConsultaContarEmpresa();
                tabLicença = ConsultaContarEmpresa();
                if (tabLicença.Rows.Count > 0)
                {
                    lblEmpresa.Text = String.Concat("Sistema licenciado para empresa : ", tabLicença.Rows[0]["Empresa"].ToString());
                    String CabecalhoCup = "";
                    CabecalhoCup = tabLicença.Rows[0]["Empresa"].ToString() + Environment.NewLine;
                    CabecalhoCup += tabLicença.Rows[0]["Endereco"].ToString() + Environment.NewLine;
                    CabecalhoCup += tabLicença.Rows[0]["CidadeEstado"].ToString() + Environment.NewLine;
                    CabecalhoCup += tabLicença.Rows[0]["CNPJ"].ToString() + Environment.NewLine;
                    txtCabecalhoCupom.SelectionAlignment = HorizontalAlignment.Center;
                    txtCabecalhoCupom.Text = CabecalhoCup.ToString();
                }
                ValidarLicenca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void ObterIDAbertura()
        {
            DataTable tabIDAber = null;
            tabIDAber = ObterCodigoDaUltimaAberturaSQL();
            int AberturaID = 0;
            if (tabIDAber.Rows[0]["ID"].ToString() != "")
                AberturaID = int.Parse(tabIDAber.Rows[0]["ID"].ToString());
            string Hora = "3.10.Versão";//(tabIDAber.Rows[0]["HoraAber"].ToString());
            lblCodigoAbertura.Text = AberturaID.ToString();
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

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btIncluirProduto_Click(object sender, EventArgs e)
        {
            inserirInte();
        }

        private void btExcluirProduto_Click(object sender, EventArgs e)
        {
            ExcluirItem();
        }

        private void txtDescontoValor_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtDescontoValor.Text.Contains(','))
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

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtPercentual.Text.Contains(','))
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

        private void txtDescontoPercentual_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtDescontoPercentual.Text.Contains(','))
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

        private void txtPercentual_Enter(object sender, EventArgs e)
        {
            txtPercentual.SelectAll();
        }

        private void txtDescontoPercentual_Enter(object sender, EventArgs e)
        {
            txtDescontoPercentual.SelectAll();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            salvarVendapdv();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cancelarAcao();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cancelarVenda();
        }

        public void salvarVendapdv()
        {
            try
            {
                if (txtCodigo.Text == "") //Insert
                {
                    #region Se for uma nova venda
                    //Carregar os campos no objeto
                    String novaVenda = "Não";
                    if (cbTipoVenda.SelectedIndex == 0)
                    {
                        carregaPropriedades();

                        if (objVen.ven_tipo == "Venda")
                            novaVenda = "Sim";
                    }
                    else
                    {
                        String condicional = "";
                        if (objVen.ven_tipo != "Venda") //A venda está na condicional?
                            condicional = "Sim";

                        carregaPropriedadesCondicional(); //Carrega as propriedades da venda alteradas pelo usuário
                        cancelouFpg = true;

                        if (objVen.ven_tipo == "Venda") // Se a venda passou de condicional para venda
                        {
                            if (condicional == "Sim") //Realizar a nova venda e fazer surgir o cupom fiscal
                                novaVenda = "Sim";
                        }
                        DataTable tabVerificarMesa = null;
                        tabVerificarMesa = VerificarMesaSQL(int.Parse(txtTicket.Text));
                        if (tabVerificarMesa.Rows.Count > 0)
                        {
                            throw new Exception("Ocorreu um erro na execução desse procedimento chame o suporte. Detalhe:Mesa já foi inserida");
                        }

                    }
                    objVen.inserir(true); //Venda
                    insereProdutosVenda(); //Produtos das Venda
                    #region QUando for Pedido mesa insere na mesa os dados
                    if (cbTipoVenda.Text == "Orçamento")
                    {
                        //Incluir Registro da mesa ou ticket  ao qual foi realizado a venda 
                        //Excluir Formas Pagamento
                        SqlCommand cmd = null;
                        Contexto objD = null;
                        try
                        {
                            objD = new Contexto();
                            cmd = new SqlCommand();
                            cmd.CommandText = String.Concat("Insert into ControleMesa (Data , VendaID , TicketID) Values (@Data , @VendaID , @TicketID)");
                            cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                            cmd.Parameters.Add(new SqlParameter("@VendaID", SqlDbType.Int)).Value = objVen.codigo;
                            cmd.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int)).Value = int.Parse(txtTicket.Text);
                            objD.ExecutaComando(cmd);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        cmd = null;
                        objD = null;
                        IncluirRegistroAtendimentoMesa();
                    }
                    #endregion
                    #region Forma de Pagamento Chama a Tela no Load
                    if (cbTipoVenda.Text == "Venda")
                    {
                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        frmPDV_Finalizadora frm = new frmPDV_Finalizadora(this);
                       // frm.txtUsuario  
                        frm.txtTotalGeralVendaBruto.Text = txtTotalFinal.Text;
                        frm.txtTotalRestante.Text = txtTotalFinal.Text;
                        frm.txtVendaID.Text = objVen.codigo.ToString();
                        frm.txtUsuario.Text = txtUsuario.Text;
                        frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                        frm.lblCodigoCliente.Text = txtCodigoCliente.Text;
                        frm.ShowDialog();


                        if (frm.cancelar)
                        {
                            // objVen.limpar();
                            objVI.excluir();
                            objVen.excluir();
                            cancelouFpg = false;
                        }
                        else
                        {
                            cancelouFpg = true;
                            objVen.forma_pagamento = frm.formaPagamento;
                            objVen.parcelas = frm.qtdParcelas;
                            txtvrRecebido.Text = frm.valorRecebido;
                            txtvrTroco.Text = frm.valorTroco;
                        }
                        frm = null;
                    }
                    #endregion
                    //Contas a receber 
                    #region Contas a Receber
                    if (cbTipoVenda.SelectedIndex == 0 && cancelouFpg == true)
                    {
                        if (novaVenda == "Sim")
                        {
                            ImprimirNaImpressoraBematech();
                        }
                        if (cancelouFpg == true)
                        {
                            objVen.limpar();
                            objVI.limpar();
                            limpar();
                            //objFP = null;
                        }

                        this.lblInfo.Visible = true;
                        lblInfo.Text = "C A I X A   A B E R T O";
                    }
                    else
                    {
                        if (cancelouFpg == true)
                        {
                            // lblInfo.Text = ("Venda Pendente salva com sucesso!");
                            txtCodigoBarra.Select();
                            limpar();
                        }
                    }
                    #endregion
                }

                else //Update
                {
                    #region Se for uma alteração da venda
                    carregaPropriedadesAlterar();
                    objVen.alterar(true);
                    insereProdutosVenda();
                    cancelouFpg = true;
                    if (cbTipoVenda.Text == "Venda")
                    {
                        #region Tratar Forma de Pagamento Novo
                        frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        // frmFechamentoDetalhe frm = new frmFechamentoDetalhe();
                        //frm.txtvrTotal.Text = (txtTotalFinal.Text);
                        //frm.txtvrRecebido.Focus();
                        //frm.txtTotalItens.Text = txtTotalItens.Text.ToString();
                        frm.txtTotalGeralVendaBruto.Text = txtTotalFinal.Text;
                        frm.txtTotalRestante.Text = txtTotalFinal.Text;
                        frm.txtVendaID.Text = objVen.codigo.ToString();
                        frm.txtUsuario.Text = txtUsuario.Text;
                        frm.lblCodigoCliente.Text = txtCodigoCliente.Text;
                        frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                        frm.ShowDialog();
                        if (frm.cancelar)
                        {
                            cancelouFpg = false;
                        }
                        else
                        {
                            cancelouFpg = true;
                            objVen.forma_pagamento = frm.formaPagamento;
                            objVen.parcelas = frm.qtdParcelas;
                            txtvrRecebido.Text = frm.valorRecebido;
                            txtvrTroco.Text = frm.valorTroco;
                        }
                        frm = null;
                        #endregion
                        if (cbTipoVenda.SelectedIndex == 0 && cancelouFpg == true)
                        {
                            AtualizarRegistroAtendimentoMesaFechamento();

                            ImprimirNaImpressoraBematech();
                            limpar();
                            objVen.limpar();
                            objVI.limpar();
                        }
                    }
                    if (cancelouFpg == true)
                        limpar();
                    #endregion
                }
                OnePDV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void IncluirRegistroAtendimentoMesa()
        {
            SqlCommand cmd = null;
            Contexto objD = null;
            int Hora = DateTime.Now.Hour;
            int Minuto = DateTime.Now.Minute;
            int Segundo = DateTime.Now.Second;
            string HoraCompleto = Hora.ToString() + ":" + Minuto.ToString() + ":" + Segundo.ToString();
            try
            {
                //Inserir o movimento do atendimento mesa 
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Insert into AtendimentoMesa ",
                    " (VendaID,DataAbertura,HoraAbertura,NumeroMesa,Atendente,Status) ",
                    " Values (@VendaID,@DataAbertura,@HoraAbertura,@NumeroMesa,@Atendente,@Status)");
                cmd.Parameters.Add(new SqlParameter("@VendaID", SqlDbType.Int)).Value = objVen.codigo;
                cmd.Parameters.Add(new SqlParameter("@DataAbertura", SqlDbType.Date)).Value = DateTime.Now.Date;
                cmd.Parameters.Add(new SqlParameter("@NumeroMesa", SqlDbType.Int)).Value = int.Parse(txtTicket.Text);
                cmd.Parameters.Add(new SqlParameter("@HoraAbertura", SqlDbType.Time)).Value = HoraCompleto;
                cmd.Parameters.Add(new SqlParameter("@Atendente", SqlDbType.Int)).Value = int.Parse(cbFuncionario.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int)).Value = 1; //Aberto
                objD.ExecutaComando(cmd);

                //Alterar a situação da mesa para 1 Ocupada 
                cmd.CommandText = String.Concat("Update  Mesa",
                   " set Status ='1' ",
                   " Where Numero =@Mesa"
                   );
                cmd.Parameters.Add(new SqlParameter("@Mesa", SqlDbType.Int)).Value = int.Parse(txtTicket.Text);
                objD.ExecutaComando(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        private void AtualizarRegistroAtendimentoMesaFechamento()
        {
            SqlCommand cmd = null;
            Contexto objD = null;
            int Hora = DateTime.Now.Hour;
            int Minuto = DateTime.Now.Minute;
            int Segundo = DateTime.Now.Second;
            string HoraCompleto = Hora.ToString() + ":" + Minuto.ToString() + ":" + Segundo.ToString();
            try
            {
                //Inserir o movimento do atendimento mesa 
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Update AtendimentoMesa ",
                    " Set Status = @Status, HoraFechamento = @HoraFechamento ,Atendente = @Atendente",
                    " Where NumeroMesa = @NumeroMesa and VendaID =@VendaID ");
                cmd.Parameters.Add(new SqlParameter("@VendaID", SqlDbType.Int)).Value = objVen.codigo;
                cmd.Parameters.Add(new SqlParameter("@NumeroMesa", SqlDbType.Int)).Value = int.Parse(txtTicket.Text);
                cmd.Parameters.Add(new SqlParameter("@HoraFechamento", SqlDbType.Time)).Value = HoraCompleto;
                cmd.Parameters.Add(new SqlParameter("@Atendente", SqlDbType.Int)).Value = int.Parse(cbFuncionario.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int)).Value = 0; //Aberto
                objD.ExecutaComando(cmd);

                //Alterar a situação da mesa para 1 Ocupada 
                cmd.CommandText = String.Concat("Update  Mesa",
                   " set Status ='0' ",
                   " Where Numero =@Mesa"
                   );
                cmd.Parameters.Add(new SqlParameter("@Mesa", SqlDbType.Int)).Value = int.Parse(txtTicket.Text);
                objD.ExecutaComando(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void cancelarAcao()
        {
            try
            {
                objVen.limpar();
                objVI.limpar();
                limpar();
                txtCodigoBarra.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void cancelarVenda()
        {
            try
            {
                if (objVen.codigo != 0)
                {
                    if (global.permissao != "Gerente" && global.codUsuario != objVen.usuario)
                        throw new Exception("Você não tem permissão para cancelar esta venda");


                    if (MessageBox.Show("Deseja realmente cancelar esta venda?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        objVen.ven_status = "Cancelado";
                        objVen.cancelarVenda();

                        DataTable tab = objVI.localizarComRetorno(objVen.codigo.ToString(), "ven_codigo");

                        for (int i = 0; i < tab.Rows.Count; i++)
                        {

                            objVI.pro_codigo = int.Parse(tab.Rows[i][1].ToString());
                            objVI.vi_quantidade = decimal.Parse(tab.Rows[i][2].ToString());

                            ProdutosBLL objPro = new ProdutosBLL();
                            objPro.localizar(objVI.pro_codigo.ToString(), "pro_codigo");
                            objPro.pro_quantidade = objPro.pro_quantidade + objVI.vi_quantidade;
                            objPro.alterarQuantidade();
                            objPro = null;
                        }

                        ContasAReceberBLL objCR = new ContasAReceberBLL();
                        objCR.vendas = int.Parse(tab.Rows[0][0].ToString());
                        objCR.excluirVenda();
                        objCR = null;
                        objVen.limpar();
                        objVI.limpar();

                        //Excluir Formas Pagamento
                        SqlCommand cmd = null;
                        Contexto objD = null;
                        try
                        {
                            objD = new Contexto();
                            cmd = new SqlCommand();
                            cmd.CommandText = "Update VendasFormasDePagamento set Status = 'Cancelado' Where VendaID = '" + txtCodigo.Text + "'";
                            objD.ExecutaComando(cmd);
                            lblInfo.Text = "";
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        cmd = null;
                        objD = null;

                        MessageBox.Show("Venda cancelada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        limpar();
                    }
                }
                else
                    MessageBox.Show("Favor selecionar uma Venda clicando F7 e inserir o código da venda, ou escolher um código válido para poder cancelar a venda", "Cancelar Venda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void inserirInte()
        {
            FechamentoCaixaBLL objFC = new FechamentoCaixaBLL();
            if (objFC.JaFechou(int.Parse(cbFuncionario.SelectedValue.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
            {
                MessageBox.Show("Não é possivél operar o caixa pois o fechamento diário já foi realizado!", "Alerta!!!!");
                this.Close();
            }
            lblInfo.Text = "C A I X A  O C U P A D O";
            lblInfo.Visible = true;
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

                x = "";
                for (int j = 0; j <= txtSubtotal.Text.Length - 1; j++)
                {
                    if ((txtSubtotal.Text[j] >= '0' &&
                    txtSubtotal.Text[j] <= '9') ||
                    txtSubtotal.Text[j] == ',')
                    {
                        x += txtSubtotal.Text[j];
                    }
                }
                txtSubtotal.Text = x;

                if (txtNomeProduto.Text == "")
                {
                    //txtCodigoBarra.Text = "";
                    txtCodigoBarra.Focus();
                    throw new Exception("Produto não encontrado na base de dados");

                }

                if (txtValorUnitario.Text == "")
                {
                    //txtCodigoBarra.Text = "";
                    txtCodigoBarra.Focus();
                    throw new Exception("Nenhum produto foi encontrado.");


                }
                if (txtQuantidade.Text == "" || txtQuantidade.Text.Equals("0"))
                    throw new Exception("O campo quantidade deve possuir um número inteiro maior que 0");

                if (txtSubtotal.Text == "" || txtSubtotal.Text.Equals("R$ 0,00"))
                    throw new Exception("O campo subtotal deve possui um número real maior que 0");
                if (txtDesconto.Text == "")
                    txtDesconto.Text = "0";
                if (txtPercentual.Text == "")
                    txtPercentual.Text = "0";
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
                    txtValorTotal.Text = total.ToString();
                    txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString();
                    txtTotalFinal.Text = total.ToString();
                    txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();
                    txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString();
                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();
                    txtQuantidade.Text = "";
                    txtCodigoBarra.Focus();
                }
                ProdutosBLL objPro = new ProdutosBLL();
                objPro.localizar(txtCodigoProduto.Text.ToString(), "pro_codigo");
                //Primeira vez que está inserindo o produto
                if (achou != "Sim")
                {
                    int item = 00;
                    item = CountItem += 1;
                    String CodigoVenda = String.Empty;
                    int NumQtdVenda = 0;
                    if (txtQtdItenVenda.Text != String.Empty)
                    {
                        NumQtdVenda = int.Parse(txtQtdItenVenda.Text);
                        NumQtdVenda += 1;
                        txtQtdItenVenda.Text = NumQtdVenda.ToString();
                    }
                    else
                    {
                        NumQtdVenda += 1;
                    }

                    if (txtCodigo.Text != String.Empty)
                    {
                        CodigoVenda = txtCodigo.Text.ToString();
                    }
                    else
                    {
                        CodigoVenda = item.ToString();
                    }

                    if (decimal.Parse(txtQuantidade.Text) > decimal.Parse(txtQuantidadeTotal.Text))
                    {
                        txtCodigoBarra.Text = "";
                        txtCodigoBarra.Focus();
                        throw new Exception("Não existe quantidade disponivél para o produto  " + objPro.pro_nome);
                    }
                    else
                    {
                        #region Verificar Estoque
                        //Verificar Estoque Inicio 18/09/2016
                        decimal quantidadeDisponivel = 0;
                        decimal quantidadeVendidagrid = 0;
                        decimal QuantidadeVendida = 0;
                        if (dgDados.Rows.Count == 0)
                        {
                            dgDados.Rows.Add(1, txtCodigoProduto.Text.ToString(), objPro.pro_nome, txtQuantidade.Text, Convert.ToDecimal(txtValorUnitario.Text).ToString(), Convert.ToDecimal(txtSubtotal.Text).ToString(), txtTara.Text);
                            txtQtdItenVenda.Text = "1";
                        }
                        else
                        {

                            for (int i = 0; i <= dgDados.Rows.Count - 1; i++)
                            {
                                if (dgDados.Rows[i].Cells[1].Value.ToString() == txtCodigoProduto.Text.ToString())
                                {
                                    quantidadeDisponivel = decimal.Parse(txtQuantidadeTotal.Text);
                                    quantidadeVendidagrid = decimal.Parse(dgDados.Rows[i].Cells[3].Value.ToString());
                                    QuantidadeVendida += quantidadeVendidagrid;
                                    decimal QuantidadeTotalCorrente = QuantidadeVendida + decimal.Parse(txtQuantidade.Text.ToString());

                                    if (QuantidadeTotalCorrente > quantidadeDisponivel)
                                    {
                                        txtCodigoBarra.Text = "";
                                        txtCodigoBarra.Focus();
                                        throw new Exception("Não há estoque disponivél");

                                    }
                                }
                            }
                            dgDados.Rows.Add(
                                       NumQtdVenda
                                       , txtCodigoProduto.Text.ToString()
                                       , objPro.pro_nome
                                       , txtQuantidade.Text
                                       , Convert.ToDecimal(txtValorUnitario.Text).ToString()
                                       , Convert.ToDecimal(txtSubtotal.Text).ToString()
                                       , txtTara.Text
                                       );
                            QuantidadeVendida = 0;

                            //Verificar Estoque FIm 18/09/2016
                        #endregion

                            objPro = null;
                        }
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
                    txtValorTotal.Text = total.ToString();
                    txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString();
                    txtTotalFinal.Text = total.ToString();
                    txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();

                    txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString();
                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();


                }
                decimal qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += decimal.Parse(dgDados.Rows[i].Cells[3].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();

                txtQuantidade.Text = "";
                //txtCodigoBarra.Text = "";
                txtCodigoBarra.Focus();

                dgDados.ClearSelection();
                int nRowIndex = dgDados.Rows.Count - 1;

                dgDados.Rows[nRowIndex].Selected = true;
                dgDados.Rows[nRowIndex].Cells[0].Selected = true;
                dgDados.FirstDisplayedScrollingRowIndex = dgDados.RowCount - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void ExcluirItem()
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
                        txtValorTotal.Text = total.ToString();
                        txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString();
                        txtTotalFinal.Text = total.ToString();
                        txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();
                        txtCodigoBarra.Select();

                        // txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString( );
                    }
                    else
                    {
                        txtValorTotal.Text = "0";
                        txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString();
                        txtTotalFinal.Text = "0";
                        txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();
                        txtCodigoBarra.Select();
                    }
                }

                int qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += int.Parse(dgDados.Rows[i].Cells[3].Value.ToString());

                txtTotalItens.Text = qtdade.ToString();

                txtDescontoPercentual.Text = "";
                txtDescontoValor.Text = "";
                txtCodigoBarra.Select();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void ObterPeso(int CodigoProduto)
        {
            try
            {
                CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
                if (txtQuantidade.Text != "")
                {
                    //Obter Tara do Produto 
                    DataTable tabProduto = null;
                    tabProduto = CarregarProdutosPesoSQL(CodigoProduto);
                    if (tabProduto.Rows.Count > 0)
                    {
                        HabilitarCamnpos(false);
                        if (AlterarPeso)
                        {
                            //txtQuantidade.Text = txtQuantidade.Text;
                        }
                        else
                        {
                            if (lblNomeBalanca.Text == "Magna")
                            {
                                ObterPesoMagna();
                            }
                            else
                            {
                                ObterPesoToledo();
                            }
                            if (txtQuantidade.Text.ToString() == "IIIII")
                            {
                                txtCodigoBarra.Focus();
                                throw new Exception("A balança não retornou um peso valido!");
                            }

                        }
                        //1txtQuantidade.Text = "462";
                        if (txtQuantidade.Text != "")
                        {
                            epeso = true;
                            txtPesoBruto.Text = txtQuantidade.Text.ToString();
                            txtDinamic.Text = txtQuantidade.Text.ToString() + " X";
                        }
                        else
                        {
                            txtDinamic.Text = txtQuantidade.Text.ToString() + " X";
                        }

                        if (tabProduto.Rows[0]["pro_comissao"].ToString() != "")
                        {
                            decimal v1 = 0;
                            decimal v2 = 0;
                            decimal vt = 0;
                            // decimal TaraProduto = 82.0m;
                            decimal TaraProduto = decimal.Parse(tabProduto.Rows[0]["pro_comissao"].ToString());
                            bool escolheu = false;
                            v1 = decimal.Parse(txtQuantidade.Text, NumberStyles.Currency, culturaBrasileira);
                            v2 = decimal.Parse(txtValorUnitario.Text, NumberStyles.Currency, culturaBrasileira);
                            v1 = v1 - TaraProduto;
                            txtQuantidade.Text = v1.ToString();
                            //378 * 27,90 
                            vt = Math.Round(((v1 * v2) / 1000), 2);
                            escolheu = true;
                            txtSubtotal.Text = vt.ToString();
                            txtTara.Text = TaraProduto.ToString();
                            txtTotalFinal.Visible = true;
                            txtSubtotal.Visible = true;
                        }
                        else
                        {
                            decimal v1 = 0;
                            decimal v2 = 0;
                            decimal vt = 0;
                            v1 = decimal.Parse(txtQuantidade.Text, NumberStyles.Currency, culturaBrasileira);
                            v2 = decimal.Parse(txtValorUnitario.Text, NumberStyles.Currency, culturaBrasileira);
                            vt = Math.Round(((v1 * v2) / 1000), 2);
                            txtSubtotal.Text = vt.ToString();
                            txtTara.Text = "0";
                            txtTotalFinal.Visible = true;
                            txtSubtotal.Visible = true;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


        private void fecharaporta()
        {
            if (PortaAberta)
            {
                if (FechaPorta() == 1)
                {
                    PortaAberta = false;
                }
                else
                {
                    // lblInfo.Text = "Ocorreu uma falha na leitura da porta." + this.Text;
                }
            }
        }

        public void pesquisarTiket()
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtTicket.Text, out cod);
                if (cod != 0)
                {

                    objVen.localizarLeave_Ticket(cod.ToString(), "ven_ticket");
                    if (objVen.codigo != 0)
                    {
                        carregaCampos();
                        //  txtCodigo.Enabled = false;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void ObterPesoToledo()
        {
            #region Obtendo o peso da balança
            if (AbrePorta(CONSTANTES.porta, CONSTANTES.baudRate, CONSTANTES.dataBits, CONSTANTES.paridade) == 1)
            {
                // lblInfo.Text = "Porta aberta!";
                PortaAberta = true;
            }

            if (PortaAberta)
            {
                byte[] DadosPeso = new byte[6]; //5 bytes + nulo

                String caminho = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                if (PegaPeso(0, DadosPeso, caminho) == 1)
                {
                    //txtPeso.Text = ListaBytesParaString(DadosPeso);
                    txtQuantidade.Text = string.Format("{0:#,###,###.##}", (ListaBytesParaString(DadosPeso)));
                    // txtPesoBruto.Text = string.Format("{0:#,###,###.##}", (ListaBytesParaString(DadosPeso)));
                    fecharaporta();
                }
                else
                    txtQuantidade.Text = "0";
                //txtPesoBruto.Text = "0";
            }
            else
                //lblInfo.Text = "Atenção! Porta fechada." + this.Text;

                if (PortaAberta)
                {
                    if (FechaPorta() == 1)
                    {
                        //txtQuantidade.Text = "00000";
                        //  lblInfo.Text = "Porta fechada!" + this.Text;
                        PortaAberta = false;
                    }
                    else
                    {
                        MessageBox.Show(this, "Error", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            #endregion
        }

        private void FrenteDeCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                HabilitarCamnpos(true);
                switch (e.KeyCode)
                {
                    case Keys.Multiply:
                        txtCodigoBarra.Text = "";
                        txtQuantidade.Select();
                        txtCodigoBarra.Text = "";
                        break;
                    case Keys.F9:
                        frmPesquisarProduto novaForm = new frmPesquisarProduto(this);
                        novaForm.ShowDialog();
                        break;
                    case Keys.F1:
                        frmMenu frmmenu = new frmMenu();
                        frmmenu.ShowDialog();
                        break;
                    //Finalizar a Venda
                    case Keys.F2:
                        if (dgDados.Rows.Count > 0 || !string.IsNullOrEmpty(txtNomeProduto.Text))
                        {
                            lblInfo.Visible = true;
                            txtPesoBruto.Text = "";
                            txtTicket.Visible = false;
                            if (!string.IsNullOrEmpty(txtNomeProduto.Text))
                            {
                                inserirNoGrid();
                                txtNomeProduto.Text = "";
                                txtCodigoBarra.Text = "";
                            }
                            if (!string.IsNullOrEmpty(lblCpf.Text))
                            {
                                objVen.CpfCnpj = lblCpf.Text.Replace(".", "").Replace("/", "").Replace("-", "");
                            }
                            salvarVendapdv();
                            lblInfo.Text = ("C A I X A    L I V R E");
                            ckdVendaPendente.Checked = false;
                            ckdVenda.Checked = true;
                            txtCodigoCliente.Text = "1";
                            txtCodigo.Visible = false;
                            CountItem = 0;
                            lblMsgMesa.Text = ". . . PDV Online";
                            lblCpf.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Informe um produto para finalizar a venda", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    //Limpar Formularios
                    case Keys.F3:
                        if (MessageBox.Show("Deseja realmente limpar os dados da venda?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            cancelarAcao();
                            lblInfo.Text = "C A I X A   L I V R E";
                            OnePDV();
                            lblCpf.Text = "";
                        }
                        break;
                    case Keys.F4:
                        txtCodigo.Visible = true;
                        txtCodigo.Focus();
                        if (txtCodigo.Text != "")
                        {
                            string autoriza = "não";
                            if (MessageBox.Show("Tem certeza que deseja cancelar essa Venda?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                            {
                                verificacaoUsuario frm = new verificacaoUsuario();
                                frm.ShowDialog();
                                if (frm.permissao != "Gerente")
                                {
                                    throw new Exception("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                                    frm = null;
                                    autoriza = "Sim";
                                }
                                else
                                {
                                    cancelarVenda();
                                    limpar();
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Precisa informar número do cupom para cancelar !");
                        }
                        break;
                    case Keys.F5:
                        FrmInputCpf cpf = new FrmInputCpf(this);
                        cpf.ShowDialog();
                        if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 11)
                        {
                            lblCpf.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"000\.000\.000\-00");
                            lblCpf.Visible = true;
                        }
                        if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 14) //99.999.999/9999-99
                        {
                            lblCpf.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"00\.000\.000\/0000\-00");
                            lblCpf.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(cpf.CpfCliente))
                            txtCodigoBarra.Text = "";
                        break;
                    case Keys.F6:
                        txtCodigoBarra.Text = "";
                        frmQuantidade frm_ = new frmQuantidade();
                        frm_.ShowDialog();
                        ItemRemove = frm_.Qtd;
                        try
                        {
                            for (int i = 0; i <= dgDados.Rows.Count - 1; i++)
                            {

                                if (dgDados.Rows[i].Cells[0].Value.ToString() == ItemRemove.ToString())
                                {

                                    dgDados.Rows.Remove(dgDados.Rows[i]);

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
                                            total += decimal.Parse(subtotal);
                                        }
                                        txtValorTotal.Text = total.ToString();
                                        txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString("C");
                                        txtTotalFinal.Text = total.ToString();
                                        txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString();
                                        txtCodigoBarra.Select();
                                    }
                                    else
                                    {
                                        txtValorTotal.Text = "0";
                                        txtValorTotal.Text = Convert.ToDecimal(txtValorTotal.Text).ToString("C");
                                        txtTotalFinal.Text = "0";
                                        txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString("C");
                                        txtCodigoBarra.Select();
                                    }


                                    int qtdade = 0;
                                    for (int j = 0; j < dgDados.Rows.Count; j++)
                                        qtdade += int.Parse(dgDados.Rows[j].Cells[3].Value.ToString());

                                    txtTotalItens.Text = qtdade.ToString();

                                    txtDescontoPercentual.Text = "";
                                    txtDescontoValor.Text = "";
                                    txtCodigoBarra.Select();

                                    break;
                                }
                            }
                            if (!string.IsNullOrEmpty(txtNomeProduto.Text))
                            {
                                txtNomeProduto.Text = "";
                                txtCodigoBarra.Text = "";
                            }
                        }
                        catch (System.Exception)
                        {
                            MessageBox.Show("não existe o item selecionado!");
                        }
                        break;
                    case Keys.F8:
                        FechamentoCaixaBLL objFC = new FechamentoCaixaBLL();

                        if (objFC.JaFechou(int.Parse(cbFuncionario.SelectedValue.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
                        {
                            throw new Exception("Fechamento diário já foi realizado");

                        }
                        else
                        {
                            frm_FechamentoCaixa frm1 = new frm_FechamentoCaixa(this);
                            frm1.lblNumerCaixa.Text = lblNumerCaixa.Text;
                            frm1.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                            frm1.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
                            frm1.txtUsuario.Text = txtUsuario.Text.ToString();
                            frm1.ShowDialog();
                            lblInfo.Visible = true;
                            break;
                        }
                    case Keys.F11:
                        string autorizar = "não";
                        if (MessageBox.Show("Tem certeza que deseja excluir o encerramento do caixa?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            verificacaoUsuario frm = new verificacaoUsuario();
                            frm.ShowDialog();
                            if (frm.permissao != "Gerente")
                            {
                                throw new Exception("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                                frm = null;
                                autorizar = "Sim";
                            }
                            else
                            {
                                SqlCommand cmd = null;
                                Contexto objD = null;
                                try
                                {
                                    objD = new Contexto();
                                    cmd = new SqlCommand();
                                    cmd.CommandText = "DELETE FROM fin_fechamento_caixa" +
                                        " WHERE" +
                                        " fin_data= CONVERT(char(11),getdate(),113)";
                                    objD.ExecutaComando(cmd);
                                    lblInfo.Text = "";
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                cmd = null;
                                objD = null;
                            }
                        }
                        break;
                    case Keys.F12:
                        frmClientes novaForm2 = new frmClientes(this);
                        novaForm2.ShowDialog();
                        //Pegando o valor da propriedade da Form novaForm e colocando no Label
                        if (novaForm2.Codigo != null)
                        {
                            txtCodigoCliente.Text = novaForm2.Codigo.ToString();
                            lblInfo.Visible = true;
                            lblInfo.Text = novaForm2.NomeCliente.ToString().ToUpper();
                            lblInfo.TextAlign = ContentAlignment.BottomLeft;
                        }
                        txtCodigoBarra.Focus();
                        break;
                    case Keys.F10:
                        ImprimirNaImpressoraBematech();
                        limpar();
                        break;
                    case Keys.Escape:
                        if (MessageBox.Show("Deseja realmente encerrar o PDV?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            // FazerBackupdoSistema();
                            Application.Exit();
                        }
                        break;
                    case Keys.Up:
                        if (dgDados.FirstDisplayedScrollingRowIndex > 0)
                            dgDados.FirstDisplayedScrollingRowIndex = dgDados.FirstDisplayedScrollingRowIndex - 1;
                        break;
                    case Keys.Down:
                        dgDados.FirstDisplayedScrollingRowIndex = dgDados.FirstDisplayedScrollingRowIndex + 1;
                        break;
                }
                if (e.Modifiers == Keys.Alt && e.KeyCode == Keys.Q)
                {
                    string autorizar = "não";
                    frmQuantidadePDV qtd = new frmQuantidadePDV();
                    AlterarPeso = true;
                    qtd.ShowDialog();
                    txtQuantidade.Text = qtd.Qtd;
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Q)
                {
                    frmAdicionarDinheiroCaixa_ frm = new frmAdicionarDinheiroCaixa_();
                    frm.txtUsuario.Text = txtUsuario.Text;
                    frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    frm.ShowDialog();
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                {
                    frmSangriaCaixa frm = new frmSangriaCaixa();
                    frm.txtUsuario.Text = txtUsuario.Text;
                    frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    frm.ShowDialog();
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
                {
                    frmConsultaMovimentoCaixa frm = new frmConsultaMovimentoCaixa();
                    frm.lblNumerCaixa.Text = lblNumerCaixa.Text;
                    frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    frm.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
                    frm.txtUsuario.Text = txtUsuario.Text.ToString();
                    frm.txtUsuario.Text = txtUsuario.Text;
                    frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void FazerBackupdoSistema()
        {
            try
            {
                Acesso ac = new Acesso();
                ac.RealizarBackupSistema();
                ac = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Realizar Bakup de rotina", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirMesa()
        {
            //  txtTicket.Visible = true;
            // label14.Visible = true;
            ckdVendaPendente.Checked = true;
            cbTipoVenda.SelectedIndex = 1;
            ckdVenda.Checked = false;
            //lblInfo.Text = ("");
            txtTicket.Focus();
            EnterMesa = 1;
            OnePDV();
            frmPedidoMesa frm = new frmPedidoMesa();
            frm.EDisponivel = true;
            frm.ShowDialog();
            if (frm.Codigo != null)
            {
                CarregarToushMesa(frm.Finaliza, frm.Codigo.ToString());
            }
        }

        public void CarregarToushMesa(bool Finaliza, string numero)
        {
            if (Finaliza)
            {
                txtLocalizarMesa.Text = numero.ToString();
                // LocalizarPedido();
                LocalizarMesaPesquisar();

            }
            else
            {
                txtTicket.Text = numero.ToString();
                ckdVendaPendente.Checked = true;
                cbTipoVenda.SelectedIndex = 1;
                ckdVenda.Checked = false;
                lblInfo.Visible = true;
                txtTicket.Focus();
                EnterMesa = 1;
                OnePDV();
                txtCodigoBarra.Focus();
            }
        }

        private void CalcularPesoProduto()
        {
            try
            {
                ObterPeso(int.Parse(txtCodigoProduto.Text.ToString()));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public int LocalizarProduto()
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                //Buscar Produto.
                objPro.localizarLeave(txtCodigoBarra.Text, "pro_codigoBarra");
                // Se Encontrar o Produto. 
                if (objPro.pro_codigo != 0)
                {
                    if (objPro.pro_comissao != 0)
                    {
                        HabilitarCamnpos(false);
                    }
                    txtCodigoProduto.Text = objPro.pro_codigo.ToString();
                    txtNomeProduto.Text = objPro.pro_nome;
                    txtQuantidadeTotal.Text = objPro.pro_quantidade.ToString();
                    txtValorUnitario.Text = objPro.pro_precoVenda.ToString();
                    txtValorUnitario.Enabled = true;
                    txtQuantidade.Enabled = true;
                    if (txtQuantidade.Text == "")
                    {
                        txtQuantidade.Text = "1";
                    }
                    txtValorUnitario.Text = objPro.pro_precoVenda.ToString();
                    //Se a quantidade for diferente de 0 .
                    if (txtQuantidade.Text != "")
                    {
                        decimal qtd = decimal.Parse(txtQuantidade.Text);
                        decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                        decimal Subtotal = qtd * valorUnitario;

                        txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();
                        //  txtSubtotal.ReadOnly = false;
                        txtSubtotal.Text = Subtotal.ToString();
                        txtSubtotal.Text = Convert.ToDecimal(txtSubtotal.Text).ToString();
                        // txtSubtotal.ReadOnly = true;


                    }
                    else if (txtValorUnitario.Text != "")
                        txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();

                    if (!string.IsNullOrEmpty(txtNomeProduto.Text) && txtNomeProduto.Text.Length > 0)
                    {
                        txtCodigoBarra.SelectionStart = 0;
                        txtCodigoBarra.SelectionLength = txtCodigoBarra.Text.Length;
                    }
                }
                //Se não Encontrar 
                else
                {
                    //  txtNomeProduto.Text = "";
                    txtQuantidadeTotal.Text = "";
                    txtValorUnitario.Text = "";
                    //txtQuantidade.Text = "1";
                    txtValorUnitario.Enabled = false;
                    txtSubtotal.Text = "";
                    txtQuantidade.Enabled = true;
                    return 0;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return 0;
            }

            return 1;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void LocalizarPedido()
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objVen.limpar();
                    objVen.localizarLeave(cod.ToString(), "ven_codigo");
                    if (objVen.codigo != 0)
                    {
                        carregaCampos();
                        txtCodigoBarra.Select();
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

        private void txtCodigo_Leave_1(object sender, EventArgs e)
        {
            LocalizarPedido();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private DataTable ObterCodigoDaUltimaAberturaSQL()
        {
            Contexto objD = null;
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    ("Select max(fin_codigo)'ID' from fin_abertura_caixa Where fin_usuario = @UsuarioID");
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = int.Parse(cbFuncionario.SelectedValue.ToString());
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

        public void InserirMovimentoCAIXA(int AberturaID, string Tipo, decimal Valor, string Usuario, int IDObj)
        {
            try
            {
                SqlCommand cmd = null;
                Contexto objD = null;


                //Inserir o movimento do atendimento mesa 
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Insert into OneFinalizadora",
                    " (Data,AberturaID, Tipo,Valor, Usuario,IDObj) ",
                    " Values (@Data,@AberturaID, @Tipo,@Valor, @Usuario,@IDObj)");
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@AberturaID", SqlDbType.Int)).Value = AberturaID;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar)).Value = Tipo;
                cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Decimal)).Value = Valor;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = Usuario;
                cmd.Parameters.Add(new SqlParameter("@IDObj", SqlDbType.Int)).Value = IDObj;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private DataTable carregaeEncerramentoCaixaSQL()
        {
            Contexto objD = null;
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    ("ResumoCaixaVendas");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = int.Parse(cbFuncionario.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@UsuarioNome", SqlDbType.VarChar)).Value = txtUsuario.Text;
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

        private void txtTicket_Leave(object sender, EventArgs e)
        {

        }

        private void btF1_Click(object sender, EventArgs e)
        {
            frmPesquisarProduto frm = new frmPesquisarProduto(this);
            frm.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void ImprimirNaImpressoraBematech()
        {
       //  try
       //  {
       //      if (ckModoImpressao.Checked == true)
       //      {
       //          //   MessageBox.Show("Entrei..........");
       //          int imagem = 0;
       //          int imprimirTexto = 0;
       //          //iniciando a Impressao
       //          int codVendaObj = 0;
       //          int codvendatextBox = 0;
       //
       //          DataTable tabCupom = objVen.FormarCupom(objVen.codigo);
       //          if (tabCupom.Rows.Count > 0)
       //          {
       //              //  MessageBox.Show("eu tenho unformações");
       //              int x = Convert.ToInt32(12);
       //              int y = Convert.ToInt32(12);
       //              int angulo = Convert.ToInt32(0);
       //              String CabecalhoCup = "";
       //              imagem = MP2032.ImprimeBmpEspecial("C:\\One\\LogoCliente.bmp", x, y, angulo);
       //              String textoImpressora;
       //              textoImpressora = "               " + Environment.NewLine;
       //              txtCabecalhoCupom.SelectionAlignment = HorizontalAlignment.Center;
       //              textoImpressora += "          " + txtCabecalhoCupom.Text.ToString();// += CabecalhoCup.ToString();
       //              textoImpressora += "-----------------------------------------------" + Environment.NewLine;
       //              textoImpressora += "              CUPOM DE VENDA " + Environment.NewLine;
       //              textoImpressora += "-----------------------------------------------" + Environment.NewLine;
       //              textoImpressora += "DATA:" + tabCupom.Rows[0]["Data da Venda"].ToString() + "  CUPOM:" + objVen.codigo.ToString() + Environment.NewLine;
       //              textoImpressora += "-----------------------------------------------" + Environment.NewLine;
       //              textoImpressora += "ITEM  " + "DESCRIÇÃO " + "QTD  " + "TARA " + "PREÇO " + "SUBTOTAL " + Environment.NewLine;
       //              textoImpressora += "-----------------------------------------------" + Environment.NewLine;
       //              for (int i = 0; i < tabCupom.Rows.Count; i++)
       //              {
       //                  textoImpressora += i + " " + tabCupom.Rows[i]["CodigoBarras"].ToString() + "  " + tabCupom.Rows[i]["Produto"].ToString() + "  " + tabCupom.Rows[i]["Unidade"].ToString() + Environment.NewLine; //+ tabCupom.Rows[i]["Quantidade"].ToString() + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + "  " + "  " +  tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
       //                  if (tabCupom.Rows[i]["Unidade"].ToString() == "KG")
       //                  {
       //                      textoImpressora += "Peso Bruto " + tabCupom.Rows[i]["Peso Bruto"].ToString() + " - " + tabCupom.Rows[i]["Tara"] + " = " + tabCupom.Rows[i]["Quantidade"] + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + " = " + tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
       //                  }
       //                  else
       //                  {
       //                      textoImpressora += "QTD " + tabCupom.Rows[i]["Quantidade"].ToString() + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + " = " + tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
       //                  }
       //              }
       //              textoImpressora += "----------------------------------------------" + Environment.NewLine;
       //
       //              textoImpressora += "Total       R$ = " + tabCupom.Rows[0]["Total"].ToString() + Environment.NewLine;
       //              textoImpressora += "Desconto    R$ = " + tabCupom.Rows[0]["Desconto"].ToString() + Environment.NewLine;
       //              textoImpressora += "Recebido    R$ = " + tabCupom.Rows[0]["ValorRecebido"].ToString() + Environment.NewLine;
       //              textoImpressora += "Troco       R$ = " + tabCupom.Rows[0]["ValorTroco"].ToString() + Environment.NewLine;
       //
       //              textoImpressora += "------------OBRIGADO PELA PREFERENCIA------------" + Environment.NewLine;
       //              textoImpressora += "SISTEMA SIAV PDV :3.10  FONE:" + DateTime.Now.Year.ToString() + "11 9 6194 6874" + Environment.NewLine;
       //              //textoImpressora += lblMsgCupom.Text + Environment.NewLine;
       //              textoImpressora += "                                           " + Environment.NewLine;
       //              //Imprime a impressão Bamatech TH2500
       //              imprimirTexto = MP2032.FormataTX(textoImpressora + "\r\n\r\n", 2, 0, 0, 0, 1);
       //              imprimirTexto = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
       //              if (MessageBox.Show("Deseja emitir a segunda via?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
       //              {
       //                  ImprimirNaImpressoraBematech();
       //              }
       //              limpar();
       //          }
       //      }
       //  }
       //  catch (Exception ex)
       //  {
       //      MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
       //  }

        }

        public void ImprimirCozinha()
        {
            //try
            //{
            //    if (ckModoImpressao.Checked == true)
            //    {
            //        //   MessageBox.Show("Entrei..........");
            //        int imagem = 0;
            //        int imprimirTexto = 0;
            //        //iniciando a Impressao
            //        int codVendaObj = 0;
            //        int codvendatextBox = 0;
            //
            //        DataTable tabCupom = objVen.FormarCupom(objVen.codigo);
            //        if (tabCupom.Rows.Count > 0)
            //        {
            //            //  MessageBox.Show("eu tenho unformações");
            //            int x = Convert.ToInt32(12);
            //            int y = Convert.ToInt32(12);
            //            int angulo = Convert.ToInt32(0);
            //
            //            //  imagem = MP2032.ImprimeBmpEspecial("C:\\One\\LogoCliente.bmp", x, y, angulo);
            //            String textoImpressora;
            //            string ticket = "";
            //            string nomepedido = "";
            //            if (txtTicket.Text == "0")
            //            {
            //                ticket = txtTicket.Text.ToString();
            //                nomepedido = "M E S A Nº";
            //            }
            //            else
            //            {
            //                nomepedido = "B A L C Â O";
            //            }
            //            textoImpressora = "-----------------------------------------------" + Environment.NewLine;
            //            textoImpressora += "       P E D I D O   " + nomepedido + ticket + Environment.NewLine;
            //            textoImpressora += "-----------------------------------------------" + Environment.NewLine;
            //            textoImpressora += "DATA:" + tabCupom.Rows[0]["Data da Venda"].ToString() + "  CUPOM:" + objVen.codigo.ToString() + Environment.NewLine;
            //            textoImpressora += "-----------------------------------------------" + Environment.NewLine;
            //            textoImpressora += "ITEM  " + "DESCRIÇÃO " + "QTD  " + Environment.NewLine;
            //            textoImpressora += "-----------------------------------------------" + Environment.NewLine;
            //            for (int i = 0; i < tabCupom.Rows.Count; i++)
            //            {
            //                textoImpressora += i + " " + tabCupom.Rows[i]["CodigoBarras"].ToString() + "  " + tabCupom.Rows[i]["Produto"].ToString() + "  " + tabCupom.Rows[i]["Unidade"].ToString() + Environment.NewLine; //+ tabCupom.Rows[i]["Quantidade"].ToString() + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + "  " + "  " +  tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
            //                if (tabCupom.Rows[i]["Unidade"].ToString() == "KG")
            //                {
            //                    textoImpressora += "Peso Bruto " + tabCupom.Rows[i]["Peso Bruto"].ToString() + " - " + tabCupom.Rows[i]["Tara"] + " = " + tabCupom.Rows[i]["Quantidade"] + Environment.NewLine;
            //                }
            //                else
            //                {
            //                    textoImpressora += "QTD " + tabCupom.Rows[i]["Quantidade"].ToString() + Environment.NewLine;
            //                }
            //            }
            //            textoImpressora += "----------------------------------------------" + Environment.NewLine;
            //            textoImpressora += "                                           " + Environment.NewLine;
            //
            //            //Imprime a impressão Bamatech TH2500
            //            imprimirTexto = MP2032.FormataTX(textoImpressora + "\r\n\r\n", 2, 0, 0, 0, 1);
            //            imprimirTexto = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
            //            if (MessageBox.Show("Deseja emitir a segunda via do pedido da cozinha?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                ImprimirCozinha();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            //}

        }

        private void btF10_Click(object sender, EventArgs e)
        {
            ImprimirNaImpressoraBematech();

        }

        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            //  txtCodigoBarra.Focus();
        }

        private void txtQuantidade_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            txtCodigoBarra.Focus();
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            EnterMesa = 0;
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            //Open(2, 2400, "Even", 2, 17);
            //MessageBox.Show("Porta Aberta com sucesso");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //Test(2, 2400, "Even", 2, 17);
            //MessageBox.Show("teste realizado  com sucesso");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void ckdVenda_CheckedChanged(object sender, EventArgs e)
        {
            if (ckdVenda.Checked == true)
            {
                cbTipoVenda.SelectedIndex = 0;
                ckdVendaPendente.Checked = false;
                txtCodigoBarra.Focus();
            }
        }

        private void ckdVendaPendente_CheckedChanged(object sender, EventArgs e)
        {
            if (ckdVendaPendente.Checked == true)
            {
                cbTipoVenda.SelectedIndex = 1;
                txtCodigoBarra.Focus();
                ckdVenda.Checked = false;
                lblInfo.Text = "";
                OnePDV();
            }
        }

        private void txtTicket_KeyDown(object sender, KeyEventArgs e)
        {
            if (EnterMesa == 1)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCodigoBarra.Select();
                }
            }
        }

        private void button6_Click_2(object sender, EventArgs e)
        {

        }

        private void SetarTrackBar()
        {
            /*
             * atualiza as posições dos cursores
             * nos trackbars e os valores apresentados pelos
             * labels
             */
            podeAlterar = false;
            podeAlterar = true;
        }

        private void pnl04_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            frmObs frm = new frmObs();
            frm.ShowDialog();
            frm.txtobs.Text = txtObs.Text;
            frm = null;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void HabilitarCamnpos(bool habilitar)
        {
            //btnMais.Enabled = habilitar;
            //btnMenos.Enabled = habilitar;
        }

        private void AdicionarItem()
        {
            decimal Qtd = decimal.Parse(txtQuantidade.Text.ToString());
            HabilitarCamnpos(true);
            try
            {
                if (Qtd > 0)
                {
                    if (EnterMesa == 0)
                    {
                        lblInfo.Visible = true;
                        inserirInte();
                        lblInfo.Text = "C A I X A   O C U P A D O";
                        txtTara.Text = "";
                        txtQuantidade.Text = "";
                        txtValorUnitario.Text = "";
                        txtSubtotal.Text = "";
                    }
                }
                else
                {
                    throw new Exception("Não pode ser inserido quantidade menor que zero");

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtQuantidade.Text = "1";
            }
        }

        private void btnMais_Click(object sender, EventArgs e)
        {

        }

        private void btnMenos_Click(object sender, EventArgs e)
        {

        }

        private void txtTara_TextChanged(object sender, EventArgs e)
        {

        }

        private void adcionarDinheiroToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAdicionarDinheiroCaixa_ frm = new frmAdicionarDinheiroCaixa_();
            frm.txtUsuario.Text = txtUsuario.Text;
            frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
            frm.ShowDialog();
        }

        private void consultaMovimentoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaMovimentoCaixa frm = new frmConsultaMovimentoCaixa();
            frm.lblNumerCaixa.Text = lblNumerCaixa.Text;
            frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
            frm.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
            frm.txtUsuario.Text = txtUsuario.Text.ToString();
            frm.txtUsuario.Text = txtUsuario.Text;
            frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
            frm.ShowDialog();
        }

        private void ckdModoPanelVisions_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarra_TextChanged_1(object sender, EventArgs e)
        {
            EnterMesa = 0;
        }

        private void ckModoImpressao_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panelCategorias_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLocalizarMesa_Leave(object sender, EventArgs e)
        {
            LocalizarMesaPesquisar();
        }

        public void RestaurarCoresEncerramento()
        {
        }

        public void LocalizarMesaPesquisar()
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtLocalizarMesa.Text, out cod);
                if (cod != 0)
                {
                    objVen.limpar();
                    objVen.localizarLeave(cod.ToString(), "ven_ticket");
                    if (objVen.codigo != 0)
                    {
                        carregaCampos();
                        txtCodigoBarra.Select();
                    }
                    else
                        limpar();
                }
                else
                    limpar();
                if (MessageBox.Show("Deseja finalizar a conta?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    cbTipoVenda.SelectedIndex = 0; //Venda
                    lblInfo.Visible = true;
                    lblInfo.Text = "TICKET " + txtTicket.Text + "F2 PARA FAZER O PAGTO!";
                    ckdVenda.Checked = true;
                    RestaurarCoresEncerramento();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPesoBruto_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // txtTicket.Visible = true;
            // label14.Visible = true;
            ckdVendaPendente.Checked = true;
            cbTipoVenda.SelectedIndex = 1;
            ckdVenda.Checked = false;
            txtTicket.Focus();
            EnterMesa = 1;
            OnePDV();
            frmPedidoMesa frm = new frmPedidoMesa();
            frm.EDisponivel = true;
            frm.ShowDialog();
            if (frm.Codigo != null)
                CarregarToushMesa(frm.Finaliza, frm.Codigo.ToString());
        }

        private void frmLojaToush_Shown(object sender, EventArgs e)
        {
            LoadPDV();
        }

        private void button8_Click_2(object sender, EventArgs e)
        {

        }

        private void txtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        public DataTable VerificarMesaSQL(int Ticket)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select * from Vendas Where Ven_ticket = @Ticket");
                cmd.Parameters.Add(new SqlParameter("@Ticket", SqlDbType.Int)).Value = Ticket;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lblDataEHora.Text = DateTime.Now.ToString();
            lblHourPDV.Text = DateTime.Now.ToString();
        }

        private void txtQuantidade_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void txtQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                inserirNoGrid();
            }
        }

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar != '\b')
            {
                if (!string.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    inserirNoGrid();
                }
                if (e.KeyChar == (char)13)
                {
                    txtCodigoBarra.Clear();
                    txtNomeProduto.Text = "";
                }
            }
            else
            {
                txtNomeProduto.Text = "";
            }

        }

        private void txtCodigoBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 39 && e.KeyValue != 37)
            {
                if (LocalizarProduto() > 0)
                {

                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (LocalizarProduto() > 0)
                    inserirNoGrid();
            }

        }

        private void inserirNoGrid()
        {

            Inserindo = true; //indica que esta inserindo para a fila
            if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                txtCodigoBarra.Clear();
                return;
            }
            int qtd = 0;
            if (!string.IsNullOrEmpty(txtQuantidade.Text) && int.TryParse(txtQuantidade.Text, out qtd) && qtd > 0)
            {
                txtQuantidade.Text = txtQuantidade.Text;
            }

            decimal qtdTotalItem = decimal.Parse(txtSubtotal.Text);
            decimal qtdItens = decimal.Parse(txtQuantidade.Text);
            decimal vlrUnitario = decimal.Parse(txtValorUnitario.Text);
            txtSubtotal.Text = (qtdItens * vlrUnitario).ToString();

            #region SALVA PRODUTO
            if (EnterMesa == 0)
            {
                int CodProduto = 0;
                if (txtCodigoProduto.Text != "")
                {
                    CodProduto = int.Parse(txtCodigoProduto.Text.ToString());
                }
                DataTable tabProduto = null;
                tabProduto = CarregarProdutosPesoSQL(CodProduto);
                if (tabProduto.Rows.Count > 0)
                {
                    HabilitarCamnpos(false);
                    //[Error]CalcularPesoProduto(); erro nessa função atualmente  (11/03/2017) - luiz

                }
                else
                {
                    epeso = false;
                    HabilitarCamnpos(true);
                }
                if (txtNomeProduto.Text == "")
                {
                    txtDinamic.Text = "";
                }
                else
                {
                    if (epeso == false)
                        txtDinamic.Text = txtQuantidade.Text + " X";
                }
                txtPesoBruto.Text = "";
                if (txtCodigoProduto.Text != "")
                {
                    lblInfo.Visible = true;
                    if (txtQuantidade.Text != "")
                    {
                        if (txtQuantidade.Text.ToString() == "IIIII")
                        {
                            txtCodigoBarra.Focus();
                            txtQuantidade.Text = "1";
                            throw new Exception("Ocorreu um erro com a comunicação com a balança. A balança não retornou um valor valido para o sistema");
                        }
                        decimal QuantidadeRetornada = decimal.Parse(txtQuantidade.Text);
                        if (QuantidadeRetornada <= 0)
                        {
                            txtQuantidade.Text = "0";
                            //txtCodigoBarra.Text = "";
                            txtCodigoBarra.Focus();
                            throw new Exception("!Atenção!Não foi possivél obter o peso da balança!");
                        }
                    }
                    inserirInte();
                    SystemSounds.Asterisk.Play();
                    lblInfo.Text = "C A I X A   O C U P A D O";
                    txtTara.Text = "";
                    txtNomeProduto.Text = "";
                    txtDinamic.Text = "";
                }
                else
                {
                    MessageBox.Show("Produto não localizado", "Produto invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                AlterarPeso = false;
            }
            Inserindo = false;
            if (dgDados.RowCount == 1) //primeiro produto a entrar ?
                FrenteDeCaixa_KeyDown(this, new KeyEventArgs(Keys.F5));
            #endregion SALVA PRODUTO
        }

        private void frmPDVSkin_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                int i;
                for (i = 0; i < dgDados.Rows.Count; i++) /*Empty*/;

                txtQtdItenVenda.Text = i.ToString();
            }
        }
    }
                    #endregion
}