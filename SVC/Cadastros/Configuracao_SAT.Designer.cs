namespace One.Cadastros
{
    partial class Configuracao_SAT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracao_SAT));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_sat = new System.Windows.Forms.Panel();
            this.cbSelecioner_Vendedor = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbPDVAtacado = new System.Windows.Forms.CheckBox();
            this.panel_sat.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Configurar SAT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Testar Cupom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sincronizar";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel_sat
            // 
            this.panel_sat.Controls.Add(this.cbPDVAtacado);
            this.panel_sat.Controls.Add(this.cbSelecioner_Vendedor);
            this.panel_sat.Controls.Add(this.button5);
            this.panel_sat.Controls.Add(this.textBox1);
            this.panel_sat.Controls.Add(this.label7);
            this.panel_sat.Location = new System.Drawing.Point(12, 152);
            this.panel_sat.Name = "panel_sat";
            this.panel_sat.Size = new System.Drawing.Size(447, 201);
            this.panel_sat.TabIndex = 9;
            // 
            // cbSelecioner_Vendedor
            // 
            this.cbSelecioner_Vendedor.AutoSize = true;
            this.cbSelecioner_Vendedor.Location = new System.Drawing.Point(16, 80);
            this.cbSelecioner_Vendedor.Name = "cbSelecioner_Vendedor";
            this.cbSelecioner_Vendedor.Size = new System.Drawing.Size(282, 21);
            this.cbSelecioner_Vendedor.TabIndex = 5;
            this.cbSelecioner_Vendedor.Text = "Selecionar Vendedor ao Final da Venda";
            this.cbSelecioner_Vendedor.UseVisualStyleBackColor = true;
            this.cbSelecioner_Vendedor.CheckedChanged += new System.EventHandler(this.cbSelecioner_Vendedor_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(364, 34);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 28);
            this.button5.TabIndex = 4;
            this.button5.Text = "Pesquisar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(342, 22);
            this.textBox1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Caminho ACBR";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(64, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 88);
            this.button4.TabIndex = 7;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(323, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 88);
            this.button2.TabIndex = 2;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(195, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 88);
            this.button1.TabIndex = 0;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbPDVAtacado
            // 
            this.cbPDVAtacado.AutoSize = true;
            this.cbPDVAtacado.Location = new System.Drawing.Point(16, 107);
            this.cbPDVAtacado.Name = "cbPDVAtacado";
            this.cbPDVAtacado.Size = new System.Drawing.Size(180, 21);
            this.cbPDVAtacado.TabIndex = 6;
            this.cbPDVAtacado.Text = "Opção Atacado no PDV";
            this.cbPDVAtacado.UseVisualStyleBackColor = true;
            this.cbPDVAtacado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Configuracao_SAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 365);
            this.Controls.Add(this.panel_sat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Configuracao_SAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracao_SAT";
            this.Load += new System.EventHandler(this.Configuracao_SAT_Load);
            this.panel_sat.ResumeLayout(false);
            this.panel_sat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel_sat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbSelecioner_Vendedor;
        private System.Windows.Forms.CheckBox cbPDVAtacado;
    }
}