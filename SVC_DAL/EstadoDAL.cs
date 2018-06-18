using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class EstadoDAL
    {
        Contexto objD = null;

        public EstadoDAL()
        {
        
        }

        //inserção
        public void inserir(String est_sigla,String est_nome)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Estado" +
                    "(est_sigla, est_nome)" +
                    " VALUES (@est_sigla,@est_nome)";
                cmd.Parameters.Add(new SqlParameter("@est_sigla", SqlDbType.VarChar)).Value = est_sigla;
                cmd.Parameters.Add(new SqlParameter("@est_nome", SqlDbType.VarChar)).Value = est_nome;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inserir_atualizando(Int32 codigo, String est_sigla, String est_nome, Int32 codigo_ibge)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Estado" +
                    "(est_sigla, est_nome,est_codigo_IBGE)" +
                    " VALUES (@est_sigla,@est_nome,@est_codigo_IBGE);";

                cmd.Parameters.Add(new SqlParameter("@est_sigla", SqlDbType.VarChar)).Value = est_sigla;
                cmd.Parameters.Add(new SqlParameter("@est_nome", SqlDbType.VarChar)).Value = est_nome;
                cmd.Parameters.Add(new SqlParameter("@est_codigo_IBGE", SqlDbType.VarChar)).Value = codigo_ibge;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //alterar
        public void alterar(int est_codigo, String est_sigla,String est_nome)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Estado" +
                    " SET est_sigla=@est_sigla, est_nome=@est_nome" +
                    " WHERE" +
                    " est_codigo=@est_codigo";
                cmd.Parameters.Add(new SqlParameter("@est_codigo", SqlDbType.Int)).Value = est_codigo;
                cmd.Parameters.Add(new SqlParameter("@est_sigla", SqlDbType.VarChar)).Value = est_sigla;
                cmd.Parameters.Add(new SqlParameter("@est_nome", SqlDbType.VarChar)).Value = est_nome;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int est_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Estado" +
                    " WHERE" +
                    " est_codigo=@est_codigo";
                cmd.Parameters.Add(new SqlParameter("@est_codigo", SqlDbType.Int)).Value = est_codigo;
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
                cmd.CommandText = "SELECT * FROM Estado" +
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
                cmd.CommandText = "SELECT * FROM Estado" +
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
                cmd.CommandText = "SELECT * FROM Estado" +
                    " WHERE est_codigo = @codigo";
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

        public DataTable localizarEmTudo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = "SELECT TOP 100 * FROM Estado" +
                    " WHERE est_codigo like @descricao or est_sigla like @descricao or est_nome like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = "%" + descricao + "%";

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

        public DataTable localizarPrimeiroUltimo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "ultimo")
                {
                    cmd.CommandText = "SELECT est_codigo = max(est_codigo) FROM Estado";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT est_codigo = min(est_codigo) FROM Estado";
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
                    cmd.CommandText = "SELECT est_codigo FROM Estado WHERE est_codigo = (SELECT MIN(est_codigo) FROM Estado WHERE est_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT est_codigo FROM Estado WHERE est_codigo = (SELECT MAX(est_codigo) FROM Estado WHERE est_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

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
