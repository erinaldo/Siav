using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class TelasDAL
    {
        Contexto objD = null;

        public TelasDAL()
        { }

        //inserção
        public void inserir(String descricao, int permissao,String ct_status,String ct_name)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO cadastroTelas" +
                    "(ct_nome, per_codigo,ct_status,ct_name)" +
                    " VALUES (@descricao, @permissao,@ct_status,@ct_name)";
                cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                cmd.Parameters.Add(new SqlParameter("@permissao", SqlDbType.Int)).Value = permissao;
                cmd.Parameters.Add(new SqlParameter("@ct_status", SqlDbType.VarChar)).Value = ct_status;
                cmd.Parameters.Add(new SqlParameter("@ct_name", SqlDbType.VarChar)).Value = ct_name;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void excluir(int per_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM cadastroTelas" +
                    " WHERE" +
                    " per_codigo=@per_codigo";
                cmd.Parameters.Add(new SqlParameter("@per_codigo", SqlDbType.Int)).Value = per_codigo;
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
                cmd.CommandText = "SELECT * FROM cadastroTelas" +
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

        

        //selecionar uma linha - um código
        public int localizar(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM cadastroTelas" +
                    " WHERE ct_nome like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao;
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

                cmd.CommandText = "SELECT TOP 100 * FROM cadastroTelas" +
                    " WHERE ct_nome like @descricao or per_codigo like @descricao or ct_status like @descricao or ct_name like @descricao";
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


        
    }
}
