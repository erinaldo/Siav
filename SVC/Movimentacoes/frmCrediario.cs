using One.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace One.Movimentacoes
{
    public enum status
    {
        aberto = 0,
        vencido = 1,
        vencem_hoje = 2,
        fechados = 3
    }
    public partial class frmCrediario : Form
    {
        VendasBLL cmd;
        Boolean baixa = false;
        Int32 id_promissoria = 0;
        status status = status.aberto;

        decimal total_pago = 0;
        decimal total = 0;

        public frmCrediario()
        {
            InitializeComponent();
            cmd = new VendasBLL();
            dataGridView1.DataSource = cmd.seleciona_promissorias("");
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (baixa)
            {

                Int32 id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                if (MessageBox.Show("Deseja realmente dar baixa nesta promissória ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    cmd = new VendasBLL();
                    cmd.baixa_promissoria(id);
                    MessageBox.Show("Promissoria baixada com sucesso !");
                    dataGridView1.DataSource = cmd.seleciona_promissorias_meses(id_promissoria);
                    calcula_promissoria();
                    pinta_linhas();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não é possivel adicionar manualmente no momento !");
          //  frm_visualizar_promissoria_add cmd = new frm_visualizar_promissoria_add(0);
          //  cmd.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.status = status.fechados;
            lbl_titulo.Text = "Listagem de Promissórias Fechadas";
            baixa = false;
            cmd = new VendasBLL();
            dataGridView1.DataSource = cmd.seleciona_promissorias_fechadas("");
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            id_promissoria = 0;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.status = status.aberto;
            lbl_titulo.Text = "Listagem de Promissórias em aberto";
            baixa = false;
            cmd = new VendasBLL();
            dataGridView1.DataSource = cmd.seleciona_promissorias("");
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            id_promissoria = 0;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.status = status.vencido;
            lbl_titulo.Text = "Listagem de Promissórias Vencidas";
            baixa = false;
            cmd = new VendasBLL();
            dataGridView1.DataSource = cmd.seleciona_promissorias_vencidas("");
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            id_promissoria = 0;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.status = status.vencem_hoje;
            lbl_titulo.Text = "Listagem de Promissórias que Vencem Hoje";
            baixa = false;
            cmd = new VendasBLL();
            dataGridView1.DataSource = cmd.seleciona_promissorias_vencidas_hoje("");
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            id_promissoria = 0;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void txt_pesquisa_KeyUp(object sender, KeyEventArgs e)
        {
            baixa = false;
            cmd = new VendasBLL();

            if (this.status == status.aberto)
            {
                dataGridView1.DataSource = cmd.seleciona_promissorias(txt_pesquisa.Text);
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }


            if (this.status == status.fechados)
            {
                dataGridView1.DataSource = cmd.seleciona_promissorias_fechadas(txt_pesquisa.Text);
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

            if (this.status == status.vencem_hoje)
            {
                dataGridView1.DataSource = cmd.seleciona_promissorias_vencidas_hoje(txt_pesquisa.Text);
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

            if (this.status == status.vencido)
            {
                dataGridView1.DataSource = cmd.seleciona_promissorias_vencidas(txt_pesquisa.Text);
                dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }

            id_promissoria = 0;
            lbl_total.Text = "R$ 0.00";
            lbl_restante.Text = "R$ 0.00";
            lbl_pago.Text = "R$ 0.00";
            lbl_nome_cliente.Text = "Nenhuma promissória selecionada.";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (baixa)
            {
                Boolean x = true;

                try
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        if (dgvr.Cells[1].Value.ToString().Trim() == "ativo")
                            x = false;
                    }
                }
                catch { }


                if (x)
                {

                    Int32 id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    if (MessageBox.Show("Deseja realmente fechar esta promissória ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        cmd = new VendasBLL();
                        cmd.fecha_promissoria(id_promissoria);
                        MessageBox.Show("Promissoria fechada com sucesso !");
                        dataGridView1.DataSource = cmd.seleciona_promissorias_meses(id_promissoria);
                        calcula_promissoria();
                        pinta_linhas();
                    }
                }
                else
                {
                    MessageBox.Show("Este cliente ainda possui contas a pagar !");
                }
            }
        }

        public void pinta_linhas()
        {
            try
            {

                foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                {

                    String xx = dgvr.Cells[2].Value.ToString().Trim();

                    Int32 ano = Int32.Parse(xx.Split('/')[2].ToString().Replace("00:00:00", "").Trim());
                    Int32 mes = Int32.Parse(xx.Split('/')[1].ToString());
                    Int32 dia = Int32.Parse(xx.Split('/')[0].ToString());

                    DateTime dt = new DateTime(ano, mes, dia);

                    if (dt.Date.Day < DateTime.Now.Day && dt.Date.Month <= DateTime.Now.Month && dt.Date.Year <= DateTime.Now.Year)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                        dgvr.DefaultCellStyle.ForeColor = Color.White;
                    }

                    if (dt.Date.Day == DateTime.Now.Day && dt.Date.Month <= DateTime.Now.Month && dt.Date.Year <= DateTime.Now.Year)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                    }

                    if (dgvr.Cells[1].Value.ToString().Trim() == "pago")
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Green;
                        dgvr.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch
            {

            }
        }

        public void calcula_promissoria()
        {
            try
            {
                decimal valor = 0;
                decimal valor_pago = 0;

                try
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        string aux = dgvr.Cells[4].Value.ToString();
                        valor += decimal.Parse(aux);

                        if (dgvr.Cells[1].Value.ToString().Trim() == "pago")
                        {
                            valor_pago += decimal.Parse(aux);
                        }


                    }
                }
                catch { }

                lbl_pago.Text = "R$ " + valor_pago;
                lbl_total.Text = "R$ " + valor;
                lbl_restante.Text = "R$ " + (valor - valor_pago);

            }
            catch
            {

            }
        }


        public void exibe_cliente_promissoria(Int32 id)
        {
            try
            {
                cmd = new VendasBLL();
                lbl_nome_cliente.Text = cmd.Localiza_Nome_Cliente_promissoria(id);
            }
            catch
            {

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (baixa == false)
                {
                    baixa = true;
                    cmd = new VendasBLL();
                    Int32 id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    id_promissoria = id;
                    dataGridView1.DataSource = cmd.seleciona_promissorias_meses(id);
                    pinta_linhas();
                    exibe_cliente_promissoria(id);
                    calcula_promissoria();
                }
                else
                {
                    button1.PerformClick();
                }
            }
            catch
            {

            }
        }
    }
}
