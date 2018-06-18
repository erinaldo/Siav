using One.Bll;
using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using View;

namespace One
{
    public partial class frm_Vendas : Form
    {
        public frm_Vendas()
        {
            InitializeComponent();
        }
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        public string codigo = "";
       

        private void button1_Click(object sender, EventArgs e)
        {
            VendasDAL ven = new VendasDAL();
            try
            {
                if (cboCliente.SelectedIndex > -1)
                {
                    codigo = cboCliente.SelectedValue.ToString();
                }
                else
                {
                    codigo = "0";
                }

                DataTable tab = null;
                dataInicial = txtDtInicial.Value;
                dataFinal = txtDtFinal.Value;
            
                tab = ven.TotalizadorVendas(int.Parse(codigo),dataInicial,dataFinal);
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

        private void frm_Vendas_Load(object sender, EventArgs e)
        {
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboCliente, "Cliente", "cli_codigo", "cli_nome", "", "");
            objD = null;
            cboCliente.SelectedIndex = -1;


        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(dataGridView1);
            

        }
    }
}
