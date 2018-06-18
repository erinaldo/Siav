using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Dal;
namespace One
{
    public partial class frm_conexao : Form
    {
        public frm_conexao()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            this.Hide();

            GlobalDAL.Con = cbAcessoBanco.SelectedItem.ToString();            

            //PDV.Login_ frm = new PDV.Login_();            

            //Menu frm = new Menu();            
            //frm.ShowDialog();

            //frm = null;

            this.Close();
        }

        private void frm_conexao_Load(object sender, EventArgs e)
        {
            try
            {
                #if DEBUG

                cbAcessoBanco.SelectedIndex = 0; //Quando for liberar para o cliente, mudar o indíce aqui

                #else   

                cbAcessoBanco.SelectedIndex = 1; //Quando for liberar para o cliente, mudar o indíce aqui

                #endif

                //Retirar o comentário, assim o cliente não precisará escolher a conexão do banco de dados para logar no sistema
                btEntrar_Click(sender, e); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbAcessoBanco_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btEntrar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cbAcessoBanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
