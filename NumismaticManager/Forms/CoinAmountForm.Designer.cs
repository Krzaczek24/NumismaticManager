namespace NumismaticManager.Forms
{
    partial class CoinAmountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoinAmountForm));
            this.ButtonDecrement = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.TextBoxCoinAmount = new System.Windows.Forms.TextBox();
            this.ButtonIncrement = new System.Windows.Forms.Button();
            this.LabelCoinName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonDecrement
            // 
            this.ButtonDecrement.Image = global::NumismaticManager.Properties.Resources.Remove;
            this.ButtonDecrement.Location = new System.Drawing.Point(12, 111);
            this.ButtonDecrement.Name = "ButtonDecrement";
            this.ButtonDecrement.Size = new System.Drawing.Size(48, 42);
            this.ButtonDecrement.TabIndex = 9;
            this.ButtonDecrement.UseVisualStyleBackColor = true;
            this.ButtonDecrement.Click += new System.EventHandler(this.ButtonDecrement_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonSave.Location = new System.Drawing.Point(12, 159);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(228, 45);
            this.ButtonSave.TabIndex = 11;
            this.ButtonSave.Text = "Zapisz";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // TextBoxCoinAmount
            // 
            this.TextBoxCoinAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxCoinAmount.Enabled = false;
            this.TextBoxCoinAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCoinAmount.Location = new System.Drawing.Point(66, 117);
            this.TextBoxCoinAmount.Name = "TextBoxCoinAmount";
            this.TextBoxCoinAmount.Size = new System.Drawing.Size(120, 31);
            this.TextBoxCoinAmount.TabIndex = 8;
            this.TextBoxCoinAmount.Text = "ilość";
            this.TextBoxCoinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButtonIncrement
            // 
            this.ButtonIncrement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonIncrement.Image = global::NumismaticManager.Properties.Resources.Add;
            this.ButtonIncrement.Location = new System.Drawing.Point(192, 111);
            this.ButtonIncrement.Name = "ButtonIncrement";
            this.ButtonIncrement.Size = new System.Drawing.Size(48, 42);
            this.ButtonIncrement.TabIndex = 10;
            this.ButtonIncrement.UseVisualStyleBackColor = true;
            this.ButtonIncrement.Click += new System.EventHandler(this.ButtonIncrement_Click);
            // 
            // LabelCoinName
            // 
            this.LabelCoinName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelCoinName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCoinName.Location = new System.Drawing.Point(12, 9);
            this.LabelCoinName.Name = "LabelCoinName";
            this.LabelCoinName.Size = new System.Drawing.Size(228, 99);
            this.LabelCoinName.TabIndex = 12;
            this.LabelCoinName.Text = "Nazwa monety";
            this.LabelCoinName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CoinAmountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 216);
            this.Controls.Add(this.LabelCoinName);
            this.Controls.Add(this.ButtonDecrement);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.TextBoxCoinAmount);
            this.Controls.Add(this.ButtonIncrement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoinAmountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liczba monet";
            this.Load += new System.EventHandler(this.CoinAmountForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoinAmountForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CoinAmountForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDecrement;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox TextBoxCoinAmount;
        private System.Windows.Forms.Button ButtonIncrement;
        private System.Windows.Forms.Label LabelCoinName;
    }
}