namespace WindowsFormsApplication1
{
    partial class fmStatystyki
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
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 387);
            this.panel1.Size = new System.Drawing.Size(1103, 32);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Size = new System.Drawing.Size(1103, 336);
            // 
            // btnUsun
            // 
            this.btnUsun.Visible = false;
            // 
            // btnModyfikuj
            // 
            this.btnModyfikuj.Visible = false;
            this.btnModyfikuj.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Visible = false;
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(3125, 6);
            // 
            // dtpDay
            // 
            this.dtpDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDay.Location = new System.Drawing.Point(100, 0);
            this.dtpDay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.ShowCheckBox = true;
            this.dtpDay.Size = new System.Drawing.Size(195, 26);
            this.dtpDay.TabIndex = 3;
            this.dtpDay.ValueChanged += new System.EventHandler(this.dtpDay_ValueChanged);
            // 
            // fmStatystyki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 419);
            this.Controls.Add(this.dtpDay);
            this.MinimumSize = new System.Drawing.Size(300, 207);
            this.Name = "fmStatystyki";
            this.Text = "Statystyki";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmStatystyki_Load);
            this.Shown += new System.EventHandler(this.fmStatystyki_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dtpDay, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDay;
    }
}