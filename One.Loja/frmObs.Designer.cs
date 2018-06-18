namespace One.Loja
{
    partial class frmObs
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
            this.txtobs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtobs
            // 
            this.txtobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtobs.Location = new System.Drawing.Point(0, 0);
            this.txtobs.Name = "txtobs";
            this.txtobs.Size = new System.Drawing.Size(440, 262);
            this.txtobs.TabIndex = 0;
            this.txtobs.Text = "";
            // 
            // frmObs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 262);
            this.Controls.Add(this.txtobs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObs";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtobs;
    }
}