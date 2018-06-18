using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One.Dal;
using System.Data;

namespace One.Bll
{
    public class UsuarioBLL
    {
        #region Propriedades

        public int usu_codigo { get; set; }
        public String usu_nome { get; set; }
        public String usu_login { get; set; }
        public String usu_senha { get; set; }
        public String usu_status { get; set; }
        public string usu_email { get; set; }
        public int per_codigo { get; set; }
        public int emp_codigo { get; set; }

        public UsuarioDAL usuarioDal { get; set; }

        #endregion

        #region Contrutores

        public UsuarioBLL()
        {
            this.usuarioDal = new UsuarioDAL();
        }

        #endregion

        #region Métodos

        public void Limpar()
        {
            this.usu_codigo = 0;
            this.usu_nome = null;
            this.usu_login = null;
            this.usu_senha = null;
            this.usu_status = null;
            this.per_codigo = 0;
            this.emp_codigo = 0;
            this.usu_email = string.Empty;
        }

        public void Inserir()
        {
            try
            {
                usuarioDal.InserirUsuario(this.usu_nome, this.usu_login, this.usu_senha, this.usu_status, this.per_codigo, this.emp_codigo, this.usu_email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Alterar()
        {
            try
            {
                usuarioDal.AlterarUsuario(this.usu_codigo, this.usu_nome, this.usu_login, this.usu_senha, this.usu_status, this.per_codigo, this.emp_codigo, this.usu_email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir()
        {
            try
            {
                usuarioDal.ExcluirUsuario(this.usu_codigo);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Localizar()
        {
            try
            {
                this.usu_codigo = usuarioDal.LocalizarUsuario(this.usu_codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean Primeiro_acesso()
        {
            try
            {
                return usuarioDal.primeiro_acesso();
            }
            catch (Exception)
            {
                return true;
            }
        }

        public void Localizar(String descricao, String atributo)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarUsuario(descricao, atributo);

                if (tab.Rows.Count > 0)
                {
                    this.usu_codigo = int.Parse(tab.Rows[0]["usu_codigo"].ToString());
                    this.usu_nome = tab.Rows[0]["usu_nome"].ToString();
                    this.usu_login = tab.Rows[0]["usu_login"].ToString();
                    this.usu_senha = tab.Rows[0]["usu_senha"].ToString();
                    this.usu_status = tab.Rows[0]["usu_status"].ToString();
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.emp_codigo = int.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.usu_email = tab.Rows[0]["usu_email"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LocalizarLeave(String descricao, String atributo)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarLeave(descricao, atributo);

                if (tab.Rows.Count > 0)
                {
                    this.usu_codigo = int.Parse(tab.Rows[0]["usu_codigo"].ToString());
                    this.usu_nome = tab.Rows[0]["usu_nome"].ToString();
                    this.usu_login = tab.Rows[0]["usu_login"].ToString();
                    this.usu_senha = tab.Rows[0]["usu_senha"].ToString();
                    this.usu_status = tab.Rows[0]["usu_status"].ToString();
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.emp_codigo = int.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.usu_email = tab.Rows[0]["usu_email"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LocalizarComRetorno(String descricao, String atributo)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarUsuario(descricao, atributo);

                return tab;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable LocalizarEmTudo(String descricao)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarEmTudo(descricao);

                return tab;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LocalizarPrimeiroUltimo(String descricao)
        {
            try
            {
                int codigo = 0;

                DataTable tab = usuarioDal.LocalizarPrimeiroUltimo(descricao);

                if (tab.Rows.Count > 0)
                {
                    int.TryParse(tab.Rows[0][0].ToString(), out codigo);
                }

                this.usu_codigo = codigo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LocalizarProxAnterior(String descricao, int codigo)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarProxAnterior(descricao, codigo);

                if (tab.Rows.Count > 0)
                {
                    this.usu_codigo = int.Parse(tab.Rows[0][0].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LocalizarLogin(String usuario, String senha)
        {
            try
            {
                DataTable tab = usuarioDal.LocalizarLogin(usuario, senha);

                if (tab.Rows.Count > 0)
                {
                    this.usu_codigo = int.Parse(tab.Rows[0]["usu_codigo"].ToString());
                    this.usu_nome = tab.Rows[0]["usu_nome"].ToString();
                    this.usu_login = tab.Rows[0]["usu_login"].ToString();
                    this.usu_senha = tab.Rows[0]["usu_senha"].ToString();
                    this.usu_status = tab.Rows[0]["usu_status"].ToString();
                    this.per_codigo = int.Parse(tab.Rows[0]["per_codigo"].ToString());
                    this.emp_codigo = int.Parse(tab.Rows[0]["emp_codigo"].ToString());
                    this.usu_email = tab.Rows[0]["usu_email"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Método responsável por consulta um usuário pelo endereço de e-mail do mesmo.
        /// </summary>
        public void VerificarUsuarioPorEmail(string email)
        {
            Localizar(email, "usu_email");
        }

        public void AtualizarSenhaUsuario(int codigoUsuario)
        {
            this.usuarioDal.RedefinirSenhaUsuario(codigoUsuario);
        }
    }
}
