using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class ContasAReceberDAL
    {
        Contexto objD = null;

        public ContasAReceberDAL()
        { }

        //inserção
        public int inserir(int venda, DateTime vencimento, int formaPagamento, Decimal original, Decimal alterado, Decimal pago, String status, DateTime? pagamento,
            Decimal juros, Decimal desconto, String observacao, String parcela, Decimal? cr_valorRestante, Decimal? cr_multa)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ContasAReceber (cr_vendas, cr_dataVencimento, cr_formaPagamento, cr_valorOriginal, cr_valorAlterado,"+
                " cr_valorPago, cr_status, cr_dataPagamento, cr_juros, cr_desconto, cr_observacao, cr_parcela,cr_valorRestante, cr_multa)" +
                " VALUES(@venda, @vencimento, @formaPagamento, @original, @alterado, @pago, @status, @pagamento, @juros, @desconto, @observacao," +
                " @parcela,@cr_valorRestante,@cr_multa)";
                cmd.Parameters.Add(new SqlParameter("@venda", SqlDbType.Int)).Value = venda;
                cmd.Parameters.Add(new SqlParameter("@vencimento", SqlDbType.DateTime)).Value = vencimento;
                cmd.Parameters.Add(new SqlParameter("@formaPagamento", SqlDbType.Int)).Value = formaPagamento;
                cmd.Parameters.Add(new SqlParameter("@original", SqlDbType.Decimal)).Value = original;
                cmd.Parameters.Add(new SqlParameter("@alterado", SqlDbType.Decimal)).Value = alterado;
                cmd.Parameters.Add(new SqlParameter("@pago", SqlDbType.Decimal)).Value = pago;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = status;
                if(pagamento != null)
                cmd.Parameters.Add(new SqlParameter("@pagamento", SqlDbType.DateTime)).Value = pagamento;
                else
                    cmd.Parameters.Add(new SqlParameter("@pagamento", SqlDbType.DateTime)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@juros", SqlDbType.Decimal)).Value = juros;
                cmd.Parameters.Add(new SqlParameter("@desconto", SqlDbType.Decimal)).Value = desconto;
                cmd.Parameters.Add(new SqlParameter("@observacao", SqlDbType.VarChar)).Value = observacao;
                cmd.Parameters.Add(new SqlParameter("@parcela", SqlDbType.VarChar)).Value = parcela;
                if (cr_valorRestante != null)
                    cmd.Parameters.Add(new SqlParameter("@cr_valorRestante", SqlDbType.Decimal)).Value = cr_valorRestante;
                else
                    cmd.Parameters.Add(new SqlParameter("@cr_valorRestante", SqlDbType.Decimal)).Value = DBNull.Value;
                if (cr_multa!= null)
                    cmd.Parameters.Add(new SqlParameter("@cr_multa", SqlDbType.Decimal)).Value = cr_multa;
                else
                    cmd.Parameters.Add(new SqlParameter("@cr_multa", SqlDbType.Decimal)).Value = 0;
                //objD.executacomando(cmd);
                //cmd = null;
                //objD = null;

                int codigo = objD.ExecutaComandoInsert(cmd, "ContasAReceber");
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
        public void alterar(int codigo, int venda, DateTime vencimento, int formaPagamento, Decimal original, Decimal alterado, Decimal pago, String status, DateTime? pagamento,
            Decimal juros, Decimal desconto, String observacao, String parcela, Decimal? cr_valorRestante, Decimal? cr_multa)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE ContasAReceber" +
                    " SET cr_vendas=@venda, cr_dataVencimento=@vencimento, cr_formaPagamento=@formaPagamento, cr_valorOriginal=@original," +
                    " cr_valorAlterado=@alterado, cr_valorPago=@pago, cr_status=@status, cr_dataPagamento=@pagamento,"+
                    " cr_juros=@juros, cr_desconto=@desconto, cr_observacao=@observacao, cr_parcela=@parcela, cr_valorRestante=@cr_valorRestante, cr_multa=@cr_multa " +
                    " WHERE cr_codigo = @codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("@venda", SqlDbType.Int)).Value = venda;
                cmd.Parameters.Add(new SqlParameter("@vencimento", SqlDbType.DateTime)).Value = vencimento;
                cmd.Parameters.Add(new SqlParameter("@formaPagamento", SqlDbType.Int)).Value = formaPagamento;
                cmd.Parameters.Add(new SqlParameter("@original", SqlDbType.Decimal)).Value = original;
                cmd.Parameters.Add(new SqlParameter("@alterado", SqlDbType.Decimal)).Value = alterado;
                cmd.Parameters.Add(new SqlParameter("@pago", SqlDbType.Decimal)).Value = pago;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = status;
                if (pagamento != null)
                    cmd.Parameters.Add(new SqlParameter("@pagamento", SqlDbType.DateTime)).Value = pagamento;
                else
                    cmd.Parameters.Add(new SqlParameter("@pagamento", SqlDbType.DateTime)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@juros", SqlDbType.Decimal)).Value = juros;
                cmd.Parameters.Add(new SqlParameter("@desconto", SqlDbType.Decimal)).Value = desconto;
                cmd.Parameters.Add(new SqlParameter("@observacao", SqlDbType.VarChar)).Value = observacao;
                cmd.Parameters.Add(new SqlParameter("@parcela", SqlDbType.VarChar)).Value = parcela;
                if(cr_valorRestante!=null)
                    cmd.Parameters.Add(new SqlParameter("@cr_valorRestante", SqlDbType.Decimal)).Value = cr_valorRestante;
                else
                    cmd.Parameters.Add(new SqlParameter("@cr_valorRestante", SqlDbType.Decimal)).Value = DBNull.Value;
                if (cr_multa != null)
                    cmd.Parameters.Add(new SqlParameter("@cr_multa", SqlDbType.Decimal)).Value = cr_multa;
                else
                    cmd.Parameters.Add(new SqlParameter("@cr_multa", SqlDbType.Decimal)).Value = 0;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int cr_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM ContasAReceber" +
                    " WHERE" +
                    " cr_codigo=@cr_codigo";
                cmd.Parameters.Add(new SqlParameter("@cr_codigo", SqlDbType.Int)).Value = cr_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluirVendas(int cr_vendas)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM ContasAReceber" +
                    " WHERE" +
                    " cr_vendas=@cr_vendas";
                cmd.Parameters.Add(new SqlParameter("@cr_vendas", SqlDbType.Int)).Value = cr_vendas;
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
                cmd.CommandText = "SELECT * FROM ContasAReceber" +
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
                cmd.CommandText = "SELECT * FROM ContasAReceber" +
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
                cmd.CommandText = "SELECT * FROM ContasAReceber" +
                    " WHERE cr_codigo = @codigo";
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
                cmd.CommandText = "SELECT cr.cr_codigo 'Código da Parcela',c.cli_nome 'Cliente', " +
                                   "v.ven_codigo 'Código da Venda', cr.cr_dataVencimento 'Data de Vencimento', cr.cr_formaPagamento 'Forma Pagamento', " +
                                   "Convert(Decimal(19,2),cr.cr_valorOriginal) 'Valor Original', Convert(Decimal(19,2),cr.cr_valorAlterado) 'Valor Alterado', " +
                                   "cr.cr_status 'Status', " +
                                   "cr.cr_juros 'Juros (%)',Convert(Decimal(19,2),cr.cr_desconto) 'Desconto (R$)',Convert(Decimal(19,2),cr.cr_valorPago) 'Valor Pago', " +
                                   "cr.cr_parcela 'Parcelas',cr.cr_dataPagamento 'Data do Pagamento' " +
                                 "FROM Cliente c INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente " +
                                   "INNER JOIN ContasAReceber cr on v.ven_codigo = cr.cr_vendas " +
                                 " WHERE " +
                                 "cr_status = 'Aberto' and " +
                                 "c.cli_nome like @descricao or c.cli_razao_social like @descricao " +
                                 "or v.ven_codigo like @descricao or cr.cr_codigo like @descricao or cr.cr_dataVencimento like @descricao";
                
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

        public DataTable localizarEmTudoFiltro(int codigo, DateTime? dataInicial, DateTime? dataFinal,string pago)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT cr.cr_codigo 'Código da Parcela',c.cli_nome 'Cliente', " +
                                   "v.ven_codigo 'Código da Venda', cr.cr_dataVencimento 'Data de Vencimento', cr.cr_formaPagamento 'Forma Pagamento', " +
                                   "Convert(Decimal(19,2),cr.cr_valorOriginal) 'Valor Original', Convert(Decimal(19,2),cr.cr_valorAlterado) 'Valor Alterado', " +
                                   "cr.cr_status 'Status', " +
                                   "cr.cr_juros 'Juros (%)',Convert(Decimal(19,2),cr.cr_desconto) 'Desconto (R$)',Convert(Decimal(19,2),cr.cr_valorPago) 'Valor Pago', " +
                                   "cr.cr_parcela 'Parcelas',cr.cr_dataPagamento 'Data do Pagamento' " +
                                 "FROM Cliente c INNER JOIN Vendas v on c.cli_codigo = v.ven_cliente " +
                                   "INNER JOIN ContasAReceber cr on v.ven_codigo = cr.cr_vendas " +
                                 "Where (c.cli_codigo = @ID or @ID = '')" +
                                 " and (cr_Status = @Status or @Status = '') ";
                    // "and  Convert(varchar,cr_dataVencimento,112) Between Convert(varchar,@DtInicial,112) and Convert(Varchar,@DtFinal,112) ";
                               //  " and Convert(Varchar,cr_dataVencimento,112)  >= Convert(Varchar,@dtInicial,112) and convert(Varchar,cr_dataVencimento,112) <= Convert(Varchar,@dtFinal,112) ";

                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = codigo;
                    cmd.Parameters.Add(new SqlParameter("@DtInicial", SqlDbType.DateTime)).Value = dataInicial;
                    cmd.Parameters.Add(new SqlParameter("@DtFinal", SqlDbType.DateTime)).Value = dataFinal;
                    cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar)).Value = pago;
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

        public DataTable RecebimentoTitulosContasAReceber(int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = 
                               " Update ContasAReceber "+
                               " set cr_status = 'Pago'"+
                               " from ContasAReceber cr" +
                                " Join vendas v on v.ven_codigo = cr.cr_vendas "+
                               "  Where v.ven_cliente = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = codigo;
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
                    cmd.CommandText = "SELECT cr_codigo = max(cr_codigo) FROM ContasAReceber";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT cr_codigo = min(cr_codigo) FROM ContasAReceber";
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
                    cmd.CommandText = "SELECT cr_codigo FROM ContasAReceber WHERE cr_codigo = (SELECT MIN(cr_codigo) FROM ContasAReceber WHERE cr_codigo > @codigo)";
                
                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT cr_codigo FROM ContasAReceber WHERE cr_codigo = (SELECT MAX(cr_codigo) FROM ContasAReceber WHERE cr_codigo < @codigo)"; ;
                    
                cmd.Parameters.Add(new SqlParameter("@codigo",SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {
                
                throw;
            }
            return tab;
        }

        public DataTable LocalizarContaReceberVenda(string idVenda)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat("select distinct(a.cr_formapagamento) forma_pagamento, ",
	                                                "a.cr_codigo id, b.fp_descricao descricao, sum(cr_valorOriginal) valor, ",
                                                    "cr_dataVencimento vencimento, a.cr_parcela parcela from contasareceber as a ",
	                                                "join formapagamento as b on a.cr_formaPagamento = b.fp_codigo ",
                                                    "where a.cr_vendas = ", idVenda,
                                                    " group by a.cr_codigo, a.cr_formapagamento, b.fp_descricao, cr_valorOriginal, cr_dataVencimento, a.cr_parcela ",
                                                    "order by a.cr_codigo");

                    using (objD = new Contexto())
                    {
                        DataTable dtContaReceberVenda = objD.ExecutaConsulta(cmd);

                        return dtContaReceberVenda;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public static DataSet ObterDadosPromissoriaVenda(int idVenda)
        {
            try
            {
                using (Contexto objD = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        DataSet dsDadosPromissoria = new DataSet();
                        DataTable tab;

                        cmd.CommandText = string.Concat("select cr_codigo, cr_vendas, cr_dataVencimento, cr_valorOriginal, cr_parcela, ",
		                                                "ven_codigo, ven_cliente, ven_dataVenda, cli_nome, cli_rg, cli_cpf, cli_razao_social ",
	                                                    "from contasareceber as a ",
	                                                    "join vendas as b on a.cr_vendas = b.ven_codigo ",
                                                        "join cliente as c on c.cli_codigo = b.ven_cliente ",
                                                        "where cr_vendas = ", idVenda);

                        tab = objD.ExecutaConsulta(cmd);
                        tab.TableName = "ContasReceber";

                        dsDadosPromissoria.Tables.Add(tab);

                        cmd.CommandText = string.Concat("select emp_codigo, emp_razaoSocial, emp_cnpj, emp_inscricaoEstadual from empresa");

                        tab = objD.ExecutaConsulta(cmd);
                        tab.TableName = "Empresa";

                        dsDadosPromissoria.Tables.Add(tab);

                        return dsDadosPromissoria;  
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}
