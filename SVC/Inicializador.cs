using One.Bll;
using One.Dal;
using One.MENUS;
using SVC_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One
{
    public partial class Inicializador : Form
    {
        Int32 codigo_versao = 0;
        String descricao_versao = "";

        public Inicializador()
        {
            InitializeComponent();

            for (int ii = 0; ii < 5; ii++)
            {

                try
                {

                    if (!Directory.Exists("C:/Rede_Sistema"))
                        Directory.CreateDirectory("C:/Rede_Sistema");

                    String path = Directory.GetCurrentDirectory();
                    String[] xpath = path.Split('\\');

                    path = "";
                    for (int i = 0; i < (xpath.Length - 1); i++)
                    {
                        path += xpath[i] + "\\";
                    }

                    path += "database\\";
                    //

                    string x = DateTime.Now.ToShortDateString().Replace('/', '_');
                    //Directory.CreateDirectory("C:/Rede_Sistema/backup_" + x);
                    //Directory.CreateDirectory("C:/Rede_Sistema/backup_att");

                    // Verifica e existe atualizacao
                    if (Directory.Exists("C:/Rede_Sistema/backup_att"))
                    {
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

                        File.Delete(path + "trend_bd.mdf");
                        File.Delete(path + "trend_bd_log.ldf");
                        File.Copy("C:/Rede_Sistema/backup_att/trend_bd.mdf", path + "trend_bd.mdf", true);
                        File.Copy("C:/Rede_Sistema/backup_att/trend_bd_log.ldf", path + "trend_bd_log.ldf", true);
                        Directory.CreateDirectory("C:/Rede_Sistema/backup" + x);
                        File.Copy("C:/Rede_Sistema/backup_att/trend_bd.mdf", "C:/Rede_Sistema/backup" + x + "trend_bd.mdf", true);
                        File.Copy("C:/Rede_Sistema/backup_att/trend_bd_log.ldf", "C:/Rede_Sistema/backup" + x + "trend_bd_log.ldf", true);

                        //Directory.Delete("C:/Rede_Sistema/backup_att");
                    }

                    ii = 5;
                }
                catch
                {

                }

            }

            try
            {
                File.Delete("C:/Rede_Sistema/backup_att/trend_bd.mdf");
                File.Delete("C:/Rede_Sistema/backup_att/trend_bd_log.ldf");
                Directory.Delete("C:/Rede_Sistema/backup_att");
            }
            catch { }
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

                    verifica_atualizacoes();
                    this.Visible = false;
                    frmLogon xcmd = new frmLogon();
                    xcmd.Show();
                    //if (x)
                    //    verifica_primeiro_acesso();

                }
                else
                {
                    verifica_atualizacoes();

                    this.Visible = false;
                    frmLogon xcmd = new frmLogon();
                    xcmd.Show();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                Application.Exit();

                //System.Diagnostics.Process.Start("c:\\batchfilename.bat");
            }
        }

        public void inicializa()
        {
            if (true)
            {

                try
                {

                    Contexto contexto = new Contexto();

                    try
                    {
                        //MessageBox.Show(contexto.StrConexao);
                        contexto.AbreConexao();
                        contexto.FechaConexao();

                        try
                        {
                            VersaoDAL cmd = new VersaoDAL();
                            DataTable x = cmd.localizar();
                        }
                        catch { }
                        verifica_primeiro_acesso();
                        //this.Visible = false;
                        //frmLogon xcmd = new frmLogon();
                        //xcmd.Show();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);

                        try
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
                        }
                        catch (Exception eee)
                        {
                            MessageBox.Show(eee.Message);
                        }


                        try
                        {
                            contexto.AbreConexao();
                            contexto.FechaConexao();


                            verifica_primeiro_acesso();
                        }
                        catch (Exception eeee)
                        {
                            MessageBox.Show(eeee.Message);
                            MessageBox.Show("Não foi possivel estabelecer conexão com banco de dados, verifique as permissões do sistema operacional ou se o arquivo de banco de dados se encontra na pasta da aplicação !");

                            String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                            String[] xx = x.Split('\\');
                            String p = "";
                            for (int i = 0; i < (xx.Length - 2); i++)
                            {
                                p += xx[i] + "\\";
                            }

                            Process.Start("explorer.exe", p);
                            Application.Exit();
                            this.Close();
                        }
                    }


                    //verifica_primeiro_acesso();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Inicializador_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            inicializa();
        }

        public void verifica_atualizacoes()
        {
            try
            {
                VersaoDAL cmd = new VersaoDAL();
                DataTable dt = cmd.localizar();

                try
                {

                    this.codigo_versao = int.Parse(dt.Rows[0].ItemArray[1].ToString());
                    this.descricao_versao = dt.Rows[0].ItemArray[2].ToString();

                }
                catch
                {

                }

                #region Versão 2.0.3


                if (this.codigo_versao < 7)
                {

                    cmd.delete();
                    cmd.inserir(this.codigo_versao, this.descricao_versao);
                }


                #endregion

                #region Versão 2.0.6
                if (this.codigo_versao < 12)
                {

                    Contexto c = new Contexto();
                    SqlCommand xcmd = new SqlCommand();
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ALTER TABLE configuracao ADD apontar_vendedor_final_venda VARCHAR(1) NULL;");
                    sb.AppendLine("ALTER TABLE configuracao ADD atacado_pdv VARCHAR(1) NULL;");
                    sb.AppendLine("ALTER TABLE Produtos ADD precoAtacado decimal(19, 2) NULL;");
                    sb.AppendLine("insert into cfop(codigo,descricao)values('5101','5101 - Venda de produção do estabelecimento');");
                    sb.AppendLine("insert into cfop(codigo,descricao)values('5102','5102 - Venda de mercadoria adquirida ou recebida de terceiros');");
                    sb.AppendLine("insert into cfop(codigo,descricao)values('5103','5103 - Venda de produção do estabelecimento, efetuada fora do estabelecimento');");
                    sb.AppendLine("insert into cfop(codigo,descricao)values('5405','5405 - Venda de mercadoria adquirida ou recebida de terceiros em operação com mercadoria sujeita ao regime de substituição tributária, na condição de contribuinte substituído')");
                    xcmd.CommandText = sb.ToString();
                    c.ExecutaComando(xcmd);

                    cmd.delete();
                    cmd.inserir(12, "2.0.6");

                }
                #endregion

                #region Versão 2.0.7
                if (this.codigo_versao < 13)
                {
                    cmd.delete();
                    cmd.inserir(12, "2.0.7");

                }
                #endregion

                #region Versão 2.0.8
                if (this.codigo_versao < 13)
                {
                    cmd.delete();
                    cmd.inserir(13, "2.0.8");

                }
                #endregion
               
                #region Versão 2.1.4
                if (this.codigo_versao < 17)
                {
                    Contexto c = new Contexto();
                    SqlCommand sql = new SqlCommand();
                    sql.CommandText = "delete from Unidades";
                    c.ExecutaComando(sql);

                    UnidadesDAL xcmd = new UnidadesDAL();
                    xcmd.inserir("AMPOLA");
                    xcmd.inserir("BALDE");
                    xcmd.inserir("BANDEJ");
                    xcmd.inserir("BARRA");
                    xcmd.inserir("BISNAG");
                    xcmd.inserir("BLOCO");
                    xcmd.inserir("BOBINA");
                    xcmd.inserir("BOMB");
                    xcmd.inserir("CAPS");
                    xcmd.inserir("CART");
                    xcmd.inserir("CENTO");
                    xcmd.inserir("CJ");
                    xcmd.inserir("CM");
                    xcmd.inserir("CM2");
                    xcmd.inserir("CX");
                    xcmd.inserir("CX2");
                    xcmd.inserir("CX3");
                    xcmd.inserir("CX5");
                    xcmd.inserir("CX10");
                    xcmd.inserir("CX15");
                    xcmd.inserir("CX20");
                    xcmd.inserir("CX25");
                    xcmd.inserir("CX50");
                    xcmd.inserir("CX100");
                    xcmd.inserir("DISP");
                    xcmd.inserir("DUZIA");
                    xcmd.inserir("EMBAL");
                    xcmd.inserir("FARDO");
                    xcmd.inserir("FOLHA");
                    xcmd.inserir("FRASCO");
                    xcmd.inserir("GALAO");
                    xcmd.inserir("GF");
                    xcmd.inserir("GRAMAS");
                    xcmd.inserir("JOGO");
                    xcmd.inserir("KG");
                    xcmd.inserir("KIT");
                    xcmd.inserir("LATA");
                    xcmd.inserir("LITRO");
                    xcmd.inserir("M");
                    xcmd.inserir("M2");
                    xcmd.inserir("M3");
                    xcmd.inserir("MILHEI");
                    xcmd.inserir("ML");
                    xcmd.inserir("MWH");
                    xcmd.inserir("PACOTE");
                    xcmd.inserir("PALETE");
                    xcmd.inserir("PARES");
                    xcmd.inserir("PC");
                    xcmd.inserir("POTE");
                    xcmd.inserir("K");
                    xcmd.inserir("RESMA");
                    xcmd.inserir("ROLO");
                    xcmd.inserir("SACO");
                    xcmd.inserir("SACOLA");
                    xcmd.inserir("TAMBOR");
                    xcmd.inserir("TANQUE");
                    xcmd.inserir("TON");
                    xcmd.inserir("TUBO");
                    xcmd.inserir("UNID");
                    xcmd.inserir("VASIL");
                    xcmd.inserir("VIDRO");

                    cmd.delete();
                    cmd.inserir(17, "2.1.4");

                }
                #endregion

                #region Versão 2.1.5

                if (this.codigo_versao < 18){

                    Contexto c = new Contexto();
                    SqlCommand sql = new SqlCommand();
                    sql.CommandText = "ALTER TABLE vendaItens ALTER COLUMN vi_quantidade decimal(16,3)";
                    c.ExecutaComando(sql);

                    cmd.delete();
                    cmd.inserir(18, "2.1.4");

                    MessageBox.Show("Atualziação Realizada com sucesso !");
                }
                #endregion

                #region Versão 2.1.6

                if (this.codigo_versao < 19)
                {

                    Contexto c = new Contexto();
                    SqlCommand sql = new SqlCommand();
                    sql.CommandText = "ALTER TABLE vendas_promissoria ADD vendedor int";
                    c.ExecutaComando(sql);

                    cmd.delete();
                    cmd.inserir(19, "2.1.6");

                    MessageBox.Show("Atualziação Realizada com sucesso !");
                }
                #endregion

            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            t.ShowDialog();
        }

    }
}
