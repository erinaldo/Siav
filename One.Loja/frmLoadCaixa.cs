using One.Dal;
//using One.Dal;
using One.MENUS;
using One.MOVIMENTACOES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace One.Loja
{
    public partial class frmLoadCaixa : Form
    {
        public frmLoadCaixa()
        {
            InitializeComponent();
          



        }
        Button btn = null;
        Button btnCaixa = null;
        Label label = null;
        int posVert = 0;
        public DataTable CarregarCategoriasSQL()
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select ID = ca.fin_codigo,Caixa = ca.fin_caixa,Usuario = usu.usu_nome From fin_abertura_caixa ca join usuario usu on usu.usu_codigo = ca.fin_usuario where ca.Fechou is null");
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        private void CarregarPanelCaixaAberto()
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                DataTable tab = CarregarCategoriasSQL();
                panelCategorias.AutoScroll = true;
                panelCategorias.Controls.Clear();
                panelCategorias.Update();
                for (int i = 0; i <= tab.Rows.Count - 1; i++)
                {
                    btnCaixa = new Button();
                    btnCaixa.Text = tab.Rows[i]["Caixa"].ToString() + ":" + tab.Rows[i]["Usuario"].ToString();
                    btnCaixa.Name = tab.Rows[i]["Caixa"].ToString();
                    btnCaixa.BackColor = Color.White;
                    btnCaixa.TextAlign = ContentAlignment.BottomCenter;
                    this.btnCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    this.btnCaixa.BackgroundImage = global::One.Loja.Properties.Resources._53;
                    this.btnCaixa.FlatAppearance.BorderSize = 0;
                    btnCaixa.ForeColor = Color.Black;
                    btnCaixa.BackColor = Color.Transparent;
                    btnCaixa.FlatStyle = FlatStyle.Flat;
                    btnCaixa.Click += btnCat_Click;
                    btnCaixa.Location = new Point(20, posVert);
                    btnCaixa.Left = 20;
                    btnCaixa.Top = posVert;
                    btnCaixa.Width = 70;
                    btnCaixa.Height = 100;
                    btnCaixa.Font = new Font("Tahoma", 6, FontStyle.Bold);
                    posVert = posVert + 70;
                    panelCategorias.Controls.Add(btnCaixa);
                    panelCategorias.HorizontalScroll.Enabled = true;
                }
                tab = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            Button btnCaixa = sender as Button;
            this.Hide();
            frmLogon frm = new frmLogon();
            frm.cboCaixa.Text = btnCaixa.Name.ToString();
            frm.cboCaixa.Enabled = false;
            //  frm.lblOkCaixa.Text = "TRUE";
            frm.ShowDialog();
        }

        private void frmLoadCaixa_Load(object sender, EventArgs e)
        {
            CarregarPanelCaixaAberto();
            if (panelCategorias.Controls.Count > 0)
            {
                lblInfoCx.Text = "Existe Caixas Aberto.";
            }
            else
            {
                lblInfoCx.Text = "Não existe caixas Aberto.";
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {

            this.Hide();
            frmLogon frm = new frmLogon();
            frm.cboCaixa.Focus();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
