using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class EmpresaDAL
    {
         Contexto objD = null;

        public EmpresaDAL()
        {

        }

        //inserção
        public void inserir(int regime, String emp_razaoSocial, String emp_nomeFantasia, String emp_logradouro, 
            String emp_numero, String emp_bairro, String emp_cep,int emp_estado, int emp_cidade, String emp_inscricaoEstadual, String emp_inscricaoMunicipal,
            String emp_cnpj, String emp_telefone, String emp_fax, Decimal emp_valorJuros, Decimal emp_multa, int emp_qtdDias)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                
                cmd.CommandText = "INSERT INTO Empresa (emp_regime, emp_razaoSocial,emp_nomeFantasia,emp_logradouro,"+
                    " emp_numero, emp_bairro, emp_cep,emp_estado, emp_cidade, emp_inscricaoEstadual,emp_inscricaoMunicipal,"+
                    " emp_cnpj, emp_telefone, emp_fax,emp_valorJuros,emp_multa,emp_qtdDias)"+
                    " VALUES (@emp_regime,@emp_razaoSocial,@emp_nomeFantasia,@emp_logradouro," +
                    " @emp_numero, @emp_bairro, @emp_cep,@emp_estado, @emp_cidade, @emp_inscricaoEstadual,@emp_inscricaoMunicipal," +
                    " @emp_cnpj, @emp_telefone, @emp_fax,@emp_valorJuros,@emp_multa,@emp_qtdDias)";

                cmd.Parameters.Add(new SqlParameter("@emp_regime", SqlDbType.Int)).Value = regime;
                cmd.Parameters.Add(new SqlParameter("@emp_razaoSocial", SqlDbType.VarChar)).Value = emp_razaoSocial;
                cmd.Parameters.Add(new SqlParameter("@emp_nomeFantasia", SqlDbType.VarChar)).Value = emp_nomeFantasia;
                cmd.Parameters.Add(new SqlParameter("@emp_logradouro", SqlDbType.VarChar)).Value = emp_logradouro;
                cmd.Parameters.Add(new SqlParameter("@emp_numero", SqlDbType.VarChar)).Value = emp_numero;
                cmd.Parameters.Add(new SqlParameter("@emp_bairro", SqlDbType.VarChar)).Value = emp_bairro;
                cmd.Parameters.Add(new SqlParameter("@emp_cep", SqlDbType.VarChar)).Value = emp_cep;
                cmd.Parameters.Add(new SqlParameter("@emp_estado", SqlDbType.Int)).Value = emp_estado;
                cmd.Parameters.Add(new SqlParameter("@emp_cidade", SqlDbType.Int)).Value = emp_cidade;
                cmd.Parameters.Add(new SqlParameter("@emp_inscricaoEstadual", SqlDbType.VarChar)).Value = emp_inscricaoEstadual;
                cmd.Parameters.Add(new SqlParameter("@emp_inscricaoMunicipal", SqlDbType.VarChar)).Value = emp_inscricaoMunicipal;                
                cmd.Parameters.Add(new SqlParameter("@emp_cnpj", SqlDbType.VarChar)).Value = emp_cnpj;
                cmd.Parameters.Add(new SqlParameter("@emp_telefone", SqlDbType.VarChar)).Value = emp_telefone;
                cmd.Parameters.Add(new SqlParameter("@emp_fax", SqlDbType.VarChar)).Value = emp_fax;
                cmd.Parameters.Add(new SqlParameter("@emp_valorJuros", SqlDbType.Decimal)).Value = emp_valorJuros;
                cmd.Parameters.Add(new SqlParameter("@emp_multa", SqlDbType.Decimal)).Value = emp_multa;
                cmd.Parameters.Add(new SqlParameter("@emp_qtdDias", SqlDbType.Int)).Value = emp_qtdDias;
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void alterar(int emp_regime, int emp_codigo, String emp_razaoSocial, String emp_nomeFantasia, String emp_logradouro,
            String emp_numero, String emp_bairro, String emp_cep,int emp_estado, int emp_cidade, String emp_inscricaoEstadual,String emp_inscricaoMunicipal,
            String emp_cnpj, String emp_telefone, String emp_fax, Decimal emp_valorJuros, Decimal emp_multa, int emp_qtdDias)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Empresa" +
                    " SET emp_regime=@emp_regime, emp_razaoSocial=@emp_razaoSocial, emp_nomeFantasia= @emp_nomeFantasia, emp_logradouro=@emp_logradouro," +
                    " emp_numero=@emp_numero, emp_bairro=@emp_bairro, emp_cep=@emp_cep,emp_estado=@emp_estado, emp_cidade=@emp_cidade,"+
                    " emp_inscricaoEstadual=@emp_inscricaoEstadual, emp_inscricaoMunicipal = @emp_inscricaoMunicipal, emp_cnpj=@emp_cnpj, emp_telefone=@emp_telefone," +
                    " emp_fax=@emp_fax,emp_valorJuros=@emp_valorJuros,emp_multa=@emp_multa,emp_qtdDias=@emp_qtdDias" +
                    " WHERE" +
                    " emp_codigo=@emp_codigo";

                cmd.Parameters.Add(new SqlParameter("@emp_regime", SqlDbType.Int)).Value = emp_regime;
                cmd.Parameters.Add(new SqlParameter("@emp_codigo", SqlDbType.Int)).Value = emp_codigo;
                cmd.Parameters.Add(new SqlParameter("@emp_razaoSocial", SqlDbType.VarChar)).Value = emp_razaoSocial;
                cmd.Parameters.Add(new SqlParameter("@emp_nomeFantasia", SqlDbType.VarChar)).Value = emp_nomeFantasia;
                cmd.Parameters.Add(new SqlParameter("@emp_logradouro", SqlDbType.VarChar)).Value = emp_logradouro;
                cmd.Parameters.Add(new SqlParameter("@emp_numero", SqlDbType.VarChar)).Value = emp_numero;
                cmd.Parameters.Add(new SqlParameter("@emp_bairro", SqlDbType.VarChar)).Value = emp_bairro;
                cmd.Parameters.Add(new SqlParameter("@emp_cep", SqlDbType.VarChar)).Value = emp_cep;
                cmd.Parameters.Add(new SqlParameter("@emp_estado", SqlDbType.Int)).Value = emp_estado;
                cmd.Parameters.Add(new SqlParameter("@emp_cidade", SqlDbType.Int)).Value = emp_cidade;
                cmd.Parameters.Add(new SqlParameter("@emp_inscricaoEstadual", SqlDbType.VarChar)).Value = emp_inscricaoEstadual;
                cmd.Parameters.Add(new SqlParameter("@emp_inscricaoMunicipal", SqlDbType.VarChar)).Value = emp_inscricaoMunicipal;                
                cmd.Parameters.Add(new SqlParameter("@emp_cnpj", SqlDbType.VarChar)).Value = emp_cnpj;
                cmd.Parameters.Add(new SqlParameter("@emp_telefone", SqlDbType.VarChar)).Value = emp_telefone;
                cmd.Parameters.Add(new SqlParameter("@emp_fax", SqlDbType.VarChar)).Value = emp_fax;
                cmd.Parameters.Add(new SqlParameter("@emp_valorJuros", SqlDbType.Decimal)).Value = emp_valorJuros;
                cmd.Parameters.Add(new SqlParameter("@emp_multa", SqlDbType.Decimal)).Value = emp_multa;
                cmd.Parameters.Add(new SqlParameter("@emp_qtdDias", SqlDbType.Int)).Value = emp_qtdDias;
                objD.ExecutaComando(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            cmd = null;
            objD = null;
        }

        public void excluir(int emp_codigo)
        {

            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Empresa" +
                    " WHERE" +
                    " emp_codigo=@emp_codigo";
                cmd.Parameters.Add(new SqlParameter("@emp_codigo", SqlDbType.Int)).Value = emp_codigo;
                objD.ExecutaComando(cmd);
            }
            catch (Exception)
            {

                throw;
            }
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
                cmd.CommandText = "SELECT * FROM Empresa" +
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

        public DataTable localizarLeave(String descricao, String coluna)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Empresa" +
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
                cmd.CommandText = "SELECT * FROM Empresa" +
                    " WHERE emp_codigo = @codigo";
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

        public DataTable localizarEmTudo(String descricao)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = "SELECT TOP 100 * FROM Empresa" +
                    " WHERE emp_codigo like @descricao or emp_razaoSocial like @descricao or emp_nomeFantasia like @descricao"+
                    " or emp_numero like @descricao or emp_bairro like @descricao or emp_cep like @descricao or emp_cidade like @descricao"+
                    " or emp_inscricaoEstadual like @descricao or emp_cnpj like @descricao or emp_telefone like @descricao or emp_fax like @descricao";
                cmd.Parameters.Add(new SqlParameter("@descricao",
                    SqlDbType.VarChar)).Value = "%" + descricao + "%";

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
                    cmd.CommandText = "SELECT emp_codigo = max(emp_codigo) FROM Empresa";
                    cmd.Parameters.Add(new SqlParameter("@descricao",
                         SqlDbType.VarChar)).Value = descricao;
                }
                else if (descricao == "primeiro")
                {
                    cmd.CommandText = "SELECT emp_codigo = min(emp_codigo) FROM Empresa";
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
                    cmd.CommandText = "SELECT emp_codigo FROM Empresa WHERE emp_codigo = (SELECT MIN(emp_codigo) FROM Empresa WHERE emp_codigo > @codigo)";

                else if (descricao == "anterior")
                    cmd.CommandText = "SELECT emp_codigo FROM Empresa WHERE emp_codigo = (SELECT MAX(emp_codigo) FROM Empresa WHERE emp_codigo < @codigo)"; ;

                cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return tab;
        }


        public void atualiza_informacoes_fiscais(String codigo_vinculacao,Double empresa_tributo,Double empresa_reducao)
        {
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();


                cmd.CommandText = "delete from configuracao; insert into configuracao(cnpj_sh,codigo_vinculacao,empresa_tributo,empresa_reducao) "
                    + "values(11444406000180,@codigo_vinculacao,@empresa_tributo,@empresa_reducao)";
                
                cmd.Parameters.Add(new SqlParameter("@codigo_vinculacao", SqlDbType.NChar)).Value = codigo_vinculacao;
                cmd.Parameters.Add(new SqlParameter("@empresa_tributo", SqlDbType.Decimal)).Value = empresa_tributo;
                cmd.Parameters.Add(new SqlParameter("@empresa_reducao", SqlDbType.Decimal)).Value = empresa_reducao;

                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
