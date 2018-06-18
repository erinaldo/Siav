using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Dal;
using One.Bll;
namespace One.RELATORIOS
{
    public partial class frm_ProdMarca : Form
    {
        public frm_ProdMarca()
        {
            InitializeComponent();
        }

        public String controle;
        public String marca;

        private void frm_ProdMarca_Load(object sender, EventArgs e)
        {
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);
                this.MaximumSize = new Size(this.Width, this.Height);
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbMarca, "Marcas", "mar_codigo", "mar_descricao", "", "");
                objD = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMarca.SelectedIndex > -1)
                {
                    marca = cbMarca.SelectedValue.ToString();
                    MarcasBLL objBLL = new MarcasBLL();
                    objBLL.localizarLeave(marca, "mar_codigo");
                    marca = objBLL.mar_descricao;
                    objBLL = null;
                }
                else
                    marca = "";
                controle = "Gerar";
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                marca = "";
                controle = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
