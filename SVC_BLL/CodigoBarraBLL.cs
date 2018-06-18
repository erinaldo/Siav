using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class CodigoBarraBLL
    {
        public String pro_codigoBarra { get; set; }
        public Decimal pro_precoVenda { get; set; }
        public String pro_nome { get; set; }

        public void codigoBarraBLL(){
        
        }

        CodigoBarraDAL objDAL = null;

        public void limpar()
        {
            try
            {
                this.pro_codigoBarra = null;
                this.pro_precoVenda = 0;
                this.pro_nome = null;
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
                objDAL = new CodigoBarraDAL();
                objDAL.inserir(this.pro_codigoBarra, this.pro_precoVenda,this.pro_nome);
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
                objDAL = new CodigoBarraDAL();
                objDAL.alterar(this.pro_codigoBarra, this.pro_precoVenda, this.pro_nome);
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
                objDAL = new CodigoBarraDAL();
                objDAL.excluir(this.pro_codigoBarra);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void localizar()
        //{
        //    try
        //    {
        //        objDAL = new CodigoBarraDAL();
        //        this.cb_codigo = objDAL.localizar(this.cb_codigo);
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void localizar(String descricao, String atributo)
        //{

        //    try
        //    {
        //        DataTable tab;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizar(descricao, atributo);
        //        if (tab.Rows.Count > 0)
        //        {
        //            this.cb_codigo = int.Parse(tab.Rows[0]['cb_codigo'].ToString());
        //            this.cb_codigoBarra= tab.Rows[0]['cb_codigoBarra'].ToString();
        //            this.cb_numeroLote = int.Parse(tab.Rows[0]['cb_numeroLote'].ToString());
        //            this.cb_dataCriacao = DateTime.Parse(tab.Rows[0]['cb_dataCriaca'].ToString());
        //        }
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void localizarLeave(String descricao, String atributo)
        //{

        //    try
        //    {
        //        DataTable tab;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizarLeave(descricao, atributo);
        //        if (tab.Rows.Count > 0)
        //        {
        //            this.cb_codigo = int.Parse(tab.Rows[0]['cb_codigo'].ToString());
        //            this.cb_codigoBarra= tab.Rows[0]['cb_codigoBarra'].ToString();
        //            this.cb_numeroLote = int.Parse(tab.Rows[0]['cb_numeroLote'].ToString());
        //            this.cb_dataCriacao = DateTime.Parse(tab.Rows[0]['cb_dataCriaca'].ToString());
        //        }
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public DataTable localizarComRetorno(String descricao, String atributo)
        //{
        //    try
        //    {
        //        DataTable tab;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizar(descricao, atributo);
        //        objDAL = null;
        //        return tab;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public DataTable localizarEmTudo(String descricao)
        //{
        //    try
        //    {
        //        DataTable tab;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizarEmTudo(descricao);
        //        objDAL = null;
        //        return tab;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public void localizarPrimeiroUltimo(String descricao)
        //{
        //    try
        //    {
        //        DataTable tab = null;
        //        int codigo = 0;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizarPrimeiroUltimo(descricao);
        //        if (tab.Rows.Count > 0)
        //            int.TryParse(tab.Rows[0][0].ToString(), out codigo);
        //        this.cb_codigo = codigo;
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //public void localizarProxAnterior(String descricao, int codigo)
        //{
        //    try
        //    {
        //        DataTable tab = null;
        //        objDAL = new CodigoBarraDAL();
        //        tab = objDAL.localizarProxAnterior(descricao, codigo);
        //        if (tab.Rows.Count > 0)
        //            this.cb_codigo = int.Parse(tab.Rows[0][0].ToString());
        //        objDAL = null;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
