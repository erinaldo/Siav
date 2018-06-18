using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class FornecedoresBLL
    {
        public int for_codigo { get; set; }
        public String for_razaoSocial { get; set; }
        public String for_cnpj { get; set; }
        public String for_ie { get; set; }
        public String for_email { get; set; }
        public String for_cep { get; set; }
        public String for_logradouro { get; set; }
        public String for_numero { get; set; }
        public String for_complemento { get; set; }
        public String for_bairro { get; set; }
        public int for_cidade { get; set; }
        public String for_telefone { get; set; }
        public String for_fax { get; set; }
        public String for_status { get; set; }
        public String for_cpf { get; set; }
        public String for_rg { get; set; }
        public String for_tipo_fornecedor { get; set; }
        public String for_nome { get; set; }
        public String for_tipo { get; set; }

        FornecedoresDAL objDAL = null;

        public FornecedoresBLL()
        { }

        public void limpar()
        {
            try
            {
                this.for_codigo = 0;
                this.for_razaoSocial = null;
                this.for_cnpj = null;
                this.for_ie = null;
                this.for_email = null;
                this.for_cep = null;
                this.for_logradouro = null;
                this.for_numero = null;
                this.for_complemento = null;   
                this.for_bairro = null;                
                this.for_cidade = 0;
                this.for_telefone = null;
                this.for_fax = null;
                this.for_status = null;
                this.for_cpf = null;
                this.for_rg = null;
                this.for_tipo_fornecedor = null;
                this.for_nome = null;
                this.for_tipo = null;
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
                objDAL = new FornecedoresDAL();
                objDAL.inserir(this.for_razaoSocial, this.for_cnpj, this.for_ie, this.for_email, this.for_cep, this.for_logradouro, this.for_numero, this.for_complemento, this.for_bairro, this.for_cidade, this.for_telefone, this.for_fax, this.for_status, this.for_cpf, this.for_rg, this.for_tipo_fornecedor, this.for_nome,this.for_tipo);
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
                objDAL = new FornecedoresDAL();
                objDAL.alterar(this.for_codigo, this.for_razaoSocial, this.for_cnpj, this.for_ie, this.for_email, this.for_cep, this.for_logradouro, this.for_numero, this.for_complemento, this.for_bairro, this.for_cidade, this.for_telefone, this.for_fax, this.for_status, this.for_cpf, this.for_rg, this.for_tipo_fornecedor, this.for_nome,this.for_tipo);
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
                objDAL = new FornecedoresDAL();
                objDAL.excluir(this.for_codigo);
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
                objDAL = new FornecedoresDAL();
                this.for_codigo = objDAL.localizar(this.for_codigo);
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
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizar(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.for_codigo = int.Parse(tab.Rows[0]["for_codigo"].ToString());
                    this.for_razaoSocial = tab.Rows[0]["for_razaoSocial"].ToString();
                    this.for_cnpj = tab.Rows[0]["for_cnpj"].ToString();
                    this.for_ie = tab.Rows[0]["for_ie"].ToString();
                    this.for_email = tab.Rows[0]["for_email"].ToString();
                    this.for_cep = tab.Rows[0]["for_cep"].ToString();
                    this.for_logradouro = tab.Rows[0]["for_logradouro"].ToString();
                    this.for_numero = tab.Rows[0]["for_numero"].ToString();
                    this.for_complemento = tab.Rows[0]["for_complemento"].ToString();
                    this.for_bairro = tab.Rows[0]["for_bairro"].ToString();
                    this.for_cidade = int.Parse(tab.Rows[0]["for_cidade"].ToString());
                    this.for_telefone = tab.Rows[0]["for_telefone"].ToString();
                    this.for_fax = tab.Rows[0]["for_fax"].ToString();
                    this.for_status = tab.Rows[0]["for_status"].ToString();
                    this.for_cpf = tab.Rows[0]["for_cpf"].ToString();
                    this.for_rg = tab.Rows[0]["for_rg"].ToString();
                    this.for_tipo_fornecedor = tab.Rows[0]["for_tipo_fornecedor"].ToString();
                    this.for_nome = tab.Rows[0]["for_nome"].ToString();
                    this.for_tipo = tab.Rows[0]["for_tipo"].ToString();
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
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizarLeave(descricao, atributo);
                if (tab.Rows.Count > 0)
                {
                    this.for_codigo = int.Parse(tab.Rows[0]["for_codigo"].ToString());
                    this.for_razaoSocial = tab.Rows[0]["for_razaoSocial"].ToString();
                    this.for_cnpj = tab.Rows[0]["for_cnpj"].ToString();
                    this.for_ie = tab.Rows[0]["for_ie"].ToString();
                    this.for_email = tab.Rows[0]["for_email"].ToString();
                    this.for_cep = tab.Rows[0]["for_cep"].ToString();
                    this.for_logradouro = tab.Rows[0]["for_logradouro"].ToString();
                    this.for_numero = tab.Rows[0]["for_numero"].ToString();
                    this.for_complemento = tab.Rows[0]["for_complemento"].ToString();
                    this.for_bairro = tab.Rows[0]["for_bairro"].ToString();
                    this.for_cidade = int.Parse(tab.Rows[0]["for_cidade"].ToString());
                    this.for_telefone = tab.Rows[0]["for_telefone"].ToString();
                    this.for_fax = tab.Rows[0]["for_fax"].ToString();
                    this.for_status = tab.Rows[0]["for_status"].ToString();
                    this.for_status = tab.Rows[0]["for_status"].ToString();
                    this.for_cpf = tab.Rows[0]["for_cpf"].ToString();
                    this.for_rg = tab.Rows[0]["for_rg"].ToString();
                    this.for_tipo_fornecedor = tab.Rows[0]["for_tipo_fornecedor"].ToString();
                    this.for_nome = tab.Rows[0]["for_nome"].ToString();
                    this.for_tipo = tab.Rows[0]["for_tipo"].ToString();
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
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizar(descricao, atributo);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarComRetorno_SQLSERVER(String descricao, String atributo,String sqlserver)
        {
            try
            {
                DataTable tab;
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizar_SQLSERVER(descricao, atributo,sqlserver);
                objDAL = null;
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable localizarEmTudo(String descricao, String tipoPessoa)
        {
            try
            {
                DataTable tab;
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizarEmTudo(descricao,tipoPessoa);
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
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizarPrimeiroUltimo(descricao);
                if (tab.Rows.Count > 0)
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                this.for_codigo = codigo;
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
                objDAL = new FornecedoresDAL();
                tab = objDAL.localizarProxAnterior(descricao, codigo);
                if (tab.Rows.Count > 0)
                    this.for_codigo = int.Parse(tab.Rows[0][0].ToString());
                objDAL = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
