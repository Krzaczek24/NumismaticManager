namespace NumismaticXP.Forms
{
    partial class ErrorsForm
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
            this.DataGridViewErrors = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewErrors
            // 
            this.DataGridViewErrors.AllowUserToAddRows = false;
            this.DataGridViewErrors.AllowUserToDeleteRows = false;
            this.DataGridViewErrors.AllowUserToResizeColumns = false;
            this.DataGridViewErrors.AllowUserToResizeRows = false;
            this.DataGridViewErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewErrors.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewErrors.Margin = new System.Windows.Forms.Padding(0);
            this.DataGridViewErrors.MultiSelect = false;
            this.DataGridViewErrors.Name = "DataGridViewErrors";
            this.DataGridViewErrors.ReadOnly = true;
            this.DataGridViewErrors.RowHeadersVisible = false;
            this.DataGridViewErrors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridViewErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewErrors.Size = new System.Drawing.Size(1264, 761);
            this.DataGridViewErrors.TabIndex = 0;
            // 
            // ErrorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.DataGridViewErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ErrorsForm";
            this.Load += new System.EventHandler(this.ErrorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewErrors;
    }
}