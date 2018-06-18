using DataAccessLayer.Dal;

using LFi.Control.Laçanmento_Financeiro;
using One.Bll;
using One.CADASTROS;
using One.Dal;
using One.FrenteDeLoja;

using One.MOVIMENTACOES;
using One.Relatorios;
using SVC_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using View;

namespace One.Loja
{
    public partial class frmPDVManager : Form
    {
        public frmPDVManager()
        {
            InitializeComponent();
        }
        //DateCalc datecalc = new DateCalc();
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public int? usuario = null;
        public DateTime? DataLic = null;
        VendasDAL objVen = new VendasDAL();

        Contexto con = new Contexto();
        public void VerificarPermissao(string usuario)
        {
            UsuarioBLL objUsu = new UsuarioBLL();
            objUsu.LocalizarComRetorno("usu_nome", usuario);
            if (objUsu.per_codigo != 0)
            {
                PermissaoBLL objPer = new PermissaoBLL();
                objPer.localizar(objUsu.per_codigo.ToString(), "per_codigo");


                if (objPer.per_nome == "Gerente")

                    //else
                    //  "aaa";
                    objPer = null;
            }
            objUsu = null;
        }
        public bool HabitarVenda;
        private void btnVendas_Click(object sender, EventArgs e)
        {

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
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja fechar o Manager PDV?", "Continuar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                FazerBackupdoSistema();
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnPedidoFinalizado_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
            string filtro = "Ativo";
            string tipo = "Venda";
            DataTable tab1 = null;
            DataTable tab2 = null;
            dataInicial = txtInicial.Value;
            dataFinal = txtFinal.Value;
            if (cbFuncionario.SelectedValue != null)
                usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
            if (ckdUsuarios.Checked)
            {
                usuario = 0;
                //  cbFuncionario.SelectedIndex = -1;
            }
            tab1 = objVen.localizarPedidoData(dataInicial, dataFinal, filtro, tipo, usuario);
            tab2 = objVen.localizarPedidoItens(dataInicial, dataFinal, filtro, tipo, usuario, 0);
            gvPesquisa.DataSource = tab1;
            dgItensVendas.DataSource = tab2;
        }

        private void btnPedidoPedente_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
            string filtro = "Ativo";
            string tipo = "Venda";
            tipo = "Orçamento";
            DataTable tab1 = null;
            DataTable tab2 = null;
            dataInicial = txtInicial.Value;
            dataFinal = txtFinal.Value;
            if (cbFuncionario.SelectedValue != null)
                usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
            if (ckdUsuarios.Checked)
                usuario = 0;
            cbFuncionario.SelectedIndex = -1;
            tab1 = objVen.localizarPedidoData(dataInicial, dataFinal, filtro, tipo, usuario);
            tab2 = objVen.localizarPedidoItens(dataInicial, dataFinal, filtro, tipo, usuario, 0);
            gvPesquisa.DataSource = tab1;
            dgItensVendas.DataSource = tab2;
        }

