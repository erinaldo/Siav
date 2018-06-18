﻿using One.Bll;
using One.Dal;
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
    public partial class frmPromissoria : Form
    {
        public Int32 venda;
        public decimal valor;
        public Boolean fatura = false;
        public Boolean sair = false;

        public frmPromissoria(Int32 venda)
        {
            InitializeComponent();

            Contexto objD = new Contexto();
            objD.PreencheComboBox(combo_cliente, "Cliente", "cli_codigo", "cli_nome", "", "cli_nome");
            objD = null;

            VendasBLL cmd_venda = new VendasBLL();
            cmd_venda.localizar(venda + "", "ven_codigo");
            this.venda = venda;
            this.valor = cmd_venda.valorFinal;


            dataGridView1.Columns.Add("pacela", "Parcela");
            dataGridView1.Columns.Add("vencimento", "Data Vencimento");
            dataGridView1.Columns.Add("valor", "Valor");


            // dataGridView1.Columns[0].Name = "Parcela";
            // dataGridView1.Columns[1].Name = "Data Vencimento";
            // dataGridView1.Columns[1].Name = "Valor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                VendasBLL cmd = new VendasBLL();
                cmd.codigo = this.venda;
                cmd.cliente = int.Parse(combo_cliente.SelectedValue.ToString());
                if (cmd.cliente > 0)
                {

                    cmd.data = dt_vencimento.Value;

                    int int_aux = 0;
                    decimal decimal_aux = 0;

                    if (this.valor > 0)
                    {

                        if (int.TryParse(txt_parcelas.Text.Replace(',', ' ').Replace(',', ' ').Trim(), out int_aux))
                        {
                            cmd.parcelas = int_aux;

                            if (decimal.TryParse(txt_percentual_juros.Text.Replace(',', '.').Trim(), out decimal_aux))
                            {

                                cmd.percentual = decimal_aux;

                                if (decimal.TryParse(txt_valor_juros.Text.Replace(',', '.').Trim(), out decimal_aux))
                                {

                                    cmd.valor = decimal_aux;

                                    if (MessageBox.Show("Deseja realmente fechar a venda como promissória ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        Boolean x = cmd.inserir_venda_promissoria(this.valor);
                                        if (x)
                                        {
                                            MessageBox.Show("Promissória cadastrada com sucesso !");
                                            this.sair = x;
                                            this.Close();
                                        }
                                    }

                                }
                                else
                                    MessageBox.Show("Percentual de juros invalido !");

                            }
                            else
                                MessageBox.Show("Percentual de juros invalido !");

                        }
                        else
                            MessageBox.Show("Quantidade de parcelas invalida !");
                    }
                    else
                        MessageBox.Show("Você não pode gerar uma promissoria com valor zerado");
                }
                else
                    MessageBox.Show("Selecione o Cliente para a promissória");



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                VendasBLL cmd = new VendasBLL();
                cmd.codigo = this.venda;
                cmd.cliente = int.Parse(combo_cliente.SelectedValue.ToString());
                if (cmd.cliente > 0)
                {

                    cmd.data = dt_vencimento.Value;

                    int int_aux = 0;
                    decimal decimal_aux = 0;

                    if (int.TryParse(txt_parcelas.Text.Replace(',', ' ').Replace(',', ' ').Trim(), out int_aux))
                    {
                        cmd.parcelas = int_aux;

                        if (decimal.TryParse(txt_percentual_juros.Text.Replace(',', '.').Trim(), out decimal_aux))
                        {

                            cmd.percentual = decimal_aux;

                            if (decimal.TryParse(txt_valor_juros.Text.Replace(',', '.').Trim(), out decimal_aux))
                            {

                                cmd.valor = decimal_aux;

                                dataGridView1.Rows.Clear();

                                DateTime x = dt_vencimento.Value;

                                try
                                {
                                    dataGridView1.Rows.Clear();
                                }
                                catch { }
                                for (int i = 1; i <= cmd.parcelas; i++)
                                {
                                    string[] row1 = new string[] { "" + i, "" + x.ToShortDateString(), "R$ " + (this.valor / cmd.parcelas) };
                                    dataGridView1.Rows.Add(row1);
                                    x = x.AddMonths(+1);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Percentual de juros invalido !");
                                this.fatura = false;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Percentual de juros invalido !");
                            this.fatura = false;
                        }


                    }
                    else
                    {
                        MessageBox.Show("Quantidade de parcelas invalida !");
                        this.fatura = false;
                    }


                }
                else
                {
                    MessageBox.Show("Selecione o Cliente para a promissória");
                    this.fatura = false;
                }




            }
            catch (Exception ee)
            {
                this.fatura = false;
                MessageBox.Show(ee.Message);

            }
        }
    }
}
