using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public enum regime_tributario
    {
        simples_nacional = 0,
        tributacao_normal = 1
    }

    public class EmpresaBLL{
        public regime_tributario emp_regime { get; set; }
        public int emp_codigo { get; set; }
        public String emp_razaoSocial { get; set; }
        public String  emp_nomeFantasia { get; set; }
        public String  emp_logradouro { get; set; }
        public String  emp_numero { get; set; }
        public String emp_bairro { get; set; }
        public String emp_cep { get; set; }
        public int emp_estado { get; set; }
        public int emp_cidade { get; set; }
        public String emp_inscricaoEstadual { get; set; }
        public String emp_inscricaoMunicipal { get; set; }
        public String emp_cnpj { get; set; }
        public String emp_telefone { get; set; }
        public String emp_fax { get; set; }
        public Decimal emp_valorJuros { get; set; }
        public Decimal emp_multa { get; set; }
        public int emp_qtdDias { get; set; }

        EmpresaDAL objDAL = null;

        public EmpresaBLL()
        { }

        public void limpar()
        {
            try
            {
                this.emp_codigo = 0;
                this.emp_razaoSocial = null;
                this.emp_nomeFantasia = null;
                this.emp_logradouro = null;
                this.emp_numero = null;
                this.emp_bairro = null;
                this.emp_cep = null;
                this.emp_cidade = 0;
                this.emp_inscricaoEstadual = null;
                this.emp_inscricaoMunicipal = null;
                this.emp_cnpj = null;
                this.emp_telefone = null;
                this.emp_fax = null;
                this.emp_valorJuros = 0;
                this.emp_multa = 0;
                this.emp_qtdDias = 0;
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
                objDAL = new EmpresaDAL();
                objDAL.inserir(this.emp_regime.GetHashCode(),  this.emp_razaoSocial, this.emp_nomeFantasia, this.emp_logradouro, this.emp_numero, this.emp_bairro, this.emp_cep,this.emp_estado, this.emp_cidade, this.emp_inscricaoEstadual, this.emp_inscricaoMunicipal, this.emp_cnpj, this.emp_telefone, this.emp_fax,this.emp_valorJuros,this.emp_multa,this.emp_qtdDias);
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
                objDAL = new EmpresaDAL();
                objDAL.alterar(this.emp_regime.GetHashCode(), this.emp_codigo, this.emp_razaoSocial, this.emp_nomeFantasia, this.emp_logradouro, this.emp_numero, this.emp_bairro, this.emp_cep, this.emp_estado, this.emp_cidade, this.emp_inscricaoEstadual, this.emp_inscricaoMunicipal, this.emp_cnpj, this.emp_telefone, this.emp_fax, this.emp_valorJuros, this.emp_multa, this.emp_qtdDias);
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
                objDAL = new EmpresaDAL();
                objDAL.excluir(this.emp_codigo);
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
                objDAL = new EmpresaDAL();
                this.emp_codigo = objDAL.localizar(this.emp_codigo);
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
                objDAL = new EmpresaDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.emp_codigo = int.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.emp_razaoSocial = tab.Rows[0]["emp_razaoSocial"].ToString();
                    this.emp_nomeFantasia = tab.Rows[0]["emp_nomeFantasia"].ToString();
                    this.emp_logradouro = tab.Rows[0]["emp_logradouro"].ToString();
                    this.emp_numero = tab.Rows[0]["emp_numero"].ToString();
                    this.emp_bairro = tab.Rows[0]["emp_bairro"].ToString();
                    this.emp_cep = tab.Rows[0]["emp_cep"].ToString();
                    this.emp_cidade = int.Parse(tab.Rows[0]["emp_cidade"].ToString());
                    this.emp_inscricaoEstadual = tab.Rows[0]["emp_inscricaoEstadual"].ToString();
                    this.emp_inscricaoMunicipal = tab.Rows[0]["emp_inscricaoMunicipal"].ToString();
                    this.emp_cnpj = tab.Rows[0]["emp_cnpj"].ToString();
                    this.emp_telefone = tab.Rows[0]["emp_telefone"].ToString();
                    this.emp_fax = tab.Rows[0]["emp_fax"].ToString();
                    this.emp_valorJuros = Decimal.Parse(tab.Rows[0]["emp_valorJuros"].ToString());
                    this.emp_multa = Decimal.Parse(tab.Rows[0]["emp_multa"].ToString());
                    this.emp_qtdDias = int.Parse(tab.Rows[0]["emp_qtdDias"].ToString());

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
                objDAL = new EmpresaDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0){

                    this.emp_regime = (regime_tributario)Int32.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.emp_codigo = int.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.emp_razaoSocial= tab.Rows[0]["emp_razaoSocial"].ToString();
                    this.emp_nomeFantasia = tab.Rows[0]["emp_nomeFantasia"].ToString();
                    this.emp_logradouro = tab.Rows[0]["emp_logradouro"].ToString();
                    this.emp_numero = tab.Rows[0]["emp_numero"].ToString();
                    this.emp_bairro = tab.Rows[0]["emp_bairro"].ToString();
                    this.emp_cep = tab.Rows[0]["emp_cep"].ToString();
                    this.emp_estado = int.Parse(tab.Rows[0]["emp_estado"].ToString());
                    this.emp_cidade = int.Parse(tab.Rows[0]["emp_cidade"].ToString());
                    this.emp_inscricaoEstadual = tab.Rows[0]["emp_inscricaoEstadual"].ToString();
                    this.emp_inscricaoMunicipal = tab.Rows[0]["emp_inscricaoMunicipal"].ToString();
                    this.emp_cnpj = tab.Rows[0]["emp_cnpj"].ToString();
                    this.emp_telefone = tab.Rows[0]["emp_telefone"].ToString();
                    this.emp_fax = tab.Rows[0]["emp_fax"].ToString();
                    this.emp_valorJuros = Decimal.Parse(tab.Rows[0]["emp_valorJuros"].ToString());
                    this.emp_multa = Decimal.Parse(tab.Rows[0]["emp_multa"].ToString());
                    this.emp_qtdDias = int.Parse(tab.Rows[0]["emp_qtdDias"].ToString());
                    try { this.emp_regime = (regime_tributario)tab.Rows[0]["emp_regime"]; }
                    catch { }
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
                objDAL = new EmpresaDAL();
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
                objDAL = new EmpresaDAL();
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
                objDAL = new EmpresaDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.emp_codigo = codigo;
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
                objDAL = new EmpresaDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.emp_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
