using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class FechamentoCaixaDAL
    {
        Contexto objD = null;

        public FechamentoCaixaDAL()
        { }

        //inserção
        public void inserir(int fin_usuario, DateTime fin_data, TimeSpan fin_hora, Decimal fin_valor, string caixa, int IDAber)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO fin_fechamento_caixa" +
                    "(fin_usuario, fin_data, fin_hora,fin_valor,fin_caixa,IDAber)" +
                    " VALUES (@fin_usuario, @fin_data, @fin_hora,@fin_valor,@fin_caixa,@IDAber)";
                cmd.Parameters.Add(new SqlParameter("@fin_usuario", SqlDbType.Int)).Value = fin_usuario;
                cmd.Parameters.Add(new SqlParameter("@fin_data", SqlDbType.DateTime)).Value = fin_data;
                cmd.Parameters.Add(new SqlParameter("@fin_hora", SqlDbType.Time)).Value = fin_hora;
                cmd.Parameters.Add(new SqlParameter("@fin_valor", SqlDbType.Decimal)).Value = fin_valor;
                cmd.Parameters.Add(new SqlParameter("@fin_caixa", SqlDbType.VarChar)).Value = caixa;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = IDAber;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //verifica se já houve fechamento do caixa no dia
        public DataTable jaFechou(int usuario, int IDAber)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select isnull(max(fin_codigo),0) from fin_fechamento_caixa where  fin_usuario =@Usuario and IDAber = @IDAber";
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = IDAber;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable jaFechouEAbriu(string Caixa)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select fin_codigo from fin_abertura_caixa where fin_dataAbertura = CONVERT(char(11),getdate(),113) and fin_caixa =" + Caixa;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable CaixaInicial()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "CaixaInicial"; //Procedure
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable FechamentoTotalDia()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "FechamentoTotalDia"; //Procedure
                cmd.CommandType = CommandType.StoredProcedure;
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
