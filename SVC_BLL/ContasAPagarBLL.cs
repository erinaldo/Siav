using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class ContasAPagarBLL
    {
        public int cp_codigo { get; set; }
        public int cp_compras { get; set; }
        public String cp_titulo { get; set; }
        public String cp_serie { get; set; }
        public DateTime cp_emissao { get; set; }
        public DateTime cp_vencimento { get; set; }
        public decimal cp_valor { get; set; }
        public String cp_status { get; set; }
        public String cp_observacao { get; set; }
        public int cp_fornecedor { get; set; }
        public DateTime? cp_dataPagamento { get; set; }
        public int TipoDeOperacaoID { get; set; }
        public int FormaDePagamentoID { get; set; }
        public int PrazoID { get; set; }
        ContasAPagarDAL objDAL = null;

        public ContasAPagarBLL()
        {}

        public void limpar()
        {
            try
            {
                this.cp_emissao = DateTime.Now;
                this.cp_observacao = null;
                this.cp_serie = null;
                this.cp_status= null;
                this.cp_titulo = null;
                this.cp_vencimento = DateTime.Now;
                this.cp_codigo = 0;
                this.cp_compras = 0;
                this.cp_valor = 0;
                this.cp_fornecedor = 0;
                this.cp_dataPagamento = null;
                this.PrazoID = 0;
                this.FormaDePagamentoID = 0;
                this.TipoDeOperacaoID = 0;

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
                objDAL = new ContasAPagarDAL();
                objDAL.inserir(this.cp_compras, this.cp_titulo, this.cp_serie, this.cp_emissao, this.cp_vencimento, this.cp_valor, this.cp_status, this.cp_observacao,this.cp_fornecedor,this.cp_dataPagamento,this.TipoDeOperacaoID, this.FormaDePagamentoID,this.PrazoID);
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
                objDAL = new ContasAPagarDAL();
                objDAL.alterar(this.cp_codigo, this.cp_compras, this.cp_titulo, this.cp_serie, this.cp_emissao, this.cp_vencimento, this.cp_valor, this.cp_status, this.cp_observacao, this.cp_fornecedor, this.cp_dataPagamento, this.TipoDeOperacaoID, this.FormaDePagamentoID, this.PrazoID);
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
                objDAL = new ContasAPagarDAL();
                objDAL.excluir(this.cp_codigo);
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
                objDAL = new ContasAPagarDAL();
                this.cp_codigo = objDAL.localizar(this.cp_codigo);
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
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {                       
                    this.cp_codigo = int.Parse(tab.Rows[0]["cp_codigo"].ToString());
                    if (tab.Rows[0]["cp_compras"] == DBNull.Value)
                        this.cp_compras = 0;
                    else
                        this.cp_compras = int.Parse(tab.Rows[0]["cp_compras"].ToString());
                    this.cp_titulo = tab.Rows[0]["cp_titulo"].ToString();
                    this.cp_serie = tab.Rows[0]["cp_serie"].ToString();
                    this.cp_emissao = DateTime.Parse(tab.Rows[0]["cp_emissao"].ToString());
                    this.cp_vencimento = DateTime.Parse(tab.Rows[0]["cp_vencimento"].ToString());
                    this.cp_valor = decimal.Parse(tab.Rows[0]["cp_valor"].ToString());
                    this.cp_status = tab.Rows[0]["cp_status"].ToString();
                    this.cp_observacao = tab.Rows[0]["cp_observacao"].ToString();
                    this.cp_fornecedor = int.Parse(tab.Rows[0]["cp_fornecedor"].ToString());
                    if (tab.Rows[0]["cp_dataPagamento"] == DBNull.Value)
                        this.cp_dataPagamento = null;
                    else
                        this.cp_dataPagamento = DateTime.Parse(tab.Rows[0]["cp_dataPagamento"].ToString());

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
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.cp_codigo = int.Parse(tab.Rows[0]["cp_codigo"].ToString());
                    if (tab.Rows[0]["cp_compras"] == DBNull.Value)
                        this.cp_compras = 0;
                    else
                        this.cp_compras = int.Parse(tab.Rows[0]["cp_compras"].ToString());
                    this.cp_titulo = tab.Rows[0]["cp_titulo"].ToString();
                    this.cp_serie = tab.Rows[0]["cp_serie"].ToString();
                    this.cp_emissao = DateTime.Parse(tab.Rows[0]["cp_emissao"].ToString());
                    this.cp_vencimento = DateTime.Parse(tab.Rows[0]["cp_vencimento"].ToString());
                    this.cp_valor = decimal.Parse(tab.Rows[0]["cp_valor"].ToString());
                    this.cp_status = tab.Rows[0]["cp_status"].ToString();
                    this.cp_observacao = tab.Rows[0]["cp_observacao"].ToString();
                    this.cp_fornecedor = int.Parse(tab.Rows[0]["cp_fornecedor"].ToString());
                    if (tab.Rows[0]["cp_dataPagamento"] == DBNull.Value)
                        this.cp_dataPagamento = null;
                    else
                        this.cp_dataPagamento = DateTime.Parse(tab.Rows[0]["cp_dataPagamento"].ToString());
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
                objDAL = new ContasAPagarDAL();
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
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizarEmTudo(descricao);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarComFiltro(int codigo, DateTime? dataInicial, DateTime? dataFinal)
        {
            try
            {
                DataTable tab;
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizarComFiltro(codigo, dataInicial, dataFinal);
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
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.cp_codigo = codigo;
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
                objDAL = new ContasAPagarDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.cp_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
