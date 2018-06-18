using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using View;

namespace One.Cadastros
{
    public partial class frmVendedor : Form
    {
        public frmVendedor()
        {
            InitializeComponent();
        }

        #region Eventos formulário do vendedor

        private void btSalvar_Click(object sender, EventArgs e)
        {
            this.ValidarFormulario();

            VendedorBll novoVendedor = this.CarregarVendedor();

            int idNovoVendedor = novoVendedor.IncluirVendedor(novoVendedor);

            if (idNovoVendedor != 0)
            {
                this.LimparFormulario();
                MessageBox.Show("Vendedor inserido com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.LimparFormulario();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            int idVendedor;

            if (TabControl1.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    MessageBox.Show("Informe o código do vendedor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    idVendedor = Convert.ToInt32(this.txtCodigo.Text);
                }
            }
            else
            {
                idVendedor = Convert.ToInt32(gvPesquisa.SelectedRows[0].Cells["id"].Value.ToString());
            }

            if (DialogResult.OK == MessageBox.Show("Deseja realmente excluir?.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                VendedorBll vendedorBll = new VendedorBll();

                vendedorBll.ExcluirVendedor(idVendedor);

                MessageBox.Show("Vendedor removido com sucesso!", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (TabControl1.SelectedIndex == 0)
                {
                    this.LimparFormulario();
                }
                else
                {
                    gvPesquisa.Rows.Remove(gvPesquisa.SelectedRows[0]);
                }
            }
        }

        private void btPrimeiro_Click(object sender, EventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();
            vendedorBll = vendedorBll.ConsultarVendedorPorPosicao(PosicaoVendedor.Primeiro, 0);

            CarregarFormularioVendedor(vendedorBll);
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();

            if (!string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                vendedorBll = vendedorBll.ConsultarVendedorPorPosicao(PosicaoVendedor.Anterior, Convert.ToInt32(this.txtCodigo.Text));

                CarregarFormularioVendedor(vendedorBll);
            }
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();

            int idVendedor = 0;

            int.TryParse(this.txtCodigo.Text, out idVendedor);

            vendedorBll = vendedorBll.ConsultarVendedorPorPosicao(PosicaoVendedor.Proximo, idVendedor);

            CarregarFormularioVendedor(vendedorBll);

        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();
            vendedorBll = vendedorBll.ConsultarVendedorPorPosicao(PosicaoVendedor.Ultimo, 0);

            CarregarFormularioVendedor(vendedorBll);
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            if (TabControl1.SelectedIndex == 1)
            {
                txtPesquisar.Focus(); this.MaximumSize = new Size(this.Width, this.Height + 100);
                this.MinimumSize = new Size(this.Width, this.Height + 100);
                this.Size = new Size(this.Width, this.Height + 100);
                DisponibilizarBotoes(false);

                LimparFormulario();

                VendedorBll vendedorBll = new VendedorBll();

                DataTable tbVendedor = vendedorBll.ConsultarTodosVendedor();

                gvPesquisa.DataSource = tbVendedor;
            }
            else
            {
                this.MaximumSize = new Size(this.Width, this.Height - 50);
                this.MinimumSize = new Size(this.Width, this.Height - 50);
                this.Size = new Size(this.Width, this.Height - 50);
                DisponibilizarBotoes(true);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();

            DataTable dtVendedor = vendedorBll.ConsultarVendedorPorTodosFiltros(txtPesquisar.Text);

            gvPesquisa.DataSource = dtVendedor;
        }

        private void gvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();

            vendedorBll.IdVendedor = Convert.ToInt32(this.gvPesquisa.SelectedRows[0].Cells["id"].Value.ToString());
            vendedorBll.NomeVendedor = this.gvPesquisa.SelectedRows[0].Cells["nome"].Value.ToString();

            this.CarregarFormularioVendedor(vendedorBll);

            this.TabControl1.SelectedIndex = 0;
        }

        #endregion

        #region Métodos do formúlário do vendedor

        public void ValidarFormulario()
        {
            if (string.IsNullOrEmpty(this.txtNomeVendedor.Text))
            {
                throw new Exception("Informar nome do vendedor.");
            }
        }

        public VendedorBll CarregarVendedor()
        {
            VendedorBll vendedorBll = new VendedorBll();

            int idVendedor;

            int.TryParse(this.txtCodigo.Text, out idVendedor);

            vendedorBll.IdVendedor = idVendedor;
            vendedorBll.NomeVendedor = this.txtNomeVendedor.Text;

            return vendedorBll;
        }

        public void CarregarFormularioVendedor(VendedorBll vendedor)
        {
            if (vendedor != null && vendedor.IdVendedor != 0)
            {
                this.txtCodigo.Text = vendedor.IdVendedor.ToString();
                this.txtNomeVendedor.Text = vendedor.NomeVendedor;
            }
        }

        public void DisponibilizarBotoes(bool habilitado)
        {
            //btSalvar.Enabled = habilitado;
            //btCancelar.Enabled = habilitado;
            //btPrimeiro.Enabled = habilitado;
            //btProximo.Enabled = habilitado;
            //btAnterior.Enabled = habilitado;
            //btUltimo.Enabled = habilitado;
        }

        public void LimparFormulario()
        {
            this.txtCodigo.Clear();
            this.txtNomeVendedor.Clear();
            this.txtPesquisar.Clear();
        }

        #endregion

        private void btImprimir_Click(object sender, EventArgs e)
        {
            printDGV.Print_DataGridView(gvPesquisa);
        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(this.Width, this.Height);
            this.MinimumSize = new Size(this.Width, this.Height);
            TabControl1.SelectedIndex = 0;
        }

        private void gvPesquisa_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            VendedorBll vendedorBll = new VendedorBll();

            vendedorBll.IdVendedor = Convert.ToInt32(this.gvPesquisa.SelectedRows[0].Cells["id"].Value.ToString());
            vendedorBll.NomeVendedor = this.gvPesquisa.SelectedRows[0].Cells["nome"].Value.ToString();

            this.CarregarFormularioVendedor(vendedorBll);

            this.TabControl1.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e){

            this.ValidarFormulario();
            VendedorBll novoVendedor = this.CarregarVendedor();
            int idNovoVendedor = novoVendedor.IncluirVendedor(novoVendedor);

            if (idNovoVendedor != 0)
            {
                this.LimparFormulario();
                MessageBox.Show("Vendedor inserido com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LimparFormulario();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idVendedor;

            if (TabControl1.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    MessageBox.Show("Informe o código do vendedor.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    idVendedor = Convert.ToInt32(this.txtCodigo.Text);
                }
            }
            else
            {
                idVendedor = Convert.ToInt32(gvPesquisa.SelectedRows[0].Cells["id"].Value.ToString());
            }

            if (DialogResult.OK == MessageBox.Show("Deseja realmente excluir?.", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                VendedorBll vendedorBll = new VendedorBll();

                vendedorBll.ExcluirVendedor(idVendedor);

                MessageBox.Show("Vendedor removido com sucesso!", "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (TabControl1.SelectedIndex == 0)
                {
                    this.LimparFormulario();
                }
                else
                {
                    gvPesquisa.Rows.Remove(gvPesquisa.SelectedRows[0]);
                }
            }
        }
    }
}
