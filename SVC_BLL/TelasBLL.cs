using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class TelasBLL
    {
        public String ct_nome { get; set; }
        public int per_codigo { get; set; }
        public String ct_status { get; set; }
        public String ct_name { get; set; }

        TelasDAL objDAL = null;

        public TelasBLL()
        { }

        public void limpar()
        {
            this.per_codigo = 0;
            this.ct_nome = null;
            this.ct_status = null;
            this.ct_name = null;
        }

        public void inserir()
        {
            try
            {
                objDAL = new TelasDAL();
                objDAL.inserir(this.ct_nome, this.per_codigo,this.ct_status,this.ct_name);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void excluir()
        {
            try
            {
                objDAL = new TelasDAL();
                objDAL.excluir(this.per_codigo);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizar()
        {
            try
            {
                objDAL = new TelasDAL();
                this.per_codigo= objDAL.localizar(this.ct_nome);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizar(String descricao, String atributo)
        {

            try
            {
                DataTable tab;
                objDAL = new TelasDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.ct_nome = tab.Rows[0]["ct_nome"].ToString();
                    this.ct_status = tab.Rows[0]["ct_status"].ToString();
                    this.ct_name = tab.Rows[0]["ct_name"].ToString();
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable localizarComRetorno(String descricao, String atributo)
        {
            try
            {
                DataTable tab;
                objDAL = new TelasDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
