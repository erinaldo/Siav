namespace One.Loja
{
    partial class frmCupom
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigoCupom = new System.Windows.Forms.TextBox();
            this.btnSegundaVia = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodigoCupom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Codigo do Cupom";
            // 
            // txtCodigoCupom
            // 
            this.txtCodigoCupom.Location = new System.Drawing.Point(6, 19);
            this.txtCodigoCupom.MaxLength = 10;
            this.txtCodigoCupom.Name = "txtCodigoCupom";
            this.txtCodigoCupom.Size = new System.Drawing.Size(450, 20);
            this.txtCodigoCupom.TabIndex = 0;
            this.txtCodigoCupom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigoCupom_KeyDown);
            this.txtCodigoCupom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCupom_KeyPress);
            // 
            // btnSegundaVia
            // 
            this.btnSegundaVia.Location = new System.Drawing.Point(372, 67);
            this.btnSegundaVia.Name = "btnSegundaVia";
            this.btnSegundaVia.Size = new System.Drawing.Size(96, 23);
            this.btnSegundaVia.TabIndex = 1;
            this.btnSegundaVia.Text = "Confirmar";
            this.btnSegundaVia.UseVisualStyleBackColor = true;
            this.btnSegundaVia.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 67);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Retornar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCupom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 101);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSegundaVia);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCupom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Segunda via do cupom";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmCancelaCupom_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtCodigoCupom;
        private System.Windows.Forms.Button btnSegundaVia;
        private System.Windows.Forms.Button btnCancelar;
    }
}