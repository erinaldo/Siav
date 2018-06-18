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
    public partial class frmCancelamentoCupom : Form
    {
        VendasBLL objVen = new VendasBLL();
        String codigo_compra;

        public frmCancelamentoCupom()
        {
            InitializeComponent();

         
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

        private void frmCancelamentoCupom_Load(object sender, EventArgs e)
        {
            DataTable tab = null;
            tab = objVen.localizarCupom(global.codUsuario);
            gridVendas.DataSource = tab;
            //  stiloGrid();
            gridVendas.ClearSelection();

            timer1.Enabled = false;
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

                if (id <= 0){
                    MessageBox.Show("");
                    ok = false;
                    return;
                }
                    
                codigo_compra = gridVendas.CurrentRow.Cells[0].Value.ToString();
                String[] xdata = gridVendas.CurrentRow.Cells[2].Value.ToString().Split(' ');

                String data = xdata[0];
                String hora = xdata[1];
                //CConfiguracao configuracao = new CConfiguracao();
                
                VendasBLL OjbVend = new VendasBLL();
                objVen.codigo = id;
                objVen.retorna_xml();
                //obj
                String xml = objVen.xml;

                //
                if (xml.Length > 0)
                {
                    if (hora.Trim().Length > 0)
                    {
                        try
                        {
                            DateTime horavenda = DateTime.Parse(hora);
                            DateTime datavenda = DateTime.Parse(data);
                            horavenda = horavenda.AddMinutes(31);

                            if (DateTime.Now.Date == datavenda.Date)
                            {

                                if (horavenda.TimeOfDay > DateTime.Now.TimeOfDay)
                                {
                                    System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", "SAT.Inicializar");
                                    System.Threading.Thread.Sleep(500);

                                    string xmlpuro = xml;
                                    xml = "SAT.CancelarCFe(\"" + xmlpuro + "\");";

                                    System.IO.File.WriteAllText(parametroSat("caminhocupomtxt"), xml);
                                    int sleep = 3000;
                                    int.TryParse(parametroSat("sleep"), out sleep);
                                    System.Threading.Thread.Sleep(sleep);

                                    string retorno = retornoSAT("codigoDeRetorno");
                                    if (retorno.Contains("7000"))
                                    {
                                        //excluirsat(ven_id);
                                        xml = "SAT.ImprimirExtratoCancelamento(\"" + xmlpuro + "\");";
                                        System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", xml);
                                        //return ok;
                                    }
                                    else
                                        ok = false;
                                }
                                else
                                {
                                    MessageBox.Show("Notas fiscais não podem ser canceladas após 30 minutos de sua emissão !");
                                    ok = false;
                                }
                            }
                            else
                                ok = false;

                        }
                        catch { ok = false; }
                    }
                }
                //ok = false;
                //return ok;
            }
            catch (Exception err)
            {               
                ok = false;
            }

            if (ok)
            {
                objVen.limpar();
                objVen.codigo =  Int32.Parse(codigo_compra);
                objVen.ven_status = "Cancelado";
                //txtCodigo.Text = frmCancelaCupom.Codigo;
                objVen.cancelarVenda();

                DataTable tab = null;
                tab = objVen.localizarCupom(global.codUsuario);
                gridVendas.DataSource = tab;
                //  stiloGrid();
                gridVendas.ClearSelection();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
