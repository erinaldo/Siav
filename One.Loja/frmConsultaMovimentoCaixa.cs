using One.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using View;

namespace One.Cadastros_Casa_De_Negocio
{
    public partial class frmConsultaMovimentoCaixa : Form
    {
        public frmConsultaMovimentoCaixa()
        {
            InitializeComponent();
        }
        Contexto objD = null;
        public DateTime? dataInicial = null;
        public DateTime? dataFinal = null;
        private DataTable carregaeEncerramentoCaixa(int abertura)
        {
            Contexto objD = null;
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();

                cmd.CommandText = String.Concat
                    ("ResumoCaixaVendas");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = int.Parse(txtCodUsuario.Text);
                cmd.Parameters.Add(new SqlParameter("@UsuarioNome", SqlDbType.VarChar)).Value = txtUsuario.Text;
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.VarChar)).Value = abertura;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }
        private void ConsultaProdução_Load(object sender, EventArgs e)
        {
            dgDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Contexto objD = new Contexto();
            objD.PreencheComboBox(cboUsuario, "Usuario", "usu_codigo", "usu_login", "", "usu_login");
            objD = null;
            ContarLinhasRegistro();
        }

        private void ContarLinhasRegistro()
        {
            int quant_linhas = dgDados.RowCount;
            // exibe o resultado
            txtQtdRegistro.Text = Convert.ToString(quant_linhas);
        }

        private DataTable ConsultarMovimentoCaixaAbertura(DateTime? dataInicial, DateTime? dataFinal, Int64? usuario)
        {
              DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText =String.Concat
                    (" Select fin_codigo 'Seq.Abertura' ,fin_dataabertura 'Data da Abertura' , fin_valorInicial 'Valor', fin_caixa 'Caixa' From fin_abertura_caixa",
                     " Where Convert(Varchar,fin_dataAbertura,103) ",
                     " >= Convert(Varchar,@dtInicial,103) ",
                     " and convert(Varchar,fin_dataAbertura,103) <= ",
                     " Convert(Varchar,@dtFinal,103) and (fin_usuario = @Usuario or @Usuario = 0) ");
                cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dataInicial;
                cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dataFinal;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }
        private DataTable ConsultarMovimentoCaixaFechamente(DateTime? dataInicial, DateTime? dataFinal, Int64? usuario)
        {
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (" Select Idaber 'Seq.Abertura' ,fin_data 'Data do Encerramento', fin_valor'Valor', fin_caixa 'Caixa' From fin_fechamento_caixa",
                     " Where Convert(Varchar,fin_data,103) ",
                     " >= Convert(Varchar,@dtInicial,103) ",
                     " and convert(Varchar,fin_data,103) <= ",
                     " Convert(Varchar,@dtFinal,103) and (fin_usuario = @Usuario or @Usuario = 0) ");
                cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dataInicial;
                cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dataFinal;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.Int)).Value = usuario;
                tab = objD.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            objD = null;
            return tab;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            DataTable tab1 = null;
            DataTable tab2 = null;
            dataInicial = txtInicial.Value;
            dataFinal = txtFinal.Value;
            if (cboUsuario.SelectedValue != null)
            {
                tab1 = ConsultarMovimentoCaixaAbertura(dataInicial, dataFinal, int.Parse(cboUsuario.SelectedValue.ToString()));
                tab2 = ConsultarMovimentoCaixaFechamente(dataInicial, dataFinal, int.Parse(cboUsuario.SelectedValue.ToString()));
            }
            else
            {
                tab1 = ConsultarMovimentoCaixaAbertura(dataInicial, dataFinal, 0);
                tab2 = ConsultarMovimentoCaixaFechamente(dataInicial, dataFinal, 0);
            }
            dgDados.DataSource = tab1;
            dgFechamento.DataSource = tab2;
            ContarLinhasRegistro();
        }

        private void dgDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < dgDados.Rows.Count)
                {
                    int cod = 0;
                    cod = int.Parse(dgDados.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {

                        DataTable tab1 = null;
                        tab1 = carregaeEncerramentoCaixa(int.Parse(lblCodigoAbertura.ToString()));
                        dgEncerramento.DataSource = tab1;
                        dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        }
    
}
