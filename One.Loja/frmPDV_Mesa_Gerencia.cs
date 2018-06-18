using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Loja
{
    public partial class frmPDV_Mesa_Gerencia : Form
    {

        public Int32 id_mesa { get; set; }
        public Boolean fecha_mesa = false;
        decimal total = 0;
        int quantidade = 0;

        public frmPDV_Mesa_Gerencia()
        {
            InitializeComponent();

        }

        public void carrega_dados_mesa()
        {

            MesaBLL cmd = new MesaBLL();
            cmd.id = this.id_mesa;
            DataTable dt = cmd.seleciona_dados_mesa();

            this.total = 0;
            this.quantidade = 0;
            DataTable dt_produtos = cmd.seleciona_produtos_mesa();
            dataGridView1.DataSource = dt_produtos;

            for (int i = 0; i < dt_produtos.Rows.Count; i++)
            {
                this.total += decimal.Parse(dt_produtos.Rows[i].ItemArray[4].ToString());
                this.quantidade += int.Parse(dt_produtos.Rows[i].ItemArray[2].ToString());
            }

            lbl_quantidade.Text = "" + this.quantidade;
            lbl_total.Text = "R$ " + this.total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPesquisaProdutoNovo cmd = new frmPesquisaProdutoNovo(this);
            cmd.ShowDialog();

            if (cmd.Codigo != null && cmd.Codigo != "")
            {
                frm_quantidade cmd_qtd = new frm_quantidade();
                cmd_qtd.ShowDialog();

                if (cmd_qtd.quantidade > 0)
                {

                    MesaBLL xcmd = new MesaBLL();
                    xcmd.id = this.id_mesa;
                    xcmd.quantidade = cmd_qtd.quantidade;
                    xcmd.codigo_produto = cmd.id_produto;
                    xcmd.adicionar_produto_mesa();
                }
                else
                {
                    MessageBox.Show("Quantidade informada não pode ser 0.");
                    cmd_qtd.ShowDialog();

                    if (cmd_qtd.quantidade > 0)
                    {

                        MesaBLL xcmd = new MesaBLL();
                        xcmd.id = this.id_mesa;
                        xcmd.codigo_produto = cmd.id_produto;
                        xcmd.adicionar_produto_mesa();
                    }
                }
            }

            carrega_dados_mesa();
        }

        private void frmPDV_Mesa_Gerencia_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.fecha_mesa = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente devolver este produto ? Essa ação não poderá ser desfeita", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    MesaBLL cmd = new MesaBLL();
                    cmd.id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    cmd.deleta_item_mesa();
                    carrega_dados_mesa();
                }

            }
            catch (Exception ee)
            {

            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {


            }
            catch (Exception ee)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
