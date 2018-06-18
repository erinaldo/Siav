using One.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Relatorios
{
    public partial class frm_relatorio_detalhado_vendas : Form
    {
        public frm_relatorio_detalhado_vendas()
        {
            InitializeComponent();

            EmpresaBLL cmd = new EmpresaBLL();
            var x = cmd.localizarEmTudo("");

            DirectoryInfo dir = new DirectoryInfo("C:\\ACBrMonitorPLUS\\Arqs\\SAT\\Vendas\\" + x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", ""));
            String cnpj = x.Rows[0].ItemArray[9].ToString().Replace(".", "").Replace("/", "").Replace("-", "");

            foreach (DirectoryInfo file in dir.GetDirectories())
            {
                String diretorio = file.Name.Substring(4, 2) + "/" + file.Name.Substring(0, 4);
                cb_periodo.Items.Add(diretorio);

                // aqui no caso estou guardando o nome completo do arquivo em em controle ListBox
                // voce faz como quiser
                //                   lbxResultado.Items.Add(file.FullName);                
            }

        }




        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
