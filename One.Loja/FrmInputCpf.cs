using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace One.Loja
{
    public partial class FrmInputCpf : Form
    {
        public string CpfCliente { get; set; }
        private Form Parent { get; set; }
        public FrmInputCpf(Form parent)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Parent = parent;
        }

        private void btnRegistraCpf_Click(object sender, EventArgs e)
        {
            if (txtCpfCliente.TextLength > 0 && (txtCpfCliente.TextLength == 14 || txtCpfCliente.TextLength == 11 ))
            {
                CpfCliente = txtCpfCliente.Text;
                this.Close();
            }
            else
                MessageBox.Show("Digite um CPF/CNPJ valido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRetornarPdv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInputCpf_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void txtCpfCliente_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCpfCliente_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27: //esc
                    this.Close();
                    break;
                case 13: //enter
                    btnRegistraCpf_Click(sender, new EventArgs());
                    break;
            }
        }

        private void txtCpfCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
