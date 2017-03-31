namespace WindowsFormsApplication1
{
    partial class fmHarmonogram
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
            this.btnGeneruj = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGeneruj);
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Size = new System.Drawing.Size(623, 36);
            this.panel1.Controls.SetChildIndex(this.btnDodaj, 0);
            this.panel1.Controls.SetChildIndex(this.btnModyfikuj, 0);
            this.panel1.Controls.SetChildIndex(this.btnUsun, 0);
            this.panel1.Controls.SetChildIndex(this.btnAnuluj, 0);
            this.panel1.Controls.SetChildIndex(this.btnGeneruj, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(623, 220);
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(192, 6);
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(756, 8);
            // 
            // btnGeneruj
            // 
            this.btnGeneruj.Location = new System.Drawing.Point(300, 6);
            this.btnGeneruj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGeneruj.Name = "btnGeneruj";
            this.btnGeneruj.Size = new System.Drawing.Size(59, 19);
            this.btnGeneruj.TabIndex = 4;
            this.btnGeneruj.Text = "Generuj";
            this.btnGeneruj.UseVisualStyleBackColor = true;
            this.btnGeneruj.Click += new System.EventHandler(this.btnGeneruj_Click);
            // 
            // fmHarmonogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(623, 280);
            this.MinimumSize = new System.Drawing.Size(300, 207);
            this.Name = "fmHarmonogram";
            this.Text = "Harmonogram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.fmHarmonogram_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneruj;
    }
}
