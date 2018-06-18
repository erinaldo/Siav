using System;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace MGMPDV
{
    class CSat
    {

        string caminhoMonitorEntrada = @"C:\Rede_Sistema\ENT.txt";
        string caminhoMonitorSaida = @"C:\Rede_Sistema\SAI.txt";
        public string hora { get; set; }
        public string data { get; set; }
        public CSat() { }


        public int lerSleep(){

            int valor = 0;
            try{
                valor = int.Parse(Application.StartupPath + @"\Sleep.txt");
            }catch { MessageBox.Show("Erro com arquivo Sleep"); valor = 0; }
            return valor;
        }

        public string Inicializar()
        {
            string text = "SAT.Inicializar";
            // WriteAllText creates a file, writes the specified string to the file, 
            // and then closes the file.
            File.WriteAllText(caminhoMonitorEntrada, text);
            System.Threading.Thread.Sleep(lerSleep());
            string[] str = File.ReadAllLines(caminhoMonitorSaida);

            return str[str.Length-1];
        }

        public string enviarCFe(){
            //tring text = @""
            return "";
        }


        public Boolean emitirSAT(){

            Boolean status = false;
            Inicializar();





            return status;
               
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
                string[] lines = File.ReadAllLines(caminhoMonitorSaida);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(chave + "="))
                    {
                        retorno = lines[i].Substring(chave.Length + 1);
                    }
                }
            }
            catch { retorno = "Erro Monitor"; }

            return retorno;
        }

      
        
      
    }
}
