using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using One.Dal;

namespace One.Bll
{
    public class ClienteBLL
    {
        #region Propriedades

        public int cli_codigo { get; set; }
        public string cli_nome { get; set; }
        public int cli_idade { get; set; }
        public DateTime cli_data_nascimento { get; set; }
        public string cli_rg { get; set; }
        public string cli_cpf { get; set; }
        public string cli_logradouro { get; set; }
        public string cli_cep { get; set; }
        public string cli_numero { get; set; }
        public string cli_complemento { get; set; }
        public string cli_bairro { get; set; }
        public int cid_codigo { get; set; }
        public string cli_razao_social { get; set; }
        public string cli_cnpj { get; set; }
        public string cli_ie { get; set; }
        public DateTime cli_data_fundacao { get; set; }
        public string cli_tipo_pessoa { get; set; }
        public string cli_telefone { get; set; }
        public string cli_celular { get; set; }
        public string cli_calJuros { get; set; }
        public Double cli_limiteCredito { get; set; }
        public Double cli_limiteMensal { get; set; }
        public int cli_estado { get; set; }      

        ClienteDAL clienteDAL = null;

        #endregion

        #region Contrutores

        public ClienteBLL()
        {
            this.clienteDAL = new ClienteDAL();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método responsável por limpar as propriedades de um objeto clienteBll
        /// </summary>
        public void LimparCliente()
        {
            this.cli_codigo = 0;
            this.cli_nome = null;
            this.cli_idade = 0;
            this.cli_data_nascimento = DateTime.MinValue;
            this.cli_rg = null;
            this.cli_cpf = null;
            this.cli_cep = null;
            this.cli_logradouro = null;
            this.cli_numero = null;
            this.cli_complemento = null;
            this.cli_bairro = null;
            this.cid_codigo = 0;
            this.cli_razao_social = null;
            this.cli_cnpj = null;
            this.cli_ie = null;
            this.cli_data_fundacao = DateTime.MinValue;
            this.cli_tipo_pessoa = null;
            this.cli_telefone = null;
            this.cli_celular = null;
            this.cli_calJuros = null;
            this.cli_limiteCredito = (Double)0;
            this.cli_limiteMensal = (Double)0;
            
        }

        /// <summary>
        /// Método responsável por inserir um cliente
        /// </summary>
        public void InserirCliente()
        {
            try
            {
                this.clienteDAL.InserirCliente(this.cli_tipo_pessoa, this.cli_nome, this.cli_idade, this.cli_data_nascimento,
                                this.cli_rg, this.cli_cpf, this.cli_cep, this.cli_logradouro, this.cli_numero, this.cli_complemento,
                                this.cli_bairro, this.cid_codigo, this.cli_razao_social, this.cli_cnpj, this.cli_ie,
                                this.cli_data_fundacao, this.cli_telefone, this.cli_celular, this.cli_calJuros, this.cli_limiteCredito, 
                                this.cli_limiteMensal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por alterar um cliente
        /// </summary>
        public void AlterarCliente()
        {
            try
            {
                this.clienteDAL.AlterarCliente(this.cli_codigo, this.cli_tipo_pessoa, this.cli_nome, this.cli_idade, this.cli_data_nascimento,
                                                this.cli_rg, this.cli_cpf, this.cli_cep, this.cli_logradouro, this.cli_numero, this.cli_complemento,
                                                this.cli_bairro, this.cid_codigo, this.cli_razao_social, this.cli_cnpj, this.cli_ie,
                                                this.cli_data_fundacao, this.cli_telefone, this.cli_celular, this.cli_calJuros, this.cli_limiteCredito, 
                                                this.cli_limiteMensal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por excluir um cliente
        /// </summary>
        public void ExcluirCliente()
        {
            try
            {
                this.clienteDAL.ExcluirCliente(this.cli_codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CarregarObjetoCliente(DataTable tab)
        {
            this.LimparCliente();

            if (tab.Rows[0]["cli_tipo_pessoa"].ToString() == "Pessoa Física")
            {
                //pessoa física   
                this.cli_nome = tab.Rows[0]["cli_nome"].ToString();

                int idade;
                if (int.TryParse(tab.Rows[0]["cli_idade"].ToString(), out idade))
                {
                    this.cli_idade = idade;
                }

                DateTime dtNascimento;                        
                if (DateTime.TryParse(tab.Rows[0]["cli_data_nascimento"].ToString(), out dtNascimento)){
                    this.cli_data_nascimento = dtNascimento;
                }

                this.cli_rg = tab.Rows[0]["cli_rg"].ToString();
                this.cli_cpf = tab.Rows[0]["cli_cpf"].ToString();                        
            }
            else if (tab.Rows[0]["cli_tipo_pessoa"].ToString() == "Pessoa Jurídica")
            {
                //pessoa jurídica
                this.cli_razao_social = tab.Rows[0]["cli_razao_social"].ToString();
                DateTime dtFundacao = new DateTime();

                if (DateTime.TryParse(tab.Rows[0]["cli_data_fundacao"].ToString(), out dtFundacao))
                {
                    this.cli_data_fundacao = dtFundacao;
                }

                this.cli_ie = tab.Rows[0]["cli_ie"].ToString();
                this.cli_cnpj = tab.Rows[0]["cli_cnpj"].ToString();
            }

            this.cli_codigo = int.Parse(tab.Rows[0]["cli_codigo"].ToString());
            this.cli_cep = tab.Rows[0]["cli_cep"].ToString();
            this.cli_logradouro = tab.Rows[0]["cli_logradouro"].ToString();
            this.cli_numero = tab.Rows[0]["cli_numero"].ToString();
            this.cli_complemento = tab.Rows[0]["cli_complemento"].ToString();
            this.cli_bairro = tab.Rows[0]["cli_bairro"].ToString();
            this.cid_codigo = int.Parse(tab.Rows[0]["cid_codigo"].ToString());
            this.cli_tipo_pessoa = tab.Rows[0]["cli_tipo_pessoa"].ToString();
            this.cli_telefone = tab.Rows[0]["cli_telefone"].ToString();
            this.cli_celular = tab.Rows[0]["cli_celular"].ToString();
            this.cli_calJuros = tab.Rows[0]["cli_calJuros"].ToString();

            //Estado 
            try { 
                this.cli_estado = int.Parse(tab.Rows[0]["Estado"].ToString());
            }
            catch { }

            Double vlLimiteCredito;
            if (Double.TryParse(tab.Rows[0]["cli_limiteCredito"].ToString(), out vlLimiteCredito))
            {
                this.cli_limiteCredito = vlLimiteCredito;
            }

            Double vlLimiteMensal;
            if (Double.TryParse(tab.Rows[0]["cli_limiteMensal"].ToString(), out vlLimiteMensal))
            {
                this.cli_limiteMensal = vlLimiteMensal;
            }
        }

        /// <summary>
        /// Método responsável por localizar um cliente pelo id do mesmo
        /// </summary>
        public void LocalizarClientePorId()
        {
            try
            {
                this.cli_codigo = this.clienteDAL.LocalizarClientePorId(this.cli_codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por localizar um cliente a partir das propriedades do mesmo
        /// </summary>
        public void Localizar(String descricao, String atributo)
        {
            try
            {
                DataTable tab = this.clienteDAL.LocalizarCliente(descricao, atributo);

                if (tab.Rows.Count > 0)
                {
                    CarregarObjetoCliente(tab);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LocalizarLeave(String descricao, String atributo)
        {
            try
            {
                DataTable tab = this.clienteDAL.LocalizarLeave(descricao, atributo);

                if (tab.Rows.Count > 0)
                {
                    CarregarObjetoCliente(tab);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTable LocalizarComRetorno(String descricao, String atributo)
        {
            try
            {
                DataTable tab = this.clienteDAL.LocalizarCliente(descricao, atributo);
                
                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por carregar todos os 100 primeiros registros da tabela de clientes.
        /// </summary>
        public DataTable LocalizarEmTudo(String descricao, String tipoPessoa)
        {
            try
            {
                DataTable tab = this.clienteDAL.LocalizarEmTudo(descricao, tipoPessoa);

                return tab;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por localizar o primeiro ou o ultimo cliente
        /// </summary>
        public void LocalizarPrimeiroUltimo(String descricao)
        {
            try
            {
                int codigo = 0;

                DataTable tab = this.clienteDAL.LocalizarPrimeiroUltimo(descricao);

                if (tab.Rows.Count > 0)
                {
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                }

                this.cli_codigo = codigo;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Método responsável por localizar o proximo cliente ou o anterior de acordo com o id passado
        /// </summary>
        public void LocalizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                DataTable tab = this.clienteDAL.LocalizarProxAnterior(descricao, codigo);
                
                if (tab.Rows.Count > 0)
                {
                    this.cli_codigo = int.Parse(tab.Rows[0][0].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
