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
//using View;
using One.MOVIMENTACOES;
using One.Bll;
using One.Loja;
using System.Data.SqlClient;
using One.Dal;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DataAccessLayer.Dal;
using System.IO;




namespace One.MENUS
{
    public partial class frmLogon : Form
    {
        public frmLogon()
        {
            InitializeComponent();

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
                //iVerificarImpressora = MP2032.ConfiguraModeloImpressora(impressora);
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
                //iPorta = MP2032.IniciaPorta(("USB"));//inicia a porta com o valor da combo (exceto ethernet)

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
        private DataTable VerificarAberturaCaixa()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("select fin_codigo from fin_abertura_caixa where fin_usuario =", global.codUsuario, "and fin_caixa =", global.NumeroCaixa, "and Fechou is null");
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

        private DataTable ObterAcessoDemo()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = string.Concat("Select * from CaixaPDV");
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
        public void SetarAcess()
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "Insert Into CaixaPDV (Data,Usuario) values (@Data,@Usuario)";
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = global.codUsuario;
                con.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            con = null;
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
            try
            {

                //DataTable tab2 = null;
                //tab2 = ObterAcessoDemo();
                //if(tab2.Rows.Count > 15)
                //{
                //    throw new Exception("Voce já ultrapassou a quantidade de acesso DEMO");
                //}
                //SetarAcess();
                //ConectarAImpressora();
                // verificarConexaoNet();
                if (cboCaixa.Text.ToString() == "")
                {
                    cboCaixa.Focus();
                    throw new Exception("Informe o caixa");
                }
                //DataTable tab = null;
               // tab = OnePDV_Config();
               // if (tab.Rows[0]["Impressora"].ToString() != "")
               // {
               //     lblImpressora.Text = tab.Rows[0]["Impressora"].ToString();
               // }
                
                txtLogin.Text = txtLogin.Text.Trim();
                txtSenha.Text = txtSenha.Text.Trim();
                if (txtLogin.Text != "" && txtSenha.Text != "")
                {
                    UsuarioBLL objUsu = new UsuarioBLL();
                    objUsu.LocalizarLogin(txtLogin.Text, txtSenha.Text);
                    if (objUsu.usu_codigo != 0)
                    {
                        //if (objUsu.usu_status != "Ativo")
                        //    throw new Exception("O usuário está inativo");
                        global.codUsuario = objUsu.usu_codigo;
                        global.nomeUsuario = objUsu.usu_nome;
                        global.NumeroCaixa = cboCaixa.Text.ToString();

                        PermissaoBLL objPer = new PermissaoBLL();
                        objPer.per_codigo = objUsu.per_codigo;
                        objPer.localizar(objUsu.per_codigo.ToString(), "per_codigo");

                        global.permissao = objPer.per_nome;
                        {
                            DataTable tab1 = null;
                            tab1 = VerificarAberturaCaixa();
                            if (tab1.Rows.Count > 0)
                            {

                                this.Hide();
                                //frmPDVSkin frm = new frmPDVSkin("0");
                                frmPDV frm = new frmPDV("0");
                                frm.txtUsuario = global.nomeUsuario;
                                frm.Show();
                            }
                            else
                            {
                                if (MessageBox.Show("Não existe caixa aberto para esse usuario!Tem certeza que desejas abrir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    this.Hide();
                                    //frmPDVSkin
                                    frmPDV frm = new frmPDV("0");
                                    frm.txtUsuario = global.nomeUsuario;
                                    frm.Show();
                                }

                            }
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
                //FazerBackupdoSistema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
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
            //btnVoltar.Visible = false;

            if (string.IsNullOrEmpty(cboCaixa.Text))
                cboCaixa.Select();
            else
                txtLogin.Select();
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

        private void frmLogon_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLoadCaixa caixa = new frmLoadCaixa();
            caixa.ShowDialog();
        }

        private void cboCaixa_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text))
                txtLogin.Focus();
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text))
                txtSenha.Focus();
        }

        private void lblImpressora_Click(object sender, EventArgs e)
        {

        }

        private void lblmsg_Click(object sender, EventArgs e)
        {

        }
    }
}
