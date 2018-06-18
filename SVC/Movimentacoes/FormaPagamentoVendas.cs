using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SVC_BLL;
using One.Bll;

namespace One.MOVIMENTACOES
{
    public partial class FormaPagamentoVendas : Form
    {
        public FormaPagamentoVendas()
        {
            InitializeComponent();
        }

        public int formaPagamento = 0;
        public int qtdParcelas=1;
        public bool cancelar = false;

        RadioButton rb = null;
        int posVert=0; //posição vertical
        FormaPagamentoBLL objFor = null;
        
        public int codigoFP; //Código da Forma de Pagamento selecionada

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void FormaPagamentoVendas_Load(object sender, EventArgs e)
        {

            
            try
            {
                this.MinimumSize = new Size(this.Width, this.Height);

                objFor = new FormaPagamentoBLL();
                DataTable tab = objFor.localizarComRetorno("", "fp_codigo");
                panFormaPagamento.AutoScroll = true;
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    rb = new RadioButton();
                    rb.Text = tab.Rows[i][1].ToString();
                    rb.Name = tab.Rows[i][0].ToString();
                    rb.Location = new Point(20, posVert);
                    //rb.Left = 20;
                    rb.Top = posVert;
                    rb.Width = 250;
                    rb.Height = 50;
                    rb.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    //rb.Tag = fileArray[i]; // Assuming you have your files in an array or similar
                    rb.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
                    posVert = posVert + 50;
                    panFormaPagamento.Controls.Add(rb);
                    //gbFormaPagamento.Controls.Add(rb);
                    //lbFormaPagamento.Controls.Add(rb);                    
                }
                objFor = null;
                tab = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            codigoFP = int.Parse(r.Name.ToString());
            if (r.Text.ToString() == "Dinheiro")
            {
                txtQuantidadeParcelas.Text = "1";
                txtQuantidadeParcelas.Visible = false;
               // lbObrigatório.Visible = false;
                lbQtdParc.Visible = false;
            }
            else
            {
                txtQuantidadeParcelas.Text = "";
                txtQuantidadeParcelas.Visible = true;
              //  lbObrigatório.Visible = true;
                lbQtdParc.Visible = true;
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            cancelar = true;
        }

        private void txtQuantidadeParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < panFormaPagamento.Controls.Count; i++)
            {
                // vamos testar se o controle é do tipo CheckBox
                if (panFormaPagamento.Controls[i] is System.Windows.Forms.RadioButton)
                {
                    if ((panFormaPagamento.Controls[i] as RadioButton).Checked == true)
                        formaPagamento = int.Parse(panFormaPagamento.Controls[i].Name.ToString());
                    
                    
                }

            }

            if (formaPagamento == 0)
                throw new Exception("Por favor, escolha uma foma de pagamento");
            if (txtQuantidadeParcelas.Text != "")
                qtdParcelas = int.Parse(txtQuantidadeParcelas.Text);
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
