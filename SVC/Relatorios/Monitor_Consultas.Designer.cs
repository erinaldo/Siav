namespace One
{
    partial class Monitor_Consultas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConsultarCliente = new System.Windows.Forms.Button();
            this.btnConsultarForncedor = new System.Windows.Forms.Button();
            this.btnConsultarPosicaoDeEstoque = new System.Windows.Forms.Button();
            this.BtnConsultarCumpo = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnContasaPagar = new System.Windows.Forms.Button();
            this.btnContasaReceber = new System.Windows.Forms.Button();
            this.gbxPeriodo = new System.Windows.Forms.GroupBox();
            this.btnPesquisarPeriodo = new System.Windows.Forms.Button();
            this.txtDtFinal = new System.Windows.Forms.MaskedTextBox();
            this.txtDtInicial = new System.Windows.Forms.MaskedTextBox();
            this.gbxCupomVenda = new System.Windows.Forms.GroupBox();
            this.btnPesquisarCupom = new System.Windows.Forms.Button();
            this.txtNumeroVenda = new System.Windows.Forms.TextBox();
            this.ctarec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxPeriodo.SuspendLayout();
            this.gbxCupomVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(156, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(867, 458);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnConsultarCliente
            // 
            this.btnConsultarCliente.Location = new System.Drawing.Point(12, 54);
            this.btnConsultarCliente.Name = "btnConsultarCliente";
            this.btnConsultarCliente.Size = new System.Drawing.Size(118, 23);
            this.btnConsultarCliente.TabIndex = 2;
            this.btnConsultarCliente.Text = "Clientes";
            this.btnConsultarCliente.UseVisualStyleBackColor = true;
            this.btnConsultarCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConsultarForncedor
            // 
            this.btnConsultarForncedor.Location = new System.Drawing.Point(12, 92);
            this.btnConsultarForncedor.Name = "btnConsultarForncedor";
            this.btnConsultarForncedor.Size = new System.Drawing.Size(118, 23);
            this.btnConsultarForncedor.TabIndex = 3;
            this.btnConsultarForncedor.Text = "Fornecedores";
            this.btnConsultarForncedor.UseVisualStyleBackColor = true;
            this.btnConsultarForncedor.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnConsultarPosicaoDeEstoque
            // 
            this.btnConsultarPosicaoDeEstoque.Location = new System.Drawing.Point(12, 133);
            this.btnConsultarPosicaoDeEstoque.Name = "btnConsultarPosicaoDeEstoque";
            this.btnConsultarPosicaoDeEstoque.Size = new System.Drawing.Size(118, 23);
            this.btnConsultarPosicaoDeEstoque.TabIndex = 4;
            this.btnConsultarPosicaoDeEstoque.Text = "Posição de Produtos";
            this.btnConsultarPosicaoDeEstoque.UseVisualStyleBackColor = true;
            this.btnConsultarPosicaoDeEstoque.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnConsultarCumpo
            // 
            this.BtnConsultarCumpo.Location = new System.Drawing.Point(12, 172);
            this.BtnConsultarCumpo.Name = "BtnConsultarCumpo";
            this.BtnConsultarCumpo.Size = new System.Drawing.Size(118, 23);
            this.BtnConsultarCumpo.TabIndex = 5;
            this.BtnConsultarCumpo.Text = "Cumpo Vendas";
            this.BtnConsultarCumpo.UseVisualStyleBackColor = true;
            this.BtnConsultarCumpo.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.Location = new System.Drawing.Point(12, 215);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(118, 23);
            this.btnCompras.TabIndex = 6;
            this.btnCompras.Text = "Compras";
            this.btnCompras.UseVisualStyleBackColor = true;
            // 
            // btnContasaPagar
            // 
            this.btnContasaPagar.Location = new System.Drawing.Point(12, 259);
            this.btnContasaPagar.Name = "btnContasaPagar";
            this.btnContasaPagar.Size = new System.Drawing.Size(118, 23);
            this.btnContasaPagar.TabIndex = 7;
            this.btnContasaPagar.Text = "Contas a pagar";
            this.btnContasaPagar.UseVisualStyleBackColor = true;
            this.btnContasaPagar.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnContasaReceber
            // 
            this.btnContasaReceber.Location = new System.Drawing.Point(12, 300);
            this.btnContasaReceber.Name = "btnContasaReceber";
            this.btnContasaReceber.Size = new System.Drawing.Size(118, 23);
            this.btnContasaReceber.TabIndex = 8;
            this.btnContasaReceber.Text = "Contas a receber";
            this.btnContasaReceber.UseVisualStyleBackColor = true;
            this.btnContasaReceber.Click += new System.EventHandler(this.btnContasaReceber_Click);
            // 
            // gbxPeriodo
            // 
            this.gbxPeriodo.Controls.Add(this.btnPesquisarPeriodo);
            this.gbxPeriodo.Controls.Add(this.txtDtFinal);
            this.gbxPeriodo.Controls.Add(this.txtDtInicial);
            this.gbxPeriodo.Location = new System.Drawing.Point(156, -1);
            this.gbxPeriodo.Name = "gbxPeriodo";
            this.gbxPeriodo.Size = new System.Drawing.Size(239, 43);
            this.gbxPeriodo.TabIndex = 9;
            this.gbxPeriodo.TabStop = false;
            this.gbxPeriodo.Text = "Periodo";
            this.gbxPeriodo.Visible = false;
            // 
            // btnPesquisarPeriodo
            // 
            this.btnPesquisarPeriodo.Location = new System.Drawing.Point(186, 17);
            this.btnPesquisarPeriodo.Name = "btnPesquisarPeriodo";
            this.btnPesquisarPeriodo.Size = new System.Drawing.Size(34, 20);
            this.btnPesquisarPeriodo.TabIndex = 2;
            this.btnPesquisarPeriodo.Text = ">>";
            this.btnPesquisarPeriodo.UseVisualStyleBackColor = true;
            this.btnPesquisarPeriodo.Visible = false;
            this.btnPesquisarPeriodo.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtDtFinal
            // 
            this.txtDtFinal.Location = new System.Drawing.Point(101, 17);
            this.txtDtFinal.Mask = "00/00/0000";
            this.txtDtFinal.Name = "txtDtFinal";
            this.txtDtFinal.Size = new System.Drawing.Size(78, 20);
            this.txtDtFinal.TabIndex = 1;
            this.txtDtFinal.ValidatingType = typeof(System.DateTime);
            // 
            // txtDtInicial
            // 
            this.txtDtInicial.Location = new System.Drawing.Point(6, 17);
            this.txtDtInicial.Mask = "00/00/0000";
            this.txtDtInicial.Name = "txtDtInicial";
            this.txtDtInicial.Size = new System.Drawing.Size(78, 20);
            this.txtDtInicial.TabIndex = 0;
            this.txtDtInicial.ValidatingType = typeof(System.DateTime);
            // 
            // gbxCupomVenda
            // 
            this.gbxCupomVenda.Controls.Add(this.btnPesquisarCupom);
            this.gbxCupomVenda.Controls.Add(this.txtNumeroVenda);
            this.gbxCupomVenda.Location = new System.Drawing.Point(401, -1);
            this.gbxCupomVenda.Name = "gbxCupomVenda";
            this.gbxCupomVenda.Size = new System.Drawing.Size(239, 43);
            this.gbxCupomVenda.TabIndex = 10;
            this.gbxCupomVenda.TabStop = false;
            this.gbxCupomVenda.Text = "Numero Cupom ";
            this.gbxCupomVenda.Visible = false;
            // 
            // btnPesquisarCupom
            // 
            this.btnPesquisarCupom.Location = new System.Drawing.Point(199, 16);
            this.btnPesquisarCupom.Name = "btnPesquisarCupom";
            this.btnPesquisarCupom.Size = new System.Drawing.Size(34, 20);
            this.btnPesquisarCupom.TabIndex = 3;
            this.btnPesquisarCupom.Text = ">>";
            this.btnPesquisarCupom.UseVisualStyleBackColor = true;
            this.btnPesquisarCupom.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtNumeroVenda
            // 
            this.txtNumeroVenda.Location = new System.Drawing.Point(6, 17);
            this.txtNumeroVenda.Name = "txtNumeroVenda";
            this.txtNumeroVenda.Size = new System.Drawing.Size(173, 20);
            this.txtNumeroVenda.TabIndex = 0;
            // 
            // ctarec
            // 
            this.ctarec.AutoSize = true;
            this.ctarec.Location = new System.Drawing.Point(676, 15);
            this.ctarec.Name = "ctarec";
            this.ctarec.Size = new System.Drawing.Size(81, 13);
            this.ctarec.TabIndex = 11;
            this.ctarec.Text = "contasareceber";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 506);
            this.Controls.Add(this.ctarec);
            this.Controls.Add(this.gbxCupomVenda);
            this.Controls.Add(this.gbxPeriodo);
            this.Controls.Add(this.btnContasaReceber);
            this.Controls.Add(this.btnContasaPagar);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.BtnConsultarCumpo);
            this.Controls.Add(this.btnConsultarPosicaoDeEstoque);
            this.Controls.Add(this.btnConsultarForncedor);
            this.Controls.Add(this.btnConsultarCliente);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxPeriodo.ResumeLayout(false);
            this.gbxPeriodo.PerformLayout();
            this.gbxCupomVenda.ResumeLayout(false);
            this.gbxCupomVenda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConsultarCliente;
        private System.Windows.Forms.Button btnConsultarForncedor;
        private System.Windows.Forms.Button btnConsultarPosicaoDeEstoque;
        private System.Windows.Forms.Button BtnConsultarCumpo;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnContasaPagar;
        private System.Windows.Forms.Button btnContasaReceber;
        private System.Windows.Forms.GroupBox gbxPeriodo;
        private System.Windows.Forms.MaskedTextBox txtDtInicial;
        private System.Windows.Forms.MaskedTextBox txtDtFinal;
        private System.Windows.Forms.Button btnPesquisarPeriodo;
        private System.Windows.Forms.GroupBox gbxCupomVenda;
        private System.Windows.Forms.TextBox txtNumeroVenda;
        private System.Windows.Forms.Button btnPesquisarCupom;
        private System.Windows.Forms.Label ctarec;

    }
}