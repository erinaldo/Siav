using One.Bll;
using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class GerarVendasXML : Form
    {
        String cnpj;
        //String acbr_path;
        public GerarVendasXML()
        {
            InitializeComponent();

            EmpresaBLL cmd = new EmpresaBLL();
            var x = cmd.localizarEmTudo("");

            //String xx = "";

            //

            //acbr_path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DirectoryInfo dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", ""));
            this.cnpj = x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", "");

            foreach (DirectoryInfo file in dir.GetDirectories()){

                String diretorio = file.Name.Substring(4, 2) + "/" + file.Name.Substring(0, 4);
                cb_periodo.Items.Add(diretorio);

                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                //                   lbxResultado.Items.Add(file.FullName);                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Double totalvenda = 0;
                Double totalimposto = 0;

                DirectoryInfo Dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + this.cnpj + "\\" + cb_periodo.SelectedItem.ToString().Split('/')[1] + cb_periodo.SelectedItem.ToString().Split('/')[0]);
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

                lbl_total.Text = "R$ " + totalvenda;

                //dt_produtos = new DataTable();
                //dt_produtos.Columns.Add("Código Produto", typeof(string));
                //dt_produtos.Columns.Add("Quantidade Produto", typeof(string));
                //
                //for (int x = 0; x < linha; x++)
                //{
                //    dt_produtos.Rows.Add(itens[x, 0], itens[x, 1]);
                //}
                //
                //super_grid spg = new super_grid(dt_produtos);
                //spg.ShowDialog();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Double totalvenda = 0;
                Double totalimposto = 0;

                DirectoryInfo Dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + this.cnpj + "\\" + cb_periodo.SelectedItem.ToString().Split('/')[1] + cb_periodo.SelectedItem.ToString().Split('/')[0]);
                //DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Natanniel\Desktop\cancelamentos_201708");
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
                DataTable dt_produtos = new DataTable();

                String[,] itens = new String[5000, 2];

                int linha = 0;
                Decimal vltotal = 0;
                int file = 0;

                StringBuilder sb = new StringBuilder();   
                foreach (FileInfo File in Files)
                {
                    file++;
                    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                    xml.Load(File.FullName);
                    System.Xml.XmlElement root = xml.DocumentElement;
                    System.Xml.XmlNodeList nodeList = root.GetElementsByTagName("total");

                    Decimal total = Decimal.Parse(nodeList[0]["vCFe"].InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    vltotal += Decimal.Parse(nodeList[0]["vCFe"].InnerText, System.Globalization.CultureInfo.InvariantCulture);
                    String data = File.CreationTime.ToString();

                                     

                    sb.AppendLine("INSERT INTO Vendas ");
                    sb.AppendLine("(ven_cliente,ven_dataVenda,ven_usuario,ven_formaPagamento ");
                    sb.AppendLine(",ven_qtdParcelas,ven_valorTotal,ven_observacao,ven_desconto ");
                    sb.AppendLine(",ven_percentualDesconto,ven_valorFinal,ven_status,ven_tipo ");
                    sb.AppendLine(",ven_vendedor,ven_diaSemana,ven_contratoimpresso,ven_ticket ");
                    sb.AppendLine(",IDAber,cpfcnpj,sessao,xml,nserieSAT)VALUES(1,'" + data.Split('/')[1]+"/" +data.Split('/')[0]+"/"+data.Split('/')[2] + "',1,null,");
                    sb.AppendLine(" null,"+total.ToString().Replace(',','.')+",null,0, ");
                    sb.AppendLine("0," + total.ToString().Replace(',', '.') + ",'Ativo','Venda',");
                    sb.AppendLine("0,null,null,0 ");
                    sb.AppendLine(",0 ,'' ,'1' ,'' ,''); ");

                   

                }

                Contexto c = new Contexto();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = sb.ToString();
                c.ExecutaComando(sql);

                //dt_produtos = new DataTable();
                //dt_produtos.Columns.Add("Código Produto", typeof(string));
                //dt_produtos.Columns.Add("Quantidade Produto", typeof(string));
                //
                //for (int x = 0; x < linha; x++)
                //{
                //    dt_produtos.Rows.Add(itens[x, 0], itens[x, 1]);
                //}
                //
                //super_grid spg = new super_grid(dt_produtos);
                //spg.ShowDialog();
            }
            catch { }
        }
    }
}

