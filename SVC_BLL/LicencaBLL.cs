using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;
namespace One.Bll
{
    public class LicencaBLL
    {
        public int lic_codigo { get; set; }
        public String lic_chave { get; set; }
        public DateTime? lic_data{ get; set; }

        LicencaDAL objDAL = null;

        public LicencaBLL()
        { }

        public void limpar()
        {
            this.lic_codigo = 0;
            this.lic_chave= null;
            this.lic_data= null;
        }

        public void inserir()
        {
            try
            {
                objDAL = new LicencaDAL();
                objDAL.inserir(this.lic_chave, this.lic_data.ToString());
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
                objDAL = new LicencaDAL();
                this.lic_codigo = objDAL.localizar(this.lic_codigo);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable localizar(String descricao, String atributo)
        {

            try
            {
                DataTable tab;
                objDAL = new LicencaDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizarLicenca(String descricao, String atributo)
        {

            try
            {
                DataTable tab;
                objDAL = new LicencaDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.lic_codigo = int.Parse(tab.Rows[0]["lic_codigo"].ToString());
                    this.lic_chave = tab.Rows[0]["lic_chave"].ToString();
                    this.lic_data = DateTime.Parse(tab.Rows[0]["lic_data"].ToString());
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizarLeave(String descricao, String atributo)
        {

            try
            {
                DataTable tab;
                objDAL = new LicencaDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.lic_codigo = int.Parse(tab.Rows[0]["lic_codigo"].ToString());
                    this.lic_chave = tab.Rows[0]["lic_chave"].ToString();
                    this.lic_data = DateTime.Parse(tab.Rows[0]["lic_data"].ToString());
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
