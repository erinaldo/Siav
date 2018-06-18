namespace LFi
{
    partial class frmTipoDeOperacao
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblIDGrupo = new System.Windows.Forms.Label();
            this.txtGrupoID = new System.Windows.Forms.TextBox();
            this.btnSalvarTipoDeOperacao = new System.Windows.Forms.Button();
            this.btnExcluirTipoDeOperacao = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSinal = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Operação = new System.Windows.Forms.Label();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.labelGrupo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvarGrupo = new System.Windows.Forms.Button();
            this.btnExcluirGrupo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(344, 473);
            this.treeView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 473);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSalvarGrupo);
            this.panel2.Controls.Add(this.btnExcluirGrupo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cboGrupo);
            this.panel2.Controls.Add(this.lblIDGrupo);
            this.panel2.Controls.Add(this.txtGrupoID);
            this.panel2.Controls.Add(this.btnSalvarTipoDeOperacao);
            this.panel2.Controls.Add(this.btnExcluirTipoDeOperacao);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboSinal);
            this.panel2.Controls.Add(this.txtNome);
            this.panel2.Controls.Add(this.Operação);
            this.panel2.Controls.Add(this.txtGrupo);
            this.panel2.Controls.Add(this.labelGrupo);
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(362, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 313);
            this.panel2.TabIndex = 2;
            
            // 
            // lblIDGrupo
            // 
            this.lblIDGrupo.AutoSize = true;
            this.lblIDGrupo.Location = new System.Drawing.Point(38, 35);
            this.lblIDGrupo.Name = "lblIDGrupo";
            this.lblIDGrupo.Size = new System.Drawing.Size(47, 13);
            this.lblIDGrupo.TabIndex = 11;
            this.lblIDGrupo.Text = "GrupoID";
            // 
            // txtGrupoID
            // 
            this.txtGrupoID.Location = new System.Drawing.Point(91, 32);
            this.txtGrupoID.Name = "txtGrupoID";
            this.txtGrupoID.Size = new System.Drawing.Size(81, 21);
            this.txtGrupoID.TabIndex = 10;
            // 
            // btnSalvarTipoDeOperacao
            // 
            this.btnSalvarTipoDeOperacao.Location = new System.Drawing.Point(177, 267);
            this.btnSalvarTipoDeOperacao.Name = "btnSalvarTipoDeOperacao";
            this.btnSalvarTipoDeOperacao.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarTipoDeOperacao.TabIndex = 9;
            this.btnSalvarTipoDeOperacao.Text = "Atualizar";
            this.btnSalvarTipoDeOperacao.UseVisualStyleBackColor = true;
            this.btnSalvarTipoDeOperacao.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExcluirTipoDeOperacao
            // 
            this.btnExcluirTipoDeOperacao.Location = new System.Drawing.Point(260, 267);
            this.btnExcluirTipoDeOperacao.Name = "btnExcluirTipoDeOperacao";
            this.btnExcluirTipoDeOperacao.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirTipoDeOperacao.TabIndex = 8;
            this.btnExcluirTipoDeOperacao.Text = "Excluir";
            this.btnExcluirTipoDeOperacao.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sinal";
            // 
            // cboSinal
            // 
            this.cboSinal.FormattingEnabled = true;
            this.cboSinal.Items.AddRange(new object[] {
            "C",
            "D"});
            this.cboSinal.Location = new System.Drawing.Point(102, 240);
            this.cboSinal.Name = "cboSinal";
            this.cboSinal.Size = new System.Drawing.Size(231, 21);
            this.cboSinal.TabIndex = 6;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(102, 201);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(231, 21);
            this.txtNome.TabIndex = 5;
            // 
            // Operação
            // 
            this.Operação.AutoSize = true;
            this.Operação.Location = new System.Drawing.Point(14, 204);
            this.Operação.Name = "Operação";
            this.Operação.Size = new System.Drawing.Size(84, 13);
            this.Operação.TabIndex = 4;
            this.Operação.Text = "Nome Operação";
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(91, 57);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(244, 21);
            this.txtGrupo.TabIndex = 3;
            // 
            // labelGrupo
            // 
            this.labelGrupo.AutoSize = true;
            this.labelGrupo.Location = new System.Drawing.Point(49, 60);
            this.labelGrupo.Name = "labelGrupo";
            this.labelGrupo.Size = new System.Drawing.Size(36, 13);
            this.labelGrupo.TabIndex = 2;
            this.labelGrupo.Text = "Grupo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(102, 125);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(81, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // cboGrupo
            // 
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(102, 163);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(231, 21);
            this.cboGrupo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Grupo";
            // 
            // btnSalvarGrupo
            // 
            this.btnSalvarGrupo.Location = new System.Drawing.Point(179, 84);
            this.btnSalvarGrupo.Name = "btnSalvarGrupo";
            this.btnSalvarGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarGrupo.TabIndex = 15;
            this.btnSalvarGrupo.Text = "Atualizar";
            this.btnSalvarGrupo.UseVisualStyleBackColor = true;
            this.btnSalvarGrupo.Click += new System.EventHandler(this.btnSalvarGrupo_Click);
            // 
            // btnExcluirGrupo
            // 
            this.btnExcluirGrupo.Location = new System.Drawing.Point(260, 84);
            this.btnExcluirGrupo.Name = "btnExcluirGrupo";
            this.btnExcluirGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirGrupo.TabIndex = 14;
            this.btnExcluirGrupo.Text = "Excluir";
            this.btnExcluirGrupo.UseVisualStyleBackColor = true;
            // 
            // frmTipoDeOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTipoDeOperacao";
            this.Text = "Tipo De Operação";
            this.Load += new System.EventHandler(this.frmTipoDeOperacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSinal;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label Operação;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label labelGrupo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvarTipoDeOperacao;
        private System.Windows.Forms.Button btnExcluirTipoDeOperacao;
        private System.Windows.Forms.Label lblIDGrupo;
        private System.Windows.Forms.TextBox txtGrupoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.Button btnSalvarGrupo;
        private System.Windows.Forms.Button btnExcluirGrupo;
    }
}