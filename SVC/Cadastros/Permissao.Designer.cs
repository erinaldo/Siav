namespace One.CADASTROS
{
    partial class Permissao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permissao));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.frm_Fechamento = new System.Windows.Forms.CheckBox();
            this.frm_CodigoBarra = new System.Windows.Forms.CheckBox();
            this.Marca = new System.Windows.Forms.CheckBox();
            this.Produto = new System.Windows.Forms.CheckBox();
            this.Vendas = new System.Windows.Forms.CheckBox();
            this.TrocaDeProdutos = new System.Windows.Forms.CheckBox();
            this.EntradaMercadoria = new System.Windows.Forms.CheckBox();
            this.ContasAReceber = new System.Windows.Forms.CheckBox();
            this.ContasAPagar = new System.Windows.Forms.CheckBox();
            this.Compras = new System.Windows.Forms.CheckBox();
            this.Usuario = new System.Windows.Forms.CheckBox();
            this.Fornecedor = new System.Windows.Forms.CheckBox();
            this.Cliente = new System.Windows.Forms.CheckBox();
            this.Unidades = new System.Windows.Forms.CheckBox();
            this.Subgrupo = new System.Windows.Forms.CheckBox();
            this.Permissa = new System.Windows.Forms.CheckBox();
            this.Grupo = new System.Windows.Forms.CheckBox();
            this.Forma_Pagamento = new System.Windows.Forms.CheckBox();
            this.Estado = new System.Windows.Forms.CheckBox();
            this.Empresa = new System.Windows.Forms.CheckBox();
            this.Cidade = new System.Windows.Forms.CheckBox();
            this.Categoria = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.gvPesquisa = new System.Windows.Forms.DataGridView();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPesquisa)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(2, 66);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(395, 122);
            this.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl1.TabIndex = 42;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.groupBox1);
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.txtDescricao);
            this.TabPage1.Controls.Add(this.txtCodigo);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(387, 96);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Cadastro";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.frm_Fechamento);
            this.groupBox1.Controls.Add(this.frm_CodigoBarra);
            this.groupBox1.Controls.Add(this.Marca);
            this.groupBox1.Controls.Add(this.Produto);
            this.groupBox1.Controls.Add(this.Vendas);
            this.groupBox1.Controls.Add(this.TrocaDeProdutos);
            this.groupBox1.Controls.Add(this.EntradaMercadoria);
            this.groupBox1.Controls.Add(this.ContasAReceber);
            this.groupBox1.Controls.Add(this.ContasAPagar);
            this.groupBox1.Controls.Add(this.Compras);
            this.groupBox1.Controls.Add(this.Usuario);
            this.groupBox1.Controls.Add(this.Fornecedor);
            this.groupBox1.Controls.Add(this.Cliente);
            this.groupBox1.Controls.Add(this.Unidades);
            this.groupBox1.Controls.Add(this.Subgrupo);
            this.groupBox1.Controls.Add(this.Permissa);
            this.groupBox1.Controls.Add(this.Grupo);
            this.groupBox1.Controls.Add(this.Forma_Pagamento);
            this.groupBox1.Controls.Add(this.Estado);
            this.groupBox1.Controls.Add(this.Empresa);
            this.groupBox1.Controls.Add(this.Cidade);
            this.groupBox1.Controls.Add(this.Categoria);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(662, 184);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telas";
            // 
            // frm_Fechamento
            // 
            this.frm_Fechamento.AutoSize = true;
            this.frm_Fechamento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm_Fechamento.Location = new System.Drawing.Point(124, 138);
            this.frm_Fechamento.Margin = new System.Windows.Forms.Padding(2);
            this.frm_Fechamento.Name = "frm_Fechamento";
            this.frm_Fechamento.Size = new System.Drawing.Size(130, 17);
            this.frm_Fechamento.TabIndex = 9;
            this.frm_Fechamento.Text = "Fechamento de Caixa";
            this.frm_Fechamento.UseVisualStyleBackColor = true;
            // 
            // frm_CodigoBarra
            // 
            this.frm_CodigoBarra.AutoSize = true;
            this.frm_CodigoBarra.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm_CodigoBarra.Location = new System.Drawing.Point(288, 85);
            this.frm_CodigoBarra.Margin = new System.Windows.Forms.Padding(2);
            this.frm_CodigoBarra.Name = "frm_CodigoBarra";
            this.frm_CodigoBarra.Size = new System.Drawing.Size(138, 17);
            this.frm_CodigoBarra.TabIndex = 12;
            this.frm_CodigoBarra.Text = "Gerar Código de Barras";
            this.frm_CodigoBarra.UseVisualStyleBackColor = true;
            // 
            // Marca
            // 
            this.Marca.AutoSize = true;
            this.Marca.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Marca.Location = new System.Drawing.Point(288, 138);
            this.Marca.Margin = new System.Windows.Forms.Padding(2);
            this.Marca.Name = "Marca";
            this.Marca.Size = new System.Drawing.Size(60, 17);
            this.Marca.TabIndex = 14;
            this.Marca.Text = "Marcas";
            this.Marca.UseVisualStyleBackColor = true;
            // 
            // Produto
            // 
            this.Produto.AutoSize = true;
            this.Produto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Produto.Location = new System.Drawing.Point(459, 58);
            this.Produto.Margin = new System.Windows.Forms.Padding(2);
            this.Produto.Name = "Produto";
            this.Produto.Size = new System.Drawing.Size(69, 17);
            this.Produto.TabIndex = 16;
            this.Produto.Text = "Produtos";
            this.Produto.UseVisualStyleBackColor = true;
            // 
            // Vendas
            // 
            this.Vendas.AutoSize = true;
            this.Vendas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vendas.Location = new System.Drawing.Point(585, 58);
            this.Vendas.Margin = new System.Windows.Forms.Padding(2);
            this.Vendas.Name = "Vendas";
            this.Vendas.Size = new System.Drawing.Size(61, 17);
            this.Vendas.TabIndex = 21;
            this.Vendas.Text = "Vendas";
            this.Vendas.UseVisualStyleBackColor = true;
            // 
            // TrocaDeProdutos
            // 
            this.TrocaDeProdutos.AutoSize = true;
            this.TrocaDeProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrocaDeProdutos.Location = new System.Drawing.Point(459, 112);
            this.TrocaDeProdutos.Margin = new System.Windows.Forms.Padding(2);
            this.TrocaDeProdutos.Name = "TrocaDeProdutos";
            this.TrocaDeProdutos.Size = new System.Drawing.Size(114, 17);
            this.TrocaDeProdutos.TabIndex = 18;
            this.TrocaDeProdutos.Text = "Troca de Produtos";
            this.TrocaDeProdutos.UseVisualStyleBackColor = true;
            // 
            // EntradaMercadoria
            // 
            this.EntradaMercadoria.AutoSize = true;
            this.EntradaMercadoria.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntradaMercadoria.Location = new System.Drawing.Point(124, 85);
            this.EntradaMercadoria.Margin = new System.Windows.Forms.Padding(2);
            this.EntradaMercadoria.Name = "EntradaMercadoria";
            this.EntradaMercadoria.Size = new System.Drawing.Size(135, 17);
            this.EntradaMercadoria.TabIndex = 7;
            this.EntradaMercadoria.Text = "Entrada de Mercadoria";
            this.EntradaMercadoria.UseVisualStyleBackColor = true;
            // 
            // ContasAReceber
            // 
            this.ContasAReceber.AutoSize = true;
            this.ContasAReceber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContasAReceber.Location = new System.Drawing.Point(124, 31);
            this.ContasAReceber.Margin = new System.Windows.Forms.Padding(2);
            this.ContasAReceber.Name = "ContasAReceber";
            this.ContasAReceber.Size = new System.Drawing.Size(113, 17);
            this.ContasAReceber.TabIndex = 5;
            this.ContasAReceber.Text = "Contas A Receber";
            this.ContasAReceber.UseVisualStyleBackColor = true;
            // 
            // ContasAPagar
            // 
            this.ContasAPagar.AutoSize = true;
            this.ContasAPagar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContasAPagar.Location = new System.Drawing.Point(6, 138);
            this.ContasAPagar.Margin = new System.Windows.Forms.Padding(2);
            this.ContasAPagar.Name = "ContasAPagar";
            this.ContasAPagar.Size = new System.Drawing.Size(101, 17);
            this.ContasAPagar.TabIndex = 4;
            this.ContasAPagar.Text = "Contas A Pagar";
            this.ContasAPagar.UseVisualStyleBackColor = true;
            // 
            // Compras
            // 
            this.Compras.AutoSize = true;
            this.Compras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compras.Location = new System.Drawing.Point(6, 112);
            this.Compras.Margin = new System.Windows.Forms.Padding(2);
            this.Compras.Name = "Compras";
            this.Compras.Size = new System.Drawing.Size(68, 17);
            this.Compras.TabIndex = 3;
            this.Compras.Text = "Compras";
            this.Compras.UseVisualStyleBackColor = true;
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.Location = new System.Drawing.Point(585, 31);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(67, 17);
            this.Usuario.TabIndex = 20;
            this.Usuario.Text = "Usuários";
            this.Usuario.UseVisualStyleBackColor = true;
            // 
            // Fornecedor
            // 
            this.Fornecedor.AutoSize = true;
            this.Fornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fornecedor.Location = new System.Drawing.Point(288, 58);
            this.Fornecedor.Margin = new System.Windows.Forms.Padding(2);
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.Size = new System.Drawing.Size(92, 17);
            this.Fornecedor.TabIndex = 11;
            this.Fornecedor.Text = "Fornecedores";
            this.Fornecedor.UseVisualStyleBackColor = true;
            // 
            // Cliente
            // 
            this.Cliente.AutoSize = true;
            this.Cliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cliente.Location = new System.Drawing.Point(6, 85);
            this.Cliente.Margin = new System.Windows.Forms.Padding(2);
            this.Cliente.Name = "Cliente";
            this.Cliente.Size = new System.Drawing.Size(64, 17);
            this.Cliente.TabIndex = 2;
            this.Cliente.Text = "Clientes";
            this.Cliente.UseVisualStyleBackColor = true;
            // 
            // Unidades
            // 
            this.Unidades.AutoSize = true;
            this.Unidades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unidades.Location = new System.Drawing.Point(459, 138);
            this.Unidades.Margin = new System.Windows.Forms.Padding(2);
            this.Unidades.Name = "Unidades";
            this.Unidades.Size = new System.Drawing.Size(70, 17);
            this.Unidades.TabIndex = 19;
            this.Unidades.Text = "Unidades";
            this.Unidades.UseVisualStyleBackColor = true;
            // 
            // Subgrupo
            // 
            this.Subgrupo.AutoSize = true;
            this.Subgrupo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subgrupo.Location = new System.Drawing.Point(459, 85);
            this.Subgrupo.Margin = new System.Windows.Forms.Padding(2);
            this.Subgrupo.Name = "Subgrupo";
            this.Subgrupo.Size = new System.Drawing.Size(72, 17);
            this.Subgrupo.TabIndex = 17;
            this.Subgrupo.Text = "Subgrupo";
            this.Subgrupo.UseVisualStyleBackColor = true;
            // 
            // Permissa
            // 
            this.Permissa.AutoSize = true;
            this.Permissa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Permissa.Location = new System.Drawing.Point(459, 31);
            this.Permissa.Margin = new System.Windows.Forms.Padding(2);
            this.Permissa.Name = "Permissa";
            this.Permissa.Size = new System.Drawing.Size(74, 17);
            this.Permissa.TabIndex = 15;
            this.Permissa.Text = "Permissão";
            this.Permissa.UseVisualStyleBackColor = true;
            // 
            // Grupo
            // 
            this.Grupo.AutoSize = true;
            this.Grupo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(288, 112);
            this.Grupo.Margin = new System.Windows.Forms.Padding(2);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(55, 17);
            this.Grupo.TabIndex = 13;
            this.Grupo.Text = "Grupo";
            this.Grupo.UseVisualStyleBackColor = true;
            // 
            // Forma_Pagamento
            // 
            this.Forma_Pagamento.AutoSize = true;
            this.Forma_Pagamento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forma_Pagamento.Location = new System.Drawing.Point(288, 31);
            this.Forma_Pagamento.Margin = new System.Windows.Forms.Padding(2);
            this.Forma_Pagamento.Name = "Forma_Pagamento";
            this.Forma_Pagamento.Size = new System.Drawing.Size(128, 17);
            this.Forma_Pagamento.TabIndex = 10;
            this.Forma_Pagamento.Text = "Forma de Pagamento";
            this.Forma_Pagamento.UseVisualStyleBackColor = true;
            // 
            // Estado
            // 
            this.Estado.AutoSize = true;
            this.Estado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estado.Location = new System.Drawing.Point(124, 112);
            this.Estado.Margin = new System.Windows.Forms.Padding(2);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(59, 17);
            this.Estado.TabIndex = 8;
            this.Estado.Text = "Estado";
            this.Estado.UseVisualStyleBackColor = true;
            // 
            // Empresa
            // 
            this.Empresa.AutoSize = true;
            this.Empresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Empresa.Location = new System.Drawing.Point(124, 58);
            this.Empresa.Margin = new System.Windows.Forms.Padding(2);
            this.Empresa.Name = "Empresa";
            this.Empresa.Size = new System.Drawing.Size(67, 17);
            this.Empresa.TabIndex = 6;
            this.Empresa.Text = "Empresa";
            this.Empresa.UseVisualStyleBackColor = true;
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cidade.Location = new System.Drawing.Point(6, 58);
            this.Cidade.Margin = new System.Windows.Forms.Padding(2);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(59, 17);
            this.Cidade.TabIndex = 1;
            this.Cidade.Text = "Cidade";
            this.Cidade.UseVisualStyleBackColor = true;
            // 
            // Categoria
            // 
            this.Categoria.AutoSize = true;
            this.Categoria.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categoria.Location = new System.Drawing.Point(6, 31);
            this.Categoria.Margin = new System.Windows.Forms.Padding(2);
            this.Categoria.Name = "Categoria";
            this.Categoria.Size = new System.Drawing.Size(73, 17);
            this.Categoria.TabIndex = 0;
            this.Categoria.Text = "Categoria";
            this.Categoria.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Permissão";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(6, 63);
            this.txtDescricao.MaxLength = 50;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(182, 21);
            this.txtDescricao.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(73, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 13);
            this.Label1.TabIndex = 134;
            this.Label1.Text = "Código";
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage2.Controls.Add(this.gvPesquisa);
            this.TabPage2.Controls.Add(this.txtPesquisar);
            this.TabPage2.Controls.Add(this.Label19);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(387, 96);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Pesquisar";
            // 
            // gvPesquisa
            // 
            this.gvPesquisa.AllowUserToAddRows = false;
            this.gvPesquisa.AllowUserToDeleteRows = false;
            this.gvPesquisa.AllowUserToOrderColumns = true;
            this.gvPesquisa.AllowUserToResizeColumns = false;
            this.gvPesquisa.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.gvPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPesquisa.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPesquisa.Location = new System.Drawing.Point(6, 25);
            this.gvPesquisa.MultiSelect = false;
            this.gvPesquisa.Name = "gvPesquisa";
            this.gvPesquisa.ReadOnly = true;
            this.gvPesquisa.RowHeadersVisible = false;
            this.gvPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPesquisa.Size = new System.Drawing.Size(375, 63);
            this.gvPesquisa.TabIndex = 48;
            this.gvPesquisa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPesquisa_CellClick);
            this.gvPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPesquisa_CellDoubleClick);
            this.gvPesquisa.Sorted += new System.EventHandler(this.gvPesquisa_Sorted);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(9, 25);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(64, 21);
            this.txtPesquisar.TabIndex = 26;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(6, 9);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(108, 13);
            this.Label19.TabIndex = 44;
            this.Label19.Text = "Pesquisar Permissão:";
            // 
            // btImprimir
            // 
            this.btImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btImprimir.FlatAppearance.BorderSize = 0;
            this.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btImprimir.ForeColor = System.Drawing.Color.White;
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.Location = new System.Drawing.Point(295, 20);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(49, 27);
            this.btImprimir.TabIndex = 53;
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImprimir.UseVisualStyleBackColor = false;
            this.btImprimir.Visible = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Controls.Add(this.btSalvar);
            this.groupBox2.Controls.Add(this.btExcluir);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btCancelar);
            this.groupBox2.Controls.Add(this.btImprimir);
            this.groupBox2.Location = new System.Drawing.Point(-6, -15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 63);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.Color.Transparent;
            this.btSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSalvar.FlatAppearance.BorderSize = 0;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.ForeColor = System.Drawing.Color.White;
            this.btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btSalvar.Image")));
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(40, 14);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(76, 43);
            this.btSalvar.TabIndex = 159;
            this.btSalvar.Text = "Atualizar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.Color.Transparent;
            this.btExcluir.FlatAppearance.BorderSize = 0;
            this.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.White;
            this.btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btExcluir.Image")));
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(218, 17);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(78, 43);
            this.btExcluir.TabIndex = 160;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(302, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 59;
            this.label11.Text = "Imprimir";
            this.label11.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(138, 14);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(70, 43);
            this.btCancelar.TabIndex = 161;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Permissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 200);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Permissao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   Cadastro | Controle De Acesso";
            this.Load += new System.EventHandler(this.Permissao_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPesquisa)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtDescricao;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Unidades;
        private System.Windows.Forms.CheckBox Subgrupo;
        private System.Windows.Forms.CheckBox Permissa;
        private System.Windows.Forms.CheckBox Grupo;
        private System.Windows.Forms.CheckBox Forma_Pagamento;
        private System.Windows.Forms.CheckBox Estado;
        private System.Windows.Forms.CheckBox Empresa;
        private System.Windows.Forms.CheckBox Cidade;
        private System.Windows.Forms.CheckBox Categoria;
        private System.Windows.Forms.CheckBox Cliente;
        private System.Windows.Forms.CheckBox Fornecedor;
        private System.Windows.Forms.CheckBox Usuario;
        private System.Windows.Forms.CheckBox Compras;
        private System.Windows.Forms.CheckBox EntradaMercadoria;
        private System.Windows.Forms.CheckBox ContasAReceber;
        private System.Windows.Forms.CheckBox ContasAPagar;
        private System.Windows.Forms.CheckBox TrocaDeProdutos;
        private System.Windows.Forms.CheckBox Vendas;
        private System.Windows.Forms.CheckBox Produto;
        private System.Windows.Forms.CheckBox Marca;
        private System.Windows.Forms.CheckBox frm_CodigoBarra;
        private System.Windows.Forms.CheckBox frm_Fechamento;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.DataGridView gvPesquisa;
        internal System.Windows.Forms.TextBox txtPesquisar;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Button btSalvar;
        internal System.Windows.Forms.Button btExcluir;
        internal System.Windows.Forms.Button btCancelar;
    }
}