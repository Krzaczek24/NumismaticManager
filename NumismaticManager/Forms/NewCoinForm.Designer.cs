﻿namespace NumismaticManager.Forms
{
    partial class NewCoinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCoinForm));
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelValue = new System.Windows.Forms.Label();
            this.LabelDiameter = new System.Windows.Forms.Label();
            this.LabelFineness = new System.Windows.Forms.Label();
            this.LabelWeight = new System.Windows.Forms.Label();
            this.LabelEdition = new System.Windows.Forms.Label();
            this.LabelEmission = new System.Windows.Forms.Label();
            this.LabelStamp = new System.Windows.Forms.Label();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxDiameter = new System.Windows.Forms.TextBox();
            this.TextBoxWeight = new System.Windows.Forms.TextBox();
            this.TextBoxEdition = new System.Windows.Forms.TextBox();
            this.DateTimePickerEmission = new System.Windows.Forms.DateTimePicker();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.LabelZL = new System.Windows.Forms.Label();
            this.LabelMM = new System.Windows.Forms.Label();
            this.LabelG = new System.Windows.Forms.Label();
            this.LabelPCS = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.TextBoxFineness = new System.Windows.Forms.TextBox();
            this.TextBoxStamp = new System.Windows.Forms.TextBox();
            this.TextBoxValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(19, 15);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(43, 13);
            this.LabelName.TabIndex = 0;
            this.LabelName.Text = "Nazwa:";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelValue
            // 
            this.LabelValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelValue.AutoSize = true;
            this.LabelValue.Location = new System.Drawing.Point(12, 83);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(50, 13);
            this.LabelValue.TabIndex = 1;
            this.LabelValue.Text = "Nominał:";
            this.LabelValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelDiameter
            // 
            this.LabelDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelDiameter.AutoSize = true;
            this.LabelDiameter.Location = new System.Drawing.Point(10, 110);
            this.LabelDiameter.Name = "LabelDiameter";
            this.LabelDiameter.Size = new System.Drawing.Size(52, 13);
            this.LabelDiameter.TabIndex = 2;
            this.LabelDiameter.Text = "Średnica:";
            this.LabelDiameter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelFineness
            // 
            this.LabelFineness.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelFineness.AutoSize = true;
            this.LabelFineness.Location = new System.Drawing.Point(24, 135);
            this.LabelFineness.Name = "LabelFineness";
            this.LabelFineness.Size = new System.Drawing.Size(38, 13);
            this.LabelFineness.TabIndex = 3;
            this.LabelFineness.Text = "Próba:";
            this.LabelFineness.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelWeight
            // 
            this.LabelWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelWeight.AutoSize = true;
            this.LabelWeight.Location = new System.Drawing.Point(23, 161);
            this.LabelWeight.Name = "LabelWeight";
            this.LabelWeight.Size = new System.Drawing.Size(39, 13);
            this.LabelWeight.TabIndex = 4;
            this.LabelWeight.Text = "Waga:";
            this.LabelWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelEdition
            // 
            this.LabelEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelEdition.AutoSize = true;
            this.LabelEdition.Location = new System.Drawing.Point(16, 187);
            this.LabelEdition.Name = "LabelEdition";
            this.LabelEdition.Size = new System.Drawing.Size(46, 13);
            this.LabelEdition.TabIndex = 5;
            this.LabelEdition.Text = "Nakład:";
            this.LabelEdition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelEmission
            // 
            this.LabelEmission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelEmission.AutoSize = true;
            this.LabelEmission.Location = new System.Drawing.Point(29, 216);
            this.LabelEmission.Name = "LabelEmission";
            this.LabelEmission.Size = new System.Drawing.Size(33, 13);
            this.LabelEmission.TabIndex = 6;
            this.LabelEmission.Text = "Data:";
            this.LabelEmission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabelStamp
            // 
            this.LabelStamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelStamp.AutoSize = true;
            this.LabelStamp.Location = new System.Drawing.Point(14, 239);
            this.LabelStamp.Name = "LabelStamp";
            this.LabelStamp.Size = new System.Drawing.Size(48, 13);
            this.LabelStamp.TabIndex = 7;
            this.LabelStamp.Text = "Stempel:";
            this.LabelStamp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(68, 12);
            this.TextBoxName.Multiline = true;
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(276, 62);
            this.TextBoxName.TabIndex = 8;
            // 
            // TextBoxDiameter
            // 
            this.TextBoxDiameter.Location = new System.Drawing.Point(68, 106);
            this.TextBoxDiameter.Name = "TextBoxDiameter";
            this.TextBoxDiameter.Size = new System.Drawing.Size(81, 20);
            this.TextBoxDiameter.TabIndex = 10;
            // 
            // TextBoxWeight
            // 
            this.TextBoxWeight.Location = new System.Drawing.Point(68, 158);
            this.TextBoxWeight.Name = "TextBoxWeight";
            this.TextBoxWeight.Size = new System.Drawing.Size(81, 20);
            this.TextBoxWeight.TabIndex = 12;
            // 
            // TextBoxEdition
            // 
            this.TextBoxEdition.Location = new System.Drawing.Point(68, 184);
            this.TextBoxEdition.Name = "TextBoxEdition";
            this.TextBoxEdition.Size = new System.Drawing.Size(81, 20);
            this.TextBoxEdition.TabIndex = 13;
            // 
            // DateTimePickerEmission
            // 
            this.DateTimePickerEmission.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePickerEmission.Location = new System.Drawing.Point(68, 210);
            this.DateTimePickerEmission.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerEmission.Name = "DateTimePickerEmission";
            this.DateTimePickerEmission.Size = new System.Drawing.Size(100, 20);
            this.DateTimePickerEmission.TabIndex = 14;
            this.DateTimePickerEmission.Value = new System.DateTime(2019, 1, 22, 11, 35, 2, 0);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(224, 215);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(119, 41);
            this.ButtonAdd.TabIndex = 16;
            this.ButtonAdd.Text = "Dodaj";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // LabelZL
            // 
            this.LabelZL.AutoSize = true;
            this.LabelZL.Location = new System.Drawing.Point(155, 83);
            this.LabelZL.Name = "LabelZL";
            this.LabelZL.Size = new System.Drawing.Size(16, 13);
            this.LabelZL.TabIndex = 16;
            this.LabelZL.Text = "zł";
            // 
            // LabelMM
            // 
            this.LabelMM.AutoSize = true;
            this.LabelMM.Location = new System.Drawing.Point(155, 110);
            this.LabelMM.Name = "LabelMM";
            this.LabelMM.Size = new System.Drawing.Size(23, 13);
            this.LabelMM.TabIndex = 17;
            this.LabelMM.Text = "mm";
            // 
            // LabelG
            // 
            this.LabelG.AutoSize = true;
            this.LabelG.Location = new System.Drawing.Point(155, 162);
            this.LabelG.Name = "LabelG";
            this.LabelG.Size = new System.Drawing.Size(13, 13);
            this.LabelG.TabIndex = 18;
            this.LabelG.Text = "g";
            // 
            // LabelPCS
            // 
            this.LabelPCS.AutoSize = true;
            this.LabelPCS.Location = new System.Drawing.Point(155, 188);
            this.LabelPCS.Name = "LabelPCS";
            this.LabelPCS.Size = new System.Drawing.Size(32, 13);
            this.LabelPCS.TabIndex = 19;
            this.LabelPCS.Text = "sztuk";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(225, 80);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(119, 41);
            this.ButtonSearch.TabIndex = 20;
            this.ButtonSearch.Text = "Szukaj danych";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // TextBoxFineness
            // 
            this.TextBoxFineness.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxFineness.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxFineness.Location = new System.Drawing.Point(68, 132);
            this.TextBoxFineness.Name = "TextBoxFineness";
            this.TextBoxFineness.Size = new System.Drawing.Size(151, 20);
            this.TextBoxFineness.TabIndex = 21;
            // 
            // TextBoxStamp
            // 
            this.TextBoxStamp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxStamp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxStamp.Location = new System.Drawing.Point(68, 236);
            this.TextBoxStamp.Name = "TextBoxStamp";
            this.TextBoxStamp.Size = new System.Drawing.Size(151, 20);
            this.TextBoxStamp.TabIndex = 22;
            // 
            // TextBoxValue
            // 
            this.TextBoxValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBoxValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBoxValue.Location = new System.Drawing.Point(68, 80);
            this.TextBoxValue.Name = "TextBoxValue";
            this.TextBoxValue.Size = new System.Drawing.Size(81, 20);
            this.TextBoxValue.TabIndex = 23;
            // 
            // NewCoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 268);
            this.Controls.Add(this.TextBoxValue);
            this.Controls.Add(this.TextBoxStamp);
            this.Controls.Add(this.TextBoxFineness);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.LabelPCS);
            this.Controls.Add(this.LabelG);
            this.Controls.Add(this.LabelMM);
            this.Controls.Add(this.LabelZL);
            this.Controls.Add(this.LabelStamp);
            this.Controls.Add(this.LabelEmission);
            this.Controls.Add(this.LabelEdition);
            this.Controls.Add(this.LabelWeight);
            this.Controls.Add(this.LabelFineness);
            this.Controls.Add(this.LabelDiameter);
            this.Controls.Add(this.LabelValue);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.TextBoxDiameter);
            this.Controls.Add(this.TextBoxWeight);
            this.Controls.Add(this.TextBoxEdition);
            this.Controls.Add(this.DateTimePickerEmission);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCoinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodawanie nowego numizmatu";
            this.Load += new System.EventHandler(this.NewCoinForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelValue;
        private System.Windows.Forms.Label LabelDiameter;
        private System.Windows.Forms.Label LabelFineness;
        private System.Windows.Forms.Label LabelWeight;
        private System.Windows.Forms.Label LabelEdition;
        private System.Windows.Forms.Label LabelEmission;
        private System.Windows.Forms.Label LabelStamp;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxDiameter;
        private System.Windows.Forms.TextBox TextBoxWeight;
        private System.Windows.Forms.TextBox TextBoxEdition;
        private System.Windows.Forms.DateTimePicker DateTimePickerEmission;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Label LabelZL;
        private System.Windows.Forms.Label LabelMM;
        private System.Windows.Forms.Label LabelG;
        private System.Windows.Forms.Label LabelPCS;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.TextBox TextBoxFineness;
        private System.Windows.Forms.TextBox TextBoxStamp;
        private System.Windows.Forms.TextBox TextBoxValue;
    }
}