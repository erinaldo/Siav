using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SVC_DAL
{
    public class MesasDAL
    {

        Contexto objD = null;

        public Boolean verifica_mesa_aberta(String id)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = " select * from Mesas where numero_mesa = " + id + " and status = 0";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            if (tab.Rows.Count > 0)
                return true;
            else
                return false;
        }


        public DataTable seleciona_produtos_mesa(String id)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                StringBuilder sb = new StringBuilder();
                sb.Append("select b.id,c.pro_nome as 'Nome Produto',b.quantidade,c.pro_precoVenda as 'Valor Unitario',(b.quantidade * c.pro_precoVenda) as 'Total' ");
                sb.Append("from Mesas as a ");
                sb.Append("inner join Mesas_Itens as b ");
                sb.Append("on b.mesa = a.id ");
                sb.Append("inner join Produtos as c ");
                sb.Append("on b.produto = c.pro_codigo ");
                sb.Append("where	a.numero_mesa = "+ id+" and a.status = 0 ");

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


        public DataTable seleciona_mesa(String id)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = " select * from Mesas where numero_mesa = " + id + " and status = 0";
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

        public void add_produto_mesa(String codigo_mesa,String codigo_produto,int quantidade)
        {
             SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Mesas_Itens(mesa,produto,quantidade)VALUES((select id from Mesas where numero_mesa = " + codigo_mesa + " and status = 0) ," + codigo_produto + ","+quantidade+");";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public void deleta_item_mesa(String id)
        {
             SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "delete from Mesas_Itens where id = " + id + "";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        

        public void abrir_mesa(String id)
        {
       
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Mesas(numero_mesa,status,data_abertura,data_fechamento) values("+id+",0,current_timestamp,current_timestamp);";
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        

        }


    }




}
