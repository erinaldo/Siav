using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using Microsoft.VisualBasic;

namespace One
{
    public partial class verificacaoUsuario : Form
    {
        public verificacaoUsuario()
        {
            InitializeComponent();
           
        }
        public String permissao;
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLogin.Text == "")
                    throw new Exception("Por favor, informe um login válido");
                if (txtSenha.Text == "")
                    throw new Exception("Por favor, informe uma senha");
                UsuarioBLL objUsu = new UsuarioBLL();
                objUsu.LocalizarLogin(txtLogin.Text, txtSenha.Text);
                if (objUsu.per_codigo != 0)
                {
                    PermissaoBLL objPer = new PermissaoBLL();
                    objPer.localizar(objUsu.per_codigo.ToString(), "per_codigo");
                   

                    if(objPer.per_nome=="Gerente")
                        permissao = "Gerente"; //objPer.per_nome;
                    else
                        permissao = "";
                    objPer = null;
                }
                objUsu = null;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                txtLogin.Text = "";
                txtSenha.Text = "";
                permissao = "";                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLogin_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //        btSalvar_Click(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void txtSenha_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //        btSalvar_Click(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void verificacaoUsuario_Load(object sender, EventArgs e)
        {
            permissao = "Gerente";
            this.Close();
        }
    }
}
