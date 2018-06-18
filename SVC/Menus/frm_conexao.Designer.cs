namespace One
{
    partial class frm_conexao
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
            this.cbAcessoBanco = new System.Windows.Forms.ComboBox();
            this.btEntrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbAcessoBanco
            // 
            this.cbAcessoBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAcessoBanco.FormattingEnabled = true;
            this.cbAcessoBanco.Items.AddRange(new object[] {
            "EquipamentosCia",
            "Desenvolvimento"});
            this.cbAcessoBanco.Location = new System.Drawing.Point(10, 11);
            this.cbAcessoBanco.Margin = new System.Windows.Forms.Padding(2);
            this.cbAcessoBanco.Name = "cbAcessoBanco";
            this.cbAcessoBanco.Size = new System.Drawing.Size(291, 21);
            this.cbAcessoBanco.TabIndex = 0;
            this.cbAcessoBanco.SelectedIndexChanged += new System.EventHandler(this.cbAcessoBanco_SelectedIndexChanged);
            this.cbAcessoBanco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbAcessoBanco_KeyUp);
            // 
            // btEntrar
            // 
            this.btEntrar.Location = new System.Drawing.Point(10, 36);
            this.btEntrar.Margin = new System.Windows.Forms.Padding(2);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(56, 19);
            this.btEntrar.TabIndex = 1;
            this.btEntrar.Text = "Entrar";
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // frm_conexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(310, 71);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.cbAcessoBanco);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 109);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 109);
            this.Name = "frm_conexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Site";
            this.Load += new System.EventHandler(this.frm_conexao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAcessoBanco;
        private System.Windows.Forms.Button btEntrar;
    }
}