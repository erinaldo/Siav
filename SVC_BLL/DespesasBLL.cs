using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class DespesasBLL
    {
        public int id { get; set; }
        public int fornecedor{get;set;}
        public Boolean mensal { get; set; }
        public String descricao { get; set; }
        public String titulo { get; set; }
        public String serie { get; set; }
        public String data { get; set; }
        public String data_inicial { get; set; }
        public String data_final { get; set; }
        public decimal valor { get; set; }

        public void add_despesa(){
            DespesasDAL cmd = new DespesasDAL();
            cmd.add_despesa(fornecedor,descricao, valor, data, mensal,titulo,serie);


        }

        public DataTable localizar(){
            DespesasDAL cmd = new DespesasDAL();
            return cmd.localizar(data_inicial,data_final);
        }

        public DataTable localizar_especifico(Int32 codigo)
        {
            DespesasDAL cmd = new DespesasDAL();
            return cmd.localizar_especifico(codigo);
        }

        public void pagar()
        {
            DespesasDAL cmd = new DespesasDAL();
            cmd.pagar(id,data);
        }

        public void excluir()
        {
            DespesasDAL cmd = new DespesasDAL();
            cmd.excluir(id, data);
        }
        


        //public void localizar(String descricao, String atributo)
        //{
        //
        //    try
        //    {
        //        DataTable tab;
        //        objDAL = new CfopDAL();
        //        tab = objDAL.localizar(descricao, atributo);
        //        if (tab.Rows.Count > 0)
        //        {
        //            this.cfop = tab.Rows[0]["cfop"].ToString();
        //            this.descricao = tab.Rows[0]["descricao"].ToString();
        //        }
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
