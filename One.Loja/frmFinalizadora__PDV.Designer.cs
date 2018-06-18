namespace One.Loja
{
    partial class frmFinalizadora__PDV
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinalizadora__PDV));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlFormasPagamento = new System.Windows.Forms.Panel();
            this.pnlReveda = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlCheque = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlDesconto = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlCartaoDebito = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlCartaoCredito = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDinheiro = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtTotalGeralVendaBruto = new System.Windows.Forms.Label();
            this._Desconto = new System.Windows.Forms.TextBox();
            this._Arrendodamento = new System.Windows.Forms.TextBox();
            this._CartaoDebito = new System.Windows.Forms.TextBox();
            this._CartaoCredito = new System.Windows.Forms.TextBox();
            this._Dinheiro = new System.Windows.Forms.TextBox();
            this.txtTotalRestante = new System.Windows.Forms.Label();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFecharTela = new System.Windows.Forms.Button();
            this.btF2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this._Cheque = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPrincipal.SuspendLayout();
            this.pnlFormasPagamento.SuspendLayout();
            this.pnlReveda.SuspendLayout();
            this.pnlCheque.SuspendLayout();
            this.pnlDesconto.SuspendLayout();
            this.pnlCartaoDebito.SuspendLayout();
            this.pnlCartaoCredito.SuspendLayout();
            this.pnlDinheiro.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrincipal.Controls.Add(this.pnlFormasPagamento);
            this.pnlPrincipal.Location = new System.Drawing.Point(52, 259);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(289, 690);
            this.pnlPrincipal.TabIndex = 0;
            // 
            // pnlFormasPagamento
            // 
            this.pnlFormasPagamento.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormasPagamento.Controls.Add(this.pnlReveda);
            this.pnlFormasPagamento.Controls.Add(this.pnlCheque);
            this.pnlFormasPagamento.Controls.Add(this.pnlDesconto);
            this.pnlFormasPagamento.Controls.Add(this.pnlCartaoDebito);
            this.pnlFormasPagamento.Controls.Add(this.pnlCartaoCredito);
            this.pnlFormasPagamento.Controls.Add(this.pnlDinheiro);
            this.pnlFormasPagamento.Location = new System.Drawing.Point(3, 10);
            this.pnlFormasPagamento.Name = "pnlFormasPagamento";
            this.pnlFormasPagamento.Size = new System.Drawing.Size(306, 659);
            this.pnlFormasPagamento.TabIndex = 1;
            this.pnlFormasPagamento.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormasPagamento_Paint);
            // 
            // pnlReveda
            // 
            this.pnlReveda.BackColor = System.Drawing.Color.Transparent;
            this.pnlReveda.Controls.Add(this.label6);
            this.pnlReveda.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlReveda.Location = new System.Drawing.Point(16, 394);
            this.pnlReveda.Name = "pnlReveda";
            this.pnlReveda.Size = new System.Drawing.Size(270, 43);
            this.pnlReveda.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 36);
            this.label6.TabIndex = 1;
            this.label6.Text = "Valor Troca";
            // 
            // pnlCheque
            // 
            this.pnlCheque.BackColor = System.Drawing.Color.Transparent;
            this.pnlCheque.Controls.Add(this.label5);
            this.pnlCheque.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlCheque.Location = new System.Drawing.Point(16, 235);
            this.pnlCheque.Name = "pnlCheque";
            this.pnlCheque.Size = new System.Drawing.Size(267, 43);
            this.pnlCheque.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "4-Cheque";
            // 
            // pnlDesconto
            // 
            this.pnlDesconto.BackColor = System.Drawing.Color.Transparent;
            this.pnlDesconto.Controls.Add(this.label7);
            this.pnlDesconto.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlDesconto.Location = new System.Drawing.Point(16, 313);
            this.pnlDesconto.Name = "pnlDesconto";
            this.pnlDesconto.Size = new System.Drawing.Size(266, 43);
            this.pnlDesconto.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(287, 36);
            this.label7.TabIndex = 1;
            this.label7.Text = "F4 - Desconto(%)";
            // 
            // pnlCartaoDebito
            // 
            this.pnlCartaoDebito.BackColor = System.Drawing.Color.Transparent;
            this.pnlCartaoDebito.Controls.Add(this.label4);
            this.pnlCartaoDebito.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlCartaoDebito.Location = new System.Drawing.Point(16, 158);
            this.pnlCartaoDebito.Name = "pnlCartaoDebito";
            this.pnlCartaoDebito.Size = new System.Drawing.Size(270, 43);
            this.pnlCartaoDebito.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 36);
            this.label4.TabIndex = 1;
            this.label4.Text = "3-Cartão Débito";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pnlCartaoCredito
            // 
            this.pnlCartaoCredito.BackColor = System.Drawing.Color.Transparent;
            this.pnlCartaoCredito.Controls.Add(this.label3);
            this.pnlCartaoCredito.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlCartaoCredito.Location = new System.Drawing.Point(16, 75);
            this.pnlCartaoCredito.Name = "pnlCartaoCredito";
            this.pnlCartaoCredito.Size = new System.Drawing.Size(267, 50);
            this.pnlCartaoCredito.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "2-Cartão Crédito";
            // 
            // pnlDinheiro
            // 
            this.pnlDinheiro.BackColor = System.Drawing.Color.Transparent;
            this.pnlDinheiro.Controls.Add(this.label2);
            this.pnlDinheiro.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlDinheiro.Location = new System.Drawing.Point(16, 1);
            this.pnlDinheiro.Name = "pnlDinheiro";
            this.pnlDinheiro.Size = new System.Drawing.Size(266, 45);
            this.pnlDinheiro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "1-Dinheiro";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblResult.Location = new System.Drawing.Point(781, 56);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(362, 36);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Informe um valor . . .  .";
            this.lblResult.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(49, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(442, 45);
            this.label9.TabIndex = 6;
            this.label9.Text = "Cód.Forma Pagamento";
            this.label9.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(1077, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Visible = false;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblStatus.Location = new System.Drawing.Point(36, 39);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(557, 57);
            this.lblStatus.TabIndex = 357;
            this.lblStatus.Text = "Finalizando Venda . . . ";
            // 
            // txtTotalGeralVendaBruto
            // 
            this.txtTotalGeralVendaBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalGeralVendaBruto.AutoSize = true;
            this.txtTotalGeralVendaBruto.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalGeralVendaBruto.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalGeralVendaBruto.ForeColor = System.Drawing.Color.White;
            this.txtTotalGeralVendaBruto.Location = new System.Drawing.Point(642, 303);
            this.txtTotalGeralVendaBruto.Name = "txtTotalGeralVendaBruto";
            this.txtTotalGeralVendaBruto.Size = new System.Drawing.Size(220, 97);
            this.txtTotalGeralVendaBruto.TabIndex = 1;
            this.txtTotalGeralVendaBruto.Text = "0,00";
            // 
            // _Desconto
            // 
            this._Desconto.BackColor = System.Drawing.Color.White;
            this._Desconto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Desconto.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Desconto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._Desconto.Location = new System.Drawing.Point(390, 588);
            this._Desconto.Name = "_Desconto";
            this._Desconto.ReadOnly = true;
            this._Desconto.Size = new System.Drawing.Size(192, 53);
            this._Desconto.TabIndex = 6;
            this._Desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Desconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this._Desconto.Enter += new System.EventHandler(this.txtDesconto_Enter);
            this._Desconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesconto_KeyDown);
            this._Desconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesconto_KeyPress);
            // 
            // _Arrendodamento
            // 
            this._Arrendodamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Arrendodamento.Enabled = false;
            this._Arrendodamento.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Arrendodamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this._Arrendodamento.Location = new System.Drawing.Point(391, 667);
            this._Arrendodamento.Name = "_Arrendodamento";
            this._Arrendodamento.Size = new System.Drawing.Size(192, 53);
            this._Arrendodamento.TabIndex = 5;
            this._Arrendodamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Arrendodamento.TextChanged += new System.EventHandler(this.txtRevenda_TextChanged);
            this._Arrendodamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Revenda_KeyDown);
            this._Arrendodamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Revenda_KeyPress);
            // 
            // _CartaoDebito
            // 
            this._CartaoDebito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._CartaoDebito.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CartaoDebito.Location = new System.Drawing.Point(392, 434);
            this._CartaoDebito.Name = "_CartaoDebito";
            this._CartaoDebito.Size = new System.Drawing.Size(192, 53);
            this._CartaoDebito.TabIndex = 3;
            this._CartaoDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CartaoDebito.TextChanged += new System.EventHandler(this.txtCartaoDebito_TextChanged);
            this._CartaoDebito.KeyDown += new System.Windows.Forms.KeyEventHandler(this._CartaoDebito_KeyDown);
            this._CartaoDebito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._CartaoDebito_KeyPress);
            // 
            // _CartaoCredito
            // 
            this._CartaoCredito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._CartaoCredito.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CartaoCredito.Location = new System.Drawing.Point(392, 351);
            this._CartaoCredito.Name = "_CartaoCredito";
            this._CartaoCredito.Size = new System.Drawing.Size(192, 53);
            this._CartaoCredito.TabIndex = 2;
            this._CartaoCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._CartaoCredito.TextChanged += new System.EventHandler(this.txtCartaoCredito_TextChanged);
            this._CartaoCredito.KeyDown += new System.Windows.Forms.KeyEventHandler(this._CartaoCredito_KeyDown);
            this._CartaoCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._CartaoCredito_KeyPress);
            // 
            // _Dinheiro
            // 
            this._Dinheiro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Dinheiro.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Dinheiro.Location = new System.Drawing.Point(392, 270);
            this._Dinheiro.Name = "_Dinheiro";
            this._Dinheiro.Size = new System.Drawing.Size(191, 56);
            this._Dinheiro.TabIndex = 1;
            this._Dinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Dinheiro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this._Dinheiro.VisibleChanged += new System.EventHandler(this._Dinheiro_VisibleChanged);
            this._Dinheiro.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Dinheiro_KeyDown);
            this._Dinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Dinheiro_KeyPress);
            // 
            // txtTotalRestante
            // 
            this.txtTotalRestante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRestante.AutoSize = true;
            this.txtTotalRestante.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalRestante.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRestante.ForeColor = System.Drawing.Color.White;
            this.txtTotalRestante.Location = new System.Drawing.Point(652, 642);
            this.txtTotalRestante.Name = "txtTotalRestante";
            this.txtTotalRestante.Size = new System.Drawing.Size(220, 97);
            this.txtTotalRestante.TabIndex = 2;
            this.txtTotalRestante.Text = "0,00";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 722);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1280, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFecharTela
            // 
            this.btnFecharTela.BackColor = System.Drawing.Color.Transparent;
            this.btnFecharTela.FlatAppearance.BorderSize = 0;
            this.btnFecharTela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharTela.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharTela.ForeColor = System.Drawing.Color.White;
            this.btnFecharTela.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharTela.Image")));
            this.btnFecharTela.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFecharTela.Location = new System.Drawing.Point(674, 9);
            this.btnFecharTela.Margin = new System.Windows.Forms.Padding(1);
            this.btnFecharTela.Name = "btnFecharTela";
            this.btnFecharTela.Size = new System.Drawing.Size(154, 23);
            this.btnFecharTela.TabIndex = 355;
            this.btnFecharTela.TabStop = false;
            this.btnFecharTela.Text = " F12 - Fechar";
            this.btnFecharTela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFecharTela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharTela.UseVisualStyleBackColor = false;
            this.btnFecharTela.Visible = false;
            // 
            // btF2
            // 
            this.btF2.BackColor = System.Drawing.Color.Transparent;
            this.btF2.FlatAppearance.BorderSize = 0;
            this.btF2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btF2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btF2.ForeColor = System.Drawing.Color.White;
            this.btF2.Image = ((System.Drawing.Image)(resources.GetObject("btF2.Image")));
            this.btF2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btF2.Location = new System.Drawing.Point(44, 4);
            this.btF2.Margin = new System.Windows.Forms.Padding(1);
            this.btF2.Name = "btF2";
            this.btF2.Size = new System.Drawing.Size(154, 35);
            this.btF2.TabIndex = 353;
            this.btF2.TabStop = false;
            this.btF2.Text = " F2 - Finalizar";
            this.btF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btF2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btF2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(352, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 35);
            this.button3.TabIndex = 358;
            this.button3.TabStop = false;
            this.button3.Text = " F4 - Desconto";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.Location = new System.Drawing.Point(506, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 35);
            this.button2.TabIndex = 357;
            this.button2.TabStop = false;
            this.button2.Text = "ESC - Voltar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(198, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 35);
            this.button1.TabIndex = 356;
            this.button1.TabStop = false;
            this.button1.Text = " F3 - Limpar Tudo";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPago.AutoSize = true;
            this.lblTotalPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPago.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.ForeColor = System.Drawing.Color.White;
            this.lblTotalPago.Location = new System.Drawing.Point(652, 474);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(220, 97);
            this.lblTotalPago.TabIndex = 360;
            this.lblTotalPago.Text = "0,00";
            // 
            // _Cheque
            // 
            this._Cheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Cheque.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Cheque.Location = new System.Drawing.Point(391, 508);
            this._Cheque.Name = "_Cheque";
            this._Cheque.Size = new System.Drawing.Size(191, 53);
            this._Cheque.TabIndex = 4;
            this._Cheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._Cheque.TextChanged += new System.EventHandler(this.txtCheque_TextChanged);
            this._Cheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this._Cheque_KeyDown);
            this._Cheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Cheque_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(214, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1071, 97);
            this.label1.TabIndex = 361;
            this.label1.Text = "Obrigado e Volte Sempre!";
            // 
            // frmFinalizadora__PDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 747);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnFecharTela);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblTotalPago);
            this.Controls.Add(this.txtTotalRestante);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTotalGeralVendaBruto);
            this.Controls.Add(this.btF2);
            this.Controls.Add(this._Arrendodamento);
            this.Controls.Add(this._Dinheiro);
            this.Controls.Add(this._Desconto);
            this.Controls.Add(this._Cheque);
            this.Controls.Add(this._CartaoDebito);
            this.Controls.Add(this._CartaoCredito);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmFinalizadora__PDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmFinalizadora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFinalizadora_KeyDown);
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlFormasPagamento.ResumeLayout(false);
            this.pnlReveda.ResumeLayout(false);
            this.pnlReveda.PerformLayout();
            this.pnlCheque.ResumeLayout(false);
            this.pnlCheque.PerformLayout();
            this.pnlDesconto.ResumeLayout(false);
            this.pnlDesconto.PerformLayout();
            this.pnlCartaoDebito.ResumeLayout(false);
            this.pnlCartaoDebito.PerformLayout();
            this.pnlCartaoCredito.ResumeLayout(false);
            this.pnlCartaoCredito.PerformLayout();
            this.pnlDinheiro.ResumeLayout(false);
            this.pnlDinheiro.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlFormasPagamento;
        private System.Windows.Forms.Panel pnlDinheiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlReveda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlCheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlCartaoDebito;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlCartaoCredito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _Arrendodamento;
        private System.Windows.Forms.TextBox _CartaoDebito;
        private System.Windows.Forms.TextBox _CartaoCredito;
        private System.Windows.Forms.TextBox _Dinheiro;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel pnlDesconto;
        private System.Windows.Forms.TextBox _Desconto;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label txtTotalGeralVendaBruto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button btnFecharTela;
        public System.Windows.Forms.Button btF2;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
        public System.Windows.Forms.ToolStripStatusLabel txtVendaID;
        public System.Windows.Forms.Label txtTotalRestante;
        public System.Windows.Forms.ToolStripStatusLabel lblCodigoAbertura;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        public System.Windows.Forms.ToolStripStatusLabel lblCodigoCliente;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.TextBox _Cheque;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
    }
}