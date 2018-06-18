namespace One
{
    partial class Primeiro_Acesso
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_cnpj = new System.Windows.Forms.MaskedTextBox();
            this.txt_senha2 = new System.Windows.Forms.TextBox();
            this.lbl_confirmar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.label_campo2 = new System.Windows.Forms.Label();
            this.label_campo1 = new System.Windows.Forms.Label();
            this.label_descricao = new System.Windows.Forms.Label();
            this.label_titulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txt_cnpj);
            this.panel1.Controls.Add(this.txt_senha2);
            this.panel1.Controls.Add(this.lbl_confirmar);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txt_senha);
            this.panel1.Controls.Add(this.label_campo2);
            this.panel1.Controls.Add(this.label_campo1);
            this.panel1.Controls.Add(this.label_descricao);
            this.panel1.Controls.Add(this.label_titulo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 379);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(99, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(314, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "Vincular Depois";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_cnpj
            // 
            this.txt_cnpj.Location = new System.Drawing.Point(99, 170);
            this.txt_cnpj.Mask = "00.000.000/0000-00";
            this.txt_cnpj.Name = "txt_cnpj";
            this.txt_cnpj.Size = new System.Drawing.Size(314, 22);
            this.txt_cnpj.TabIndex = 1;
            // 
            // txt_senha2
            // 
            this.txt_senha2.Location = new System.Drawing.Point(99, 261);
            this.txt_senha2.Name = "txt_senha2";
            this.txt_senha2.Size = new System.Drawing.Size(314, 22);
            this.txt_senha2.TabIndex = 6;
            this.txt_senha2.UseSystemPasswordChar = true;
            this.txt_senha2.Visible = false;
            // 
            // lbl_confirmar
            // 
            this.lbl_confirmar.AutoSize = true;
            this.lbl_confirmar.Location = new System.Drawing.Point(96, 241);
            this.lbl_confirmar.Name = "lbl_confirmar";
            this.lbl_confirmar.Size = new System.Drawing.Size(114, 17);
            this.lbl_confirmar.TabIndex = 9;
            this.lbl_confirmar.Text = "Confirmar Senha";
            this.lbl_confirmar.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(314, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Vincular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(99, 215);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.Size = new System.Drawing.Size(314, 22);
            this.txt_senha.TabIndex = 5;
            this.txt_senha.UseSystemPasswordChar = true;
            // 
            // label_campo2
            // 
            this.label_campo2.AutoSize = true;
            this.label_campo2.Location = new System.Drawing.Point(96, 195);
            this.label_campo2.Name = "label_campo2";
            this.label_campo2.Size = new System.Drawing.Size(49, 17);
            this.label_campo2.TabIndex = 3;
            this.label_campo2.Text = "Senha";
            // 
            // label_campo1
            // 
            this.label_campo1.AutoSize = true;
            this.label_campo1.Location = new System.Drawing.Point(96, 150);
            this.label_campo1.Name = "label_campo1";
            this.label_campo1.Size = new System.Drawing.Size(43, 17);
            this.label_campo1.TabIndex = 2;
            this.label_campo1.Text = "CNPJ";
            // 
            // label_descricao
            // 
            this.label_descricao.Location = new System.Drawing.Point(53, 61);
            this.label_descricao.Name = "label_descricao";
            this.label_descricao.Size = new System.Drawing.Size(389, 45);
            this.label_descricao.TabIndex = 1;
            this.label_descricao.Text = "Você precisa inserir seu CNPJ e Senha para vincular esta unidade de sistema em se" +
    "u usuario credenciado.";
            // 
            // label_titulo
            // 
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.Location = new System.Drawing.Point(3, 10);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(500, 41);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Seja Bem vindo !";
            this.label_titulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Primeiro_Acesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 395);
            this.Controls.Add(this.panel1);
            this.Name = "Primeiro_Acesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primeiro Acesso";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Primeiro_Acesso_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Label label_campo2;
        private System.Windows.Forms.Label label_campo1;
        private System.Windows.Forms.Label label_descricao;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.TextBox txt_senha2;
        private System.Windows.Forms.Label lbl_confirmar;
        private System.Windows.Forms.MaskedTextBox txt_cnpj;
        private System.Windows.Forms.Button button2;

    }
}