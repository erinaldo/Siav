using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using Microsoft.VisualBasic;
using ImprimeCupom;
using System.Net;
using System.Net.Sockets;
using One.MOVIMENTACOES;
using One.RELATORIOS;
using DataAccessLayer.Dal;
using One.CADASTROS;
using One.Relatorios;
using One.Dal;

using One.Cadastros;
using One.FrenteDeLoja;

using System.Data.SqlClient;
using One.Loja;

using System.IO;
using SVC_DAL;
using System.Diagnostics;



namespace One
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();


            //  Atualizacao att = new Atualizacao();
            //  att.ShowDialog();

        }
        public int sair = 0;
        Contexto objD = null;
        //Não permitir redimensionar o Menu
        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case 0x0112: // Esse é o codigo de uma mensagem referente a barra de titulo do formulario
        //            int command = m.WParam.ToInt32() & 0xfff0;
        //            // 0xF010 eh o codigo do comando "Restore" 
        //            // 0xF120 eh o Duplo Clique da Barra
        //            if ((new int[] { 0xF010, 0xF120 }).Contains(command))
        //            {
        //                // Se for executado qq um desses casos ignorar o comando (nao passar para o windows) ao menos q o form esteje minimizado.. ai continua...
        //                if (this.WindowState != FormWindowState.Minimized) return;
        //            }
        //            break;
        //    }

        //    base.WndProc(ref m);
        //}


        private void CATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Categorias frm = new Categorias();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                if (sair == 0) //A variável sair foi utilizada pois quando ocorre o "this.close" ele entra novamente nesta função, ocorrendo assim uma recursividade, logo é necessário uma variável para que se consiga controlar o momento em que a tela deve ser fechada
                {
                    if (MessageBox.Show("Deseja realmente sair?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        sair = 1; // No momento em que o cliente confirmar que quer sair o evento por si só concluirá o fechamento, não sendo necessário informar o this.close
                        this.Close();
                    }
                }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //public static DateTime GetNetworkTime()
        //{
        //    //Servidor nacional para melhor latência
        //    const string ntpServer = "a.ntp.br";

        //    // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
        //    var ntpData = new byte[48];

        //    //Indicador de Leap (ver RFC), Versão e Modo
        //    ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)

        //    var addresses = Dns.GetHostEntry(ntpServer).AddressList;

        //    //123 é a porta padrão do NTP
        //    var ipEndPoint = new IPEndPoint(addresses[0], 123);
        //    //NTP usa UDP
        //    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //    socket.Connect(ipEndPoint);

        //    //Caso NTP esteja bloqueado, ao menos nao trava o app
        //    socket.ReceiveTimeout = 3000;

        //    socket.Send(ntpData);
        //    socket.Receive(ntpData);
        //    socket.Close();

        //    //Offset para chegar no campo "Transmit Timestamp" (que é
        //    //o do momento da saída do servidor, em formato 64-bit timestamp
        //    const byte serverReplyTime = 40;

        //    //Pegando os segundos
        //    ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

        //    //e a fração de segundos
        //    ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

        //    //Passando de big-endian pra little-endian
        //    intPart = SwapEndianness(intPart);
        //    fractPart = SwapEndianness(fractPart);

        //    var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

        //    //Tempo em **UTC**
        //    var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

        //    return networkDateTime.ToLocalTime();
        //}

        // stackoverflow.com/a/3294698/162671
        //static uint SwapEndianness(ulong x)
        //{
        //    return (uint)(((x & 0x000000ff) << 24) +
        //                   ((x & 0x0000ff00) << 8) +
        //                   ((x & 0x00ff0000) >> 8) +
        //                   ((x & 0xff000000) >> 24));
        //}
        public DataTable LocalizarContasAPagar()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select ID =cp.cp_codigo,Fornecedor = CASE WHEN frn.for_tipo_fornecedor = 'Pessoa Jurídica' THEN frn.for_razaoSocial ELSE frn.for_nome END,valor = cp.cp_valor  from ContasAPagar cp join Fornecedores frn on frn.for_codigo = cp.cp_fornecedor Where cp.cp_vencimento = Convert(varchar,getdate(),112) AND cp.cp_status = 'aberto'";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable LocalizarContasAReceber()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat(
                        " Select ID =cr.cr_codigo ",
                        " ,Cliente = CASE WHEN cli.cli_tipo_pessoa = 'Pessoa Jurídica' ",
                        "            THEN cli.cli_razao_social ELSE cli.cli_nome ",
                        "            END ",
                        " ,valor = cr.cr_valorAlterado ",
                        " from ContasAReceber cr ",
                        " left join Vendas ven on ven_codigo = cr.cr_vendas ",
                       "  left join Cliente  cli on cli.cli_codigo = ven_cliente",
                       "  Where cr.cr_dataVencimento = Convert(varchar,getdate(),112) AND cr.cr_status = 'aberto'",
                      "   --and cr.cr_codigo = 4");
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
        public void CarregarAlertas()
        {
            ProdutosDAL objDal = new ProdutosDAL();
            try
            {
                DataTable tab = null;
                DataTable tabcp = null;
                DataTable tabcr = null;
                tabcr = LocalizarContasAReceber();
                tabcp = LocalizarContasAPagar();
                tab = objDal.localizarProdutoEstoque();

                if (tabcr.Rows.Count > 0)
                {

                    dgContasAReceber.Visible = true;
                    dgContasAReceber.DataSource = tabcr;
                    lblContasAReber.Visible = true;
                }
                else
                {
                    dgContasAReceber.Visible = false;
                    lblContasAReber.Visible = false;
                }


                if (tabcp.Rows.Count > 0)
                {
                    dgContasAPgAlerta.Visible = true;
                    dgContasAPgAlerta.DataSource = tabcp;
                    lblcpAlerta.Visible = true;
                }
                else
                {
                    dgContasAPgAlerta.Visible = false;
                    lblcpAlerta.Visible = false;
                }
                if (tab.Rows.Count > 0)
                {
                    txtAlerta.Visible = true;
                    txtAlerta.Text = "Atenção existe produtos com estoque zerado ou estoque mínimo na sua capacidade";
                }
                else
                {
                    txtAlerta.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarLicenca()
        {
            LicencaDAL licenca = new LicencaDAL();
            DataTable licenca_dt = licenca.localizar("", "");
            lblDtValidade.Text = "Valido Até " + licenca_dt.Rows[0]["lic_data"].ToString().Replace("00:00:00", "");
            String[] xdata = licenca_dt.Rows[0]["lic_data"].ToString().Replace("00:00:00", "").Split('/');

            DateTime data_licenca = new DateTime(Int32.Parse(xdata[2]), Int32.Parse(xdata[1]), Int32.Parse(xdata[0]));
            DateTime data_atual = DateTime.Now;

            data_licenca = data_licenca.AddDays(-5);
            int result = DateTime.Compare(data_licenca, data_atual);
            if (result < 0)
            {
                MessageBox.Show("Sua licença esta expirando !");
                lblDtValidade.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            }
            else
                lblDtValidade.ForeColor = System.Drawing.Color.White;

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try{
                Acesso db = new Acesso();
                txtServer.Text = db.readDriverSQL().Substring(0, 18);
                // pictureBox1.Image = Image.FromFile(@"C:\One\image.png"); ================================
                timer1.Enabled = true;
                txtUsu.Text = "Bem Vindo : " + global.nomeUsuario.ToString() + " (" + global.permissao + ")";
                ValidarLicenca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void Menu_LocationChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Location = new Point(0, 0);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                //CarregarAlertas();
                Hora.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (sair == 0) //A variável sair foi utilizada pois quando ocorre o "this.close" ele entra novamente nesta função, ocorrendo assim uma recursividade, logo é necessário uma variável para que se consiga controlar o momento em que a tela deve ser fechada
                {
                    if (MessageBox.Show("Deseja realmente sair?", "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        sair = 1; // No momento em que o cliente confirmar que quer sair o evento por si só concluirá o fechamento, não sendo necessário informar o this.close
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void FORMADEPAGAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Forma_Pagamento frm = new Forma_Pagamento();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void GRUPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Grupo frm = new Grupo();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void uNIDADESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Unidades frm = new Unidades();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void sUBGRUPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Sub_Grupo frm = new Sub_Grupo();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void eSTADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Estado frm = new Estado();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void cIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cidade frm = new Cidade();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void eMPRESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Empresa frm = new Empresa();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void pERMISSÕESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Permissao frm = new Permissao();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void uSUÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario frm = new Usuario();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente frm = new Cliente();
                //frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fORNECEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor frm = new Fornecedor();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void pRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Produto frm = new Produto();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {

        }

        private void btnprodutos_Click(object sender, EventArgs e)
        {

        }

        private void btnvendas_Click(object sender, EventArgs e)
        {

        }

        private void btncompras_Click(object sender, EventArgs e)
        {

        }

        private void btnfinanceiro_Click(object sender, EventArgs e)
        {

        }

        private void mARCASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Marcas frm = new Marcas();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void rEALIZARCOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.Compras frm = new MOVIMENTACOES.Compras();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cONFIRMARCOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.EntradaMercadoria frm = new MOVIMENTACOES.EntradaMercadoria();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cONTASAPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.ContasAPagar frm = new MOVIMENTACOES.ContasAPagar();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void fORMAPAGAMENTOTESTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.frmContasAReceber frm = new MOVIMENTACOES.frmContasAReceber();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void rEALIZARVENDAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tROCADEPRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cONTASÁPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.ContasAPagar frm = new MOVIMENTACOES.ContasAPagar();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cONTASARECEBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmContasAReceber frm = new frmContasAReceber();
                //frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cLIENTESQUEMAISCOMPRARAMToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void gERARETIQUETASDECÓDIGODEBARRAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gERARETIQUETASDECÓDIGODEBARRAPIMACO6287ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eNTRADADEMERCADORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cLIENTESATENDIDOSPORPERÍODOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pRODUTOSVENDIDOSPORPERÍODOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void fÍSICOFINANCEIROCOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fÍSICOFINANCEIROVENDASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pOSIÇÃODEESTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cONTASAPAGAREMABERTOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cONTASAPAGARPAGASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vENDASCANCELADASToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vENDASPORBALCONISTAToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void cONTASARECEBERToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fECHAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cLIENTESToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void aBERTURAToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fECHAMENTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fORMADEPAGAMENTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fORNECEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void gRUPOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mARCASToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sUBGRUPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uNIDADESToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pRODUTOSPORMARCAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cAIXAPORLUCRATIVIDADEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cOMPRAPORPERÍODOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pARCELASEMATRASOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Escolher_Impressora prn = new Escolher_Impressora();
            prn.Show();
        }

        private void janelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);

        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void fecharTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form mdiChildForm in MdiChildren)
            {
                mdiChildForm.Close();
            }
        }

        private void LOCALIZAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lHora_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cliente frm = new Cliente();
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                //frm.MdiParent = this;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Movimentacoes.Gestao_Vendas cmd = new Movimentacoes.Gestao_Vendas();
            cmd.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Produto frm = new Produto();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.Compras frm = new MOVIMENTACOES.Compras();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                Cadastros.Despesas frm = new Cadastros.Despesas();
                frm.ShowDialog();

                //   MOVIMENTACOES.ContasAPagar frm = new MOVIMENTACOES.ContasAPagar();
                //   //frm.MdiParent = this;
                //   frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                //   frm.ShowDialog();
                //   frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e){

            try{
                MOVIMENTACOES.frmContasAReceber frm = new MOVIMENTACOES.frmContasAReceber();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }catch (Exception ex){
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor frm = new Fornecedor();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void mONITORDECONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Monitor_Consultas mc = new Monitor_Consultas();
                mc.MdiParent = this;
                mc.Show();
                mc = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void vendasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            //
            {
                // MOVIMENTACOES.
                //  MOVIMENTACOES.VendasDocumento frm = new MOVIMENTACOES.VendasDocumento();
                //frm.MdiParent = this;
                //   frm.ShowDialog();
                //   frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void trocaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerarEtiquetaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendedor frm = new frmVendedor();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((e.X >= panel1.Location.X & e.X <= (panel1.Location.X + panel1.Size.Width)) & (e.Y >= panel1.Location.Y & e.Y <= (panel1.Size.Height + panel1.Location.Y)))
            //{
            //    panel1.Visible = true;

            //}
            //else
            //{
            //    panel1.Visible = false;
            //}
        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {


        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_2(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click_3(object sender, EventArgs e)
        {
            try
            {
                Empresa frm = new Empresa();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Menu_MouseMove_1(object sender, MouseEventArgs e)
        {
            //    if ((e.X >= toolStrip1.Location.X & e.X <= (toolStrip1.Location.X + toolStrip1.Size.Width)) & (e.Y >= toolStrip1.Location.Y & e.Y <= (toolStrip1.Size.Height + toolStrip1.Location.Y)))
            //    {
            //        toolStrip1.Visible = true;

            //    }
            //    else
            //    {
            //        toolStrip1.Visible = false;
            //    }

        }

        private void toolStripButton1_Click_3(object sender, EventArgs e)
        {

        }

        private void totalizadoresDeVendasPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Vendas frm = new frm_Vendas();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cADASTROSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resumoVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Vendas vendas = new frm_Vendas();
            vendas.ShowDialog();
            vendas = null;
        }

        private void resumoComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Compras vendas = new frm_Compras();
            // vendas.MdiParent = this;
            vendas.ShowDialog();
            vendas = null;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frm = new frmSobre();
            frm.ShowDialog();
        }

        private void toolStripButton2_Click_2(object sender, EventArgs e)
        {
            try
            {
                Usuario frm = new Usuario();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void centroDeCustosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CentroDeCusto frm = new CentroDeCusto();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void historicoEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmHistoricoEstoque frm = new frmHistoricoEstoque();
                //frm.MdiParent = this;
                frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            frmPesquisarProduto frm = new frmPesquisarProduto();
            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            frm.ShowDialog();
            frm = null;
            //try
            //{
            //    frmPesquisarProduto frm = new frmPesquisarProduto();
            //    //frm.MdiParent = this;
            //    frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //    frm.ShowDialog();
            //    frm = null;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void toolStripButton4_Click_2(object sender, EventArgs e)
        {
            try
            {
                MOVIMENTACOES.EntradaMercadoria frm = new MOVIMENTACOES.EntradaMercadoria();
                //frm.MdiParent = this;
                frm.ShowDialog();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void licençaToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rELATÓRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cOMPRASToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void financeiroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Suporte frm = new Suporte();
            //frm.ShowDialog();
            //frm = null;
        }

        private void panelVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPDVManager frm = new frmPDVManager();
            frm.ShowDialog();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Configuracao_SAT c = new Configuracao_SAT();
            c.ShowDialog();
            
            //Cadastros.Configuracao c = new Configuracao();
            //Configuracoes c = new Configuracoes();
            //c.StartPosition = FormStartPosition.CenterScreen;
            //c.ShowDialog();
        
        }

        private void relatórioSATToolStripMenuItem_Click(object sender, EventArgs e){
            frm_venda frm_venda = new frm_venda();
            frm_venda.ShowDialog();
            frm_venda = null;
        }

        private void separarArquivosXMLToolStripMenuItem_Click(object sender, EventArgs e){
            frm_contabilidade_xml f = new frm_contabilidade_xml();
            f.ShowDialog();
        }

        private void btn_att_Click(object sender, EventArgs e)
        {

            String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            String[] xx = x.Split('\\');

            String p = "";

            for (int i = 0; i < (xx.Length - 2); i++)
            {
                p += xx[i] + "\\";
            }
            p += "patch\\";

            System.Diagnostics.Process.Start(p + "SAT_Patcher.exe");
        }

        private void timer_atualizacao_Tick(object sender, EventArgs e)
        {
            timer_atualizacao.Enabled = false;
            background_atualizacao.RunWorkerAsync();            
        }

        Boolean existe = false;

        private void background_atualizacao_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                

                VersaoDAL cmd = new VersaoDAL();
                DataTable x = cmd.localizar();
                string v = "";

                try
                {
                    v = x.Rows[0].ItemArray[1].ToString();
                }
                catch
                {
                    v = "1";
                }
                bd_pg bd = new bd_pg();
                bd.AbrirConexao();
                bd.Comando = new Npgsql.NpgsqlCommand();
                bd.Comando.CommandText = "select * from trendsat_versao where data > (select data from trendsat_versao where id = " + v + ")";

                IDataReader dr = bd.RetornaDados_v2();
                existe = false;
                while (dr.Read())
                {
                    existe = true;
                }

                bd.FechaConexao();

               
            }
            catch
            {

            }

        }

        private void background_atualizacao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            if (existe){
                toolStripButton1.Visible = true;
                timer_atualizacao.Enabled = true;                
            }
            else{
                toolStripButton1.Visible = false;
                timer_atualizacao.Enabled = true;
            }
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            t.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acesso cmd = new Acesso();
            cmd.RealizarBackupSistema();
        }

        private void cupomFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cupom_Fiscal cmd = new Cupom_Fiscal();
            cmd.ShowDialog();
        }

        private void toolStripButton1_Click_4(object sender, EventArgs e){
            
        }



        private void dgContasAReceber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e){
            Movimentacoes.frmCrediario cmd = new Movimentacoes.frmCrediario();
            cmd.ShowDialog();
            //Cadastros.Despesas cmd = new Cadastros.Despesas();
            //cmd.ShowDialog();
        }

        private void toolStripButton1_Click_5(object sender, EventArgs e){

            if (!Directory.Exists("C:/Rede_Sistema"))
                Directory.CreateDirectory("C:/Rede_Sistema");

            String path = Directory.GetCurrentDirectory();
            String[] xpath = path.Split('\\');

            path = "";
            for (int i = 0; i < (xpath.Length - 1); i++){
                path += xpath[i] +"\\";
            }

            path += "database\\";

            string x = DateTime.Now.ToShortDateString().Replace('/','_');
            //Directory.CreateDirectory("C:/Rede_Sistema/backup_" + x);
            Directory.CreateDirectory("C:/Rede_Sistema/backup_att");


            String paath = "";
            x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            String[] xx = x.Split('\\');
            String p = "";
            for (int i = 0; i < (xx.Length - 2); i++)
            {
                p += xx[i] + "\\";
            }
            p += "bats\\";
            paath = p;


            Process proc = new Process();
            proc.StartInfo.FileName = "bdstop.bat";
            proc.StartInfo.WorkingDirectory = paath;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
            int ExitCode = proc.ExitCode;
            proc.Close();

            File.Copy(path + "trend_bd.mdf", "C:/Rede_Sistema/backup_att/trend_bd.mdf", true);
            File.Copy(path + "trend_bd_log.ldf", "C:/Rede_Sistema/backup_att/trend_bd_log.ldf", true);

            //Directory
            ProcessStartInfo processo = new ProcessStartInfo("http://sat.trendsis.com.br/atualizacao_sat.aspx");
            Process.Start(processo);
        }

        private void sQLServerToolStripMenuItem_Click(object sender, EventArgs e){
            Scripts.sqlserver_nova_versao cmd = new Scripts.sqlserver_nova_versao();
            cmd.ShowDialog();
        }

        private void contabilidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void relatórioMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gerarVendasAPartirDeXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.GerarVendasXML cmd = new GerarVendasXML();
            cmd.ShowDialog();
        }

        private void detalhamentDeVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorios.frm_relatorio_detalhado_vendas cmd = new frm_relatorio_detalhado_vendas();
            cmd.ShowDialog();
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

