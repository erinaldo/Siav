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

namespace One.Loja
{
    public partial class frmTreeViewDebitos : Form
    {
        public frmTreeViewDebitos()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                CarregarTreeView();
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
                    PopulateTreeView(int.Parse(tab.Rows[i]["ID"].ToString()), parentNode);
                }
                treeView1.ExpandAll();
                treeView1.Update();
            }
        }

        private void PopulateTreeView(int p, TreeNode parentNode)
        {
            DataTable tab = null;
            tab = ConsultaTipoDeOpercaoTodos(p);
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
                        "Select ID = v.ven_cliente , Nome = convert(varchar,convert(varchar,v.ven_dataVenda,103) + '/' + convert(varchar,sum(v.ven_valorfinal)))  , Valor = sum(v.ven_valorfinal) From Vendas v join Cliente cli on cli.cli_codigo = v.ven_cliente Where v.ven_cliente = @ID Group by v.ven_dataVenda,v.ven_cliente order by v.ven_dataVenda "
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
                       "Select ID = v.ven_cliente , Nome =cli.cli_nome + '..................................................'+ Convert(varchar,sum(cr.cr_valorAlterado)), Valor = sum(cr.cr_valorAlterado) From ContasAReceber Cr Join Vendas v on v.ven_codigo = cr.cr_vendas join Cliente cli on cli.cli_codigo = v.ven_cliente  Where cr.cr_status = 'Aberto' Group by ven_cliente,cli.cli_nome order by Nome"
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

        private void frmTreeViewDebitos_Load(object sender, EventArgs e)
        {

        }
    }
}
