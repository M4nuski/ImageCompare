namespace ImageComparer
{
    partial class MainForm
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
            this.startCompareButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.baseFolderBox = new System.Windows.Forms.TextBox();
            this.compareFolderBox = new System.Windows.Forms.TextBox();
            this.trashFolderBox = new System.Windows.Forms.TextBox();
            this.selectBaseFolderButton = new System.Windows.Forms.Button();
            this.AddCompareFolderButton = new System.Windows.Forms.Button();
            this.ChangeTrashFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.clearCompareFolderListButton = new System.Windows.Forms.Button();
            this.searchEmptyFolderButton = new System.Windows.Forms.Button();
            this.bubbleEmptyPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startCompareButton
            // 
            this.startCompareButton.Location = new System.Drawing.Point(12, 337);
            this.startCompareButton.Name = "startCompareButton";
            this.startCompareButton.Size = new System.Drawing.Size(134, 62);
            this.startCompareButton.TabIndex = 0;
            this.startCompareButton.Text = "Scan and Trash Duplicate Images";
            this.startCompareButton.UseVisualStyleBackColor = true;
            this.startCompareButton.Click += new System.EventHandler(this.startCompareButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(152, 121);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(526, 278);
            this.logTextBox.TabIndex = 1;
            this.logTextBox.WordWrap = false;
            // 
            // baseFolderBox
            // 
            this.baseFolderBox.Location = new System.Drawing.Point(152, 11);
            this.baseFolderBox.Name = "baseFolderBox";
            this.baseFolderBox.ReadOnly = true;
            this.baseFolderBox.Size = new System.Drawing.Size(526, 20);
            this.baseFolderBox.TabIndex = 2;
            // 
            // compareFolderBox
            // 
            this.compareFolderBox.Location = new System.Drawing.Point(152, 40);
            this.compareFolderBox.Multiline = true;
            this.compareFolderBox.Name = "compareFolderBox";
            this.compareFolderBox.ReadOnly = true;
            this.compareFolderBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.compareFolderBox.Size = new System.Drawing.Size(526, 72);
            this.compareFolderBox.TabIndex = 3;
            // 
            // trashFolderBox
            // 
            this.trashFolderBox.Location = new System.Drawing.Point(153, 407);
            this.trashFolderBox.Name = "trashFolderBox";
            this.trashFolderBox.ReadOnly = true;
            this.trashFolderBox.Size = new System.Drawing.Size(526, 20);
            this.trashFolderBox.TabIndex = 4;
            this.trashFolderBox.Text = "C:\\$Recycle.Bin";
            // 
            // selectBaseFolderButton
            // 
            this.selectBaseFolderButton.Location = new System.Drawing.Point(12, 10);
            this.selectBaseFolderButton.Name = "selectBaseFolderButton";
            this.selectBaseFolderButton.Size = new System.Drawing.Size(134, 23);
            this.selectBaseFolderButton.TabIndex = 5;
            this.selectBaseFolderButton.Text = "Select Base Folder";
            this.selectBaseFolderButton.UseVisualStyleBackColor = true;
            this.selectBaseFolderButton.Click += new System.EventHandler(this.selectBaseFolderButton_Click);
            // 
            // AddCompareFolderButton
            // 
            this.AddCompareFolderButton.Location = new System.Drawing.Point(12, 39);
            this.AddCompareFolderButton.Name = "AddCompareFolderButton";
            this.AddCompareFolderButton.Size = new System.Drawing.Size(134, 23);
            this.AddCompareFolderButton.TabIndex = 6;
            this.AddCompareFolderButton.Text = "Add Folder to Compare";
            this.AddCompareFolderButton.UseVisualStyleBackColor = true;
            this.AddCompareFolderButton.Click += new System.EventHandler(this.AddCompareFolderButton_Click);
            // 
            // ChangeTrashFolder
            // 
            this.ChangeTrashFolder.Enabled = false;
            this.ChangeTrashFolder.Location = new System.Drawing.Point(12, 405);
            this.ChangeTrashFolder.Name = "ChangeTrashFolder";
            this.ChangeTrashFolder.Size = new System.Drawing.Size(134, 23);
            this.ChangeTrashFolder.TabIndex = 7;
            this.ChangeTrashFolder.Text = "Select Trash Fodler";
            this.ChangeTrashFolder.UseVisualStyleBackColor = true;
            this.ChangeTrashFolder.Click += new System.EventHandler(this.ChangeTrashFolder_Click);
            // 
            // clearCompareFolderListButton
            // 
            this.clearCompareFolderListButton.Location = new System.Drawing.Point(12, 89);
            this.clearCompareFolderListButton.Name = "clearCompareFolderListButton";
            this.clearCompareFolderListButton.Size = new System.Drawing.Size(134, 23);
            this.clearCompareFolderListButton.TabIndex = 8;
            this.clearCompareFolderListButton.Text = "Clear Folder List";
            this.clearCompareFolderListButton.UseVisualStyleBackColor = true;
            this.clearCompareFolderListButton.Click += new System.EventHandler(this.clearCompareFolderListButton_Click);
            // 
            // searchEmptyFolderButton
            // 
            this.searchEmptyFolderButton.Location = new System.Drawing.Point(12, 121);
            this.searchEmptyFolderButton.Name = "searchEmptyFolderButton";
            this.searchEmptyFolderButton.Size = new System.Drawing.Size(133, 62);
            this.searchEmptyFolderButton.TabIndex = 9;
            this.searchEmptyFolderButton.Text = "Scan and Trash Empty Folders";
            this.searchEmptyFolderButton.UseVisualStyleBackColor = true;
            // 
            // bubbleEmptyPathButton
            // 
            this.bubbleEmptyPathButton.Location = new System.Drawing.Point(11, 189);
            this.bubbleEmptyPathButton.Name = "bubbleEmptyPathButton";
            this.bubbleEmptyPathButton.Size = new System.Drawing.Size(134, 62);
            this.bubbleEmptyPathButton.TabIndex = 10;
            this.bubbleEmptyPathButton.Text = "Bubble Empty Paths";
            this.bubbleEmptyPathButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 439);
            this.Controls.Add(this.bubbleEmptyPathButton);
            this.Controls.Add(this.searchEmptyFolderButton);
            this.Controls.Add(this.clearCompareFolderListButton);
            this.Controls.Add(this.ChangeTrashFolder);
            this.Controls.Add(this.AddCompareFolderButton);
            this.Controls.Add(this.selectBaseFolderButton);
            this.Controls.Add(this.trashFolderBox);
            this.Controls.Add(this.compareFolderBox);
            this.Controls.Add(this.baseFolderBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.startCompareButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image Duplicate Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startCompareButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox baseFolderBox;
        private System.Windows.Forms.TextBox compareFolderBox;
        private System.Windows.Forms.TextBox trashFolderBox;
        private System.Windows.Forms.Button selectBaseFolderButton;
        private System.Windows.Forms.Button AddCompareFolderButton;
        private System.Windows.Forms.Button ChangeTrashFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button clearCompareFolderListButton;
        private System.Windows.Forms.Button searchEmptyFolderButton;
        private System.Windows.Forms.Button bubbleEmptyPathButton;
    }
}

