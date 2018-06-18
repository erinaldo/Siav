using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class MesaBLL
    {

        public int id { get; set; }
        public int quantidade { get; set; }
        public String codigo_produto{get;set;}
        public mesa_status status { get; set; }
        public int mesa { get; set; }
        public String data_abertura { get; set; }
        public String data_fechamento { get; set; }


        public Boolean verifica_se_mesa_esta_aberta()
        {

            MesasDAL cmd = new MesasDAL();
            return cmd.verifica_mesa_aberta(this.id.ToString());

        }

        public void deleta_item_mesa()
        {

            MesasDAL cmd = new MesasDAL();
            cmd.deleta_item_mesa(this.id.ToString());

        }

        public DataTable seleciona_dados_mesa()
        {

            MesasDAL cmd = new MesasDAL();
            return cmd.seleciona_mesa(this.id.ToString());

        }

        public void abrir_mesa()
        {
            MesasDAL cmd = new MesasDAL();
            cmd.abrir_mesa(id.ToString());
            //cmd.(this.id.ToString());
        }


        public DataTable localizar_em_aberto()
        {

            try{

                DataTable tab = new DataTable();

                //  objDAL = new CfopDAL();
                //  tab = objDAL.localizar(descricao, atributo);
                //  if (tab.Rows.Count > 0)
                //  {
                //      this.cfop = tab.Rows[0]["cfop"].ToString();
                //      this.descricao = tab.Rows[0]["descricao"].ToString();
                //  }
                //  objDAL = null;

                return tab;

            }
            catch (Exception)
            {
                throw;
                return new DataTable();
            }
        }

        public void adicionar_produto_mesa()
        {
            MesasDAL cmd = new MesasDAL();
            cmd.add_produto_mesa(this.id.ToString(), this.codigo_produto,this.quantidade);
        }

        public DataTable seleciona_produtos_mesa()
        {
            MesasDAL cmd = new MesasDAL();
            return cmd.seleciona_produtos_mesa(this.id.ToString());
        }

    }

    public enum mesa_status
    {
        fechado = 0,
        aberto = 1
    }



}
