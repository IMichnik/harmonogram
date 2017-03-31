namespace WindowsFormsApplication1
{
    partial class fmDzienRoboczyEdit
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbDniRobocze = new System.Windows.Forms.ComboBox();
            this.chbRoboczy = new System.Windows.Forms.CheckBox();
            this.chbUstalone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(62, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data";
            // 
            // cbDniRobocze
            // 
            this.cbDniRobocze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDniRobocze.FormattingEnabled = true;
            this.cbDniRobocze.Location = new System.Drawing.Point(180, 55);
            this.cbDniRobocze.Name = "cbDniRobocze";
            this.cbDniRobocze.Size = new System.Drawing.Size(304, 24);
            this.cbDniRobocze.TabIndex = 10;
            // 
            // chbRoboczy
            // 
            this.chbRoboczy.AutoSize = true;
            this.chbRoboczy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbRoboczy.Location = new System.Drawing.Point(66, 137);
            this.chbRoboczy.Name = "chbRoboczy";
            this.chbRoboczy.Size = new System.Drawing.Size(139, 24);
            this.chbRoboczy.TabIndex = 12;
            this.chbRoboczy.Text = "Dzień roboczy";
            this.chbRoboczy.UseVisualStyleBackColor = true;
            // 
            // chbUstalone
            // 
            this.chbUstalone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbUstalone.AutoSize = true;
            this.chbUstalone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbUstalone.Location = new System.Drawing.Point(342, 137);
            this.chbUstalone.Name = "chbUstalone";
            this.chbUstalone.Size = new System.Drawing.Size(142, 24);
            this.chbUstalone.TabIndex = 13;
            this.chbUstalone.Text = "Ustalony grafik";
            this.chbUstalone.UseVisualStyleBackColor = true;
            // 
            // fmDzienRoboczyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(562, 270);
            this.Controls.Add(this.chbUstalone);
            this.Controls.Add(this.chbRoboczy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDniRobocze);
            this.MinimumSize = new System.Drawing.Size(580, 317);
            this.Name = "fmDzienRoboczyEdit";
            this.Text = "Dzień roboczy - edycja";
            this.Controls.SetChildIndex(this.cbDniRobocze, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.chbRoboczy, 0);
            this.Controls.SetChildIndex(this.chbUstalone, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDniRobocze;
        private System.Windows.Forms.CheckBox chbRoboczy;
        private System.Windows.Forms.CheckBox chbUstalone;
    }
}
