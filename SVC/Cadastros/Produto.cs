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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using View;


namespace One.CADASTROS
{
    public partial class Produto : Form
    {
        public Produto()
        {
            InitializeComponent();
        }
        Contexto con = null;
        public int proCompra = 0;
        ProdutosBLL objPro = new ProdutosBLL();
        private Ean13 ean13 = null;

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
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    i++;
                }
                gvPesquisa.ClearSelection();
                objPro.limpar();
            }
        }

        public void limpar()
        {
            try
            {
                txtCodigo.Text = "";
                txtData.Text = DateTime.Now.ToString();
                txtEstoqueAtual.Text = "";
                txtEstoqueMaximo.Text = "";
                txtEstoqueMinimo.Text = "";
                txtPrecoCusto.Text = "";
                txtPrecoVenda.Text = "";
                txtPrecoAtacado.Text = "";
                txtProduto.Text = "";
                cbCategoria.SelectedIndex = -1;
                cbGrupo.SelectedIndex = -1;
                cbSubgrupo.SelectedIndex = -1;
                cbUnidade.SelectedIndex = -1;
                cbMarca.SelectedIndex = -1;
                cbFornecedor.SelectedIndex = -1;
                txtPesquisar.Text = "";
                txtCodigoBarras.Text = "";
                txtMargem.Text = "";
                txtAdicionaEstoque.Text = "";
                txtTamanho.Text = "";
                txtComissao.Text = "";
                txtCodigo.Enabled = true;
                txtCodigo.ReadOnly = false;
                pictImageProduto.Image = null;
                checkBox1.Checked = false;
                //txtEstoqueAtual.Enabled = true;
                txtAdicionaEstoque.Enabled = false;
                txtAliquota.Text = "0";
                txtporcentagemtributos.Text = "0";

                txtNCM.Text = "";
                txtcsosn.Text = "";
                txtcst.Text = "";
                txtcest.Text = "";

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void carregaCombo()
        {

            try
            {

                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbCategoria, "Categoria", "cat_codigo", "cat_descricao", "", "cat_descricao");
                objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbGrupo, "Grupo", "gru_codigo", "gru_descricao", "", "gru_descricao");
                objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbSubgrupo, "SubGrupo", "sg_codigo", "sg_descricao", "", "sg_descricao");
                objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbUnidade, "Unidades", "uni_codigo", "uni_descricao", "", "uni_descricao");
                objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbMarca, "Marcas", "mar_codigo", "mar_descricao", "", "mar_descricao");
                objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                objD = null;

                //objD = new Contexto();
                //objD.PreencheComboBox(cbProdutos, "Produtos", "pro_codigo", "pro_nome", "", "pro_nome");
                //objD = null;

                objD = new Contexto();
                objD.PreencheComboBox(cbCFOP, "cfop", "codigo", "descricao", "", "");
                objD = null;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public Boolean validaNCM()
        {

            String texto = "NCM.Validar('" + objPro.ncm + "')";
            System.IO.File.WriteAllText(@"C:\Rede_Sistema\ENT.txt", texto);



            return false;
        }

        public void carregaPropriedades()
        {
            try
            {
                if (txtCodigo.Text != "")
                {
                    objPro.pro_codigo = int.Parse(txtCodigo.Text);
                }
                else
                {
                    objPro.pro_codigo = 0;
                }

                txtProduto.Text = txtProduto.Text.Trim();

                if (txtProduto.Text != "")
                {
                    objPro.pro_nome = txtProduto.Text;
                }
                else
                {
                    throw new Exception("O campo nome é de preenchimento obrigatório");
                }

                if (txtData.Text != "")
                {
                    objPro.pro_dataCadastro = Convert.ToDateTime(txtData.Text);
                }
                else
                {
                    throw new Exception("O campo data de Vencimento é de preenchimento obrigatório");
                }


                objPro.pro_codigoBarra = txtCodigoBarras.Text;
                objPro.pro_dataCadastro = DateTime.Now;

                if (cbCategoria.SelectedValue == null)
                {
                    //Dal.CategoriaDAL categoriaDal = new CategoriaDAL();
                    //DataTable dtCategoria = categoriaDal.localizar("sem categoria", "cat_descricao");
                    objPro.pro_categoria = 1;
                    //Convert.ToInt32(dtCategoria.Rows[0]["cat_codigo"].ToString());
                }
                else
                {
                    objPro.pro_categoria = int.Parse(cbCategoria.SelectedValue.ToString());
                }

                if (cbGrupo.SelectedValue == null)
                {
                    objPro.pro_grupo = 1;
                }
                else
                {
                    objPro.pro_grupo = int.Parse(cbGrupo.SelectedValue.ToString());
                }

                if (cbSubgrupo.SelectedValue == null)
                {
                    objPro.pro_subGrupo = 1;
                }
                else
                {
                    objPro.pro_subGrupo = int.Parse(cbSubgrupo.SelectedValue.ToString());
                }

                if (cbUnidade.SelectedValue == null)
                {
                    objPro.pro_unidade = 1;
                }
                else
                {
                    objPro.pro_unidade = int.Parse(cbUnidade.SelectedValue.ToString());
                }

                if (cbMarca.SelectedValue == null)
                {
                    //Dal.MarcasDAL marcasDal = new MarcasDAL();
                    //DataTable dtMarca = marcasDal.localizar("sem marca", "mar_descricao");
                    objPro.pro_marca = 1;//Convert.ToInt32(dtMarca.Rows[0]["mar_codigo"].ToString());
                }
                else
                {
                    objPro.pro_marca = int.Parse(cbMarca.SelectedValue.ToString());
                }

                //if (cbFornecedor.SelectedValue == null)
                //{
                //    throw new Exception("Fornecedor não encontrada na base de dados");
                //}
                //else
                //{
                //    objPro.pro_fornecedor = int.Parse(cbFornecedor.SelectedValue.ToString());
                //}
                objPro.pro_fornecedor = 1;

                String x = "";

                for (int i = 0; i <= txtPrecoCusto.Text.Length - 1; i++)
                {
                    if ((txtPrecoCusto.Text[i] >= '0' &&
                    txtPrecoCusto.Text[i] <= '9') ||
                    txtPrecoCusto.Text[i] == ',')
                    {
                        x += txtPrecoCusto.Text[i];
                    }
                }

                txtPrecoCusto.Text = x;
                txtPrecoCusto.SelectAll();

                txtPrecoCusto.Text = txtPrecoCusto.Text.Trim();

                if (txtPrecoCusto.Text != "")
                {
                    objPro.pro_precoCusto = Decimal.Parse(txtPrecoCusto.Text);
                }
                else
                {
                    throw new Exception("O campo 'preço de custo' é de preenchimento obrigatório");
                }

                x = "";
                for (int i = 0; i <= txtPrecoVenda.Text.Length - 1; i++)
                {
                    if ((txtPrecoVenda.Text[i] >= '0' &&
                    txtPrecoVenda.Text[i] <= '9') ||
                    txtPrecoVenda.Text[i] == ',')
                    {
                        x += txtPrecoVenda.Text[i];
                    }
                }
                
                txtPrecoVenda.Text = x;
                txtPrecoVenda.SelectAll();

                txtPrecoVenda.Text = txtPrecoVenda.Text.Trim();

                if (txtPrecoVenda.Text != "")
                {
                    objPro.pro_precoVenda = Decimal.Parse(txtPrecoVenda.Text);
                }
                else
                {
                    throw new Exception("O campo 'preço de venda' é de preenchimento obrigatório");
                }



                x = "";
                for (int i = 0; i <= txtPrecoAtacado.Text.Length - 1; i++)
                {
                    if ((txtPrecoAtacado.Text[i] >= '0' &&
                    txtPrecoAtacado.Text[i] <= '9') ||
                    txtPrecoAtacado.Text[i] == ',')
                    {
                        x += txtPrecoAtacado.Text[i];
                    }
                }

                txtPrecoAtacado.Text = x;
                txtPrecoAtacado.SelectAll();

                txtPrecoAtacado.Text = txtPrecoAtacado.Text.Trim();

                if (txtPrecoAtacado.Text != "")
                {
                    objPro.pro_precoAtacado = Decimal.Parse(txtPrecoAtacado.Text);
                }
                else
                {
                    throw new Exception("O campo 'preço de atacado' é de preenchimento obrigatório");
                }


                txtEstoqueAtual.Text = txtEstoqueAtual.Text.Trim();

                if (txtEstoqueAtual.Text != "")
                {
                    objPro.pro_quantidade = decimal.Parse(txtEstoqueAtual.Text);
                }
                else
                {
                    //throw new Exception("O campo 'estoque atual' é de preenchimento obrigatório");
                    objPro.pro_quantidade = 0;
                }

                if (txtEstoqueMinimo.Text != "")
                {
                    objPro.pro_estoqueMin = int.Parse(txtEstoqueMinimo.Text);
                }
                else
                {
                    throw new Exception("O campo 'estoque mínimo' é de preenchimento obrigatório");
                }

                if (txtEstoqueMaximo.Text != "")
                {
                    objPro.pro_estoqueMax = int.Parse(txtEstoqueMaximo.Text);
                }
                else
                {
                    objPro.pro_estoqueMax = 10;
                    // throw new Exception("O campo 'estoque máximo' é de preenchimento obrigatório");
                }

                txtTamanho.Text = txtTamanho.Text.Trim();

                if (txtTamanho.Text != "")
                {
                    objPro.pro_tamanho = int.Parse(txtTamanho.Text);
                }

                txtMargem.Text = txtMargem.Text.Trim();

                if (txtMargem.Text != "")
                {
                    objPro.pro_margem = Decimal.Parse(txtMargem.Text);
                }
                else
                {
                    objPro.pro_margem = 0;
                }

                txtAdicionaEstoque.Text = txtAdicionaEstoque.Text.Trim();

                if (txtAdicionaEstoque.Text != "")
                {
                    objPro.pro_quantidade = objPro.pro_quantidade + int.Parse(txtAdicionaEstoque.Text);
                }

                txtComissao.Text = txtComissao.Text.Trim();

                if (txtComissao.Text != "")
                {
                    objPro.pro_comissao = Decimal.Parse(txtComissao.Text);
                }
                else
                {
                    objPro.pro_comissao = 0;
                }


                // Fiscal ======================================================================

                if (txtNCM.Text != null && txtNCM.Text != "" && txtNCM.Text != "0")
                    objPro.ncm = txtNCM.Text;
                else
                    objPro.ncm = "0";

                if (cbCFOP.SelectedValue != null && cbCFOP.SelectedValue != "" && cbCFOP.SelectedValue != "0")
                {
                    //Dal.CategoriaDAL categoriaDal = new CategoriaDAL();
                    //DataTable dtCategoria = categoriaDal.localizar("sem categoria", "cat_descricao");
                    objPro.cfop = Int32.Parse(cbCFOP.SelectedValue.ToString().Trim()); //Convert.ToInt32(dtCategoria.Rows[0]["cat_codigo"].ToString());
                }

                if (txtAliquota.Text.Trim() == "")
                {
                    txtAliquota.Text = "0";
                }

                try
                {
                    decimal.Parse(txtAliquota.Text);
                    objPro.pro_aliquota = decimal.Parse(txtAliquota.Text);
                }
                catch
                {
                    MessageBox.Show("Aliquota inválida!");
                    return;
                }



                if (txtporcentagemtributos.Text.Trim() == "")
                {
                    txtporcentagemtributos.Text = "0";
                }

                try
                {
                    decimal.Parse(txtporcentagemtributos.Text);
                    objPro.porcentagem_tributos = decimal.Parse(txtporcentagemtributos.Text);
                }
                catch
                {
                    MessageBox.Show("Porcentagem de Tributos inválido!");
                    return;
                }

                if (txtcsosn.Text.Trim() == "" || txtcsosn.Text.Trim() == null)
                    objPro.pro_csosn = " ";
                else
                    objPro.pro_csosn = txtcsosn.Text;

                if (txtcst.Text.Trim() == "" || txtcst.Text.Trim() == null)
                    objPro.pro_cst = " ";
                else                    
                    objPro.pro_cst = txtcst.Text;

                if (txtcest.Text.Trim() == "" || txtcest.Text.Trim() == null)
                    objPro.cest = " ";
                else                    
                    objPro.cest = txtcest.Text;
                    



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaCampos()
        {
            try
            {
                DataTable tab = null;
                tab = carregarTipoDeProduto(objPro.pro_codigo);
                cboTipoDeProduto.Text = tab.Rows[0]["TipoProduto"].ToString();
                if (tab.Rows[0]["Imagem"].ToString() != "")
                {
                    byte[] data0 = (byte[])tab.Rows[0]["Imagem"];
                    MemoryStream ms0 = new MemoryStream(data0);
                    pictImageProduto.Image = Image.FromStream(ms0);
                }
                if (objPro.pro_codigo == 0)
                    txtCodigo.Text = "";
                else
                    txtCodigo.Text = objPro.pro_codigo.ToString();
                txtProduto.Text = objPro.pro_nome;
                txtCodigoBarras.Text = objPro.pro_codigoBarra;
                if (txtCodigoBarras.Text.Length == 13)
                {
                    System.Drawing.Graphics g = this.pictImageProduto.CreateGraphics();
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
                        new Rectangle(0, 0, pictImageProduto.Width, pictImageProduto.Height));
                    CreateEan13();
                    ean13.Scale = (float)Convert.ToDecimal("0,8");//(float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
                    ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
                    g.Dispose();
                }
                txtData.Text = objPro.pro_dataCadastro.ToString();
                cbCategoria.SelectedValue = objPro.pro_categoria;
                if (objPro.pro_grupo != 0)
                    cbGrupo.SelectedValue = objPro.pro_grupo;
                else
                    cbGrupo.SelectedIndex = -1;
                if (objPro.pro_subGrupo != 0)
                    cbSubgrupo.SelectedValue = objPro.pro_subGrupo;
                else
                    cbSubgrupo.SelectedIndex = -1;
                if (objPro.pro_unidade != 0)
                    cbUnidade.SelectedValue = objPro.pro_unidade;
                else
                    cbUnidade.SelectedIndex = -1;
                cbMarca.SelectedValue = objPro.pro_marca;

                FornecedoresBLL objFor = new FornecedoresBLL();
                objFor.localizar(objPro.pro_fornecedor.ToString(), "for_codigo");
                if (objFor.for_tipo_fornecedor == "Pessoa Jurídica")
                {
                    checkBox1.Checked = true;
                    Contexto objD = new Contexto();
                    objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
                    objD = null;
                }
                else
                {
                    checkBox1.Checked = false;
                    Contexto objD = new Contexto();
                    objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                    objD = null;
                }

                cbFornecedor.SelectedValue = objPro.pro_fornecedor;
                objFor = null;
                txtPrecoCusto.Text = objPro.pro_precoCusto.ToString();
                txtPrecoCusto.Text = String.Format(txtPrecoCusto.Text, "C");
                txtPrecoVenda.Text = objPro.pro_precoVenda.ToString();
                txtPrecoVenda.Text = String.Format(txtPrecoVenda.Text, "C");
                txtPrecoAtacado.Text = objPro.pro_precoAtacado.ToString();
                txtPrecoAtacado.Text = String.Format(txtPrecoAtacado.Text, "C");
                txtEstoqueAtual.Text = objPro.pro_quantidade.ToString();
                txtEstoqueMinimo.Text = objPro.pro_estoqueMin.ToString();
                txtEstoqueMaximo.Text = objPro.pro_estoqueMax.ToString();
                txtMargem.Text = objPro.pro_margem.ToString();
                txtTamanho.Text = objPro.pro_tamanho.ToString();
                txtComissao.Text = objPro.pro_comissao.ToString();
                txtAdicionaEstoque.Enabled = true;
                txtEstoqueAtual.Enabled = true;

                if (txtPrecoVenda.Text != "")
                    txtPrecoVenda.Text = Convert.ToDecimal(txtPrecoVenda.Text).ToString("C");
                if (txtPrecoAtacado.Text != "")
                    txtPrecoAtacado.Text = Convert.ToDecimal(txtPrecoAtacado.Text).ToString("C");
                if (txtPrecoCusto.Text != "")
                    txtPrecoCusto.Text = Convert.ToDecimal(txtPrecoCusto.Text).ToString("C");


                // Dados Fiscais
                if (objPro.cfop > 0)
                {
                    cbCFOP.SelectedValue = objPro.cfop;
                }

                if (txtAliquota.Text.Trim() == "")
                {
                    txtAliquota.Text = "0";
                }

                try{
                    decimal.Parse(txtAliquota.Text);

                }
                catch
                {
                    MessageBox.Show("Aliquota inválida!");
                    return;
                }

                txtNCM.Text = objPro.ncm;
                txtAliquota.Text = objPro.pro_aliquota.ToString();
                txtporcentagemtributos.Text = objPro.porcentagem_tributos.ToString();
                txtcsosn.Text = objPro.pro_csosn;
                txtcst.Text = objPro.pro_cst;
                txtcest.Text = objPro.cest;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void carregaGrid()
        {
            try
            {
                DataTable tab = null;
                tab = objPro.localizarEmTudoLITE(txtPesquisar.Text,cb_listar_tudo.Checked);
                gvPesquisa.DataSource = tab;
                // stiloGrid();
                gvPesquisa.ClearSelection();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable CarregarDadosEstoque(int ID)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
              // cmd = new SqlCommand();
              // cmd.CommandText = String.Concat("Select  * From EstoqueProdutos",
              //     " Where (ProdutoID = @id or @id =0)",
              //      " and Convert(Varchar,DataLancamento,112) >= Convert(Varchar,@dtInicial,112) ",
              //              " and convert(Varchar,DataLancamento,112) <= Convert(Varchar,@dtFinal,112) ",
              //              "  and (tipo = @tipo or @tipo ='') order by datalancamento "
              //
              //     );
              // cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = ID;
              // //cmd.Parameters.Add(new SqlParameter("@dtInicial", SqlDbType.DateTime)).Value = dtInicial.Value;
              // //cmd.Parameters.Add(new SqlParameter("@dtFinal", SqlDbType.DateTime)).Value = dtFinal.Value;
              // //cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar)).Value = cboTpEstoque.Text;
              // tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        public DataTable carregarTipoDeProduto(int ID)
        {
            Contexto con = new Contexto();
            DataTable tab = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Select  TipoProduto 'TipoProduto', imagem 'Imagem' From Produtos",
                    " Where pro_codigo = @id");
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = ID;
                tab = con.ExecutaConsulta(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            cmd = null;
            return tab;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        void ContextMenuStrip_Click(object sender, EventArgs e)
        {
            pictImageProduto.Image = null;
        }
        private void Produto_Load(object sender, EventArgs e)
        {

        }

        private void LoadProduto()
        {
            pictImageProduto.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            pictImageProduto.ContextMenuStrip.Items.Add("Limpar");
            pictImageProduto.ContextMenuStrip.Click += ContextMenuStrip_Click;

            txtTamanho.Text = "1";
            //  gvPesquisa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int quant_linhas = gvPesquisa.RowCount;
            // exibe o resultado
            txtReg.Text = Convert.ToString(quant_linhas);
            try
            {
                //this.MaximumSize = new Size(this.Width, this.Height);
                //this.MinimumSize = new Size(this.Width, this.Height);
                carregaCombo();
                limpar();
                txtData.Enabled = false;
                TabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                // Localizar usuário
                int cod;
                int.TryParse(txtCodigo.Text, out cod);
                if (cod != 0)
                {
                    objPro.limpar();
                    objPro.localizarLeave(cod.ToString(), "pro_codigo");
                    if (objPro.pro_codigo != 0)
                    {
                        carregaCampos();
                        txtCodigo.Enabled = false;
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

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                carregaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
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
                        objPro.pro_codigo = cod;
                        objPro.localizarLeave(objPro.pro_codigo.ToString(), "pro_codigo");
                        txtCodigo.Text = objPro.pro_codigo.ToString();
                        txtCodigo.Enabled = false;
                        carregaCampos();
                        DataTable tab = null;
                        tab = CarregarDadosEstoque(cod);
                        //dgEstoque.DataSource = tab;
                        tab = null;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 1)
                {
                    objPro.limpar();
                    limpar();
                    carregaGrid();
                    //Contar Registro do Sistema
                    int quant_linhas = gvPesquisa.RowCount;
                    // exibe o resultado
                    txtReg.Text = Convert.ToString(quant_linhas);
                    //Obtendo a quantidade Total do Estoque 
                    int quantidadeTotal = 0;
                    foreach (DataGridViewRow col in gvPesquisa.Rows)
                    {
                        quantidadeTotal = quantidadeTotal + Convert.ToInt32(col.Cells[3].Value);
                    }

                    txtTotItens.Text = Convert.ToString(quantidadeTotal);

                    //Obtendo o Valor Total do Estoque 
                    decimal valorTotal = 0;
                   // foreach (DataGridViewRow col in gvPesquisa.Rows)
                   // {
                   //     try { 
                   //     valorTotal = valorTotal + Convert.ToDecimal(col.Cells[5].Value) * Convert.ToInt32(col.Cells[3].Value);
                   //     }
                   //     catch { }
                   //  }
                    txtTotalEstoque.Text = Convert.ToString(valorTotal);
                    txtPesquisar.Focus();
                    //this.MaximumSize = new Size(this.Width, this.Height + 100);
                    //this.MinimumSize = new Size(this.Width, this.Height + 100);
                    //this.Size = new Size(this.Width, this.Height + 100);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y-100); 
                    this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    groupBox1.Visible = false;
                }
                else if (TabControl1.SelectedIndex == 0)
                {
                    objPro.limpar();
                    //this.MaximumSize = new Size(this.Width, this.Height - 50);
                    //this.MinimumSize = new Size(this.Width, this.Height - 50);
                    //this.Size = new Size(this.Width, this.Height - 50);
                    //this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+100);
                    this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    groupBox1.Visible = true;
                }
                else if (TabControl1.SelectedIndex == 2)
                {
                  //  Contexto objD = new Contexto();
                  //  objD = new Contexto();
                  //  objD.PreencheComboBox(cbProdutos, "Produtos", "pro_codigo", "pro_nome", "", "pro_nome");
                  //  objD = null;
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

        private void gvPesquisa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.RowIndex < gvPesquisa.Rows.Count)
                {
                    objPro.localizarLeave(gvPesquisa.Rows[e.RowIndex].Cells[0].Value.ToString(), "pro_codigo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPrecoCusto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecoCusto.Text != "")
                    txtPrecoCusto.Text = Convert.ToDecimal(txtPrecoCusto.Text).ToString("C");
            }
            catch (Exception)
            {
                txtPrecoCusto.Text = "";
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtPrecoCusto.Text.Contains(','))
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

        private void txtPrecoCusto_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtPrecoCusto.Text.Length - 1; i++)
                {
                    if ((txtPrecoCusto.Text[i] >= '0' &&
                    txtPrecoCusto.Text[i] <= '9') ||
                    txtPrecoCusto.Text[i] == ',')
                    {
                        x += txtPrecoCusto.Text[i];
                    }
                }
                txtPrecoCusto.Text = x;
                txtPrecoCusto.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPrecoVenda_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecoCusto.Text != "" && txtPrecoVenda.Text != "")
                {
                    String x = "";
                    for (int i = 0; i <= txtPrecoVenda.Text.Length - 1; i++)
                    {
                        if ((txtPrecoVenda.Text[i] >= '0' &&
                        txtPrecoVenda.Text[i] <= '9') ||
                        txtPrecoVenda.Text[i] == ',')
                        {
                            x += txtPrecoVenda.Text[i];
                        }
                    }
                    txtPrecoVenda.Text = x;

                    x = "";
                    for (int i = 0; i <= txtPrecoCusto.Text.Length - 1; i++)
                    {
                        if ((txtPrecoCusto.Text[i] >= '0' &&
                        txtPrecoCusto.Text[i] <= '9') ||
                        txtPrecoCusto.Text[i] == ',')
                        {
                            x += txtPrecoCusto.Text[i];
                        }
                    }
                    txtPrecoCusto.Text = x;


                    Decimal custo = Decimal.Parse(txtPrecoCusto.Text);
                    Decimal venda = Decimal.Parse(txtPrecoVenda.Text);
                    Decimal margem = venda / custo * 100 - 100;
                    txtMargem.Text = margem.ToString();
                }
                txtMargem.Text = Math.Round(Decimal.Parse(txtMargem.Text), 2).ToString();
                txtPrecoVenda.Text = Math.Round(Decimal.Parse(txtPrecoVenda.Text), 2).ToString();
                if (txtPrecoVenda.Text != "")
                    txtPrecoVenda.Text = Convert.ToDecimal(txtPrecoVenda.Text).ToString("C");
                if (txtPrecoCusto.Text != "")
                    txtPrecoCusto.Text = Convert.ToDecimal(txtPrecoCusto.Text).ToString("C");
            }
            catch (Exception)
            {
                txtPrecoVenda.Text = "";
                //MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtPrecoVenda.Text.Contains(','))
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

        private void txtPrecoVenda_Enter(object sender, EventArgs e)
        {
            try
            {
                String x = "";
                for (int i = 0; i <= txtPrecoVenda.Text.Length - 1; i++)
                {
                    if ((txtPrecoVenda.Text[i] >= '0' &&
                    txtPrecoVenda.Text[i] <= '9') ||
                    txtPrecoVenda.Text[i] == ',')
                    {
                        x += txtPrecoVenda.Text[i];
                    }
                }
                txtPrecoVenda.Text = x;
                txtPrecoVenda.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtEstoqueAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtEstoqueMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCodigoBarras_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtCodigoBarras.Text.Length == 13)
            //    {
            //        System.Drawing.Graphics g = this.pictureBox1.CreateGraphics();
            //        g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
            //            new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            //        CreateEan13();
            //        ean13.Scale = (float)Convert.ToDecimal("0,8");//(float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
            //        ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
            //        g.Dispose();
            //    }
            //    else
            //        pictureBox1.Image = null;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}

          // try
          // {
          //     // Localizar Produto
          //     if (txtCodigo.Text == "")
          //     {
          //         String cod;
          //         cod = txtCodigoBarras.Text;
          //         if (cod != "")
          //         {
          //             //objPro.limpar();
          //             objPro.localizarLeave(cod.ToString(), "pro_codigoBarra");
          //             if (objPro.pro_codigo != 0)
          //             {
          //                 carregaCampos();
          //                 txtCodigo.Enabled = false;
          //             }
          //
          //             if (txtCodigoBarras.Text.Length == 13)
          //             {
          //                 System.Drawing.Graphics g = this.pictImageProduto.CreateGraphics();
          //                 g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control),
          //                     new Rectangle(0, 0, pictImageProduto.Width, pictImageProduto.Height));
          //                 CreateEan13();
          //                 ean13.Scale = (float)Convert.ToDecimal("0,8");//(float)Convert.ToDecimal(cboScale.Items[cboScale.SelectedIndex]);
          //                 ean13.DrawEan13Barcode(g, new System.Drawing.Point(0, 0));
          //                 g.Dispose();
          //             }
          //             else
          //                 pictImageProduto.Image = null;
          //
          //         }
          //     }
          // }
          // catch (Exception ex)
          // {
          //     MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
          // }


        }

        private void CreateEan13()
        {
            try
            {
                if (txtCodigoBarras.Text.Length == 13)
                {
                    ean13 = new Ean13();

                    for (int i = 0; i < 13; i++)
                    {
                        if (i < 3)
                        {
                            if (i == 0)
                                ean13.CountryCode = txtCodigoBarras.Text[i].ToString();
                            else
                                ean13.CountryCode += txtCodigoBarras.Text[i];
                        }
                        else if (i > 2 && i < 8)
                        {
                            if (i == 3)
                                ean13.ManufacturerCode = txtCodigoBarras.Text[i].ToString();
                            else
                                ean13.ManufacturerCode += txtCodigoBarras.Text[i];
                        }
                        else if (i < 12)
                        {
                            if (i == 8)
                                ean13.ProductCode = txtCodigoBarras.Text[i].ToString();
                            else
                                ean13.ProductCode += txtCodigoBarras.Text[i];
                        }
                        else
                            ean13.ChecksumDigit = txtCodigoBarras.Text[i].ToString();
                    }
                }
                else
                    pictImageProduto.Image = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            //if (txtCodigoBarras.Text.Length == 12)
//            if (txtCodigo.Text == "")
//                txtCodigoBarras_Leave(sender, e);
            //else
            //  pictureBox1.Image = null;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
                objD = null;
                cbFornecedor.SelectedIndex = -1;
            }
            else
            {
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                objD = null;
                cbFornecedor.SelectedIndex = -1;
            }

        }

        private void txtMargem_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecoCusto.Text != "" && txtMargem.Text != "")
                {
                    String x = "";
                    for (int i = 0; i <= txtPrecoCusto.Text.Length - 1; i++)
                    {
                        if ((txtPrecoCusto.Text[i] >= '0' &&
                        txtPrecoCusto.Text[i] <= '9') ||
                        txtPrecoCusto.Text[i] == ',')
                        {
                            x += txtPrecoCusto.Text[i];
                        }
                    }
                    txtPrecoCusto.Text = x;

                    x = "";
                    for (int i = 0; i <= txtPrecoVenda.Text.Length - 1; i++)
                    {
                        if ((txtPrecoVenda.Text[i] >= '0' &&
                        txtPrecoVenda.Text[i] <= '9') ||
                        txtPrecoVenda.Text[i] == ',')
                        {
                            x += txtPrecoVenda.Text[i];
                        }
                    }
                    txtPrecoVenda.Text = x;

                    Decimal custo = Decimal.Parse(txtPrecoCusto.Text);
                    Decimal margem = Decimal.Parse(txtMargem.Text);
                    Decimal res = custo + custo * margem / 100;
                    txtPrecoVenda.Text = res.ToString();
                    txtPrecoCusto.Text = txtPrecoCusto.Text;
                    if (txtPrecoCusto.Text != "")
                        txtPrecoCusto.Text = Convert.ToDecimal(txtPrecoCusto.Text).ToString("C");
                    if (txtPrecoVenda.Text != "")
                        txtPrecoVenda.Text = Convert.ToDecimal(txtPrecoVenda.Text).ToString("C");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtTamanho_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtAdicionaEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMargem_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtMargem.Text.Contains(','))
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

        private void txtComissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            //  (e.KeyChar != ',' && e.KeyChar != '.' &&
            //   e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            //    {
            //        e.KeyChar = (Char)0;
            //    }
            //    else
            //    {
            //        if (e.KeyChar == '.' || e.KeyChar == ',')
            //        {
            //            if (!txtComissao.Text.Contains(','))
            //            {
            //                e.KeyChar = ',';
            //            }
            //            else
            //            {
            //                e.KeyChar = (Char)0;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void btInserirFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Fornecedor frm = new CADASTROS.Fornecedor();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                objD = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    Contexto objD = new Contexto();
                    objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_razaoSocial", "for_tipo_fornecedor = 'Pessoa Jurídica'", "for_razaoSocial");
                    objD = null;
                    cbFornecedor.SelectedIndex = -1;
                }
                else
                {
                    Contexto objD = new Contexto();
                    objD.PreencheComboBox(cbFornecedor, "Fornecedores", "for_codigo", "for_nome", "for_tipo_fornecedor = 'Pessoa Física'", "for_nome");
                    objD = null;
                    cbFornecedor.SelectedIndex = -1;
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
                CADASTROS.Categorias frm = new CADASTROS.Categorias();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbCategoria, "Categoria", "cat_codigo", "cat_descricao", "", "cat_descricao");
                objD = null;

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
                CADASTROS.Grupo frm = new CADASTROS.Grupo();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbGrupo, "Grupo", "gru_codigo", "gru_descricao", "", "gru_descricao");
                objD = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btInserirSubgrupo_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Sub_Grupo frm = new CADASTROS.Sub_Grupo();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbSubgrupo, "SubGrupo", "sg_codigo", "sg_descricao", "", "sg_descricao");
                objD = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btInserirUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Unidades frm = new CADASTROS.Unidades();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbUnidade, "Unidades", "uni_codigo", "uni_descricao", "", "uni_descricao");
                objD = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CADASTROS.Marcas frm = new CADASTROS.Marcas();
                frm.ShowDialog();
                frm = null;
                Contexto objD = new Contexto();
                objD.PreencheComboBox(cbMarca, "Marcas", "mar_codigo", "mar_descricao", "", "mar_descricao");
                objD = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtComissao_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    String x = "";
            //    for (int i = 0; i <= txtPrecoCusto.Text.Length - 1; i++)
            //    {
            //        if ((txtPrecoCusto.Text[i] >= '0' &&
            //        txtPrecoCusto.Text[i] <= '9') ||
            //        txtPrecoCusto.Text[i] == ',')
            //        {
            //            x += txtPrecoCusto.Text[i];
            //        }
            //    }
            //    txtPrecoCusto.Text = x;

            //    x = "";
            //    for (int i = 0; i <= txtPrecoVenda.Text.Length - 1; i++)
            //    {
            //        if ((txtPrecoVenda.Text[i] >= '0' &&
            //        txtPrecoVenda.Text[i] <= '9') ||
            //        txtPrecoVenda.Text[i] == ',')
            //        {
            //            x += txtPrecoVenda.Text[i];
            //        }
            //    }
            //    txtPrecoVenda.Text = x;

            //    if (txtPrecoCusto.Text != "")
            //        txtPrecoCusto.Text = Convert.ToDecimal (txtPrecoCusto.Text).ToString("C");
            //    if (txtPrecoVenda.Text != "")
            //        txtPrecoVenda.Text = Convert.ToDecimal (txtPrecoVenda.Text).ToString("C");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        private void btReinserir_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 0)
                {
                    //Carregar os campos no objeto
                    carregaPropriedades();

                    if (objPro.pro_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                    {

                        ////Verificar se produto já existe
                        //objPro.localizarLeave(objPro.pro_nome, "pro_nome"); //Pesquisa por descrição, na coluna descrição
                        //if (objPro.pro_codigo != 0) // se o código retornar um número acima de 0, significa que o produto já está cadastrada
                        //    throw new Exception("Este produto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                        objPro.inserir();

                        proCompra = objPro.pro_codigo;
                        objPro.limpar();
                        limpar();
                        MessageBox.Show("Produto incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else //Alteração
                    {
                        //Verificar se o nome do produto alterado é igual ao de outro no banco
                        //ProdutosBLL objPro2 = new ProdutosBLL();
                        //objPro2.localizar(objPro.pro_nome, "pro_nome"); //Pesquisa por descrição, na coluna descrição
                        //if (objPro2.pro_codigo != objPro.pro_codigo && objPro2.pro_codigo>0) // se o código retornar um número acima de 0, significa que o produto já está cadastrada
                        //{
                        //    objPro2 = null;
                        //    throw new Exception("Este produto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                        //}
                        //objPro2 = null;

                        objPro.alterar();
                        objPro.limpar();
                        limpar();
                        MessageBox.Show("Produto alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else if (TabControl1.SelectedIndex == 1)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                objPro.limpar();
                limpar();
                txtCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (objPro.pro_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objPro.excluir();
                        objPro.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Produto excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um produto na aba 'Pesquisar', ou escolha um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este produto está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                    carregaPropriedades();
                else
                    limpar();
                objPro.localizarPrimeiroUltimo("primeiro");
                if (objPro.pro_codigo != 0)
                {
                    objPro.localizar(objPro.pro_codigo.ToString(), "pro_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objPro.localizarProxAnterior("anterior", 0);
                else
                    objPro.localizarProxAnterior("anterior", int.Parse(txtCodigo.Text));
                if (objPro.pro_codigo != 0)
                {
                    objPro.localizar(objPro.pro_codigo.ToString(), "pro_codigo ");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                if (txtCodigo.Text == "")
                    objPro.localizarProxAnterior("proximo", 0);
                else
                    objPro.localizarProxAnterior("proximo", int.Parse(txtCodigo.Text));
                if (objPro.pro_codigo != 0)
                {
                    objPro.localizar(objPro.pro_codigo.ToString(), "pro_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text != "")
                    carregaPropriedades();
                else
                    limpar();
                objPro.localizarPrimeiroUltimo("ultimo");
                if (objPro.pro_codigo != 0)
                {
                    objPro.localizar(objPro.pro_codigo.ToString(), "pro_codigo");
                    carregaCampos();
                    txtCodigo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabControl1.SelectedIndex == 0)
                {
                    //Carregar os campos no objeto
                    carregaPropriedades();

                    if (objPro.pro_codigo > 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                    {
                        objPro.inserir();
                        AtualizarTipoProduto(objPro.pro_codigo, cboTipoDeProduto.Text);
                        if (txtAdicionaEstoque.Text != String.Empty)
                        {
                            LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, txtProduto.Text, global.codUsuario, global.nomeUsuario, decimal.Parse(txtAdicionaEstoque.Text.ToString()), cboMotivo.Text);
                        }
                        if (txtEstoqueAtual.Text != String.Empty)
                        {
                            LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, txtProduto.Text, global.codUsuario, global.nomeUsuario, decimal.Parse(txtEstoqueAtual.Text.ToString()), cboMotivo.Text);
                        }
                        proCompra = objPro.pro_codigo;
                        objPro.limpar();
                        limpar();
                        MessageBox.Show("Produto incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else //Alteração
                    {
                        throw new Exception("");
                    }
                }
                else if (TabControl1.SelectedIndex == 1)
                {

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

        private void button1_Click_2(object sender, EventArgs e)
        {


        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gvPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewRow r = gvPesquisa.Rows[e.RowIndex];
            ////int Valor = 0;
            ////Valor = int.Parse(e.Value.ToString());
            //if (e.ColumnIndex == 6 && Convert.ToInt32(e.Value) == 0 )// --&& e.ColumnIndex == 7 )
            //{
            //    {

            //            DataGridViewRow ree = gvPesquisa.Rows[e.RowIndex];
            //            ree.DefaultCellStyle.BackColor = Color.Red;
            //            ree.DefaultCellStyle.ForeColor = Color.White;
            //            //ree.DefaultCellStyle.Font.Bold=T

            //    }
            //}
        }

        private void gvPesquisa_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try { 
            DataGridView dgv = sender as DataGridView;
            /* Pegando valor de uma celula do DataGridView */            
            int quantidade = int.Parse(dgv.Rows[e.RowIndex].Cells[3].Value.ToString());
            int quantidadeMin = int.Parse(dgv.Rows[e.RowIndex].Cells[4].Value.ToString());
            if (quantidade == 0)
            {
                /* Alterando cor do Fundo */
                // dgv.CurrentRow.DefaultCellStyle.BackColor = Color.;
                /* Alterando cor da fonte */
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
            }
            else if (quantidadeMin >= quantidade)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            }
            }
            catch
            {

            }
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void Produto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F5:
                    button3_Click(sender, e);
                    break;

                case Keys.F3:
                    button8_Click(sender, e);
                    break;

                case Keys.F6:
                    button7_Click(sender, e);
                    break;
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            txtEstoqueAtual.Enabled = true;
        }
        public void AtualizarTipoProduto(int ProdutoID, string TipoProduto)
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat(
                                "Update Produtos Set ",
                                         "  TipoProduto = @TipoProduto",
                                         " Where pro_codigo = @ProdutoID");
                cmd.Parameters.Add(new SqlParameter("@ProdutoID", SqlDbType.Int)).Value = ProdutoID;
                cmd.Parameters.Add(new SqlParameter("@TipoProduto", SqlDbType.VarChar)).Value = TipoProduto;
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void button2_Click_2(object sender, EventArgs e)
        {
            try{

                if (TabControl1.SelectedIndex == 0){

                    //Carregar os campos no objeto
                    carregaPropriedades();

                   // if (validaNCM())
                   // {

                        if (objPro.pro_codigo == 0) //Se o código for 0, significa que não é alteração, mas sim inserção 
                        {
                            ////Verificar se produto já existe
                            //objPro.localizarLeave(objPro.pro_nome, "pro_nome"); //Pesquisa por descrição, na coluna descrição
                            //if (objPro.pro_codigo != 0) // se o código retornar um número acima de 0, significa que o produto já está cadastrada
                            //    throw new Exception("Este produto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados

                            objPro.inserir();
                            //  int produtoID,DateTime DataLancamento,int ProdutoID,string DescricaoProduto,int UsuarioID,string NomeUsuario,int Quantidade,string Motivo

                            //Lancamento Estoque
                            if (txtAdicionaEstoque.Text != String.Empty)
                            {
                                LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, txtProduto.Text, global.codUsuario, global.nomeUsuario, decimal.Parse(txtAdicionaEstoque.Text.ToString()), cboMotivo.Text);
                            }
                            if (txtEstoqueAtual.Text != String.Empty)
                            {
                                LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, txtProduto.Text, global.codUsuario, global.nomeUsuario, decimal.Parse(txtEstoqueAtual.Text.ToString()), cboMotivo.Text);
                            }

                            AtualizarTipoProduto(objPro.pro_codigo, cboTipoDeProduto.Text.ToString());
                            AtualizarImagemProduto(objPro.pro_codigo, pictImageProduto);
                            proCompra = objPro.pro_codigo;
                            objPro.limpar();
                            limpar();
                            MessageBox.Show("Produto incluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        }
                        else //Alteração
                        {
                            //Verificar se o nome do produto alterado é igual ao de outro no banco
                            //ProdutosBLL objPro2 = new ProdutosBLL();
                            //objPro2.localizar(objPro.pro_nome, "pro_nome"); //Pesquisa por descrição, na coluna descrição
                            //if (objPro2.pro_codigo != objPro.pro_codigo && objPro2.pro_codigo>0) // se o código retornar um número acima de 0, significa que o produto já está cadastrada
                            //{
                            //    objPro2 = null;
                            //    throw new Exception("Este produto já existe no sistema"); // Se cair no throw automaticamente os comandos de inserção são cancelados
                            //}
                            //objPro2 = null;

                            objPro.alterar();
                            //Lancamento Estoque
                            if (txtAdicionaEstoque.Text != String.Empty)
                            {
                                LançamentoEstoqueProduto("ENTRADA", objPro.pro_codigo, DateTime.Now, txtProduto.Text, global.codUsuario, global.nomeUsuario, int.Parse(txtAdicionaEstoque.Text.ToString()), cboMotivo.Text);
                            }

                            AtualizarTipoProduto(objPro.pro_codigo, cboTipoDeProduto.Text.ToString());
                            AtualizarImagemProduto(objPro.pro_codigo, pictImageProduto);
                            objPro.limpar();
                            limpar();
                            MessageBox.Show("Produto alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }

                    //}
                   // else
                   // {
                   //     MessageBox.Show("NCM Inválido !");
                   // }

                }
                else if (TabControl1.SelectedIndex == 1)
                {

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
        private void AtualizarImagemProduto(int ID, PictureBox ImageProduto)
        {
            SqlCommand cmd = null;
            try
            {
                con = new Contexto();
                cmd = new SqlCommand();
                cmd.CommandText = String.Concat("Update Produtos Set Imagem = @ImageProduto Where pro_codigo = @ID ");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar)).Value = ID;
                if (ImageProduto.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    Bitmap bmpImage = new Bitmap(ImageProduto.Image);
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] data = ms.GetBuffer();
                    SqlParameter p = new SqlParameter("@ImageProduto", SqlDbType.Image);
                    p.Value = data;
                    cmd.Parameters.Add((object)p ?? DBNull.Value);
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@ImageProduto", SqlDbType.Image)).Value = (object)ImageProduto.Image ?? DBNull.Value;
                }
                con.ExecutaComando(cmd);
                cmd = null;
                con = null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                objPro.limpar();
                limpar();
                txtCodigo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (objPro.pro_codigo != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                    {

                        objPro.excluir();
                        objPro.limpar();
                        limpar();
                        carregaGrid();
                        MessageBox.Show("Produto excluído com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Favor selecionar um produto na aba 'Pesquisar', ou escolha um código válido para poder excluir", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException)
            {
                MessageBox.Show("Este produto está vinculado a alguma movimentação do sistema e não pode ser excluído", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictImageProduto_Click(object sender, EventArgs e)
        {
            try
            {
                var _with1 = openFileDialog1;

                _with1.Filter = ("Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;");
                _with1.FilterIndex = 4;
                //Resetar the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictImageProduto.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            // frmPanelProdutos frm = new frmPanelProdutos();
        }

        private void txtComissao_TextChanged(object sender, EventArgs e)
        {
            Moeda(ref txtComissao);
        }

        private void Moeda(ref TextBox txt)
        {
            string m = string.Empty;
            decimal v = 0;
            try
            {
                m = txt.Text.Replace(",", "").Replace(",", "");
                if (m.Equals(""))
                {
                    m = "";
                }
                m = m.PadLeft(3, '0');
                if (m.Length > 3 & m.Substring(0, 1) == "0")
                {
                    m = m.Substring(1, m.Length - 1);
                }
                v = Convert.ToDecimal(m) / 100;
                txt.Text = string.Format("{0:N}", v);
                txt.SelectionStart = txt.Text.Length;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Produto_Shown(object sender, EventArgs e)
        {
            LoadProduto();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            try
            {
                //if (cbProdutos.SelectedValue != null)
                //{
                //    DataTable tab = null;
                //    tab = CarregarDadosEstoque(int.Parse(cbProdutos.SelectedValue.ToString()));
                //    dgEstoque.DataSource = tab;
                //    tab = null;
                //}
                //else
                //{
                //    DataTable tab = null;
                //    tab = CarregarDadosEstoque(0);
                //    dgEstoque.DataSource = tab;
                //    tab = null;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtNCM_TextChanged(object sender, EventArgs e)
        {
            //AutoCompleteStringCollection dadosLista = new AutoCompleteStringCollection();
            //dadosLista.Add("Ricardo");
            //dadosLista.Add("Juliana");
            //dadosLista.Add("Marli");
            //dadosLista.Add("Maria");
            //dadosLista.Add("Fatima");
            //
            //txtNCM.AutoCompleteCustomSource = dadosLista;
            //txtNCM.AutoScrollOffset.

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void ttbcest_TextChanged(object sender, EventArgs e)
        {

        }

        private void ttbcst_TextChanged(object sender, EventArgs e)
        {

        }

        private void ttbcsosn_TextChanged(object sender, EventArgs e)
        {

        }

        private void ttbporcentagemtributo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivo.Text == "Estoque Inicial")
                txtAdicionaEstoque.Enabled = true;
        }

        private void TabControl1_StyleChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_4(object sender, EventArgs e)
        {
            One.RELATORIOS.frm_CodigoBarra c = new RELATORIOS.frm_CodigoBarra();
            c.ShowDialog();

        }

        private void txtPrecoVenda_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (!txtPrecoAtacado.Text.Contains(','))
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

        private void txtPrecoAtacado_Leave(object sender, EventArgs e)
        {
            
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e){
            carregaGrid();
        }
    }
}
