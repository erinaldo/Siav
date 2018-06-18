using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace One.Loja
{
    public class Lancamento
    {
        Contexto con = null;

        public void Inserir(DateTime Data, int TipoDeOperacao, string Detalhe, string Sinal, Decimal Valor, int DocID)
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat(
                                "Insert Lancamentos ",
                                         "  (Data ",
                                         "  ,TipoDeOperacao",
                                         "  ,Detalhe",
                                         "  ,Sinal",
                                         "  ,Valor,DocID) Values (",
                                           " @Data ",
                                         "  ,@TipoDeOperacao",
                                         "  ,@Detalhe",
                                         "  ,@Sinal",
                                         "  ,@Valor,@DocID)");
                cmd.Parameters.Add(new SqlParameter("@Data", SqlDbType.DateTime)).Value = Data;
                cmd.Parameters.Add(new SqlParameter("@TipoDeOperacao", SqlDbType.Int)).Value = TipoDeOperacao;
                cmd.Parameters.Add(new SqlParameter("@Detalhe", SqlDbType.VarChar)).Value = Detalhe;
                cmd.Parameters.Add(new SqlParameter("@Sinal", SqlDbType.VarChar)).Value = Sinal;
                cmd.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = Valor;
                cmd.Parameters.Add(new SqlParameter("@DocID", SqlDbType.Int)).Value = DocID;
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Excluir(int DocID)
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat(
                                "delete lancamentos where DocID = @DocID");
                cmd.Parameters.Add(new SqlParameter("@DocID", SqlDbType.Int)).Value = DocID;
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Consultar(DateTime? dtInicial, DateTime? dtFinal)
        {
            try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Lancamento"; //Procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@DtInicial", SqlDbType.DateTime)).Value = dtInicial;
                    cmd.Parameters.Add(new SqlParameter("@DtFinal", SqlDbType.DateTime)).Value = dtFinal;
                    DataTable tab = contexto.ExecutaConsulta(cmd);
                    return tab;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
