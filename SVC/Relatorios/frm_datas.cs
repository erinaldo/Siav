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
    public partial class frm_datas : Form
    {
        public frm_datas()
        {
            InitializeComponent();
        }
        public String controle = "Cancelado";
        public DateTime? dataInical=null;
        public DateTime? dataFinal=null;

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
                dataInical =  dtpDataInicial.Value;
                dataFinal = dtpDataFinal.Value;
                controle = "Gerar";
                this.Close();
            }
            catch (Exception)
            {

                throw;
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

        private void frm_datas_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(this.Width, this.Height);
            this.MaximumSize = new Size(this.Width, this.Height);
        }
    }
}
