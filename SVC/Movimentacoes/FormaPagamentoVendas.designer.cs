namespace One.MOVIMENTACOES
{
    partial class FormaPagamentoVendas
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
            this.gbFormaPagamento = new System.Windows.Forms.GroupBox();
            this.txtQuantidadeParcelas = new System.Windows.Forms.TextBox();
            this.lbQtdParc = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.panFormaPagamento = new System.Windows.Forms.Panel();
            this.gbFormaPagamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFormaPagamento
            // 
            this.gbFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFormaPagamento.Controls.Add(this.txtQuantidadeParcelas);
            this.gbFormaPagamento.Controls.Add(this.lbQtdParc);
            this.gbFormaPagamento.Controls.Add(this.btCancelar);
            this.gbFormaPagamento.Controls.Add(this.btConfirmar);
            this.gbFormaPagamento.Controls.Add(this.panFormaPagamento);
            this.gbFormaPagamento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFormaPagamento.Location = new System.Drawing.Point(10, 11);
            this.gbFormaPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.gbFormaPagamento.Name = "gbFormaPagamento";
            this.gbFormaPagamento.Padding = new System.Windows.Forms.Padding(2);
            this.gbFormaPagamento.Size = new System.Drawing.Size(355, 344);
            this.gbFormaPagamento.TabIndex = 0;
            this.gbFormaPagamento.TabStop = false;
            // 
            // txtQuantidadeParcelas
            // 
            this.txtQuantidadeParcelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQuantidadeParcelas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeParcelas.Location = new System.Drawing.Point(294, 282);
            this.txtQuantidadeParcelas.Name = "txtQuantidadeParcelas";
            this.txtQuantidadeParcelas.Size = new System.Drawing.Size(55, 21);
            this.txtQuantidadeParcelas.TabIndex = 33;
            this.txtQuantidadeParcelas.Visible = false;
            this.txtQuantidadeParcelas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeParcelas_KeyPress);
            // 
            // lbQtdParc
            // 
            this.lbQtdParc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbQtdParc.AutoSize = true;
            this.lbQtdParc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQtdParc.Location = new System.Drawing.Point(167, 282);
            this.lbQtdParc.Name = "lbQtdParc";
            this.lbQtdParc.Size = new System.Drawing.Size(121, 13);
            this.lbQtdParc.TabIndex = 232;
            this.lbQtdParc.Text = "Quantidade de Parcelas";
            this.lbQtdParc.Visible = false;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btCancelar.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.Black;
            this.btCancelar.Location = new System.Drawing.Point(5, 313);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(76, 25);
            this.btCancelar.TabIndex = 34;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btConfirmar
            // 
            this.btConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btConfirmar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirmar.ForeColor = System.Drawing.Color.Navy;
            this.btConfirmar.Location = new System.Drawing.Point(273, 313);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(76, 25);
            this.btConfirmar.TabIndex = 33;
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btConfirmar.UseVisualStyleBackColor = true;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // panFormaPagamento
            // 
            this.panFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panFormaPagamento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panFormaPagamento.Location = new System.Drawing.Point(4, 17);
            this.panFormaPagamento.Margin = new System.Windows.Forms.Padding(2);
            this.panFormaPagamento.Name = "panFormaPagamento";
            this.panFormaPagamento.Size = new System.Drawing.Size(346, 259);
            this.panFormaPagamento.TabIndex = 0;
            // 
            // FormaPagamentoVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 364);
            this.Controls.Add(this.gbFormaPagamento);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormaPagamentoVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma de Pagamento";
            this.Load += new System.EventHandler(this.FormaPagamentoVendas_Load);
            this.gbFormaPagamento.ResumeLayout(false);
            this.gbFormaPagamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFormaPagamento;
        private System.Windows.Forms.Panel panFormaPagamento;
        internal System.Windows.Forms.Button btConfirmar;
        internal System.Windows.Forms.Button btCancelar;
        internal System.Windows.Forms.TextBox txtQuantidadeParcelas;
        internal System.Windows.Forms.Label lbQtdParc;
    }
}