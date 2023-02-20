namespace Sistem_Bilgileri
{
    partial class Ayarlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.GroupBoxAboutDeveloper = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDeveloperGithubProfile = new System.Windows.Forms.LinkLabel();
            this.labelDeveloperWebSite = new System.Windows.Forms.LinkLabel();
            this.labelDeveloperName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBoxAboutApp = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAppGithubRepository = new System.Windows.Forms.LinkLabel();
            this.labelAllRightReserved = new System.Windows.Forms.Label();
            this.labelAppNameAndVersion = new System.Windows.Forms.Label();
            this.pictureBoxAppIcon = new System.Windows.Forms.PictureBox();
            this.GroupBoxAboutDeveloper.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBoxAboutApp.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxAboutDeveloper
            // 
            this.GroupBoxAboutDeveloper.Controls.Add(this.panel2);
            this.GroupBoxAboutDeveloper.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GroupBoxAboutDeveloper.Location = new System.Drawing.Point(12, 130);
            this.GroupBoxAboutDeveloper.Name = "GroupBoxAboutDeveloper";
            this.GroupBoxAboutDeveloper.Size = new System.Drawing.Size(345, 107);
            this.GroupBoxAboutDeveloper.TabIndex = 3;
            this.GroupBoxAboutDeveloper.TabStop = false;
            this.GroupBoxAboutDeveloper.Text = "Geliştiriciler Hakkında";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDeveloperGithubProfile);
            this.panel2.Controls.Add(this.labelDeveloperWebSite);
            this.panel2.Controls.Add(this.labelDeveloperName);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 85);
            this.panel2.TabIndex = 1;
            // 
            // labelDeveloperGithubProfile
            // 
            this.labelDeveloperGithubProfile.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelDeveloperGithubProfile.AutoSize = true;
            this.labelDeveloperGithubProfile.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperGithubProfile.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperGithubProfile.Location = new System.Drawing.Point(76, 62);
            this.labelDeveloperGithubProfile.Name = "labelDeveloperGithubProfile";
            this.labelDeveloperGithubProfile.Size = new System.Drawing.Size(220, 15);
            this.labelDeveloperGithubProfile.TabIndex = 9;
            this.labelDeveloperGithubProfile.TabStop = true;
            this.labelDeveloperGithubProfile.Tag = "balaban_github_page";
            this.labelDeveloperGithubProfile.Text = "Developer Github Profile: @epbalaban01";
            this.labelDeveloperGithubProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelDeveloperWebSite
            // 
            this.labelDeveloperWebSite.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelDeveloperWebSite.AutoSize = true;
            this.labelDeveloperWebSite.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperWebSite.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperWebSite.Location = new System.Drawing.Point(76, 37);
            this.labelDeveloperWebSite.Name = "labelDeveloperWebSite";
            this.labelDeveloperWebSite.Size = new System.Drawing.Size(249, 15);
            this.labelDeveloperWebSite.TabIndex = 8;
            this.labelDeveloperWebSite.TabStop = true;
            this.labelDeveloperWebSite.Tag = "balaban_website";
            this.labelDeveloperWebSite.Text = "Developer Website: formula1turkey.epizy.com";
            this.labelDeveloperWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelDeveloperName
            // 
            this.labelDeveloperName.AutoSize = true;
            this.labelDeveloperName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelDeveloperName.Location = new System.Drawing.Point(76, 12);
            this.labelDeveloperName.Name = "labelDeveloperName";
            this.labelDeveloperName.Size = new System.Drawing.Size(191, 15);
            this.labelDeveloperName.TabIndex = 5;
            this.labelDeveloperName.Text = "Eyüp Can Balaban / @epbalaban01\r\n";
            this.labelDeveloperName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistem_Bilgileri.Properties.Resources.DeveloperIcon_64x64;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // GroupBoxAboutApp
            // 
            this.GroupBoxAboutApp.Controls.Add(this.panel1);
            this.GroupBoxAboutApp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GroupBoxAboutApp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBoxAboutApp.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxAboutApp.Name = "GroupBoxAboutApp";
            this.GroupBoxAboutApp.Size = new System.Drawing.Size(345, 112);
            this.GroupBoxAboutApp.TabIndex = 2;
            this.GroupBoxAboutApp.TabStop = false;
            this.GroupBoxAboutApp.Text = "Sistem Bilgileri Uygulaması Hakkında";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAppGithubRepository);
            this.panel1.Controls.Add(this.labelAllRightReserved);
            this.panel1.Controls.Add(this.labelAppNameAndVersion);
            this.panel1.Controls.Add(this.pictureBoxAppIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 90);
            this.panel1.TabIndex = 0;
            // 
            // labelAppGithubRepository
            // 
            this.labelAppGithubRepository.ActiveLinkColor = System.Drawing.Color.Black;
            this.labelAppGithubRepository.AutoSize = true;
            this.labelAppGithubRepository.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppGithubRepository.LinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppGithubRepository.Location = new System.Drawing.Point(73, 37);
            this.labelAppGithubRepository.Name = "labelAppGithubRepository";
            this.labelAppGithubRepository.Size = new System.Drawing.Size(182, 15);
            this.labelAppGithubRepository.TabIndex = 7;
            this.labelAppGithubRepository.TabStop = true;
            this.labelAppGithubRepository.Tag = "github_repo";
            this.labelAppGithubRepository.Text = "Sistem Bilgileri Github Repository";
            this.labelAppGithubRepository.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RedirectLinkLabels);
            // 
            // labelAllRightReserved
            // 
            this.labelAllRightReserved.AutoSize = true;
            this.labelAllRightReserved.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAllRightReserved.Location = new System.Drawing.Point(73, 62);
            this.labelAllRightReserved.Name = "labelAllRightReserved";
            this.labelAllRightReserved.Size = new System.Drawing.Size(25, 15);
            this.labelAllRightReserved.TabIndex = 6;
            this.labelAllRightReserved.Text = "[--]";
            // 
            // labelAppNameAndVersion
            // 
            this.labelAppNameAndVersion.AutoSize = true;
            this.labelAppNameAndVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelAppNameAndVersion.Location = new System.Drawing.Point(73, 12);
            this.labelAppNameAndVersion.Name = "labelAppNameAndVersion";
            this.labelAppNameAndVersion.Size = new System.Drawing.Size(20, 15);
            this.labelAppNameAndVersion.TabIndex = 4;
            this.labelAppNameAndVersion.Text = "[-]";
            this.labelAppNameAndVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxAppIcon
            // 
            this.pictureBoxAppIcon.Image = global::Sistem_Bilgileri.Properties.Resources.icons8_windows_client_64;
            this.pictureBoxAppIcon.Location = new System.Drawing.Point(3, 12);
            this.pictureBoxAppIcon.Name = "pictureBoxAppIcon";
            this.pictureBoxAppIcon.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxAppIcon.TabIndex = 3;
            this.pictureBoxAppIcon.TabStop = false;
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 249);
            this.Controls.Add(this.GroupBoxAboutDeveloper);
            this.Controls.Add(this.GroupBoxAboutApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Ayarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.GroupBoxAboutDeveloper.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBoxAboutApp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxAboutDeveloper;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel labelDeveloperGithubProfile;
        private System.Windows.Forms.LinkLabel labelDeveloperWebSite;
        private System.Windows.Forms.Label labelDeveloperName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox GroupBoxAboutApp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel labelAppGithubRepository;
        private System.Windows.Forms.Label labelAllRightReserved;
        private System.Windows.Forms.Label labelAppNameAndVersion;
        private System.Windows.Forms.PictureBox pictureBoxAppIcon;
    }
}