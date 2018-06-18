using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using One.Dal;

namespace One.RELATORIOS
{
    public partial class frm_CodigoBarra : Form
    {
        public frm_CodigoBarra()
        {
            InitializeComponent();
        }

        public String controle;

        public void carregaCombo()
        {
            lbProdutos.Items.Clear();
            ProdutosBLL objPro = new ProdutosBLL();
            DataTable tab = objPro.localizarProdutoCodigoBarra(txtProdutos.Text);
            for(int i=0;i<tab.Rows.Count;i++)
                lbProdutos.Items.Add(tab.Rows[i][0].ToString());
            objPro = null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frm_CodigoBarra_Load(object sender, EventArgs e)
        {
            try
            {
                carregaCombo();
                this.MinimumSize = new Size(this.Width, this.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutosBLL objPro = new ProdutosBLL();
                if (lbProdutos.SelectedIndex < 0)
                    throw new Exception("Por favor, selecione um produto da lista");
                if (nudQuantidade.Value < 1)
                    throw new Exception("Por favor, selecione uma quantidade superior a 0");
                
                objPro.localizar("pro_codigo",lbProdutos.SelectedItem.ToString());
                int achou=0;
                for (int i = 0; i < dgEtiquetas.Rows.Count; i++)
                {
                    if (dgEtiquetas.Rows[i].Cells[0].Value.ToString() == objPro.pro_codigo.ToString())
                    {
                        achou = 1;
                        int quantidade = int.Parse(dgEtiquetas.Rows[i].Cells[2].Value.ToString());
                        quantidade += int.Parse(nudQuantidade.Value.ToString());
                        dgEtiquetas.Rows[i].Cells[2].Value = quantidade;
                    }
                }
                if(achou ==0)
                    dgEtiquetas.Rows.Add(objPro.pro_codigo,objPro.pro_nome,nudQuantidade.Value);
                objPro = null;
                if (lbProdutos.SelectedIndex < lbProdutos.Items.Count-1)
                    lbProdutos.SelectedIndex = lbProdutos.SelectedIndex + 1;
                else if (lbProdutos.SelectedIndex == lbProdutos.Items.Count-1)
                    lbProdutos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btRetirar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgEtiquetas.CurrentRow != null)
                    this.dgEtiquetas.Rows.Remove(this.dgEtiquetas.CurrentRow);
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgEtiquetas.Rows.Count; i++)
                {
                    ProdutosBLL objPro = new ProdutosBLL();
                    objPro.localizar("pro_codigo", dgEtiquetas.Rows[i].Cells[0].Value.ToString());
                    CodigoBarraBLL objCB = new CodigoBarraBLL();
                    objCB.pro_codigoBarra = String.Format("*{0}*", objPro.pro_codigoBarra);
                    objCB.pro_precoVenda = objPro.pro_precoVenda;
                    objCB.pro_nome = objPro.pro_nome;
                    for (int j = 0; j < int.Parse(dgEtiquetas.Rows[i].Cells[2].Value.ToString()); j++)
                        objCB.inserir();
                    objCB = null;
                    objPro = null;
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void lbProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbProdutos.SelectedIndex >= 0)
                {
                    ProdutosBLL objPro = new ProdutosBLL();
                    objPro.localizar(lbProdutos.SelectedItem.ToString(), "pro_nome");
                    nudQuantidade.Value = objPro.pro_quantidade;
                    objPro = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtProdutos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                carregaCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


    }
}
