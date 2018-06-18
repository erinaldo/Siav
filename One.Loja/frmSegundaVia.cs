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

namespace One.Loja
{
    public partial class frmSegundaVia : Form
    {
        VendasBLL objVen = new VendasBLL();
        public frmSegundaVia()
        {
            InitializeComponent();

            DataTable tab = null;
            tab = objVen.LocalizarSegundaVia(global.codUsuario);
            gridVendas.DataSource = tab;
            //stiloGrid();
            gridVendas.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;

            try
            {
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

                Int32 id = Int32.Parse(gridVendas.CurrentRow.Cells[0].Value.ToString());

                if (id <= 0)
                {
                    MessageBox.Show("Falha ao imprimir cupom !");
                    ok = false;
                    return;
                }
                
                //CConfiguracao configuracao = new CConfiguracao();

                VendasBLL OjbVend = new VendasBLL();
                objVen.codigo = id;
                objVen.retorna_xml();
                String xml = objVen.xml;

                xml = "SAT.ImprimirExtratoVenda(\"" + xml + "\");";
                string codigoDeRetorno = this.retornoSAT("codigoDeRetorno");
                string numeroSessao = this.retornoSAT("numeroSessao");
                System.IO.File.WriteAllText("C:\\Rede_Sistema\\ENT.txt", xml);
            }
            catch (Exception err)
            {
                ok = false;
            }

          
        }

        private string retornoSAT(string chave)
        {

            string retorno = "";
            try
            {

                string[] lines = File.ReadAllLines(parametroSat("caminhosaitxt"));
                for (int i = 0; i < lines.Length; i++)
                {

                    if (lines[i].Contains(chave + "="))
                        retorno = lines[i].Substring(chave.Length + 1);

                }
            }
            catch { retorno = "Erro Monitor"; }
            return retorno;
        }

        private string parametroSat(string chave)
        {

            string retorno = "";
            string[] lines = File.ReadAllLines(Application.StartupPath + @"\SAT.ini");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(chave + "="))
                {
                    retorno = lines[i].Substring(chave.Length + 1);
                }
            }
            return retorno;
        }

    }
}
