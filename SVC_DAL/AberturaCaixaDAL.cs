using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
   public class AberturaCaixaDAL
    {
         Contexto objD = null;

         public AberturaCaixaDAL()
        { }

         //inserção
         public void inserir(int fin_usuario, DateTime fin_dataAbertura,TimeSpan fin_horaAbertura, Decimal fin_valorInicial, string caixa )
         {
             SqlCommand cmd = null;
             try
             {
                 objD = new Contexto();
                 cmd = new SqlCommand();
                 cmd.CommandText = "INSERT INTO fin_abertura_caixa" +
                     "(fin_usuario, fin_dataAbertura, fin_horaAbertura,fin_valorInicial,fin_caixa)" +
                     " VALUES (@fin_usuario, @fin_dataAbertura, @fin_horaAbertura,@fin_valorInicial,@fin_caixa)";
                 cmd.Parameters.Add(new SqlParameter("@fin_usuario", SqlDbType.Int)).Value = fin_usuario;
                 cmd.Parameters.Add(new SqlParameter("@fin_dataAbertura", SqlDbType.DateTime)).Value = fin_dataAbertura;
                 cmd.Parameters.Add(new SqlParameter("@fin_horaAbertura", SqlDbType.Time)).Value = fin_horaAbertura;
                 cmd.Parameters.Add(new SqlParameter("@fin_valorInicial", SqlDbType.Float)).Value = fin_valorInicial;
                 cmd.Parameters.Add(new SqlParameter("@fin_caixa", SqlDbType.VarChar)).Value = caixa;
                 objD.ExecutaComando(cmd);
                 cmd = null;
                 objD = null;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

        //verifica se é a primeira vez que está logando no sistema
        public DataTable isPrimeiraVez(int usuario)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select max(fin_codigo) from fin_abertura_caixa where fin_usuario =@usuario";
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.Int)).Value = usuario;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        //verifica se é a primeira vez que está logando no sistema no dia
        public DataTable isPrimeiraVezDia(int usuario)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select isnull(max(fin_codigo),0) from fin_abertura_caixa where  fechou = null  and fin_usuario = " + usuario;
              //  cmd.CommandText = "select max(fin_codigo) from fin_abertura_caixa where  fin_usuario ="+ usuario+ "and Fechou is null";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
        public DataTable isPrimeiraVezFechou(int usuario)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select top 1 fechou from fin_abertura_caixa where  fin_usuario = " + usuario +" Order by fin_codigo desc";
                //  cmd.CommandText = "select max(fin_codigo) from fin_abertura_caixa where  fin_usuario ="+ usuario+ "and Fechou is null";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable DiaAnterior(DateTime data)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select fin_valorInicial from fin_abertura_caixa where fin_dataAbertura = " + data;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable PrimeiroDia()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select top 1 fin_valorInicial from fin_abertura_caixa";
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
