using One.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVC_DAL
{
    public class CfopDAL{

        Contexto objD = null;

        //selecionar várias linhas
        public DataTable localizar(String descricao, String coluna){
            DataTable tab = null;
            SqlCommand cmd = null;
            
            try{

                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM cfop";                  
                tab = objD.ExecutaConsulta(cmd);
            
            }catch (Exception ex){
                throw ex;
            }
            
            cmd = null;
            objD = null;
            return tab;
        }

  
    
    }
}
