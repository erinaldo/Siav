namespace One.Loja
{
    partial class FrmInputCpf
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
            this.gbInputs = new System.Windows.Forms.GroupBox();
            this.txtCpfCliente = new System.Windows.Forms.MaskedTextBox();
            this.btnRegistraCpf = new System.Windows.Forms.Button();
            this.btnRetornarPdv = new System.Windows.Forms.Button();
            this.gbInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInputs
            // 
            this.gbInputs.Controls.Add(this.txtCpfCliente);
            this.gbInputs.Location = new System.Drawing.Point(12, 12);
            this.gbInputs.Name = "gbInputs";
            this.gbInputs.Size = new System.Drawing.Size(437, 41);
            this.gbInputs.TabIndex = 0;
            this.gbInputs.TabStop = false;
            this.gbInputs.Text = "CPF/CNPJ";
            // 
            // txtCpfCliente
            // 
            this.txtCpfCliente.Location = new System.Drawing.Point(13, 15);
            this.txtCpfCliente.Name = "txtCpfCliente";
            this.txtCpfCliente.Size = new System.Drawing.Size(418, 20);
            this.txtCpfCliente.TabIndex = 0;
            this.txtCpfCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCpfCliente_KeyDown);
            this.txtCpfCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpfCliente_KeyPress);
            this.txtCpfCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCpfCliente_KeyUp);
            // 
            // btnRegistraCpf
            // 
            this.btnRegistraCpf.Location = new System.Drawing.Point(372, 62);
            this.btnRegistraCpf.Name = "btnRegistraCpf";
            this.btnRegistraCpf.Size = new System.Drawing.Size(75, 23);
            this.btnRegistraCpf.TabIndex = 1;
            this.btnRegistraCpf.Text = "Registrar CPF";
            this.btnRegistraCpf.UseVisualStyleBackColor = true;
            this.btnRegistraCpf.Click += new System.EventHandler(this.btnRegistraCpf_Click);
            // 
            // btnRetornarPdv
            // 
            this.btnRetornarPdv.Location = new System.Drawing.Point(291, 62);
            this.btnRetornarPdv.Name = "btnRetornarPdv";
            this.btnRetornarPdv.Size = new System.Drawing.Size(75, 23);
            this.btnRetornarPdv.TabIndex = 2;
            this.btnRetornarPdv.Text = "Retornar";
            this.btnRetornarPdv.UseVisualStyleBackColor = true;
            this.btnRetornarPdv.Click += new System.EventHandler(this.btnRetornarPdv_Click);
            // 
            // FrmInputCpf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(459, 97);
            this.Controls.Add(this.btnRetornarPdv);
            this.Controls.Add(this.btnRegistraCpf);
            this.Controls.Add(this.gbInputs);
            this.Name = "FrmInputCpf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entre o CPF/CNPJ do cliente";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInputCpf_KeyDown);
            this.gbInputs.ResumeLayout(false);
            this.gbInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInputs;
        private System.Windows.Forms.Button btnRegistraCpf;
        private System.Windows.Forms.Button btnRetornarPdv;
        private System.Windows.Forms.MaskedTextBox txtCpfCliente;
    }
}