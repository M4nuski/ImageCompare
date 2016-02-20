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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.logger1 = new ImageComparer.Logger();
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
            // baseFolderBox
            // 
            this.baseFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseFolderBox.Location = new System.Drawing.Point(152, 11);
            this.baseFolderBox.Name = "baseFolderBox";
            this.baseFolderBox.ReadOnly = true;
            this.baseFolderBox.Size = new System.Drawing.Size(526, 20);
            this.baseFolderBox.TabIndex = 2;
            // 
            // compareFolderBox
            // 
            this.compareFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.trashFolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // logger1
            // 
            this.logger1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logger1.Count = 0;
            this.logger1.CountStamp = false;
            this.logger1.CountStampFormat = "D4";
            this.logger1.DateStamp = false;
            this.logger1.DateStampFormat = "yyyy-MM-dd";
            this.logger1.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.logger1.Location = new System.Drawing.Point(152, 121);
            this.logger1.Multiline = true;
            this.logger1.Name = "logger1";
            this.logger1.ReadOnly = true;
            this.logger1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logger1.Size = new System.Drawing.Size(526, 278);
            this.logger1.TabIndex = 11;
            this.logger1.TimeStamp = true;
            this.logger1.TimeStampFormat = "HH-mm-ss";
            this.logger1.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 439);
            this.Controls.Add(this.logger1);
            this.Controls.Add(this.bubbleEmptyPathButton);
            this.Controls.Add(this.searchEmptyFolderButton);
            this.Controls.Add(this.clearCompareFolderListButton);
            this.Controls.Add(this.ChangeTrashFolder);
            this.Controls.Add(this.AddCompareFolderButton);
            this.Controls.Add(this.selectBaseFolderButton);
            this.Controls.Add(this.trashFolderBox);
            this.Controls.Add(this.compareFolderBox);
            this.Controls.Add(this.baseFolderBox);
            this.Controls.Add(this.startCompareButton);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(478, 478);
            this.Name = "MainForm";
            this.Text = "Image Duplicate Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startCompareButton;
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
        private Logger logger1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

