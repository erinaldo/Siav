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

namespace One.Loja
{
    public partial class frm_troca_itens : Form
    {
        public DataTable tb_troca;
        public List<string> lista_troca = new List<string>();
        public frm_troca_itens(VendasBLL vendas)
        {
            InitializeComponent();

            grid_cupom.DataSource = vendas.seleciona_itens_venda_troca(vendas.codigo.ToString());
            // grid_troca.DataSource = vendas.seleciona_itens_venda_troca(vendas.codigo.ToString());
            try
            {
                //   Int32 x = grid_troca.Rows.Count;
                //   for (int i = 0; i < x; i++)
                //   {
                //       grid_troca.Rows.Remove(grid_troca.Rows[0]);
                //   }

                tb_troca = new DataTable();
                tb_troca.Columns.Add("pro_codigo", typeof(String));
                tb_troca.Columns.Add("pro_nome", typeof(String));
                tb_troca.Columns.Add("vi_quantidade", typeof(String));
                tb_troca.Columns.Add("vi_subtotal", typeof(String));
                grid_troca.DataSource = tb_troca;


                //DataGridViewRow row = new DataGridViewRow();
                //DataGridViewRow row = (DataGridViewRow)grid_cupom.Rows[0].Clone();
            }
            catch
            {

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente realizar a troca destes itens ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            //foreach (DataGridViewRow item in this.grid_cupom.SelectedRows)
            //{
            //    grid_cupom.Rows.RemoveAt(item.Index);
            //}

            //grid_troca.Rows.Add(grid_cupom.SelectedRows[0]);

            //DataGridViewRow row = (DataGridViewRow)yourDataGridView.Rows[0].Clone();
            //row.Cells["Column2"].Value = "XYZ";
            //row.Cells["Column6"].Value = 50.2;
            //DataGridViewRow row = (DataGridViewRow)grid_cupom.Rows[0].Clone();


            //DataGridViewRow row = (DataGridViewRow)grid_cupom.Rows[0].Clone();
            //tb_troca.Rows.Add(row);

            //DataRow row = new DataRow();
            //row.
            //
            //tb_troca.Rows.Add(new DataRow() { });
            //
            //grid_troca.DataSource = tb_troca;

            //DataGridViewRow row = new DataGridViewRow();

            //row.Cells["pro_codigo"].Value = "XYZ";
            //row.Cells["pro_nome"].Value = "XYZ";
            //row.Cells["vi_quantidade"].Value = "XYZ";
            //row.Cells["vi_subtotal"].Value = "XYZ";
            //  grid_troca.Rows.Add("teste");
            // grid_troca.Rows.Add(row);
            //row.Cells["Column6"].Value = 50.2;
            //grid_troca.Rows.Add();
            //grid_troca.Rows.Add(row);

            if (grid_cupom.CurrentRow == null)
                return;

            var currentRow = ((DataRowView)grid_cupom.CurrentRow.DataBoundItem).Row;

            ((DataTable)grid_troca.DataSource).ImportRow(currentRow);


            grid_cupom.Rows.Remove(grid_cupom.SelectedRows[0]);
            calcula_troca();
        }


        public void popula_troca()
        {

        }

        public void calcula_troca()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow row in grid_troca.Rows)
                {
                    //  Int32 n_item = Int32.Parse(row.Cells[0].Value.ToString().Replace(',', '.'));
                    // if (n_item == Int32.Parse(frm.textBox1.Text))
                    // {
                    //        string x = row.Cells[3].Value.ToString().Replace(',', '.');
                    //      decimal qtd = decimal.Parse(x);

                    decimal valor = 0;
                    try
                    {
                        valor = decimal.Parse(row.Cells[3].Value.ToString());
                    }
                    catch { }
                    //decimal desconto = decimal.Parse(frm.txtDescontoPer.Text.ToString());
                    //decimal nvalor = valor - (valor * (desconto / 100));

                    //  dgDados.Rows[row.Index].Cells[4].Value = nvalor.ToString();
                    //  dgDados.Rows[row.Index].Cells[5].Value = string.Format("{0:n2}", (nvalor * qtd));

                    //carregaCampos();
                    //decimal total = decimal.Parse(total_troca.Text.Replace(',', '.'));


                    //double total .Parse();
                    total += valor;
                    //  }
                }

                total_troca.Text = total.ToString("n2");
            }
            catch
            {

            }
        }


        private void frm_troca_itens_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            grid_cupom.Rows.Add(grid_cupom.SelectedRows[0]);
            grid_troca.Rows.Remove(grid_cupom.SelectedRows[0]);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grid_cupom = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid_troca = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.total_troca = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_cupom)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_troca)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grid_cupom);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 379);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens do Cupom";
            // 
            // grid_cupom
            // 
            this.grid_cupom.BackgroundColor = System.Drawing.Color.White;
            this.grid_cupom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_cupom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_cupom.Location = new System.Drawing.Point(6, 21);
            this.grid_cupom.Name = "grid_cupom";
            this.grid_cupom.RowTemplate.Height = 24;
            this.grid_cupom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_cupom.Size = new System.Drawing.Size(524, 352);
            this.grid_cupom.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid_troca);
            this.groupBox2.Location = new System.Drawing.Point(554, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 379);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens da Troca";
            // 
            // grid_troca
            // 
            this.grid_troca.BackgroundColor = System.Drawing.Color.White;
            this.grid_troca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_troca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_troca.Location = new System.Drawing.Point(3, 21);
            this.grid_troca.Name = "grid_troca";
            this.grid_troca.RowTemplate.Height = 24;
            this.grid_troca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_troca.Size = new System.Drawing.Size(524, 352);
            this.grid_troca.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Adicionar a Troca";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(942, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Remover da Troca";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(942, 516);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Confirmar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.total_troca);
            this.groupBox3.Location = new System.Drawing.Point(554, 438);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(533, 72);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Troca";
            // 
            // total_troca
            // 
            this.total_troca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.total_troca.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.total_troca.Location = new System.Drawing.Point(6, 18);
            this.total_troca.Name = "total_troca";
            this.total_troca.Size = new System.Drawing.Size(521, 51);
            this.total_troca.TabIndex = 0;
            this.total_troca.Text = "0.00";
            this.total_troca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_troca_itens
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1099, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_troca_itens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_cupom)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_troca)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente realizar a troca destes itens ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {

                foreach (DataGridViewRow row in grid_troca.Rows)
                {
                    try
                    {
                        String x = row.Cells[0].Value.ToString() + "|" + row.Cells[2].Value.ToString().Split(',')[0].ToString();
                        lista_troca.Add(x);
                    }
                    catch
                    {

                    }
                }

                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (grid_troca.CurrentRow == null)
                return;

            var currentRow = ((DataRowView)grid_troca.CurrentRow.DataBoundItem).Row;

            ((DataTable)grid_cupom.DataSource).ImportRow(currentRow);


            grid_troca.Rows.Remove(grid_troca.SelectedRows[0]);
            calcula_troca();
        }
    }
}
