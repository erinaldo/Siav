using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class PermissaoBLL
    {
        public int per_codigo { get; set; }
        public String per_nome { get; set; }

        PermissaoDAL objDAL = null;

        public PermissaoBLL()
        { }

        public void limpar()
        {
            this.per_codigo = 0;
            this.per_nome = null;
        }

        public void inserir()
        {
            try
            {
                objDAL = new PermissaoDAL();
                objDAL.inserir(this.per_codigo , this.per_nome);
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
                objDAL = new PermissaoDAL();
                objDAL.alterar(this.per_codigo, this.per_nome);
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
                objDAL = new PermissaoDAL();
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
                objDAL = new PermissaoDAL();
                this.per_codigo= objDAL.localizar(this.per_codigo);
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
                objDAL = new PermissaoDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.per_nome = tab.Rows[0]["per_nome"].ToString();
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
                objDAL = new PermissaoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.per_nome = tab.Rows[0]["per_nome"].ToString();
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
                objDAL = new PermissaoDAL();
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
                objDAL = new PermissaoDAL();
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
                int codigo=0;
                objDAL = new PermissaoDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(),out codigo);
                this.per_codigo = codigo;
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
                objDAL = new PermissaoDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.per_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
