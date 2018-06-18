using One.Bll;
using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Movimentacoes
{
    public partial class Gestao_Vendas : Form
    {
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        public Gestao_Vendas(){

            InitializeComponent();
           
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cbVendedor, "vendedor", "id", "nome","1 = 1" , "nome");
            objD = null;
            cbVendedor.SelectedIndex = -1;

            pesquisa(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        public void pesquisa(String data_inicio,String data_final)
        {
            VendasBLL cmd = new VendasBLL();
            cmd.Data_inicial = data_inicio;
            cmd.Data_final = data_final;
            try
            {
                cmd.vendedor = int.Parse(cbVendedor.SelectedValue.ToString());
            }
            catch { }
            DataTable x = cmd.gestao_vendas();
            dataGridView1.DataSource = x;

            decimal total = 0;
            decimal total_cancelado = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try{
                    if (row.Cells[1].Value.ToString() == "Cancelado")
                        total_cancelado += decimal.Parse(row.Cells[7].Value.ToString());
                    else
                        total += decimal.Parse(row.Cells[7].Value.ToString());
                }catch{
                }                
            }

            if (total == 0)
                lbl_total_vendas.Text = "R$ 0.00";
            else
                lbl_total_vendas.Text = "R$ " + total;

            if(total_cancelado == 0)
                 lbl_total_vendas_canceladas.Text = "R$ 0.00";
            else
                lbl_total_vendas_canceladas.Text = "R$ " + total_cancelado;



         // foreach (var item in x){
         //
         // }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Gestao_Vendas_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e){

        }

        private void label6_Click(object sender, EventArgs e){

        }

        private void button4_Click(object sender, EventArgs e){
            pesquisa(date_inicial.Text, date_final.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e){

        }

        private void label7_Click(object sender, EventArgs e){
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e){

        }

        private void button2_Click(object sender, EventArgs e){
            DateTime dtUltimoDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            DateTime dtPrimeiroDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            pesquisa(dtPrimeiroDiaMes.ToShortDateString(), dtUltimoDiaMes.ToShortDateString());
        }

        private void button1_Click(object sender, EventArgs e){
            pesquisa(DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
        }

        private void cbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

    }
}
