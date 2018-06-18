using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class ConfiguracoesDAL
    {

        Contexto objD;

        public ConfiguracoesDAL() { 





        }

        public int inserir(String cnpj_sh, String codigo_vinculacao, String emp_tributos, String emp_reducao, String acbr_path)
        {

          SqlCommand cmd = null;
          try
          {
              int codigo;
              objD = new Contexto();
              cmd = new SqlCommand();
              cmd.CommandText = "INSERT INTO Configuracao" +
                  "(cnpj_sh,codigo_vinculacao,empresa_tributo,empresa_reducao,acbr_path)" +
                  " VALUES (@cnpj_sh,@codigo_vinculacao,@empresa_tributo,@empresa_reducao,@acbr_path)";
              
              cmd.Parameters.Add(new SqlParameter("@cnpj_sh", SqlDbType.VarChar)).Value = cnpj_sh;
              cmd.Parameters.Add(new SqlParameter("@codigo_vinculacao", SqlDbType.Decimal)).Value = codigo_vinculacao;
              cmd.Parameters.Add(new SqlParameter("@empresa_tributo", SqlDbType.Decimal)).Value = emp_tributos;
              cmd.Parameters.Add(new SqlParameter("@empresa_reducao", SqlDbType.Decimal)).Value = emp_reducao;
              cmd.Parameters.Add(new SqlParameter("@acbr_path", SqlDbType.VarChar)).Value = acbr_path;

              codigo = objD.ExecutaComandoInsert(cmd, "Configuracao");
          
              cmd = null;
              objD = null;
              return codigo;
          }
          catch (Exception ex)
          {
              throw ex;
          }

            return 0;
        }

        public int inserir2(String cnpj_sh, String codigo_vinculacao, String emp_tributos, String emp_reducao, String acbr_path)
        {

            SqlCommand cmd = null;
            try
            {
                int codigo;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "delete from configuracao; INSERT INTO Configuracao" +
                    "(cnpj_sh,codigo_vinculacao,empresa_tributo,empresa_reducao,acbr_path)" +
                    " VALUES (@cnpj_sh,@codigo_vinculacao,@empresa_tributo,@empresa_reducao,@acbr_path)";

                cmd.Parameters.Add(new SqlParameter("@cnpj_sh", SqlDbType.VarChar)).Value = cnpj_sh;
                cmd.Parameters.Add(new SqlParameter("@codigo_vinculacao", SqlDbType.Decimal)).Value = codigo_vinculacao;
                cmd.Parameters.Add(new SqlParameter("@empresa_tributo", SqlDbType.Decimal)).Value = emp_tributos;
                cmd.Parameters.Add(new SqlParameter("@empresa_reducao", SqlDbType.Decimal)).Value = emp_reducao;
                cmd.Parameters.Add(new SqlParameter("@acbr_path", SqlDbType.VarChar)).Value = acbr_path;

                codigo = objD.ExecutaComandoInsert(cmd, "Configuracao");

                cmd = null;
                objD = null;
                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return 0;
        }

        


        public DataTable localizar()
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {

                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM configuracao";
                tab = objD.ExecutaConsulta(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            cmd = null;
            objD = null;
            return tab;
        }


    }
}
