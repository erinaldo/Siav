using One.Bll;
using One.MOVIMENTACOES;
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

    public partial class frmClientes : Form
    {
        private Form Parent { get; set; }
        public frmClientes(Form parent)
        {
            InitializeComponent();
            this.Parent = parent;
        }

        public string Codigo { get; set; }
        public string NomeCliente { get; set; }

        ClienteBLL clienteBll = new ClienteBLL();

        public void CarregaGridCliente()
        {
            try
            {
                DataTable tab = null;

                tab = clienteBll.LocalizarEmTudo(txtPesquisa.Text, cbOpcao.Text);

                dgvClientes.DataSource = tab;

                dgvClientes.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgvClientes.Rows.Count)
                {
                    int cod = cod = int.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string Nome = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string cpf;

                    if(cbOpcao.SelectedItem.ToString() == "Pessoa Física")
                        cpf = dgvClientes.Rows[e.RowIndex].Cells[5].Value.ToString();
                    else
                        cpf = dgvClientes.Rows[e.RowIndex].Cells[6].Value.ToString();

                    clienteBll.cli_codigo = cod;
                    if (validaCpfCnpj(cpf, out cpf) && MessageBox.Show("Deseja adicionar CPF/CNPJ a seguir: " + cpf, "CPF/CNPJ na nota", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                    {
                        Label lblCpf = Parent.Controls.Find("lblCpf", false).First() as Label;
                        lblCpf.Text = cpf;
                        lblCpf.Visible = true;
                    }
                    //Atribuir valor na propriedade
                    Codigo = cod.ToString();
                    NomeCliente = Nome.ToString();
                    //Fechar este Form
                    this.Close();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            //txtPesquisar.Select();
            try
            {
                cbOpcao.SelectedIndex = 0;
                CarregaGridCliente();
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool validaCpfCnpj(string num, out string format)
        {
            num = num.Replace(".", "").Replace("/","").Replace("-","");
            if (num.Length == 11 || num.Length == 14)
            {
                format = "";
                if (num.Length == 11)
                    format = Convert.ToUInt64(num).ToString(@"000\.000\.000\-00");
                if (num.Length == 14)
                    format = Convert.ToUInt64(num).ToString(@"00\.000\.000\/0000\-00");
                return true;
            }
            format = null;
            return false;
        }
    }
}


