using SVC_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SVC_BLL
{
    public class CfopBLL
    {
        public int id { get; set; }
        public String cfop { get; set; }
        public String descricao { get; set; }

        CfopDAL objDAL = null;


        public void localizar(String descricao, String atributo)
        {

            try{
                DataTable tab;
                objDAL = new CfopDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0){
                    this.cfop = tab.Rows[0]["cfop"].ToString();
                    this.descricao = tab.Rows[0]["descricao"].ToString();
                }
                objDAL = null;
            }
            catch (Exception){
                throw;
            }
        }

    }
}
