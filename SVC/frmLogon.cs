using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SVC_BLL;
using SVC_DAL;
using View;
using One.MOVIMENTACOES;
using One.Bll;
using One.Loja;
using System.Data.SqlClient;
using One.Dal;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DataAccessLayer.Dal;
using One;
using CDSSoftware;
using System.Net.NetworkInformation;
using System.IO;
using System.Web;
using System.Xml;

namespace One.MENUS
{
    public partial class frmLogon : Form
    {
        public frmLogon()
        {

            InitializeComponent();

            //if (false){
            //    
            //    try{
            //
            //        Contexto contexto = new Contexto();
            //
            //        try
            //        {
            //            contexto.AbreConexao();
            //            contexto.FechaConexao();
            //
            //            VersaoDAL cmd = new VersaoDAL();
            //            DataTable x = cmd.localizar();
            //
            //            try
            //            {
            //                lbl_versao.Text = "V " + x.Rows[0].ItemArray[2].ToString();
            //            }
            //            catch
            //            {
            //                lbl_versao.Text = "V 1.0";
            //            }
            //
            //        }
            //        catch
            //        {
            //
            //            try
            //            {
            //                String path = "";
            //                String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            //                String[] xx = x.Split('\\');
            //                String p = "";
            //                for (int i = 0; i < (xx.Length - 2); i++)
            //                {
            //                    p += xx[i] + "\\";
            //                }
            //                p += "bats\\";
            //                path = p;
            //
            //
            //                Process proc = new Process();
            //                proc.StartInfo.FileName = "bd.bat";
            //                proc.StartInfo.WorkingDirectory = path;
            //                proc.StartInfo.CreateNoWindow = false;
            //                proc.Start();
            //                proc.WaitForExit();
            //                int ExitCode = proc.ExitCode;
            //                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
            //                //info.Arguments = "net start MSSQL$SQLEXPRESS";
            //                //Process.Start(info);
            //                proc.Close();
            //
            //                proc = new Process();
            //                proc.StartInfo.FileName = "localdb_creator.bat";
            //                proc.StartInfo.WorkingDirectory = path;
            //                proc.StartInfo.CreateNoWindow = false;
            //                proc.Start();
            //                proc.WaitForExit();
            //                ExitCode = proc.ExitCode;
            //                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
            //                //info.Arguments = "net start MSSQL$SQLEXPRESS";
            //                //Process.Start(info);
            //                proc.Close();
            //
            //                proc = new Process();
            //                proc.StartInfo.FileName = "localdb_creatorv11.bat";
            //                proc.StartInfo.WorkingDirectory = path;
            //                proc.StartInfo.CreateNoWindow = false;
            //                proc.Start();
            //                proc.WaitForExit();
            //                ExitCode = proc.ExitCode;
            //                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
            //                //info.Arguments = "net start MSSQL$SQLEXPRESS";
            //                //Process.Start(info);
            //                proc.Close();
            //            }
            //            catch (Exception ee)
            //            {
            //                MessageBox.Show(ee.Message);
            //            }
            //
            //
            //            try
            //            {
            //                contexto.AbreConexao();
            //                contexto.FechaConexao();
            //            }
            //            catch
            //            {
            //                MessageBox.Show("Não foi possivel estabelecer conexão com banco de dados, verifique as permissões do sistema operacional !");
            //                Application.Exit();
            //                this.Close();
            //            }
            //        }
            //
            //
            //        verifica_primeiro_acesso();
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.Message);
            //    }
            //}
        }

        public void verifica_primeiro_acesso()
        {
            try
            {
                UsuarioBLL objUsu = new UsuarioBLL();
                Boolean x = objUsu.Primeiro_acesso();
                if (x)
                {
                    this.Visible = false;
                    Primeiro_Acesso p_acesso = new Primeiro_Acesso();
                    p_acesso.ShowDialog();
                    this.Visible = true;

                    x = objUsu.Primeiro_acesso();
                    //if (x)
                    //    verifica_primeiro_acesso();

                }

            }
            catch (Exception e)
            {
                String path = "";


                String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                String[] xx = x.Split('\\');
                String p = "";
                for (int i = 0; i < (xx.Length - 2); i++)
                {
                    p += xx[i] + "\\";
                }
                p += "bats\\";
                path = p;


                Process proc = new Process();
                proc.StartInfo.FileName = "bd.bat";
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                int ExitCode = proc.ExitCode;
                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                //info.Arguments = "net start MSSQL$SQLEXPRESS";
                //Process.Start(info);
                proc.Close();

                proc = new Process();
                proc.StartInfo.FileName = "localdb_creator.bat";
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                ExitCode = proc.ExitCode;
                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                //info.Arguments = "net start MSSQL$SQLEXPRESS";
                //Process.Start(info);
                proc.Close();

                proc = new Process();
                proc.StartInfo.FileName = "localdb_creatorv11.bat";
                proc.StartInfo.WorkingDirectory = path;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                ExitCode = proc.ExitCode;
                //ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                //info.Arguments = "net start MSSQL$SQLEXPRESS";
                //Process.Start(info);
                proc.Close();

                MessageBox.Show(e.Message + "");
                //System.Diagnostics.Process.Start("c:\\batchfilename.bat");
            }
        }

