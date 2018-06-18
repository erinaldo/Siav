using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class PagamentoDiaDAL
    {
        Contexto objD = null;

        public PagamentoDiaDAL()
        { }

        //inserção
        public void inserir(int cr_codigo, Decimal pd_valor, DateTime pd_data)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO PagamentoDia" +
                    "(cr_codigo,pd_valor,pd_data)" +
                    " VALUES (@cr_codigo,@pd_valor,@pd_data)";
                cmd.Parameters.Add(new SqlParameter("@cr_codigo", SqlDbType.Int)).Value = cr_codigo;
                cmd.Parameters.Add(new SqlParameter("@pd_valor", SqlDbType.Decimal)).Value = pd_valor;
                cmd.Parameters.Add(new SqlParameter("@pd_data", SqlDbType.DateTime)).Value = pd_data;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
