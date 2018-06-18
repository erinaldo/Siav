using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace One.Bll
{
    public class UtilBll
    {
        public static bool VerificaCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string SoNumero;

                SoNumero = Regex.Replace(cpf, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

                // se a quantidade de dígitos numérios for igual a 11
                // iremos verificar como CPF
                if (SoNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }
                else
                    return false;
            }
        }

        public static bool VerificaCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string Sequencia, SoNumero;

                SoNumero = Regex.Replace(cnpj, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
                if (SoNumero.Length == 14)
                {
                    Sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }
                // CPF ou CNPJ inválido se
                // a quantidade de dígitos numérios for diferente de 11 e 14
                else return false;
            }
        }

        public static EnderecoByJG ObterEnderecoPorCEPAutomatico(string cep, out string erro)
        {
            EnderecoByJG enderecoByJG = new EnderecoByJG();
            erro = string.Empty;

            try
            {
                string usuario = ConfigurationManager.AppSettings["LoginByJG"];
                string senha = ConfigurationManager.AppSettings["PassByJG"];

                SVC_BLL.WsByJG.CEPService wsByJG = new SVC_BLL.WsByJG.CEPService();

                string[] retornoEndereco = wsByJG.obterLogradouroAuth(cep, usuario, senha).Split(',');

                if (retornoEndereco.Length >= 4)
                {
                    enderecoByJG.Cep = cep;
                    enderecoByJG.Logradouro = retornoEndereco[0].Split('-')[0];
                    enderecoByJG.Bairro = retornoEndereco[1];
                    enderecoByJG.Cidade = retornoEndereco[2];
                    enderecoByJG.Estado = retornoEndereco[3];
                }
                else
                {
                    erro = retornoEndereco[0];
                }
            }
            catch (Exception ex)
            {
                erro = "Ocorreu um erro ao tentar obter o endereço a partir do cep.\r\nDetalhes do erro: " + ex.Message;
            } 

            return enderecoByJG;
        }

        public struct EnderecoByJG
        {
            public string Cep { get; set; }
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
        }
    }
}
