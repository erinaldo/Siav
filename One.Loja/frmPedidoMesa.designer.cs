namespace One.Loja
{
    partial class frmPedidoMesa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.Label();
            this.lblInfoOcup = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMesas = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutDiponivel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLayoutAtendente = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutOcupadas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSupGeralVendas = new System.Windows.Forms.Panel();
            this.dgDetalheMesa = new System.Windows.Forms.DataGridView();
            this.lblResumoGeral = new System.Windows.Forms.Label();
            this.lblItensVendas = new System.Windows.Forms.Label();
            this.pnlInferioItensVendas = new System.Windows.Forms.Panel();
            this.dgDetalhes = new System.Windows.Forms.DataGridView();
            this.pnlCentralMesas = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMesas.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.pnlSupGeralVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalheMesa)).BeginInit();
            this.pnlInferioItensVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhes)).BeginInit();
            this.pnlCentralMesas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(979, 769);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "Valor Total (R$) =";
            this.label6.Visible = false;
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtValorTotal.AutoSize = true;
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(1106, 769);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(32, 14);
            this.txtValorTotal.TabIndex = 37;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.Visible = false;
            // 
            // lblInfoOcup
            // 
            this.lblInfoOcup.AutoSize = true;
            this.lblInfoOcup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoOcup.ForeColor = System.Drawing.Color.White;
            this.lblInfoOcup.Location = new System.Drawing.Point(126, 3);
            this.lblInfoOcup.Name = "lblInfoOcup";
            this.lblInfoOcup.Size = new System.Drawing.Size(12, 16);
            this.lblInfoOcup.TabIndex = 368;
            this.lblInfoOcup.Text = ".";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.White;
            this.lblQuantidade.Location = new System.Drawing.Point(108, 3);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(12, 16);
            this.lblQuantidade.TabIndex = 367;
            this.lblQuantidade.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 366;
            this.label2.Text = "Quantidade : ";
            // 
            // tabMesas
            // 
            this.tabMesas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMesas.Controls.Add(this.tabPage3);
            this.tabMesas.Controls.Add(this.tabPage4);
            this.tabMesas.Location = new System.Drawing.Point(4, 39);
            this.tabMesas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMesas.Name = "tabMesas";
            this.tabMesas.SelectedIndex = 0;
            this.tabMesas.Size = new System.Drawing.Size(1477, 688);
            this.tabMesas.TabIndex = 1;
            this.tabMesas.SelectedIndexChanged += new System.EventHandler(this.tabMesas_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flowLayoutDiponivel);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(1469, 656);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Disponível";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutDiponivel
            // 
            this.flowLayoutDiponivel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutDiponivel.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutDiponivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutDiponivel.Name = "flowLayoutDiponivel";
            this.flowLayoutDiponivel.Size = new System.Drawing.Size(1463, 648);
            this.flowLayoutDiponivel.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flowLayoutAtendente);
            this.tabPage4.Controls.Add(this.flowLayoutOcupadas);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage4.Size = new System.Drawing.Size(1469, 656);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Ocupado";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutAtendente
            // 
            this.flowLayoutAtendente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutAtendente.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutAtendente.Location = new System.Drawing.Point(0, 574);
            this.flowLayoutAtendente.Name = "flowLayoutAtendente";
            this.flowLayoutAtendente.Size = new System.Drawing.Size(1453, 82);
            this.flowLayoutAtendente.TabIndex = 367;
            this.flowLayoutAtendente.Visible = false;
            // 
            // flowLayoutOcupadas
            // 
            this.flowLayoutOcupadas.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutOcupadas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutOcupadas.Name = "flowLayoutOcupadas";
            this.flowLayoutOcupadas.Size = new System.Drawing.Size(1069, 563);
            this.flowLayoutOcupadas.TabIndex = 0;
            // 
            // pnlSupGeralVendas
            // 
            this.pnlSupGeralVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSupGeralVendas.BackColor = System.Drawing.Color.Black;
            this.pnlSupGeralVendas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSupGeralVendas.Controls.Add(this.dgDetalheMesa);
            this.pnlSupGeralVendas.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSupGeralVendas.Location = new System.Drawing.Point(1130, 532);
            this.pnlSupGeralVendas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSupGeralVendas.Name = "pnlSupGeralVendas";
            this.pnlSupGeralVendas.Size = new System.Drawing.Size(356, 210);
            this.pnlSupGeralVendas.TabIndex = 384;
            this.pnlSupGeralVendas.Visible = false;
            // 
            // dgDetalheMesa
            // 
            this.dgDetalheMesa.AllowUserToAddRows = false;
            this.dgDetalheMesa.AllowUserToDeleteRows = false;
            this.dgDetalheMesa.AllowUserToResizeColumns = false;
            this.dgDetalheMesa.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightBlue;
            this.dgDetalheMesa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgDetalheMesa.BackgroundColor = System.Drawing.Color.White;
            this.dgDetalheMesa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDetalheMesa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDetalheMesa.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgDetalheMesa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalheMesa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgDetalheMesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDetalheMesa.ColumnHeadersVisible = false;
            this.dgDetalheMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalheMesa.Enabled = false;
            this.dgDetalheMesa.EnableHeadersVisualStyles = false;
            this.dgDetalheMesa.GridColor = System.Drawing.Color.White;
            this.dgDetalheMesa.Location = new System.Drawing.Point(0, 0);
            this.dgDetalheMesa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgDetalheMesa.MultiSelect = false;
            this.dgDetalheMesa.Name = "dgDetalheMesa";
            this.dgDetalheMesa.ReadOnly = true;
            this.dgDetalheMesa.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgDetalheMesa.RowHeadersVisible = false;
            this.dgDetalheMesa.ShowCellErrors = false;
            this.dgDetalheMesa.ShowCellToolTips = false;
            this.dgDetalheMesa.ShowEditingIcon = false;
            this.dgDetalheMesa.ShowRowErrors = false;
            this.dgDetalheMesa.Size = new System.Drawing.Size(354, 208);
            this.dgDetalheMesa.TabIndex = 4;
            // 
            // lblResumoGeral
            // 
            this.lblResumoGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResumoGeral.AutoSize = true;
            this.lblResumoGeral.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumoGeral.Location = new System.Drawing.Point(1241, 510);
            this.lblResumoGeral.Name = "lblResumoGeral";
            this.lblResumoGeral.Size = new System.Drawing.Size(143, 16);
            this.lblResumoGeral.TabIndex = 11;
            this.lblResumoGeral.Text = "R E S U M O   G E R A L";
            this.lblResumoGeral.Visible = false;
            // 
            // lblItensVendas
            // 
            this.lblItensVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItensVendas.AutoSize = true;
            this.lblItensVendas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItensVendas.Location = new System.Drawing.Point(1238, 15);
            this.lblItensVendas.Name = "lblItensVendas";
            this.lblItensVendas.Size = new System.Drawing.Size(146, 16);
            this.lblItensVendas.TabIndex = 10;
            this.lblItensVendas.Text = "I T E N S    V E N D A S ";
            this.lblItensVendas.Visible = false;
            // 
            // pnlInferioItensVendas
            // 
            this.pnlInferioItensVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInferioItensVendas.BackColor = System.Drawing.Color.Red;
            this.pnlInferioItensVendas.Controls.Add(this.dgDetalhes);
            this.pnlInferioItensVendas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInferioItensVendas.Location = new System.Drawing.Point(1133, 34);
            this.pnlInferioItensVendas.Name = "pnlInferioItensVendas";
            this.pnlInferioItensVendas.Size = new System.Drawing.Size(356, 451);
            this.pnlInferioItensVendas.TabIndex = 385;
            this.pnlInferioItensVendas.Visible = false;
            // 
            // dgDetalhes
            // 
            this.dgDetalhes.AllowUserToAddRows = false;
            this.dgDetalhes.AllowUserToDeleteRows = false;
            this.dgDetalhes.AllowUserToResizeColumns = false;
            this.dgDetalhes.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightBlue;
            this.dgDetalhes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgDetalhes.BackgroundColor = System.Drawing.Color.White;
            this.dgDetalhes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDetalhes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgDetalhes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetalhes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgDetalhes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetalhes.Enabled = false;
            this.dgDetalhes.EnableHeadersVisualStyles = false;
            this.dgDetalhes.GridColor = System.Drawing.Color.White;
            this.dgDetalhes.Location = new System.Drawing.Point(0, 0);
            this.dgDetalhes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgDetalhes.MultiSelect = false;
            this.dgDetalhes.Name = "dgDetalhes";
            this.dgDetalhes.ReadOnly = true;
            this.dgDetalhes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgDetalhes.RowHeadersVisible = false;
            this.dgDetalhes.ShowCellErrors = false;
            this.dgDetalhes.ShowCellToolTips = false;
            this.dgDetalhes.ShowEditingIcon = false;
            this.dgDetalhes.ShowRowErrors = false;
            this.dgDetalhes.Size = new System.Drawing.Size(356, 451);
            this.dgDetalhes.TabIndex = 7;
            // 
            // pnlCentralMesas
            // 
            this.pnlCentralMesas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCentralMesas.BackColor = System.Drawing.Color.Transparent;
            this.pnlCentralMesas.Controls.Add(this.lblTexto);
            this.pnlCentralMesas.Controls.Add(this.tabMesas);
            this.pnlCentralMesas.Location = new System.Drawing.Point(9, 12);
            this.pnlCentralMesas.Name = "pnlCentralMesas";
            this.pnlCentralMesas.Size = new System.Drawing.Size(1480, 731);
            this.pnlCentralMesas.TabIndex = 384;
            this.pnlCentralMesas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCentralMesas_Paint);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(361, 5);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(413, 58);
            this.lblTexto.TabIndex = 2;
            this.lblTexto.Text = "Controle de Mesas";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.lblInfoOcup);
            this.panel2.Controls.Add(this.lblQuantidade);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(9, 743);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1481, 25);
            this.panel2.TabIndex = 386;
            // 
            // frmPedidoMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1506, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblResumoGeral);
            this.Controls.Add(this.pnlSupGeralVendas);
            this.Controls.Add(this.pnlCentralMesas);
            this.Controls.Add(this.lblItensVendas);
            this.Controls.Add(this.pnlInferioItensVendas);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label6);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPedidoMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "\'\'";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            this.Shown += new System.EventHandler(this.frmPedido_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPedido_KeyDown);
            this.tabMesas.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.pnlSupGeralVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalheMesa)).EndInit();
            this.pnlInferioItensVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhes)).EndInit();
            this.pnlCentralMesas.ResumeLayout(false);
            this.pnlCentralMesas.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtValorTotal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutDiponivel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutAtendente;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOcupadas;
        private System.Windows.Forms.Label lblItensVendas;
        private System.Windows.Forms.Label lblResumoGeral;
        private System.Windows.Forms.Label lblInfoOcup;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSupGeralVendas;
        private System.Windows.Forms.Panel pnlInferioItensVendas;
        public System.Windows.Forms.DataGridView dgDetalhes;
        private System.Windows.Forms.Panel pnlCentralMesas;
        public System.Windows.Forms.TabControl tabMesas;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgDetalheMesa;
        private System.Windows.Forms.Label lblTexto;
    }
}