        private void btnPedidoCancelado_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 0;
            string filtro = "Ativo";
            string tipo = "Venda";
            filtro = "Cancelado";
            DataTable tab1 = null;
            DataTable tab2 = null;
            dataInicial = txtInicial.Value;
            dataFinal = txtFinal.Value;
            if (cbFuncionario.SelectedValue != null)
                usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
            if (ckdUsuarios.Checked)
                usuario = 0;
            cbFuncionario.SelectedIndex = -1;
            tab1 = objVen.localizarPedidoData(dataInicial, dataFinal, filtro, tipo, usuario);
            tab2 = objVen.localizarPedidoItens(dataInicial, dataFinal, filtro, tipo, usuario, 0);
            gvPesquisa.DataSource = tab1;
            dgItensVendas.DataSource = tab2;
        }

        private void btnPanelVendas_Click(object sender, EventArgs e){
            tabControl1.SelectedIndex = 2;
            tabControl1.Enabled = true;

        }

        private void gvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
            {
                int cod = 0;
                string usuario = "";
                usuario = gvPesquisa.Rows[e.RowIndex].Cells[5].Value.ToString();
                cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (cod != 0)
                {
                    //pnlVendas.Controls.Clear();
                    //tabControl1.SelectedIndex = 0;
                    //frmPDVSkin frm = new frmPDVSkin(cod.ToString());
                    //frm.TopLevel = false;
                    //pnlVendas.Controls.Add(frm);
                    //frm.SetaCodigovenda();
                    //frm.txtCodigo.Enabled = true;
                    //frm.Visible = true;
                    //frm.txtUsuario.Text = usuario.ToString();
                }
            }
        }

        private void frmPDVManager_Load(object sender, EventArgs e)
        {
            //string nome = Dns.GetHostName();
            //IPAddress[] ip = Dns.GetHostAddresses(nome);
            //if (nome.ToString != )
            //lblIP.Text = "(" + nome.ToString() + "/  IP: " + ip[4].ToString() + ")";

            //dgDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataTable tabLicença = null;
            tabLicença = ConsultaContarEmpresa();
            if (tabLicença.Rows.Count > 0)
                lblEmpresa.Text = String.Concat("Sistema licenciado para empresa : ", tabLicença.Rows[0]["Empresa"].ToString());
            //ValidarLicenca();

            //998; 729
            // 1062; 757
            //984; 757
          
            //Acesso db = new Acesso();
            //lblServer.Text ="Servidor :" +db.readDriverSQL().Replace("; User=sa; Password=123", "");
            //HabilitarChart(false);
            //string url = "http://onesolucao.com/";
            //webBrowser1.Navigate(url);

        }

        //private void ValidarLicenca()
        //{
        //    string dtmaquina = "";
        //    string dtaplic = "";
        //    string dtvenc = "";

        //    #region Data Maquina
        //    DateTime agora = DateTime.Now;
        //    string stringSerFeitoReplace1 = agora.ToString("dd/MM/yyyy");
        //    var vencimento = stringSerFeitoReplace1.Replace(",", "/");
        //    dtmaquina = vencimento;
        //    #endregion

        //    #region Data do One
        //    string key = "Criptografia";
        //    Criptografia crip = new Criptografia(CryptProvider.DES);
        //    crip.Key = key;
        //    dtaplic = File.ReadAllText(@"c:\one\hpostap.dll", System.Text.Encoding.UTF8);

        //    #endregion

        //    #region Data do Vencimento
        //    dtvenc = File.ReadAllText(@"c:\one\host.dll", System.Text.Encoding.UTF8);
        //  //  lblDtValidade.Text = dtvenc.ToString();
        //    #endregion

        //    #region Verificar Bloqueio
        //    DateTime data = Convert.ToDateTime(dtmaquina);//Data da Maquina 
        //    DateTime outraData = Convert.ToDateTime(crip.Decrypt(dtaplic));//Data do Aplicatico Lic
        //    DateTime datavenc = Convert.ToDateTime(crip.Decrypt(dtvenc)); ;//Data Vencimento 
        //    //lblDtValidade.Text = datavenc.ToString("dd/MM/yyyy");

        //    int DiaAtual = DateTime.Now.Day;
        //    int DiaVencimento = datavenc.Day;
        //    int MesVencimento = datavenc.Month;
        //    int MesAtual = DateTime.Now.Month;

        //    int AnoAtual = DateTime.Now.Year;
        //    int AnoVencimento = datavenc.Year;

        //    int Result = DiaVencimento - DiaAtual;

        //    if (Result <= 5 && MesAtual == MesVencimento && AnoVencimento == AnoAtual)
        //    {
        //        MessageBox.Show("A licença do sistema expira em " + Result + " dias.", "Licença", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }

        //    #endregion
        //}

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

        private DataTable carregaeEncerramentoCaixa(DateTime? datainicial, DateTime? datafinal)
        {
            Contexto objD = null;
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {

                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                  "ResumoCaixaVendasConsulta"
                    );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = cbFuncionario.SelectedValue;
                cmd.Parameters.Add(new SqlParameter("@UsuarioNome", SqlDbType.VarChar)).Value = global.nomeUsuario;
                cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = datainicial;
                cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = datafinal;
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
        private void btnDetalheDia_Click(object sender, EventArgs e)
        {
            DataTable tab1 = null;
            dataInicial = txtInicial.Value;
            dataFinal = txtInicial.Value;
            tab1 = carregaeEncerramentoCaixa(dataInicial, dataFinal);
            gvPesquisa.DataSource = tab1;
            this.gvPesquisa.Columns[2].Visible = false;
        }

        private void frmPDVManager_Shown(object sender, EventArgs e)
        {
            carregacombo();
            cbFuncionario.SelectedValue = global.codUsuario;
            gvPesquisa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvPesquisa.ClearSelection();
            //this.gvPesquisa.Columns[1].Visible = false;
        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    tabControl1.SelectedIndex = 3;
        //    panelConntaCorrente.Visible = true;
        //    CarregarContaCorrente();
        //}

        //private void CarregarContaCorrente()
        //{
        //    try
        //    {
        //        dgDados.DataSource = null;
        //        Lancamento lan = new Lancamento();
        //        DataTable tab = null;
        //        tab = lan.Consultar(dateTimePicker1.Value, dateTimePicker2.Value);
        //        if (tab.Rows.Count > 0)
        //        {
        //            decimal cred = 0;
        //            decimal deb = 0;
        //            decimal sld = 0;
        //            dgDados.DataSource = tab;
        //            dgDados.Columns[1].Visible = false;
        //            dgDados.Columns[2].Visible = false;
        //            dgDados.Columns[3].Width = 600;
        //            dgDados.Columns[4].Visible = false;
        //            dgDados.Columns[6].Visible = false;
        //            dgDados.Columns[7].Visible = false;
        //            dgDados.Columns[8].Visible = false;
        //            if (tab.Rows[0]["Credito"].ToString() != "")
        //                cred = decimal.Parse(tab.Rows[0]["Credito"].ToString());
        //            if (tab.Rows[0]["Debito"].ToString() != "")
        //                deb = decimal.Parse(tab.Rows[0]["Debito"].ToString());
        //            if (tab.Rows[0]["Saldo"].ToString() != "")
        //                sld = decimal.Parse(tab.Rows[0]["Saldo"].ToString());
        //            if (sld > 0)
        //                this.txtSaldo.ForeColor = Color.Green;
        //            else
        //                this.txtSaldo.ForeColor = Color.Red;
        //            txtCredito.Text = cred.ToString("C");
        //            txtDebito.Text = deb.ToString("C");
        //            txtSaldo.Text = sld.ToString("C");
        //            carregarGrafico();
        //            lan = null;
        //        }
        //        else
        //        {
        //            throw new Exception("Não existe lançamentos para Hoje!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void carregarGrafico()
        //{
        //    Lancamento lan = new Lancamento();
        //    DataTable tab = null;
        //    tab = lan.Consultar(dateTimePicker1.Value, dateTimePicker2.Value);

        //    int numeracao = -1;
        //    cCorrete.Series.Clear();
        //    #region Credito
        //    cCorrete.Series.Add("Credito");
        //    cCorrete.Palette = ChartColorPalette.BrightPastel;
        //    cCorrete.Series["Credito"].ChartType = SeriesChartType.Column;
        //    cCorrete.Series["Credito"].IsValueShownAsLabel = true;
        //    cCorrete.Series["Credito"].LabelFormat = "c";
        //    #endregion
        //    #region Debito
        //    cCorrete.Series.Add("Débito");
        //    cCorrete.Palette = ChartColorPalette.BrightPastel;
        //    cCorrete.Series["Débito"].ChartType = SeriesChartType.Column;
        //    cCorrete.Series["Débito"].IsValueShownAsLabel = true;
        //    cCorrete.Series["Débito"].LabelFormat = "c";
        //    #endregion
        //    cCorrete.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        //    cCorrete.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = true;
        //    cCorrete.ChartAreas["ChartArea1"].BackColor = Color.White;
        //    cCorrete.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
        //    cCorrete.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        //    //Organizando x e y do grafico
        //    string detalhe = "";
        //    string valor = "";
        //    string valor_FinalC = "";
        //    string detalheD = "";
        //    string valorD = "";
        //    string valorD_Final = "";
        //    string dia = "";
        //    for (int i = 0; i <= tab.Rows.Count - 1; i++)
        //    {
        //        //Credito

        //        numeracao = numeracao + 1;
        //        dia = tab.Rows[i]["Dia"].ToString();
        //        if (tab.Rows[i]["Sinal"].ToString() == "C")
        //        {
        //            //Credito
        //            detalhe = tab.Rows[i]["Detalhe"].ToString();
        //            valor = tab.Rows[i]["Valor"].ToString();
        //            valor_FinalC = valor.Replace(",", ".");
        //            tab.Rows[i]["Valor"] = valor_FinalC;
        //            this.cCorrete.Series["Credito"].Points.AddXY(dia, valor_FinalC);
        //        }
        //        else
        //        {
        //            //Debito
        //            detalheD = tab.Rows[i]["Detalhe"].ToString();
        //            valorD = tab.Rows[i]["Valor"].ToString();
        //            valorD_Final = valorD.Replace(",", ".");
        //            tab.Rows[i]["Valor"] = valorD_Final;
        //            this.cCorrete.Series["Débito"].Points.AddXY(dia, valorD_Final);
        //        }
        //    }
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            //CarregarContaCorrente();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //CarregarContaCorrente();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // dgDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabControl2.SelectedIndex = 2;
        }

        private DataTable CarregarConsultaVendas(DateTime dtInicial, DateTime dtFinal, string Tipo, string Status)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                if (Tipo == "Díario")
                {
                    cmd.CommandText = string.Concat
                   (
                        "Select ",
                        "Datename(DAY,ven_dataVenda) 'Dia' ",
                        ",Sum(ven_valorFinal)        'Valor' ",
                        "From  Vendas v ",
                        "WHERE Convert(Varchar,v.ven_datavenda,112) >= Convert(Varchar,@dtInicial,112) ",
                        "and convert(Varchar,v.ven_datavenda,112) <= Convert(Varchar,@dtFinal,112) ",
                        " and ven_status ='", Status,
                        "' Group by Datename(day,ven_datavenda) Order By Dia "
                  );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    tab = con.ExecutaConsulta(cmd);
                }
                if (Tipo == "Mensal")
                {
                    cmd.CommandText = string.Concat
                   (
                        "Select ",
                        "month(ven_dataVenda) 'Dia' ",
                        ",Sum(ven_valorFinal)  'Valor' ",
                        "From  Vendas v ",
                        "  where month(ven_dataVenda) = ", dtInicial.Date.Month,
                        " and ven_status ='", Status,
                        "' Group by month(ven_dataVenda) Order By Dia"
                  );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    tab = con.ExecutaConsulta(cmd);
                }
                if (Tipo == "Anual")
                {
                    cmd.CommandText = string.Concat
                    (
                        "Select ",
                        "year(ven_dataVenda) 'Dia' ",
                        ",Sum(ven_valorFinal)  'Valor' ",
                        "From  Vendas v ",
                        "  where year(ven_dataVenda) = ", dtInicial.Date.Year,
                        " and ven_status ='", Status,
                        "' Group by year(ven_dataVenda) Order By Dia"
                   );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    tab = con.ExecutaConsulta(cmd);
                }
                if (Tipo == "AgrupamentoMensal")
                {
                    cmd.CommandText = string.Concat
                    (
                       "select ",
                        "case when MONTH(ven_dataVenda) = 1 then 'JANEIRO' ",
                         "    WHEN MONTH(ven_dataVenda) = 2 then 'FEVEREIRO' ",
                         "    WHEN MONTH(ven_dataVenda) = 3 then 'MARÇO' ",
                         "    WHEN MONTH(ven_dataVenda) = 4 then 'ABRIL' ",
                         "    WHEN MONTH(ven_dataVenda) = 5 then 'MAIO' ",
                         "    WHEN MONTH(ven_dataVenda) = 6 then 'JUNHO' ",
                         "    WHEN MONTH(ven_dataVenda) = 7 then 'JULHO' ",
                         "   WHEN MONTH(ven_dataVenda) = 8 then 'AGOSTO' ",
                         "    WHEN MONTH(ven_dataVenda) = 9 then 'SETEMBRO' ",
                         "    WHEN MONTH(ven_dataVenda) = 10 then 'OUTUBRO' ",
                         "    WHEN MONTH(ven_dataVenda) = 11 then 'NOVEMBRO' ",
                         "    WHEN MONTH(ven_dataVenda) = 12 then 'DEZEMBRO' ",
                         "  else ''end 'Dia' ",
                         " ,convert(decimal(19,2),Sum(ven_valorfinal)) ",
                       " from Vendas ",
                         "  where year(ven_dataVenda) = ", dtInicial.Date.Year,
                       " Group By MONTH(ven_dataVenda) order by Dia"
                   );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    tab = con.ExecutaConsulta(cmd);
                }
                if (Tipo == "ContasAReceber")
                {

                    cmd.CommandText = string.Concat(
                               " Select ",
                                  "  Dia = cli.cli_nome ",
                               " ,	Valor   = sum(cr.cr_valorAlterado) ",
                               " From Vendas v",
                               " Join ContasAReceber cr on cr.cr_vendas= v.ven_codigo ",
                               " Join Cliente cli on cli.cli_codigo = v.ven_cliente ",
                               " Where cr.cr_status = 'Aberto' and v.ven_cliente <>1",
                               " Group by cli.cli_nome",
                               " order by Dia"
                        );
                    tab = con.ExecutaConsulta(cmd);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd = null;
            return tab;
        }

        private DataTable CarregarConsultaProdutos(DateTime dtInicial, DateTime dtFinal, int? usuario, string top)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                if (cboPeriodicidadeProdutos.Text == "Mais Vendidos")
                {
                    cmd.CommandText =
                  String.Concat(
                        "  Select Top ", top,
                        "   Quantidade          =  sum(convert(int,Vi.vi_quantidade)) ",
                        "  ,	Produto				= prod.pro_nome ",

                        "   From vendaItens Vi ",
                        "   Join Produtos prod on prod.pro_codigo = Vi.pro_codigo ",
                        "   join Vendas V on v.ven_codigo = Vi.ven_codigo ",
                        "   WHERE Convert(Varchar,v.ven_datavenda,112) ",
                        "        >= Convert(Varchar,@dtInicial,112) ",
                        "        and convert(Varchar,v.ven_datavenda,112) ",
                        "        <= Convert(Varchar,@dtFinal,112) ",
                        "        and ven_status = 'Ativo' ",
                        "        and ven_Tipo = 'Venda' ",
                         "        Group by prod.pro_nome    Order by Quantidade desc "
                        //"   and (v.ven_usuario = @Usuario or @Usuario = 0) "
              );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                    cmd.Parameters.Add(new SqlParameter("@Top", SqlDbType.Int)).Value = top;
                    tab = con.ExecutaConsulta(cmd);
                }
                if (cboPeriodicidadeProdutos.Text == "Menos Vendidos")
                {
                    cmd.CommandText =
              String.Concat(
                    "  Select Top ", top,
                    "   Quantidade          =  sum(convert(int,Vi.vi_quantidade)) ",
                    "  ,	Produto				= prod.pro_nome ",

                    "   From vendaItens Vi ",
                    "   Join Produtos prod on prod.pro_codigo = Vi.pro_codigo ",
                    "   join Vendas V on v.ven_codigo = Vi.ven_codigo ",
                    "   WHERE Convert(Varchar,v.ven_datavenda,112) ",
                    "        >= Convert(Varchar,@dtInicial,112) ",
                    "        and convert(Varchar,v.ven_datavenda,112) ",
                    "        <= Convert(Varchar,@dtFinal,112) ",
                    "        and ven_status = 'Ativo' ",
                    "        and ven_Tipo = 'Venda' ",
                     "        Group by prod.pro_nome    Order by Quantidade asc "
                        //"   and (v.ven_usuario = @Usuario or @Usuario = 0) "
          );
                    cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                    cmd.Parameters.Add(new SqlParameter("@Top", SqlDbType.Int)).Value = top;
                    tab = con.ExecutaConsulta(cmd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd = null;
            return tab;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbPer.Text == "")
                {
                    throw new Exception("Informe a periodicidade!");
                }
                if (cboSatus.Text == "")
                {
                    throw new Exception("Informe a sistuação da venda!");
                }
                DataTable tab1 = null;
                tab1 = CarregarConsultaVendas(txtDataInicial.Value, txtDataFinal.Value, CbPer.Text.ToString(), cboSatus.Text);
                dataGridView1Vendas.DataSource = tab1;
                //Grafico >> 
                //string graf = Consulta(txtDataInicial.Value, txtDataFinal.Value);
                //SqlDataAdapter adapter = new SqlDataAdapter(graf, con.StrConexao);
                //DataTable tabVendas = new DataTable();
                //adapter.Fill(tabVendas);
                //Grafico 
                int numeracao = -1;
                chart1.Series.Clear();
                chart1.Series.Add("Vendas");
                chart1.Palette = ChartColorPalette.BrightPastel;

                chart1.Series["Vendas"].ChartType = SeriesChartType.Column;
                chart1.Series["Vendas"].IsValueShownAsLabel = true;
                chart1.Series["Vendas"].LabelFormat = "c";

                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = true;
                chart1.ChartAreas["ChartArea1"].BackColor = Color.White;
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                //Organizando x e y do grafico
                string dia = "";
                foreach (DataRow item in tab1.Rows)
                {
                    #region Moedas
                    string valor = item[1].ToString();
                    string valor_Final = valor.Replace(",", ".");
                    item[1] = valor_Final;
                    #endregion

                    numeracao = numeracao + 1;

                    dia = dataGridView1Vendas.Rows[numeracao].Cells[0].Value.ToString();
                    this.chart1.Series["Vendas"].Points.AddXY(dia, valor_Final);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPesquisarprodutos_Click_1(object sender, EventArgs e)
        {
            try
            {
                int usuario = 0;
                if (cbFuncionario.SelectedValue != null)
                    usuario = int.Parse(cbFuncionario.SelectedValue.ToString());
                if (ckdUsuarios.Checked)
                {
                    usuario = 0;
                }
                if (cboPeriodicidadeProdutos.Text == "")
                {
                    throw new Exception("Informe a periodicidade!");
                }
                if (cboTop.Text == "")
                {
                    throw new Exception("Informe o top!");
                }
                DataTable tab1 = null;
                tab1 = CarregarConsultaProdutos(txtDataInicial.Value, txtDataFinal.Value, usuario, cboTop.Text.ToString());
                dataGridView1Produtos.DataSource = tab1;
                int numeracao = -1;
                chartProdutos.Series.Clear();
                chartProdutos.Series.Add("Produtos");
                chartProdutos.Palette = ChartColorPalette.BrightPastel;

                chartProdutos.Series["Produtos"].ChartType = SeriesChartType.Column;
                chartProdutos.Series["Produtos"].IsValueShownAsLabel = true;
                //chartProdutos.Series["Produtos"].LabelFormat = "c";

                chartProdutos.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                chartProdutos.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = true;
                chartProdutos.ChartAreas["ChartArea1"].BackColor = Color.White;
                chartProdutos.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                chartProdutos.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                //Organizando x e y do grafico
                string Quantidade = "";
                foreach (DataRow item in tab1.Rows)
                {
                    #region Moedas
                    string Produto = item[1].ToString();
                    item[1] = Produto;
                    #endregion

                    numeracao = numeracao + 1;

                    Quantidade = (dataGridView1Produtos.Rows[numeracao].Cells[0].Value.ToString());
                    this.chartProdutos.Series["Produtos"].Points.AddXY(Produto, Quantidade);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //public void CarregarTreeView()
        //{
        //    DataTable tab = null;
        //    tab = ConsultaContasAReceberCliente();
        //    TreeNode parentNode = null;
        //    if (tab.Rows.Count > 0)
        //    {

        //        for (int i = 0; i <= tab.Rows.Count - 1; i++)
        //        {
        //            parentNode = treeView1.Nodes.Add(tab.Rows[i]["Nome"].ToString());
        //            PopulateTreeView(int.Parse(tab.Rows[i]["ID"].ToString()), parentNode);
        //        }
        //        treeView1.ExpandAll();
        //        treeView1.Update();
        //    }
        //}

        private DataTable ConsultaContasAReceberCliente()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                        " Select ID = cr.cr_vendas , Nome = cli.cli_nome, Valor =SUM(cr.cr_valorPago)  From ContasAReceber cr ",
                        " Join Vendas Ven on Ven.Ven_codigo = cr.cr_vendas ",
                        " Join Cliente Cli on Cli.Cli_Codigo = Ven.Ven_Cliente Group by  cr.cr_vendas, cli.cli_nome"// Where cr.cr_vendas = @ID "
                    );
                //  cmd.Parameters.Add(new SqlParameter("@ID ", SqlDbType.Int)).Value = ID;
                tab = con.ExecutaConsulta(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        //private void PopulateTreeView(int parentId, TreeNode parentNode)
        //{
        //    DataTable tab = null;
        //    tab = ConsultarVendasClientes(parentId);
        //    if (tab.Rows.Count > 0)
        //    {
        //        TreeNode childNode;
        //        for (int i = 0; i <= tab.Rows.Count - 1; i++)
        //        {
        //            if (parentNode == null)
        //                childNode = treeView1.Nodes.Add(tab.Rows[i]["Nome"].ToString());
        //            else
        //                childNode = parentNode.Nodes.Add(tab.Rows[i]["Nome"].ToString());
        //            //PopulateTreeView(Convert.ToInt32(dr["MNUSUBMENU"].ToString()), childNode);
        //        }
        //    }
        //}

        private DataTable ConsultarVendasClientes(int parentId)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                       "Select ID = cr_Vendas , Nome = cr_dataVencimento From ContasAReceber Where cr_vendas = @ID"
                    );
                cmd.Parameters.Add(new SqlParameter("@ID ", SqlDbType.Int)).Value = parentId;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            //treeView1.Nodes.Clear();
            //CarregarTreeView();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(gvPesquisa);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(dgItensVendas);
        }

        private void empresaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Empresa frm = new Empresa();
            frm.ShowDialog();
            frm = null;
        }

        private void pDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   frmPDVSkin frm = new frmPDVSkin("0");
         //   frm.TopLevel = false;
         ////   pnlVendas.Controls.Clear();
         //   // VerificarPermissao(txtUsuario.Text);
         //  // pnlVendas.Controls.Add(frm);
         //   frm.txtUsuario.Text = txtUsuario.Text;
         //   // frm.txtUsuario.Visible = true;
         //   frm.Visible = true;
         //   HabitarVenda = true;
         //   tabControl1.SelectedIndex = 0;
         //   tabControl1.Enabled = true;
        }

        private void contateAOneDesenvolvimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suporte frm = new Suporte();
            frm.ShowDialog();
            frm = null;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente frm = new Cliente();
            frm.ShowDialog();
            frm = null;
        }

        private void forncedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fornecedor frm = new Fornecedor();
            frm.ShowDialog();
            frm = null;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario frm = new Usuario();
            frm.ShowDialog();
            frm = null;
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forma_Pagamento frm = new Forma_Pagamento();
            frm.ShowDialog();
            frm = null;
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras frm = new Compras();
            frm.ShowDialog();
            frm = null;
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContasAReceberPanel frm = new frmContasAReceberPanel();
            
            frm.ShowDialog();
            frm = null;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //frmPDVSkin frm = new frmPDVSkin("0");
            //frm.TopLevel = false;
            //pnlVendas.Controls.Clear();
            //// VerificarPermissao(txtUsuario.Text);
            //pnlVendas.Controls.Add(frm);
            //frm.txtUsuario.Text = txtUsuario.Text;
            //// frm.txtUsuario.Visible = true;
            //frm.Visible = true;
            //HabitarVenda = true;
            //tabControl1.SelectedIndex = 0;
            //tabControl1.Enabled = true;
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            //frmPDVSkin frm = new frmPDVSkin("0");
            //frm.TopLevel = false;
            //pnlVendas.Controls.Clear();
            //// VerificarPermissao(txtUsuario.Text);
            //pnlVendas.Controls.Add(frm);
            //frm.txtUsuario.Text = txtUsuario.Text;
            //// frm.txtUsuario.Visible = true;
            //frm.Visible = true;
            //HabitarVenda = true;
            //tabControl1.SelectedIndex = 0;
            //tabControl1.Enabled = true;

            //frm = null;
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produto frm = new Produto();
            frm.ShowDialog();
            frm = null;
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
                        " Select Empresa = emp_nomefantasia From Empresa"
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

        private void licenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTime.Text = DateTime.Now.ToString();
        }

        private void frmPDVManager_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmPDVManager_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.V:
                    //frmPDVSkin frm = new frmPDVSkin("0");
                    //frm.TopLevel = false;
                    //pnlVendas.Controls.Clear();
                    //// VerificarPermissao(txtUsuario.Text);
                    //pnlVendas.Controls.Add(frm);
                    //frm.txtUsuario.Text = txtUsuario.Text;
                    //// frm.txtUsuario.Visible = true;
                    //frm.Visible = true;
                    //HabitarVenda = true;
                    //tabControl1.SelectedIndex = 0;
                    //tabControl1.Enabled = true;
                    //frm = null;
                  
                    break;

            }
        }

        private void lblPDVDinamic_Click(object sender, EventArgs e)
        {
            //lblPDVDinamic.Visible = false;
        }
        
        public void HabilitarChart(bool Ver)
        {
           
            
        }
        
        private void GetFirstLastDayofWeek(int ano, int mes, int dia)
        {

            DateTime data = new DateTime(ano, mes, dia);

            //Variáveis de controle dos dias.
            int numeroMenor = 1, numeroMaior = 7;

            var dataInicioSemana = data.AddDays(numeroMenor - data.DayOfWeek.GetHashCode());

            var dataFimSemana = data.AddDays(numeroMaior - data.DayOfWeek.GetHashCode());

        }
        
        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmPDVSkin frm = new frmPDVSkin("0");
            //frm.TopLevel = false;
            //pnlVendas.Controls.Clear();
            //// VerificarPermissao(txtUsuario.Text);
            //pnlVendas.Controls.Add(frm);
            //frm.txtUsuario.Text = txtUsuario.Text;
            //// frm.txtUsuario.Visible = true;
            //frm.Visible = true;
            //HabitarVenda = true;
            //tabControl1.SelectedIndex = 0;
            //tabControl1.Enabled = true;
            //frm = null;
                  
        }

        private void nivelDeAcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permissao frm = new Permissao();
            frm.ShowDialog();
            frm = null;
        }

    }
}