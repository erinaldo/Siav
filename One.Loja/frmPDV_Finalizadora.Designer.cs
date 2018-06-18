namespace One.Loja
{
    partial class frmPDV_Finalizadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPDV_Finalizadora));
            this.lblStatus = new System.Windows.Forms.Label();
            this._Arrendodamento = new System.Windows.Forms.TextBox();
            this.pnlReveda = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlCartaoDebito = new System.Windows.Forms.GroupBox();
            this._CartaoDebito = new System.Windows.Forms.TextBox();
            this.pnlCartaoCredito = new System.Windows.Forms.GroupBox();
            this._CartaoCredito = new System.Windows.Forms.TextBox();
            this.pnlDinheiro = new System.Windows.Forms.GroupBox();
            this._Dinheiro = new System.Windows.Forms.TextBox();
            this.pnlDesconto = new System.Windows.Forms.GroupBox();
            this._Desconto = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTotalGeralVendaBruto = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtTotalRestante = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblTotalPago = new System.Windows.Forms.TextBox();
            this.pnlCheque = new System.Windows.Forms.GroupBox();
            this._Cheque = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtVendaID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCodigoAbertura = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCodigoCliente = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.group_vendedor = new System.Windows.Forms.GroupBox();
            this.cb_vendedor = new System.Windows.Forms.ComboBox();
            this.pnlReveda.SuspendLayout();
            this.pnlCartaoDebito.SuspendLayout();
            this.pnlCartaoCredito.SuspendLayout();
            this.pnlDinheiro.SuspendLayout();
            this.pnlDesconto.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.pnlCheque.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.group_vendedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblStatus.Location = new System.Drawing.Point(18, 37);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1015, 57);
            this.lblStatus.TabIndex = 358;
            this.lblStatus.Text = "Finalizando Venda . . . ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // _Arrendodamento
            // 
            this._Arrendodamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Arrendodamento.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Arrendodamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._Arrendodamento.Location = new System.Drawing.Point(12, 21);
            this._Arrendodamento.Name = "_Arrendodamento";
            this._Arrendodamento.ReadOnly = true;
            this._Arrendodamento.Size = new System.Drawing.Size(398, 53);
            this._Arrendodamento.TabIndex = 359;
            this._Arrendodamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Arrendodamento.TextChanged += new System.EventHandler(this._Arrendodamento_TextChanged);
            this._Arrendodamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Arrendodamento_KeyDown);
            // 
            // pnlReveda
            // 
            this.pnlReveda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlReveda.Controls.Add(this._Arrendodamento);
            this.pnlReveda.ForeColor = System.Drawing.Color.Black;
            this.pnlReveda.Location = new System.Drawing.Point(12, 475);
            this.pnlReveda.Name = "pnlReveda";
            this.pnlReveda.Size = new System.Drawing.Size(410, 85);
            this.pnlReveda.TabIndex = 360;
            this.pnlReveda.TabStop = false;
            this.pnlReveda.Text = "Valor troca";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(857, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 64);
            this.button1.TabIndex = 361;
            this.button1.Text = "F2 - Fechar Venda";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(453, 587);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 62);
            this.button2.TabIndex = 362;
            this.button2.Text = "F3 - Limpar ";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(643, 587);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 62);
            this.button3.TabIndex = 363;
            this.button3.Text = "F4 - Desconto";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(942, -1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 35);
            this.button5.TabIndex = 365;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnlCartaoDebito
            // 
            this.pnlCartaoDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCartaoDebito.Controls.Add(this._CartaoDebito);
            this.pnlCartaoDebito.ForeColor = System.Drawing.Color.Black;
            this.pnlCartaoDebito.Location = new System.Drawing.Point(12, 293);
            this.pnlCartaoDebito.Name = "pnlCartaoDebito";
            this.pnlCartaoDebito.Size = new System.Drawing.Size(410, 85);
            this.pnlCartaoDebito.TabIndex = 366;
            this.pnlCartaoDebito.TabStop = false;
            this.pnlCartaoDebito.Text = "Valor em Cartão de Débito";
            // 
            // _CartaoDebito
            // 
            this._CartaoDebito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._CartaoDebito.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CartaoDebito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._CartaoDebito.Location = new System.Drawing.Point(6, 21);
            this._CartaoDebito.Name = "_CartaoDebito";
            this._CartaoDebito.Size = new System.Drawing.Size(398, 53);
            this._CartaoDebito.TabIndex = 2;
            this._CartaoDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CartaoDebito.TextChanged += new System.EventHandler(this._CartaoDebito_TextChanged);
            this._CartaoDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this._CartaoDebito_KeyDown);
            // 
            // pnlCartaoCredito
            // 
            this.pnlCartaoCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCartaoCredito.Controls.Add(this._CartaoCredito);
            this.pnlCartaoCredito.ForeColor = System.Drawing.Color.Black;
            this.pnlCartaoCredito.Location = new System.Drawing.Point(12, 202);
            this.pnlCartaoCredito.Name = "pnlCartaoCredito";
            this.pnlCartaoCredito.Size = new System.Drawing.Size(410, 85);
            this.pnlCartaoCredito.TabIndex = 367;
            this.pnlCartaoCredito.TabStop = false;
            this.pnlCartaoCredito.Text = "Cartão de Crédito";
            // 
            // _CartaoCredito
            // 
            this._CartaoCredito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._CartaoCredito.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CartaoCredito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._CartaoCredito.Location = new System.Drawing.Point(6, 21);
            this._CartaoCredito.Name = "_CartaoCredito";
            this._CartaoCredito.Size = new System.Drawing.Size(398, 53);
            this._CartaoCredito.TabIndex = 1;
            this._CartaoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CartaoCredito.TextChanged += new System.EventHandler(this._CartaoCredito_TextChanged);
            this._CartaoCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this._CartaoCredito_KeyDown);
            // 
            // pnlDinheiro
            // 
            this.pnlDinheiro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDinheiro.Controls.Add(this._Dinheiro);
            this.pnlDinheiro.ForeColor = System.Drawing.Color.Black;
            this.pnlDinheiro.Location = new System.Drawing.Point(12, 111);
            this.pnlDinheiro.Name = "pnlDinheiro";
            this.pnlDinheiro.Size = new System.Drawing.Size(410, 85);
            this.pnlDinheiro.TabIndex = 368;
            this.pnlDinheiro.TabStop = false;
            this.pnlDinheiro.Text = "Dinheiro";
            // 
            // _Dinheiro
            // 
            this._Dinheiro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dinheiro.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dinheiro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._Dinheiro.Location = new System.Drawing.Point(6, 21);
            this._Dinheiro.Name = "_Dinheiro";
            this._Dinheiro.Size = new System.Drawing.Size(398, 53);
            this._Dinheiro.TabIndex = 0;
            this._Dinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Dinheiro.TextChanged += new System.EventHandler(this._Dinheiro_TextChanged);
            this._Dinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Dinheiro_KeyDown);
            this._Dinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Dinheiro_KeyPress);
            // 
            // pnlDesconto
            // 
            this.pnlDesconto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDesconto.Controls.Add(this._Desconto);
            this.pnlDesconto.ForeColor = System.Drawing.Color.Black;
            this.pnlDesconto.Location = new System.Drawing.Point(12, 566);
            this.pnlDesconto.Name = "pnlDesconto";
            this.pnlDesconto.Size = new System.Drawing.Size(410, 85);
            this.pnlDesconto.TabIndex = 369;
            this.pnlDesconto.TabStop = false;
            this.pnlDesconto.Text = "Valor Desconto";
            // 
            // _Desconto
            // 
            this._Desconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Desconto.Enabled = false;
            this._Desconto.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Desconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._Desconto.Location = new System.Drawing.Point(6, 21);
            this._Desconto.Name = "_Desconto";
            this._Desconto.ReadOnly = true;
            this._Desconto.Size = new System.Drawing.Size(398, 53);
            this._Desconto.TabIndex = 359;
            this._Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Desconto.TextChanged += new System.EventHandler(this._Desconto_TextChanged);
            this._Desconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Desconto_KeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.txtTotalGeralVendaBruto);
            this.groupBox6.Location = new System.Drawing.Point(521, 426);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(512, 85);
            this.groupBox6.TabIndex = 370;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Total Venda";
            // 
            // txtTotalGeralVendaBruto
            // 
            this.txtTotalGeralVendaBruto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalGeralVendaBruto.Enabled = false;
            this.txtTotalGeralVendaBruto.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGeralVendaBruto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtTotalGeralVendaBruto.Location = new System.Drawing.Point(6, 21);
            this.txtTotalGeralVendaBruto.Name = "txtTotalGeralVendaBruto";
            this.txtTotalGeralVendaBruto.Size = new System.Drawing.Size(500, 53);
            this.txtTotalGeralVendaBruto.TabIndex = 359;
            this.txtTotalGeralVendaBruto.Text = "0,00";
            this.txtTotalGeralVendaBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.txtTotalRestante);
            this.groupBox7.Location = new System.Drawing.Point(780, 335);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(253, 85);
            this.groupBox7.TabIndex = 371;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Troco";
            // 
            // txtTotalRestante
            // 
            this.txtTotalRestante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalRestante.Enabled = false;
            this.txtTotalRestante.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRestante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtTotalRestante.Location = new System.Drawing.Point(6, 21);
            this.txtTotalRestante.Name = "txtTotalRestante";
            this.txtTotalRestante.Size = new System.Drawing.Size(241, 53);
            this.txtTotalRestante.TabIndex = 359;
            this.txtTotalRestante.Text = "0,00";
            this.txtTotalRestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.lblTotalPago);
            this.groupBox8.Location = new System.Drawing.Point(521, 335);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(253, 85);
            this.groupBox8.TabIndex = 372;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Total Pago";
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTotalPago.Enabled = false;
            this.lblTotalPago.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalPago.Location = new System.Drawing.Point(6, 21);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(241, 53);
            this.lblTotalPago.TabIndex = 359;
            this.lblTotalPago.Text = "0,00";
            this.lblTotalPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlCheque
            // 
            this.pnlCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCheque.Controls.Add(this._Cheque);
            this.pnlCheque.ForeColor = System.Drawing.Color.Black;
            this.pnlCheque.Location = new System.Drawing.Point(12, 384);
            this.pnlCheque.Name = "pnlCheque";
            this.pnlCheque.Size = new System.Drawing.Size(410, 85);
            this.pnlCheque.TabIndex = 373;
            this.pnlCheque.TabStop = false;
            this.pnlCheque.Text = "Valor em Cheque";
            // 
            // _Cheque
            // 
            this._Cheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Cheque.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this._Cheque.Location = new System.Drawing.Point(6, 21);
            this._Cheque.Name = "_Cheque";
            this._Cheque.Size = new System.Drawing.Size(398, 53);
            this._Cheque.TabIndex = 3;
            this._Cheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Cheque.TextChanged += new System.EventHandler(this._Cheque_TextChanged);
            this._Cheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Cheque_KeyDown);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 70);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 374;
            this.lblResult.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtUsuario,
            this.toolStripStatusLabel2,
            this.txtVendaID,
            this.toolStripStatusLabel3,
            this.lblTime,
            this.toolStripStatusLabel4,
            this.lblCodigoAbertura,
            this.toolStripStatusLabel5,
            this.lblCodigoCliente,
            this.toolStripStatusLabel6});
            this.statusStrip1.Location = new System.Drawing.Point(0, 638);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1043, 25);
            this.statusStrip1.TabIndex = 375;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 20);
            this.toolStripStatusLabel1.Text = "Operador :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(76, 20);
            this.txtUsuario.Text = "lblUsuario";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 20);
            this.toolStripStatusLabel2.Text = "| Venda  :";
            // 
            // txtVendaID
            // 
            this.txtVendaID.Name = "txtVendaID";
            this.txtVendaID.Size = new System.Drawing.Size(68, 20);
            this.txtVendaID.Text = "lblVenda";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(60, 20);
            this.toolStripStatusLabel3.Text = "| Data  :";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 20);
            this.lblTime.Text = "lblTime";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(82, 20);
            this.toolStripStatusLabel4.Text = "| Abertura :";
            // 
            // lblCodigoAbertura
            // 
            this.lblCodigoAbertura.Name = "lblCodigoAbertura";
            this.lblCodigoAbertura.Size = new System.Drawing.Size(84, 20);
            this.lblCodigoAbertura.Text = "lblAbertura";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(101, 20);
            this.toolStripStatusLabel5.Text = "| Cliente Cod :";
            // 
            // lblCodigoCliente
            // 
            this.lblCodigoCliente.Name = "lblCodigoCliente";
            this.lblCodigoCliente.Size = new System.Drawing.Size(30, 20);
            this.lblCodigoCliente.Text = "xxx";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel6.Text = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(857, 517);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 64);
            this.button4.TabIndex = 376;
            this.button4.Text = "Venda Promissoria";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // group_vendedor
            // 
            this.group_vendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.group_vendedor.Controls.Add(this.cb_vendedor);
            this.group_vendedor.Location = new System.Drawing.Point(521, 244);
            this.group_vendedor.Name = "group_vendedor";
            this.group_vendedor.Size = new System.Drawing.Size(506, 85);
            this.group_vendedor.TabIndex = 377;
            this.group_vendedor.TabStop = false;
            this.group_vendedor.Text = "Vendedor";
            this.group_vendedor.Visible = false;
            // 
            // cb_vendedor
            // 
            this.cb_vendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F);
            this.cb_vendedor.FormattingEnabled = true;
            this.cb_vendedor.Location = new System.Drawing.Point(6, 21);
            this.cb_vendedor.Name = "cb_vendedor";
            this.cb_vendedor.Size = new System.Drawing.Size(494, 59);
            this.cb_vendedor.TabIndex = 0;
            // 
            // frmPDV_Finalizadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 663);
            this.ControlBox = false;
            this.Controls.Add(this.group_vendedor);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.pnlCheque);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.pnlDesconto);
            this.Controls.Add(this.pnlDinheiro);
            this.Controls.Add(this.pnlCartaoCredito);
            this.Controls.Add(this.pnlCartaoDebito);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlReveda);
            this.Controls.Add(this.lblStatus);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPDV_Finalizadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPDV_Finalizadora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPDV_Finalizadora_FormClosing);
            this.Load += new System.EventHandler(this.frmPDV_Finalizadora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPDV_Finalizadora_KeyDown);
            this.pnlReveda.ResumeLayout(false);
            this.pnlReveda.PerformLayout();
            this.pnlCartaoDebito.ResumeLayout(false);
            this.pnlCartaoDebito.PerformLayout();
            this.pnlCartaoCredito.ResumeLayout(false);
            this.pnlCartaoCredito.PerformLayout();
            this.pnlDinheiro.ResumeLayout(false);
            this.pnlDinheiro.PerformLayout();
            this.pnlDesconto.ResumeLayout(false);
            this.pnlDesconto.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.pnlCheque.ResumeLayout(false);
            this.pnlCheque.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.group_vendedor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox _Arrendodamento;
        private System.Windows.Forms.GroupBox pnlReveda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox pnlCartaoDebito;
        private System.Windows.Forms.TextBox _CartaoDebito;
        private System.Windows.Forms.GroupBox pnlCartaoCredito;
        private System.Windows.Forms.TextBox _CartaoCredito;
        private System.Windows.Forms.GroupBox pnlDinheiro;
        private System.Windows.Forms.TextBox _Dinheiro;
        private System.Windows.Forms.TextBox _Desconto;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox lblTotalPago;
        private System.Windows.Forms.GroupBox pnlCheque;
        private System.Windows.Forms.TextBox _Cheque;
        private System.Windows.Forms.GroupBox pnlDesconto;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripStatusLabel txtVendaID;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public System.Windows.Forms.ToolStripStatusLabel lblCodigoAbertura;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripStatusLabel lblCodigoCliente;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        public System.Windows.Forms.TextBox txtTotalGeralVendaBruto;
        public System.Windows.Forms.TextBox txtTotalRestante;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox group_vendedor;
        private System.Windows.Forms.ComboBox cb_vendedor;
    }
}