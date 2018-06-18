using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{


    public class VersaoDAL
    {

        Contexto objD = null;

        public void inserir(Int32 id_versao, String versao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO versao" +
                    "(Id,codigo_versao, descricao_versao)" +
                    " VALUES (@Id,@codigo_versao,@descricao_versao)";

                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id_versao;
                cmd.Parameters.Add(new SqlParameter("@codigo_versao", SqlDbType.Int)).Value = id_versao;
                cmd.Parameters.Add(new SqlParameter("@descricao_versao", SqlDbType.VarChar)).Value = versao;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void roda_script_atualizacao(String script)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = script;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void delete()
        {
            SqlCommand cmd = null;
            try{

                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "delete from versao";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable localizar()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM versao";
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
