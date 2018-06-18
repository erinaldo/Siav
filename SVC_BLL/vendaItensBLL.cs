using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class vendaItensBLL
    {
        public int ven_codigo { get; set; }
        public int pro_codigo { get; set; }
        public decimal vi_quantidade { get; set; }
        public decimal vi_valorUnitario { get; set; }
        public decimal vi_subtotal { get; set; }
        public decimal vi_desconto { get; set; }
        public decimal vi_percentual { get; set; }
        public int vi_mesGarantia { get; set; }
        public string vi_tara { get; set; }

        vendaItensDAL objDAL = new vendaItensDAL();

        public vendaItensBLL()
        {}

        public void limpar()
        {
            try 
	        {
                this.ven_codigo = 0;
                this.pro_codigo = 0;
                this.vi_quantidade = 0;
                this.vi_valorUnitario = 0;
                this.vi_subtotal = 0;
                this.vi_desconto = 0;
                this.vi_percentual = 0;
                this.vi_mesGarantia = 0;
                this.vi_tara = "";
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
                objDAL = new vendaItensDAL();
                objDAL.inserir(this.ven_codigo, this.pro_codigo, this.vi_quantidade, this.vi_valorUnitario, this.vi_subtotal, this.vi_desconto, this.vi_percentual, this.vi_mesGarantia , this.vi_tara);
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
                objDAL = new vendaItensDAL();
                objDAL.alterar(this.ven_codigo, this.pro_codigo, this.vi_quantidade, this.vi_valorUnitario, this.vi_subtotal, this.vi_desconto, this.vi_percentual, this.vi_mesGarantia,this.vi_tara);
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
                objDAL = new vendaItensDAL();
                objDAL.excluir(this.ven_codigo);
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
                objDAL = new vendaItensDAL();
                this.ven_codigo = objDAL.localizar(this.ven_codigo);
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
                objDAL = new vendaItensDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.ven_codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.pro_codigo = int.Parse(tab.Rows[0]["pro_codigo"].ToString());
                    this.vi_quantidade = decimal.Parse(tab.Rows[0]["vi_quantidade"].ToString());
                    this.vi_valorUnitario = decimal.Parse(tab.Rows[0]["vi_valorUnitario"].ToString());
                    this.vi_subtotal = decimal.Parse(tab.Rows[0]["vi_subtotal"].ToString());
                    this.vi_desconto = decimal.Parse(tab.Rows[0]["vi_desconto"].ToString());
                    this.vi_percentual = decimal.Parse(tab.Rows[0]["vi_percentual"].ToString());
                    this.vi_mesGarantia = int.Parse(tab.Rows[0]["vi_MesGarantia"].ToString());
                    this.vi_tara = (tab.Rows[0]["vi_tara"].ToString());
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
                objDAL = new vendaItensDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.ven_codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.pro_codigo = int.Parse(tab.Rows[0]["pro_codigo"].ToString());
                    this.vi_quantidade = decimal.Parse(tab.Rows[0]["vi_quantidade"].ToString());
                    this.vi_valorUnitario = decimal.Parse(tab.Rows[0]["vi_valorUnitario"].ToString());
                    this.vi_subtotal = decimal.Parse(tab.Rows[0]["vi_subtotal"].ToString());
                    this.vi_desconto = decimal.Parse(tab.Rows[0]["vi_desconto"].ToString());
                    this.vi_percentual = decimal.Parse(tab.Rows[0]["vi_percentual"].ToString());
                    this.vi_mesGarantia = int.Parse(tab.Rows[0]["vi_MesGarantia"].ToString());
                    this.vi_tara = (tab.Rows[0]["vi_tara"].ToString());
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizarProdutoDaVenda(int codigoCompra, int codigoProduto)
        {

            try
            {
                DataTable tab;
                objDAL = new vendaItensDAL();
                tab = objDAL.localizarProdutoDaCompra(codigoCompra, codigoProduto);
                if (tab.Rows.Count > 0)
                {
                    this.ven_codigo = int.Parse(tab.Rows[0]["ven_codigo"].ToString());
                    this.pro_codigo = int.Parse(tab.Rows[0]["pro_codigo"].ToString());
                    this.vi_quantidade = decimal.Parse(tab.Rows[0]["vi_quantidade"].ToString());
                    this.vi_valorUnitario = decimal.Parse(tab.Rows[0]["vi_valorUnitario"].ToString());
                    this.vi_subtotal = decimal.Parse(tab.Rows[0]["vi_subtotal"].ToString());
                    this.vi_desconto = decimal.Parse(tab.Rows[0]["vi_desconto"].ToString());
                    this.vi_percentual = decimal.Parse(tab.Rows[0]["vi_percentual"].ToString());
                    this.vi_mesGarantia = int.Parse(tab.Rows[0]["vi_MesGarantia"].ToString());
                    this.vi_tara = (tab.Rows[0]["vi_tara"].ToString());
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
                objDAL = new vendaItensDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarLeaveComRetorno(String descricao, String atributo)
        {
            try
            {
                DataTable tab;
                objDAL = new vendaItensDAL();
                tab = objDAL.localizarLeaveComRetorno(descricao, atributo);
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
                objDAL = new vendaItensDAL();
                tab = objDAL.localizarEmTudo(descricao);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
