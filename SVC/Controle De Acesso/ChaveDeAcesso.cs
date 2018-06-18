using GestaoComercial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One
{
    public partial class ChaveDeAcesso : Form
    {
        public ChaveDeAcesso()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 1 - o mês atual = now.Month.ToString()
                // 383 - codigo binario digitado manualmente por Me
                // 1 - numeracao de lojas
                // 6 - o ultimo digito do final da tada  -- Ano = now.Year.ToString().Substring(3, 1)
                // 2 - o ultimo numero do id da maquina --- IP = ip[1].ToString().Substring(ip[1].ToString().Length - 1, 1)
                // 6 - o dia atual -- Dia = now.Day.ToString()
                //********************************************


                DateTime now = DateTime.Now;
                int loja_num = 1;
                string licença = now.Month.ToString() + "383" + loja_num + now.Year.ToString().Substring(3, 1) + now.Day.ToString();
                double cript = Convert.ToDouble(licença) * Convert.ToDouble(33) - (30 * 396) + (61 * Convert.ToDouble(licença) * 261);
                string div = cript.ToString();
                string lic = div.Replace(",", "");
                string sub_liberacao = lic.Substring(lic.Length - 5);
                int chave_liberacao = (Convert.ToInt32(sub_liberacao.ToString()) * loja_num);
                string parte = chave_liberacao.ToString();
                if (Convert.ToInt32(parte.Length.ToString()) < 5)
                {
                    parte = chave_liberacao.ToString().PadLeft(5, '0');
                }

                if (textBox1.Text == parte.ToString().Substring(parte.ToString().Length - 5))
                {

                    string key = "Criptografia"; //Está chave você mesmo é quem escolhe.
                    Criptografia crip = new Criptografia(CryptProvider.DES);
                    crip.Key = key;
                    string stringSerFeitoReplace3 = Convert.ToDateTime(crip.Decrypt(File.ReadAllText(@"c:\one\hpostap.dll", System.Text.Encoding.UTF8))).ToString("dd/MM/yyyy");
                    var vencimento3 = stringSerFeitoReplace3.Replace(",", "/");
                    string data_ap = "05/" + vencimento3.Substring(3);
                    DateTime today = Convert.ToDateTime(data_ap);
                    DateTime answe = today.AddMonths(1);


                    #region Data do Vencimento
                    try
                    {
                        StreamWriter x;
                        //Colocando o endereço físico (caminho do arquivo texto) 
                        string Caminho = @"c:\one\host.dll";
                        File.Delete(Caminho);
                        //usando o metodo e abrindo o arquivo texto
                        x = File.AppendText(Caminho);

                        #region Criptografia Data do Vencimento

                        x.WriteLine(crip.Encrypt(answe.ToString("dd/MM/yyyy")));

                        string teste = crip.Encrypt(answe.ToString("dd/MM/yyyy"));
                       

                        #endregion

                        x.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro 3314: Sem Comunicação com a licença.");
                        return;
                    }
                    #endregion

                    MessageBox.Show("Aplicativo Liberado");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Número de Serie invalido!!!");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
        }
    }
}
