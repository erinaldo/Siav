namespace One.Cadastros
{
    partial class Configuracao
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.emp_reducao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.emp_tributos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.acbr_path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trend_cnpj = new System.Windows.Forms.TextBox();
            this.trend_codigo_vinculacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.check_vendedor_final = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(190, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 310);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.check_vendedor_final);
            this.tabPage3.Controls.Add(this.emp_reducao);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.emp_tributos);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(471, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Empresa";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // emp_reducao
            // 
            this.emp_reducao.Location = new System.Drawing.Point(6, 91);
            this.emp_reducao.Name = "emp_reducao";
            this.emp_reducao.Size = new System.Drawing.Size(313, 22);
            this.emp_reducao.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Redução ";
            // 
            // emp_tributos
            // 
            this.emp_tributos.Location = new System.Drawing.Point(6, 36);
            this.emp_tributos.Name = "emp_tributos";
            this.emp_tributos.Size = new System.Drawing.Size(313, 22);
            this.emp_tributos.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "% Tributos";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.acbr_path);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(471, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ACBr ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // acbr_path
            // 
            this.acbr_path.Location = new System.Drawing.Point(3, 35);
            this.acbr_path.Name = "acbr_path";
            this.acbr_path.Size = new System.Drawing.Size(345, 22);
            this.acbr_path.TabIndex = 2;
            this.acbr_path.TextChanged += new System.EventHandler(this.acbr_path_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Pasta ACBR";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.DoubleClick += new System.EventHandler(this.label5_DoubleClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 29);
            this.button2.TabIndex = 0;
            this.button2.Text = "Localizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trend_cnpj);
            this.tabPage2.Controls.Add(this.trend_codigo_vinculacao);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(471, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trend";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trend_cnpj
            // 
            this.trend_cnpj.Location = new System.Drawing.Point(6, 44);
            this.trend_cnpj.Name = "trend_cnpj";
            this.trend_cnpj.Size = new System.Drawing.Size(454, 22);
            this.trend_cnpj.TabIndex = 2;
            // 
            // trend_codigo_vinculacao
            // 
            this.trend_codigo_vinculacao.Location = new System.Drawing.Point(6, 103);
            this.trend_codigo_vinculacao.Multiline = true;
            this.trend_codigo_vinculacao.Name = "trend_codigo_vinculacao";
            this.trend_codigo_vinculacao.Size = new System.Drawing.Size(454, 108);
            this.trend_codigo_vinculacao.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código de Vinculação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "CNPJ Software House";
            // 
            // check_vendedor_final
            // 
            this.check_vendedor_final.AutoSize = true;
            this.check_vendedor_final.Location = new System.Drawing.Point(6, 132);
            this.check_vendedor_final.Name = "check_vendedor_final";
            this.check_vendedor_final.Size = new System.Drawing.Size(212, 21);
            this.check_vendedor_final.TabIndex = 8;
            this.check_vendedor_final.TabStop = true;
            this.check_vendedor_final.Text = "Selecionar Vendedor no final";
            this.check_vendedor_final.UseVisualStyleBackColor = true;
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Configuracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracao";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox trend_cnpj;
        private System.Windows.Forms.TextBox trend_codigo_vinculacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox emp_reducao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emp_tributos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox acbr_path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton check_vendedor_final;

    }
}