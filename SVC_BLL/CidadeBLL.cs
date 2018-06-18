using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class CidadeBLL{

        public int cid_codigo { get; set; }
        public String cid_nome { get; set; }
        public int cid_estado { get; set; }

        CidadeDAL objDAL = null;

        public CidadeBLL(){
        }

        public void limpar()
        {
            this.cid_codigo = 0;
            this.cid_nome = null;
            this.cid_estado = 0;
        }

        public void inserir()
        {
            try
            {
                objDAL = new CidadeDAL();
                objDAL.inserir(this.cid_nome, this.cid_estado);
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
                objDAL = new CidadeDAL();
                objDAL.alterar(this.cid_codigo, this.cid_nome, this.cid_estado);
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
                objDAL = new CidadeDAL();
                objDAL.excluir(this.cid_codigo);
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
                objDAL = new CidadeDAL();
                this.cid_codigo = objDAL.localizar(this.cid_codigo);
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
                objDAL = new CidadeDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cid_codigo = int.Parse(tab.Rows[0]["cid_codigo"].ToString());
                    this.cid_nome = tab.Rows[0]["cid_nome"].ToString();
                    this.cid_estado= int.Parse(tab.Rows[0]["cid_estado"].ToString());
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
                objDAL = new CidadeDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cid_codigo = int.Parse(tab.Rows[0]["cid_codigo"].ToString());
                    this.cid_nome = tab.Rows[0]["cid_nome"].ToString();
                    this.cid_estado = int.Parse(tab.Rows[0]["cid_estado"].ToString());
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
                objDAL = new CidadeDAL();
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
                objDAL = new CidadeDAL();
                tab = objDAL.localizarEmTudo(descricao);
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
                int codigo = 0;
                objDAL = new CidadeDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.cid_codigo = codigo;
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
                objDAL = new CidadeDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.cid_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
