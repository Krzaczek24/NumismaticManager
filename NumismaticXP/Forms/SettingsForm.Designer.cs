namespace Numismatic.Forms
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
            this.LabelShowCoins = new System.Windows.Forms.Label();
            this.ButtonSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckBoxesCoins
            // 
            this.CheckBoxesCoins.FormattingEnabled = true;
            this.CheckBoxesCoins.Location = new System.Drawing.Point(12, 35);
            this.CheckBoxesCoins.Name = "CheckBoxesCoins";
            this.CheckBoxesCoins.Size = new System.Drawing.Size(136, 229);
            this.CheckBoxesCoins.TabIndex = 1;
            // 
            // LabelShowCoins
            // 
            this.LabelShowCoins.Location = new System.Drawing.Point(12, 9);
            this.LabelShowCoins.Name = "LabelShowCoins";
            this.LabelShowCoins.Size = new System.Drawing.Size(136, 23);
            this.LabelShowCoins.TabIndex = 2;
            this.LabelShowCoins.Text = "Wyświetlaj nominały:";
            this.LabelShowCoins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonSaveSettings
            // 
            this.ButtonSaveSettings.Location = new System.Drawing.Point(12, 270);
            this.ButtonSaveSettings.Name = "ButtonSaveSettings";
            this.ButtonSaveSettings.Size = new System.Drawing.Size(136, 23);
            this.ButtonSaveSettings.TabIndex = 3;
            this.ButtonSaveSettings.Text = "Zapisz";
            this.ButtonSaveSettings.UseVisualStyleBackColor = true;
            this.ButtonSaveSettings.Click += new System.EventHandler(this.ButtonSaveSettings_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 303);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CheckBoxesCoins;
        private System.Windows.Forms.Label LabelShowCoins;
        private System.Windows.Forms.Button ButtonSaveSettings;
    }
}