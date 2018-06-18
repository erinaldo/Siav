using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class LicencaDAL
    {
        Contexto objD = null;
    
         public LicencaDAL()
        { }

         //inserção
         public void inserir(String lic_chave, String lic_data)
         {
             SqlCommand cmd = null;
             try
             {
                 objD = new Contexto();
                 cmd = new SqlCommand();
                 cmd.CommandText = "INSERT INTO licenca" +
                     " (lic_data)" +
                     " VALUES (@lic_data)";
                 cmd.Parameters.Add(new SqlParameter("@lic_data", SqlDbType.Date)).Value = lic_data;
                 objD.ExecutaComando(cmd);
                 cmd = null;
                 objD = null;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         //selecionar várias linhas
         public DataTable localizar(String descricao, String coluna){

             DataTable tab = null;
             SqlCommand cmd = null;
             try{
                
                 objD = new Contexto();
                 cmd = new SqlCommand();
                 cmd.CommandText = "SELECT * FROM licenca";
                 tab = objD.ExecutaConsulta(cmd);
             
             }catch (Exception ex){
             
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
                 cmd.CommandText = "SELECT * FROM licenca" +
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

         public DataTable localizarLicenca(String descricao, String coluna)
         {
             DataTable tab = null;
             SqlCommand cmd = null;
             try
             {
                 objD = new Contexto();
                 cmd = new SqlCommand();
                 cmd.CommandText = "SELECT * FROM licenca";
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
                 cmd.CommandText = "SELECT * FROM licenca" +
                     " WHERE lic_codigo = @codigo";
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

         public void limpar_licencas()
         {
             SqlCommand cmd = null;

             try{

                 objD = new Contexto();
                 cmd = new SqlCommand();
                 cmd.CommandText = "delete from licenca";
      
                 objD.ExecutaComando(cmd);
                 
             }catch (Exception ex){
                 throw ex;
             }
         }


    }
}
