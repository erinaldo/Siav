using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class CategoriaDAL
    {

        Contexto objD = null;

        public CategoriaDAL()
        { }

        //inserção
        public void InserirCategoria(String cat_descricao)
        {
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = string.Concat("INSERT INTO Categoria (cat_descricao) ",
                                                "VALUES (@cat_descricao)");

                cmd.Parameters.Add(new SqlParameter("@cat_descricao", SqlDbType.VarChar)).Value = cat_descricao;

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
        public void alterar(int cat_codigo, String cat_descricao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Categoria" +
                    " SET cat_descricao=@cat_descricao" +
                    " WHERE" +
                    " cat_codigo=@cat_codigo";
                cmd.Parameters.Add(new SqlParameter("@cat_codigo", SqlDbType.Int)).Value = cat_codigo;
                cmd.Parameters.Add(new SqlParameter("@cat_descricao", SqlDbType.VarChar)).Value = cat_descricao;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int cat_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Categoria" +
                    " WHERE" +
                    " cat_codigo=@cat_codigo";
                cmd.Parameters.Add(new SqlParameter("@cat_codigo", SqlDbType.Int)).Value = cat_codigo;
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
                cmd.CommandText = "SELECT * FROM Categoria" +
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
                cmd.CommandText = "SELECT * FROM Categoria" +
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
                cmd.CommandText = "SELECT * FROM Categoria" +
                    " WHERE cat_codigo = @codigo";
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

                cmd.CommandText = string.Concat("SELECT TOP 100 * FROM Categoria ",
                                                "WHERE cat_codigo like @descricao or cat_descricao like @descricao");

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
                    cmd.CommandText = "SELECT cat_codigo = max(cat_codigo) FROM Categoria";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT cat_codigo = min(cat_codigo) FROM Categoria";
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
                    cmd.CommandText = "SELECT cat_codigo FROM Categoria WHERE cat_codigo = (SELECT MIN(cat_codigo) FROM Categoria WHERE cat_codigo > @codigo)";
                
                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT cat_codigo FROM Categoria WHERE cat_codigo = (SELECT MAX(cat_codigo) FROM Categoria WHERE cat_codigo < @codigo)"; ;
                    
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
