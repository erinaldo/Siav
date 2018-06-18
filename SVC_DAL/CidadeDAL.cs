using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class CidadeDAL
    {
        Contexto objD = null;

        public CidadeDAL()
        { }

        //inserção
        public void inserir(String cid_nome, int cid_estado)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Cidade" +
                    "(cid_nome,cid_estado)" +
                    " VALUES (@cid_nome,@cid_estado)";
                cmd.Parameters.Add(new SqlParameter("@cid_nome", SqlDbType.VarChar)).Value = cid_nome;
                cmd.Parameters.Add(new SqlParameter("@cid_estado", SqlDbType.Int)).Value = cid_estado;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inserir_atualiza(Int32 cid_codigo ,String cid_nome, int cid_estado,Int32 cid_codigo_ibge)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Cidade" +
                    "(cid_nome,cid_estado,cid_codigo_IBGE)" +
                    " VALUES (@cid_nome,@cid_estado,@cid_codigo_IBGE)";
                cmd.Parameters.Add(new SqlParameter("@cid_nome", SqlDbType.VarChar)).Value = cid_nome;
                cmd.Parameters.Add(new SqlParameter("@cid_estado", SqlDbType.Int)).Value = cid_estado;
                cmd.Parameters.Add(new SqlParameter("@cid_codigo_IBGE", SqlDbType.VarChar)).Value = cid_codigo_ibge;
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
        public void alterar(int cid_codigo, String cid_nome, int cid_estado)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Cidade" +
                    " SET cid_nome=@cid_nome, cid_estado=@cid_estado" +
                    " WHERE" +
                    " cid_codigo=@cid_codigo";
                cmd.Parameters.Add(new SqlParameter("@cid_codigo", SqlDbType.Int)).Value = cid_codigo;
                cmd.Parameters.Add(new SqlParameter("@cid_nome", SqlDbType.VarChar)).Value = cid_nome;
                cmd.Parameters.Add(new SqlParameter("@cid_estado", SqlDbType.Int)).Value = cid_estado;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int cid_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Cidade" +
                    " WHERE" +
                    " cid_codigo=@cid_codigo";
                cmd.Parameters.Add(new SqlParameter("@cid_codigo", SqlDbType.Int)).Value = cid_codigo;
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
                cmd.CommandText = "SELECT * FROM Cidade" +
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
                cmd.CommandText = "SELECT * FROM Cidade" +
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
                cmd.CommandText = "SELECT * FROM Cidade" +
                    " WHERE cid_codigo = @codigo";
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

                cmd.CommandText = "SELECT TOP 100 c.cid_codigo, c.cid_nome, e.est_sigla, e.est_codigo FROM Cidade c inner join Estado e on e.est_codigo = c.cid_estado" +
                    " WHERE c.cid_codigo like @descricao or c.cid_nome like @descricao or e.est_sigla like @descricao";
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
                    cmd.CommandText = "SELECT cid_codigo = max(cid_codigo) FROM Cidade";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT cid_codigo = min(cid_codigo) FROM Cidade";
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
                    cmd.CommandText = "SELECT cid_codigo FROM Cidade WHERE cid_codigo = (SELECT MIN(cid_codigo) FROM Cidade WHERE cid_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT cid_codigo FROM Cidade WHERE cid_codigo = (SELECT MAX(cid_codigo) FROM Cidade WHERE cid_codigo < @codigo)"; ;

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
