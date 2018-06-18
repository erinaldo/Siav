using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class ContasAPagarDAL
    {
        Contexto objD = null;

        public ContasAPagarDAL()
        { }

        //inserção
        public void inserir(int cp_compras, String cp_titulo, String cp_serie, DateTime cp_emissao, DateTime cp_vencimento, decimal  cp_valor, String cp_status, String cp_observacao,int cp_fornecedor,DateTime? cp_dataPagamento,int TipoDeOperacaoID, int FormaDePagamentoID, int PrazoID)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ContasAPagar (cp_compras, cp_titulo, cp_serie, cp_emissao, cp_vencimento,cp_valor,cp_status,cp_observacao,cp_fornecedor,cp_dataPagamento,TipoDeOperacaoID, FormaDePagamentoID,Prazo)" +
                "VALUES(@cp_compras, @cp_titulo, @cp_serie, @cp_emissao, @cp_vencimento,@cp_valor,@cp_status,@cp_observacao,@cp_fornecedor,@cp_dataPagamento,@TipoDeOperacaoID, @FormaDePagamentoID,@Prazo)";
                if(cp_compras == 0)
                    cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = cp_compras;
                cmd.Parameters.Add(new SqlParameter("@cp_titulo", SqlDbType.VarChar)).Value = cp_titulo;
                cmd.Parameters.Add(new SqlParameter("@cp_serie", SqlDbType.VarChar)).Value = cp_serie;
                cmd.Parameters.Add(new SqlParameter("@cp_emissao", SqlDbType.Date)).Value = cp_emissao;
                cmd.Parameters.Add(new SqlParameter("@cp_vencimento", SqlDbType.Date)).Value = cp_vencimento;
                cmd.Parameters.Add(new SqlParameter("@cp_valor", SqlDbType.Decimal)).Value = cp_valor;
                cmd.Parameters.Add(new SqlParameter("@cp_status", SqlDbType.VarChar)).Value = cp_status;
                //cmd.Parameters.Add(new SqlParameter("@cp_observacao", SqlDbType.VarChar)).Value = cp_observacao;
                if (cp_observacao != null && cp_observacao != "")
                    cmd.Parameters.Add(new SqlParameter("@cp_observacao", SqlDbType.VarChar)).Value = cp_observacao;
                else
                    cmd.Parameters.Add(new SqlParameter("@cp_observacao", SqlDbType.VarChar)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@cp_fornecedor", SqlDbType.Int)).Value = cp_fornecedor;
                if (cp_dataPagamento == null)
                    cmd.Parameters.Add(new SqlParameter("@cp_dataPagamento", SqlDbType.Date)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@cp_dataPagamento", SqlDbType.Date)).Value = cp_dataPagamento;
                cmd.Parameters.Add(new SqlParameter("@TipoDeOperacaoID", SqlDbType.Int)).Value = TipoDeOperacaoID;
                cmd.Parameters.Add(new SqlParameter("@FormaDePagamentoID", SqlDbType.Int)).Value = FormaDePagamentoID;
                cmd.Parameters.Add(new SqlParameter("@Prazo", SqlDbType.Int)).Value = PrazoID;
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
        public void alterar(int cp_codigo, int cp_compras, String cp_titulo, String cp_serie, DateTime cp_emissao, DateTime cp_vencimento, decimal cp_valor, String cp_status, String cp_observacao, int cp_fornecedor, DateTime? cp_dataPagamento, int TipoDeOperacaoID, int FormaDePagamentoID, int PrazoID)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (cp_dataPagamento == null)
                    cmd.CommandText = "UPDATE ContasAPagar" +
                        " SET cp_compras=@cp_compras, cp_titulo=@cp_titulo,cp_serie=@cp_serie,cp_emissao=@cp_emissao,cp_vencimento=@cp_vencimento,cp_valor=@cp_valor, cp_status=@cp_status, cp_observacao=@cp_observacao,cp_fornecedor=@cp_fornecedor,cp_dataPagamento = null ,TipoDeOperacaoID = @TipoDeOperacaoID,FormaDePagamentoID =@FormaDePagamentoID,Prazo = @Prazo" +
                        " WHERE" +
                        " cp_codigo = @cp_codigo";
                else
                    cmd.CommandText = "UPDATE ContasAPagar" +
                        " SET cp_compras=@cp_compras, cp_titulo=@cp_titulo,cp_serie=@cp_serie,cp_emissao=@cp_emissao,cp_vencimento=@cp_vencimento,cp_valor=@cp_valor, cp_status=@cp_status, cp_observacao=@cp_observacao,cp_fornecedor=@cp_fornecedor,cp_dataPagamento = @cp_dataPagamento,TipoDeOperacaoID = @TipoDeOperacaoID,FormaDePagamentoID =@FormaDePagamentoID,Prazo = @Prazo" +
                        " WHERE" +
                        " cp_codigo = @cp_codigo";
                cmd.Parameters.Add(new SqlParameter("@cp_codigo", SqlDbType.Int)).Value = cp_codigo;
                if (cp_compras == 0)
                    cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@cp_compras", SqlDbType.Int)).Value = cp_compras;
                cmd.Parameters.Add(new SqlParameter("@cp_titulo", SqlDbType.VarChar)).Value = cp_titulo;
                cmd.Parameters.Add(new SqlParameter("@cp_serie", SqlDbType.VarChar)).Value = cp_serie;
                cmd.Parameters.Add(new SqlParameter("@cp_emissao", SqlDbType.Date)).Value = cp_emissao;
                cmd.Parameters.Add(new SqlParameter("@cp_vencimento", SqlDbType.Date)).Value = cp_vencimento;
                cmd.Parameters.Add(new SqlParameter("@cp_valor", SqlDbType.Decimal)).Value = cp_valor;
                cmd.Parameters.Add(new SqlParameter("@cp_status", SqlDbType.VarChar)).Value = cp_status;
                cmd.Parameters.Add(new SqlParameter("@cp_observacao", SqlDbType.VarChar)).Value = cp_observacao;
                cmd.Parameters.Add(new SqlParameter("@cp_fornecedor", SqlDbType.Int)).Value = cp_fornecedor;
                if (cp_dataPagamento == null)
                    cmd.Parameters.Add(new SqlParameter("@cp_dataPagamento", SqlDbType.Date)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@cp_dataPagamento", SqlDbType.Date)).Value = cp_dataPagamento;

                cmd.Parameters.Add(new SqlParameter("@TipoDeOperacaoID", SqlDbType.Int)).Value = TipoDeOperacaoID;
                cmd.Parameters.Add(new SqlParameter("@FormaDePagamentoID", SqlDbType.Int)).Value = FormaDePagamentoID;
                cmd.Parameters.Add(new SqlParameter("@Prazo", SqlDbType.Int)).Value = PrazoID;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int cp_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM ContasAPagar" +
                    " WHERE" +
                    " cp_codigo=@cp_codigo";
                cmd.Parameters.Add(new SqlParameter("@cat_codigo", SqlDbType.Int)).Value = cp_codigo;
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
                cmd.CommandText = "SELECT * FROM ContasAPagar" +
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
                cmd.CommandText = "SELECT * FROM ContasAPagar" +
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
                cmd.CommandText = "SELECT * FROM ContasAPagar" +
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

                cmd.CommandText = "SELECT TOP 100 cp.*,c.com_numPedido FROM Compras c INNER join  ContasAPagar cp on c.com_codigo = cp.cp_compras "+
					 "LEFT JOIN Fornecedores f on cp_fornecedor = for_codigo "+
                     "WHERE cp_codigo like @descricao or cp_compras like '7' or cp_titulo like @descricao or cp_serie like @descricao "+
                     "or cp_emissao like @descricao or cp_valor like @descricao or cp_status like @descricao " +
                     "or cp_observacao like @descricao or for_razaoSocial like @descricao or for_nome like @descricao "+
					 "or com_numPedido like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",SqlDbType.VarChar)).Value = "%" + descricao + "%";
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

        public DataTable localizarComFiltro(int codigo, DateTime? dataInicial, DateTime? dataFinal)
        {
           try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "ContasAPagarPerirodo"; //Procedure
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
                    cmd.CommandText = "SELECT cp_codigo = max(cp_codigo) FROM ContasAPagar";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT cp_codigo = min(cp_codigo) FROM ContasAPagar";
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
                    cmd.CommandText = "SELECT cp_codigo FROM ContasAPagar WHERE cp_codigo = (SELECT MIN(cp_codigo) FROM ContasAPagar WHERE cp_codigo > @codigo)";
                
                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT cp_codigo FROM ContasAPagar WHERE cp_codigo = (SELECT MAX(cp_codigo) FROM ContasAPagar WHERE cp_codigo < @codigo)"; ;
                    
                cmd.Parameters.Add(new SqlParameter("@codigo",SqlDbType.Int)).Value = codigo;

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

