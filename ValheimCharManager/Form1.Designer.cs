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
            this.tc_builds = new System.Windows.Forms.TabControl();
            this.tp_chooseBuild = new System.Windows.Forms.TabPage();
            this.bt_switchBuild = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cb_chosseBuild = new System.Windows.Forms.ComboBox();
            this.lb_chooseBuild = new System.Windows.Forms.Label();
            this.tp_createBuild = new System.Windows.Forms.TabPage();
            this.lb_defineBuild = new System.Windows.Forms.Label();
            this.gb_localChar = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_mainChar = new System.Windows.Forms.Label();
            this.cb_mainChar = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tb_buildName = new System.Windows.Forms.TextBox();
            this.bt_saveBuild = new System.Windows.Forms.Button();
            this.pb_folder = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tc_builds.SuspendLayout();
            this.tp_chooseBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tp_createBuild.SuspendLayout();
            this.gb_localChar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(350, 258);
            this.panel1.TabIndex = 0;
            // 
            // tc_builds
            // 
            this.tc_builds.Controls.Add(this.tp_chooseBuild);
            this.tc_builds.Controls.Add(this.tp_createBuild);
            this.tc_builds.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold);
            this.tc_builds.Location = new System.Drawing.Point(12, 98);
            this.tc_builds.Name = "tc_builds";
            this.tc_builds.SelectedIndex = 0;
            this.tc_builds.Size = new System.Drawing.Size(330, 148);
            this.tc_builds.TabIndex = 1;
            // 
            // tp_chooseBuild
            // 
            this.tp_chooseBuild.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tp_chooseBuild.Controls.Add(this.bt_switchBuild);
            this.tp_chooseBuild.Controls.Add(this.pictureBox2);
            this.tp_chooseBuild.Controls.Add(this.cb_chosseBuild);
            this.tp_chooseBuild.Controls.Add(this.lb_chooseBuild);
            this.tp_chooseBuild.ForeColor = System.Drawing.Color.White;
            this.tp_chooseBuild.Location = new System.Drawing.Point(4, 23);
            this.tp_chooseBuild.Name = "tp_chooseBuild";
            this.tp_chooseBuild.Padding = new System.Windows.Forms.Padding(3);
            this.tp_chooseBuild.Size = new System.Drawing.Size(322, 121);
            this.tp_chooseBuild.TabIndex = 0;
            this.tp_chooseBuild.Text = "Choose Build";
            // 
            // bt_switchBuild
            // 
            this.bt_switchBuild.BackColor = System.Drawing.Color.DarkCyan;
            this.bt_switchBuild.Image = ((System.Drawing.Image)(resources.GetObject("bt_switchBuild.Image")));
            this.bt_switchBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_switchBuild.Location = new System.Drawing.Point(66, 55);
            this.bt_switchBuild.Name = "bt_switchBuild";
            this.bt_switchBuild.Size = new System.Drawing.Size(214, 47);
            this.bt_switchBuild.TabIndex = 4;
            this.bt_switchBuild.Text = "Switch Build";
            this.bt_switchBuild.UseVisualStyleBackColor = false;
            this.bt_switchBuild.Click += new System.EventHandler(this.bt_switchBuild_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // cb_chosseBuild
            // 
            this.cb_chosseBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_chosseBuild.FormattingEnabled = true;
            this.cb_chosseBuild.Location = new System.Drawing.Point(44, 23);
            this.cb_chosseBuild.Name = "cb_chosseBuild";
            this.cb_chosseBuild.Size = new System.Drawing.Size(272, 21);
            this.cb_chosseBuild.TabIndex = 3;
            // 
            // lb_chooseBuild
            // 
            this.lb_chooseBuild.AutoSize = true;
            this.lb_chooseBuild.Location = new System.Drawing.Point(6, 3);
            this.lb_chooseBuild.Name = "lb_chooseBuild";
            this.lb_chooseBuild.Size = new System.Drawing.Size(160, 13);
            this.lb_chooseBuild.TabIndex = 2;
            this.lb_chooseBuild.Text = "Choose your Build";
            // 
            // tp_createBuild
            // 
            this.tp_createBuild.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tp_createBuild.Controls.Add(this.bt_saveBuild);
            this.tp_createBuild.Controls.Add(this.tb_buildName);
            this.tp_createBuild.Controls.Add(this.pictureBox3);
            this.tp_createBuild.Controls.Add(this.lb_defineBuild);
            this.tp_createBuild.ForeColor = System.Drawing.Color.White;
            this.tp_createBuild.Location = new System.Drawing.Point(4, 23);
            this.tp_createBuild.Name = "tp_createBuild";
            this.tp_createBuild.Padding = new System.Windows.Forms.Padding(3);
            this.tp_createBuild.Size = new System.Drawing.Size(322, 121);
            this.tp_createBuild.TabIndex = 1;
            this.tp_createBuild.Text = "Create Build";
            // 
            // lb_defineBuild
            // 
            this.lb_defineBuild.AutoSize = true;
            this.lb_defineBuild.Location = new System.Drawing.Point(6, 3);
            this.lb_defineBuild.Name = "lb_defineBuild";
            this.lb_defineBuild.Size = new System.Drawing.Size(178, 13);
            this.lb_defineBuild.TabIndex = 3;
            this.lb_defineBuild.Text = "Define a build name";
            // 
            // gb_localChar
            // 
            this.gb_localChar.Controls.Add(this.pb_folder);
            this.gb_localChar.Controls.Add(this.pictureBox1);
            this.gb_localChar.Controls.Add(this.lb_mainChar);
            this.gb_localChar.Controls.Add(this.cb_mainChar);
            this.gb_localChar.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_localChar.ForeColor = System.Drawing.Color.White;
            this.gb_localChar.Location = new System.Drawing.Point(12, 12);
            this.gb_localChar.Name = "gb_localChar";
            this.gb_localChar.Size = new System.Drawing.Size(330, 80);
            this.gb_localChar.TabIndex = 0;
            this.gb_localChar.TabStop = false;
            this.gb_localChar.Text = "Local Charakter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
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
            this.cb_mainChar.Location = new System.Drawing.Point(48, 45);
            this.cb_mainChar.Name = "cb_mainChar";
            this.cb_mainChar.Size = new System.Drawing.Size(272, 21);
            this.cb_mainChar.TabIndex = 0;
            this.cb_mainChar.SelectedIndexChanged += new System.EventHandler(this.cb_mainChar_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // tb_buildName
            // 
            this.tb_buildName.Location = new System.Drawing.Point(44, 23);
            this.tb_buildName.Name = "tb_buildName";
            this.tb_buildName.Size = new System.Drawing.Size(272, 21);
            this.tb_buildName.TabIndex = 4;
            // 
            // bt_saveBuild
            // 
            this.bt_saveBuild.BackColor = System.Drawing.Color.DarkCyan;
            this.bt_saveBuild.Image = ((System.Drawing.Image)(resources.GetObject("bt_saveBuild.Image")));
            this.bt_saveBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_saveBuild.Location = new System.Drawing.Point(66, 55);
            this.bt_saveBuild.Name = "bt_saveBuild";
            this.bt_saveBuild.Size = new System.Drawing.Size(214, 47);
            this.bt_saveBuild.TabIndex = 5;
            this.bt_saveBuild.Text = "Save Build";
            this.bt_saveBuild.UseVisualStyleBackColor = false;
            this.bt_saveBuild.Click += new System.EventHandler(this.bt_saveBuild_Click);
            // 
            // pb_folder
            // 
            this.pb_folder.BackColor = System.Drawing.Color.Transparent;
            this.pb_folder.Image = ((System.Drawing.Image)(resources.GetObject("pb_folder.Image")));
            this.pb_folder.Location = new System.Drawing.Point(295, 8);
            this.pb_folder.Name = "pb_folder";
            this.pb_folder.Size = new System.Drawing.Size(32, 32);
            this.pb_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_folder.TabIndex = 3;
            this.pb_folder.TabStop = false;
            this.pb_folder.DoubleClick += new System.EventHandler(this.pb_folder_DoubleClick);
            this.pb_folder.MouseLeave += new System.EventHandler(this.pb_folder_MouseLeave_1);
            this.pb_folder.MouseHover += new System.EventHandler(this.pb_folder_MouseHover);
            // 
            // fr_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 258);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fr_main";
            this.Text = "Valheim Character Manager";
            this.panel1.ResumeLayout(false);
            this.tc_builds.ResumeLayout(false);
            this.tp_chooseBuild.ResumeLayout(false);
            this.tp_chooseBuild.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tp_createBuild.ResumeLayout(false);
            this.tp_createBuild.PerformLayout();
            this.gb_localChar.ResumeLayout(false);
            this.gb_localChar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_folder)).EndInit();
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
        private System.Windows.Forms.Label lb_chooseBuild;
        private System.Windows.Forms.ComboBox cb_chosseBuild;
        private System.Windows.Forms.Button bt_switchBuild;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lb_defineBuild;
        private System.Windows.Forms.Button bt_saveBuild;
        private System.Windows.Forms.TextBox tb_buildName;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pb_folder;
    }
}

