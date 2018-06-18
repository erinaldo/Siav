using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class ComprasDAL
    {
         Contexto objD = null;

        public ComprasDAL()
        { }

        //inserção
        public int inserir(DateTime com_dataCompra, int com_usuario,int com_fornecedor, decimal com_quantidade, decimal com_valorTotal, String com_observacao,int com_numPedido)
        {
            SqlCommand cmd = null;
            try
            {
                int codigo = 0;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Compras" +
                    "(com_dataCompra, com_usuario, com_fornecedor, com_quantidade, com_valorTotal, com_observacao, com_status,com_numPedido)" +
                    " VALUES (@com_dataCompra, @com_usuario, @com_fornecedor, @com_quantidade, @com_valorTotal, @com_observacao, 'Ativo',@com_numPedido)";
                cmd.Parameters.Add(new SqlParameter("@com_dataCompra", SqlDbType.DateTime)).Value = com_dataCompra;
                cmd.Parameters.Add(new SqlParameter("@com_usuario", SqlDbType.Int)).Value = com_usuario;
                cmd.Parameters.Add(new SqlParameter("@com_fornecedor", SqlDbType.Int)).Value = com_fornecedor;
                //cmd.Parameters.Add(new SqlParameter("@com_formaPagamento", SqlDbType.Int)).Value = com_formaPagamento;
                cmd.Parameters.Add(new SqlParameter("@com_quantidade", SqlDbType.Int)).Value = com_quantidade;
                cmd.Parameters.Add(new SqlParameter("@com_valorTotal", SqlDbType.Decimal)).Value = com_valorTotal;
                if(com_observacao != null && com_observacao != "")
                    cmd.Parameters.Add(new SqlParameter("@com_observacao", SqlDbType.VarChar)).Value = com_observacao;
                else
                    cmd.Parameters.Add(new SqlParameter("@com_observacao", SqlDbType.VarChar)).Value = DBNull.Value;
                if(com_numPedido != 0)
                    cmd.Parameters.Add(new SqlParameter("@com_numPedido", SqlDbType.Int)).Value = com_numPedido;
                else
                    cmd.Parameters.Add(new SqlParameter("@com_numPedido", SqlDbType.Int)).Value = DBNull.Value;
                codigo = objD.ExecutaComandoInsert(cmd,"Compras");
                cmd = null;
                objD = null;
                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //alterar
        public void alterar(int com_codigo,DateTime com_dataCompra, int com_usuario,int com_fornecedor, decimal com_quantidade,
            decimal com_valorTotal, String com_observacao, String com_status, int com_numPedido)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Compras" +
                    " SET com_dataCompra=@com_dataCompra,com_usuario=@com_usuario," +
                    " com_fornecedor=@com_fornecedor," +
                    " com_quantidade=@com_quantidade,com_valorTotal=@com_valorTotal," +
                    " com_observacao=@com_observacao,com_status=@com_status" +
                    " WHERE" +
                    " com_codigo=@com_codigo";
                cmd.Parameters.Add(new SqlParameter("@com_codigo", SqlDbType.Int)).Value = com_codigo;
                cmd.Parameters.Add(new SqlParameter("@com_dataCompra", SqlDbType.DateTime)).Value = com_dataCompra;
                cmd.Parameters.Add(new SqlParameter("@com_usuario", SqlDbType.Int)).Value = com_usuario;
                cmd.Parameters.Add(new SqlParameter("@com_fornecedor", SqlDbType.Int)).Value = com_fornecedor;
                //cmd.Parameters.Add(new SqlParameter("@com_formaPagamento", SqlDbType.Int)).Value = com_formaPagamento;
                cmd.Parameters.Add(new SqlParameter("@com_quantidade", SqlDbType.Int)).Value = com_quantidade;
                cmd.Parameters.Add(new SqlParameter("@com_valorTotal", SqlDbType.Decimal)).Value = com_valorTotal;
                if (com_observacao != null && com_observacao != "")
                    cmd.Parameters.Add(new SqlParameter("@com_observacao", SqlDbType.VarChar)).Value = com_observacao;
                else
                    cmd.Parameters.Add(new SqlParameter("@com_observacao", SqlDbType.VarChar)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@com_status", SqlDbType.VarChar)).Value = com_status;
                if (com_numPedido != 0)
                    cmd.Parameters.Add(new SqlParameter("@com_numPedido", SqlDbType.Int)).Value = com_numPedido;
                else
                    cmd.Parameters.Add(new SqlParameter("@com_numPedido", SqlDbType.Int)).Value = DBNull.Value;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        //alterar
        public void alterar(int com_codigo,decimal com_valorTotal)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Compras" +
                    " SET com_valorTotal=@com_valorTotal"+                     
                    " WHERE" +
                    " com_codigo=@com_codigo";
                cmd.Parameters.Add(new SqlParameter("@com_codigo", SqlDbType.Int)).Value = com_codigo;                
                cmd.Parameters.Add(new SqlParameter("@com_valorTotal", SqlDbType.Decimal)).Value = com_valorTotal;                
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        //alterar
        public void cancelarCompra(int com_codigo,String com_status)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Compras" +
                    " SET com_status = @com_status" +
                    " WHERE" +
                    " com_codigo=@com_codigo";
                cmd.Parameters.Add(new SqlParameter("@com_codigo", SqlDbType.Int)).Value = com_codigo;
                cmd.Parameters.Add(new SqlParameter("@com_status", SqlDbType.VarChar)).Value = com_status;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int com_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Compras" +
                    " WHERE" +
                    " com_codigo=@com_codigo";
                cmd.Parameters.Add(new SqlParameter("@com_codigo", SqlDbType.Int)).Value = com_codigo;
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
                cmd.CommandText = "SELECT * FROM Compras" +
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
                cmd.CommandText = "SELECT * FROM Compras" +
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
                cmd.CommandText = "SELECT * FROM Compras" +
                    " WHERE com_codigo = @codigo";
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

                cmd.CommandText = "SELECT c.com_codigo 'Código da Compra',u.usu_nome 'Usuário', " +
                                    "c.com_dataCompra 'Data da Compra', cp.cp_quantidade 'Quantidade', c.com_valorTotal 'Valor Total',prod.pro_nome 'Descricao Produto' " +
                            "FROM	comprasProduto cp  " +
                            " Left Join Produtos prod on prod.pro_codigo = cp.cp_produtos " + 
                                    "RIGHT JOIN Compras c on cp.cp_compras = c.com_codigo " +
                                    "LEFT JOIN Usuario u on c.com_usuario = u.usu_codigo  " +
                                    "LEFT JOIN Fornecedores f on c.com_fornecedor = f.for_codigo " +
                            "WHERE  (c.com_codigo like @descricao or c.com_dataCompra like @descricao  " +
                                    "or c.com_quantidade like @descricao or c.com_valorTotal like @descricao  " +
                                    "or u.usu_nome like @descricao) and cp.cp_chegou is null";
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
                    cmd.CommandText = "SELECT com_codigo = max(com_codigo) FROM Compras";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT com_codigo = min(com_codigo) FROM Compras";
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
                    cmd.CommandText = "SELECT com_codigo FROM Compras WHERE com_codigo = (SELECT MIN(com_codigo) FROM Compras WHERE com_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT com_codigo FROM Compras WHERE com_codigo = (SELECT MAX(com_codigo) FROM Compras WHERE com_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
        public DataTable TotalizadorCompras(int codigo, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Totalizador_ComprasPorFornecedor"; //Procedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = codigo;
                    cmd.Parameters.Add(new SqlParameter("@DtInicial", SqlDbType.DateTime)).Value = dataInicial;
                    cmd.Parameters.Add(new SqlParameter("@DtFinal", SqlDbType.DateTime)).Value = dataFinal;
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
