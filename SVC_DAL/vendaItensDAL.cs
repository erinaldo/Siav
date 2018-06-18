using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class vendaItensDAL
    {
        Contexto objD = null;

        public vendaItensDAL()
        { }

        //inserção
        public void inserir(int ven_codigo, int pro_codigo, decimal vi_quantidade, Decimal vi_valorUnitario,Decimal vi_subtotal, Decimal vi_desconto, Decimal vi_percentual, int vi_mesGarantia,string vi_tara)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO vendaItens" +
                    " (ven_codigo, pro_codigo, vi_quantidade, vi_valorUnitario, vi_subtotal,vi_desconto,vi_percentual,vi_mesgarantia,vi_tara)" +
                    " VALUES (@ven_codigo, @pro_codigo, @vi_quantidade, @vi_valorUnitario, @vi_subtotal,@vi_desconto,@vi_percentual,@vi_mesGarantia,@vi_tara)";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = ven_codigo;
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = pro_codigo;
                cmd.Parameters.Add(new SqlParameter("@vi_quantidade", SqlDbType.Decimal)).Value = vi_quantidade;
                cmd.Parameters.Add(new SqlParameter("@vi_valorUnitario", SqlDbType.Decimal )).Value = vi_valorUnitario;
                cmd.Parameters.Add(new SqlParameter("@vi_subtotal", SqlDbType.Decimal )).Value = vi_subtotal;
                cmd.Parameters.Add(new SqlParameter("@vi_desconto", SqlDbType.Decimal )).Value = vi_desconto;
                cmd.Parameters.Add(new SqlParameter("@vi_percentual", SqlDbType.Decimal )).Value = vi_percentual;
                cmd.Parameters.Add(new SqlParameter("@vi_mesGarantia", SqlDbType.Int)).Value = vi_mesGarantia;
                cmd.Parameters.Add(new SqlParameter("@vi_tara", SqlDbType.VarChar)).Value = vi_tara;
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
        public void alterar(int ven_codigo, int pro_codigo, decimal vi_quantidade, 
            Decimal vi_valorUnitario, Decimal vi_subtotal, Decimal vi_desconto, Decimal vi_percentual, int vi_mesGarantia,string vi_tara)
        {
              SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE vendaItens" +
                    " SET vi_quantidade=@vi_quantidade,"+
                    " vi_valorUnitario=@vi_valorUnitario, vi_subtotal=@vi_subtotal,vi_desconto=@vi_desconto,"+
                    " vi_percentual=@vi_desconto,vi_mesgarantia=@vi_mesGarantia, vi_tara = @vi_tara" +
                    " WHERE" +
                    " ven_codigo=@ven_codigo and pro_codigo=@pro_codigo";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = ven_codigo;
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = pro_codigo;
                cmd.Parameters.Add(new SqlParameter("@vi_quantidade", SqlDbType.Decimal)).Value = vi_quantidade;
                cmd.Parameters.Add(new SqlParameter("@vi_valorUnitario", SqlDbType.Decimal )).Value = vi_valorUnitario;
                cmd.Parameters.Add(new SqlParameter("@vi_subtotal", SqlDbType.Decimal )).Value = vi_subtotal;
                cmd.Parameters.Add(new SqlParameter("@vi_desconto", SqlDbType.Decimal )).Value = vi_desconto;
                cmd.Parameters.Add(new SqlParameter("@vi_percentual", SqlDbType.Decimal )).Value = vi_percentual;
                cmd.Parameters.Add(new SqlParameter("@vi_mesGarantia", SqlDbType.Int)).Value = vi_mesGarantia;
                cmd.Parameters.Add(new SqlParameter("@vi_tara", SqlDbType.VarChar)).Value = vi_tara;
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

        public void excluir(int ven_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM vendaItens" +
                    " WHERE" +
                    " ven_codigo=@ven_codigo";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = ven_codigo;                
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
                cmd.CommandText = "SELECT * FROM vendaItens" +
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

        //selecionar várias linhas
        public DataTable localizarLeaveComRetorno(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM vendaItens" +
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
        public DataTable localizarLeaveID(int ID)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID=vi.ven_codigo,Produto = pro.pro_nome,Quantidade = vi_quantidade, Valor = vi.vi_valorunitario, SubTotal = vi.vi_subtotal FROM vendaItens vi " +
                    " join produtos pro on pro.pro_codigo = vi.pro_codigo"  +
                    " WHERE ven_codigo = @ID ";
                cmd.Parameters.Add(new SqlParameter("@ID",
                    SqlDbType.Int)).Value = ID;
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
                cmd.CommandText = "SELECT * FROM vendaItens" +
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

        public DataTable localizarProdutoDaCompra(int codigoVenda, int codigoProduto)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM vendaItens" +
                    " WHERE ven_codigo =@ven_codigo and pro_codigo = @pro_codigo";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = codigoVenda;
                cmd.Parameters.Add(new SqlParameter("@pro_codigo", SqlDbType.Int)).Value = codigoProduto;
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
                cmd.CommandText = "SELECT * FROM vendaItens" +
                    " WHERE ven_codigo = @codigo";
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

                cmd.CommandText = "SELECT TOP 100 * FROM vendaItens" +
                    " WHERE ven_codigo like @descricao or cp_produtos like @descricao or cp_produtos like @descricao";
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
