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
    public partial class frm_Compras : Form
    {
        public frm_Compras()
        {
            InitializeComponent();
        }

        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public string codigo = "";
     
        private void button1_Click(object sender, EventArgs e)
        {
            ComprasDAL com = new ComprasDAL();
            try
            {
                if (cboFornecedor.SelectedIndex > -1)
                {
                    codigo = cboFornecedor.SelectedValue.ToString();
                }
                else
                {
                    codigo = "0";
                }

                DataTable tab = null;
                dataInicial = txtDtInicial.Value;
                dataFinal = txtDtFinal.Value;

                tab = com.TotalizadorCompras(int.Parse(codigo), dataInicial, dataFinal);
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

        private void frm_Compras_Load(object sender, EventArgs e)
        {
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboFornecedor, "Fornecedores", "for_codigo", "for_nome", "", "");
            objD = null;
            cboFornecedor.SelectedIndex = -1;
        }

        private void btImprimir_Click(object sender, EventArgs e){
            printDGV.Print_DataGridView(dataGridView1);
        }

        private void label4_Click(object sender, EventArgs e){

        }



    }
}
