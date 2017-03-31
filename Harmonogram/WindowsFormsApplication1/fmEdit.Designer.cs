namespace WindowsFormsApplication1
{
    partial class fmEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZamknij = new System.Windows.Forms.Button();
            this.btnZapiszZamknij = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnZamknij);
            this.panel1.Controls.Add(this.btnZapiszZamknij);
            this.panel1.Controls.Add(this.btnZapisz);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 46);
            this.panel1.TabIndex = 2;
            // 
            // btnZamknij
            // 
            this.btnZamknij.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnZamknij.Location = new System.Drawing.Point(596, 12);
            this.btnZamknij.Name = "btnZamknij";
            this.btnZamknij.Size = new System.Drawing.Size(75, 25);
            this.btnZamknij.TabIndex = 2;
            this.btnZamknij.Text = "Zamknij";
            this.btnZamknij.UseVisualStyleBackColor = true;
            this.btnZamknij.Click += new System.EventHandler(this.btnZamknij_Click);
            // 
            // btnZapiszZamknij
            // 
            this.btnZapiszZamknij.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnZapiszZamknij.Location = new System.Drawing.Point(12, 12);
            this.btnZapiszZamknij.Name = "btnZapiszZamknij";
            this.btnZapiszZamknij.Size = new System.Drawing.Size(134, 25);
            this.btnZapiszZamknij.TabIndex = 1;
            this.btnZapiszZamknij.Text = "Zapisz i zamknij";
            this.btnZapiszZamknij.UseVisualStyleBackColor = true;
            this.btnZapiszZamknij.Click += new System.EventHandler(this.btnZapiszZamknij_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnZapisz.Location = new System.Drawing.Point(154, 12);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(75, 25);
            this.btnZapisz.TabIndex = 0;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // fmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 466);
            this.Controls.Add(this.panel1);
            this.Name = "fmEdit";
            this.Text = "Forma edycyjna";
            this.Shown += new System.EventHandler(this.fmEdit_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnZamknij;
        private System.Windows.Forms.Button btnZapiszZamknij;
        private System.Windows.Forms.Button btnZapisz;
    }
}