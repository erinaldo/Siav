using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using View;

namespace One.Relatorios
{
    public partial class frmHistoricoEstoque : Form
    {
        public frmHistoricoEstoque()
        {
            InitializeComponent();
        }
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public string codigo = "";
       
        private void frmHistoricoEstoque_Load(object sender, EventArgs e)
        {
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboProduto, "Produtos", "pro_codigo", "pro_nome", "", "");
            objD = null;
            cboProduto.SelectedIndex = -1;

            dataGridView1.AutoSizeColumnsMode =
         DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VendasDAL ven = new VendasDAL();
            try
            {
                if (cboProduto.SelectedIndex > -1)
                {
                    codigo = cboProduto.SelectedValue.ToString();
                }
                else
                {
                    codigo = "0";
                }

                DataTable tab = null;
                dataInicial = txtDtInicial.Value;
                dataFinal = txtDtFinal.Value;

                tab = ven.EstoqueHistoricoProduto(int.Parse(codigo), dataInicial, dataFinal);
                dataGridView1.DataSource = tab;
                //if (tab.Rows.Count > 0)
                //{
                //    pictureBox1.Visible = true;
                //    btnver.Visible = true;
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            /* Pegando valor de uma celula do DataGridView */
            string valor = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (valor == "SAÌDA")
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
            }
            else if (valor == "ENTRADA")
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else if (valor == "SALDO")
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
    }
}
