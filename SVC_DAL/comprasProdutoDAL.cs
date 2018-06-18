using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class comprasProdutoDAL
    {
        Contexto objD = null;

        public comprasProdutoDAL()
        { }

        //inserção
        public void inserir(int cp_compras, int cp_produtos, decimal  cp_valorUnitario, decimal cp_quantidade,decimal  cp_subtotal)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO comprasProduto" +
                    " (cp_compras, cp_produtos, cp_valorUnitario, cp_quantidade, cp_subtotal)" +
                    " VALUES (@cp_compras, @cp_produtos, @cp_valorUnitario, @cp_quantidade, @cp_subtotal)";
                cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = cp_compras;
                cmd.Parameters.Add(new SqlParameter("@cp_produtos", SqlDbType.Int)).Value = cp_produtos;
                cmd.Parameters.Add(new SqlParameter("@cp_valorUnitario", SqlDbType.Decimal)).Value = cp_valorUnitario;
                cmd.Parameters.Add(new SqlParameter("@cp_quantidade", SqlDbType.Int)).Value = cp_quantidade;
                cmd.Parameters.Add(new SqlParameter("@cp_subtotal", SqlDbType.Decimal)).Value = cp_subtotal;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //inserção
        public void alterar(int cp_compras, int cp_produtos, decimal  cp_valorUnitario, decimal cp_quantidade, decimal  cp_subtotal, String cp_chegou)
        {
              SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE comprasProduto" +
                    " SET cp_valorUnitario=@cp_valorUnitario,"+
                    " cp_quantidade=@cp_quantidade, cp_subtotal=@cp_subtotal, cp_chegou=@cp_chegou" +
                    " WHERE" +
                    " cp_compras=@cp_compras and cp_produtos=@cp_produtos";
                cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = cp_compras;
                cmd.Parameters.Add(new SqlParameter("@cp_produtos", SqlDbType.Int)).Value = cp_produtos;
                cmd.Parameters.Add(new SqlParameter("@cp_valorUnitario", SqlDbType.Decimal)).Value = cp_valorUnitario;
                cmd.Parameters.Add(new SqlParameter("@cp_quantidade", SqlDbType.Int)).Value = cp_quantidade;
                cmd.Parameters.Add(new SqlParameter("@cp_subtotal", SqlDbType.Int)).Value = cp_subtotal;
                cmd.Parameters.Add(new SqlParameter("@cp_chegou", SqlDbType.VarChar)).Value = cp_chegou;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int cp_compras)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM comprasProduto" +
                    " WHERE" +
                    " cp_compras=@cp_compras";
                cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = cp_compras;                
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
                cmd.CommandText = "SELECT * FROM comprasProduto" +
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
                cmd.CommandText = "SELECT * FROM comprasProduto" +
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

        public DataTable localizarProdutoDaCompra(int codigoCompra, int codigoProduto)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM comprasProduto" +
                    " WHERE cp_compras = @cp_compras and cp_produtos = @cp_produtos";
                cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = codigoCompra;
                cmd.Parameters.Add(new SqlParameter("@cp_produtos", SqlDbType.Int)).Value = codigoProduto;
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
                cmd.CommandText = "SELECT * FROM comprasProduto" +
                    " WHERE cp_codigo = @codigo";
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

                cmd.CommandText = "SELECT TOP 100 * FROM comprasProduto" +
                    " WHERE cp_compras like @descricao or cp_produtos like @descricao or cp_produtos like @descricao";
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

    }
}
