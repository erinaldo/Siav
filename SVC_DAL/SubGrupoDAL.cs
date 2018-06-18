using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace One.Dal
{
    public class SubGrupoDAL
    {
        Contexto objD = null;

        public SubGrupoDAL()
        {

        }

        //inserção
        public void inserir(String sg_descricao, int sg_grupo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO SubGrupo (sg_descricao,sg_grupo) VALUES (@sg_descricao,@sg_grupo)";
                cmd.Parameters.Add(new SqlParameter("@sg_descricao", SqlDbType.VarChar)).Value = sg_descricao;
                cmd.Parameters.Add(new SqlParameter("@sg_grupo", SqlDbType.Int)).Value = sg_grupo;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void alterar(int sg_codigo, String sg_descricao, int sg_grupo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE SubGrupo" +
                    " SET sg_descricao=@sg_descricao, sg_grupo = @sg_grupo" +
                    " WHERE" +
                    " sg_codigo=@sg_codigo";
                cmd.Parameters.Add(new SqlParameter("@sg_codigo", SqlDbType.Int)).Value = sg_codigo;
                cmd.Parameters.Add(new SqlParameter("@sg_descricao", SqlDbType.VarChar)).Value = sg_descricao;
                cmd.Parameters.Add(new SqlParameter("@sg_grupo", SqlDbType.Int)).Value = sg_grupo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int sg_codigo)
        {

            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM SubGrupo" +
                    " WHERE" +
                    " sg_codigo=@sg_codigo";
                cmd.Parameters.Add(new SqlParameter("@sg_codigo", SqlDbType.Int)).Value = sg_codigo;
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
                cmd.CommandText = "SELECT * FROM SubGrupo" +
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
                cmd.CommandText = "SELECT * FROM SubGrupo" +
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
                cmd.CommandText = "SELECT * FROM SubGrupo" +
                    " WHERE sg_codigo = @codigo";
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

                cmd.CommandText = "SELECT TOP 100 sg.sg_codigo,sg.sg_descricao,g.gru_descricao,g.gru_codigo FROM SubGrupo sg INNER JOIN Grupo g on sg.sg_grupo = g.gru_codigo"+
                    " where sg.sg_codigo like @descricao or sg.sg_descricao like @descricao or g.gru_descricao like @descricao";
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
                    cmd.CommandText = "SELECT sg_codigo = max(sg_codigo) FROM SubGrupo";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT sg_codigo = min(sg_codigo) FROM SubGrupo";
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
                    cmd.CommandText = "SELECT sg_codigo FROM SubGrupo WHERE sg_codigo = (SELECT MIN(sg_codigo) FROM SubGrupo WHERE sg_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT sg_codigo FROM SubGrupo WHERE sg_codigo = (SELECT MAX(sg_codigo) FROM SubGrupo WHERE sg_codigo < @codigo)"; ;

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
