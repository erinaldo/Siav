using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class VendasDAL
    {
        Contexto objD = null;

        public VendasDAL()
        { }

        public DataTable gestao_seleciona(String data_inicial, String data_final, int vendedor)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("SELECT a.ven_codigo as 'ID',a.ven_status as 'Status',FORMAT(a.ven_dataVenda , 'dd/MM/yyyy  hh:mm:ss', 'pt-BR') as 'Data/Hora',c.nome as 'Vendedor',a.ven_valorTotal as 'Valor',a.ven_desconto 'Desconto',a.ven_valorFinal as 'Total' ");
                sb.AppendLine("FROM Vendas as a ");

                sb.AppendLine("left join Cliente as b ");
                sb.AppendLine("on  a.ven_cliente = b.cli_codigo ");

                sb.AppendLine("left join vendedor as c ");
                sb.AppendLine("on a.ven_vendedor = c.id ");                
                sb.AppendLine("WHERE 1 = 1 ");

                if (vendedor > 0)
                    sb.AppendLine("and c.id = "+vendedor+" ");

                if (data_inicial != "" && data_inicial != null){
                    sb.AppendLine(" and ven_dataVenda >= '" + data_inicial.Split('/')[1] + "/" + data_inicial.Split('/')[0] + "/" + data_inicial.Split('/')[2] + "'");
                }

                if (data_final != "" && data_final != null){
                    sb.AppendLine(" and ven_dataVenda <= '" + data_final.Split('/')[1] + "/" + data_final.Split('/')[0] + "/" + data_final.Split('/')[2] + " 23:59:59'");
                }

                sb.AppendLine(" order by a.ven_dataVenda desc");
                cmd.CommandText = sb.ToString();
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

        //inserção
        public int inserir(int cliente, DateTime data_venda, int funcionario, int vendedor, int forma_pagamento,
            int parcelas, decimal valor, String observacao, decimal percentual_desconto,
            decimal desconto, decimal ven_valorFinal, String ven_status, String ven_tipo, int ven_ticket, int IDAber, String cpfcnpj)
        {
            SqlCommand cmd = null;
            try
            {
                int codigo = 0;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Vendas" +
                    "(ven_cliente, ven_dataVenda, ven_usuario ,ven_vendedor, ven_formaPagamento, ven_qtdParcelas, ven_valorTotal, ven_observacao, " +
                    " ven_desconto, ven_percentualDesconto,ven_valorFinal,ven_status,ven_tipo,ven_ticket,IDAber,cpfcnpj)" +
                    " VALUES (@cliente, @data, @usuario, @vendedor, @forma_pagto, @parcelas, Convert(decimal(19,2),@total), @obs, @desconto, @percentual_desc,Convert(decimal(19,2),@ven_valorFinal),@ven_status,@ven_tipo,@ven_ticket,@IDAber,@cpfcnpj)";
                cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.Int)).Value = cliente;
                cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime)).Value = data_venda;
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar)).Value = funcionario;
                cmd.Parameters.Add(new SqlParameter("@vendedor", SqlDbType.Int)).Value = vendedor;
                if (forma_pagamento == 0)
                    cmd.Parameters.Add(new SqlParameter("@forma_pagto", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@forma_pagto", SqlDbType.Int)).Value = forma_pagamento;
                if (parcelas == 0)
                    cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = parcelas;
                cmd.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal)).Value = valor;
                if (observacao != null && observacao != "")
                    cmd.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar)).Value = observacao;
                else
                    cmd.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@desconto", SqlDbType.Decimal)).Value = desconto;
                cmd.Parameters.Add(new SqlParameter("@percentual_desc", SqlDbType.Decimal)).Value = percentual_desconto;
                cmd.Parameters.Add(new SqlParameter("@ven_valorFinal", SqlDbType.Decimal)).Value = ven_valorFinal;
                cmd.Parameters.Add(new SqlParameter("@ven_status", SqlDbType.VarChar)).Value = ven_status;
                cmd.Parameters.Add(new SqlParameter("@ven_tipo", SqlDbType.VarChar)).Value = ven_tipo;
                cmd.Parameters.Add(new SqlParameter("@ven_ticket", SqlDbType.Int)).Value = ven_ticket;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = IDAber;
                cmd.Parameters.Add(new SqlParameter("@cpfcnpj", SqlDbType.VarChar)).Value = cpfcnpj + "";
                codigo = objD.ExecutaComandoInsert(cmd, "Vendas");
                cmd = null;
                objD = null;
                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int inserir_venda_promissoria(int id_venda,int id_cliente,int vendedor, int parcelas, decimal juros,decimal ven_desconto, decimal ven_desconto_percentual){

            SqlCommand cmd = null;

            try{

                int codigo = 0;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Vendas_Promissoria" +
                    "(ven_status,ven_cliente,vendedor,ven_parcelas,ven_juros,ven_desconto,ven_percentual_desconto)" +
                    " VALUES (1,@id_cliente,@ven_vendedor,@parcelas,@juros,@ven_desconto,@ven_desconto_percentual)";

                cmd.Parameters.Add(new SqlParameter("@id_cliente", SqlDbType.Int)).Value = id_cliente;
                cmd.Parameters.Add(new SqlParameter("@ven_vendedor", SqlDbType.Int)).Value = vendedor;
                cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = parcelas;
                cmd.Parameters.Add(new SqlParameter("@juros", SqlDbType.Decimal)).Value = juros;
                cmd.Parameters.Add(new SqlParameter("@ven_desconto", SqlDbType.Decimal)).Value = ven_desconto;
                cmd.Parameters.Add(new SqlParameter("@ven_desconto_percentual", SqlDbType.Decimal)).Value = ven_desconto_percentual;

                codigo = objD.ExecutaComandoInsert(cmd,"Vendas_Promissoria");
                cmd = null;
                objD = null;
                return codigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int inserir_venda_promissoria_meses(int id_venda,int parcelas, string vencimento, decimal juros, decimal total){

            SqlCommand cmd = null;

            try{
               
                int codigo = 0;
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Vendas_Promissoria_Meses" +
                    "(promissoria,status,parcela,vencimento,juros,total)" +
                    " VALUES (@id,'ativo',@parcelas,@vencimento,@juros,@total)";

                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id_venda;
                cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = parcelas;
                cmd.Parameters.Add(new SqlParameter("@vencimento", SqlDbType.Date)).Value = vencimento;
                cmd.Parameters.Add(new SqlParameter("@juros", SqlDbType.Decimal)).Value = juros;
                cmd.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal)).Value = total;

                codigo = objD.ExecutaComandoInsert(cmd, "Vendas_Promissoria_Meses");
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
        public void alterar(int codigo, int cliente, DateTime data_venda, int funcionario, int vendedor, int forma_pagamento,
            int parcelas, decimal valor, String observacao, decimal percentual_desconto, decimal desconto,
            decimal ven_valorFinal, String ven_status, String ven_tipo, int ven_ticket)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Vendas" +
                    " SET ven_cliente=@cliente,ven_dataVenda=@data," +
                    " ven_usuario=@usuario," +
                    " ven_vendedor=@vendedor," +
                    " ven_formaPagamento=@forma_pagto,ven_qtdParcelas=@parcelas," +
                    " ven_valorTotal=@total,ven_observacao=@obs," +
                    " ven_desconto = @desconto, ven_percentualDesconto = @percentual_desc," +
                    " ven_valorFinal=@ven_valorFinal, ven_status=@ven_status, ven_tipo=@ven_tipo, ven_ticket = @ven_ticket" +
                    " WHERE" +
                    " ven_codigo=@codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("@cliente", SqlDbType.Int)).Value = cliente;
                cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.DateTime)).Value = data_venda;
                cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar)).Value = funcionario;
                cmd.Parameters.Add(new SqlParameter("@vendedor", SqlDbType.Int)).Value = vendedor;
                if (forma_pagamento == 0)
                    cmd.Parameters.Add(new SqlParameter("@forma_pagto", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@forma_pagto", SqlDbType.Int)).Value = forma_pagamento;
                if (parcelas == 0)
                    cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@parcelas", SqlDbType.Int)).Value = parcelas;
                cmd.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal)).Value = valor;
                if (observacao != null && observacao != "")
                    cmd.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar)).Value = observacao;
                else
                    cmd.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar)).Value = DBNull.Value;
                cmd.Parameters.Add(new SqlParameter("@desconto", SqlDbType.Decimal)).Value = desconto;
                cmd.Parameters.Add(new SqlParameter("@percentual_desc", SqlDbType.Decimal)).Value = percentual_desconto;
                cmd.Parameters.Add(new SqlParameter("@ven_valorFinal", SqlDbType.Decimal)).Value = ven_valorFinal;
                cmd.Parameters.Add(new SqlParameter("@ven_status", SqlDbType.VarChar)).Value = ven_status;
                cmd.Parameters.Add(new SqlParameter("@ven_tipo", SqlDbType.VarChar)).Value = ven_tipo;
                cmd.Parameters.Add(new SqlParameter("@ven_ticket", SqlDbType.Int)).Value = ven_ticket;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void alterar_xml(int codigo, int sessao, String xml, String data_hora, String nsat)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Vendas" +
                    " SET ven_status='Ativo',sessao=@sessao,xml=@xml,ven_dataVenda=@data_hora,nserieSAT = @nsat " +
                    " WHERE" +
                    " ven_codigo=@codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
                cmd.Parameters.Add(new SqlParameter("@sessao", SqlDbType.VarChar)).Value = sessao.ToString();
                cmd.Parameters.Add(new SqlParameter("@xml", SqlDbType.VarChar)).Value = xml;
                cmd.Parameters.Add(new SqlParameter("@data_hora", SqlDbType.DateTime)).Value = data_hora;
                cmd.Parameters.Add(new SqlParameter("@nsat", SqlDbType.VarChar)).Value = nsat;
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
        public void cancelarVenda(int ven_codigo, String ven_status)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Vendas" +
                    " SET ven_status = @ven_status" +
                    " WHERE" +
                    " ven_codigo=@ven_codigo";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = ven_codigo;
                cmd.Parameters.Add(new SqlParameter("@ven_status", SqlDbType.VarChar)).Value = ven_status;
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
        public void alterarTipoVenda(int ven_codigo, int ven_formaPagamento, int ven_qtdParcelas, String ven_tipo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Vendas" +
                    " SET ven_formaPagamento = @ven_formaPagamento, ven_qtdParcelas = @ven_qtdParcelas,ven_tipo = @ven_tipo" +
                    " WHERE" +
                    " ven_codigo=@ven_codigo";
                cmd.Parameters.Add(new SqlParameter("@ven_codigo", SqlDbType.Int)).Value = ven_codigo;
                cmd.Parameters.Add(new SqlParameter("@ven_formaPagamento", SqlDbType.Int)).Value = ven_formaPagamento;
                cmd.Parameters.Add(new SqlParameter("@ven_qtdParcelas", SqlDbType.Int)).Value = ven_qtdParcelas;
                cmd.Parameters.Add(new SqlParameter("@ven_tipo", SqlDbType.VarChar)).Value = ven_tipo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }


        public void excluir(int codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Vendas" +
                    " WHERE" +
                    " ven_codigo=@codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
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
                cmd.CommandText = "SELECT * FROM Vendas" +
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

        public DataTable seleciona_promissorias(String search)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();            

                String x = "";

                x += "select a.*,ISNULL(sum(b.total), 0 ) as 'Total_Restante' ";
                x += "from ";
                x += "( ";
                x += "SELECT TOP 50 a.ven_promissoria as 'Codigo_Promissoria',c.cli_nome as 'Nome_Cliente',a.ven_parcelas as 'Parcelas',   ";
                x += "sum(b.total) as 'Total' ";

                x += "FROM Vendas_Promissoria as a  ";

                x += "inner join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.ven_promissoria   ";

                x += "inner join Cliente as c  ";
                x += "on a.ven_cliente = c.cli_codigo  ";

                x += "where a.ven_status = 1 ";

                x += "group by  a.ven_promissoria ,c.cli_nome ,a.ven_parcelas ";
                x += "order by c.cli_nome asc ";
                x += ") as a ";

                x += "left join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.Codigo_Promissoria and b.status = 'ativo' ";

                if (search.Length > 0)
                    x += "where a.Nome_Cliente like '" + search + "%' ";

                x += "group by a.Codigo_Promissoria,a.Nome_Cliente,a.Parcelas,a.Total ";

                cmd.CommandText = x;

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

        public DataTable seleciona_promissorias_fechadas(String search)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                String x = "";

                x += "select a.*,ISNULL(sum(b.total), 0 ) as 'Total_Restante' ";
                x += "from ";
                x += "( ";
                x += "SELECT TOP 50 a.ven_promissoria as 'Codigo_Promissoria',c.cli_nome as 'Nome_Cliente',a.ven_parcelas as 'Parcelas',   ";
                x += "sum(b.total) as 'Total' ";

                x += "FROM Vendas_Promissoria as a  ";

                x += "inner join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.ven_promissoria   ";

                x += "inner join Cliente as c  ";
                x += "on a.ven_cliente = c.cli_codigo  ";

                x += "where a.ven_status = 0 ";

                x += "group by  a.ven_promissoria ,c.cli_nome ,a.ven_parcelas ";
                x += "order by c.cli_nome asc ";
                x += ") as a ";

                x += "left join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.Codigo_Promissoria and b.status = 'ativo' ";

                if (search.Length > 0)
                    x += "where a.Nome_Cliente like '" + search + "%' ";

                x += "group by a.Codigo_Promissoria,a.Nome_Cliente,a.Parcelas,a.Total ";

                cmd.CommandText = x;

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

        public DataTable seleciona_promissorias_search(String search)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                String x = "";

                x += "select a.*,ISNULL(sum(b.total), 0 ) as 'Total_Restante' ";
                x += "from ";
                x += "( ";
                x += "SELECT TOP 50 a.ven_promissoria as 'Codigo_Promissoria',c.cli_nome as 'Nome_Cliente',a.ven_parcelas as 'Parcelas',   ";
                x += "sum(b.total) as 'Total' ";

                x += "FROM Vendas_Promissoria as a  ";

                x += "inner join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.ven_promissoria   ";

                x += "inner join Cliente as c  ";
                x += "on a.ven_cliente = c.cli_codigo  ";

                x += "group by  a.ven_promissoria ,c.cli_nome ,a.ven_parcelas ";
                x += "order by c.cli_nome asc ";
                                
                x += ") as a ";

                x += "left join Vendas_Promissoria_Meses as b  ";
                x += "on b.promissoria = a.Codigo_Promissoria and b.status = 'ativo' ";
                
                if (search.Length > 0)
                    x += "where a.Nome_Cliente like '" + search + "%' ";

                x += "group by a.Codigo_Promissoria,a.Nome_Cliente,a.Parcelas,a.Total ";

                cmd.CommandText = x;

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

        public DataTable seleciona_promissorias_vencidas(String search)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                String x = "";

                x += "select a.*,sum(b.total) as 'Total Restante' from ";
                x += "( ";
                x += "SELECT TOP 50 a.promissoria as 'Codigo_Promissoria', c.cli_nome as 'Nome_Cliente' , count(d.id) as 'Parcelas' , sum(d.total) as 'Total' ";
                x += "FROM Vendas_Promissoria_Meses as a ";
                x += "inner join Vendas_Promissoria as b ";
                x += "on a.promissoria = b.ven_promissoria and b.ven_status = 1 ";
                x += "inner join Cliente as c ";
                x += "on c.cli_codigo = b.ven_cliente ";
                x += "inner join Vendas_Promissoria_Meses as d ";
                x += "on a.promissoria = d.promissoria ";
                x += "where a.status = 'ativo' and  (SELECT CONVERT(date, a.vencimento)) < (SELECT CONVERT(date, (SELECT GETDATE ()))) ";
                x += "group by a.promissoria,c.cli_nome ";
                x += ") as a ";
                x += "inner join Vendas_Promissoria_Meses as b ";
                x += "on a.Codigo_Promissoria = b.promissoria and b.status = 'ativo' ";

                if (search.Length > 0)
                    x += "where a.Nome_Cliente like '" + search + "%' ";

                x += "group by a.Codigo_Promissoria,a.Nome_Cliente,a.Parcelas,a.Total "; 
                x += "order by a.Nome_Cliente asc ";

                cmd.CommandText = x;

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

       public DataTable seleciona_promissorias_vencidas_hoje_bd(String search)
       {
           DataTable tab = null;
           SqlCommand cmd = null;
           try
           {
               objD = new Contexto();
               cmd = new SqlCommand();
       
               String x = "";
       
               x += "select a.*,sum(b.total) as 'Total Restante' from ";
               x += "( ";
               x += "SELECT TOP 50 a.promissoria as 'Codigo_Promissoria', c.cli_nome as 'Nome_Cliente' , count(d.id) as 'Parcelas' , sum(d.total) as 'Total' ";
               x += "FROM Vendas_Promissoria_Meses as a ";
               x += "inner join Vendas_Promissoria as b ";
               x += "on a.promissoria = b.ven_promissoria and b.ven_status = 1 ";
               x += "inner join Cliente as c ";
               x += "on c.cli_codigo = b.ven_cliente ";
               x += "inner join Vendas_Promissoria_Meses as d ";
               x += "on a.promissoria = d.promissoria ";
               x += "where a.status = 'ativo' and (SELECT CONVERT(date, a.vencimento)) = (SELECT CONVERT(date, GETDATE())) ";
               x += "group by a.promissoria,c.cli_nome ";
               x += ") as a ";
               x += "inner join Vendas_Promissoria_Meses as b ";
               x += "on a.Codigo_Promissoria = b.promissoria and b.status = 'ativo' ";

               if (search.Length > 0)
                   x += "where a.Nome_Cliente like '" + search + "%' ";

               x += "group by a.Codigo_Promissoria,a.Nome_Cliente,a.Parcelas,a.Total ";
               x += "order by a.Nome_Cliente asc ";
       
               cmd.CommandText = x;
       
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


         public DataTable seleciona_promissorias_meses(Int32 id)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                String x = "select a.id,a.status,a.vencimento,a.juros,a.total FROM Vendas_Promissoria_Meses as a where a.promissoria = " + id + "";

                x += " ";
                cmd.CommandText = x;

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

         public void baixa_promissoria(Int32 id)
         {
             DataTable tab = null;
             SqlCommand cmd = null;
             try
             {
                 objD = new Contexto();
                 cmd = new SqlCommand();

                 String x = " UPDATE Vendas_Promissoria_Meses SET status = 'pago' WHERE id = " + id + "";

                 cmd.CommandText = x;
                 objD.ExecutaComando(cmd);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             cmd = null;
             objD = null;
         }

         public void fecha_promissoria(Int32 id)
         {
             DataTable tab = null;
             SqlCommand cmd = null;
             try
             {
                 objD = new Contexto();
                 cmd = new SqlCommand();

                 String x = " UPDATE Vendas_Promissoria SET ven_status = 0 WHERE ven_promissoria = " + id + "";

                 cmd.CommandText = x;
                 objD.ExecutaComando(cmd);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             cmd = null;
             objD = null;
         }
        

        public DataTable localizar_vendas_troca(String data_inicial, String data_final)
        {

            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                String cmd_text = " SELECT TOP 1000 [a].[ven_codigo] as 'Codigo' ,[a].[ven_dataVenda] as 'Data Venda' ,Sum(CONVERT(INT, [b].[vi_quantidade]) ) as 'Quantidade Itens' " +
                " ,[a].[ven_valorFinal] as 'Valor Venda' FROM Vendas as a " +
                " inner join vendaItens as b on a.[ven_codigo] = b.[ven_codigo] " +
                " where [ven_status] = 'Ativo' ";

                if (data_inicial != "" && data_inicial != null)
                    cmd_text += " and [a].[ven_dataVenda] >= '" + data_inicial + "' ";

                if (data_final != "" && data_final != null)
                    cmd_text += " and [a].[ven_dataVenda] <= '" + data_final + "' ";

                cmd_text += " group by [a].[ven_codigo],[a].[ven_dataVenda],[a].[ven_valorFinal]";
                cmd.CommandText = cmd_text;
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


        public DataTable localizar_cliente_promissoria(Int32 id)
        {

            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                String cmd_text = "  ";

                cmd_text += "select b.cli_nome ";
                cmd_text += "from Vendas_Promissoria as a ";
                cmd_text += "inner join Cliente as b ";
                cmd_text += "on a.ven_cliente = b.cli_codigo ";
                cmd_text += "where  a.ven_promissoria =  " + id;

                cmd.CommandText = cmd_text;
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

        public DataTable localizar_itens_troca(String codigo_venda)
        {

            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "select a.pro_codigo, b.pro_nome,a.vi_quantidade,a.vi_subtotal from vendaItens as a " +
                " inner join Produtos as b" +
                " on a.pro_codigo = b.pro_codigo" +
                " where ven_codigo = " + codigo_venda;

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
                cmd.CommandText = "SELECT * FROM Vendas" +
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
        //Novo Localizar Ticket 
        public DataTable localizarLeave_Ticket(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Vendas" +
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
        //***********


        public DataTable verificaLimiteClienteMensal(int cli_codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT SUM(cr.cr_valorAlterado) 'Valor Total do Devedor' " +
                                "FROM Cliente c " +
                                "INNER JOIN vendas v on c.cli_codigo = v.ven_cliente " +
                                "INNER JOIN ContasAReceber cr on v.ven_codigo= cr.cr_vendas " +
                                "WHERE c.cli_codigo = @descricao and v.ven_dataVenda < GETDATE() and v.ven_dataVenda > GETDATE() - 30 and cr.cr_status <> 'Pago' " +
                                "GROUP BY c.cli_limiteMensal " +
                                "having c.cli_limiteMensal < SUM(cr.cr_valorAlterado)";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.Int)).Value = cli_codigo;
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

        public DataTable verificaLimiteClienteTotal(int cli_codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT SUM(cr.cr_valorAlterado) 'Valor Total do Devedor' " +
                                "FROM Cliente c " +
                                "INNER JOIN vendas v on c.cli_codigo = v.ven_cliente " +
                                "INNER JOIN ContasAReceber cr on v.ven_codigo= cr.cr_vendas " +
                                "WHERE c.cli_codigo = @descricao " +
                                "GROUP BY c.cli_limiteCredito " +
                                "HAVING  c.cli_limiteCredito < SUM(cr.cr_valorAlterado)";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.Int)).Value = cli_codigo;
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
                cmd.CommandText = "SELECT * FROM Vendas" +
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

        public String localizar_xml(int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT xml FROM Vendas" +
                    " WHERE ven_codigo = @codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo",
                    SqlDbType.Int)).Value = codigo;
                tab = objD.ExecutaConsulta(cmd);
                cmd = null;
                objD = null;
                if (tab.Rows.Count > 0)
                    return tab.Rows[0][0].ToString();
                else
                    return "";
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

                cmd.CommandText = "SELECT v.ven_codigo'Nº'," +
                                    "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', " +
                                    "v.ven_dataVenda 'Data',u.usu_nome 'Atendente', fp.fp_descricao 'Forma de Pagamento', " +
                                    "v.ven_qtdParcelas 'Parcelas', v.ven_valorTotal 'Subtotal',v.ven_status 'Situação', v.ven_desconto 'Desconto', " +
                                    "v.ven_percentualDesconto '%',ven_valorFinal'Total',v.ven_tipo 'Tipo',v.ven_observacao 'Observaçaõ' " +
                            "FROM Vendas v  " +
                                    "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  " +
                                    "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo " +
                                    "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " +
                            "WHERE c.cli_nome like @descricao or c.cli_razao_social like @descricao or v.ven_codigo like @descricao";
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


        public DataTable LocalizarCupom(Int32 usuario)
        {
            DateTime dt = DateTime.Now;
            dt = dt.AddMinutes(-30);


            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = "SELECT v.ven_codigo'Nº'," +
                        "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', " +
                        "v.ven_dataVenda 'Data', v.ven_valorTotal 'Subtotal' " +
                "FROM Vendas v  " +
                        "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  " +
                        "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo " +
                        "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " +
                "WHERE ven_dataVenda > @data and ven_status = 'Ativo' and ven_usuario = @ven_usuario order by Data desc ";

                cmd.Parameters.Add(new SqlParameter("@data",
                   SqlDbType.DateTime)).Value = dt.ToString();
                cmd.Parameters.Add(new SqlParameter("@ven_usuario",
                    SqlDbType.Int)).Value = usuario;

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

        public DataTable LocalizarSegundaVia(Int32 usuario)
        {


            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = "SELECT v.ven_codigo'Nº'," +
                        "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', " +
                        "v.ven_dataVenda 'Data', v.ven_valorTotal 'Subtotal' " +
                "FROM Vendas v  " +
                        "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  " +
                        "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo " +
                        "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " +
                "WHERE  ven_status = 'Ativo' ";

                if (usuario > 0)
                {
                    cmd.CommandText += "and ven_usuario = @ven_usuario";

                    cmd.Parameters.Add(new SqlParameter("@ven_usuario", SqlDbType.Int)).Value = usuario;
                }

                cmd.CommandText += " order by Data desc ";



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

        public DataTable LocalizarRelatorioVendas(String data_inicial, String data_final)
        {


            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = "SELECT v.ven_codigo'Nº'," +
                        "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', " +
                        "v.ven_dataVenda 'Data', v.ven_valorTotal 'Subtotal',xml as 'N° SAT' " +
                "FROM Vendas v  " +
                        "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  " +
                        "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo " +
                        "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " +
                "WHERE  ven_dataVenda >= @data_inicial and ven_dataVenda <= @data_final and xml != null ";

                cmd.Parameters.Add(new SqlParameter("@data_inicial", SqlDbType.Date)).Value = data_inicial;
                cmd.Parameters.Add(new SqlParameter("@data_final", SqlDbType.Date)).Value = data_final;


                cmd.CommandText += " order by Data desc ";



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
                    cmd.CommandText = "SELECT ven_codigo = max(ven_codigo) FROM Vendas";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                            SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT ven_codigo = min(ven_codigo) FROM Vendas";
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
                    cmd.CommandText = "SELECT ven_codigo FROM Vendas WHERE ven_codigo = (SELECT MIN(ven_codigo) FROM Vendas WHERE ven_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT ven_codigo FROM Vendas WHERE ven_codigo = (SELECT MAX(ven_codigo) FROM Vendas WHERE ven_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable vendasDia()
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT SUM(v.ven_valorTotal) " +
                                "FROM vendas v WHERE v.ven_dataVenda = GETDATE()";
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

        public DataTable FormarCupom(int venda)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "sp_cupom"; //Procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@venda", SqlDbType.Int)).Value = venda;
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

        public DataSet ObterDadosContratoVenda(int idVenda)
        {
            try
            {
                using (objD = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        DataSet dsDadosContratoVenda = new DataSet("DadosContratoVenda");
                        DataTable tab;

                        //Venda com os dados do cliente e forma de pagamento
                        cmd.CommandText = string.Concat("select ven_codigo, ven_cliente, ven_dataVenda, ven_usuario, ven_vendedor, ven_formaPagamento, ven_qtdParcelas, ",
                                                        "ven_valorTotal, ven_observacao, ven_desconto, ven_percentualDesconto, ven_valorFinal, ven_status, ",
                                                        "ven_tipo, cli_codigo, cli_nome, cli_idade, cli_data_nascimento, cli_rg, cli_cpf, cli_logradouro, ",
                                                        "cli_complemento, cli_bairro, cli_razao_social, cli_cnpj, cli_ie, cli_data_fundacao, cli_tipo_pessoa ",
                                                        "cli_telefone, cli_celular, cli_calJuros, cli_limiteCredito, cli_limiteMensal, cli_cep, cli_cota, ",
                                                        "cli_Grupo, emp_codigo, cli_email1, cli_email2, observacao, fp_codigo, fp_descricao, cid_nome, ",
                                                        "cid_estado, est_codigo, est_sigla from vendas as vend ",
                                                        "join cliente as clie on vend.ven_cliente = clie.cli_codigo ",
                                                        "join formapagamento as formPag on vend.ven_formaPagamento = formpag.fp_codigo ",
                                                        "join cidade as cida on clie.cid_codigo = cida.cid_codigo ",
                                                        "join estado as esta on cida.cid_estado = esta.est_codigo ",
                                                        "where ven_codigo = ", idVenda);
                        tab = objD.ExecutaConsulta(cmd);
                        tab.TableName = "Tb_Venda";

                        dsDadosContratoVenda.Tables.Add(tab);

                        //Itens da venda
                        cmd.CommandText = string.Concat("select ven_codigo, vi_quantidade, vi_valorUnitario, vi_subtotal, vi_desconto, ",
                                                        "vi_percentual, vi_mesgarantia, pro_nome, pro_quantidade, pro_precoCusto, pro_precoVenda, ",
                                                        "pro_categoria, pro_grupo, pro_subGrupo, pro_unidade, pro_estoqueMin, pro_estoqueMax, ",
                                                        "pro_dataCadastro, pro_codigoBarra, pro_marca, pro_fornecedor, pro_tamanho, pro_margem, pro_comissao ",
                                                        "from vendaitens as vendItens ",
                                                        "join produtos as prod on vendItens.pro_codigo = prod.pro_codigo ",
                                                        "where ven_codigo = ", idVenda);
                        tab = objD.ExecutaConsulta(cmd);
                        tab.TableName = "Tb_itens";

                        dsDadosContratoVenda.Tables.Add(tab);

                        //Contas a receber da venda
                        cmd.CommandText = string.Concat("select cr_codigo, cr_vendas, cr_dataVencimento, cr_valorOriginal, cr_valorAlterado, cr_valorPago, ",
                                                        "cr_status, cr_dataPagamento, cr_juros, cr_desconto, cr_observacao, cr_parcela, cr_valorRestante, cr_multa ",
                                                        "from contasareceber ",
                                                        "where cr_vendas = ", idVenda);
                        tab = objD.ExecutaConsulta(cmd);
                        tab.TableName = "Tb_Titulos";

                        dsDadosContratoVenda.Tables.Add(tab);

                        return dsDadosContratoVenda;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable TotalizadorVendas(int codigo, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Totalizador_VendasPorCliente"; //Procedure
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
        //Historico Produto

        public DataTable EstoqueHistoricoProduto(int codigo, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                Contexto contexto = new Contexto();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "EstoqueHistorico"; //Procedure
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


        public DataTable localizarPedido(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = String.Concat(
                                    "SELECT",
                                    " v.ven_codigo'Nº'",
                                      ",v.ven_tipo 'Tipo',",
                                    " v.ven_ticket 'Mesa|Cartão', ",
                                    "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', ",
                                    "v.ven_dataVenda 'Data',",
                                    "u.usu_nome 'Usuario',",
                    // "ven.nome 'Vendendor', " ,
                                    " v.ven_valorTotal 'Subtotal',",
                                    "v.ven_status 'Situação',",
                                    " v.ven_desconto 'Desconto', ",
                                    "v.ven_percentualDesconto '%',",
                                    "ven_valorFinal'Total'",
                    // "v.ven_observacao 'Observação' " ,
                            " FROM Vendas v  ",
                                    "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  ",
                                    "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo ",
                                    "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo ",
                                    "Left join vendedor ven on ven.id = v.ven_vendedor ",
                            " WHERE c.cli_nome like @descricao or c.cli_razao_social like @descricao or v.ven_codigo like @descricao or  v.ven_ticket like @descricao ",
                             " Union All ",
                               "SELECT",
                                    " 0'Nº'",
                                      ",'' 'Tipo',",
                                    " '' 'Mesa|Cartão', ",
                                    "'''Cliente', ",
                                    "'' 'Data',",
                                    "'' 'Usuario',",
                    // "ven.nome 'Vendendor', " ,
                                    " 0 'Subtotal',",
                                    "'' 'Situação',",
                                    " 0 'Desconto', ",
                                    "0 '%',",
                                    "sum(ven_valorFinal)'Total'",
                    // "v.ven_observacao 'Observação' " ,
                            " FROM Vendas v  ",
                                    "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  ",
                                    "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo ",
                                    "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo ",
                                    "Left join vendedor ven on ven.id = v.ven_vendedor ",
                            " WHERE c.cli_nome like @descricao or c.cli_razao_social like @descricao or v.ven_codigo like @descricao or  v.ven_ticket like @descricao ",
                            " Order by v.ven_dataVenda desc");
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
        public DataTable localizarPedidoData(DateTime? dtIncial, DateTime? dtFinal, string Situacao, string Tipo, int? usuario)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText =
                    String.Concat(
                                    "SELECT",
                                    " v.ven_codigo'Nº'",
                                      ",v.ven_tipo 'Tipo',",
                                    " v.ven_ticket 'Mesa|Cartão', ",
                                    "CASE WHEN (c.cli_tipo_pessoa = 'Pessoa Física') THEN c.cli_nome ELSE c.cli_razao_social END 'Cliente', ",
                                    "v.ven_dataVenda 'Data',",
                                    "u.usu_nome 'Usuario',",
                    // "ven.nome 'Vendendor', " ,
                                    " v.ven_valorTotal 'Subtotal',",
                                    "v.ven_status 'Situação',",
                                    " v.ven_desconto 'Desconto', ",
                                    "v.ven_percentualDesconto '%',",
                                    "ven_valorFinal'Total'",
                    // "v.ven_observacao 'Observação' " ,
                            " FROM Vendas v  ",
                                    "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  ",
                                    "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo ",
                    //"LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " ,
                                    "Left join vendedor ven on ven.id = v.ven_vendedor ",
                             "WHERE xml != 'null' and Convert(Varchar,v.ven_datavenda,112) >= Convert(Varchar,@dtInicial,112) and convert(Varchar,v.ven_datavenda,112) <= Convert(Varchar,@dtFinal,112) and ven_status = @Situacao and ven_Tipo = @Tipo",
                              " and (v.ven_usuario = @Usuario or @Usuario = 0) ",
                    //  " Order by v.ven_dataVenda desc",
                             " Union All ",
                            "SELECT ",
                            "null",
                            ",null",
                            ",0",
                            ", 'T O T A L'",
                            ", null",
                            ",null",
                            ",null",
                            ",null",
                            ", null",
                            ", null",
                           " ,SUM(ven_valorFinal)'Total'",
                            "FROM Vendas v  " +
                                    "LEFT JOIN Usuario u ON v.ven_usuario = u.usu_codigo  " +
                                    "LEFT JOIN Cliente c ON v.ven_cliente= c.cli_codigo " +
                    // "LEFT JOIN FormaPagamento fp ON v.ven_formaPagamento = fp.fp_codigo " +
                                    "Left join vendedor ven on ven.id = v.ven_vendedor " +
                            "WHERE Convert(Varchar,v.ven_datavenda,112) >= Convert(Varchar,@dtInicial,112) and convert(Varchar,v.ven_datavenda,112) <= Convert(Varchar,@dtFinal,112) and ven_status = @Situacao and ven_Tipo = @Tipo",
                            " and (v.ven_usuario = @Usuario or @Usuario = 0) ",
                            " Order by v.ven_dataVenda desc");
                cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtIncial;
                cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                cmd.Parameters.Add(new SqlParameter("@Situacao", SqlDbType.VarChar)).Value = Situacao;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar)).Value = Tipo;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;

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
        public DataTable localizarPedidoItens(DateTime? dtIncial, DateTime? dtFinal, string Situacao, string Tipo, int? usuario, int? ID)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText =
                    String.Concat(
                          "  Select ",
                          "     IDVenda				= Vi.ven_codigo ",
                          "  ,	IDProduto			= vi.pro_codigo ",
                          "  ,	Produto				= prod.pro_nome ",
                          "  ,   Quantidade          = Vi.vi_quantidade ",
                          "  ,   PreçoUnitario       = vi.vi_valorUnitario ",
                          "  ,   SubTotal            = vi.vi_subTotal ",
                          "   From vendaItens Vi ",
                          "   Join Produtos prod on prod.pro_codigo = Vi.pro_codigo ",
                          "   join Vendas V on v.ven_codigo = Vi.ven_codigo ",
                          "   WHERE xml != 'null' and Convert(Varchar,v.ven_datavenda,112) ",
                          "        >= Convert(Varchar,@dtInicial,112) ",
                          "        and convert(Varchar,v.ven_datavenda,112) ",
                          "        <= Convert(Varchar,@dtFinal,112) ",
                          "        and ven_status = @Situacao ",
                          "        and ven_Tipo = @Tipo ",
                          "   and (v.ven_usuario = @Usuario or @Usuario = 0) ",
                          "   and (Vi.ven_codigo = @ID or @ID = 0) "
                );
                cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtIncial;
                cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal;
                cmd.Parameters.Add(new SqlParameter("@Situacao", SqlDbType.VarChar)).Value = Situacao;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar)).Value = Tipo;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
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
