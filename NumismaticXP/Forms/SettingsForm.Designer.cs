namespace NumismaticXP.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.CheckBoxesCoins = new System.Windows.Forms.CheckedListBox();
            this.ButtonSaveSettings = new System.Windows.Forms.Button();
            this.LabelShowCoins = new System.Windows.Forms.Label();
            this.GroupBoxCoins = new System.Windows.Forms.GroupBox();
            this.GroupBoxWebsitePath = new System.Windows.Forms.GroupBox();
            this.ListBoxHidden = new System.Windows.Forms.ListBox();
            this.ListBoxShown = new System.Windows.Forms.ListBox();
            this.ButtonShowThis = new System.Windows.Forms.Button();
            this.ButtonHideThis = new System.Windows.Forms.Button();
            this.LabelShownCoins = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxWebsitePath = new System.Windows.Forms.TextBox();
            this.GroupBoxCoins.SuspendLayout();
            this.GroupBoxWebsitePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxesCoins
            // 
            this.CheckBoxesCoins.FormattingEnabled = true;
            this.CheckBoxesCoins.Location = new System.Drawing.Point(15, 35);
            this.CheckBoxesCoins.Name = "CheckBoxesCoins";
            this.CheckBoxesCoins.Size = new System.Drawing.Size(170, 229);
            this.CheckBoxesCoins.TabIndex = 1;
            // 
            // ButtonSaveSettings
            // 
            this.ButtonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSaveSettings.Location = new System.Drawing.Point(556, 462);
            this.ButtonSaveSettings.Name = "ButtonSaveSettings";
            this.ButtonSaveSettings.Size = new System.Drawing.Size(74, 23);
            this.ButtonSaveSettings.TabIndex = 3;
            this.ButtonSaveSettings.Text = "Zapisz";
            this.ButtonSaveSettings.UseVisualStyleBackColor = true;
            this.ButtonSaveSettings.Click += new System.EventHandler(this.ButtonSaveSettings_Click);
            // 
            // LabelShowCoins
            // 
            this.LabelShowCoins.Location = new System.Drawing.Point(12, 9);
            this.LabelShowCoins.Name = "LabelShowCoins";
            this.LabelShowCoins.Size = new System.Drawing.Size(173, 23);
            this.LabelShowCoins.TabIndex = 2;
            this.LabelShowCoins.Text = "Wyświetlaj nominały:";
            this.LabelShowCoins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBoxCoins
            // 
            this.GroupBoxCoins.Controls.Add(this.label2);
            this.GroupBoxCoins.Controls.Add(this.LabelShownCoins);
            this.GroupBoxCoins.Controls.Add(this.ButtonHideThis);
            this.GroupBoxCoins.Controls.Add(this.ButtonShowThis);
            this.GroupBoxCoins.Controls.Add(this.ListBoxShown);
            this.GroupBoxCoins.Controls.Add(this.ListBoxHidden);
            this.GroupBoxCoins.Location = new System.Drawing.Point(285, 85);
            this.GroupBoxCoins.Name = "GroupBoxCoins";
            this.GroupBoxCoins.Size = new System.Drawing.Size(299, 250);
            this.GroupBoxCoins.TabIndex = 4;
            this.GroupBoxCoins.TabStop = false;
            this.GroupBoxCoins.Text = "Wyświetlane nominały";
            // 
            // GroupBoxWebsitePath
            // 
            this.GroupBoxWebsitePath.Controls.Add(this.TextBoxWebsitePath);
            this.GroupBoxWebsitePath.Location = new System.Drawing.Point(67, 351);
            this.GroupBoxWebsitePath.Name = "GroupBoxWebsitePath";
            this.GroupBoxWebsitePath.Size = new System.Drawing.Size(517, 45);
            this.GroupBoxWebsitePath.TabIndex = 5;
            this.GroupBoxWebsitePath.TabStop = false;
            this.GroupBoxWebsitePath.Text = "Adres katalogu NBP";
            // 
            // ListBoxHidden
            // 
            this.ListBoxHidden.FormattingEnabled = true;
            this.ListBoxHidden.Location = new System.Drawing.Point(6, 32);
            this.ListBoxHidden.Name = "ListBoxHidden";
            this.ListBoxHidden.Size = new System.Drawing.Size(120, 212);
            this.ListBoxHidden.TabIndex = 0;
            // 
            // ListBoxShown
            // 
            this.ListBoxShown.FormattingEnabled = true;
            this.ListBoxShown.Location = new System.Drawing.Point(173, 32);
            this.ListBoxShown.Name = "ListBoxShown";
            this.ListBoxShown.Size = new System.Drawing.Size(120, 212);
            this.ListBoxShown.TabIndex = 1;
            // 
            // ButtonShowThis
            // 
            this.ButtonShowThis.Image = global::NumismaticXP.Properties.Resources.Add;
            this.ButtonShowThis.Location = new System.Drawing.Point(132, 101);
            this.ButtonShowThis.Name = "ButtonShowThis";
            this.ButtonShowThis.Size = new System.Drawing.Size(35, 34);
            this.ButtonShowThis.TabIndex = 3;
            this.ButtonShowThis.UseVisualStyleBackColor = true;
            // 
            // ButtonHideThis
            // 
            this.ButtonHideThis.Image = global::NumismaticXP.Properties.Resources.Remove;
            this.ButtonHideThis.Location = new System.Drawing.Point(132, 141);
            this.ButtonHideThis.Name = "ButtonHideThis";
            this.ButtonHideThis.Size = new System.Drawing.Size(35, 34);
            this.ButtonHideThis.TabIndex = 4;
            this.ButtonHideThis.UseVisualStyleBackColor = true;
            // 
            // LabelShownCoins
            // 
            this.LabelShownCoins.AutoSize = true;
            this.LabelShownCoins.Location = new System.Drawing.Point(6, 16);
            this.LabelShownCoins.Name = "LabelShownCoins";
            this.LabelShownCoins.Size = new System.Drawing.Size(56, 13);
            this.LabelShownCoins.TabIndex = 5;
            this.LabelShownCoins.Text = "Dostępne:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Widoczne:";
            // 
            // TextBoxWebsitePath
            // 
            this.TextBoxWebsitePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxWebsitePath.Location = new System.Drawing.Point(6, 19);
            this.TextBoxWebsitePath.Name = "TextBoxWebsitePath";
            this.TextBoxWebsitePath.Size = new System.Drawing.Size(505, 20);
            this.TextBoxWebsitePath.TabIndex = 0;
            this.TextBoxWebsitePath.Text = "https://www.nbp.pl/";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 497);
            this.Controls.Add(this.GroupBoxWebsitePath);
            this.Controls.Add(this.GroupBoxCoins);
            this.Controls.Add(this.ButtonSaveSettings);
            this.Controls.Add(this.LabelShowCoins);
            this.Controls.Add(this.CheckBoxesCoins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ustawienia";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.GroupBoxCoins.ResumeLayout(false);
            this.GroupBoxCoins.PerformLayout();
            this.GroupBoxWebsitePath.ResumeLayout(false);
            this.GroupBoxWebsitePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckBoxesCoins;
        private System.Windows.Forms.Button ButtonSaveSettings;
        private System.Windows.Forms.Label LabelShowCoins;
        private System.Windows.Forms.GroupBox GroupBoxCoins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelShownCoins;
        private System.Windows.Forms.Button ButtonHideThis;
        private System.Windows.Forms.Button ButtonShowThis;
        private System.Windows.Forms.ListBox ListBoxShown;
        private System.Windows.Forms.ListBox ListBoxHidden;
        private System.Windows.Forms.GroupBox GroupBoxWebsitePath;
        private System.Windows.Forms.TextBox TextBoxWebsitePath;
    }
}