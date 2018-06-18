using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using One.Bll;
using View;
using System.Data.SqlClient;
using One.Dal;

namespace One.MOVIMENTACOES
{
    public partial class EntradaMercadoria : Form
    {
        public EntradaMercadoria()
        {
            InitializeComponent();
        }
        Contexto con = null;
        comprasProdutoBLL objCP = new comprasProdutoBLL();
        ComprasBLL objCom = new ComprasBLL();

        public void limpar()
        {
            try
            {
                dgDados.Rows.Clear();
                txtCodigo.Text = "";
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void stiloGrid()
        {

            int i = 0;
            if (gvPesquisa.Rows.Count != 0)
            {
                foreach (DataGridViewRow row in gvPesquisa.Rows)
                {
                    if (i % 2 != 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromName("ActiveCaption");
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    i++;
                }
                gvPesquisa.ClearSelection();
                objCom.limpar();
            }
        }

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;
                tab = objCom.localizarEmTudo(txtPesquisar.Text);
                gvPesquisa.DataSource = tab;
                //gvPesquisa.Columns["cat_codigo"].HeaderText = "Código";
                //gvPesquisa.Columns["cat_descricao"].HeaderText = "Nome";
                //gvPesquisa.Columns[1].Width = gvPesquisa.Width - 103;
              //  stiloGrid();
                gvPesquisa.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 

        private void EntradaMercadoria_Load(object sender, EventArgs e)
        {
            gvPesquisa.AutoSizeColumnsMode =
              DataGridViewAutoSizeColumnsMode.AllCells;
            
            
            txtData.Text = DateTime.Now.ToString();
            dgDados.Columns[0].Width = dgDados.Width / 3-130;
            dgDados.Columns[1].Width = dgDados.Width / 3+200;
            dgDados.Columns[2].Width = dgDados.Width / 3-140;
            TabControl1.SelectedIndex = 0;
        }

        private void txtNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                dgDados.Rows.Clear();
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objCP.limpar();
                    objCP.cp_compras = cod;
                    objCP.localizarLeave(objCP.cp_compras.ToString(), "cp_compras");
                    if (objCP.cp_compras != 0)
                    {
                        DataTable tab = objCP.localizarComRetorno(objCP.cp_compras.ToString(), "cp_compras");
                        for (int i = 0; i < tab.Rows.Count; i++)
                        {
                            ProdutosBLL objPro = new ProdutosBLL();
                            objPro.localizar(tab.Rows[i][1].ToString(), "pro_codigo");
                            if(tab.Rows[i][5].ToString() != "Sim")
                                dgDados.Rows.Add(false, objPro.pro_nome, tab.Rows[i][3].ToString()); 
                            //else
                            //dgDados.Rows.Add(true, objPro.pro_nome, tab.Rows[i][3].ToString());
                            objPro = null;
                        }
                    }
                    else
                        limpar();
                }
                else
                    limpar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
          
        }

        private void btPrimeiro_Click(object sender, EventArgs e)
        {
          
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
           
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            
        }

        private void btUltimo_Click(object sender, EventArgs e)
        {
            
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objCom.limpar();
                    objCP.limpar();
                    limpar();
                    carregaGrid();
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100);   
                    btAnterior.Enabled = false;
                    btPrimeiro.Enabled = false;
                    btProximo.Enabled = false;
                    btUltimo.Enabled = false;
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objCom.limpar();
                    objCP.limpar();
                    limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    btAnterior.Enabled = true;
                    btPrimeiro.Enabled = true;
                    btProximo.Enabled = true;
                    btUltimo.Enabled = true;
                    
                    groupBox1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            carregaGrid();
        }

