using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.MOVIMENTACOES
{
    public partial class Escolher_Impressora : Form
    {
        public Escolher_Impressora()
        {
            InitializeComponent();
        }

        public int iRetorno = 0; //Variável para retorno das chamadas
        public string porta="";

        private void Escolher_Impressora_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            

            // LOAD do Formulário para configuração de portas e Modelos de impressoras
            // carrega o combo com os modelos das impressoras
            cbModeloImp.Items.Add("MP 20 CI");
            cbModeloImp.Items.Add("MP 20 MI");
            cbModeloImp.Items.Add("MP 20 TH");
            cbModeloImp.Items.Add("MP 2000 CI");
            cbModeloImp.Items.Add("MP 2000 TH");
            cbModeloImp.Items.Add("MP 2100 TH");
            cbModeloImp.Items.Add("MP 2500 TH");
            cbModeloImp.Items.Add("MP 4000 TH");
            cbModeloImp.Items.Add("MP 4200 TH");

            //carrega o combo com as portas
            cbPorta.Items.Add("USB");
            cbPorta.Items.Add("COM1");
            cbPorta.Items.Add("COM2");
            cbPorta.Items.Add("COM3");
            cbPorta.Items.Add("COM4");
            cbPorta.Items.Add("LPT1");
            cbPorta.Items.Add("LPT2");
            cbPorta.Items.Add("LPT3");
            cbPorta.Items.Add("LPT4");
            cbPorta.Items.Add("ETHERNET");
        }

        private void cbPorta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPorta.SelectedItem.ToString() == "ETHERNET")
            {
                txtIpImpressora.Visible = true;
            }
            btnOk.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            iRetorno = -1;//Cancelado pelo Usuário
           // this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            string porta = cbPorta.SelectedItem.ToString(); //pega a seleção da combo 
            if (porta == "ETHERNET")
            {
                iRetorno = MP2032.IniciaPorta(txtIpImpressora.Text); //inicia a porta com o IP digitado
                porta = txtIpImpressora.Text;
            }
            else
            {
                iRetorno = MP2032.IniciaPorta(cbPorta.SelectedItem.ToString());//inicia a porta com o valor da combo (exceto ethernet)
                porta = cbPorta.SelectedItem.ToString();
            }

            if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                MessageBox.Show("Não foi possível conectar com a impressora!!!");
                //Application.Exit();
            }
            else
            {
                MessageBox.Show("Impressora conectada!!!");
            }
           // this.Close(); //após clicar em OK, fecha o formulário dpara configuração de porta e impressora
        }

        private void cbModeloImp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string modeloImp = cbModeloImp.SelectedItem.ToString(); //Pega a seleção do Combo

            //testes para definir o código do modelo da impressora
            if (modeloImp == "MP 20 CI")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(1);
            }
            else if (modeloImp == "MP 20 MI")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(1);
            }
            else if (modeloImp == "MP 20 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(0);
            }
            else if (modeloImp == "MP 2000 CI")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(0);
            }
            else if (modeloImp == "MP 2000 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(0);
            }
            else if (modeloImp == "MP 2100 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(0);
            }
            else if (modeloImp == "MP 2500 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(8);
            }
            else if (modeloImp == "MP 4000 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(5);
            }
            else if (modeloImp == "MP 4200 TH")
            {
                iRetorno = MP2032.ConfiguraModeloImpressora(7);
            }


            cbPorta.Enabled = true; //habilita a COMBO para seleção da porta
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int impressao;

            impressao = MP2032.FormataTX("teste", 2, 0, 0, 1,1);

            if (impressao == 1)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("erro");
            }

        }
    }
}
