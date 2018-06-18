using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class CentroDeCustoBLL
    {
        public int ccs_codigo { get; set; }
        public String ccs_descricao { get; set; }

        CentroDeCustoDAL objDAL = null;

        public CentroDeCustoBLL()
        { }

        public void limpar()
        {
            this.ccs_codigo = 0;
            this.ccs_descricao = null;
        }

        public void inserir()
        {
            try
            {
                objDAL = new CentroDeCustoDAL();
                objDAL.InserirCentroDeCusto(this.ccs_descricao);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void alterar()
        {
            try
            {
                objDAL = new CentroDeCustoDAL();
                objDAL.alterar(this.ccs_codigo, this.ccs_descricao);
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
                objDAL = new CentroDeCustoDAL();
                objDAL.excluir(this.ccs_codigo);
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
                objDAL = new CentroDeCustoDAL();
                this.ccs_codigo= objDAL.localizar(this.ccs_codigo);
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
                objDAL = new CentroDeCustoDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.ccs_codigo = int.Parse(tab.Rows[0]["ccs_codigo"].ToString());
                    this.ccs_descricao = tab.Rows[0]["ccs_descricao"].ToString();
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
                objDAL = new CentroDeCustoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.ccs_codigo = int.Parse(tab.Rows[0]["ccs_codigo"].ToString());
                    this.ccs_descricao = tab.Rows[0]["ccs_descricao"].ToString();
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
                objDAL = new CentroDeCustoDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarEmTudo(String descricao)
        {
            try
            {
                DataTable tab;
                objDAL = new CentroDeCustoDAL();

                tab = objDAL.LocalizarEmTudo(descricao);

                objDAL = null;

                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizarPrimeiroUltimo(String descricao)
        {
            try
            {
                DataTable tab = null;
                int codigo=0;
                objDAL = new CentroDeCustoDAL();
                tab = objDAL.LocalizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(),out codigo);
                this.ccs_codigo = codigo;
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void localizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                DataTable tab = null;
                objDAL = new CentroDeCustoDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.ccs_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
