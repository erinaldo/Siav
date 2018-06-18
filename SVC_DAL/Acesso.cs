using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using One.Dal;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace DataAccessLayer.Dal
{
    /// <summary>
    /// Irá abrir o arquivo de configuração xml e montar uma string de conexão com banco de dados.
    /// </summary>
    public class Acesso
    {
        Contexto con = null;
        /*
         * Declaração de variaveis
         */
        private string localPath, fileName;

        public Acesso()
        {
            this.localPath = "C:\\Users\\Tyago\\Desktop\\Trend_SIAV\\ZFontes\\SVC\\";
            this.fileName = "dbConfig.xml";
        }

        /// <summary>
        /// Define o diretorio local onde esta o arquivo dedelete_fabricante configuração.
        /// </summary>
        /// <param name="localPath"></param>
        public void setLocalPath(string localPath)
        {
            this.localPath = localPath;
        }

        /// <summary>
        /// Retorna o caminho do diretório local
        /// </summary>
        /// <returns>localPtah</returns>
        public string getLocalPath()
        {
            return localPath;
        }

        /// <summary>
        /// Define o nome do arquivo de configuração
        /// </summary>
        /// <param name="fileName"></param>
        public void setfileName(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Retorna o nome do arquivo de configuração
        /// </summary>
        /// <returns>fileName</returns>
        public string getfileName()
        {
            return fileName;
        }

        /// <summary>
        /// Método que irá montar a string de conexão para o banco de dados PostgreSQL
        /// </summary>
        /// <returns>string</returns>
        public string readDriverPGSQL()
        {
            string stConnect = "";
            try
            {
                XmlDocument domDoc = new XmlDocument();

                string completePath = (this.localPath + this.fileName);
                int passada = 0;

                domDoc.Load(completePath);

                //Seleciona somente o node com atributo igual ao especificado. Utilizando XPath.
                foreach (XmlNode node in domDoc.SelectSingleNode("//driver[@name='PGSQL']"))
                {
                    passada++;
                    string strName = node.Name;
                    string strValue = node.InnerText;

                    //Converte o caracter underscore por espaço. No node Name
                    StringBuilder newStrName = new StringBuilder(strName);
                    newStrName.Replace("_", " ");

                    //Monta a string de conexão
                    if (passada == 1)
                    {
                        stConnect += (newStrName + "=" + strValue);
                    }
                    else
                    {
                        stConnect += "; " + (newStrName + "=" + strValue);
                    }
                }
                //Retorna string preenchida
                return (stConnect);
            }
            catch (XmlException xmlEx)
            {
                return (xmlEx.Message);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        /// <summary>
        /// Método que irá montar a string de conexão para o banco de dados Microsoft SQL Server
        /// </summary>
        /// <returns>string</returns>
        public string readDriverMSSQL()
        {
            string stConnect = "";
            try
            {
                XmlDocument domDoc = new XmlDocument();

                string completePath = (this.localPath + this.fileName);
                int passada = 0;

                domDoc.Load(completePath);

                //Seleciona somente o node com atributo igual ao especificado. Utilizando XPath.
                foreach (XmlNode node in domDoc.SelectSingleNode("//driver[@name='MSSQL']"))
                {
                    passada++;
                    string strName = node.Name;
                    string strValue = node.InnerText;

                    //Converte o caracter underscore por espaço. No node Name
                    StringBuilder newStrName = new StringBuilder(strName);
                    newStrName.Replace("_", " ");

                    //Monta a string de conexão
                    if (passada == 1)
                    {
                        stConnect += (newStrName + "=" + strValue);
                    }
                    else
                    {
                        stConnect += "; " + (newStrName + "=" + strValue);
                    }
                }
                //Retorna string preenchida
                return (stConnect);
            }
            catch (XmlException xmlEx)
            {
                return (xmlEx.Message);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public string readDriverSQL()
        {
            try
            {
                String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                String[] xx = x.Split('\\');
                String p = "";
                for (int i = 0; i < (xx.Length - 2); i++){
                    p += xx[i] + "\\";
                }
                p += "database\\";

                String text = "";
                
                // Debug
                //text = "C:\\Program Files (x86)\\Trend\\Trend SAT\\database\\trend_bd.mdf";
                
                // Desenvolvimento 
                //text = "C:\\Rede_Sistema\\trend_bd.mdf";

                // Produção
                text = p + "trend_bd.mdf";                

                // Versão antiga sistema
                //text = System.IO.File.ReadAllText(@System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "bd.txt");
                
                // Nova versão Sistema
                text = @"Data Source=(localdb)\v12.0;AttachDbFileName=" + text + ";Integrated Security=True;"; 
                

                return text;

            }
            catch (XmlException xmlEx)
            {
                return (xmlEx.Message);
            }
            catch (Exception ex){
                return (ex.Message);
            }

        }

        public string readDriverSQL_teste(String text)
        {
            try
            {
                String x = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                String[] xx = x.Split('\\');
                
                String p = "";
                
                for (int i = 0; i < (xx.Length - 2); i++)
                {
                    p += xx[i] + "\\";
                }
                p += "database\\";

                // Debug
                //text = "C:\\Program Files (x86)\\Trend\\Trend SAT\\database\\trend_bd.mdf";

                // Desenvolvimento 
                //text = "C:\\Users\\Natanniel\\Desktop\\Trend_SIAV\\ZFontes\\SVC\\bin\\database\\trend_bd.mdf";

                // Produção
                text = p + "trend_bd.mdf";

                // Nova versão Sistema
                text = @"Server=" + text + ";Initial Catalog=Siav;Integrated Security=True;";
                // Versão antiga sistema
                //text = System.IO.File.ReadAllText(@System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "bd.txt");

                return text;

            }
            catch (XmlException xmlEx)
            {
                return (xmlEx.Message);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }

        }


        public string readDriverSQLV12()
        {
            //string stConnect = "";
            try
            {
                /*XmlDocument domDoc = new XmlDocument();

                string completePath = (this.localPath + this.fileName);
                int passada = 0;

                domDoc.Load(completePath);

                //Seleciona somente o node com atributo igual ao especificado. Utilizando XPath.
                foreach (XmlNode node in domDoc.SelectSingleNode("//driver[@name='SQL']"))
                {
                    passada++;
                    string strName = node.Name;
                    string strValue = node.InnerText;

                    //Converte o caracter underscore por espaço. No node Name
                    StringBuilder newStrName = new StringBuilder(strName);
                    newStrName.Replace("_", " ");

                    //Monta a string de conexão
                    if (passada == 1)
                    {
                        stConnect += (newStrName + "=" + strValue);
                    }
                    else
                    {
                        stConnect += "; " + (newStrName + "=" + strValue);
                    }
                }
                //Retorna string preenchida
                return (stConnect);*/

                //return "DATABASE=nfe;Pooling=False;SERVER=localhost;PORT=5433;UID=sistema;Password=q2aw3@se4;";
                //<add name="ConnectionStringName" providerName="System.Data.SqlClient"
                //return "Data Source=.\SQLEXPRESS;Initial Catalog=DatabaseName;Integrated Security=True;MultipleActiveResultSets=True"/>
                //return "Server=Natanniel-PC\\SQLEXPRESS;Database=Siav;User Id=sistema; Password=q2aw3@se4;Integrated Security=True";

                string text = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "trend_bd.mdf";

                //text = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + text + ";Integrated Security=True";
                //text = @"Data Source=(LocalDB)\v12.0;AttachDbFilename=" + text + ";Integrated Security=True";
                text = @"Data Source=(localdb)\v11.0;Initial Catalog=" + text + ";Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                
                return text;

                //return "Server=192.168.3.78;Database=Siav;User Id=sistemaSAT";
                //String x = ConfigurationManager.AppSettings["countoffiles"];                
                //return "Data Source=Natanniel-PC\\SQLEXPRESS;Initial Catalog=Siav;Integrated Security=True";

            }
            catch (XmlException xmlEx)
            {
                return (xmlEx.Message);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public void RealizarBackupSistema()
        {
            SqlCommand cmd = null;
            try
            {

                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("GerarBakupOnePDV");
                cmd.CommandType = CommandType.StoredProcedure;
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
                MessageBox.Show("Backup realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
