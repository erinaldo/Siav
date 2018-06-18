using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class FornecedoresDAL
    {
        Contexto objD = null;

        public FornecedoresDAL()
        { }

        //inserção
        public void inserir(String for_razaoSocial,String for_cnpj, String for_ie, String for_email, String for_cep, 
            String for_logradouro, String for_numero, String for_complemento, String for_bairro, int for_cidade, 
            String for_telefone, String for_fax, String for_status, String for_cpf, String for_rg, String for_tipo_fornecedor,String for_nome, String for_tipo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                if (for_tipo_fornecedor == "Pessoa Física")
                {
                    cmd.CommandText = "INSERT INTO Fornecedores" +
                    " (for_email, for_cep,for_logradouro,for_numero, for_complemento," +
                    " for_bairro, for_cidade, for_telefone, for_fax, for_status,for_cpf,for_rg,for_tipo_fornecedor,for_nome,for_tipo)" +
                    " VALUES (@for_email, @for_cep, @for_logradouro,@for_numero," +
                    " @for_complemento, @for_bairro, @for_cidade, @for_telefone, @for_fax," +
                    " @for_status,@for_cpf,@for_rg,@for_tipo_fornecedor,@for_nome,@for_tipo)";
                    
                    cmd.Parameters.Add(new SqlParameter("@for_email", SqlDbType.VarChar)).Value = for_email;
                    cmd.Parameters.Add(new SqlParameter("@for_cep", SqlDbType.VarChar)).Value = for_cep;
                    cmd.Parameters.Add(new SqlParameter("@for_logradouro", SqlDbType.VarChar)).Value = for_logradouro;
                    cmd.Parameters.Add(new SqlParameter("@for_numero", SqlDbType.VarChar)).Value = for_numero;
                    cmd.Parameters.Add(new SqlParameter("@for_complemento", SqlDbType.VarChar)).Value = for_complemento;
                    cmd.Parameters.Add(new SqlParameter("@for_bairro", SqlDbType.VarChar)).Value = for_bairro;
                    cmd.Parameters.Add(new SqlParameter("@for_cidade", SqlDbType.Int)).Value = for_cidade;
                    cmd.Parameters.Add(new SqlParameter("@for_telefone", SqlDbType.VarChar)).Value = for_telefone;
                    cmd.Parameters.Add(new SqlParameter("@for_fax", SqlDbType.VarChar)).Value = for_fax;
                    cmd.Parameters.Add(new SqlParameter("@for_status", SqlDbType.VarChar)).Value = for_status;
                    cmd.Parameters.Add(new SqlParameter("@for_cpf", SqlDbType.VarChar)).Value = for_cpf;
                    cmd.Parameters.Add(new SqlParameter("@for_rg", SqlDbType.VarChar)).Value = for_rg;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo_fornecedor", SqlDbType.VarChar)).Value = for_tipo_fornecedor;
                    cmd.Parameters.Add(new SqlParameter("@for_nome", SqlDbType.VarChar)).Value = for_nome;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo", SqlDbType.VarChar)).Value = for_tipo;
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Fornecedores" +
                    " (for_razaoSocial, for_cnpj, for_ie," +
                    " for_email, for_cep,for_logradouro,for_numero, for_complemento," +
                    " for_bairro, for_cidade, for_telefone, for_fax, for_status,for_tipo_fornecedor,for_tipo)" +
                    " VALUES (@for_razaoSocial, @for_cnpj," +
                    " @for_ie, @for_email, @for_cep, @for_logradouro,@for_numero," +
                    " @for_complemento, @for_bairro, @for_cidade, @for_telefone, @for_fax," +
                    " @for_status,@for_tipo_fornecedor,@for_tipo)";
                    cmd.Parameters.Add(new SqlParameter("@for_razaoSocial", SqlDbType.VarChar)).Value = for_razaoSocial;
                    cmd.Parameters.Add(new SqlParameter("@for_cnpj", SqlDbType.VarChar)).Value = for_cnpj;
                    cmd.Parameters.Add(new SqlParameter("@for_ie", SqlDbType.VarChar)).Value = for_ie;
                    cmd.Parameters.Add(new SqlParameter("@for_email", SqlDbType.VarChar)).Value = for_email;
                    cmd.Parameters.Add(new SqlParameter("@for_cep", SqlDbType.VarChar)).Value = for_cep;
                    cmd.Parameters.Add(new SqlParameter("@for_logradouro", SqlDbType.VarChar)).Value = for_logradouro;
                    cmd.Parameters.Add(new SqlParameter("@for_numero", SqlDbType.VarChar)).Value = for_numero;
                    cmd.Parameters.Add(new SqlParameter("@for_complemento", SqlDbType.VarChar)).Value = for_complemento;
                    cmd.Parameters.Add(new SqlParameter("@for_bairro", SqlDbType.VarChar)).Value = for_bairro;
                    cmd.Parameters.Add(new SqlParameter("@for_cidade", SqlDbType.Int)).Value = for_cidade;
                    cmd.Parameters.Add(new SqlParameter("@for_telefone", SqlDbType.VarChar)).Value = for_telefone;
                    cmd.Parameters.Add(new SqlParameter("@for_fax", SqlDbType.VarChar)).Value = for_fax;
                    cmd.Parameters.Add(new SqlParameter("@for_status", SqlDbType.VarChar)).Value = for_status;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo_fornecedor", SqlDbType.VarChar)).Value = for_tipo_fornecedor;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo", SqlDbType.VarChar)).Value = for_tipo;
                }
                
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //alterar
        public void alterar(int for_codigo, String for_razaoSocial,
            String for_cnpj, String for_ie, String for_email, String for_cep, String for_logradouro,
            String for_numero, String for_complemento, String for_bairro, int for_cidade, String for_telefone, String for_fax, String for_status,
            String for_cpf, String for_rg, String for_tipo_fornecedor,String for_nome, String for_tipo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                

                if (for_tipo_fornecedor == "Pessoa Física")
                {
                    cmd.CommandText = "UPDATE Fornecedores" +
                    " SET"+
                    " for_email = @for_email, for_cep = @for_cep,"+
                    " for_logradouro = @for_logradouro, for_numero = @for_numero," +                    
                    " for_complemento = @for_complemento, for_bairro=@for_bairro," +
                    " for_cidade=@for_cidade, for_telefone=@for_telefone, for_fax=@for_fax,"+
                    " for_status=@for_status, for_cpf = @for_cpf, for_rg=@for_rg, for_tipo_fornecedor=@for_tipo_fornecedor,"+
                    " for_nome = @for_nome, for_tipo = @for_tipo" +
                    " WHERE" +
                    " for_codigo=@for_codigo";

                    cmd.Parameters.Add(new SqlParameter("@for_codigo", SqlDbType.Int)).Value = for_codigo;
                    cmd.Parameters.Add(new SqlParameter("@for_email", SqlDbType.VarChar)).Value = for_email;
                    cmd.Parameters.Add(new SqlParameter("@for_cep", SqlDbType.VarChar)).Value = for_cep;
                    cmd.Parameters.Add(new SqlParameter("@for_logradouro", SqlDbType.VarChar)).Value = for_logradouro;
                    cmd.Parameters.Add(new SqlParameter("@for_numero", SqlDbType.VarChar)).Value = for_numero;
                    cmd.Parameters.Add(new SqlParameter("@for_complemento", SqlDbType.VarChar)).Value = for_complemento;
                    cmd.Parameters.Add(new SqlParameter("@for_bairro", SqlDbType.VarChar)).Value = for_bairro;
                    cmd.Parameters.Add(new SqlParameter("@for_cidade", SqlDbType.Int)).Value = for_cidade;
                    cmd.Parameters.Add(new SqlParameter("@for_telefone", SqlDbType.VarChar)).Value = for_telefone;
                    cmd.Parameters.Add(new SqlParameter("@for_fax", SqlDbType.VarChar)).Value = for_fax;
                    cmd.Parameters.Add(new SqlParameter("@for_status", SqlDbType.VarChar)).Value = for_status;
                    cmd.Parameters.Add(new SqlParameter("@for_cpf", SqlDbType.VarChar)).Value = for_cpf;
                    cmd.Parameters.Add(new SqlParameter("@for_rg", SqlDbType.VarChar)).Value = for_rg;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo_fornecedor", SqlDbType.VarChar)).Value = for_tipo_fornecedor;
                    cmd.Parameters.Add(new SqlParameter("@for_nome", SqlDbType.VarChar)).Value = for_nome;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo", SqlDbType.VarChar)).Value = for_tipo;
                }
                else
                {
                    cmd.CommandText = "UPDATE Fornecedores" +
                    " SET for_razaoSocial=@for_razaoSocial," +
                    " for_ie = @for_ie, for_email = @for_email, for_cep = @for_cep," +
                    " for_logradouro = @for_logradouro, for_numero = @for_numero," +
                    " for_complemento = @for_complemento, for_bairro=@for_bairro," +
                    " for_cidade=@for_cidade, for_telefone=@for_telefone, for_fax=@for_fax," +
                    " for_status=@for_status,for_tipo_fornecedor=@for_tipo_fornecedor, for_tipo=@for_tipo" +
                    " WHERE" +
                    " for_codigo=@for_codigo";

                    cmd.Parameters.Add(new SqlParameter("@for_codigo", SqlDbType.Int)).Value = for_codigo;
                    cmd.Parameters.Add(new SqlParameter("@for_razaoSocial", SqlDbType.VarChar)).Value = for_razaoSocial;
                    cmd.Parameters.Add(new SqlParameter("@for_cnpj", SqlDbType.VarChar)).Value = for_cnpj;
                    cmd.Parameters.Add(new SqlParameter("@for_ie", SqlDbType.VarChar)).Value = for_ie;
                    cmd.Parameters.Add(new SqlParameter("@for_email", SqlDbType.VarChar)).Value = for_email;
                    cmd.Parameters.Add(new SqlParameter("@for_cep", SqlDbType.VarChar)).Value = for_cep;
                    cmd.Parameters.Add(new SqlParameter("@for_logradouro", SqlDbType.VarChar)).Value = for_logradouro;
                    cmd.Parameters.Add(new SqlParameter("@for_numero", SqlDbType.VarChar)).Value = for_numero;
                    cmd.Parameters.Add(new SqlParameter("@for_complemento", SqlDbType.VarChar)).Value = for_complemento;
                    cmd.Parameters.Add(new SqlParameter("@for_bairro", SqlDbType.VarChar)).Value = for_bairro;
                    cmd.Parameters.Add(new SqlParameter("@for_cidade", SqlDbType.Int)).Value = for_cidade;
                    cmd.Parameters.Add(new SqlParameter("@for_telefone", SqlDbType.VarChar)).Value = for_telefone;
                    cmd.Parameters.Add(new SqlParameter("@for_fax", SqlDbType.VarChar)).Value = for_fax;
                    cmd.Parameters.Add(new SqlParameter("@for_status", SqlDbType.VarChar)).Value = for_status;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo_fornecedor", SqlDbType.VarChar)).Value = for_tipo_fornecedor;
                    cmd.Parameters.Add(new SqlParameter("@for_tipo", SqlDbType.VarChar)).Value = for_tipo;
                }
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int for_codigo)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Fornecedores" +
                    " WHERE" +
                    " for_codigo=@for_codigo";
                cmd.Parameters.Add(new SqlParameter("@for_codigo", SqlDbType.Int)).Value = for_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
        }

        //selecionar várias linhas
        public DataTable localizar(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Fornecedores" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao + "%";
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizar_SQLSERVER(String descricao, String coluna,String sqlserver)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                objD.Contexto_local(sqlserver);
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT for_codigo,for_razaoSocial,for_cnpj,for_ie,for_email,for_cep,for_logradouro,for_numero,for_complemento,for_bairro,for_cidade,for_telefone,for_fax,for_status,for_cpf,for_rg,for_tipo_fornecedor,for_nome,for_tipo FROM Fornecedores";
                   
               
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }



        public DataTable localizarLeave(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Fornecedores" +
                    " WHERE " + coluna + " like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = descricao;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        //selecionar uma linha - um código
        public int localizar(int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Fornecedores" +
                    " WHERE for_codigo = @codigo";
                cmd.Parameters.Add(new SqlParameter("@codigo",
                    SqlDbType.Int)).Value = codigo;
                tab = objD.ExecutaConsulta(cmd);
                cmd = null;
                objD = null;
                if (tab.Rows.Count > 0)
                    return int.Parse(tab.Rows[0][0].ToString());
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable localizarEmTudo(String descricao, String tipoPessoa)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "LocalizaFornecedor"; //Procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = "%" + descricao + "%";
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar)).Value = tipoPessoa;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        public DataTable localizarPrimeiroUltimo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "ultimo")
                {
                    cmd.CommandText = "SELECT for_codigo = max(for_codigo) FROM Fornecedores";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT for_codigo = min(for_codigo) FROM Fornecedores";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                     SqlDbType.VarChar)).Value = descricao;
                }
                tab = objD.ExecutaConsulta(cmd);

            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }

        public DataTable localizarProxAnterior(String descricao, int codigo)
        {
            DataTable tab = null;
            SqlCommand cmd = null;

            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                if (descricao == "proximo")
                    cmd.CommandText = "SELECT for_codigo FROM Fornecedores WHERE for_codigo = (SELECT MIN(for_codigo) FROM Fornecedores WHERE for_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT for_codigo FROM Fornecedores WHERE for_codigo = (SELECT MAX(for_codigo) FROM Fornecedores WHERE for_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }
    }
}
