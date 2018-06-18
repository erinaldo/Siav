using One.Bll;
using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace One.Relatorios
{
    public partial class frm_contabilidade_xml : Form
    {
        String cnpj;

        public frm_contabilidade_xml()
        {

            InitializeComponent();

            calcula();


            EmpresaBLL cmd = new EmpresaBLL();
            var x = cmd.localizarEmTudo("");

            //String xx = "";

            //

            acbr_path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DirectoryInfo dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", ""));
            this.cnpj = x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", "");

            foreach (DirectoryInfo file in dir.GetDirectories()){
                String diretorio = file.Name.Substring(4, 2) + "/" + file.Name.Substring(0, 4);
                cb_periodo.Items.Add(diretorio);
                
                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                //                   lbxResultado.Items.Add(file.FullName);                
            }
            //C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas

            //   ConfiguracoesBLL entidade = new ConfiguracoesBLL();
            //   entidade.localizar();
            //
            //   EmpresaBLL empresa = new EmpresaBLL();
            //   DataTable dt = empresa.localizarEmTudo("");
            //
            //   empresa.localizarLeave(dt.Rows[0].ItemArray[0].ToString(), "emp_codigo");
            //   // DataTable dt = objEmp.localizarEmTudo("");            
            //
            //   string[] diretorios = Directory.GetDirectories(entidade.acbr_path.Trim());
            //   diretorios = Directory.GetDirectories(diretorios[1] + "\\" + empresa.emp_cnpj);
            //
            //   for (int i = (diretorios.Length - 1); i >= 0; i--)
            //   {
            //       String[] aux = diretorios[i].Split('\\');
            //       String x = aux[aux.Length - 1].Substring(0, 4);
            //       String x2 = aux[aux.Length - 1].Substring(4, 2);
            //
            //       x = x2 + "/" + x;
            //
            //       //String x = aux[aux.Length - 1].Substring(0,3) + "/" + aux[aux.Length - 1].Substring(4,5).ToString();
            //       cb_periodo.Items.Add(x);
            //
            //   }

        }

        public void calcula()
        {
            try
            {
                Double totalvenda = 0;
                Double totalimposto = 0;

                DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Natanniel\Desktop\201803");
                //DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Natanniel\Desktop\cancelamentos_201708");
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
                DataTable dt_produtos = new DataTable();

                String[,] itens = new String[5000, 2];

                int linha = 0;

                foreach (FileInfo File in Files)
                {

                    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                    xml.Load(File.FullName);
                    System.Xml.XmlElement root = xml.DocumentElement;
                    System.Xml.XmlNodeList nodeList = root.GetElementsByTagName("total");

                    totalvenda += Double.Parse(nodeList[0]["vCFe"].InnerText, System.Globalization.CultureInfo.InvariantCulture);
                  
                }

                dt_produtos = new DataTable();
                dt_produtos.Columns.Add("Código Produto", typeof(string));
                dt_produtos.Columns.Add("Quantidade Produto", typeof(string));

                for (int x = 0; x < linha; x++)
                {
                    dt_produtos.Rows.Add(itens[x, 0], itens[x, 1]);
                }

                super_grid spg = new super_grid(dt_produtos);
                spg.ShowDialog();
            }
            catch { }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (cb_periodo.SelectedItem != null && cb_periodo.SelectedItem != "")
            {

                if (acbr_path.Text != null && acbr_path.Text != "")
                {

                    if (Directory.Exists(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_")))
                        Directory.Delete(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_"));

                    Directory.CreateDirectory(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_"));

                    // Arquivos de Venda
                    DirectoryInfo dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + cnpj + "\\" + cb_periodo.SelectedItem.ToString().Split('/')[1] + cb_periodo.SelectedItem.ToString().Split('/')[0]);
                    if (Directory.Exists(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\vendas"))
                        Directory.Delete(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\vendas");

                    Directory.CreateDirectory(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\vendas");


                    foreach (FileInfo file in dir.GetFiles())
                    {
                        try
                        {
                            System.IO.File.Copy(file.FullName, acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\vendas" + "\\" + file.Name, true);
                        }
                        catch
                        {

                        }
                    }
                    // Arquivos de Cancelamento
                    try
                    {
                        dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Cancelamentos\\" + cnpj + "\\" + cb_periodo.SelectedItem.ToString().Split('/')[1] + cb_periodo.SelectedItem.ToString().Split('/')[0]);
                        if (Directory.Exists(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\cancelamentos"))
                            Directory.Delete(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\cancelamentos");

                        Directory.CreateDirectory(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\cancelamentos");


                        foreach (FileInfo file in dir.GetFiles())
                        {
                            try
                            {
                                System.IO.File.Copy(file.FullName, acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + "\\cancelamentos" + "\\" + file.Name, true);
                            }
                            catch
                            {

                            }
                        }
                    }
                    catch { }

                    //var bytes = Directory.r File.ReadAllBytes(this.fileName);
                    //using (FileStream fs =new FileStream(this.newFileName, FileMode.CreateNew))
                    //using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    //{
                    //     zipStream.Write(bytes, 0, bytes.Length);
                    //}

                    //String startPath = @"c:\example\start";
                    //string zipPath = @"c:\example\result.zip";
                    //string extractPath = @"c:\example\extract";
                    //

                    ICSharpCode.SharpZipLib.Zip.FastZip c = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    c.CreateZip(acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_") + ".zip" , acbr_path.Text + "\\Fechamento_" + cb_periodo.SelectedItem.ToString().Replace("/", "_"), true, "");
                    MessageBox.Show("Exportação finalizada com sucesso !");
                }
                else
                {
                    MessageBox.Show("Você precisa selecionar o diretório de destino para os arquivos");
                }

            }
            else
            {
                MessageBox.Show("Você precisa selecionar o período para exportação");
            }


            //DirectoryInfo diretorio_emissao = new DirectoryInfo(@acbr_path.Text);
            //FileInfo[] Files = diretorio_emissao.GetFiles("*", SearchOption.AllDirectories);
            //foreach (FileInfo File in Files)
            //{
            //    //XmlTextReader xml_emitido = new XmlTextReader(File.FullName);
            //    Boolean xml_cancelado = false;
            //
            //    XmlDocument xml_emitido = new XmlDocument();
            //    xml_emitido.LoadXml(File.FullName);
            //    
            //   //xml_emitido.
            //   //
            //   //System.Xml.XmlElement root = xml_emitido.DocumentElement;
            //   //
            //   //
            //   //System.Xml.XmlNodeList nodeList = root.GetElementsByTagName("infCFe");
            //   //
            //   //XmlAttributeCollection attrColl = DocumentElement.Attributes;
            //
            //
            //        
            //
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                acbr_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //     acbr_cancel.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         

        }

        private void frm_contabilidade_xml_Load(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void acbr_path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
