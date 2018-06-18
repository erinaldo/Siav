using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class UnidadesBLL
    {
        public int uni_codigo { get; set; }
        public String uni_descricao { get; set; }

        UnidadesDAL objDAL = null;

        public UnidadesBLL()
        { }

        public void limpar()
        {
            try
            {
                this.uni_codigo = 0;
                this.uni_descricao = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void inserir()
        {
            try
            {
                objDAL = new UnidadesDAL();
                objDAL.inserir(this.uni_descricao);
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
                objDAL = new UnidadesDAL();
                objDAL.alterar(this.uni_codigo, this.uni_descricao);
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
                objDAL = new UnidadesDAL();
                objDAL.excluir(this.uni_codigo);
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
                objDAL = new UnidadesDAL();
                this.uni_codigo = objDAL.localizar(this.uni_codigo);
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
                objDAL = new UnidadesDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.uni_codigo = int.Parse(tab.Rows[0]["uni_codigo"].ToString());
                    this.uni_descricao = tab.Rows[0]["uni_descricao"].ToString();
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
                objDAL = new UnidadesDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.uni_codigo = int.Parse(tab.Rows[0]["uni_codigo"].ToString());
                    this.uni_descricao = tab.Rows[0]["uni_descricao"].ToString();
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
                objDAL = new UnidadesDAL();
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
                objDAL = new UnidadesDAL();
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
                objDAL = new UnidadesDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.uni_codigo = codigo;
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
                objDAL = new UnidadesDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.uni_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
