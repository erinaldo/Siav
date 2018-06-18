using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class FormaPagamentoBLL
    {
        public int fp_codigo { get; set; }
        public String fp_descricao { get; set; }

        FormaPagamentoDAL objDAL = null;

        public FormaPagamentoBLL()
        { }

        public void limpar()
        {
            try
            {
                this.fp_codigo = 0;
                this.fp_descricao = null;
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
                objDAL = new FormaPagamentoDAL();
                objDAL.inserir(this.fp_descricao);
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
                objDAL = new FormaPagamentoDAL();
                objDAL.alterar(this.fp_codigo, this.fp_descricao);
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
                objDAL = new FormaPagamentoDAL();
                objDAL.excluir(this.fp_codigo);
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
                objDAL = new FormaPagamentoDAL();
                this.fp_codigo = objDAL.localizar(this.fp_codigo);
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
                objDAL = new FormaPagamentoDAL();
                tab = objDAL.localizar(descricao, atributo);

                if (tab.Rows.Count > 0)
                {
                    this.fp_codigo = int.Parse(tab.Rows[0]["fp_codigo"].ToString());
                    this.fp_descricao = tab.Rows[0]["fp_descricao"].ToString();
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
                objDAL = new FormaPagamentoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.fp_codigo = int.Parse(tab.Rows[0]["fp_codigo"].ToString());
                    this.fp_descricao = tab.Rows[0]["fp_descricao"].ToString();
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
                    objDAL = new FormaPagamentoDAL();
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
                objDAL = new FormaPagamentoDAL();
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
                objDAL = new FormaPagamentoDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(),out codigo);
                this.fp_codigo = codigo;
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
                objDAL = new FormaPagamentoDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.fp_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
