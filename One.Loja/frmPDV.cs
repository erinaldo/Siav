//using ImprimeCupom;
//using CDSSoftware;
using One.Bll;
using One.Dal;
using One.FrenteDeLoja;
using One.MOVIMENTACOES;
using One.RELATORIOS;
using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmPDV : Form
    {
        Contexto con = null;

        String txtCodigoProduto;
        String txtQuantidadeTotal;
        String txtDinamic;
        String txtTara;
        String txtPesoBruto;
        String txtValorTotal;
        //String txtTotalFinal;
        String txtQtdItenVenda;
        String txtCodigo;
        String txtTotalItens;
        String lblNumerCaixa;
        String txtCodigoCliente;
        String txtData;
        String txtObservacao;
        String txtDescontoValor;
        String txtDescontoPercentual;
        String txtTicket;
        String lblMsgMesa;
        String txtvrRecebido;
        String txtvrTroco;
        List<string> lista_troca;
        Boolean cbRenovarVenda;

        public String txtUsuario;
        decimal txtSubtotal;
        Boolean ckModoImpressao;

        private bool Inserindo = false;
        public int EnterMesa = 0;

        bool podeAlterar = false;

        public bool epeso = false;

        public bool AlterarPeso = false;
        public bool javiu { get; set; }
        public decimal Tara { get; set; }
        public bool cancelouFpg { get; set; }
        public string NumeroDoPedido { get; set; }
        public int ItemRemove { get; set; }
        public int CountItem { get; set; }



        // Propriedades para troca de produto
        Boolean pdv_troca = false;
        String n_cupom;


        VendasBLL objVen = new VendasBLL();
        vendaItensBLL objVI = new vendaItensBLL();

        public frmPDV(string Pedido)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            InitializeComponent();
            NumeroDoPedido = Pedido;

            try
            {
                Contexto objD = new Contexto();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from configuracao";
                DataTable tab = objD.ExecutaConsulta(cmd);

                //if (tab.Rows[0].ItemArray[6].ToString() == "s")
                //    cbSelecioner_Vendedor.Checked = true;

                if (tab.Rows[0].ItemArray[7].ToString() == "s")
                    checkAtacado.Visible = true;



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
                //ckdVenda.Checked = true;
                txtCodigoCliente = "1";
                //imageSystemLOgo.Image = Image.FromFile(@"C:\One\image.jpg");
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
                txtNomeProduto.Text = "";
                txtCodigoBarra.Select();
                txtQuantidade.Text = "1";
                lblInfo.Text = "C A I X A  L I V R E";
                SetaCodigovenda();
                if (txtCodigo != "")
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

        private void ValidarLicenca()
        {

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
                    "   Empresa = emp.emp_nomefantasia ",
                    ",	Endereco = emp.emp_logradouro + ' , ' + emp.emp_numero + ' - ' + emp.emp_bairro ",
                    ",	CidadeEstado = cid.cid_nome + ' - ' + est.est_sigla + ' - ' + emp.emp_cep ",
                    ",  CNPJ = 'CNPJ: ' + emp.emp_cnpj +'         IE:' + emp.emp_inscricaoEstadual",
                    ",  IE = emp.emp_inscricaoEstadual ",
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


        private void txtCodigoBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 39 && e.KeyValue != 37)
            {
                if (LocalizarProduto() > 0)
                {

                }
                else
                {
                    Image myImage = global::One.Loja.Properties.Resources.foto_vazia;
                    imagem_produto.Image = myImage;
                    imagem_produto.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }

            if (e.KeyCode == Keys.Enter)
            {
                inserirNoGrid();
            }

            verifica_f(e);
        }


        public void SetaCodigovenda()
        {
            txtCodigo = NumeroDoPedido;
        }

        public void LocalizarPedido()
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo, out cod);
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

        public void carregaCampos()
        {
            try
            {
                dgDados.Rows.Clear();
                txtCodigo = objVen.codigo.ToString();
                txtData = objVen.data.ToString();
                txtCodigoCliente = objVen.cliente.ToString();
                cbFuncionario.SelectedValue = objVen.usuario;
                //objVen.forma_pagamento;
                //objVen.parcelas = 0;
                txtValorTotal = objVen.valor.ToString();
                txtTotalFinal.Text = objVen.valorFinal.ToString();
                txtObservacao = objVen.observacao;
                txtDescontoValor = objVen.desconto.ToString();
                txtDescontoPercentual = objVen.percentual.ToString();

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

                txtTotalItens = qtdade.ToString();

                txtDescontoValor = Convert.ToDecimal(txtDescontoValor).ToString();
                txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString();
                txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";

                txtTicket = objVen.ven_ticket.ToString();

                if (objVen.ven_ticket.ToString() != "0")
                {
                    lblMsgMesa = String.Concat("Mesa|Ticket Número : ", objVen.ven_ticket.ToString(), " selecionado");
                }

                if (objVen.ven_status == "Cancelado")
                {
                    lblInfo.Visible = true;
                    // cbRenovarVenda.Visible = true;
                    cbRenovarVenda = false;
                }
                else
                {
                    //lblInfo.Visible = false;

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

                // txtDescontoPercentual.Enabled = false;
                // txtDescontoValor.Enabled = false;
            }
            catch (Exception)
            {

                throw;
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
                    try
                    {
                        if (objPro.pro_imagem.Length > 0 && objPro.pro_imagem != null)
                        {
                            //  byte[] data0 = (byte[])tab.Rows[0]["Imagem"];
                            MemoryStream ms0 = new MemoryStream(objPro.pro_imagem);
                            imagem_produto.Image = Image.FromStream(ms0);
                            //  pictImageProduto.Image = Image.FromStream(ms0);
                        }
                        else
                        {
                            Image myImage = global::One.Loja.Properties.Resources.foto_vazia;
                            imagem_produto.Image = myImage;
                            imagem_produto.SizeMode = PictureBoxSizeMode.StretchImage;

                            // String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                            // imagem_produto.Image = Image.FromFile(path + "Resources\\vazia.jpg");



                            //imagem_produto.Image.Dispose();
                        }
                    }
                    catch
                    {
                        Image myImage = global::One.Loja.Properties.Resources.foto_vazia;
                        imagem_produto.Image = myImage;
                        imagem_produto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }


                    if (objPro.pro_comissao != 0)
                    {
                        // HabilitarCamnpos(false);
                    }
                    txtCodigoProduto = objPro.pro_codigo.ToString();
                    txtNomeProduto.Text = objPro.pro_nome;
                    txtQuantidadeTotal = objPro.pro_quantidade.ToString();
                    
                    if(checkAtacado.Checked)
                        txtValorUnitario.Text = objPro.pro_precoAtacado.ToString();
                    else
                        txtValorUnitario.Text = objPro.pro_precoVenda.ToString();

                    // txtValorUnitario.Enabled = true;
                    txtQuantidade.Enabled = true;
                    if (txtQuantidade.Text == ""){
                        txtQuantidade.Text = "1";
                    }

                    //txtValorUnitario.Text = objPro.pro_precoVenda.ToString();
                    //Se a quantidade for diferente de 0 .
                    if (txtQuantidade.Text != ""){

                        decimal qtd = decimal.Parse(txtQuantidade.Text);
                        decimal valorUnitario = decimal.Parse(txtValorUnitario.Text);
                        decimal Subtotal = qtd * valorUnitario;

                        txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();
                        //  txtSubtotal.ReadOnly = false;
                        txtSubtotal = Subtotal;
                        // txtSubtotal.ReadOnly = true;
                        
                    }
                    else if (txtValorUnitario.Text != "")
                        txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();

                    if (!string.IsNullOrEmpty(txtNomeProduto.Text) && txtNomeProduto.Text.Length > 0)
                    {
                        txtCodigoBarra.SelectionStart = 0;
                        txtCodigoBarra.SelectionLength = txtCodigoBarra.Text.Length;
                    }



                    //imagem_produto.
                }
                //Se não Encontrar 
                else
                {
                    //  txtNomeProduto.Text = "";
                    txtQuantidadeTotal = "";
                    txtValorUnitario.Text = "";
                    //txtQuantidade.Text = "1";
                    //txtValorUnitario.Enabled = false;
                    txtSubtotal = 0;
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

        private void inserirNoGrid()
        {
            try
            {
                this.Inserindo = true;
                if (string.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    txtCodigoBarra.Clear();
                    return;
                }
                int qtd = 0;
                if (!string.IsNullOrEmpty(txtQuantidade.Text) && int.TryParse(txtQuantidade.Text, out qtd) && qtd > 0){
                    txtQuantidade.Text = txtQuantidade.Text;
                }

                decimal qtdTotalItem = txtSubtotal;
                decimal qtdItens = decimal.Parse(txtQuantidade.Text);
                decimal vlrUnitario = decimal.Parse(txtValorUnitario.Text);
                txtSubtotal = qtdItens * vlrUnitario;

                #region SALVA PRODUTO
                if (EnterMesa == 0)
                {
                    int CodProduto = 0;
                    if (txtCodigoProduto != "")
                    {
                        CodProduto = int.Parse(txtCodigoProduto.ToString());
                    }
                    DataTable tabProduto = null;
                    tabProduto = CarregarProdutosPesoSQL(CodProduto);
                    if (tabProduto.Rows.Count > 0)
                    {
                        //HabilitarCamnpos(false);
                        //[Error]CalcularPesoProduto(); erro nessa função atualmente  (11/03/2017) - luiz

                    }
                    else
                    {
                        epeso = false;
                        //HabilitarCamnpos(true);
                    }
                    if (txtNomeProduto.Text == "")
                    {
                        txtDinamic = "";
                    }
                    else
                    {
                        if (epeso == false)
                            txtDinamic = txtQuantidade.Text + " X";
                    }
                    txtPesoBruto = "";
                    if (txtCodigoProduto != "")
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
                                txtCodigoBarra.Focus();
                                throw new Exception("!Atenção!Não foi possivél obter o peso da balança!");
                            }
                        }
                        inserirInte();
                        SystemSounds.Asterisk.Play();
                        lblInfo.Text = "C A I X A   O C U P A D O";
                        txtTara = "";
                        txtNomeProduto.Text = "";
                        txtCodigoBarra.Text = "";
                        txtQuantidade.Text = "1";
                        txtDinamic = "";
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

            }catch (Exception e){
                MessageBox.Show("Erro ao buscar o produto : " + e.Message);
            }
        }


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
                for (int j = 0; j <= txtSubtotal.ToString().Length - 1; j++)
                {
                    if ((txtSubtotal.ToString()[j] >= '0' &&
                    txtSubtotal.ToString()[j] <= '9') ||
                    txtSubtotal.ToString()[j] == ',')
                    {
                        x += txtSubtotal.ToString()[j];
                    }
                }
                txtSubtotal = decimal.Parse(x);

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

                if (txtSubtotal == 0)
                    throw new Exception("O campo subtotal deve possui um número real maior que 0");

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
                    txtValorTotal = total.ToString();
                    txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString();
                    txtTotalFinal.Text = total.ToString();
                    txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text), 2) + "";
                    txtSubtotal = txtSubtotal;
                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();
                    txtQuantidade.Text = "";
                    txtCodigoBarra.Focus();
                }
                ProdutosBLL objPro = new ProdutosBLL();
                objPro.localizar("pro_codigo", txtCodigoProduto.ToString());
                //Primeira vez que está inserindo o produto
                if (achou != "Sim")
                {
                    int item = 00;
                    item = CountItem += 1;
                    String CodigoVenda = String.Empty;
                    int NumQtdVenda = 0;
                    if (txtQtdItenVenda != String.Empty && txtQtdItenVenda != null && txtQtdItenVenda != "null")
                    {
                        NumQtdVenda = int.Parse(txtQtdItenVenda);
                        NumQtdVenda += 1;
                        txtQtdItenVenda = NumQtdVenda.ToString();
                    }
                    else
                    {
                        NumQtdVenda += 1;
                    }

                    if (txtCodigo != String.Empty)
                    {
                        CodigoVenda = txtCodigo.ToString();
                    }
                    else
                    {
                        CodigoVenda = item.ToString();
                    }

                    if (decimal.Parse(txtQuantidade.Text) > decimal.Parse(txtQuantidadeTotal))
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
                            dgDados.Rows.Add(1, txtCodigoProduto.ToString(), objPro.pro_nome, txtQuantidade.Text, Convert.ToDecimal(txtValorUnitario.Text).ToString(), Convert.ToDecimal(txtSubtotal).ToString(), txtTara);
                            txtQtdItenVenda = "1";
                        }
                        else
                        {

                            for (int i = 0; i <= dgDados.Rows.Count - 1; i++)
                            {
                                if (dgDados.Rows[i].Cells[1].Value.ToString() == txtCodigoProduto.ToString())
                                {
                                    quantidadeDisponivel = decimal.Parse(txtQuantidadeTotal);
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
                                       , txtCodigoProduto.ToString()
                                       , objPro.pro_nome
                                       , txtQuantidade.Text
                                       , Convert.ToDecimal(txtValorUnitario.Text).ToString()
                                       , Convert.ToDecimal(txtSubtotal).ToString()
                                       , txtTara
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
                    txtValorTotal = total.ToString();
                    txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString();
                    txtTotalFinal.Text = total.ToString();
                    txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";

                    txtSubtotal = Convert.ToDecimal(txtSubtotal.ToString());
                    txtValorUnitario.Text = Convert.ToDecimal(txtValorUnitario.Text).ToString();


                }
                decimal qtdade = 0;
                for (int i = 0; i < dgDados.Rows.Count; i++)
                    qtdade += decimal.Parse(dgDados.Rows[i].Cells[3].Value.ToString());

                txtTotalItens = qtdade.ToString();

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

        private void FrenteDeCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //HabilitarCamnpos(true);
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
                            if (pdv_troca)
                            {
                                decimal valor_compra = decimal.Parse(txtTotalFinal.Text.Replace(',', '.'));
                                decimal valor_troca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));

                                if (valor_troca > valor_compra)
                                {
                                    MessageBox.Show("Valor de total da compra deve ser maior ou igual ao valor da troca !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    throw new Exception();
                                }
                            }


                            lblInfo.Visible = true;
                            txtPesoBruto = "";
                            //txtTicket.Visible = false;
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
                            txtCodigoCliente = "1";
                            //txtCodigo.Visible = false;
                            CountItem = 0;
                            lblMsgMesa = ". . . PDV Online";
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
                            //cancelarAcao();
                            //lblInfo.Text = "C A I X A   L I V R E";
                            //OnePDV();
                            //lblCpf.Text = "";
                        }
                        break;
                    case Keys.F4:

                        frmSegundaViaCupom frmSeg = new frmSegundaViaCupom();
                        frmSeg.ShowDialog();

                        // txtCodigo.Visible = true;
                        // txtCodigo.Focus();
                        // if (txtCodigo.Text != "")
                        // {
                        //     string autoriza = "não";
                        //     if (MessageBox.Show("Tem certeza que deseja cancelar essa Venda?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        //     {
                        //         verificacaoUsuario frm = new verificacaoUsuario();
                        //         frm.ShowDialog();
                        //         if (frm.permissao != "Gerente")
                        //         {
                        //             throw new Exception("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                        //             frm = null;
                        //             autoriza = "Sim";
                        //         }
                        //         else
                        //         {
                        //             cancelarVenda();
                        //             limpar();
                        //         }
                        //     }
                        // }
                        // else
                        // {
                        //     throw new Exception("Precisa informar número do cupom para cancelar !");
                        // }
                        break;
                    case Keys.F5:
                        FrmInputCpf cpf = new FrmInputCpf(this);
                        cpf.ShowDialog();

                        if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 11)
                        {
                            cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"000\.000\.000\-00");
                            // lblCpf.Visible = true;
                        }
                        if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 14) //99.999.999/9999-99
                        {
                            cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"00\.000\.000\/0000\-00");
                            //    lblCpf.Visible = true;
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
                                        txtValorTotal = total.ToString();
                                        txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                                        txtTotalFinal.Text = total.ToString();
                                        txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                                        txtCodigoBarra.Select();
                                    }
                                    else
                                    {
                                        txtValorTotal = "0";
                                        txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                                        txtTotalFinal.Text = "0";
                                        txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                                        txtCodigoBarra.Select();
                                    }


                                    int qtdade = 0;
                                    for (int j = 0; j < dgDados.Rows.Count; j++)
                                        qtdade += int.Parse(dgDados.Rows[j].Cells[3].Value.ToString());

                                    txtTotalItens = qtdade.ToString();

                                    txtDescontoPercentual = "";
                                    txtDescontoValor = "";
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
                        //FechamentoCaixaBLL objFC = new FechamentoCaixaBLL();
                        //
                        //if (objFC.JaFechou(int.Parse(cbFuncionario.SelectedValue.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
                        //{
                        //    throw new Exception("Fechamento diário já foi realizado");
                        //
                        //}
                        //else
                        //{
                        //    frm_FechamentoCaixa frm1 = new frm_FechamentoCaixa(this);
                        //    frm1.lblNumerCaixa.Text = lblNumerCaixa.Text;
                        //    frm1.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                        //    frm1.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
                        //    frm1.txtUsuario.Text = txtUsuario.Text.ToString();
                        //    frm1.ShowDialog();
                        //    lblInfo.Visible = true;
                        //    break;
                        //}
                        break;
                    case Keys.F11:
                        //string autorizar = "não";
                        //if (MessageBox.Show("Tem certeza que deseja excluir o encerramento do caixa?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        //{
                        //    verificacaoUsuario frm = new verificacaoUsuario();
                        //    frm.ShowDialog();
                        //    if (frm.permissao != "Gerente")
                        //    {
                        //        throw new Exception("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                        //        frm = null;
                        //        autorizar = "Sim";
                        //    }
                        //    else
                        //    {
                        //        SqlCommand cmd = null;
                        //        Contexto objD = null;
                        //        try
                        //        {
                        //            objD = new Contexto();
                        //            cmd = new SqlCommand();
                        //            cmd.CommandText = "DELETE FROM fin_fechamento_caixa" +
                        //                " WHERE" +
                        //                " fin_data= CONVERT(char(11),getdate(),113)";
                        //            objD.ExecutaComando(cmd);
                        //            lblInfo.Text = "";
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            throw ex;
                        //        }
                        //        cmd = null;
                        //        objD = null;
                        //    }
                        //}
                        break;
                    case Keys.F12:
                        //frmClientes novaForm2 = new frmClientes(this);
                        //novaForm2.ShowDialog();
                        ////Pegando o valor da propriedade da Form novaForm e colocando no Label
                        //if (novaForm2.Codigo != null)
                        //{
                        //    txtCodigoCliente.Text = novaForm2.Codigo.ToString();
                        //    lblInfo.Visible = true;
                        //    lblInfo.Text = novaForm2.NomeCliente.ToString().ToUpper();
                        //    lblInfo.TextAlign = ContentAlignment.BottomLeft;
                        //}
                        //txtCodigoBarra.Focus();
                        break;
                    case Keys.F10:
                        //ImprimirNaImpressoraBematech();
                        //limpar();
                        break;
                    case Keys.Escape:
                        //if (MessageBox.Show("Deseja realmente encerrar o PDV?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        //{
                        //    // FazerBackupdoSistema();
                        //    Application.Exit();
                        //}
                        break;
                    case Keys.Up:
                        //if (dgDados.FirstDisplayedScrollingRowIndex > 0)
                        //    dgDados.FirstDisplayedScrollingRowIndex = dgDados.FirstDisplayedScrollingRowIndex - 1;
                        break;
                    case Keys.Down:
                        //dgDados.FirstDisplayedScrollingRowIndex = dgDados.FirstDisplayedScrollingRowIndex + 1;
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
                    //frmAdicionarDinheiroCaixa_ frm = new frmAdicionarDinheiroCaixa_();
                    //frm.txtUsuario.Text = txtUsuario.Text;
                    //frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    //frm.ShowDialog();
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                {
                    //frmSangriaCaixa frm = new frmSangriaCaixa();
                    //frm.txtUsuario.Text = txtUsuario.Text;
                    //frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    //frm.ShowDialog();
                }
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
                {
                    //frmConsultaMovimentoCaixa frm = new frmConsultaMovimentoCaixa();
                    //frm.lblNumerCaixa.Text = lblNumerCaixa.Text;
                    //frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    //frm.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
                    //frm.txtUsuario.Text = txtUsuario.Text.ToString();
                    //frm.txtUsuario.Text = txtUsuario.Text;
                    //frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                    //frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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

        private void AbrircaixaAntigo()
        {
            //Se lo caixa estiver encerrado que pode abrir outro
            lblNumerCaixa = global.NumeroCaixa.ToString();

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
                    objAber.caixa = lblNumerCaixa.ToString();
                    objAber.inserir();
                   // if (MessageBox.Show("Deseja Imprimir o valor do Fundo de Caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                   // {
                   //     int iRetorno;
                   //     String impressora;
                   //     iRetorno = MP2032.ConfiguraModeloImpressora(8);
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
                   //         // lblInfo.Text = ("Não foi possível conectar com a impressora!!!");
                   //         // Application.Exit();
                   //     }
                   //     else
                   //     {
                   //         // lblInfo.Text = ("Impressora conectada!!!");
                   //     }
                   //     ImprimeTexto imp = new ImprimeTexto();
                   //     //
                   //     //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
                   //     imp.Inicio("LPT1");
                   //     //
                   //     imp.ImpLF(imp.NegritoOn + "ABERTURA DE CAIXA" + imp.NegritoOff);
                   //     imp.ImpLF("-------------------------------------");
                   //     imp.Pula(1);
                   //     imp.ImpLF("Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString());
                   //     imp.ImpLF("Operador: " + global.nomeUsuario);
                   //
                   //     imp.Pula(2);
                   //     imp.ImpLF("Valor Inicial: R$ " + valor.ToString());
                   //     imp.Pula(2);
                   //     imp.ImpLF("-------------------------------------");
                   //     imp.Fim();
                   //
                   //
                   //     // ImprimeTexto imp = new ImprimeTexto();
                   //     // impressora = "Abertura do Caixa " + Environment.NewLine;
                   //     // impressora += "Valor Inicial:" + valor.ToString() + Environment.NewLine;
                   //     // // impressora += "_______________________" + Environment.NewLine;
                   //     // impressora += "Usuário: " + global.nomeUsuario + Environment.NewLine;
                   //     // impressora += "Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString() + Environment.NewLine;
                   //     // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                   //     // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                   //     //
                   //     // iRetorno = MP2032.FormataTX(impressora + "\r\n\r\n", 3, 0, 0, 1, 1);
                   //     // iRetorno = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
                   // }
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
                objAber.caixa = lblNumerCaixa;
                objAber.inserir();
                //if (MessageBox.Show("Deseja Imprimir o valor do Fundo de Caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    //Declarando as Variaveis 
                //    int iRetorno; // Configurar Modelo da Impressora
                //    String impressora; // Impressora
                //    iRetorno = MP2032.ConfiguraModeloImpressora(8); // Configurar Modelo da Impressora 
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
                //        //  lblInfo.Text = ("Não foi possível conectar com a impressora!!!");
                //        // Application.Exit();
                //    }
                //    else
                //    {
                //        //lblInfo.Text = ("Impressora conectada!!!");
                //    }
                //
                //    ImprimeTexto imp = new ImprimeTexto();
                //    //
                //    //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
                //    //ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
                //    imp.Inicio("LPT1");
                //    //
                //    imp.ImpLF(imp.NegritoOn + "ABERTURA DE CAIXA" + imp.NegritoOff);
                //    imp.ImpLF("-------------------------------------");
                //    imp.Pula(1);
                //    imp.ImpLF("Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString());
                //    imp.ImpLF("Operador: " + global.nomeUsuario);
                //
                //    imp.Pula(2);
                //    imp.ImpLF("Valor Inicial: R$ " + valor.ToString());
                //    imp.Pula(2);
                //    imp.ImpLF("-------------------------------------");
                //    imp.Fim();
                //
                //    // ImprimeTexto imp = new ImprimeTexto();
                //    // impressora = "Abertura do Caixa " + Environment.NewLine;
                //    // impressora += "Valor Inicial:" + valor.ToString() + Environment.NewLine;
                //    // // impressora += "_______________________" + Environment.NewLine;
                //    // impressora += "Usuário: " + global.nomeUsuario + Environment.NewLine;
                //    // impressora += "Data:" + objAber.data.ToString("dd/mm/yyyy") + " " + objAber.hora.ToString() + Environment.NewLine;
                //    // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                //    // impressora += "               " + Environment.NewLine;  //+ valor.ToString();
                //    //
                //    // iRetorno = MP2032.FormataTX(impressora + "\r\n\r\n", 3, 0, 0, 1, 1);
                //    // iRetorno = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
                //}
            }   //
            ObterIDAbertura();
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

        public void OnePDV()
        {
            DataTable tab = null;
            tab = OnePDV_ConfigSQL();
            if (tab.Rows[0]["Impressora"].ToString() == "Outras")
            {
                //ckModoImpressao.Checked = false;
            }
            else if (tab.Rows[0]["Impressora"].ToString() != "Outras")
            {
                //ckModoImpressao.Checked = true;
            }
            if (tab.Rows[0]["Balança"].ToString() != "")
            {
                //lblNomeBalanca.Text = tab.Rows[0]["Balança"].ToString();
            }
            if (tab.Rows[0]["MensagemCupom"].ToString() != "")
            {
                //lblMsgCupom.Text = tab.Rows[0]["MensagemCupom"].ToString();
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

        public void limpar()
        {
            try
            {
                txtCodigo = "false";
                cancelouFpg = false;
                // txtLocalizarMesa.Text = "";
                txtPesoBruto = "";
                cbFuncionario.SelectedValue = global.codUsuario;
                // txtObservacao.Visible = false;
                txtCodigo = "";
                txtData = DateTime.Now.ToString();
                txtObservacao = "";
                txtQuantidade.Text = "1";
                txtSubtotal = 0;
                txtTotalFinal.Text = "";
                txtTotalItens = "";
                txtValorUnitario.Text = "";
                txtNomeProduto.Text = "";
                dgDados.Rows.Clear();
                txtDescontoValor = "";
                //txtDesconto.Text = "";
                txtValorTotal = "";
                txtDescontoPercentual = "";
                txtDescontoValor = "";
                txtSubtotal = 0;
                // txtPercentual.Text = "";
                txtQuantidade.Text = "";
                txtQuantidadeTotal = "";
                txtCodigoBarra.Text = "";
                cbTipoVenda.SelectedIndex = 0;
                btnAlterarTipoVenda.Enabled = true;
                cbTipoVenda.Enabled = true;
                //txtValorUnitario.Enabled = true;
                txtQuantidade.Enabled = true;
                cbRenovarVenda = true;
                //txtDescontoPercentual = true;
                //txtDescontoValor = true;
                txtTicket = "0";
                txtTara = "0";
                txtCodigoCliente = "1";
                txtDinamic = "";
                cpf_cliente.Text = "";
                pdv_troca = false;
                gb_troca.Visible = false;

                Image myImage = global::One.Loja.Properties.Resources.foto_vazia;
                imagem_produto.Image = myImage;
                imagem_produto.SizeMode = PictureBoxSizeMode.StretchImage;
                //   String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                //   imagem_produto.Image = Image.FromFile(path + "Resources\\vazia.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ckdVendaPendente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ckdVenda_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmPDV_KeyUp(object sender, KeyEventArgs e)
        {

        }


        public void verifica_f(KeyEventArgs e)
        {
            try
            {

                switch (e.KeyData)
                {
                    case Keys.F5:
                        frmCancelamentoCupom frm_cancel = new frmCancelamentoCupom();
                        frm_cancel.ShowDialog();
                        // do whatever
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
                                        txtValorTotal = total.ToString();
                                        txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                                        txtTotalFinal.Text = total.ToString();
                                        txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                                        txtCodigoBarra.Select();
                                    }
                                    else
                                    {
                                        txtValorTotal = "0";
                                        txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                                        txtTotalFinal.Text = "0";
                                        txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                                        txtCodigoBarra.Select();
                                    }


                                    int qtdade = 0;
                                    for (int j = 0; j < dgDados.Rows.Count; j++)
                                        qtdade += int.Parse(dgDados.Rows[j].Cells[3].Value.ToString());

                                    txtTotalItens = qtdade.ToString();

                                    txtDescontoPercentual = "";
                                    txtDescontoValor = "";
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
                    case Keys.F2:
                        Boolean prosseguir = true;
                        if (dgDados.Rows.Count > 0 || !string.IsNullOrEmpty(txtNomeProduto.Text))
                        {
                            if (pdv_troca)
                            {
                                decimal valor_compra = decimal.Parse(txtTotalFinal.Text.Replace(',', '.'));
                                decimal valor_troca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));

                                if (valor_troca > valor_compra)
                                {
                                    MessageBox.Show("Valor de total da compra deve ser maior ou igual ao valor da troca !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    prosseguir = false;
                                }
                            }

                            if (prosseguir)
                            {
                                lblInfo.Visible = true;
                                txtPesoBruto = "";
                                //txtTicket.Visible = false;
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
                                txtCodigoCliente = "1";
                                //txtCodigo.Visible = false;
                                CountItem = 0;
                                lblMsgMesa = ". . . PDV Online";
                                lblCpf.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Informe um produto para finalizar a venda", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;

                    case Keys.F3:
                        if (MessageBox.Show("Deseja realmente limpar os dados da venda?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            cancelarAcao();
                            lblInfo.Text = "C A I X A   L I V R E";
                            OnePDV();
                            lblCpf.Text = "";
                        }
                        // do whatever
                        break;


                    case Keys.F4:
                        frmSegundaViaCupom frmSeg = new frmSegundaViaCupom();
                        frmSeg.ShowDialog();

                        break;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCancelamentoCupom frm_cancel = new frmCancelamentoCupom();
            frm_cancel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente limpar os dados da venda?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                cancelarAcao();
                lblInfo.Text = "C A I X A   L I V R E";
                OnePDV();
                lblCpf.Text = "";
            }
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



        public void carregaPropriedades()
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValorTotal.Length - 1; i++)
                {
                    if ((txtValorTotal[i] >= '0' &&
                    txtValorTotal[i] <= '9') ||
                    txtValorTotal[i] == ','){
                        x += txtValorTotal[i];
                    }
                }
                txtValorTotal = x;

                x = "";
                for (int i = 0; i <= txtTotalFinal.Text.Length - 1; i++){
                    if ((txtTotalFinal.Text[i] >= '0' &&
                    txtTotalFinal.Text[i] <= '9') ||
                    txtTotalFinal.Text[i] == ','){
                        x += txtTotalFinal.Text[i];
                    }
                }
                txtTotalFinal.Text = x;

                x = "";
                for (int i = 0; i <= txtDescontoValor.Length - 1; i++)
                {
                    if ((txtDescontoValor[i] >= '0' &&
                    txtDescontoValor[i] <= '9') ||
                    txtDescontoValor[i] == ',')
                    {
                        x += txtDescontoValor[i];
                    }
                }
                txtDescontoValor = x;


                //Vendas
                if (txtCodigo != "")
                    objVen.codigo = int.Parse(txtCodigo);
                else
                    objVen.codigo = 0;
                txtData = txtData.Trim();
                if (txtData != "")
                    objVen.data = DateTime.Parse(txtData);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacao = txtObservacao.Trim();
                if (txtObservacao != "")
                    objVen.observacao = txtObservacao;
                else
                    objVen.observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a venda");
                else
                    objVen.usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
                //if (cbCliente.SelectedValue == null)
                
                objVen.cliente = int.Parse(txtCodigoCliente);//int.Parse("23");


                if (txtDescontoPercentual == "")
                    objVen.percentual = 0;
                else
                    objVen.percentual = decimal.Parse(txtDescontoPercentual);

                if (txtDescontoValor == "")
                    objVen.desconto = 0;
                else
                    objVen.desconto = decimal.Parse(txtDescontoValor);

                objVen.valor = decimal.Parse(txtValorTotal);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text);

                objVen.ven_ticket = int.Parse(txtTicket);

                lblInfo.Text = "V E N D A  F I N A L I Z A";
                if (cbRenovarVenda == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda == false)
                    objVen.ven_status = "Cancelado";

                objVen.ven_tipo = cbTipoVenda.SelectedItem.ToString();

                objVen.IDAber = int.Parse(lblCodigoAbertura.Text.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void salvarVendapdv()
        {
            try
            {
                if (txtCodigo == "") //Insert
                {

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
                        tabVerificarMesa = VerificarMesaSQL(int.Parse(txtTicket));
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
                            cmd.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int)).Value = int.Parse(txtTicket);
                            objD.ExecutaComando(cmd);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        cmd = null;
                        objD = null;
                        //IncluirRegistroAtendimentoMesa();
                    }
                    #endregion
                    #region Forma de Pagamento Chama a Tela no Load
                    if (cbTipoVenda.Text == "Venda")
                    {
                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        frmPDV_Finalizadora frm = new frmPDV_Finalizadora(this);
                        frm.txtTotalGeralVendaBruto.Text = txtTotalFinal.Text;
                        frm.txtTotalRestante.Text = txtTotalFinal.Text;
                        frm.txtVendaID.Text = objVen.codigo.ToString();
                        frm.txtUsuario.Text = txtUsuario;
                        frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                        frm.lblCodigoCliente.Text = txtCodigoCliente;
                        frm.cpf = this.cpf_cliente.Text;

                        if (pdv_troca)
                        {
                            frm.valorTroca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));
                            frm.lista_troca = this.lista_troca;
                        }
                        //frm.TopLevel = false;
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
                            txtvrRecebido = frm.valorRecebido;
                            txtvrTroco = frm.valorTroco;
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

                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        //frmFinalizadora__PDV frm = new frmFinalizadora__PDV(this);
                        frmPDV_Finalizadora frm = new frmPDV_Finalizadora(this);
                        // frmFechamentoDetalhe frm = new frmFechamentoDetalhe();
                        //frm.txtvrTotal.Text = (txtTotalFinal.Text);
                        //frm.txtvrRecebido.Focus();
                        //frm.txtTotalItens.Text = txtTotalItens.Text.ToString();
                        frm.txtTotalGeralVendaBruto.Text = txtTotalFinal.Text;
                        frm.txtTotalRestante.Text = txtTotalFinal.Text;
                        frm.txtVendaID.Text = objVen.codigo.ToString();
                        frm.txtUsuario.Text = txtUsuario;
                        frm.lblCodigoCliente.Text = txtCodigoCliente;
                        frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();

                        if (pdv_troca)
                        {
                            frm.valorTroca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));
                            frm.lista_troca = this.lista_troca;
                        }

                        frm.Show();
                        //frm.ShowDialog();
                        if (frm.cancelar)
                        {
                            cancelouFpg = false;
                        }
                        else
                        {
                            cancelouFpg = true;
                            objVen.forma_pagamento = frm.formaPagamento;
                            objVen.parcelas = frm.qtdParcelas;
                            txtvrRecebido = frm.valorRecebido;
                            txtvrTroco = frm.valorTroco;
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
                this.Visible = true;
            }
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
                cmd.Parameters.Add(new SqlParameter("@NumeroMesa", SqlDbType.Int)).Value = int.Parse(txtTicket);
                cmd.Parameters.Add(new SqlParameter("@HoraFechamento", SqlDbType.Time)).Value = HoraCompleto;
                cmd.Parameters.Add(new SqlParameter("@Atendente", SqlDbType.Int)).Value = int.Parse(cbFuncionario.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Int)).Value = 0; //Aberto
                objD.ExecutaComando(cmd);

                //Alterar a situação da mesa para 1 Ocupada 
                cmd.CommandText = String.Concat("Update  Mesa",
                   " set Status ='0' ",
                   " Where Numero =@Mesa"
                   );
                cmd.Parameters.Add(new SqlParameter("@Mesa", SqlDbType.Int)).Value = int.Parse(txtTicket);
                objD.ExecutaComando(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }


        public void carregaPropriedadesAlterar()
        {
            // Cria uma instância com as configurações da cultura brasileira (formatos)
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
            //objVen.valorFinal = decimal.Parse(txtTotalFinal.Text, NumberStyles.Currency, culturaBrasileira);
            try
            {
                if (txtCodigo != "")
                    objVen.codigo = int.Parse(txtCodigo);
                else
                    objVen.codigo = 0;
                objVen.localizar(objVen.codigo.ToString(), "ven_codigo");
                //setando valores originais da venda e não da consulta 
                objVen.cliente = int.Parse(txtCodigoCliente);
                objVen.valor = decimal.Parse(txtValorTotal, NumberStyles.Currency, culturaBrasileira);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text, NumberStyles.Currency, culturaBrasileira);
                //
                if (cbRenovarVenda == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda == false)
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

        public void ImprimirNaImpressoraBematech()
        {
          // try
          // {
          //     if (ckModoImpressao == true)
          //     {
          //         //   MessageBox.Show("Entrei..........");
          //         int imagem = 0;
          //         int imprimirTexto = 0;
          //         //iniciando a Impressao
          //         int codVendaObj = 0;
          //         int codvendatextBox = 0;
          //
          //         DataTable tabCupom = objVen.FormarCupom(objVen.codigo);
          //         if (tabCupom.Rows.Count > 0)
          //         {
          //             //  MessageBox.Show("eu tenho unformações");
          //             int x = Convert.ToInt32(12);
          //             int y = Convert.ToInt32(12);
          //             int angulo = Convert.ToInt32(0);
          //             String CabecalhoCup = "";
          //             imagem = MP2032.ImprimeBmpEspecial("C:\\One\\LogoCliente.bmp", x, y, angulo);
          //             String textoImpressora;
          //             textoImpressora = "               " + Environment.NewLine;
          //             txtCabecalhoCupom.SelectionAlignment = HorizontalAlignment.Center;
          //             textoImpressora += "          " + txtCabecalhoCupom.Text.ToString();// += CabecalhoCup.ToString();
          //             textoImpressora += "-----------------------------------------------" + Environment.NewLine;
          //             textoImpressora += "              CUPOM DE VENDA " + Environment.NewLine;
          //             textoImpressora += "-----------------------------------------------" + Environment.NewLine;
          //             textoImpressora += "DATA:" + tabCupom.Rows[0]["Data da Venda"].ToString() + "  CUPOM:" + objVen.codigo.ToString() + Environment.NewLine;
          //             textoImpressora += "-----------------------------------------------" + Environment.NewLine;
          //             textoImpressora += "ITEM  " + "DESCRIÇÃO " + "QTD  " + "TARA " + "PREÇO " + "SUBTOTAL " + Environment.NewLine;
          //             textoImpressora += "-----------------------------------------------" + Environment.NewLine;
          //             for (int i = 0; i < tabCupom.Rows.Count; i++)
          //             {
          //                 textoImpressora += i + " " + tabCupom.Rows[i]["CodigoBarras"].ToString() + "  " + tabCupom.Rows[i]["Produto"].ToString() + "  " + tabCupom.Rows[i]["Unidade"].ToString() + Environment.NewLine; //+ tabCupom.Rows[i]["Quantidade"].ToString() + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + "  " + "  " +  tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
          //                 if (tabCupom.Rows[i]["Unidade"].ToString() == "KG")
          //                 {
          //                     textoImpressora += "Peso Bruto " + tabCupom.Rows[i]["Peso Bruto"].ToString() + " - " + tabCupom.Rows[i]["Tara"] + " = " + tabCupom.Rows[i]["Quantidade"] + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + " = " + tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
          //                 }
          //                 else
          //                 {
          //                     textoImpressora += "QTD " + tabCupom.Rows[i]["Quantidade"].ToString() + " X " + tabCupom.Rows[i]["Preço Produto"].ToString() + " = " + tabCupom.Rows[i]["Valor Total"].ToString() + Environment.NewLine;
          //                 }
          //             }
          //             textoImpressora += "----------------------------------------------" + Environment.NewLine;
          //
          //             textoImpressora += "Total       R$ = " + tabCupom.Rows[0]["Total"].ToString() + Environment.NewLine;
          //             textoImpressora += "Desconto    R$ = " + tabCupom.Rows[0]["Desconto"].ToString() + Environment.NewLine;
          //             textoImpressora += "Recebido    R$ = " + tabCupom.Rows[0]["ValorRecebido"].ToString() + Environment.NewLine;
          //             textoImpressora += "Troco       R$ = " + tabCupom.Rows[0]["ValorTroco"].ToString() + Environment.NewLine;
          //
          //             textoImpressora += "------------OBRIGADO PELA PREFERENCIA------------" + Environment.NewLine;
          //             textoImpressora += "SISTEMA SIAV PDV :3.10  FONE:" + DateTime.Now.Year.ToString() + "11 9 6194 6874" + Environment.NewLine;
          //             //textoImpressora += lblMsgCupom.Text + Environment.NewLine;
          //             textoImpressora += "                                           " + Environment.NewLine;
          //             //Imprime a impressão Bamatech TH2500
          //             imprimirTexto = MP2032.FormataTX(textoImpressora + "\r\n\r\n", 2, 0, 0, 0, 1);
          //             imprimirTexto = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
          //             if (MessageBox.Show("Deseja emitir a segunda via?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
          //             {
          //                 ImprimirNaImpressoraBematech();
          //             }
          //             limpar();
          //         }
          //     }
          // }
          // catch (Exception ex)
          // {
          //     MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
          // }

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
        public void carregaPropriedadesCondicional()
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtValorTotal.Length - 1; i++)
                {
                    if ((txtValorTotal[i] >= '0' &&
                    txtValorTotal[i] <= '9') ||
                    txtValorTotal[i] == ',')
                    {
                        x += txtValorTotal[i];
                    }
                }
                txtValorTotal = x;

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
                for (int i = 0; i <= txtDescontoValor.Length - 1; i++)
                {
                    if ((txtDescontoValor[i] >= '0' &&
                    txtDescontoValor[i] <= '9') ||
                    txtDescontoValor[i] == ',')
                    {
                        x += txtDescontoValor[i];
                    }
                }
                txtDescontoValor = x;
                //Vendas
                if (txtCodigo != "")
                    objVen.codigo = int.Parse(txtCodigo);
                else
                    objVen.codigo = 0;
                txtData = txtData.Trim();
                if (txtData != "")
                    objVen.data = DateTime.Parse(txtData);
                else
                    throw new Exception("O campo data é de preenchimento obrigatório");
                txtObservacao = txtObservacao.Trim();
                if (txtObservacao != "")
                    objVen.observacao = txtObservacao;
                else
                    objVen.observacao = null;
                if (cbFuncionario.SelectedValue == null)
                    throw new Exception("Por favor, informe qual funcionário está efetuando a venda");
                else
                    objVen.usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
                if (txtCodigoCliente != "")
                    objVen.cliente = int.Parse(txtCodigoCliente);

                if (txtDescontoPercentual == "")
                    objVen.percentual = 0;
                else
                    objVen.percentual = decimal.Parse(txtDescontoPercentual);

                if (txtDescontoValor == "")
                    objVen.desconto = 0;
                else
                    objVen.desconto = decimal.Parse(txtDescontoValor);

                objVen.valor = decimal.Parse(txtValorTotal);
                objVen.valorFinal = decimal.Parse(txtTotalFinal.Text);

                objVen.ven_ticket = int.Parse(txtTicket);


                objVen.forma_pagamento = 0;
                objVen.parcelas = 0;
                objVen.cliente = int.Parse(txtCodigoCliente);

                if (cbRenovarVenda == true)
                    objVen.ven_status = "Ativo";
                else if (cbRenovarVenda == false)
                    objVen.ven_status = "Cancelado";

                objVen.ven_tipo = cbTipoVenda.SelectedItem.ToString();
                objVen.IDAber = int.Parse(lblCodigoAbertura.Text.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean prosseguir = true;
            if (dgDados.Rows.Count > 0 || !string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                if (pdv_troca)
                {

                    decimal valor_compra = decimal.Parse(txtTotalFinal.Text.Replace(',', '.'));
                    decimal valor_troca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));

                    if (valor_troca > valor_compra)
                    {
                        MessageBox.Show("Valor de total da compra deve ser maior ou igual ao valor da troca !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        prosseguir = false;
                    }

                }

                if (prosseguir)
                {
                    lblInfo.Visible = true;
                    txtPesoBruto = "";
                    //txtTicket.Visible = false;
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
                    txtCodigoCliente = "0";
                    //txtCodigo.Visible = false;
                    CountItem = 0;
                    lblMsgMesa = ". . . PDV Online";
                    lblCpf.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Informe um produto para finalizar a venda", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PDVDesconto_Item frm = new PDVDesconto_Item();
            frm.ShowDialog();


            //foreach (DataGridViewRow row in datagridviews.Rows)
            //{
            //    currQty += row.Cells["qty"].Value;
            //    //More code here
            //}


            foreach (DataGridViewRow row in dgDados.Rows)
            {
                Int32 n_item = Int32.Parse(row.Cells[0].Value.ToString().Replace(',', '.'));
                if (n_item == Int32.Parse(frm.textBox1.Text))
                {
                    string x = row.Cells[3].Value.ToString().Replace(',', '.');
                    decimal qtd = decimal.Parse(x);

                    decimal valor = decimal.Parse(row.Cells[4].Value.ToString());
                    decimal desconto = decimal.Parse(frm.txtDescontoPer.Text.ToString());
                    decimal nvalor = valor - (valor * (desconto / 100));

                    dgDados.Rows[row.Index].Cells[4].Value = nvalor.ToString();
                    dgDados.Rows[row.Index].Cells[5].Value = string.Format("{0:n2}", (nvalor * qtd));

                    //carregaCampos();
                    decimal total = decimal.Parse(txtTotalFinal.Text.Replace(',', '.'));
                    total = total / 100;

                    //double total .Parse();
                    total = total - (valor * qtd);
                    total = total + (nvalor * qtd);
                    txtTotalFinal.Text = total.ToString("n2");
                }

                //  int qtd = int.Parse(dgvRow.Cells[4].Value.ToString());
                //  decimal valor = decimal.Parse(dgvRow.Cells[4].Value.ToString());
                //
                //  valor = valor * int.Parse(frm.txtDescontoPer.ToString());
                //
                //  dgDados.Rows[0].Cells[4].Value = valor;
                //
                //
                //  String x = "";
            }




            vendaItensDAL venda_item = new vendaItensDAL();

            //venda

        }

        private void button5_Click(object sender, EventArgs e)
        {

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
                            txtValorTotal = total.ToString();
                            txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                            txtTotalFinal.Text = total.ToString();
                            txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                            txtCodigoBarra.Select();
                        }
                        else
                        {
                            txtValorTotal = "0";
                            txtValorTotal = Convert.ToDecimal(txtValorTotal).ToString("C");
                            txtTotalFinal.Text = "0";
                            //txtTotalFinal.Text = Convert.ToDecimal(txtTotalFinal.Text).ToString("C");
                            txtTotalFinal.Text = Math.Round(Convert.ToDecimal(txtTotalFinal.Text),2) + "";
                            txtCodigoBarra.Select();
                        }


                        int qtdade = 0;
                        for (int j = 0; j < dgDados.Rows.Count; j++)
                            qtdade += int.Parse(dgDados.Rows[j].Cells[3].Value.ToString());

                        txtTotalItens = qtdade.ToString();

                        txtDescontoPercentual = "";
                        txtDescontoValor = "";
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
        }

        private void txtQuantidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigoBarra.Focus();
            }

            verifica_f(e);
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmInputCpf cpf = new FrmInputCpf(this);
            cpf.ShowDialog();
            if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 11)
            {
                cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"000\.000\.000\-00");
                // lblCpf.Visible = true;
            }
            if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 14) //99.999.999/9999-99
            {
                cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"00\.000\.000\/0000\-00");
                //    lblCpf.Visible = true;
            }
            if (!string.IsNullOrEmpty(cpf.CpfCliente))
                txtCodigoBarra.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmInputCpf cpf = new FrmInputCpf(this);
            cpf.ShowDialog();
            if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 11)
            {
                cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"000\.000\.000\-00");
                // lblCpf.Visible = true;
            }

            if (cpf.CpfCliente != null && cpf.CpfCliente.Length == 14) //99.999.999/9999-99
            {
                cpf_cliente.Text = Convert.ToInt64(cpf.CpfCliente).ToString(@"00\.000\.000\/0000\-00");
                // lblCpf.Visible = true;
            }

            if (!string.IsNullOrEmpty(cpf.CpfCliente))
                txtCodigoBarra.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSegundaViaCupom frmSeg = new frmSegundaViaCupom();
            frmSeg.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            FechamentoCaixaBLL objFC = new FechamentoCaixaBLL();

            if (objFC.JaFechou(int.Parse(cbFuncionario.SelectedValue.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
            {
                throw new Exception("Fechamento diário já foi realizado");

            }
            else
            {
                frm_FechamentoCaixa frm1 = new frm_FechamentoCaixa(this);
                frm1.lblNumerCaixa.Text = lblNumerCaixa;
                frm1.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                frm1.txtCodUsuario.Text = cbFuncionario.SelectedValue.ToString();
                frm1.txtUsuario.Text = txtUsuario.ToString();
                frm1.ShowDialog();
                lblInfo.Visible = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            devolucao_troca frm_devolucao = new devolucao_troca();
            frm_devolucao.ShowDialog();

            String cupom = frm_devolucao.codigo_cupom;

            try
            {

                if (cupom.Length > 0)
                {

                    Int32 x = Int32.Parse(cupom);

                    if (x > 0)
                    {

                        Boolean ok = true;

                        verificacaoUsuario frmVerifi = new verificacaoUsuario();
                        frmVerifi.ShowDialog();
                        if (frmVerifi.permissao == "Cancelar")
                        {
                            ok = false;
                        }
                        if (frmVerifi.permissao != "Gerente")
                        {
                            MessageBox.Show("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                            ok = false;
                            throw new Exception();
                        }

                        if (ok)
                        {


                            VendasBLL vendas = new VendasBLL();
                            vendas.localizar(cupom.Trim(), "nserieSAT");
                            Boolean xx = vendas.retorna_itens_venda_ao_estoque(vendas.codigo);

                            if (xx)
                            {
                                vendas.ven_status = "Devolvido";
                                vendas.cancelarVenda();
                            }



                            if (xx)
                                MessageBox.Show("Venda devolvida com sucesso !");
                            else
                                MessageBox.Show("Erro ao devolver venda !");
                        }

                    }

                }
                else
                {

                }
            }
            catch
            {

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {

            devolucao_troca frm_devolucao = new devolucao_troca();
            frm_devolucao.ShowDialog();

            String cupom = frm_devolucao.codigo_cupom;

            try
            {

                if (cupom.Length > 0)
                {

                    Int32 x = Int32.Parse(cupom);

                    if (x > 0)
                    {

                        Boolean ok = true;

                        verificacaoUsuario frmVerifi = new verificacaoUsuario();
                        frmVerifi.ShowDialog();
                        if (frmVerifi.permissao == "Cancelar")
                        {
                            ok = false;
                        }
                        if (frmVerifi.permissao != "Gerente")
                        {
                            MessageBox.Show("Você não tem permissão para realizar essa rotina procure o administrador do sistema!");
                            ok = false;
                            throw new Exception();
                        }

                        if (ok)
                        {

                            VendasBLL vendas = new VendasBLL();
                            vendas.localizar(cupom.Trim(), "ven_codigo");

                            pdv_troca = true;
                            n_cupom = cupom.Trim();
                            lbl_valor_troca.Text = vendas.valorFinal.ToString();
                            lblInfo.Text = "T R O C A   D E   M E R C A D O R I A";
                            gb_troca.Visible = true;

                            frm_troca_itens frm_troca = new frm_troca_itens(vendas);
                            frm_troca.ShowDialog();

                            lbl_valor_troca.Text = frm_troca.total_troca.Text;

                            this.lista_troca = frm_troca.lista_troca;


                            //      Boolean xx = vendas.retorna_itens_venda_ao_estoque(vendas.codigo);
                            //
                            //      if (xx)
                            //      {
                            //          vendas.ven_status = "Devolvido";
                            //          vendas.cancelarVenda();
                            //      }
                            //
                            //
                            //
                            //      if (xx)
                            //          MessageBox.Show("Venda devolvida com sucesso !");
                            //      else
                            //          MessageBox.Show("Erro ao devolver venda !");
                        }
                        //
                    }

                }
                else
                {

                }
            }
            catch
            {

            }

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmPesquisaProdutoNovo novaForm = new frmPesquisaProdutoNovo(this);
            try
            {
                novaForm.ShowDialog();
                txtCodigoBarra.Text = novaForm.Codigo;
                txtCodigoBarra.Focus();
            }
            catch (Exception ee)
            {
                txtCodigoBarra.Text = novaForm.Codigo;
                txtCodigoBarra.Focus();
            }
        }

        private void ckdVendaPendente_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void ckdVenda_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void lblCodigoAbertura_Click(object sender, EventArgs e)
        {

        }

        private void cbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmPDV_Load(object sender, EventArgs e)
        {

        }

        private void btn_fechar_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            frmSangriaCaixa frm = new frmSangriaCaixa();
            frm.txtUsuario.Text = txtUsuario.ToString();
            frm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
            frm.ShowDialog();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            frm_visualizar_promissoria cmd = new frm_visualizar_promissoria();
            cmd.ShowDialog();
        }

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            AbrirMesa();
        }

        private void AbrirMesa(){

            frmPDV_Mesa frm = new frmPDV_Mesa();
            frm.ShowDialog();

            if (frm.fecha_mesa)
            {
                limpar();
                txtCodigo = "";
                cbTipoVenda.SelectedItem = "Venda";
                txtDescontoValor = "0";
                cbFuncionario.SelectedValue = global.codUsuario;

                decimal total = 0;
                int quantidade = 0;

                MesaBLL cmd = new MesaBLL();
                cmd.id = frm.numero_mesa;
                DataTable dt_produtos = cmd.seleciona_produtos_mesa();

                button2_Click(new object(), new EventArgs());
                
                for (int i = 0; i < dt_produtos.Rows.Count; i++)
                {
                    total += decimal.Parse(dt_produtos.Rows[i].ItemArray[4].ToString());
                    quantidade += int.Parse(dt_produtos.Rows[i].ItemArray[2].ToString());
                }

                txtValorTotal = total.ToString();


                salvarVendapdv();

                //frmPDV_Finalizadora xfrm = new frmPDV_Finalizadora(this);
                //xfrm.txtTotalGeralVendaBruto.Text = txtTotalFinal.Text;
                //xfrm.txtTotalRestante.Text = txtTotalFinal.Text;
                //xfrm.txtVendaID.Text = objVen.codigo.ToString();
                //xfrm.txtUsuario.Text = txtUsuario;
                //xfrm.lblCodigoAbertura.Text = lblCodigoAbertura.Text.ToString();
                //xfrm.lblCodigoCliente.Text = txtCodigoCliente;
                //xfrm.cpf = this.cpf_cliente.Text;
                //
                //if (pdv_troca)
                //{
                //    xfrm.valorTroca = decimal.Parse(lbl_valor_troca.Text.Replace(',', '.'));
                //    xfrm.lista_troca = this.lista_troca;
                //}
                ////frm.TopLevel = false;
                //xfrm.ShowDialog();
                               
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PesquisaProdutoNovoBalanca cmd = new PesquisaProdutoNovoBalanca();
            cmd.ShowDialog();

            try
            {

                if (cmd.finalizado)
                {

                    this.Inserindo = true;
                    //
                    //decimal qtdTotalItem = txtSubtotal;
                    //decimal qtdItens = decimal.Parse(txtQuantidade.Text);
                    decimal vlrUnitario = cmd.valor_produto;
                    txtSubtotal = cmd.valor;
                    txtCodigoProduto = cmd.produto;
                    txtNomeProduto.Text = cmd.nome_produto;
                    txtValorUnitario.Text = vlrUnitario.ToString();
                    txtQuantidade.Text = cmd.quantidade.ToString();
                    txtQuantidadeTotal = "999999999";

                    #region SALVA PRODUTO
                    if (EnterMesa == 0)
                    {
                        int CodProduto = 0;
                        if (txtCodigoProduto != "")
                        {
                            CodProduto = int.Parse(txtCodigoProduto.ToString());
                        }
                        DataTable tabProduto = null;
                        tabProduto = CarregarProdutosPesoSQL(CodProduto);
                        if (tabProduto.Rows.Count > 0)
                        {
                            //HabilitarCamnpos(false);
                            //[Error]CalcularPesoProduto(); erro nessa função atualmente  (11/03/2017) - luiz
                        }
                        else
                        {
                            epeso = false;
                            //HabilitarCamnpos(true);
                        }
                        if (txtNomeProduto.Text == "")
                        {
                            txtDinamic = "";
                        }
                        else
                        {
                            if (epeso == false)
                                txtDinamic = txtQuantidade.Text + " X";
                        }
                        txtPesoBruto = "";
                        if (txtCodigoProduto != "")
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
                                    txtCodigoBarra.Focus();
                                    throw new Exception("!Atenção!Não foi possivél obter o peso da balança!");
                                }
                            }
                            inserirInte();
                            SystemSounds.Asterisk.Play();
                            lblInfo.Text = "C A I X A   O C U P A D O";
                            txtTara = "";
                            txtNomeProduto.Text = "";
                            txtCodigoBarra.Text = "";
                            txtQuantidade.Text = "1";
                            txtDinamic = "";
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
                else
                {

                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("Erro ao buscar o produto : " + ee.Message);
            }


        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
