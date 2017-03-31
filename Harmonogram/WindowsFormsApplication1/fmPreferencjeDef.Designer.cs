namespace WindowsFormsApplication1
{
    partial class fmPreferencjeDef
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
            this.components = new System.ComponentModel.Container();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.chklbDniTygodnia = new System.Windows.Forms.CheckedListBox();
            this.cbPracownicy = new System.Windows.Forms.ComboBox();
            this.numudPreferencje1 = new System.Windows.Forms.NumericUpDown();
            this.numudPreferencje2 = new System.Windows.Forms.NumericUpDown();
            this.numudPreferencje4 = new System.Windows.Forms.NumericUpDown();
            this.numudPreferencje3 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btUstaw = new System.Windows.Forms.Button();
            this.chkLosowo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpOd
            // 
            this.dtpOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOd.Location = new System.Drawing.Point(173, 111);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.ShowCheckBox = true;
            this.dtpOd.Size = new System.Drawing.Size(200, 30);
            this.dtpOd.TabIndex = 0;
            // 
            // dtpDo
            // 
            this.dtpDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDo.Location = new System.Drawing.Point(565, 111);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.ShowCheckBox = true;
            this.dtpDo.Size = new System.Drawing.Size(200, 30);
            this.dtpDo.TabIndex = 1;
            // 
            // chklbDniTygodnia
            // 
            this.chklbDniTygodnia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chklbDniTygodnia.FormattingEnabled = true;
            this.chklbDniTygodnia.Items.AddRange(new object[] {
            "Poniedziałek",
            "Wtorek",
            "Środa",
            "Czwartek",
            "Piątek"});
            this.chklbDniTygodnia.Location = new System.Drawing.Point(173, 187);
            this.chklbDniTygodnia.Name = "chklbDniTygodnia";
            this.chklbDniTygodnia.Size = new System.Drawing.Size(200, 129);
            this.chklbDniTygodnia.TabIndex = 2;
            // 
            // cbPracownicy
            // 
            this.cbPracownicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPracownicy.FormattingEnabled = true;
            this.cbPracownicy.Location = new System.Drawing.Point(173, 49);
            this.cbPracownicy.Name = "cbPracownicy";
            this.cbPracownicy.Size = new System.Drawing.Size(592, 37);
            this.cbPracownicy.TabIndex = 3;
            // 
            // numudPreferencje1
            // 
            this.numudPreferencje1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numudPreferencje1.Location = new System.Drawing.Point(690, 187);
            this.numudPreferencje1.Name = "numudPreferencje1";
            this.numudPreferencje1.Size = new System.Drawing.Size(75, 30);
            this.numudPreferencje1.TabIndex = 4;
            this.numudPreferencje1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numudPreferencje1.ValueChanged += new System.EventHandler(this.numudPreferencje1_ValueChanged);
            // 
            // numudPreferencje2
            // 
            this.numudPreferencje2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numudPreferencje2.Location = new System.Drawing.Point(690, 234);
            this.numudPreferencje2.Name = "numudPreferencje2";
            this.numudPreferencje2.Size = new System.Drawing.Size(75, 30);
            this.numudPreferencje2.TabIndex = 5;
            this.numudPreferencje2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numudPreferencje2.ValueChanged += new System.EventHandler(this.numudPreferencje2_ValueChanged);
            // 
            // numudPreferencje4
            // 
            this.numudPreferencje4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numudPreferencje4.Location = new System.Drawing.Point(690, 326);
            this.numudPreferencje4.Name = "numudPreferencje4";
            this.numudPreferencje4.Size = new System.Drawing.Size(75, 30);
            this.numudPreferencje4.TabIndex = 6;
            this.numudPreferencje4.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // numudPreferencje3
            // 
            this.numudPreferencje3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numudPreferencje3.Location = new System.Drawing.Point(690, 281);
            this.numudPreferencje3.Name = "numudPreferencje3";
            this.numudPreferencje3.Size = new System.Drawing.Size(75, 30);
            this.numudPreferencje3.TabIndex = 7;
            this.numudPreferencje3.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numudPreferencje3.ValueChanged += new System.EventHandler(this.numudPreferencje3_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btUstaw);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 41);
            this.panel1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(714, 9);
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
            this.btUstaw.Text = "Ustaw";
            this.btUstaw.UseVisualStyleBackColor = true;
            this.btUstaw.Click += new System.EventHandler(this.btUstaw_Click);
            // 
            // chkLosowo
            // 
            this.chkLosowo.AutoSize = true;
            this.chkLosowo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chkLosowo.Location = new System.Drawing.Point(676, 378);
            this.chkLosowo.Name = "chkLosowo";
            this.chkLosowo.Size = new System.Drawing.Size(89, 24);
            this.chkLosowo.TabIndex = 11;
            this.chkLosowo.Text = "Losowo";
            this.chkLosowo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(563, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "07:00 - 15:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(563, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "08:00 - 16:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(563, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "09:00 - 17:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(561, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "10:00 - 18:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(28, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pracownik";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(28, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Data od";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(452, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Data do";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(28, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Dni tygodnia";
            // 
            // fmPreferencjeDef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 469);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLosowo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.numudPreferencje3);
            this.Controls.Add(this.numudPreferencje4);
            this.Controls.Add(this.numudPreferencje2);
            this.Controls.Add(this.numudPreferencje1);
            this.Controls.Add(this.cbPracownicy);
            this.Controls.Add(this.chklbDniTygodnia);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(856, 516);
            this.MinimumSize = new System.Drawing.Size(856, 516);
            this.Name = "fmPreferencjeDef";
            this.Text = "Preferencje";
            this.Load += new System.EventHandler(this.fmPreferencjeDef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudPreferencje3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.CheckedListBox chklbDniTygodnia;
        private System.Windows.Forms.ComboBox cbPracownicy;
        private System.Windows.Forms.NumericUpDown numudPreferencje1;
        private System.Windows.Forms.NumericUpDown numudPreferencje2;
        private System.Windows.Forms.NumericUpDown numudPreferencje4;
        private System.Windows.Forms.NumericUpDown numudPreferencje3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btUstaw;
        private System.Windows.Forms.CheckBox chkLosowo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}