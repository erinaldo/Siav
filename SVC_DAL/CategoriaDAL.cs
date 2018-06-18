using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class CentroDeCustoDAL
    {

        Contexto objD = null;

        public CentroDeCustoDAL()
        { }

        //inserção
        public void InserirCentroDeCusto(String ccs_descricao)
        {
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = string.Concat("INSERT INTO CentroDeCusto (ccs_descricao) ",
                                                "VALUES (@ccs_descricao)");

                cmd.Parameters.Add(new SqlParameter("@ccs_descricao", SqlDbType.VarChar)).Value = ccs_descricao;

                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                cmd = null;
                objD = null;
                throw ex;
            }
            finally 
            {
                cmd = null;
                objD = null;
            }
        }

        //alterar
        public void alterar(int ccs_codigo, String ccs_descricao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE CentroDeCusto" +
                    " SET ccs_descricao=@ccs_descricao" +
                    " WHERE" +
                    " ccs_codigo=@ccs_codigo";
                cmd.Parameters.Add(new SqlParameter("@ccs_codigo", SqlDbType.Int)).Value = ccs_codigo;
                cmd.Parameters.Add(new SqlParameter("@ccs_descricao", SqlDbType.VarChar)).Value = ccs_descricao;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int ccs_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM CentroDeCusto" +
                    " WHERE" +
                    " ccs_codigo=@ccs_codigo";
                cmd.Parameters.Add(new SqlParameter("@ccs_codigo", SqlDbType.Int)).Value = ccs_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        //selecionar várias linhas
        public DataTable localizar(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM CentroDeCusto" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao + "%";
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

        public DataTable localizarLeave(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM CentroDeCusto" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao;
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

        //selecionar uma linha - um código
        public int localizar(int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM CentroDeCusto" +
                    " WHERE ccs_codigo = @codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo",
                    SqlDbType.Int)).Value = codigo;
                tab = objD.ExecutaConsulta(cmd);
                cmd = null;
                objD = null;
                if (tab.Rows.Count > 0)
                    return int.Parse(tab.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public DataTable LocalizarEmTudo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = string.Concat("SELECT TOP 100 * FROM CentroDeCusto ",
                                                "WHERE ccs_codigo like @descricao or ccs_descricao like @descricao");

                cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = "%" + descricao + "%";

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                cmd = null;
                objD = null;
                throw ex;
            }
            finally
            {
                cmd = null;
                objD = null;
            }

            return tab;
        }


        public DataTable LocalizarPrimeiroUltimo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "ultimo")
                {
                    cmd.CommandText = "SELECT ccs_codigo = max(ccs_codigo) FROM CentroDeCusto";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT ccs_codigo = min(ccs_codigo) FROM CentroDeCusto";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                     SqlDbType.VarChar)).Value = descricao;
                }
                tab = objD.ExecutaConsulta(cmd);

            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable localizarProxAnterior(String descricao, int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "proximo")
                    cmd.CommandText = "SELECT ccs_codigo FROM CentroDeCusto WHERE ccs_codigo = (SELECT MIN(ccs_codigo) FROM CentroDeCusto WHERE ccs_codigo > @codigo)";
                
                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT ccs_codigo FROM CentroDeCusto WHERE ccs_codigo = (SELECT MAX(ccs_codigo) FROM CentroDeCusto WHERE ccs_codigo < @codigo)"; ;
                    
                cmd.Parameters.Add(new SqlParameter("@codigo",SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
            return tab;
        }
    }
}
