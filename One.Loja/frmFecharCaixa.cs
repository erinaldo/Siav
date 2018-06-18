using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
//using ImprimeCupom;
using One.MOVIMENTACOES;
using System.Data.SqlClient;
using One.Dal;
//using LFi.Control.Laçanmento_Financeiro;
using DataAccessLayer.Dal;
using One.Loja;
//using LFi.Control.Laçanmento_Financeiro;
//using LFi.Control.Laçanmento_Financeiro;
//using ImprimeCupom;
//using LFi.Control.Laçanmento_Financeiro;
//using ImprimeCupom;
//using LFi.Control.Laçanmento_Financeiro;

namespace One.RELATORIOS
{
    public partial class frm_FechamentoCaixa : Form
    {
        private Form parent;
        public frm_FechamentoCaixa(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public Decimal TotalFinal = 0;
        FechamentoCaixaBLL objFC = new FechamentoCaixaBLL();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frm_Fechamento_Load(object sender, EventArgs e)
        {
            //CarregarLoad();
        }

        private void CarregarLoad()
        {
            //Carregar informações caixa 
            try
            {

                DataTable tab1 = null;
                tab1 = carregaeEncerramentoCaixa();
                dgEncerramento.DataSource = tab1;
                dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                foreach (DataGridViewColumn column in dgEncerramento.Columns)
                {
                    if (column.DataPropertyName == "Tipo")
                        column.Width = 500; //tamanho fixo da primeira coluna

                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                dgEncerramento.Columns[2].Visible = false;

                dgDados.Rows.Add("5 centavo");
                dgDados.Rows.Add("10 centavo");
                dgDados.Rows.Add("25 centavo");
                dgDados.Rows.Add("50 centavo");
                dgDados.Rows.Add("1 (Moeda)");
                dgDados.Rows.Add("2 Reais");
                dgDados.Rows.Add("5 Reais");
                dgDados.Rows.Add("10 Reais");
                dgDados.Rows.Add("20 Reais");
                dgDados.Rows.Add("50 Reais");
                dgDados.Rows.Add("100 Reais");

                //CalcularEncerramentoAntigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void AtualizarAbertura()
        {
            SqlCommand cmd = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                        "Update fin_abertura_caixa set Fechou = 1 where fin_codigo = @IDAber"
                    );
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = int.Parse(lblCodigoAbertura.Text.ToString());
                objD.ExecutaComando(cmd);
                cmd = null;
                objD = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable VerificarMesaEmAberto()
        {
            SqlCommand cmd = null;
            DataTable tab = null;
            Contexto objD = null;
            try
            {
                objD = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat
                    (
                        "Select Status From mesa where Status = 1"
                    );
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.Int)).Value = int.Parse(lblCodigoAbertura.Text.ToString());
                tab = objD.ExecutaConsulta(cmd);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd = null;
            objD = null;
            return tab;
        }
        private DataTable carregaeEncerramentoCaixa()
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
                cmd.Parameters.Add(new SqlParameter("@IDAber", SqlDbType.VarChar)).Value = int.Parse(lblCodigoAbertura.Text.ToString());
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
        public void GerarRelatorios()
        {


        }

        private void btGerar_Click(object sender, EventArgs e)
        {

        }

        public void Fechamento()
        {
            try
            {
                DataTable tabmesa = null;
                // tabmesa = VerificarMesaEmAberto();
                // if (tabmesa.Rows.Count > 0)
                // {
                //     throw new Exception("Existe mesas em aberto! Por favor faça o encerramento clique em F7 no PDV!");
                // }

                Lancamento Lan = new Lancamento();
                DataTable tab = null;
                tab = carregaeEncerramentoCaixa();
                if (tab.Rows.Count > 0)
                    //   TotalFinal = decimal.Parse(tab.Rows[3]["Tipo"].ToString());
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        if (tab.Rows[i]["Tipo"].ToString() == "Total Final(R$ )		")
                        {
                            TotalFinal = decimal.Parse(tab.Rows[i]["Valor R$"].ToString());
                        }
                    }

                if (objFC.JaFechou(int.Parse(txtCodUsuario.Text.ToString()), int.Parse(lblCodigoAbertura.Text.ToString())))
                    throw new Exception("Fechamento diário já foi realizado");
                objFC.limpar();
                objFC.data = DateTime.Now.Date;
                objFC.hora = TimeSpan.FromHours(DateTime.Now.Hour) + TimeSpan.FromMinutes(DateTime.Now.Minute) + TimeSpan.FromSeconds(DateTime.Now.Second);
                objFC.usuario = global.codUsuario;
                objFC.IDAber = int.Parse(global.NumeroCaixa.ToString());
                objFC.valor = TotalFinal;
                objFC.inserir();
                Lan.Inserir(objFC.data, 1, "VENDAS PDV", "C", TotalFinal, objFC.codigo);
                Lan = null;
                AtualizarAbertura();
                MessageBox.Show("Fechamento do Dia Realizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (MessageBox.Show("Deseja Imprimir o comprovante do encerramento do caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    ImprimirFechamentoCaixa();
                }
                else
                {
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (objFC.JaFechou(int.Parse(txtCodUsuario.Text)))
            //        throw new Exception("Fechamento diário já foi realizado");
            //    objFC.limpar();
            //    objFC.data = DateTime.Now.Date;
            //    objFC.hora = TimeSpan.FromHours(DateTime.Now.Hour) + TimeSpan.FromMinutes(DateTime.Now.Minute) + TimeSpan.FromSeconds(DateTime.Now.Second);
            //    objFC.usuario = global.codUsuario;
            //    objFC.valor = TotalFinal;
            //    objFC.inserir();
            //    MessageBox.Show("Fechamento do Dia Realizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //    if (MessageBox.Show("Deseja Imprimir o comprovante do encerramento do caixa?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        ImprimirFechamentoCaixa();
            //    }
            //    else
            //    {
            //        this.Close();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        public void ImprimirFechamentoCaixa()
        {
            try
            {
               //ImprimeTexto imp = new ImprimeTexto();
               ////
               ////ImprimeCupom.ImprimeTexto imp = new ImprimeCupom.ImprimeTexto();
               //imp.Inicio("LPT1");
               ////
               //imp.ImpLF(imp.NegritoOn + "FECHAMENTO CAIXA" + imp.NegritoOff);
               //imp.ImpLF("-------------------------------------");
               //imp.Pula(1);
               //
               //
               //String aux = "Data: " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year
               //   + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
               //imp.ImpLF(aux);
               //imp.ImpLF("Operador:" + global.nomeUsuario);
               //imp.Pula(2);
               //DataTable tab = null;
               //tab = carregaeEncerramentoCaixa();
               //
               //if (tab.Rows.Count > 0)
               //{
               //   //TotalFinal = decimal.Parse(tab.Rows[3]["Tipo"].ToString());
               //    for (int i = 0; i <= tab.Rows.Count - 1; i++)
               //    {
               //        
               //        String v = tab.Rows[i]["Tipo"].ToString().Replace("*", "");
               //        v = v.Replace("FUNDO DE CAIXA - INICIAL (R$ )", "Fundo de caixa - inicial (R$)");
               //        v = v.Replace("TOTAL DE RETIRADA (R$ )", "Total de retirada (R$)");
               //        v = v.Replace("TOTAL CRÉDITO CAIXA (R$ )", "Total credito caixa (R$)");
               //        v = v.Replace("TOTAL VENDAS REALIZADAS (R$ )", "Total vendas realizadas (R$)");
               //        v = v.Replace("TOTAL DESCONTO", "Total desconto");
               //        v = v.Replace("TOTAL GERAL FINAL (R$ )", "Total geral final (R$)");
               //        
               //
               //        imp.ImpLF(v);
               //        imp.ImpLF(tab.Rows[i]["Valor R$"].ToString());
               //
               //        if (v == "DETALHES DAS VENDAS PAGAMENTOS" || v == "Fundo de caixa - inicial (R$)")
               //            imp.Pula(1);
               //    }
               //    imp.ImpLF("---------------------");
               //    imp.Pula(2);                   
               //    imp.Fim();
               //}

                //imp.ImpLF("Carlos dos Santos - MVP C#");
                //imp.ImpLF("CDS Informática Ltda.");
                //imp.ImpLF("-------------------------------------");
                //imp.ImpLF("Componente de impressao em modo texto");
                //for (int i = 0; i < 5; i++)
                //{
                //    imp.ImpLF("Linha impressa " + i.ToString());
                //}
                //imp.ImpLF(imp.NegritoOn + "Negrito ligado" + imp.NegritoOff);
                //imp.ImpLF(imp.Expandido + "Expandido" + imp.Normal);
                //imp.ImpLF(imp.Comprimido + "Comprimido" + imp.Normal);
                //imp.Pula(2);
                //imp.ImpCol(10, "Coluna 10");
                //imp.ImpCol(40, "Coluna 40");
                //imp.Pula(2);
                //imp.Imp((char)27 + "0");
                //imp.ImpLF("8 linha ppp");
                //imp.ImpLF("8 linha ppp");
                //imp.ImpLF("8 linha ppp");
                //imp.Imp((char)27 + "2");
                //imp.ImpLF("6 linha ppp");
                //imp.ImpLF("6 linha ppp");
                //imp.ImpLF("6 linha ppp");
                //imp.Pula(2);
                //imp.Fim();


                //
                // DataTable tab = null;
                // tab = carregaeEncerramentoCaixa();
                //  String data = "Data: " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year
                //     + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                //  String ImpLF ="";
                //  ImpLF = "FECHAMENTO CAIXA     " + data + Environment.NewLine;
                //  ImpLF += ("Operador: " + lUsuario.Text) + Environment.NewLine;
                //  if (tab.Rows.Count > 0)
                //  {
                //      //   TotalFinal = decimal.Parse(tab.Rows[3]["Tipo"].ToString());
                //      for (int i = 0; i <= tab.Rows.Count - 1; i++)
                //      {
                //          ImpLF += (tab.Rows[i]["Tipo"].ToString().Replace("*","")) + Environment.NewLine;
                //          ImpLF += (tab.Rows[i]["Valor R$"].ToString()) + Environment.NewLine;
                //      }
                //      ImpLF += "---------------------" + Environment.NewLine + Environment.NewLine;
                //      ImpLF += "               " + Environment.NewLine;  //+ valor.ToString();
                //      ImpLF += "               " + Environment.NewLine;  //+ valor.ToString();
                //      int Imp;
                //      //Imprime a impressão Bamatech TH2500
                //      Imp = MP2032.FormataTX(ImpLF + "\r\n\r\n", 2, 0, 0, 0, 1);
                //     
                //  }
                //  //Imp = MP2032.AcionaGuilhotina(0);//chama a função da DLL(Corte Total)
                //  this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frm_Fechamento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void FazerBackupdoSistema()
        {
            try
            {
                Acesso ac = new Acesso();
                ac.RealizarBackupSistema();
                ac = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao Realizar Bakup de rotina", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_Fechamento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.End:
                    if (MessageBox.Show("Tem certeza que deseja efetuar o encerramento do caixa ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Fechamento();
                        // FazerBackupdoSistema();
                        this.Close();
                    }
                    this.parent.Close();
                    One.MENUS.frmLogon logon = new MENUS.frmLogon();
                    logon.ShowDialog();
                    //   GerarRelatorios();
                    break;
                case Keys.Delete:
                    btnZerar_Click(sender, e);
                    break;
            }
        }

        private void AtualizarFechamento()
        {
            DataTable tab1 = null;
            tab1 = carregaeEncerramentoCaixa();
            dgEncerramento.DataSource = tab1;
            dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgEncerramento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            foreach (DataGridViewColumn column in dgEncerramento.Columns)
            {
                if (column.DataPropertyName == "Tipo")
                    column.Width = 200; //tamanho fixo da primeira coluna

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgEncerramento.Columns[2].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgEncerramento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    decimal cell1 = 0;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "5 centavo")
                        cell1 = 0.05M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "10 centavo")
                        cell1 = 0.10M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "25 centavo")
                        cell1 = 0.25M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "50 centavo")
                        cell1 = 0.50M;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "1 (Moeda)")
                        cell1 = 1;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "2 Reais")
                        cell1 = 2;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "5 Reais")
                        cell1 = 5;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "10 Reais")
                        cell1 = 10;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "20 Reais")
                        cell1 = 20;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "50 Reais")
                        cell1 = 50;
                    if (dgDados.CurrentRow.Cells[0].Value.ToString() == "100 Reais")
                        cell1 = 100;
                    decimal ValorTotal = 0;
                    decimal cell2 = Convert.ToDecimal(dgDados.CurrentRow.Cells[1].Value);
                    if (cell1.ToString() != "" && cell2.ToString() != "")
                    {

                        ValorTotal = cell1 * cell2;
                        dgDados.CurrentRow.Cells[2].Value = ValorTotal.ToString("C");
                    }
                }
                decimal valorTotal = 0;
                string valor = "";

