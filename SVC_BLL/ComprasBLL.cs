using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Bll;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class ComprasBLL
    {
        public int com_codigo { get; set; }
        public DateTime com_dataCompra { get; set; }
        public int com_usario { get; set; }
        public int com_fornecedor { get; set; }
        //public int com_formaPagamento { get; set; }
        public decimal com_quantidade { get; set; }
        public decimal com_valorTotal { get; set; }
        public String com_observacao { get; set; }
        public String com_status { get; set; }
        public int com_numPedido { get; set; }

        ComprasDAL objDAL = new ComprasDAL();

        public ComprasBLL()
        { }

        public void limpar()
        {
            try
            {
                this.com_codigo = 0;
                this.com_dataCompra = DateTime.Now;
                this.com_usario = 0;
                this.com_fornecedor = 0;
                //this.com_formaPagamento = 0;
                //this.com_quantidade = 0;
                this.com_observacao = null;
                this.com_status = null;
                this.com_numPedido = 0;
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
                objDAL = new ComprasDAL();
                this.com_codigo = objDAL.inserir(this.com_dataCompra, this.com_usario, this.com_fornecedor,this.com_quantidade, this.com_valorTotal, this.com_observacao,this.com_numPedido);
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
                objDAL = new ComprasDAL();
                objDAL.alterar(this.com_codigo, this.com_dataCompra, this.com_usario, this.com_fornecedor, this.com_quantidade, this.com_valorTotal, this.com_observacao, this.com_status,this.com_numPedido);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void alterarEntradaMercadoria()
        {
            try
            {
                objDAL = new ComprasDAL();
                objDAL.alterar(this.com_codigo, this.com_valorTotal);
                objDAL = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void cancelarCompra()
        {
            try
            {
                objDAL = new ComprasDAL();
                objDAL.cancelarCompra(this.com_codigo,this.com_status);
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
                objDAL = new ComprasDAL();
                objDAL.excluir(this.com_codigo);
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
                objDAL = new ComprasDAL();
                this.com_codigo = objDAL.localizar(this.com_codigo);
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
                objDAL = new ComprasDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.com_codigo = int.Parse(tab.Rows[0]["com_codigo"].ToString());
                    this.com_dataCompra = DateTime.Parse(tab.Rows[0]["com_dataCompra"].ToString());
                    this.com_usario = int.Parse(tab.Rows[0]["com_usuario"].ToString());
                    this.com_fornecedor = int.Parse(tab.Rows[0]["com_fornecedor"].ToString());
                    //this.com_formaPagamento = int.Parse(tab.Rows[0]["com_formaPagamento"].ToString());
                    this.com_quantidade = decimal.Parse(tab.Rows[0]["com_quantidade"].ToString());
                    this.com_valorTotal = decimal.Parse(tab.Rows[0]["com_valorTotal"].ToString());
                    this.com_observacao = tab.Rows[0]["com_observacao"].ToString();
                    this.com_status = tab.Rows[0]["com_status"].ToString();
                    if (tab.Rows[0]["com_numPedido"] == DBNull.Value)
                        this.com_numPedido = 0;
                    else
                        this.com_numPedido = int.Parse(tab.Rows[0]["com_numPedido"].ToString());
                    
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
                objDAL = new ComprasDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.com_codigo = int.Parse(tab.Rows[0]["com_codigo"].ToString());
                    this.com_dataCompra = DateTime.Parse(tab.Rows[0]["com_dataCompra"].ToString());
                    this.com_usario = int.Parse(tab.Rows[0]["com_usuario"].ToString());
                    this.com_fornecedor = int.Parse(tab.Rows[0]["com_fornecedor"].ToString());
                    //this.com_formaPagamento = int.Parse(tab.Rows[0]["com_formaPagamento"].ToString());
                    this.com_quantidade = int.Parse(tab.Rows[0]["com_quantidade"].ToString());
                    this.com_valorTotal = decimal.Parse(tab.Rows[0]["com_valorTotal"].ToString());
                    this.com_observacao = tab.Rows[0]["com_observacao"].ToString();
                    this.com_status = tab.Rows[0]["com_status"].ToString();
                    if (tab.Rows[0]["com_numPedido"] == DBNull.Value)
                        this.com_numPedido = 0;
                    else
                        this.com_numPedido = int.Parse(tab.Rows[0]["com_numPedido"].ToString());
                    
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
                objDAL = new ComprasDAL();
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
                objDAL = new ComprasDAL();
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
                objDAL = new ComprasDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.com_codigo = codigo;
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
                objDAL = new ComprasDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.com_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
