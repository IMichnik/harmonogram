namespace WindowsFormsApplication1
{
    partial class fmGenerate
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
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btUstaw = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDo
            // 
            this.dtpDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDo.Location = new System.Drawing.Point(308, 46);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.ShowCheckBox = true;
            this.dtpDo.Size = new System.Drawing.Size(200, 30);
            this.dtpDo.TabIndex = 3;
            // 
            // dtpOd
            // 
            this.dtpOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOd.Location = new System.Drawing.Point(38, 46);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.ShowCheckBox = true;
            this.dtpOd.Size = new System.Drawing.Size(200, 30);
            this.dtpOd.TabIndex = 2;
            this.dtpOd.ValueChanged += new System.EventHandler(this.dtpOd_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btUstaw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 41);
            this.panel1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(424, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zamknij";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btUstaw
            // 
            this.btUstaw.Location = new System.Drawing.Point(49, 9);
            this.btUstaw.Name = "btUstaw";
            this.btUstaw.Size = new System.Drawing.Size(75, 23);
            this.btUstaw.TabIndex = 0;
            this.btUstaw.Text = "Start";
            this.btUstaw.UseVisualStyleBackColor = true;
            this.btUstaw.Click += new System.EventHandler(this.btUstaw_Click);
            // 
            // fmGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 152);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.dtpOd);
            this.Name = "fmGenerate";
            this.Text = "Generowanie harmonogramu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btUstaw;
    }
}