using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class ContasAReceberBLL
    {
        public int codigo { get; set; }
        public int vendas { get; set; }
        public int formaPagamento { get; set; }
        public DateTime vencimento { get; set; }
        public Decimal original { get; set; }
        public Decimal alterado { get; set; }
        public Decimal pago { get; set; }
        public String status { get; set; }
        public DateTime? pagamento { get; set; }
        public Decimal juros { get; set; }
        public Decimal desconto { get; set; }
        public String observacao { get; set; }
        public String parcela { get; set; }
        public Decimal? cr_valorRestante { get; set; }
        public Decimal? cr_multa { get; set; }

        ContasAReceberDAL objDAL = null;

        public ContasAReceberBLL()
        {}

        public void limpar()
        {
            try
            {
                this.alterado = 0;
                this.codigo = 0;
                this.formaPagamento = 0;
                this.desconto = 0;
                this.juros = 0;
                this.observacao = null;
                this.original = 0;
                this.pagamento = DateTime.Now;
                this.pago = 0;
                this.parcela = null;
                this.status = null;
                this.vencimento = DateTime.Now;
                this.vendas = 0;
                this.cr_valorRestante = 0;
                this.cr_multa = 0;
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
                objDAL = new ContasAReceberDAL();
                this.codigo = objDAL.inserir(this.vendas, this.vencimento, this.formaPagamento, this.original, this.alterado, this.pago, this.status, this.pagamento, this.juros, this.desconto, this.observacao, this.parcela, this.cr_valorRestante, this.cr_multa);
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
                objDAL = new ContasAReceberDAL();
                objDAL.alterar(this.codigo, this.vendas, this.vencimento, this.formaPagamento, this.original, this.alterado, this.pago, this.status, this.pagamento, this.juros, this.desconto, this.observacao, this.parcela, this.cr_valorRestante, this.cr_multa);
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
                objDAL = new ContasAReceberDAL();
                objDAL.excluir(this.codigo);
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void excluirVenda()
        {
            try
            {
                objDAL = new ContasAReceberDAL();
                objDAL.excluirVendas(this.vendas);
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
                objDAL = new ContasAReceberDAL();
                this.codigo = objDAL.localizar(this.codigo);
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
                objDAL = new ContasAReceberDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["cr_codigo"].ToString());
                    this.vendas = int.Parse(tab.Rows[0]["cr_vendas"].ToString());
                    this.formaPagamento = int.Parse(tab.Rows[0]["cr_formaPagamento"].ToString());
                    this.vencimento = DateTime.Parse(tab.Rows[0]["cr_dataVencimento"].ToString());
                    this.original = Decimal.Parse(tab.Rows[0]["cr_valorOriginal"].ToString());
                    this.alterado = Decimal.Parse(tab.Rows[0]["cr_valorAlterado"].ToString());
                    this.pago = Decimal.Parse(tab.Rows[0]["cr_valorPago"].ToString());
                    this.status = tab.Rows[0]["cr_status"].ToString();
                    if (tab.Rows[0]["cr_dataPagamento"] != DBNull.Value)
                        this.pagamento = DateTime.Parse(tab.Rows[0]["cr_dataPagamento"].ToString());
                    else
                        this.pagamento = null;
                    this.juros = Decimal.Parse(tab.Rows[0]["cr_juros"].ToString());
                    this.desconto = Decimal.Parse(tab.Rows[0]["cr_desconto"].ToString());
                    this.observacao = tab.Rows[0]["cr_observacao"].ToString();
                    this.parcela = tab.Rows[0]["cr_parcela"].ToString();
                    if (tab.Rows[0]["cr_valorRestante"] != DBNull.Value)
                        this.cr_valorRestante = Decimal.Parse(tab.Rows[0]["cr_valorRestante"].ToString());
                    else
                        this.cr_valorRestante = 0;
                    this.cr_multa = Decimal.Parse(tab.Rows[0]["cr_multa"].ToString());
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
                objDAL = new ContasAReceberDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.codigo = int.Parse(tab.Rows[0]["cr_codigo"].ToString());
                    this.vendas = int.Parse(tab.Rows[0]["cr_vendas"].ToString());
                    this.formaPagamento = int.Parse(tab.Rows[0]["cr_formaPagamento"].ToString());
                    this.vencimento = DateTime.Parse(tab.Rows[0]["cr_dataVencimento"].ToString());
                    this.original = Decimal.Parse(tab.Rows[0]["cr_valorOriginal"].ToString());
                    this.alterado = Decimal.Parse(tab.Rows[0]["cr_valorAlterado"].ToString());
                    this.pago = Decimal.Parse(tab.Rows[0]["cr_valorPago"].ToString());
                    this.status = tab.Rows[0]["cr_status"].ToString();
                    if (tab.Rows[0]["cr_dataPagamento"] != DBNull.Value)
                        this.pagamento = DateTime.Parse(tab.Rows[0]["cr_dataPagamento"].ToString());
                    else
                        this.pagamento = null;
                    this.juros = Decimal.Parse(tab.Rows[0]["cr_juros"].ToString());
                    this.desconto = Decimal.Parse(tab.Rows[0]["cr_desconto"].ToString());
                    this.observacao = tab.Rows[0]["cr_observacao"].ToString();
                    this.parcela = tab.Rows[0]["cr_parcela"].ToString();
                    if (tab.Rows[0]["cr_valorRestante"] != DBNull.Value)
                        this.cr_valorRestante = Decimal.Parse(tab.Rows[0]["cr_valorRestante"].ToString());
                    else
                        this.cr_valorRestante = 0;
                    this.cr_multa = Decimal.Parse(tab.Rows[0]["cr_multa"].ToString());
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
                objDAL = new ContasAReceberDAL();
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
                objDAL = new ContasAReceberDAL();
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
                objDAL = new ContasAReceberDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.codigo = codigo;
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
                objDAL = new ContasAReceberDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable LocalizarContaReceberVenda(string idVenda)
        {
            try
            {
                this.objDAL = new ContasAReceberDAL();

                DataTable dtContaReceberVenda = objDAL.LocalizarContaReceberVenda(idVenda);

                this.objDAL = null;

                return dtContaReceberVenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObterDadosPromissoriaVenda(int idVenda)
        {
            DataSet dsDadosPromissoria = ContasAReceberDAL.ObterDadosPromissoriaVenda(idVenda);

            return dsDadosPromissoria;
        }
    }
}
