namespace One.Loja
{
    partial class frmDesconto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesconto));
            this.pnlDinheiro = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescontoPer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescontoValor = new System.Windows.Forms.TextBox();
            this.pnlDinheiro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDinheiro
            // 
            this.pnlDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDinheiro.Controls.Add(this.txtDescontoValor);
            this.pnlDinheiro.Controls.Add(this.label1);
            this.pnlDinheiro.Controls.Add(this.label8);
            this.pnlDinheiro.Controls.Add(this.txtDescontoPer);
            this.pnlDinheiro.Controls.Add(this.label2);
            this.pnlDinheiro.Controls.Add(this.pictureBox2);
            this.pnlDinheiro.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlDinheiro.Location = new System.Drawing.Point(12, 12);
            this.pnlDinheiro.Name = "pnlDinheiro";
            this.pnlDinheiro.Size = new System.Drawing.Size(543, 155);
            this.pnlDinheiro.TabIndex = 2;
            this.pnlDinheiro.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDinheiro_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(116, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Informe o desconto e aperte Enter";
            // 
            // txtDescontoPer
            // 
            this.txtDescontoPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescontoPer.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPer.Location = new System.Drawing.Point(350, 19);
            this.txtDescontoPer.Name = "txtDescontoPer";
            this.txtDescontoPer.Size = new System.Drawing.Size(188, 51);
            this.txtDescontoPer.TabIndex = 2;
            this.txtDescontoPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPer.TextChanged += new System.EventHandler(this.txtDescontoPer_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(161, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "% Desconto";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(155, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "R$ Desconto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDescontoValor
            // 
            this.txtDescontoValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescontoValor.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoValor.Location = new System.Drawing.Point(350, 76);
            this.txtDescontoValor.Name = "txtDescontoValor";
            this.txtDescontoValor.Size = new System.Drawing.Size(188, 51);
            this.txtDescontoValor.TabIndex = 8;
            this.txtDescontoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoValor.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // frmDesconto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 179);
            this.ControlBox = false;
            this.Controls.Add(this.pnlDinheiro);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmDesconto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "% Desconto";
            this.Load += new System.EventHandler(this.frmDesconto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDesconto_KeyDown);
            this.pnlDinheiro.ResumeLayout(false);
            this.pnlDinheiro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDinheiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.TextBox txtDescontoPer;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDescontoValor;
        private System.Windows.Forms.Label label1;
    }
}