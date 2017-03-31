namespace WindowsFormsApplication1
{
    partial class fmHarmonogramEdit
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
            this.cbDniRobocze = new System.Windows.Forms.ComboBox();
            this.cbDyzury = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPracownicy
            // 
            this.cbPracownicy.FormattingEnabled = true;
            this.cbPracownicy.Location = new System.Drawing.Point(154, 49);
            this.cbPracownicy.Name = "cbPracownicy";
            this.cbPracownicy.Size = new System.Drawing.Size(280, 24);
            this.cbPracownicy.TabIndex = 5;
            // 
            // cbDniRobocze
            // 
            this.cbDniRobocze.FormattingEnabled = true;
            this.cbDniRobocze.Location = new System.Drawing.Point(154, 113);
            this.cbDniRobocze.Name = "cbDniRobocze";
            this.cbDniRobocze.Size = new System.Drawing.Size(280, 24);
            this.cbDniRobocze.TabIndex = 6;
            // 
            // cbDyzury
            // 
            this.cbDyzury.FormattingEnabled = true;
            this.cbDyzury.Items.AddRange(new object[] {
            "07:00 - 15:00",
            "08:00 - 16:00",
            "09:00 - 17:00",
            "10:00 - 18:00"});
            this.cbDyzury.Location = new System.Drawing.Point(154, 177);
            this.cbDyzury.Name = "cbDyzury";
            this.cbDyzury.Size = new System.Drawing.Size(280, 24);
            this.cbDyzury.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(36, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pracownik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(36, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dyżur";
            // 
            // fmHarmonogramEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(505, 321);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDyzury);
            this.Controls.Add(this.cbDniRobocze);
            this.Controls.Add(this.cbPracownicy);
            this.Name = "fmHarmonogramEdit";
            this.Text = "Harmonogram - edycja";
            this.Shown += new System.EventHandler(this.fmHarmonogramEdit_Shown);
            this.Controls.SetChildIndex(this.cbPracownicy, 0);
            this.Controls.SetChildIndex(this.cbDniRobocze, 0);
            this.Controls.SetChildIndex(this.cbDyzury, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbPracownicy;
        private System.Windows.Forms.ComboBox cbDniRobocze;
        private System.Windows.Forms.ComboBox cbDyzury;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
