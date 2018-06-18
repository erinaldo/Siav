using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFi
{
    public partial class frmTipoDeOperacao : Form
    {
        public frmTipoDeOperacao()
        {
            InitializeComponent();
        }
        Contexto con = new Contexto();
       

        private void Limpar()
        {
            txtCodigo.Text = "";
            txtGrupo.Text = "";
            txtNome.Text = "";
            cboSinal.SelectedIndex = -1;
            cboSinal.Text = "";
            txtGrupo.Text = "";
            cboGrupo.SelectedIndex = -1;
        }

        private void InserirTipoDeOperacao(string tipo)
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                if (tipo == "Tpo")
                {
                    cmd.CommandText = String.Concat(
                                    "Insert TipoDeOperacao  ",
                                             "     (Grupo ",
                                              "  ,	Nome     ",
                                              "  ,	Sinal , Nivel )",
                                         " VALUES",
                                           "     (@Grupo ",
                                              "  ,	@Nome     ",
                                              "  ,	@Sinal, 2 )"
                                             );
                    cmd.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.Int)).Value = cboGrupo.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = txtNome.Text;
                    cmd.Parameters.Add(new SqlParameter("@Sinal ", SqlDbType.VarChar)).Value = cboSinal.Text;
                }
                else if (tipo == "Gru")
                {
                    cmd.CommandText = String.Concat(
                                   "Insert GrupoTpo  ",
                                            "     (Nome , Nivel ",
                                             "     )",
                                        " VALUES",
                                          "     (",
                                             "  	@Nome , 1   ",
                                             "   )"
                                            );

                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = txtGrupo.Text;


                }
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AtualizarObj(int cod, string tipo)
        {
            SqlCommand cmd = null;
            try
            {
                if (tipo == "Tpo")
                {
                    con = new Contexto();
                    cmd = new SqlCommand();
                    cmd.CommandText = String.Concat(
                                    "Update TipoDeOperacao  Set",
                                             "     Grupo = @Grupo",
                                              "  ,	Nome = @Nome    ",
                                              "  ,	Sinal = @Sinal",
                                              " Where ID = @ID"
                                             );
                    cmd.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.Int)).Value = cboGrupo.SelectedValue;
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar)).Value = txtNome.Text;
                    cmd.Parameters.Add(new SqlParameter("@Sinal ", SqlDbType.VarChar)).Value = cboSinal.Text;
                    cmd.Parameters.Add(new SqlParameter("@ID ", SqlDbType.VarChar)).Value = int.Parse(txtCodigo.Text);
                }
                else if (tipo == "Gru")
                {
                    con = new Contexto();
                    cmd = new SqlCommand();
                    cmd.CommandText = String.Concat(
                                    "Update GrupoTpo  Set",
                                             "     Nome = @Grupo",
                                              "    Where ID = @ID"
                                             );
                    cmd.Parameters.Add(new SqlParameter("@Grupo", SqlDbType.VarChar)).Value = txtGrupo.Text;
                    cmd.Parameters.Add(new SqlParameter("@ID ", SqlDbType.VarChar)).Value = int.Parse(txtGrupoID.Text);
                }
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private DataTable ConsultaTipoDeOpercaoTodos(int ID)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                        "Select Nome , Sinal From TipoDeOperacao Where Grupo = @ID "
                    );
                cmd.Parameters.Add(new SqlParameter("@ID ", SqlDbType.Int)).Value = ID;
                tab = con.ExecutaConsulta(cmd);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        private DataTable ConsultaTipoDeOpercaoGrupo()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                       "Select ID , Nome From GrupoTpo"
                    );
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        private DataTable ConsultaObj(int ID, string tipo)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                if (tipo == "Tpo")
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = String.Concat
                        (
                            "SELECT ID,*",
                              " FROM TipoDeOperacao ",
                              " Where ID = @ID"
                        );
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
                }
                else if (tipo == "Gru")
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = String.Concat
                        (
                            "SELECT ID,*",
                              " FROM GrupoTpo ",
                              "  Where ID = @ID "
                        );
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
                }
                tab = con.ExecutaConsulta(cmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }

        private void Validacao(string tipo)
        {
            try
            {
                if (tipo == "Tpo")
                {
                    if (txtNome.Text == "")
                        throw new Exception("Informe o nome da operação");
                    if (cboGrupo.SelectedValue == null)
                        throw new Exception("Informe o grupo");
                    if (cboSinal.Text == "")
                        throw new Exception("Informe o sinal");
                }
                else if (tipo == "Gru")
                {
                    if (txtGrupo.Text == "")
                        throw new Exception("Informe o grupo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void CarregarTreeView()
        {
            DataTable tab = null;
            tab = ConsultaTipoDeOpercaoGrupo();
            TreeNode parentNode = null;
            if (tab.Rows.Count > 0)
            {
                
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    parentNode = treeView1.Nodes.Add(tab.Rows[i]["Nome"].ToString());
                    PopulateTreeView(int.Parse(tab.Rows[i]["ID"].ToString()),parentNode);
                }
                treeView1.ExpandAll();
                treeView1.Update();
            }
        }
        private void PopulateTreeView(int parentId, TreeNode parentNode)
        {
             DataTable tab = null;
             tab = ConsultaTipoDeOpercaoTodos(parentId);
            if (tab.Rows.Count > 0)
            {
                TreeNode childNode;
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    if (parentNode == null)
                        childNode = treeView1.Nodes.Add(tab.Rows[i]["Nome"].ToString());
                    else
                        childNode = parentNode.Nodes.Add(tab.Rows[i]["Nome"].ToString());
                    //PopulateTreeView(Convert.ToInt32(dr["MNUSUBMENU"].ToString()), childNode);
                }
            }
        }
        private void frmTipoDeOperacao_Load(object sender, EventArgs e)
        {
            //http://www.c-sharpcorner.com/UploadFile/c5c6e2/populate-a-treeview-dynamically/
            CarregarTreeView();
            CarregarCombo();
        }

        private void CarregarCombo()
        {
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboGrupo, "GrupoTpo", "ID", "Nome", "", "Nome");
            cboGrupo.SelectedIndex = -1;
            objD = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Validacao("Tpo");
            int cod = 0;
            if (txtCodigo.Text != "")
            {
                cod = int.Parse(txtCodigo.Text);
            }
            else
            {
                cod = 0;
            }
            DataTable tab = null;
            tab = ConsultaObj(cod, "Tpo");
            //Atualizar
            if (tab.Rows.Count > 0)
            {
                AtualizarObj(cod, "Tpo");
            }
            //Insere Novo 
            else
            {
                InserirTipoDeOperacao("Tpo");

            }
            Limpar();
            MessageBox.Show("Operação realizada com sucesso!");
            treeView1.Nodes.Clear();
            CarregarTreeView();
        }

        private void btnSalvarGrupo_Click(object sender, EventArgs e)
        {
            Validacao("Gru");
            int cod = 0;
            if (txtCodigo.Text != "")
            {
                cod = int.Parse(txtGrupoID.Text);
            }
            else
            {
                cod = 0;
            }
            DataTable tab = null;
            tab = ConsultaObj(cod, "Gru");
            //Atualizar
            if (tab.Rows.Count > 0)
            {
                AtualizarObj(cod, "Gru");
            }
            //Insere Novo 
            else
            {
                InserirTipoDeOperacao("Gru");

            }
            Limpar();
            CarregarCombo();
            MessageBox.Show("Operação realizada com sucesso!");
        }
    }
}