        Contexto con = null;
        _Contexto _con = null;
        public string TipoPermissao { get; set; }
        public void ConectarAImpressora()
        {
            try
            {
                int iPorta = 0;
                int iVerificarImpressora = 0;
                int impressora = 0;
                //8 MP 2500 TH 
                //7 MP 4200 TH
                if (lblImpressora.Text.ToString() == "MP4200TH")
                {
                    impressora = 7;
                }
                else if (lblImpressora.Text.ToString() == "MP2500TH")
                {
                    impressora = 8;
                }
                iVerificarImpressora = MP2032.ConfiguraModeloImpressora(impressora);
                //Vaidar Impressora se 0 significa que a empressora não foi encontrada, se for 1 impressora foi 
                if (iVerificarImpressora == 0)
                {
                    lblmsg.Text = ("Impressora não encontrata!");
                    // MessageBox.Show("Impressora não encontrata!");

                }
                else
                {
                    lblmsg.Text = ("Impressora encontrada!");
                }
                iPorta = MP2032.IniciaPorta(("USB"));//inicia a porta com o valor da combo (exceto ethernet)

                if (iPorta <= 0) //testa se a conexão da porta foi bem sucedido
                {
                    lblmsg.Text = ("Não foi possível conectar com a impressora!!!");
                    // Application.Exit();
                }
                else
                {
                    lblmsg.Text = ("Impressora conectada!!!");
                    // MessageBox.Show("Impressora conectada!!!");

                }

            }
            catch (Exception ex)
            {
                lblmsg.Text = ("ERROR 001 : " + ex.Message);
                // MessageBox.Show("ERROR 001 : " + ex.Message);
            }
        }

        private DataTable OnePDV_Config()
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
        private DataTable ObterDadosDaEmpresa()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("Select Isnull(emp_cnpj,'INEXISTENTE') from empresa");
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
        #region
        private DataTable ObterDadosLicença()
        {
            DataTable emp = null;
            emp = ObterDadosDaEmpresa();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                _con = new _Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("Select Isnull(ClienteCnpjCpf,'INEXISTENTE') ,ChaveAcesso From onelicense where ClienteCnpjCpf = '",
                     emp.Rows[0][0].ToString(), "' and Ativo = 1");
                tab = _con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            _con = null;
            emp = null;
            return tab;
        }

