namespace NumismaticXP.Forms
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
            this.ButtonClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelLeftCount = new System.Windows.Forms.Label();
            this.LabelLeftValue = new System.Windows.Forms.Label();
            this.LabelLeftWeight = new System.Windows.Forms.Label();
            this.LabelLeftPercent = new System.Windows.Forms.Label();
            this.LabelRightCount = new System.Windows.Forms.Label();
            this.LabelRightValue = new System.Windows.Forms.Label();
            this.LabelRightWeight = new System.Windows.Forms.Label();
            this.LabelRightPercent = new System.Windows.Forms.Label();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonRedundant = new System.Windows.Forms.RadioButton();
            this.RadioButtonOwned = new System.Windows.Forms.RadioButton();
            this.RadioButtonUnique = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.GroupBox.SuspendLayout();
            this.TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelProgressBar
            // 
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
            // ButtonClose
            // 
            this.ButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonClose.Location = new System.Drawing.Point(12, 229);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(237, 30);
            this.ButtonClose.TabIndex = 5;
            this.ButtonClose.Text = "Zamknij";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.95652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.04348F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.LabelLeftCount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelLeftValue, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelLeftWeight, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LabelLeftPercent, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LabelRightCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelRightValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelRightWeight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LabelRightPercent, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 118);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(237, 105);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // LabelLeftCount
            // 
            this.LabelLeftCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLeftCount.AutoSize = true;
            this.LabelLeftCount.Location = new System.Drawing.Point(3, 0);
            this.LabelLeftCount.Name = "LabelLeftCount";
            this.LabelLeftCount.Size = new System.Drawing.Size(81, 26);
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
            this.LabelLeftValue.Location = new System.Drawing.Point(3, 26);
            this.LabelLeftValue.Name = "LabelLeftValue";
            this.LabelLeftValue.Size = new System.Drawing.Size(81, 26);
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
            this.LabelLeftWeight.Location = new System.Drawing.Point(3, 52);
            this.LabelLeftWeight.Name = "LabelLeftWeight";
            this.LabelLeftWeight.Size = new System.Drawing.Size(81, 26);
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
            this.LabelLeftPercent.Location = new System.Drawing.Point(3, 78);
            this.LabelLeftPercent.Name = "LabelLeftPercent";
            this.LabelLeftPercent.Size = new System.Drawing.Size(81, 27);
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
            this.LabelRightCount.Size = new System.Drawing.Size(144, 26);
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
            this.LabelRightValue.Location = new System.Drawing.Point(90, 26);
            this.LabelRightValue.Name = "LabelRightValue";
            this.LabelRightValue.Size = new System.Drawing.Size(144, 26);
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
            this.LabelRightWeight.Location = new System.Drawing.Point(90, 52);
            this.LabelRightWeight.Name = "LabelRightWeight";
            this.LabelRightWeight.Size = new System.Drawing.Size(144, 26);
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
            this.LabelRightPercent.Location = new System.Drawing.Point(90, 78);
            this.LabelRightPercent.Name = "LabelRightPercent";
            this.LabelRightPercent.Size = new System.Drawing.Size(144, 27);
            this.LabelRightPercent.TabIndex = 8;
            this.LabelRightPercent.Text = "percent";
            this.LabelRightPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.TableLayoutPanel);
            this.GroupBox.Location = new System.Drawing.Point(12, 65);
            this.GroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.GroupBox.Size = new System.Drawing.Size(237, 50);
            this.GroupBox.TabIndex = 7;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Grupa monet";
            // 
            // TableLayoutPanel
            // 
            this.TableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel.ColumnCount = 3;
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.TableLayoutPanel.Controls.Add(this.RadioButtonRedundant, 2, 0);
            this.TableLayoutPanel.Controls.Add(this.RadioButtonOwned, 0, 0);
            this.TableLayoutPanel.Controls.Add(this.RadioButtonUnique, 1, 0);
            this.TableLayoutPanel.Location = new System.Drawing.Point(0, 13);
            this.TableLayoutPanel.Name = "TableLayoutPanel";
            this.TableLayoutPanel.RowCount = 1;
            this.TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel.Size = new System.Drawing.Size(237, 34);
            this.TableLayoutPanel.TabIndex = 0;
            // 
            // RadioButtonRedundant
            // 
            this.RadioButtonRedundant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RadioButtonRedundant.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioButtonRedundant.AutoSize = true;
            this.RadioButtonRedundant.Location = new System.Drawing.Point(160, 3);
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
            this.RadioButtonOwned.Location = new System.Drawing.Point(3, 3);
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
            this.RadioButtonUnique.Location = new System.Drawing.Point(81, 3);
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
            this.ClientSize = new System.Drawing.Size(261, 271);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ButtonClose);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.GroupBox.ResumeLayout(false);
            this.TableLayoutPanel.ResumeLayout(false);
            this.TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelProgressBar;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
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
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel;
    }
}