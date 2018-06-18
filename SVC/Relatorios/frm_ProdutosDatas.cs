using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.RELATORIOS
{
    public partial class frm_ProdutosDatas : Form
    {
        public frm_ProdutosDatas()
        {
            InitializeComponent();
        }

        public String controle = "Cancelado";
        public DateTime? dataInical = null;
        public DateTime? dataFinal = null;
        public int produtoIncial = 0;
        public int produtoFinal = 0;


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void tbProdutoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void tbProdutoFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbProdutoFinal.Text != "")
                    produtoFinal = int.Parse(tbProdutoFinal.Text);
                else
                    produtoFinal = 0;

                if (tbProdutoInicial.Text != "")
                    produtoIncial = int.Parse(tbProdutoInicial.Text);
                else
                    produtoIncial= 0;

                dataInical = dtpDataInicial.Value;
                dataFinal = dtpDataFinal.Value;
                controle = "Gerar";
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tbProdutoInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void tbProdutoFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dtpDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGerar_Click(sender, e);
            }
        }

        private void frm_ProdutosDatas_Load(object sender, EventArgs e)
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                this.MaximumSize= new Size(this.Width, this.Height);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
