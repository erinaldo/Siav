using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class CodigoBarraDAL
    {
        Contexto objD = null;

          public CodigoBarraDAL()
        { }

          //inserção
          public void inserir(String pro_codigoBarra, Decimal pro_precoVenda, String pro_nome)
          {
              SqlCommand cmd = null;
              try
              {
                  objD = new Contexto();
                  cmd = new SqlCommand();
                  cmd.CommandText = "INSERT INTO codigoBarra" +
                      "(pro_codigoBarra, pro_precoVenda,pro_nome)" +
                      " VALUES (@pro_codigoBarra, @pro_precoVenda,@pro_nome)";
                  cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = pro_codigoBarra;
                  cmd.Parameters.Add(new SqlParameter("@pro_precoVenda", SqlDbType.Float)).Value = pro_precoVenda;
                  cmd.Parameters.Add(new SqlParameter("@pro_nome", SqlDbType.VarChar)).Value = pro_nome;
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
          public void alterar(String pro_codigoBarra, Decimal pro_precoVenda, String pro_nome)
          {
              SqlCommand cmd = null;
              try
              {
                  objD = new Contexto();
                  cmd = new SqlCommand();
                  cmd.CommandText = "UPDATE codigoBarra" +
                      " SET pro_precoVenda=@pro_precoVenda,pro_nome=@pro_nome" +
                      " WHERE" +
                      " pro_codigoBarra=@pro_codigoBarra";
                  cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = pro_codigoBarra;
                  cmd.Parameters.Add(new SqlParameter("@pro_precoVenda", SqlDbType.Float)).Value = pro_precoVenda;
                  cmd.Parameters.Add(new SqlParameter("@pro_nome", SqlDbType.VarChar)).Value = pro_nome;
                  objD.ExecutaComando(cmd);
              }
              catch (Exception ex)
              {

                  throw ex;
              }
              cmd = null;
              objD = null;
          }

          public void excluir(String pro_codigoBarra)
          {
              SqlCommand cmd = null;
              try
              {
                  objD = new Contexto();
                  cmd = new SqlCommand();
                  cmd.CommandText = "DELETE FROM codigoBarra" +
                      " WHERE" +
                      " pro_codigoBarra=@pro_codigoBarra";
                  cmd.Parameters.Add(new SqlParameter("@pro_codigoBarra", SqlDbType.VarChar)).Value = pro_codigoBarra;
                  objD.ExecutaComando(cmd);
              }
              catch (Exception ex)
              {
                  throw ex;
              }
              cmd = null;
              objD = null;
          }

          ////selecionar várias linhas
          //public DataTable localizar(String descricao, String coluna)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;
          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();
          //        cmd.CommandText = "SELECT * FROM codigoBarra" +
          //            " WHERE " + coluna + " like @descricao";
          //        cmd.Parameters.Add(new SqlParameter("@descricao",
          //            SqlDbType.VarChar)).Value = descricao + "%";
          //        tab = objD.ExecutaConsulta(cmd);
          //    }
          //    catch (Exception ex)
          //    {
          //        throw ex;
          //    }
          //    cmd = null;
          //    objD = null;
          //    return tab;
          //}

          //public DataTable localizarLeave(String descricao, String coluna)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;
          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();
          //        cmd.CommandText = "SELECT * FROM codigoBarra" +
          //            " WHERE " + coluna + " like @descricao";
          //        cmd.Parameters.Add(new SqlParameter("@descricao",
          //            SqlDbType.VarChar)).Value = descricao;
          //        tab = objD.ExecutaConsulta(cmd);
          //    }
          //    catch (Exception ex)
          //    {
          //        throw ex;
          //    }
          //    cmd = null;
          //    objD = null;
          //    return tab;
          //}

          ////selecionar uma linha - um código
          //public int localizar(int codigo)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;

          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();
          //        cmd.CommandText = "SELECT * FROM codigoBarra" +
          //            " WHERE cb_codigo = @codigo";
          //        cmd.Parameters.Add(new SqlParameter("@codigo",
          //            SqlDbType.Int)).Value = codigo;
          //        tab = objD.ExecutaConsulta(cmd);
          //        cmd = null;
          //        objD = null;
          //        if (tab.Rows.Count > 0)
          //            return int.Parse(tab.Rows[0][0].ToString());
          //        else
          //            return 0;
          //    }
          //    catch (Exception ex)
          //    {
          //        throw ex;
          //    }
          //}

          //public DataTable localizarEmTudo(String descricao)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;
          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();

          //        cmd.CommandText = "SELECT TOP 100 * FROM codigoBarra" +
          //            " WHERE cb_codigo like @descricao or cb_codigoBarra like @descricao or cb_numeroLote like @descricao"+
          //            " or cb_dataCriacao like @descricao";
          //        cmd.Parameters.Add(new SqlParameter("@descricao",
          //            SqlDbType.VarChar)).Value = "%" + descricao + "%";

          //        tab = objD.ExecutaConsulta(cmd);
          //    }
          //    catch (Exception ex)
          //    {
          //        throw ex;
          //    }
          //    cmd = null;
          //    objD = null;
          //    return tab;
          //}

          //public DataTable localizarPrimeiroUltimo(String descricao)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;

          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();
          //        if (descricao == "ultimo")
          //        {
          //            cmd.CommandText = "SELECT cb_codigo = max(cb_codigo) FROM codigoBarra";
          //            cmd.Parameters.Add(new SqlParameter("@descricao",
          //                 SqlDbType.VarChar)).Value = descricao;
          //        }
          //        else if (descricao == "primeiro")
          //        {
          //            cmd.CommandText = "SELECT cb_codigo = min(cb_codigo) FROM codigoBarra";
          //            cmd.Parameters.Add(new SqlParameter("@descricao",
          //             SqlDbType.VarChar)).Value = descricao;
          //        }
          //        tab = objD.ExecutaConsulta(cmd);

          //    }
          //    catch (Exception)
          //    {

          //        throw;
          //    }
          //    return tab;
          //}

          //public DataTable localizarProxAnterior(String descricao, int codigo)
          //{
          //    DataTable tab = null;
          //    SqlCommand cmd = null;

          //    try
          //    {
          //        objD = new Dados();
          //        cmd = new SqlCommand();
          //        if (descricao == "proximo")
          //            cmd.CommandText = "SELECT cb_codigo FROM codigoBarra WHERE cb_codigo = (SELECT MIN(cb_codigo) FROM codigoBarra WHERE cb_codigo > @codigo)";

          //        else if (descricao == "anterior")
          //            cmd.CommandText = "SELECT cb_codigo FROM codigoBarra WHERE cb_codigo = (SELECT MAX(cb_codigo) FROM codigoBarra WHERE cb_codigo < @codigo)"; ;

          //        cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

          //        tab = objD.ExecutaConsulta(cmd);
          //    }
          //    catch (Exception)
          //    {

          //        throw;
          //    }
          //    return tab;
          //}


    }
}