        private void gvPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                {
                    int cod = 0;
                    cod = int.Parse(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString());
                    if (cod != 0)
                    {
                        TabControl1.SelectedIndex = 0;
                        txtPesquisar.Text = "";
                        objCom.com_codigo = cod;
                        objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                        txtCodigo.Text = objCom.com_codigo.ToString();
                        txtCodigo.Text = objCom.com_codigo.ToString();
                        txtNumero_Leave(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void gvPesquisa_Sorted(object sender, EventArgs e)
        {
            //try
            //{
            //    stiloGrid();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}   
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                 decimal subtotal = 0;
                if (txtCodigo.Text != "" && dgDados.Rows.Count > 0)
                {
                    for (int i = 0; i < dgDados.Rows.Count; i++)
                    {

                        objCP.cp_compras = int.Parse(txtCodigo.Text);
                        ProdutosBLL objPro = new ProdutosBLL();
                        objPro.localizar(dgDados.Rows[i].Cells[1].Value.ToString(), "pro_nome");
                        objCP.cp_produtos = objPro.pro_codigo;

                        objCP.localizarProdutoDaCompra(objCP.cp_compras, objCP.cp_produtos); //procurar pelo produto atual

                        if (((bool)dgDados.Rows[i].Cells[0].Value == false))
                            objCP.cp_chegou = "Não";
                        else
                        {
                            objCP.cp_chegou = "Sim";

                            objCP.cp_quantidade = decimal.Parse(dgDados.Rows[i].Cells[2].Value.ToString()); //quantidade
                            objCP.cp_subtotal = objCP.cp_quantidade * objCP.cp_valorUnitario;
                            subtotal += objCP.cp_subtotal;
                            objPro.pro_quantidade += objCP.cp_quantidade;
                            objPro.alterarQuantidade();
                            LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, dgDados.Rows[i].Cells[1].Value.ToString(), global.codUsuario, global.nomeUsuario, decimal.Parse(dgDados.Rows[i].Cells[2].Value.ToString()), "Entrada via compras");
                        }
                        objCP.alterar();//Alterar status


                        objPro = null;
                    }
                    limpar();
                    objCom.com_codigo = objCP.cp_compras;
                    objCom.com_valorTotal = subtotal;
                    objCom.alterarEntradaMercadoria();
                    objCP.limpar();

                    MessageBox.Show("Entrada de mercadorias inserida com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public void LançamentoEstoqueProduto(string Tipo, int produtoID, DateTime DataLancamento, string DescricaoProduto, int UsuarioID, string NomeUsuario, decimal? Quantidade, string Motivo)
        {
            try
            {
                //decimal QuantidadeAdicionada = 0;
                //if (txtAdicionaEstoque.Text != String.Empty)
                //{
                //    QuantidadeAdicionada = decimal.Parse(txtAdicionaEstoque.Text.ToString());
                //}
                //if (QuantidadeAdicionada != 0)
                //{
                SqlCommand cmd = null;

                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Insert into EstoqueProdutos (Tipo,DataLancamento,ProdutoID,DescricaoProduto,UsuarioID,NomeUsuario,Quantidade,Motivo)"
                    , "values (@Tipo,@DataLancamento,@ProdutoID,@DescricaoProduto,@UsuarioID,@NomeUsuario,@Quantidade,@Motivo)"
                    );
                cmd.Parameters.Add(new SqlParameter("@DataLancamento", SqlDbType.DateTime)).Value = DataLancamento;
                cmd.Parameters.Add(new SqlParameter("@ProdutoID", SqlDbType.Int)).Value = produtoID;
                cmd.Parameters.Add(new SqlParameter("@DescricaoProduto", SqlDbType.VarChar)).Value = DescricaoProduto;
                cmd.Parameters.Add(new SqlParameter("@UsuarioID", SqlDbType.Int)).Value = UsuarioID;
                cmd.Parameters.Add(new SqlParameter("@NomeUsuario", SqlDbType.VarChar)).Value = NomeUsuario;
                cmd.Parameters.Add(new SqlParameter("@Quantidade", SqlDbType.Int)).Value = Quantidade;
                cmd.Parameters.Add(new SqlParameter("@Motivo", SqlDbType.VarChar)).Value = Motivo;
                cmd.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar)).Value = Tipo;

                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
                //  }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    txtNumero_Leave(sender, e);
                else
                    limpar();
                objCom.localizarPrimeiroUltimo("primeiro");
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                    txtCodigo.Text = objCom.com_codigo.ToString();
                    txtNumero_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    txtNumero_Leave(sender, e);
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objCom.localizarProxAnterior("anterior", 0);
                else
                    objCom.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                    txtCodigo.Text = objCom.com_codigo.ToString();
                    txtNumero_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    txtNumero_Leave(sender, e);
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objCom.localizarProxAnterior("proximo", 0);
                else
                    objCom.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                    txtCodigo.Text = objCom.com_codigo.ToString();
                    txtNumero_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    txtNumero_Leave(sender, e);
                else
                    limpar();
                objCom.localizarPrimeiroUltimo("ultimo");
                if (objCom.com_codigo != 0)
                {
                    objCom.localizar(objCom.com_codigo.ToString(), "com_codigo");
                    txtCodigo.Text = objCom.com_codigo.ToString();
                    txtNumero_Leave(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {

            printDGV.Print_DataGridView(gvPesquisa);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
