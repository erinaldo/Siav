using GestaoComercial;
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

namespace Demo_sorft
{
    public partial class Licenca : Form
    {
        public Licenca()
        {
            InitializeComponent();
        }

        string dtmaquina = "";
        string dtaplic = "";
        string dtvenc = "";

        private void frm_lec_Load(object sender, EventArgs e)
        {
            #region Data Maquina
            DateTime agora = DateTime.Now;
            string stringSerFeitoReplace1 = agora.ToString("dd/MM/yyyy");
            var vencimento = stringSerFeitoReplace1.Replace(",", "/");
            dtmaquina = vencimento;
            #endregion

            #region Data do Gestão Comercial
            string key = "Criptografia";
            Criptografia crip = new Criptografia(CryptProvider.DES);
            crip.Key = key;
            dtaplic = File.ReadAllText(@"c:\one\hpostap.dll", System.Text.Encoding.UTF8);

            #endregion

            #region Data do Vencimento
            dtvenc = File.ReadAllText(@"c:\one\host.dll", System.Text.Encoding.UTF8);
            #endregion

            txt_maq.Text = dtmaquina;
            txt_prog.Text =crip.Decrypt(dtaplic);
            txt_venc.Text = crip.Decrypt(dtvenc);
        }

        private void bt_atualizar_Click(object sender, EventArgs e)
        {
            #region Atualizar a data do Aplicativo
            try
            {
                StreamWriter x;
                //Colocando o endereço físico (caminho do arquivo texto) 
                string Caminho = @"c:\one\hpostap.dll";
                File.Delete(Caminho);
                //usando o metodo e abrindo o arquivo texto
                x = File.AppendText(Caminho);

                string key = "Criptografia"; //Está chave você mesmo é quem escolhe.
                Criptografia crip = new Criptografia(CryptProvider.DES);
                crip.Key = key;
                x.WriteLine(crip.Encrypt(txt_prog.Text));
                x.Close();
                MessageBox.Show("Licença Atualizada com Sucesso!", ">>>SIAV<<<<<<<<<<<<", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3314: Sem Comunicação com a licenção ou acesso de permissão!", ">>>SIAV<<<<<<<<<<<<", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.Exit();
                return;
            }
            #endregion

            #region Atualizar a data do Vencimento
            try
            {
                StreamWriter x;
                //Colocando o endereço físico (caminho do arquivo texto) 
                string Caminho = @"c:\one\host.dll";
                File.Delete(Caminho);
                //usando o metodo e abrindo o arquivo texto
                x = File.AppendText(Caminho);

                string key = "Criptografia"; //Está chave você mesmo é quem escolhe.
                Criptografia crip = new Criptografia(CryptProvider.DES);
                crip.Key = key;
                x.WriteLine(crip.Encrypt(txt_venc.Text));

                x.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro 3314: Sem Comunicação com a licenção ou acesso de permissão!", ">>>Sistema de Gestão Comercial<<<<<<<<<<<<", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Application.Exit();
                return;
            }
            #endregion

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "SIAV" && txtSenha.Text == "13052013")
            {
                panel1.Visible = true;
                
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
