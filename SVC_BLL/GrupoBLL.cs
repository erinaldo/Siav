using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;
namespace One.Bll
{
    public class GrupoBLL
    {
        public int gru_codigo { get; set; }
        public String gru_descricao { get; set; }

        GrupoDAL objDAL = null;

        public GrupoBLL()
        { }

        public void limpar()
        {
            try
            {
                this.gru_codigo = 0;
                this.gru_descricao = null;
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
                objDAL = new GrupoDAL();
                objDAL.inserir(this.gru_descricao);
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
                objDAL = new GrupoDAL();
                objDAL.alterar(this.gru_codigo, this.gru_descricao);
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
                objDAL = new GrupoDAL();
                objDAL.excluir(this.gru_codigo);
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
                objDAL = new GrupoDAL();
                this.gru_codigo = objDAL.localizar(this.gru_codigo);
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
                objDAL = new GrupoDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.gru_codigo = int.Parse(tab.Rows[0]["gru_codigo"].ToString());
                    this.gru_descricao = tab.Rows[0]["gru_descricao"].ToString();
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
                objDAL = new GrupoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.gru_codigo = int.Parse(tab.Rows[0]["gru_codigo"].ToString());
                    this.gru_descricao = tab.Rows[0]["gru_descricao"].ToString();
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
                objDAL = new GrupoDAL();
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
                objDAL = new GrupoDAL();
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
                objDAL = new GrupoDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(),out codigo);
                this.gru_codigo = codigo;
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
                objDAL = new GrupoDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.gru_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
