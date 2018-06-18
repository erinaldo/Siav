using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class Despesas : Form
    {
        public Despesas()
        {
            InitializeComponent();
            this.data_final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            this.data_inicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            filtra_despesas();
        }

        DateTime data_inicial;
        DateTime data_final;
        Int32 month_control = 0;

        public void filtra_despesas(){

            decimal total = 0;
            decimal pago = 0;

            DespesasBLL despesas = new DespesasBLL();
            despesas.data_inicial = this.data_inicial.ToShortDateString();
            despesas.data_final = this.data_final.ToShortDateString();
            dataGridView1.DataSource = despesas.localizar();
            lbl_mes.Text = this.data_inicial.ToShortDateString() + " - " + this.data_final.ToShortDateString();

            foreach (DataGridViewRow row in this.dataGridView1.Rows){
                try{

                    total += decimal.Parse(row.Cells[5].Value.ToString());

                    if(row.Cells[1].Value.ToString() == "PAGO")
                        pago += decimal.Parse(row.Cells[5].Value.ToString());

                    String xmes = this.data_inicial.ToShortDateString().Split('/')[1].ToString();
                    row.Cells[3].Value = row.Cells[3].Value.ToString().Split('/')[0].ToString() + "/" + xmes + "/" + row.Cells[3].Value.ToString().Split('/')[0].ToString();

                }
                catch
                {

                }
            }

            lbl_total_despesa.Text = "R$ " + total;
            lbl_total_pago.Text = "R$ " + pago;
            lbl_saldo.Text = "R$ " + (total - pago);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.month_control++;
            this.data_final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1 + month_control).AddDays(-1);
            this.data_inicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(month_control);
            filtra_despesas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.month_control = 0;
            this.data_final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            this.data_inicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            filtra_despesas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.month_control--;
            this.data_final = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1 + month_control).AddDays(-1);
            this.data_inicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(month_control);
            filtra_despesas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Despesas_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Despesas_Detalhamento cmd = new Despesas_Detalhamento();
            cmd.ShowDialog();
            filtra_despesas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente pagar esta despesa ?", "Sim", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {                   
                    Int32 id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DespesasBLL cmd = new DespesasBLL();
                    cmd.id = id;
                    cmd.data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(month_control).ToShortDateString();
                    cmd.pagar();
                    MessageBox.Show("Pagamento realizado com sucesso !");

                    filtra_despesas();
                }
            }
            catch
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esta despesa ?", "Sim", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                Int32 id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DespesasBLL cmd = new DespesasBLL();
                cmd.id = id;
                cmd.data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(month_control).ToShortDateString();
                cmd.excluir();
                MessageBox.Show("Dispesa excluida com sucesso !");

                filtra_despesas();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                Despesas_Detalhamento cmd = new Despesas_Detalhamento();
                cmd.visualizar(id, dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                cmd.ShowDialog();

            }
            catch
            {

            }
        }
    }
}