                if (dgDados.CurrentRow.Cells[2].Value != null)
                {
                    valor = dgDados.CurrentRow.Cells[2].Value.ToString();
                    if (!valor.Equals(""))
                    {

                        for (int i = 0; i <= dgDados.RowCount - 1; i++)
                        {
                            if (dgDados.Rows[i].Cells[2].Value != null)
                            {
                                string v = dgDados.Rows[i].Cells[2].Value.ToString();
                                string vr = v.ToString().Replace("R$", "");
                                if (dgDados.Rows[i].Cells[2].Value != null)
                                    valorTotal += Convert.ToDecimal(vr);
                            }
                        }
                        if (valorTotal == 0)
                        {
                            MessageBox.Show("Nenhum registro encontrado");
                        }
                        txtTotal.Text = valorTotal.ToString("C");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frm_Fechamento_Shown(object sender, EventArgs e)
        {
            CarregarLoad();
        }

        private void btnZerar_Click(object sender, EventArgs e)
        {
            dgDados.Rows.Clear();
            dgDados.Rows.Add("5 centavo");
            dgDados.Rows.Add("10 centavo");
            dgDados.Rows.Add("25 centavo");
            dgDados.Rows.Add("50 centavo");
            dgDados.Rows.Add("1 (Moeda)");
            dgDados.Rows.Add("2 Reais");
            dgDados.Rows.Add("5 Reais");
            dgDados.Rows.Add("10 Reais");
            dgDados.Rows.Add("20 Reais");
            dgDados.Rows.Add("50 Reais");
            dgDados.Rows.Add("100 Reais");
            txtTotal.Text = "0,00";
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btF2_Click(object sender, EventArgs e)
        {

        }

    }
}
