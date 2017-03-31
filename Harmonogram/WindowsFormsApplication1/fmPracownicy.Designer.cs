namespace WindowsFormsApplication1
{
    partial class fmPracownicy
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 230);
            this.panel1.Size = new System.Drawing.Size(447, 32);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(447, 206);
            // 
            // btnModyfikuj
            // 
            this.btnModyfikuj.Click += new System.EventHandler(this.btnModyfikuj_Click_1);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click_1);
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(370, 6);
            // 
            // fmPracownicy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(447, 262);
            this.MinimumSize = new System.Drawing.Size(300, 207);
            this.Name = "fmPracownicy";
            this.Text = "Pracownicy";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
