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
    public partial class frm_CodDatas : Form
    {
        public frm_CodDatas()
        {
            InitializeComponent();
        }
        public String lControle = "";
        public String controle = "Cancelado";
        public DateTime? dataInical = null;
        public DateTime? dataFinal = null;
        public int codigo = 0;

        private void tbProdutoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
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

                if (tbCodigo.Text != "")
                    codigo = int.Parse(tbCodigo.Text);
                else
                    codigo = 0;

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

        private void frm_CodDatas_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);

            if (lControle == "Funcionário")
                lCodigo.Text = "Código do Funcionário";            
            else if (lControle == "Cliente")
                lCodigo.Text = "Código do Cliente";
            

        }

        private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
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
    }
}
