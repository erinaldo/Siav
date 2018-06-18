using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace One.Dal
{
    public class UsuarioDAL
    {
        public UsuarioDAL()
        {

        }

        //inserção
        public void InserirUsuario(String nome, String login, String senha, String status, int permissao, int empresa, string email)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "ALTER DATABASE MyDatabaseName SET READ_WRITE";

                    cmd.CommandText = string.Concat("INSERT INTO Usuario (usu_nome, usu_login, usu_senha, usu_status, per_codigo, emp_codigo, usu_email) ",
                                                    "VALUES (@nome,@login, @senha, @status, @permissao, @empresa, @email)");

                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = nome;
                    cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar)).Value = login;
                    cmd.Parameters.Add(new SqlParameter("@senha", SqlDbType.VarChar)).Value = senha;
                    cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = status;
                    cmd.Parameters.Add(new SqlParameter("@permissao", SqlDbType.Int)).Value = permissao;
                    cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.Int)).Value = empresa;
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;

                    using (Contexto contexto = new Contexto())
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

        //alterar
        public void AlterarUsuario(int codigo, String nome, String login, String senha, String status, int permissao, int empresa, string email)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat("UPDATE Usuario SET ",
                                                        "usu_nome= @nome, ",
                                                        "usu_login= @login, ",
                                                        "usu_senha = @senha, ",
                                                        "usu_status = @status, ",
                                                        "per_codigo = @permissao, ",
                                                        "emp_codigo = @empresa, ",
                                                        "usu_email = @email ",
                                                    "WHERE ",
                                                        "usu_codigo=@codigo");

                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;
                    cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = nome;
                    cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar)).Value = login;
                    cmd.Parameters.Add(new SqlParameter("@senha", SqlDbType.VarChar)).Value = senha;
                    cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar)).Value = status;
                    cmd.Parameters.Add(new SqlParameter("@permissao", SqlDbType.Int)).Value = permissao;
                    cmd.Parameters.Add(new SqlParameter("@empresa", SqlDbType.Int)).Value = empresa;
                    cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;

                    using (Contexto contexto = new Contexto())
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

        public void ExcluirUsuario(int usu_codigo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM Usuario WHERE usu_codigo=@usu_codigo";

                    cmd.Parameters.Add(new SqlParameter("@usu_codigo", SqlDbType.Int)).Value = usu_codigo;

                    using (Contexto contexto = new Contexto())
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

        public DataTable LocalizarUsuario(String descricao, String coluna)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat("SELECT * FROM Usuario WHERE ", coluna, " like @descricao");

                    cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao + "%";

                    using (Contexto contexto = new Contexto())
                    {
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

        public DataTable LocalizarLeave(String descricao, String coluna)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat("SELECT * FROM Usuario WHERE ", coluna, " like @descricao");

                    cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;

                    using (Contexto contexto = new Contexto())
                    {
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

        public int LocalizarUsuario(int codigo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario WHERE usu_codigo = @codigo";

                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                    using (Contexto contexto = new Contexto())
                    {
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

        public Boolean primeiro_acesso()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario";

                    Contexto contexto = new Contexto();

                    DataTable tab = contexto.ExecutaConsulta(cmd);

                    if (tab.Rows.Count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LocalizarEmTudo(String descricao)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT TOP 100 u.usu_codigo as [Código do Usuário], u.usu_nome as Nome, u.usu_login as [Login], " +
                                    " u.usu_status as [Status], e.emp_razaoSocial as [Razão Social],p.per_nome [Permissão] ,u.per_codigo [Código da Permissão],u.emp_codigo [Código da Empresa] " +
                                    " FROM Empresa e Inner Join Usuario u ON e.emp_codigo = u.emp_codigo inner join Permissao p on u.per_codigo = p.per_codigo" +
                                    " WHERE u.usu_codigo like @descricao or u.usu_nome like @descricao or u.usu_login like @descricao or u.usu_status like @descricao" +
                                    " or e.emp_razaoSocial like @descricao or p.per_nome like @descricao";

                    cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = "%" + descricao + "%";

                    using (Contexto contexto = new Contexto())
                    {
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

        public DataTable LocalizarPrimeiroUltimo(String descricao)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (descricao == "ultimo")
                    {
                        cmd.CommandText = "SELECT usu_codigo = max(usu_codigo) FROM Usuario";

                        cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                    }
                    else if (descricao == "primeiro")
                    {
                        cmd.CommandText = "SELECT usu_codigo = min(usu_codigo) FROM Usuario";

                        cmd.Parameters.Add(new SqlParameter("@descricao", SqlDbType.VarChar)).Value = descricao;
                    }

                    using (Contexto contexto = new Contexto())
                    {
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

        public DataTable LocalizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (descricao == "proximo")
                    {
                        cmd.CommandText = "SELECT usu_codigo FROM Usuario WHERE usu_codigo = (SELECT MIN(usu_codigo) FROM Usuario WHERE usu_codigo > @codigo)";
                    }
                    else if (descricao == "anterior")
                    {
                        cmd.CommandText = "SELECT usu_codigo FROM Usuario WHERE usu_codigo = (SELECT MAX(usu_codigo) FROM Usuario WHERE usu_codigo < @codigo)"; ;
                    }

                    cmd.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int)).Value = codigo;

                    using (Contexto contexto = new Contexto())
                    {
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

        public DataTable LocalizarLogin(String usuario, String senha)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM Usuario WHERE usu_login = @usuario and usu_senha = @senha";

                    cmd.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar)).Value = usuario;
                    cmd.Parameters.Add(new SqlParameter("@senha", SqlDbType.VarChar)).Value = senha;

                    using (Contexto contexto = new Contexto())
                    {
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
        /// Método responsável por redefinir a senha do usuário.
        /// </summary>
        public void RedefinirSenhaUsuario(int idUsuario)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = string.Concat("UPDATE usuario SET usu_senha = 123 WHERE usu_codigo = ", idUsuario);

                    using (Contexto contexto = new Contexto())
                    {
                        contexto.ExecutaComando(cmd);
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