        public void VerificarLicencaClienteCpfCnpj()
        {
            try
            {
                DataTable tabLic = null;
                DataTable tabEmp = null;

                tabLic = ObterDadosLicença();
                tabEmp = ObterDadosDaEmpresa();
                string cpfCnpjLicenca = "";

                string CpfCnpjEmpresa = tabEmp.Rows[0][0].ToString();
                if (tabLic.Rows.Count > 0)
                {
                    cpfCnpjLicenca = tabLic.Rows[0][0].ToString();
                }
                else
                {
                    throw new Exception("Ocorreu um bloqueio na validação do processo. Entre em contato com administrador do sistema");
                }
                if (CpfCnpjEmpresa != cpfCnpjLicenca)
                {
                    throw new Exception("Ocorreu um bloqueio na validação do processo. Entre em contato com administrador do sistema");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
        //Método da API
        [DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        public static Boolean IsConnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }
        public void verificarConexaoNet()
        {
            try
            {
                if (IsConnected())
                {
                    Process mProcesso = new Process();

                    // indica se deve usar o shell do sistema
                    // operacional para iniciar o processo
                    mProcesso.StartInfo.UseShellExecute = true;
                    // podemos iniciar qualquer processo
                    mProcesso.StartInfo.FileName = "http://www.google.com";
                    // indica se o processo deve iniciar em uma nova janela
                    mProcesso.StartInfo.CreateNoWindow = true;
                    //   mProcesso.Start();
                    //outra forma direta de chamar a página seria
                    //System.Diagnostics.Process.Start("http://www.google.com");

                    VerificarLicencaClienteCpfCnpj();
                }
                else
                {
                    if (MessageBox.Show("Não ha conexão com a internet. O sistema irá funcionar no modo Local , deseja continuar ?", "Sem Conexão ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (Exception)
            {
                throw;
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

        private void btEntrar_Click(object sender, EventArgs e)
        {
            try{

                Boolean licenca = verifica_licenca();
                //Boolean licenca = true;
                if (licenca){

                    //verificarConexaoNet();
                    //DataTable tab = null;
                    //tab = OnePDV_Config();
                    //if(tab.Rows[0]["Impressora"].ToString()!="")                                                                            
                    //lblImpressora.Text = tab.Rows[0]["Impressora"].ToString();
                    //ConectarAImpressora();
                    txtLogin.Text = txtLogin.Text.Trim();
                    txtSenha.Text = txtSenha.Text.Trim();
                    if (txtLogin.Text != "" && txtSenha.Text != "")
                    {

                        UsuarioBLL objUsu = new UsuarioBLL();
                        objUsu.LocalizarLogin(txtLogin.Text, txtSenha.Text);
                        if (objUsu.usu_codigo != 0)
                        {
                            if (objUsu.usu_status.Trim() != "Ativo")
                                throw new Exception("O usuário está inativo");
                            global.codUsuario = objUsu.usu_codigo;
                            global.nomeUsuario = objUsu.usu_nome;

                            PermissaoBLL objPer = new PermissaoBLL();
                            objPer.per_codigo = objUsu.per_codigo;
                            objPer.localizar(objUsu.per_codigo.ToString(), "per_codigo");
                            global.permissao = objPer.per_nome;
                            {
                                //if (tab.Rows[0]["TipoDePDV"].ToString() == "Restaurante")
                                //{
                                this.Hide();
                                //frmLoadPDVSkincs frm = new frmLoadPDVSkincs();
                                //frm.Show();
                                Menu frm = new Menu();
                                frm.Show();
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Informe o tipo de PDV para Restaurante");
                                //}
                            }
                        }
                        else
                        {
                            throw new Exception("Usuário ou senha estão incorretos!");
                        }
                    }
                    else
                    {
                        throw new Exception("Favor, preencha o campo 'Login' e 'Senha' com um usuário válido para poder logar");
                    }
                }
                //FazerBackupdoSistema();
            }catch (Exception ex){
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            //  try
            //  {
            //      using (SqlCommand cmd = new SqlCommand())
            //      {
            //
            //          Contexto contexto = new Contexto();
            //          contexto.AbreConexao();
            //          contexto.FechaConexao();
            //
            //      }
            //  }
            //  catch (Exception ex)
            //  {
            //      MessageBox.Show(ex.Message);
            //      throw ex;
            //  }


        }


        /*
         
         *   

         * 
         
         */


        private void btSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btEntrar_Click(sender, e);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btEntrar_Click(sender, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                //btnVoltar.Visible = false;
                txtLogin.Select();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void cboBanco_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //btnAbrirPDV.Visible = false;
            //btnVoltar.Visible = true;
            this.Height = 374;
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //btnVoltar.Visible = false;
            this.Height = 189;
            //btnAbrirPDV.Visible = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btEntrar.PerformClick();
        }

        private void txtSenha_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
                btEntrar.PerformClick();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public Boolean verifica_licenca()
        {

            LicencaDAL licenca = new LicencaDAL();

            DataTable licenca_dt = licenca.localizarLicenca("", "lic_data");

            if (licenca_dt.Rows.Count > 0)
            {
                String data_licenca = licenca_dt.Rows[0]["lic_data"].ToString();

                String[] xdata_licenca = data_licenca.Split('/');
                DateTime nova_data = new DateTime(Int32.Parse(xdata_licenca[2].Replace("00:00:00", "")), Int32.Parse(xdata_licenca[1]), Int32.Parse(xdata_licenca[0]));

                DateTime data_hoje = DateTime.Now.Date;

                int result = DateTime.Compare(nova_data, data_hoje);

                // Data 1 é anterior a Data 2
                if (result < 0)
                {
                    try
                    {
                        EmpresaDAL empresa = new EmpresaDAL();
                        DataTable dt = empresa.localizarEmTudo("");
                        String xx = dt.Rows[0]["emp_cnpj"].ToString();

                        Trend_SAT.ClienteClient client = new Trend_SAT.ClienteClient();
                        //trend


                        client.Open();
                        String x = "";

                        bd_pg sql = new bd_pg();
                        sql.AbrirConexao();
                        IDataReader dr = sql.RetornaDados("select * from trendsat_clientes where replace(replace(replace(cnpj,'.',''),'-',''),'/','') = '" + xx.ToString().Replace(".", "").Replace(",", "").Replace("/", "").Replace("-", "") + "'");

                        Int32 xlicenca = dr.GetOrdinal("licenca");

                        while (dr.Read())
                        {
                            x = dr.GetDateTime(xlicenca).ToShortDateString();
                        }

                        sql.FechaConexao();


                        client.Close();

                        if (x.Length > 0)
                        {
                            licenca.limpar_licencas();
                            String[] data = x.Split('/');
                            nova_data = new DateTime(Int32.Parse(data[2]), Int32.Parse(data[1]), Int32.Parse(data[0]));
                            licenca.inserir("", nova_data.ToShortDateString());

                            data_hoje = DateTime.Now.Date;
                            result = DateTime.Compare(nova_data, data_hoje);

                            if (result < 0)
                            {
                                MessageBox.Show("Sua licença expirou, contate o desenvolvedor do sistema.");
                                return false;
                            }
                            return true;

                        }
                        else
                        {
                            MessageBox.Show("Nenhuma licença encontrada para este software, entre em contato com o desenvolvedor.");
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Sua licença Expirou, contate o desenvolvedor ou certifique-se de não ter pendência financeira e estar conectado a internet.");
                        return false;
                    }


                }
                // Data 1 é igual a Data 2
                else if (result == 0)
                {
                    try
                    {
                        EmpresaDAL empresa = new EmpresaDAL();
                        DataTable dt = empresa.localizarEmTudo("");
                        String xx = dt.Rows[0]["emp_cnpj"].ToString();

                        Trend_SAT.ClienteClient client = new Trend_SAT.ClienteClient();
                        //trend


                        client.Open();
                        String x = client.DoWork(xx).ToString();

                        client.Close();

                        if (x.Length > 0)
                        {
                            licenca.limpar_licencas();
                            String[] data = x.Split('/');
                            nova_data = new DateTime(Int32.Parse(data[2]), Int32.Parse(data[1]), Int32.Parse(data[0]));
                            licenca.inserir("", nova_data.ToShortDateString());

                            data_hoje = DateTime.Now.Date;
                            result = DateTime.Compare(nova_data, data_hoje);

                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }

                    return true;
                }
                // Data 1 é maior a Data 2
                else if (result > 0)
                {
                    try
                    {
                        EmpresaDAL empresa = new EmpresaDAL();
                        DataTable dt = empresa.localizarEmTudo("");
                        String xx = dt.Rows[0]["emp_cnpj"].ToString();

                        Trend_SAT.ClienteClient client = new Trend_SAT.ClienteClient();
                        //trend


                        client.Open();
                        String x = client.DoWork(xx).ToString();

                        client.Close();

                        if (x.Length > 0)
                        {
                            licenca.limpar_licencas();
                            String[] data = x.Split('/');
                            nova_data = new DateTime(Int32.Parse(data[2]), Int32.Parse(data[1]), Int32.Parse(data[0]));
                            licenca.inserir("", nova_data.ToShortDateString());

                            data_hoje = DateTime.Now.Date;
                            result = DateTime.Compare(nova_data, data_hoje);

                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {

                EmpresaDAL empresa = new EmpresaDAL();
                DataTable dt = empresa.localizarEmTudo("");
                String xx = dt.Rows[0]["emp_cnpj"].ToString();

                //Verifica a licença na internet =============================================
                try
                {

                    Trend_SAT.ClienteClient client = new Trend_SAT.ClienteClient();
                    client.Open();
                    String x = client.DoWork(xx).ToString();

                    client.Close();

                    if (x.Length > 0)
                    {

                        licenca.limpar_licencas();
                        String[] data = x.Split('/');
                        DateTime nova_data = new DateTime(Int32.Parse(data[2]), Int32.Parse(data[1]), Int32.Parse(data[0]));
                        licenca.inserir("", nova_data.ToShortDateString());

                        DateTime data_hoje = DateTime.Now.Date;
                        int result = DateTime.Compare(nova_data, data_hoje);

                        if (result < 0)
                        {
                            MessageBox.Show("Sua licença expirou, contate o desenvolvedor do sistema.");
                            return false;
                        }
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Nenhuma licença encontrada para este software, entre em contato com o desenvolvedor.");
                        return false;
                    }
                }
                catch
                {



                    //DateTime data_hoje = DateTime.Now.Date;
                    MessageBox.Show("Você precisa estar conectado a internet para atualizar sua licença !");
                    return false;

                }

            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            t.ShowDialog();
        }


        private string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;

            //            var macAddr =
            //     (
            //         from nic in NetworkInterface.GetAllNetworkInterfaces()
            //         where nic.OperationalStatus == OperationalStatus.Up
            //         select nic.GetPhysicalAddress().ToString()
            //     ).FirstOrDefault();
            //
            //            return macAddr.ToString();
        }

        public void criar_local_base()
        {
            if (!Directory.Exists("C:/Trend_Rede"))
            {
                Directory.CreateDirectory("C:/Trend_Rede");
                String path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

                String[] xpath = path.Split('\\');
            }


        }

        private void frmLogon_FormClosed(object sender, FormClosedEventArgs e){
            Application.Exit();
        }



    }
}
