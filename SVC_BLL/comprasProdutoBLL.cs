using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class comprasProdutoBLL
    {
        public int cp_produtos { get; set; }
        public int cp_compras { get; set; }
        public decimal cp_valorUnitario { get; set; }
        public decimal cp_quantidade { get; set; }
        public decimal cp_subtotal { get; set; }
        public String cp_chegou { get; set; }

        comprasProdutoDAL objDAL = new comprasProdutoDAL();

        public comprasProdutoBLL()
        {}

        public void limpar()
        {
            try 
	        {
                this.cp_produtos = 0;
                this.cp_compras = 0;
               // this.cp_valorUnitario = 0;
                this.cp_quantidade = 0;
                this.cp_subtotal = 0;
                this.cp_chegou = null;
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
                objDAL = new comprasProdutoDAL();
                objDAL.inserir(this.cp_compras,this.cp_produtos,this.cp_valorUnitario,this.cp_quantidade,this.cp_subtotal);
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
                objDAL = new comprasProdutoDAL();
                objDAL.alterar(this.cp_compras, this.cp_produtos, this.cp_valorUnitario, this.cp_quantidade, this.cp_subtotal,this.cp_chegou);
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
                objDAL = new comprasProdutoDAL();
                objDAL.excluir(this.cp_compras);
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
                objDAL = new comprasProdutoDAL();
                this.cp_compras= objDAL.localizar(this.cp_compras);
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
                objDAL = new comprasProdutoDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cp_compras = int.Parse(tab.Rows[0]["cp_compras"].ToString());
                    this.cp_produtos = int.Parse(tab.Rows[0]["cp_produtos"].ToString());
                    this.cp_valorUnitario = decimal.Parse(tab.Rows[0]["cp_valorUnitario"].ToString());
                    this.cp_quantidade = int.Parse(tab.Rows[0]["cp_quantidade"].ToString());
                    this.cp_subtotal = decimal.Parse(tab.Rows[0]["cp_subtotal"].ToString());
                    this.cp_chegou = tab.Rows[0]["cp_chegou"].ToString();
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
                objDAL = new comprasProdutoDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cp_compras = int.Parse(tab.Rows[0]["cp_compras"].ToString());
                    this.cp_produtos = int.Parse(tab.Rows[0]["cp_produtos"].ToString());
                    this.cp_valorUnitario = decimal.Parse(tab.Rows[0]["cp_valorUnitario"].ToString());
                    this.cp_quantidade = decimal.Parse(tab.Rows[0]["cp_quantidade"].ToString());
                    this.cp_subtotal = decimal.Parse(tab.Rows[0]["cp_subtotal"].ToString());                    
                    this.cp_chegou = tab.Rows[0]["cp_chegou"].ToString();
                }
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void localizarProdutoDaCompra(int codigoCompra, int codigoProduto)
        {

            try
            {
                DataTable tab;
                objDAL = new comprasProdutoDAL();
                tab = objDAL.localizarProdutoDaCompra(codigoCompra, codigoProduto);
                if (tab.Rows.Count > 0)
                {
                    this.cp_compras = int.Parse(tab.Rows[0]["cp_compras"].ToString());
                    this.cp_produtos = int.Parse(tab.Rows[0]["cp_produtos"].ToString());
                    this.cp_valorUnitario = decimal.Parse(tab.Rows[0]["cp_valorUnitario"].ToString());
                    this.cp_quantidade = decimal.Parse(tab.Rows[0]["cp_quantidade"].ToString());
                    this.cp_subtotal = decimal.Parse(tab.Rows[0]["cp_subtotal"].ToString());
                    this.cp_chegou = tab.Rows[0]["cp_chegou"].ToString();
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
                objDAL = new comprasProdutoDAL();
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
                objDAL = new comprasProdutoDAL();
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
