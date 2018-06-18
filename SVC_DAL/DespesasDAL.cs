using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class DespesasDAL{
        
        Contexto objD = null;

        public void add_despesa(Int32 fornecedor, String nome,decimal valor,String validade,Boolean mensal,String titulo, String serie){
            
            Int32 x = 0;
            if (mensal)
                x = 1;

            SqlCommand cmd = null;
            try{
                objD = new Contexto();
                cmd = new SqlCommand();
                String comando = "INSERT INTO Despesa(fornecedor,nome,valor,validade,mensal,data_exclusao,titulo,serie)VALUES("+fornecedor+",'"+nome+"',"+valor.ToString().Replace(',','.')+",'"+validade+"',"+x+",'1/1/3995','"+titulo+"','"+serie+"');";
                cmd.CommandText = comando;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }catch (Exception ex){
                throw ex;
            }
        }

        public void pagar(Int32 despesa,String data_pagamento)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Despesa_Detalhe(fk_despesa,data_pagamento)VALUES("+despesa+",'"+data_pagamento+"');";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void excluir(Int32 despesa, String data)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "update Despesa set data_exclusao = '" + data + "' where id = " + despesa + "";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable localizar(String data_inicial,String data_final)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select * from (select a.id as 'codigo',case when b.id > 0 then 'PAGO' else 'PENDENTE' end as status,case when a.mensal = 0 then 'Não' else 'Sim' end  as 'Cobrança Mensal',a.validade,	 a.nome as 'Descrição',	a.valor,a.data_exclusao ");
                sb.Append("from Despesa as a  ");
                sb.Append("left join Despesa_Detalhe as b ");
                sb.Append("on b.[fk_despesa] = a.[id] and b.data_pagamento >= '"+data_inicial+"' and b.data_pagamento <= '"+data_final+"'  ");

                sb.Append("where a.validade >= '" + data_inicial + "'  and   a.validade <= '" + data_final + "' or a.mensal = 1 ");
                sb.Append(") as a where a.data_exclusao >	'" + data_final + "' order by a.validade asc");
                objD = new Contexto();
                cmd = new SqlCommand();
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

        public DataTable localizar_especifico(Int32 codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("select * from Despesa where id = " + codigo );
                objD = new Contexto();
                cmd = new SqlCommand();
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


        
    }
}
