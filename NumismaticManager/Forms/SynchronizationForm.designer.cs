namespace NumismaticManager.Forms
{
    partial class SynchronizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynchronizationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TableLayoutPanelSynchronize = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonWipeDatabase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonFastSynchronize = new System.Windows.Forms.Button();
            this.ButtonAdvancedSynchronize = new System.Windows.Forms.Button();
            this.ButtonWipeUserCollection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TableLayoutPanelSynchronize.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(103, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(207, 80);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pobiera dane ze strony a nastepnie dodaje do bazy nowe monety oraz aktualizuje au" +
    "tomatycznie wybrane monety";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // TableLayoutPanelSynchronize
            // 
            this.TableLayoutPanelSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanelSynchronize.ColumnCount = 2;
            this.TableLayoutPanelSynchronize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.16374F));
            this.TableLayoutPanelSynchronize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.83626F));
            this.TableLayoutPanelSynchronize.Controls.Add(this.ButtonWipeDatabase, 0, 3);
            this.TableLayoutPanelSynchronize.Controls.Add(this.label2, 1, 1);
            this.TableLayoutPanelSynchronize.Controls.Add(this.ButtonFastSynchronize, 0, 0);
            this.TableLayoutPanelSynchronize.Controls.Add(this.label1, 1, 0);
            this.TableLayoutPanelSynchronize.Controls.Add(this.ButtonAdvancedSynchronize, 0, 1);
            this.TableLayoutPanelSynchronize.Controls.Add(this.ButtonWipeUserCollection, 0, 2);
            this.TableLayoutPanelSynchronize.Controls.Add(this.label3, 1, 2);
            this.TableLayoutPanelSynchronize.Controls.Add(this.label4, 1, 3);
            this.TableLayoutPanelSynchronize.Location = new System.Drawing.Point(12, 12);
            this.TableLayoutPanelSynchronize.Name = "TableLayoutPanelSynchronize";
            this.TableLayoutPanelSynchronize.RowCount = 4;
            this.TableLayoutPanelSynchronize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelSynchronize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelSynchronize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelSynchronize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TableLayoutPanelSynchronize.Size = new System.Drawing.Size(313, 321);
            this.TableLayoutPanelSynchronize.TabIndex = 3;
            // 
            // ButtonWipeDatabase
            // 
            this.ButtonWipeDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonWipeDatabase.Image = global::NumismaticManager.Properties.Resources.Mr_Bomb;
            this.ButtonWipeDatabase.Location = new System.Drawing.Point(3, 243);
            this.ButtonWipeDatabase.Name = "ButtonWipeDatabase";
            this.ButtonWipeDatabase.Size = new System.Drawing.Size(94, 75);
            this.ButtonWipeDatabase.TabIndex = 6;
            this.ButtonWipeDatabase.Text = "Usunięcie  danych z bazy";
            this.ButtonWipeDatabase.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonWipeDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonWipeDatabase.UseCompatibleTextRendering = true;
            this.ButtonWipeDatabase.UseVisualStyleBackColor = true;
            this.ButtonWipeDatabase.Click += new System.EventHandler(this.ButtonWipeDatabase_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(103, 80);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10);
            this.label2.Size = new System.Drawing.Size(207, 80);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pobiera monety ze strony a następnie pozwala na ręczny wybór monet do dodania i a" +
    "ktualizacji";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.UseCompatibleTextRendering = true;
            // 
            // ButtonFastSynchronize
            // 
            this.ButtonFastSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFastSynchronize.Image = global::NumismaticManager.Properties.Resources.Play_All;
            this.ButtonFastSynchronize.Location = new System.Drawing.Point(3, 3);
            this.ButtonFastSynchronize.Name = "ButtonFastSynchronize";
            this.ButtonFastSynchronize.Size = new System.Drawing.Size(94, 74);
            this.ButtonFastSynchronize.TabIndex = 0;
            this.ButtonFastSynchronize.Text = "Szybka synchronizacja";
            this.ButtonFastSynchronize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonFastSynchronize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonFastSynchronize.UseCompatibleTextRendering = true;
            this.ButtonFastSynchronize.UseVisualStyleBackColor = true;
            this.ButtonFastSynchronize.Click += new System.EventHandler(this.ButtonFastSynchronization_Click);
            // 
            // ButtonAdvancedSynchronize
            // 
            this.ButtonAdvancedSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdvancedSynchronize.Enabled = false;
            this.ButtonAdvancedSynchronize.Image = global::NumismaticManager.Properties.Resources.Play;
            this.ButtonAdvancedSynchronize.Location = new System.Drawing.Point(3, 83);
            this.ButtonAdvancedSynchronize.Name = "ButtonAdvancedSynchronize";
            this.ButtonAdvancedSynchronize.Size = new System.Drawing.Size(94, 74);
            this.ButtonAdvancedSynchronize.TabIndex = 1;
            this.ButtonAdvancedSynchronize.Text = "Zaawansowana synchronizacja";
            this.ButtonAdvancedSynchronize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonAdvancedSynchronize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonAdvancedSynchronize.UseCompatibleTextRendering = true;
            this.ButtonAdvancedSynchronize.UseVisualStyleBackColor = true;
            this.ButtonAdvancedSynchronize.Click += new System.EventHandler(this.ButtonAdvancedSynchronization_Click);
            // 
            // ButtonWipeUserCollection
            // 
            this.ButtonWipeUserCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonWipeUserCollection.Image = global::NumismaticManager.Properties.Resources.Mr_Bomb;
            this.ButtonWipeUserCollection.Location = new System.Drawing.Point(3, 163);
            this.ButtonWipeUserCollection.Name = "ButtonWipeUserCollection";
            this.ButtonWipeUserCollection.Size = new System.Drawing.Size(94, 74);
            this.ButtonWipeUserCollection.TabIndex = 2;
            this.ButtonWipeUserCollection.Text = "Usunięcie  kolekcji";
            this.ButtonWipeUserCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ButtonWipeUserCollection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonWipeUserCollection.UseCompatibleTextRendering = true;
            this.ButtonWipeUserCollection.UseVisualStyleBackColor = true;
            this.ButtonWipeUserCollection.Click += new System.EventHandler(this.ButtonWipeUserCollection_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 160);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10);
            this.label3.Size = new System.Drawing.Size(207, 80);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuwa z bazy całą kolekcję użytkownika";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 240);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10);
            this.label4.Size = new System.Drawing.Size(207, 81);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuwa wszystkie dane z bazy";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.UseCompatibleTextRendering = true;
            // 
            // SynchronizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 345);
            this.Controls.Add(this.TableLayoutPanelSynchronize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SynchronizationForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór rodzaju synchronizacji";
            this.TableLayoutPanelSynchronize.ResumeLayout(false);
            this.TableLayoutPanelSynchronize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonFastSynchronize;
        private System.Windows.Forms.Button ButtonAdvancedSynchronize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelSynchronize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonWipeUserCollection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonWipeDatabase;
        private System.Windows.Forms.Label label4;
    }
}