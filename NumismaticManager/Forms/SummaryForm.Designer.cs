namespace NumismaticManager.Forms
{
    partial class SummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryForm));
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TableLayoutPanelInformation = new System.Windows.Forms.TableLayoutPanel();
            this.LabelLeftCount = new System.Windows.Forms.Label();
            this.LabelLeftValue = new System.Windows.Forms.Label();
            this.LabelLeftWeight = new System.Windows.Forms.Label();
            this.LabelLeftPercent = new System.Windows.Forms.Label();
            this.LabelRightCount = new System.Windows.Forms.Label();
            this.LabelRightValue = new System.Windows.Forms.Label();
            this.LabelRightWeight = new System.Windows.Forms.Label();
            this.LabelRightPercent = new System.Windows.Forms.Label();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanelSwitch = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonRedundant = new System.Windows.Forms.RadioButton();
            this.RadioButtonOwned = new System.Windows.Forms.RadioButton();
            this.RadioButtonUnique = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanelInformation.SuspendLayout();
            this.GroupBox.SuspendLayout();
            this.TableLayoutPanelSwitch.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelProgressBar.Location = new System.Drawing.Point(12, 9);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(237, 23);
            this.LabelProgressBar.TabIndex = 0;
            this.LabelProgressBar.Text = "Posiadasz XXX z YYYY monet (ZZ.ZZ%)";
            this.LabelProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(12, 35);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(237, 23);
            this.ProgressBar.TabIndex = 4;
            // 
            // TableLayoutPanelInformation
            // 
            this.TableLayoutPanelInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanelInformation.ColumnCount = 2;
            this.TableLayoutPanelInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.95652F));
            this.TableLayoutPanelInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.04348F));
            this.TableLayoutPanelInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanelInformation.Controls.Add(this.LabelLeftCount, 0, 0);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelLeftValue, 0, 1);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelLeftWeight, 0, 2);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelLeftPercent, 0, 3);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelRightCount, 1, 0);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelRightValue, 1, 1);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelRightWeight, 1, 2);
            this.TableLayoutPanelInformation.Controls.Add(this.LabelRightPercent, 1, 3);
            this.TableLayoutPanelInformation.Location = new System.Drawing.Point(12, 118);
            this.TableLayoutPanelInformation.Name = "TableLayoutPanelInformation";
            this.TableLayoutPanelInformation.RowCount = 4;
            this.TableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelInformation.Size = new System.Drawing.Size(237, 84);
            this.TableLayoutPanelInformation.TabIndex = 6;
            // 
            // LabelLeftCount
            // 
            this.LabelLeftCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLeftCount.AutoSize = true;
            this.LabelLeftCount.Location = new System.Drawing.Point(3, 0);
            this.LabelLeftCount.Name = "LabelLeftCount";
            this.LabelLeftCount.Size = new System.Drawing.Size(81, 21);
            this.LabelLeftCount.TabIndex = 0;
            this.LabelLeftCount.Text = "Ilość:";
            this.LabelLeftCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLeftValue
            // 
            this.LabelLeftValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLeftValue.AutoSize = true;
            this.LabelLeftValue.Location = new System.Drawing.Point(3, 21);
            this.LabelLeftValue.Name = "LabelLeftValue";
            this.LabelLeftValue.Size = new System.Drawing.Size(81, 21);
            this.LabelLeftValue.TabIndex = 1;
            this.LabelLeftValue.Text = "Wartość nom.:";
            this.LabelLeftValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLeftWeight
            // 
            this.LabelLeftWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLeftWeight.AutoSize = true;
            this.LabelLeftWeight.Location = new System.Drawing.Point(3, 42);
            this.LabelLeftWeight.Name = "LabelLeftWeight";
            this.LabelLeftWeight.Size = new System.Drawing.Size(81, 21);
            this.LabelLeftWeight.TabIndex = 2;
            this.LabelLeftWeight.Text = "Waga:";
            this.LabelLeftWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelLeftPercent
            // 
            this.LabelLeftPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLeftPercent.AutoSize = true;
            this.LabelLeftPercent.Location = new System.Drawing.Point(3, 63);
            this.LabelLeftPercent.Name = "LabelLeftPercent";
            this.LabelLeftPercent.Size = new System.Drawing.Size(81, 21);
            this.LabelLeftPercent.TabIndex = 3;
            this.LabelLeftPercent.Text = "Procent:";
            this.LabelLeftPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelRightCount
            // 
            this.LabelRightCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRightCount.AutoSize = true;
            this.LabelRightCount.Location = new System.Drawing.Point(90, 0);
            this.LabelRightCount.Name = "LabelRightCount";
            this.LabelRightCount.Size = new System.Drawing.Size(144, 21);
            this.LabelRightCount.TabIndex = 5;
            this.LabelRightCount.Text = "count";
            this.LabelRightCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelRightValue
            // 
            this.LabelRightValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRightValue.AutoSize = true;
            this.LabelRightValue.Location = new System.Drawing.Point(90, 21);
            this.LabelRightValue.Name = "LabelRightValue";
            this.LabelRightValue.Size = new System.Drawing.Size(144, 21);
            this.LabelRightValue.TabIndex = 6;
            this.LabelRightValue.Text = "value";
            this.LabelRightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelRightWeight
            // 
            this.LabelRightWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRightWeight.AutoSize = true;
            this.LabelRightWeight.Location = new System.Drawing.Point(90, 42);
            this.LabelRightWeight.Name = "LabelRightWeight";
            this.LabelRightWeight.Size = new System.Drawing.Size(144, 21);
            this.LabelRightWeight.TabIndex = 7;
            this.LabelRightWeight.Text = "weight";
            this.LabelRightWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelRightPercent
            // 
            this.LabelRightPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRightPercent.AutoSize = true;
            this.LabelRightPercent.Location = new System.Drawing.Point(90, 63);
            this.LabelRightPercent.Name = "LabelRightPercent";
            this.LabelRightPercent.Size = new System.Drawing.Size(144, 21);
            this.LabelRightPercent.TabIndex = 8;
            this.LabelRightPercent.Text = "percent";
            this.LabelRightPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox
            // 
            this.GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox.Controls.Add(this.TableLayoutPanelSwitch);
            this.GroupBox.Location = new System.Drawing.Point(12, 65);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(237, 50);
            this.GroupBox.TabIndex = 7;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Grupa monet";
            // 
            // TableLayoutPanelSwitch
            // 
            this.TableLayoutPanelSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanelSwitch.ColumnCount = 3;
            this.TableLayoutPanelSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.TableLayoutPanelSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.TableLayoutPanelSwitch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.TableLayoutPanelSwitch.Controls.Add(this.RadioButtonRedundant, 2, 0);
            this.TableLayoutPanelSwitch.Controls.Add(this.RadioButtonOwned, 0, 0);
            this.TableLayoutPanelSwitch.Controls.Add(this.RadioButtonUnique, 1, 0);
            this.TableLayoutPanelSwitch.Location = new System.Drawing.Point(3, 16);
            this.TableLayoutPanelSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanelSwitch.Name = "TableLayoutPanelSwitch";
            this.TableLayoutPanelSwitch.RowCount = 1;
            this.TableLayoutPanelSwitch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanelSwitch.Size = new System.Drawing.Size(231, 28);
            this.TableLayoutPanelSwitch.TabIndex = 0;
            // 
            // RadioButtonRedundant
            // 
            this.RadioButtonRedundant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonRedundant.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonRedundant.AutoSize = true;
            this.RadioButtonRedundant.Location = new System.Drawing.Point(155, 0);
            this.RadioButtonRedundant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RadioButtonRedundant.Name = "RadioButtonRedundant";
            this.RadioButtonRedundant.Size = new System.Drawing.Size(74, 28);
            this.RadioButtonRedundant.TabIndex = 2;
            this.RadioButtonRedundant.Text = "Nadmiarowe";
            this.RadioButtonRedundant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioButtonRedundant.UseVisualStyleBackColor = true;
            this.RadioButtonRedundant.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonOwned
            // 
            this.RadioButtonOwned.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonOwned.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonOwned.AutoSize = true;
            this.RadioButtonOwned.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RadioButtonOwned.Checked = true;
            this.RadioButtonOwned.Location = new System.Drawing.Point(2, 0);
            this.RadioButtonOwned.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RadioButtonOwned.Name = "RadioButtonOwned";
            this.RadioButtonOwned.Size = new System.Drawing.Size(72, 28);
            this.RadioButtonOwned.TabIndex = 0;
            this.RadioButtonOwned.TabStop = true;
            this.RadioButtonOwned.Text = "Posiadane";
            this.RadioButtonOwned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioButtonOwned.UseVisualStyleBackColor = true;
            this.RadioButtonOwned.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonUnique
            // 
            this.RadioButtonUnique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonUnique.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonUnique.AutoSize = true;
            this.RadioButtonUnique.Location = new System.Drawing.Point(78, 0);
            this.RadioButtonUnique.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RadioButtonUnique.Name = "RadioButtonUnique";
            this.RadioButtonUnique.Size = new System.Drawing.Size(73, 28);
            this.RadioButtonUnique.TabIndex = 1;
            this.RadioButtonUnique.Text = "Unikatowe";
            this.RadioButtonUnique.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioButtonUnique.UseVisualStyleBackColor = true;
            this.RadioButtonUnique.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 214);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.TableLayoutPanelInformation);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.LabelProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SummaryForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Podsumowanie";
            this.Load += new System.EventHandler(this.SummaryForm_Load);
            this.TableLayoutPanelInformation.ResumeLayout(false);
            this.TableLayoutPanelInformation.PerformLayout();
            this.GroupBox.ResumeLayout(false);
            this.TableLayoutPanelSwitch.ResumeLayout(false);
            this.TableLayoutPanelSwitch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelProgressBar;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelInformation;
        private System.Windows.Forms.Label LabelLeftCount;
        private System.Windows.Forms.Label LabelLeftValue;
        private System.Windows.Forms.Label LabelLeftWeight;
        private System.Windows.Forms.Label LabelLeftPercent;
        private System.Windows.Forms.Label LabelRightCount;
        private System.Windows.Forms.Label LabelRightValue;
        private System.Windows.Forms.Label LabelRightWeight;
        private System.Windows.Forms.Label LabelRightPercent;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.RadioButton RadioButtonRedundant;
        private System.Windows.Forms.RadioButton RadioButtonUnique;
        private System.Windows.Forms.RadioButton RadioButtonOwned;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelSwitch;
    }
}