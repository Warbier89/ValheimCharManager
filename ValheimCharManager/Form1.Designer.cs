namespace ValheimCharManager
{
    partial class fr_main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb_localChar = new System.Windows.Forms.GroupBox();
            this.lb_mainChar = new System.Windows.Forms.Label();
            this.cb_mainChar = new System.Windows.Forms.ComboBox();
            this.tc_builds = new System.Windows.Forms.TabControl();
            this.tp_chooseBuild = new System.Windows.Forms.TabPage();
            this.tp_createBuild = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gb_localChar.SuspendLayout();
            this.tc_builds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.tc_builds);
            this.panel1.Controls.Add(this.gb_localChar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 214);
            this.panel1.TabIndex = 0;
            // 
            // gb_localChar
            // 
            this.gb_localChar.Controls.Add(this.pictureBox1);
            this.gb_localChar.Controls.Add(this.lb_mainChar);
            this.gb_localChar.Controls.Add(this.cb_mainChar);
            this.gb_localChar.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_localChar.ForeColor = System.Drawing.Color.White;
            this.gb_localChar.Location = new System.Drawing.Point(12, 12);
            this.gb_localChar.Name = "gb_localChar";
            this.gb_localChar.Size = new System.Drawing.Size(416, 69);
            this.gb_localChar.TabIndex = 0;
            this.gb_localChar.TabStop = false;
            this.gb_localChar.Text = "Local Charakter";
            // 
            // lb_mainChar
            // 
            this.lb_mainChar.AutoSize = true;
            this.lb_mainChar.Location = new System.Drawing.Point(7, 21);
            this.lb_mainChar.Name = "lb_mainChar";
            this.lb_mainChar.Size = new System.Drawing.Size(241, 13);
            this.lb_mainChar.TabIndex = 1;
            this.lb_mainChar.Text = "Choose your main character";
            // 
            // cb_mainChar
            // 
            this.cb_mainChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_mainChar.FormattingEnabled = true;
            this.cb_mainChar.Location = new System.Drawing.Point(10, 37);
            this.cb_mainChar.Name = "cb_mainChar";
            this.cb_mainChar.Size = new System.Drawing.Size(276, 21);
            this.cb_mainChar.TabIndex = 0;
            // 
            // tc_builds
            // 
            this.tc_builds.Controls.Add(this.tp_chooseBuild);
            this.tc_builds.Controls.Add(this.tp_createBuild);
            this.tc_builds.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold);
            this.tc_builds.Location = new System.Drawing.Point(12, 87);
            this.tc_builds.Name = "tc_builds";
            this.tc_builds.SelectedIndex = 0;
            this.tc_builds.Size = new System.Drawing.Size(416, 115);
            this.tc_builds.TabIndex = 1;
            // 
            // tp_chooseBuild
            // 
            this.tp_chooseBuild.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tp_chooseBuild.ForeColor = System.Drawing.Color.White;
            this.tp_chooseBuild.Location = new System.Drawing.Point(4, 23);
            this.tp_chooseBuild.Name = "tp_chooseBuild";
            this.tp_chooseBuild.Padding = new System.Windows.Forms.Padding(3);
            this.tp_chooseBuild.Size = new System.Drawing.Size(408, 88);
            this.tp_chooseBuild.TabIndex = 0;
            this.tp_chooseBuild.Text = "Choose Build";
            // 
            // tp_createBuild
            // 
            this.tp_createBuild.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tp_createBuild.ForeColor = System.Drawing.Color.White;
            this.tp_createBuild.Location = new System.Drawing.Point(4, 23);
            this.tp_createBuild.Name = "tp_createBuild";
            this.tp_createBuild.Padding = new System.Windows.Forms.Padding(3);
            this.tp_createBuild.Size = new System.Drawing.Size(401, 88);
            this.tp_createBuild.TabIndex = 1;
            this.tp_createBuild.Text = "Create Build";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(373, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // fr_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 214);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fr_main";
            this.Text = "Valheim Charakter Mangaer";
            this.panel1.ResumeLayout(false);
            this.gb_localChar.ResumeLayout(false);
            this.gb_localChar.PerformLayout();
            this.tc_builds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gb_localChar;
        private System.Windows.Forms.Label lb_mainChar;
        private System.Windows.Forms.ComboBox cb_mainChar;
        private System.Windows.Forms.TabControl tc_builds;
        private System.Windows.Forms.TabPage tp_chooseBuild;
        private System.Windows.Forms.TabPage tp_createBuild;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

