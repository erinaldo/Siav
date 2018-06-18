using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class CategoriaBLL
    {
        public int cat_codigo { get; set; }
        public String cat_descricao { get; set; }

        CategoriaDAL objDAL = null;

        public CategoriaBLL()
        { }

        public void limpar()
        {
            this.cat_codigo = 0;
            this.cat_descricao = null;
        }

        public void inserir()
        {
            try
            {
                objDAL = new CategoriaDAL();
                objDAL.InserirCategoria(this.cat_descricao);
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
                objDAL = new CategoriaDAL();
                objDAL.alterar(this.cat_codigo, this.cat_descricao);
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
                objDAL = new CategoriaDAL();
                objDAL.excluir(this.cat_codigo);
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
                objDAL = new CategoriaDAL();
                this.cat_codigo= objDAL.localizar(this.cat_codigo);
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
                objDAL = new CategoriaDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cat_codigo = int.Parse(tab.Rows[0]["cat_codigo"].ToString());
                    this.cat_descricao = tab.Rows[0]["cat_descricao"].ToString();
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
                objDAL = new CategoriaDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cat_codigo = int.Parse(tab.Rows[0]["cat_codigo"].ToString());
                    this.cat_descricao = tab.Rows[0]["cat_descricao"].ToString();
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
                objDAL = new CategoriaDAL();
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
                objDAL = new CategoriaDAL();

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
                objDAL = new CategoriaDAL();
                tab = objDAL.LocalizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(),out codigo);
                this.cat_codigo = codigo;
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
                objDAL = new CategoriaDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.cat_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
