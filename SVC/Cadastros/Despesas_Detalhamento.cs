using One.Dal;
using SVC_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace One.Cadastros
{
    public partial class Despesas_Detalhamento : Form
    {
        public Despesas_Detalhamento()
        {
            InitializeComponent();
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cbFornPresServ, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
        }

        public void visualizar(Int32 id,String vencimento){
            DespesasBLL cmd = new DespesasBLL();
            DataTable tb = cmd.localizar_especifico(id);

            if (tb.Rows.Count > 0){

                try { cbFornPresServ.SelectedValue = tb.Rows[0].ItemArray[1].ToString(); }catch { }

                try{
                    txt_descricao.Text = tb.Rows[0].ItemArray[2].ToString();
                }catch { 
                
                }

                if (Int32.Parse(tb.Rows[0].ItemArray[3].ToString()) == 1)
                    cb_mensal.Checked = true;
                else
                    cb_mensal.Checked = false;
                             

                txtTitulo.Text = tb.Rows[0].ItemArray[5].ToString();
                txtSerie.Text = tb.Rows[0].ItemArray[6].ToString();

                dt_data.Text = vencimento;
                dt_data.Text = tb.Rows[0].ItemArray[9].ToString();

                //dt_data

                txt_valor.Text = "0.00";
                panel1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Não foi possivel selecionar a conta a pagar, contate o desenvolvedor !");
                this.Close();
            }

        }

        private void Despesas_Detalhamento_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


           // if()

            if (txt_descricao.Text.Length > 2){

                if (txt_valor.Text.Length > 1){
                    DespesasBLL cmd = new DespesasBLL();
                    try{
                        cmd.fornecedor = int.Parse(cbFornPresServ.SelectedValue.ToString());
                    }catch{
                        cmd.fornecedor = 0;
                    }

                    cmd.descricao = txt_descricao.Text;
                    cmd.data = dt_data.Text;
                    cmd.mensal = cb_mensal.Checked;
                    cmd.valor = decimal.Parse(txt_valor.Text);

                    cmd.titulo = txtTitulo.Text.Length > 0 ? txtTitulo.Text : "";
                    cmd.serie = txtSerie.Text.Length > 0 ? txtSerie.Text : "";

                    cmd.add_despesa();
                    MessageBox.Show("Despesa cadastrada com sucesso !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Insira um valor válido !");
                }

            }else{
                MessageBox.Show("Insira uma descrição valida !");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_valor_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar < '0' || e.KeyChar > '9') &&
              (e.KeyChar != ',' && e.KeyChar != '.' &&
               e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
                {
                    e.KeyChar = (Char)0;
                }
                else
                {
                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (!txt_valor.Text.Contains(','))
                        {
                            e.KeyChar = ',';
                        }
                        else
                        {
                            e.KeyChar = (Char)0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }


    }
}
