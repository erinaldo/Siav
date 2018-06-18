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
    public partial class frmComposicaoProduto : Form
    {
        public frmComposicaoProduto()
        {
            InitializeComponent();
        }
        public void CarregarCombo()
        {
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    contexto.PreencheComboBox(cboProdutoFilhoComposição, "Produtos", "pro_codigo", "pro_nome", "", "pro_nome");
                    contexto.PreencheComboBox(cboProdutoPai, "Produtos", "pro_codigo", "pro_nome", "", "pro_nome");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void frmComposicaoProduto_Load(object sender, EventArgs e)
        {
            CarregarCombo();
            cboProdutoFilhoComposição.SelectedIndex = -1;
            cboProdutoPai.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgOrdemFabricacao.Rows.Add(
                
                cboProdutoPai.SelectedValue,
                cboProdutoFilhoComposição.Text,
                txtUND.Text,
                txtQuantidade.Text
                );
        }
    }
}
