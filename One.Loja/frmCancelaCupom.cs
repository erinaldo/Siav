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
    public partial class frmCancelaCupom : Form
    {
        public bool Cancelar { get; set; }
        public string Codigo { get; set; }
        public frmCancelaCupom()
        {
            InitializeComponent();
            Cancelar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void txtCodigoCupom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void frmCancelaCupom_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    btnCancelarVenda_Click(this, new EventArgs());
                    break;
            }
        }

        private void txtCodigoCupom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    if (!string.IsNullOrEmpty(txtCodigoCupom.Text))
                    {
                        Cancelar = true;
                        Codigo = txtCodigoCupom.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Prescisa informar número do cupom para cancelar !");
                    }
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar = false;
            this.Close();
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigoCupom.Text))
            {
                Codigo = txtCodigoCupom.Text;
                Cancelar = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Prescisa informar número do cupom para cancelar !");
            }
        }
    }
}
