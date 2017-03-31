namespace WindowsFormsApplication1
{
    partial class fmDniRobocze
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
            this.btnGenerujGrafik = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenerujGrafik);
            this.panel1.Location = new System.Drawing.Point(0, 232);
            this.panel1.Size = new System.Drawing.Size(741, 32);
            this.panel1.Controls.SetChildIndex(this.btnDodaj, 0);
            this.panel1.Controls.SetChildIndex(this.btnModyfikuj, 0);
            this.panel1.Controls.SetChildIndex(this.btnUsun, 0);
            this.panel1.Controls.SetChildIndex(this.btnAnuluj, 0);
            this.panel1.Controls.SetChildIndex(this.btnGenerujGrafik, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(741, 208);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Visible = false;
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(1013, 6);
            // 
            // btnGenerujGrafik
            // 
            this.btnGenerujGrafik.Location = new System.Drawing.Point(30, 6);
            this.btnGenerujGrafik.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerujGrafik.Name = "btnGenerujGrafik";
            this.btnGenerujGrafik.Size = new System.Drawing.Size(56, 19);
            this.btnGenerujGrafik.TabIndex = 4;
            this.btnGenerujGrafik.Text = "Generuj grafik";
            this.btnGenerujGrafik.UseVisualStyleBackColor = true;
            this.btnGenerujGrafik.Click += new System.EventHandler(this.btnGenerujGrafik_Click);
            // 
            // fmDniRobocze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(741, 264);
            this.MinimumSize = new System.Drawing.Size(300, 207);
            this.Name = "fmDniRobocze";
            this.Text = "Dni robocze";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerujGrafik;
    }
}
