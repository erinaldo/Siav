using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class SubGrupoBLL
    {
        public int sg_codigo { get; set; }
        public String sg_descricao { get; set; }
        public int sg_grupo { get; set; }

        SubGrupoDAL objDAL = null;

        public SubGrupoBLL()
        { }

        public void limpar()
        {
            try
            {
                this.sg_codigo = 0;
                this.sg_descricao = null;
                this.sg_grupo = 0;
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
                objDAL = new SubGrupoDAL();
                objDAL.inserir(this.sg_descricao, this.sg_grupo);
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
                objDAL = new SubGrupoDAL();
                objDAL.alterar(this.sg_codigo, this.sg_descricao, this.sg_grupo);
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
                objDAL = new SubGrupoDAL();
                objDAL.excluir(this.sg_codigo);
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
                objDAL = new SubGrupoDAL();
                this.sg_codigo = objDAL.localizar(this.sg_codigo);
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
                objDAL = new SubGrupoDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.sg_codigo = int.Parse(tab.Rows[0]["sg_codigo"].ToString());
                    this.sg_descricao = tab.Rows[0]["sg_descricao"].ToString();
                    this.sg_grupo = int.Parse(tab.Rows[0]["sg_grupo"].ToString());
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
                objDAL = new SubGrupoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.sg_codigo = int.Parse(tab.Rows[0]["sg_codigo"].ToString());
                    this.sg_descricao = tab.Rows[0]["sg_descricao"].ToString();
                    this.sg_grupo = int.Parse(tab.Rows[0]["sg_grupo"].ToString());
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
                objDAL = new SubGrupoDAL();
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
                objDAL = new SubGrupoDAL();
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
                objDAL = new SubGrupoDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.sg_codigo = codigo;
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
                objDAL = new SubGrupoDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.sg_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
