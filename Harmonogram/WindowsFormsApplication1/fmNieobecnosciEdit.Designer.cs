namespace WindowsFormsApplication1
{
    partial class fmNieobecnosciEdit
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
            this.dtpDataOd = new System.Windows.Forms.DateTimePicker();
            this.cbTyp = new System.Windows.Forms.ComboBox();
            this.chbZatwierdzone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataDo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cbPracownicy
            // 
            this.cbPracownicy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPracownicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPracownicy.FormattingEnabled = true;
            this.cbPracownicy.Location = new System.Drawing.Point(264, 36);
            this.cbPracownicy.Name = "cbPracownicy";
            this.cbPracownicy.Size = new System.Drawing.Size(294, 28);
            this.cbPracownicy.TabIndex = 3;
            // 
            // dtpDataOd
            // 
            this.dtpDataOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDataOd.Location = new System.Drawing.Point(264, 99);
            this.dtpDataOd.Name = "dtpDataOd";
            this.dtpDataOd.Size = new System.Drawing.Size(128, 26);
            this.dtpDataOd.TabIndex = 4;
            // 
            // cbTyp
            // 
            this.cbTyp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTyp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbTyp.FormattingEnabled = true;
            this.cbTyp.Items.AddRange(new object[] {
            "Urlop",
            "Choroba",
            "Wyjazd",
            "Szkolenie"});
            this.cbTyp.Location = new System.Drawing.Point(264, 157);
            this.cbTyp.Name = "cbTyp";
            this.cbTyp.Size = new System.Drawing.Size(294, 28);
            this.cbTyp.TabIndex = 5;
            // 
            // chbZatwierdzone
            // 
            this.chbZatwierdzone.AutoSize = true;
            this.chbZatwierdzone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbZatwierdzone.Location = new System.Drawing.Point(264, 222);
            this.chbZatwierdzone.Name = "chbZatwierdzone";
            this.chbZatwierdzone.Size = new System.Drawing.Size(130, 24);
            this.chbZatwierdzone.TabIndex = 6;
            this.chbZatwierdzone.Text = "Zatwierdzone";
            this.chbZatwierdzone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(67, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pracownik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(67, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Okres nieobecności";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(67, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Przyczyna";
            // 
            // dtpDataDo
            // 
            this.dtpDataDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDataDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDataDo.Location = new System.Drawing.Point(430, 98);
            this.dtpDataDo.Name = "dtpDataDo";
            this.dtpDataDo.Size = new System.Drawing.Size(128, 26);
            this.dtpDataDo.TabIndex = 10;
            // 
            // fmNieobecnosciEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(590, 313);
            this.Controls.Add(this.dtpDataDo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbZatwierdzone);
            this.Controls.Add(this.cbTyp);
            this.Controls.Add(this.dtpDataOd);
            this.Controls.Add(this.cbPracownicy);
            this.MaximumSize = new System.Drawing.Size(608, 360);
            this.MinimumSize = new System.Drawing.Size(608, 360);
            this.Name = "fmNieobecnosciEdit";
            this.Controls.SetChildIndex(this.cbPracownicy, 0);
            this.Controls.SetChildIndex(this.dtpDataOd, 0);
            this.Controls.SetChildIndex(this.cbTyp, 0);
            this.Controls.SetChildIndex(this.chbZatwierdzone, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpDataDo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPracownicy;
        private System.Windows.Forms.DateTimePicker dtpDataOd;
        private System.Windows.Forms.ComboBox cbTyp;
        private System.Windows.Forms.CheckBox chbZatwierdzone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataDo;
    }
}
