using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class Acbr
    {

        public void configura_acbr(String cnpj, String ie, String im, String codigo_vinculacao)
        {

            System.IO.StreamReader arquivo = File.OpenText(@"C:\ACBrMonitorPLUS\ACBrMonitor.ini");
            System.IO.StreamWriter novoArquivo = File.CreateText(@"C:\ACBrMonitorPLUS\ACBrMonitorx.ini");
            string depura = "";
            string linha = "";

            Boolean flag = false; //flag para quando o arquivo chegou na parte do sat
            Boolean flag_monitor = false;
            Boolean flag_emitente = false; // Flag para quando chegar no arquivo de configuração do emitente
            Boolean flag_software_house = false;
            Boolean flag_impressao = false;

            //Cria os diretórios
            if (!Directory.Exists(@"C:\Rede_Sistema"))
                Directory.CreateDirectory(@"C:\Rede_Sistema");

            while ((linha = arquivo.ReadLine()) != null)
            {
                if (linha.Trim() == "[ACBrMonitor]")
                    flag_monitor = true;

                if (linha.Trim() == "[SAT]")
                    flag = true;

                if (linha.Trim() == "[SATEmit]")
                    flag_emitente = true;

                if (linha.Trim() == "[SATSwH]")
                    flag_software_house = true;

                if (linha.Trim() == "[SATFortes]")
                    flag_impressao = true;

                if (flag_monitor)
                {
                    if (linha.Split('=')[0].ToString() == "TXT_Entrada")
                        linha = "TXT_Entrada = C:/Rede_Sistema/ent.txt";

                    if (linha.Split('=')[0].ToString() == "TXT_Saida")
                    {
                        linha = "TXT_Saida = C:/Rede_Sistema/sai.txt";
                        flag_monitor = false;
                    }

                }


                if (flag){

                    if (linha.Split('=')[0].ToString() == "CodigoAtivacao")
                    {
                        linha = "CodigoAtivacao = 123";
                        flag = false;
                    }
                }

                if (flag_emitente){

                    if (linha.Split('=')[0].ToString() == "CNPJ")
                        linha = "CNPJ = " + cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "");

                    if (linha.Split('=')[0].ToString() == "IE")
                        linha = "IE = " + ie.Replace(".", "");

                    if (linha.Split('=')[0].ToString() == "IM"){
                        linha = "IM = " + im;
                        flag_emitente = false;
                    }
                }

                if (flag_software_house){

                    if (linha.Split('=')[0].ToString() == "CNPJ")
                        linha = "CNPJ = 11444406000180";

                    if (linha.Split('=')[0].ToString() == "Assinatura"){
                        linha = "Assinatura = " + codigo_vinculacao;
                        flag_software_house = false;
                    }
                }


                if (flag_impressao){
                    if (linha.Split('=')[0].ToString() == "Largura")
                    {
                        linha = "Largura = 280";
                        flag_impressao = false;
                    }

                }                
                novoArquivo.WriteLine(linha);
            }

            arquivo.Close();
            novoArquivo.Dispose();
            novoArquivo.Close();
            File.Replace(@"C:\ACBrMonitorPLUS\ACBrMonitorx.ini", @"C:\ACBrMonitorPLUS\ACBrMonitor.ini", @"C:\ACBrMonitorPLUS\ACBrMonitorbkp.ini");
        }

    }
}
