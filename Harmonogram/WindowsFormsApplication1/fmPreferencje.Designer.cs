namespace WindowsFormsApplication1
{
    partial class fmPreferencje
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
            this.cbPracownicy = new System.Windows.Forms.ComboBox();
            this.btnDefine = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDefine);
            this.panel1.Location = new System.Drawing.Point(0, 248);
            this.panel1.Size = new System.Drawing.Size(605, 32);
            this.panel1.Controls.SetChildIndex(this.btnDodaj, 0);
            this.panel1.Controls.SetChildIndex(this.btnModyfikuj, 0);
            this.panel1.Controls.SetChildIndex(this.btnUsun, 0);
            this.panel1.Controls.SetChildIndex(this.btnAnuluj, 0);
            this.panel1.Controls.SetChildIndex(this.btnDefine, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Size = new System.Drawing.Size(605, 197);
            // 
            // btnUsun
            // 
            this.btnUsun.Size = new System.Drawing.Size(65, 20);
            this.btnUsun.Visible = false;
            // 
            // btnModyfikuj
            // 
            this.btnModyfikuj.Size = new System.Drawing.Size(65, 20);
            this.btnModyfikuj.Visible = false;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Size = new System.Drawing.Size(47, 19);
            this.btnDodaj.Text = "Definiuj";
            this.btnDodaj.Visible = false;
            this.btnDodaj.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(744, 6);
            this.btnAnuluj.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbPracownicy
            // 
            this.cbPracownicy.FormattingEnabled = true;
            this.cbPracownicy.Location = new System.Drawing.Point(174, 1);
            this.cbPracownicy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPracownicy.Name = "cbPracownicy";
            this.cbPracownicy.Size = new System.Drawing.Size(156, 21);
            this.cbPracownicy.TabIndex = 3;
            this.cbPracownicy.SelectedIndexChanged += new System.EventHandler(this.cbPracownicy_SelectedIndexChanged);
            // 
            // btnDefine
            // 
            this.btnDefine.Location = new System.Drawing.Point(21, 6);
            this.btnDefine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDefine.Name = "btnDefine";
            this.btnDefine.Size = new System.Drawing.Size(56, 20);
            this.btnDefine.TabIndex = 4;
            this.btnDefine.Text = "Definiuj";
            this.btnDefine.UseVisualStyleBackColor = true;
            this.btnDefine.Click += new System.EventHandler(this.btnDefine_Click);
            // 
            // fmPreferencje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(605, 280);
            this.Controls.Add(this.cbPracownicy);
            this.MinimumSize = new System.Drawing.Size(300, 207);
            this.Name = "fmPreferencje";
            this.Text = "Preferencje";
            this.Shown += new System.EventHandler(this.fmPreferencje_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.cbPracownicy, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPracownicy;
        private System.Windows.Forms.Button btnDefine;
    }
}
