using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class FormaPagamentoDAL
    {
        Contexto objD = null;

        public FormaPagamentoDAL()
        {

        }

        //inserção
        public void inserir(String fp_descricao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO FormaPagamento (fp_descricao) VALUES (@fp_descricao)";
                cmd.Parameters.Add(new SqlParameter("@fp_descricao", SqlDbType.VarChar)).Value = fp_descricao;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void alterar(int fp_codigo, String fp_descricao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE FormaPagamento" +
                    " SET fp_descricao=@fp_descricao" +
                    " WHERE" +
                    " fp_codigo=@fp_codigo";
                cmd.Parameters.Add(new SqlParameter("@fp_codigo", SqlDbType.Int)).Value = fp_codigo;
                cmd.Parameters.Add(new SqlParameter("@fp_descricao", SqlDbType.VarChar)).Value = fp_descricao;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int fp_codigo)
        {

            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM FormaPagamento" +
                    " WHERE" +
                    " fp_codigo=@fp_codigo";
                cmd.Parameters.Add(new SqlParameter("@fp_codigo", SqlDbType.Int)).Value = fp_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception)
            {

                throw;
            }
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
                cmd.CommandText = "SELECT * FROM FormaPagamento" +
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
                cmd.CommandText = "SELECT * FROM FormaPagamento" +
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
                cmd.CommandText = "SELECT * FROM FormaPagamento" +
                    " WHERE fp_codigo = @codigo";
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

                cmd.CommandText = "SELECT TOP 100 * FROM FormaPagamento" +
                    " WHERE fp_codigo like @descricao or fp_descricao like @descricao";
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
                    cmd.CommandText = "SELECT fp_codigo = max(fp_codigo) FROM FormaPagamento";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT fp_codigo = min(fp_codigo) FROM FormaPagamento";
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
                    cmd.CommandText = "SELECT fp_codigo FROM FormaPagamento WHERE fp_codigo = (SELECT MIN(fp_codigo) FROM FormaPagamento WHERE fp_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT fp_codigo FROM FormaPagamento WHERE fp_codigo = (SELECT MAX(fp_codigo) FROM FormaPagamento WHERE fp_codigo < @codigo)"; ;

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
