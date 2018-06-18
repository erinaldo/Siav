namespace One.RELATORIOS
{
    partial class frm_CodigoBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_CodigoBarra));
            this.gbEtiquetas = new System.Windows.Forms.GroupBox();
            this.txtProdutos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btRetirar = new System.Windows.Forms.Button();
            this.dgEtiquetas = new System.Windows.Forms.DataGridView();
            this.pro_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btInserir = new System.Windows.Forms.Button();
            this.lbProdutos = new System.Windows.Forms.ListBox();
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btGerar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbEtiquetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEtiquetas)).BeginInit();
            this.gbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEtiquetas
            // 
            this.gbEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEtiquetas.Controls.Add(this.txtProdutos);
            this.gbEtiquetas.Controls.Add(this.label2);
            this.gbEtiquetas.Controls.Add(this.label1);
            this.gbEtiquetas.Controls.Add(this.nudQuantidade);
            this.gbEtiquetas.Controls.Add(this.btRetirar);
            this.gbEtiquetas.Controls.Add(this.dgEtiquetas);
            this.gbEtiquetas.Controls.Add(this.btInserir);
            this.gbEtiquetas.Controls.Add(this.lbProdutos);
            this.gbEtiquetas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEtiquetas.Location = new System.Drawing.Point(8, 64);
            this.gbEtiquetas.Margin = new System.Windows.Forms.Padding(2);
            this.gbEtiquetas.Name = "gbEtiquetas";
            this.gbEtiquetas.Padding = new System.Windows.Forms.Padding(2);
            this.gbEtiquetas.Size = new System.Drawing.Size(881, 345);
            this.gbEtiquetas.TabIndex = 0;
            this.gbEtiquetas.TabStop = false;
            this.gbEtiquetas.Text = "Gerar Etiquetas";
            // 
            // txtProdutos
            // 
            this.txtProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdutos.Location = new System.Drawing.Point(6, 37);
            this.txtProdutos.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdutos.Name = "txtProdutos";
            this.txtProdutos.Size = new System.Drawing.Size(219, 21);
            this.txtProdutos.TabIndex = 7;
            this.txtProdutos.TextChanged += new System.EventHandler(this.txtProdutos_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Buscar Produtos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantidade";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantidade.Location = new System.Drawing.Point(236, 92);
            this.nudQuantidade.Margin = new System.Windows.Forms.Padding(2);
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(56, 21);
            this.nudQuantidade.TabIndex = 1;
            // 
            // btRetirar
            // 
            this.btRetirar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetirar.Location = new System.Drawing.Point(236, 159);
            this.btRetirar.Margin = new System.Windows.Forms.Padding(2);
            this.btRetirar.Name = "btRetirar";
            this.btRetirar.Size = new System.Drawing.Size(56, 34);
            this.btRetirar.TabIndex = 3;
            this.btRetirar.Text = "<<";
            this.btRetirar.UseVisualStyleBackColor = true;
            this.btRetirar.Click += new System.EventHandler(this.btRetirar_Click);
            // 
            // dgEtiquetas
            // 
            this.dgEtiquetas.AllowUserToAddRows = false;
            this.dgEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEtiquetas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgEtiquetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEtiquetas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pro_codigo,
            this.pro_nome,
            this.pro_quantidade});
            this.dgEtiquetas.Location = new System.Drawing.Point(301, 18);
            this.dgEtiquetas.Margin = new System.Windows.Forms.Padding(2);
            this.dgEtiquetas.Name = "dgEtiquetas";
            this.dgEtiquetas.RowTemplate.Height = 24;
            this.dgEtiquetas.Size = new System.Drawing.Size(576, 317);
            this.dgEtiquetas.TabIndex = 4;
            // 
            // pro_codigo
            // 
            this.pro_codigo.HeaderText = "Código do Produto";
            this.pro_codigo.Name = "pro_codigo";
            this.pro_codigo.ReadOnly = true;
            this.pro_codigo.Width = 125;
            // 
            // pro_nome
            // 
            this.pro_nome.HeaderText = "Produto";
            this.pro_nome.Name = "pro_nome";
            this.pro_nome.ReadOnly = true;
            this.pro_nome.Width = 300;
            // 
            // pro_quantidade
            // 
            this.pro_quantidade.HeaderText = "Quantidade";
            this.pro_quantidade.Name = "pro_quantidade";
            this.pro_quantidade.ReadOnly = true;
            this.pro_quantidade.Width = 93;
            // 
            // btInserir
            // 
            this.btInserir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInserir.Location = new System.Drawing.Point(236, 120);
            this.btInserir.Margin = new System.Windows.Forms.Padding(2);
            this.btInserir.Name = "btInserir";
            this.btInserir.Size = new System.Drawing.Size(56, 34);
            this.btInserir.TabIndex = 2;
            this.btInserir.Text = ">>";
            this.btInserir.UseVisualStyleBackColor = true;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // lbProdutos
            // 
            this.lbProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProdutos.FormattingEnabled = true;
            this.lbProdutos.Location = new System.Drawing.Point(5, 74);
            this.lbProdutos.Margin = new System.Windows.Forms.Padding(2);
            this.lbProdutos.Name = "lbProdutos";
            this.lbProdutos.Size = new System.Drawing.Size(220, 264);
            this.lbProdutos.TabIndex = 0;
            this.lbProdutos.SelectedIndexChanged += new System.EventHandler(this.lbProdutos_SelectedIndexChanged);
            // 
            // gbMenu
            // 
            this.gbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.gbMenu.Controls.Add(this.label11);
            this.gbMenu.Controls.Add(this.btGerar);
            this.gbMenu.Location = new System.Drawing.Point(-11, -9);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(921, 55);
            this.gbMenu.TabIndex = 45;
            this.gbMenu.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(839, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 56;
            this.label11.Text = "Imprimir";
            // 
            // btGerar
            // 
            this.btGerar.FlatAppearance.BorderSize = 0;
            this.btGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGerar.ForeColor = System.Drawing.Color.Navy;
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.Location = new System.Drawing.Point(850, 15);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(24, 25);
            this.btGerar.TabIndex = 32;
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btGerar, "Gerar Etiquetas");
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // frm_CodigoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 408);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.gbEtiquetas);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_CodigoBarra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Código de Barra";
            this.Load += new System.EventHandler(this.frm_CodigoBarra_Load);
            this.gbEtiquetas.ResumeLayout(false);
            this.gbEtiquetas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEtiquetas)).EndInit();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEtiquetas;
        private System.Windows.Forms.DataGridView dgEtiquetas;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.ListBox lbProdutos;
        private System.Windows.Forms.Button btRetirar;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox gbMenu;
        internal System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_quantidade;
        private System.Windows.Forms.Label label11;
    }
}