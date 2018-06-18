namespace One.CADASTROS
{
	partial class Forma_Pagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forma_Pagamento));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.gvPesquisa = new System.Windows.Forms.DataGridView();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbMenu = new System.Windows.Forms.GroupBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btUltimo = new System.Windows.Forms.Button();
            this.btPrimeiro = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPesquisa)).BeginInit();
            this.gbMenu.SuspendLayout();
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
            this.TabControl1.Size = new System.Drawing.Size(459, 122);
            this.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl1.TabIndex = 37;
            this.TabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.label3);
            this.TabPage1.Controls.Add(this.Label23);
            this.TabPage1.Controls.Add(this.txtDescricao);
            this.TabPage1.Controls.Add(this.label10);
            this.TabPage1.Controls.Add(this.txtCodigo);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.label8);
            this.TabPage1.Controls.Add(this.btPrimeiro);
            this.TabPage1.Controls.Add(this.label7);
            this.TabPage1.Controls.Add(this.btAnterior);
            this.TabPage1.Controls.Add(this.label6);
            this.TabPage1.Controls.Add(this.btProximo);
            this.TabPage1.Controls.Add(this.btUltimo);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(451, 96);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Cadastro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 156;
            this.label3.Text = "Forma de Pagamento";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.Color.Red;
            this.Label23.Location = new System.Drawing.Point(574, 159);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(119, 14);
            this.Label23.TabIndex = 155;
            this.Label23.Text = "* Campos Obrigatórios";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(85, 33);
            this.txtDescricao.MaxLength = 150;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(195, 21);
            this.txtDescricao.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(73, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(3, 17);
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
            this.TabPage2.Size = new System.Drawing.Size(451, 96);
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
            this.gvPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPesquisa.Location = new System.Drawing.Point(6, 55);
            this.gvPesquisa.MultiSelect = false;
            this.gvPesquisa.Name = "gvPesquisa";
            this.gvPesquisa.ReadOnly = true;
            this.gvPesquisa.RowHeadersVisible = false;
            this.gvPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPesquisa.Size = new System.Drawing.Size(439, 43);
            this.gvPesquisa.TabIndex = 48;
            this.gvPesquisa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPesquisa_CellClick);
            this.gvPesquisa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPesquisa_CellDoubleClick);
            this.gvPesquisa.Sorted += new System.EventHandler(this.gvPesquisa_Sorted);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(6, 29);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(194, 20);
            this.txtPesquisar.TabIndex = 26;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label19.Location = new System.Drawing.Point(6, 11);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(162, 13);
            this.Label19.TabIndex = 44;
            this.Label19.Text = "Pesquisar Forma de Pagamento:";
            // 
            // btImprimir
            // 
            this.btImprimir.FlatAppearance.BorderSize = 0;
            this.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImprimir.ForeColor = System.Drawing.Color.Navy;
            this.btImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btImprimir.Image")));
            this.btImprimir.Location = new System.Drawing.Point(298, 15);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(31, 25);
            this.btImprimir.TabIndex = 51;
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Visible = false;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // gbMenu
            // 
            this.gbMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.gbMenu.Controls.Add(this.btSalvar);
            this.gbMenu.Controls.Add(this.label11);
            this.gbMenu.Controls.Add(this.btExcluir);
            this.gbMenu.Controls.Add(this.btCancelar);
            this.gbMenu.Controls.Add(this.btImprimir);
            this.gbMenu.Location = new System.Drawing.Point(2, -3);
            this.gbMenu.Name = "gbMenu";
            this.gbMenu.Size = new System.Drawing.Size(455, 63);
            this.gbMenu.TabIndex = 40;
            this.gbMenu.TabStop = false;
            this.gbMenu.Enter += new System.EventHandler(this.gbMenu_Enter);
            // 
            // btSalvar
            // 
            this.btSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSalvar.FlatAppearance.BorderSize = 0;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.ForeColor = System.Drawing.Color.White;
            this.btSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btSalvar.Image")));
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(105, 16);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(68, 43);
            this.btSalvar.TabIndex = 157;
            this.btSalvar.Text = "Atualizar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(291, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 62;
            this.label11.Text = "Imprimir";
            this.label11.Visible = false;
            // 
            // btExcluir
            // 
            this.btExcluir.FlatAppearance.BorderSize = 0;
            this.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.White;
            this.btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btExcluir.Image")));
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(224, 16);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(70, 43);
            this.btExcluir.TabIndex = 158;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(425, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 11);
            this.label10.TabIndex = 61;
            this.label10.Text = "Ultimo";
            this.label10.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.White;
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(167, 16);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(62, 43);
            this.btCancelar.TabIndex = 159;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(329, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 11);
            this.label8.TabIndex = 59;
            this.label8.Text = "Anterior";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(284, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 11);
            this.label7.TabIndex = 58;
            this.label7.Text = "Primeiro";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(378, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 11);
            this.label6.TabIndex = 57;
            this.label6.Text = "Próximo";
            this.label6.Visible = false;
            // 
            // btUltimo
            // 
            this.btUltimo.FlatAppearance.BorderSize = 0;
            this.btUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUltimo.ForeColor = System.Drawing.Color.Navy;
            this.btUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btUltimo.Image")));
            this.btUltimo.Location = new System.Drawing.Point(427, 33);
            this.btUltimo.Name = "btUltimo";
            this.btUltimo.Size = new System.Drawing.Size(30, 33);
            this.btUltimo.TabIndex = 39;
            this.btUltimo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUltimo.UseVisualStyleBackColor = true;
            this.btUltimo.Visible = false;
            this.btUltimo.Click += new System.EventHandler(this.btUltimo_Click_1);
            // 
            // btPrimeiro
            // 
            this.btPrimeiro.FlatAppearance.BorderSize = 0;
            this.btPrimeiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrimeiro.ForeColor = System.Drawing.Color.Navy;
            this.btPrimeiro.Image = ((System.Drawing.Image)(resources.GetObject("btPrimeiro.Image")));
            this.btPrimeiro.Location = new System.Drawing.Point(286, 33);
            this.btPrimeiro.Name = "btPrimeiro";
            this.btPrimeiro.Size = new System.Drawing.Size(30, 33);
            this.btPrimeiro.TabIndex = 36;
            this.btPrimeiro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btPrimeiro.UseVisualStyleBackColor = true;
            this.btPrimeiro.Visible = false;
            this.btPrimeiro.Click += new System.EventHandler(this.btPrimeiro_Click_1);
            // 
            // btProximo
            // 
            this.btProximo.FlatAppearance.BorderSize = 0;
            this.btProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProximo.ForeColor = System.Drawing.Color.Navy;
            this.btProximo.Image = ((System.Drawing.Image)(resources.GetObject("btProximo.Image")));
            this.btProximo.Location = new System.Drawing.Point(380, 33);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(30, 33);
            this.btProximo.TabIndex = 38;
            this.btProximo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Visible = false;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click_1);
            // 
            // btAnterior
            // 
            this.btAnterior.FlatAppearance.BorderSize = 0;
            this.btAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnterior.ForeColor = System.Drawing.Color.Navy;
            this.btAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btAnterior.Image")));
            this.btAnterior.Location = new System.Drawing.Point(331, 33);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(30, 33);
            this.btAnterior.TabIndex = 37;
            this.btAnterior.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Visible = false;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click_1);
            // 
            // Forma_Pagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(465, 193);
            this.Controls.Add(this.gbMenu);
            this.Controls.Add(this.TabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(481, 231);
            this.MaximizeBox = false;
            this.Name = "Forma_Pagamento";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "   Cadastro | Formas De Pagamento";
            this.Load += new System.EventHandler(this.Forma_Pagamento_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPesquisa)).EndInit();
            this.gbMenu.ResumeLayout(false);
            this.gbMenu.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.TextBox txtDescricao;
        internal System.Windows.Forms.TextBox txtCodigo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.DataGridView gvPesquisa;
        internal System.Windows.Forms.TextBox txtPesquisar;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.GroupBox gbMenu;
        internal System.Windows.Forms.Button btUltimo;
        internal System.Windows.Forms.Button btPrimeiro;
        internal System.Windows.Forms.Button btProximo;
        internal System.Windows.Forms.Button btAnterior;
        internal System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btSalvar;
        internal System.Windows.Forms.Button btExcluir;
        internal System.Windows.Forms.Button btCancelar;
	}
}