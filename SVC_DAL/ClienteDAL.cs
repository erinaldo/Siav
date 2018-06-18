using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class ClienteDAL
    {
        Contexto contexto = null;

        public ClienteDAL()
        {
        
        }

        /// <summary>
        /// Método responsável por inserir um cliente no banco de dados.
        /// </summary>
        public void InserirCliente(String tipo_pessoa, String nome, int idade, DateTime nascimento, String rg,
                                    String cpf, string cep, String logradouro, String numero, String complemento, String bairro, int cidade,
                                    String razao, String cnpj, String ie, DateTime fundacao,String cli_telefone, String cli_celular,
                                    String cli_calJuros, Double cli_limiteCredito, Double cli_limiteMensal)
        {
            try
            {                    
                using (SqlCommand cmd = new SqlCommand())
                {
                    List<string> lstCamposTabelaCliente = new List<string>();
                    List<string> lstParametrosTabelaCliente = new List<string>();
                    string query = string.Empty;

                    //Adicionar campos específicos a query de acordo com o tipo de pessoa
                    if (tipo_pessoa == "Pessoa Física")
                    {
                        if (nome != null && nome != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_nome");
                            lstParametrosTabelaCliente.Add("@nome");
                            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = nome;
                        }

                        if (idade != 0)
                        {
                            lstCamposTabelaCliente.Add("cli_idade");
                            lstParametrosTabelaCliente.Add("@idade");
                            cmd.Parameters.Add(new SqlParameter("@idade", SqlDbType.Int)).Value = idade;
                        }

                        if (nascimento != DateTime.MinValue)
                        {
                            lstCamposTabelaCliente.Add("cli_data_nascimento");
                            lstParametrosTabelaCliente.Add("@nascimento");
                            cmd.Parameters.Add(new SqlParameter("@nascimento", SqlDbType.DateTime)).Value = nascimento;
                        }

                        if (rg != null && rg != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_rg");
                            lstParametrosTabelaCliente.Add("@rg");
                            cmd.Parameters.Add(new SqlParameter("@rg", SqlDbType.VarChar)).Value = rg;
                        }

                        if (cpf != null && cpf != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_cpf");
                            lstParametrosTabelaCliente.Add("@cpf");
                            cmd.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar)).Value = cpf;
                        }
                    }
                    else
                    {
                        if (razao != null && razao != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_razao_social");
                            lstParametrosTabelaCliente.Add("@razao");
                            cmd.Parameters.Add(new SqlParameter("@razao", SqlDbType.VarChar)).Value = razao;
                        }

                        if (fundacao != DateTime.MinValue)
                        {
                            lstCamposTabelaCliente.Add("cli_data_fundacao");
                            lstParametrosTabelaCliente.Add("@fundacao");
                            cmd.Parameters.Add(new SqlParameter("@fundacao", SqlDbType.DateTime)).Value = fundacao;
                        }

                        if (ie != null && ie != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_ie");
                            lstParametrosTabelaCliente.Add("@ie");
                            cmd.Parameters.Add(new SqlParameter("@ie", SqlDbType.VarChar)).Value = ie;
                        }

                        if (cnpj != null && cnpj != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_cnpj");
                            lstParametrosTabelaCliente.Add("@cnpj");
                            cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar)).Value = cnpj;
                        }
                    }

                    if (cep != null && cep != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_cep");
                        lstParametrosTabelaCliente.Add("@cep");
                        cmd.Parameters.Add(new SqlParameter("@cep", SqlDbType.VarChar)).Value = cep;
                    }


                    if (logradouro != null && logradouro != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_logradouro");
                        lstParametrosTabelaCliente.Add("@logradouro");
                        cmd.Parameters.Add(new SqlParameter("@logradouro", SqlDbType.VarChar)).Value = logradouro;
                    }

                    if (numero != null && numero != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_numero");
                        lstParametrosTabelaCliente.Add("@numero");
                        cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value = numero;
                    }

                    if (complemento != null && complemento != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_complemento");
                        lstParametrosTabelaCliente.Add("@complemento");
                        cmd.Parameters.Add(new SqlParameter("@complemento", SqlDbType.VarChar)).Value = complemento;
                    }

                    if (bairro != null && bairro != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_bairro");
                        lstParametrosTabelaCliente.Add("@bairro");
                        cmd.Parameters.Add(new SqlParameter("@bairro", SqlDbType.VarChar)).Value = bairro;
                    }

                    if (cidade != 0)
                    {
                        lstCamposTabelaCliente.Add("cid_codigo");
                        lstParametrosTabelaCliente.Add("@cidade");
                        cmd.Parameters.Add(new SqlParameter("@cidade", SqlDbType.Int)).Value = cidade;
                    }

                    if (tipo_pessoa != null && tipo_pessoa != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_tipo_pessoa");
                        lstParametrosTabelaCliente.Add("@tipo_pessoa");
                        cmd.Parameters.Add(new SqlParameter("@tipo_pessoa", SqlDbType.VarChar)).Value = tipo_pessoa;
                    }

                    if (cli_telefone != null && cli_telefone != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_telefone");
                        lstParametrosTabelaCliente.Add("@cli_telefone");
                        cmd.Parameters.Add(new SqlParameter("@cli_telefone", SqlDbType.VarChar)).Value = cli_telefone;
                    }

                    if (cli_celular != null && cli_celular != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_celular");
                        lstParametrosTabelaCliente.Add("@cli_celular");
                        cmd.Parameters.Add(new SqlParameter("@cli_celular", SqlDbType.VarChar)).Value = cli_celular;
                    }

                    if (cli_calJuros != null && cli_calJuros != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_calJuros");
                        lstParametrosTabelaCliente.Add("@cli_calJuros");
                        cmd.Parameters.Add(new SqlParameter("@cli_calJuros", SqlDbType.VarChar)).Value = cli_calJuros;
                    }

                    if (cli_limiteCredito != (Double)0)
                    {
                        lstCamposTabelaCliente.Add("cli_limiteCredito");
                        lstParametrosTabelaCliente.Add("@cli_limiteCredito");
                        cmd.Parameters.Add(new SqlParameter("@cli_limiteCredito", SqlDbType.Float)).Value = cli_limiteCredito;
                    }

                    if (cli_limiteMensal != (Double)0)
                    {
                        lstCamposTabelaCliente.Add("cli_limiteMensal");
                        lstParametrosTabelaCliente.Add("@cli_limiteMensal");
                        cmd.Parameters.Add(new SqlParameter("@cli_limiteMensal", SqlDbType.Float)).Value = cli_limiteMensal;
                    }        
         
                    //Montar query sql
                    query = string.Concat("INSERT INTO Cliente ",
                                        "(",
                                            string.Join(",", lstCamposTabelaCliente),
                                        ")",
                                        "VALUES ",
                                        "(",
                                            string.Join(",", lstParametrosTabelaCliente),
                                        ")");

                    cmd.CommandText = query;

                    //Executar comando no banco de dados.
                    using (contexto = new Contexto())
                    {
                        contexto.ExecutaComando(cmd);    
                    }
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por alterar um cliente no banco
        /// </summary>
        public void AlterarCliente(int codigo, String tipo_pessoa, String nome, int idade, DateTime nascimento, String rg,
                                    String cpf, string cep, String logradouro, String numero, String complemento, String bairro, int cidade,
                                    String razao, String cnpj, String ie, DateTime fundacao,String cli_telefone, String cli_celular,
                                    String cli_calJuros, Double cli_limiteCredito, Double cli_limiteMensal)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
	            {
                    List<string> lstCamposTabelaCliente = new List<string>();
                    List<string> lstParametrosTabelaCliente = new List<string>();
                    List<string> lstCamposNulos = new List<string>();
                    string query = string.Empty;

                    //Adicionar campos específicos a query de acordo com o tipo de pessoa
                    if (tipo_pessoa == "Pessoa Física")
                    {
                        if (nome != null && nome != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_nome");
                            lstParametrosTabelaCliente.Add("@nome");
                            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = nome;
                        }

                        if (idade != 0)
                        {
                            lstCamposTabelaCliente.Add("cli_idade");
                            lstParametrosTabelaCliente.Add("@idade");
                            cmd.Parameters.Add(new SqlParameter("@idade", SqlDbType.Int)).Value = idade;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_idade");
                        }

                        if (nascimento != DateTime.MinValue)
                        {
                            lstCamposTabelaCliente.Add("cli_data_nascimento");
                            lstParametrosTabelaCliente.Add("@nascimento");
                            cmd.Parameters.Add(new SqlParameter("@nascimento", SqlDbType.DateTime)).Value = nascimento;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_data_nascimento");
                        }

                        if (rg != null && rg != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_rg");
                            lstParametrosTabelaCliente.Add("@rg");
                            cmd.Parameters.Add(new SqlParameter("@rg", SqlDbType.VarChar)).Value = rg;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_rg");
                        }

                        if (cpf != null && cpf != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_cpf");
                            lstParametrosTabelaCliente.Add("@cpf");
                            cmd.Parameters.Add(new SqlParameter("@cpf", SqlDbType.VarChar)).Value = cpf;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_cpf");
                        }
                    }
                    else
                    {
                        if (razao != null && razao != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_razao_social");
                            lstParametrosTabelaCliente.Add("@razao");
                            cmd.Parameters.Add(new SqlParameter("@razao", SqlDbType.VarChar)).Value = razao;
                        }
                        
                        if (fundacao != DateTime.MinValue)
                        {
                            lstCamposTabelaCliente.Add("cli_data_fundacao");
                            lstParametrosTabelaCliente.Add("@fundacao");
                            cmd.Parameters.Add(new SqlParameter("@fundacao", SqlDbType.DateTime)).Value = fundacao;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_data_fundacao");
                        }

                        if (ie != null && ie != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_ie");
                            lstParametrosTabelaCliente.Add("@ie");
                            cmd.Parameters.Add(new SqlParameter("@ie", SqlDbType.VarChar)).Value = ie;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_ie");
                        }

                        if (cnpj != null && cnpj != string.Empty)
                        {
                            lstCamposTabelaCliente.Add("cli_cnpj");
                            lstParametrosTabelaCliente.Add("@cnpj");
                            cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar)).Value = cnpj;
                        }
                        else
                        {
                            lstCamposNulos.Add("cli_cnpj");
                        }
                    }

                    if (cep != null && cep != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_cep");
                        lstParametrosTabelaCliente.Add("@cep");
                        cmd.Parameters.Add(new SqlParameter("@cep", SqlDbType.VarChar)).Value = cep;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_cep");
                    }

                    if (logradouro != null && logradouro != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_logradouro");
                        lstParametrosTabelaCliente.Add("@logradouro");
                        cmd.Parameters.Add(new SqlParameter("@logradouro", SqlDbType.VarChar)).Value = logradouro;
                    }

                    if (numero != null && numero != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_numero");
                        lstParametrosTabelaCliente.Add("@numero");
                        cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value = numero;
                    }

                    if (complemento != null && complemento != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_complemento");
                        lstParametrosTabelaCliente.Add("@complemento");
                        cmd.Parameters.Add(new SqlParameter("@complemento", SqlDbType.VarChar)).Value = complemento;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_complemento");
                    }

                    if (bairro != null && bairro != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_bairro");
                        lstParametrosTabelaCliente.Add("@bairro");
                        cmd.Parameters.Add(new SqlParameter("@bairro", SqlDbType.VarChar)).Value = bairro;
                    }

                    if (cidade != 0)
                    {
                        lstCamposTabelaCliente.Add("cid_codigo");
                        lstParametrosTabelaCliente.Add("@cidade");
                        cmd.Parameters.Add(new SqlParameter("@cidade", SqlDbType.Int)).Value = cidade;
                    }

                    if (tipo_pessoa != null && tipo_pessoa != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_tipo_pessoa");
                        lstParametrosTabelaCliente.Add("@tipo_pessoa");
                        cmd.Parameters.Add(new SqlParameter("@tipo_pessoa", SqlDbType.VarChar)).Value = tipo_pessoa;
                    }

                    if (cli_telefone != null && cli_telefone != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_telefone");
                        lstParametrosTabelaCliente.Add("@cli_telefone");
                        cmd.Parameters.Add(new SqlParameter("@cli_telefone", SqlDbType.VarChar)).Value = cli_telefone;
                    }

                    if (cli_celular != null && cli_celular != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_celular");
                        lstParametrosTabelaCliente.Add("@cli_celular");
                        cmd.Parameters.Add(new SqlParameter("@cli_celular", SqlDbType.VarChar)).Value = cli_celular;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_celular");
                    }

                    if (cli_calJuros != null && cli_calJuros != string.Empty)
                    {
                        lstCamposTabelaCliente.Add("cli_calJuros");
                        lstParametrosTabelaCliente.Add("@cli_calJuros");
                        cmd.Parameters.Add(new SqlParameter("@cli_calJuros", SqlDbType.VarChar)).Value = cli_calJuros;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_calJuros");
                    }

                    if (cli_limiteCredito != (Double)0)
                    {
                        lstCamposTabelaCliente.Add("cli_limiteCredito");
                        lstParametrosTabelaCliente.Add("@cli_limiteCredito");
                        cmd.Parameters.Add(new SqlParameter("@cli_limiteCredito", SqlDbType.Float)).Value = cli_limiteCredito;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_limiteCredito");
                    }

                    if (cli_limiteMensal != (Double)0)
                    {
                        lstCamposTabelaCliente.Add("cli_limiteMensal");
                        lstParametrosTabelaCliente.Add("@cli_limiteMensal");
                        cmd.Parameters.Add(new SqlParameter("@cli_limiteMensal", SqlDbType.Float)).Value = cli_limiteMensal;
                    }
                    else
                    {
                        lstCamposNulos.Add("cli_limiteMensal");
                    }

                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Float)).Value = codigo;
                    
                    //Montar query sql
                    StringBuilder stbCampoValor = new StringBuilder();

                    for (int i = 0; i < lstCamposTabelaCliente.Count; i++)
			        {
                        stbCampoValor.Append(string.Concat(lstCamposTabelaCliente[i], " = ", lstParametrosTabelaCliente[i], ", "));
			        }

                    for (int i = 0; i < lstCamposNulos.Count; i++)
                    {
                        stbCampoValor.Append(string.Concat(lstCamposNulos[i], " = null, "));
                    }

                    query = string.Concat("UPDATE Cliente SET ", stbCampoValor.ToString().Remove(stbCampoValor.Length - 2, 2), " WHERE cli_codigo = @codigo");

                    cmd.CommandText = query;

                    //Executar alteração
                    using (contexto = new Contexto())
                    {
                        contexto.ExecutaComando(cmd);
                    }
	            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por excluir um cliente no banco
        /// </summary>
        public void ExcluirCliente(int cli_codigo)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {   
                        cmd.CommandText = "DELETE FROM Cliente WHERE cli_codigo = @cli_codigo";
                        cmd.Parameters.Add(new SqlParameter("@cli_codigo", SqlDbType.Int)).Value = cli_codigo;

                        contexto.ExecutaComando(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por localizar clientes de acordo com o filtro e coluna
        /// </summary>
        public DataTable LocalizarCliente(String descricao, String coluna)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {   
                        cmd.CommandText = string.Concat("SELECT *,cid.cid_estado 'Estado' FROM Cliente c left Join Cidade cid on cid.cid_codigo = c.cid_codigo   WHERE  ", coluna, " like @descricao");
                        cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao + "%";
                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por localizar clientes de acordo com o filtro e coluna
        /// </summary>
        public DataTable LocalizarLeave(String descricao, String coluna)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = string.Concat("SELECT * FROM Cliente WHERE ", coluna, " like @descricao");
                        cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }  
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// Método responsável por localizar cliente por id
        /// </summary>
        public int LocalizarClientePorId(int codigo)
        {
            try
            {
                using(contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = string.Concat("SELECT * FROM Cliente WHERE cli_codigo = @codigo");
                        cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        if (tab.Rows.Count > 0)
                        {
                            return int.Parse(tab.Rows[0][0].ToString());
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por localizar os 100 primeiros clientes utilizando like en todas as propriedades da tabela
        /// </summary>
        public DataTable LocalizarEmTudo(String descricao, String tipoPessoa)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    using(SqlCommand cmd = new SqlCommand())
	                {
                        cmd.CommandText = "LocalizaCliente"; //Procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = "%" + descricao + "%";
                        cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar)).Value = tipoPessoa;

                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
	                }    
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por localizar o primeiro e o ultimo cliente de acordo com o filtro
        /// </summary>
        public DataTable LocalizarPrimeiroUltimo(String descricao)
        {
            try
            {
                using(contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (descricao == "ultimo")
                        {
                            cmd.CommandText = "SELECT cli_codigo = max(cli_codigo) FROM Cliente";
                            cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                        }
                        else if (descricao == "primeiro")
                        {
                            cmd.CommandText = "SELECT cli_codigo = min(cli_codigo) FROM Cliente";
                            cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                        }

                        DataTable tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por localizar o proximo cliente de acordo com o id passado
        /// </summary>
        public DataTable LocalizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                using (contexto = new Contexto())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (descricao == "proximo")
                        {
                            cmd.CommandText = "SELECT cli_codigo FROM Cliente WHERE cli_codigo = (SELECT MIN(cli_codigo) FROM Cliente WHERE cli_codigo > @codigo)";
                        }
                        else if (descricao == "anterior")
                        {
                            cmd.CommandText = "SELECT cli_codigo FROM Cliente WHERE cli_codigo = (SELECT MAX(cli_codigo) FROM Cliente WHERE cli_codigo < @codigo)"; ;
                        }

                        cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                        DataTable  tab = contexto.ExecutaConsulta(cmd);

                        return tab;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
