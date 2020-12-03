namespace SS
{
    partial class window
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.cellInputBox = new System.Windows.Forms.TextBox();
            this.spreadsheetPanel1 = new SS.SpreadsheetPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CellNameLabel = new System.Windows.Forms.Label();
            this.FileToolStrip = new System.Windows.Forms.ToolStrip();
            this.FileDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpButton = new System.Windows.Forms.ToolStripButton();
            this.DarkModeButton = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.HelpTextBox = new System.Windows.Forms.RichTextBox();
            this.CloseHelpButton = new System.Windows.Forms.Button();
            this.FileToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellInputBox
            // 
            this.cellInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cellInputBox.BackColor = System.Drawing.Color.White;
            this.cellInputBox.ForeColor = System.Drawing.Color.Black;
            this.cellInputBox.Location = new System.Drawing.Point(273, 29);
            this.cellInputBox.Name = "cellInputBox";
            this.cellInputBox.Size = new System.Drawing.Size(504, 20);
            this.cellInputBox.TabIndex = 0;
            this.cellInputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CellInputBox_KeyDown);
            // 
            // spreadsheetPanel1
            // 
            this.spreadsheetPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spreadsheetPanel1.Location = new System.Drawing.Point(-2, 54);
            this.spreadsheetPanel1.Name = "spreadsheetPanel1";
            this.spreadsheetPanel1.Size = new System.Drawing.Size(802, 397);
            this.spreadsheetPanel1.TabIndex = 2;
            this.spreadsheetPanel1.SelectionChanged += new SS.SelectionChangedHandler(this.SpreadsheetPanel1_SelectionChanged);
            this.spreadsheetPanel1.Load += new System.EventHandler(this.SpreadsheetPanel1_Load);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CellNameLabel
            // 
            this.CellNameLabel.AutoEllipsis = true;
            this.CellNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CellNameLabel.Location = new System.Drawing.Point(12, 29);
            this.CellNameLabel.Name = "CellNameLabel";
            this.CellNameLabel.Size = new System.Drawing.Size(255, 18);
            this.CellNameLabel.TabIndex = 5;
            this.CellNameLabel.Text = "A1 = ";
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.FileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDropDownButton,
            this.helpButton,
            this.DarkModeButton});
            this.FileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.Size = new System.Drawing.Size(800, 25);
            this.FileToolStrip.TabIndex = 6;
            this.FileToolStrip.Text = "toolStrip1";
            // 
            // FileDropDownButton
            // 
            this.FileDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.FileDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("FileDropDownButton.Image")));
            this.FileDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileDropDownButton.Name = "FileDropDownButton";
            this.FileDropDownButton.Size = new System.Drawing.Size(38, 22);
            this.FileDropDownButton.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpButton
            // 
            this.helpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpButton.Image = ((System.Drawing.Image)(resources.GetObject("helpButton.Image")));
            this.helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(36, 22);
            this.helpButton.Text = "Help";
            this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // DarkModeButton
            // 
            this.DarkModeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DarkModeButton.Image = ((System.Drawing.Image)(resources.GetObject("DarkModeButton.Image")));
            this.DarkModeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DarkModeButton.Name = "DarkModeButton";
            this.DarkModeButton.Size = new System.Drawing.Size(88, 22);
            this.DarkModeButton.Text = "Dark Mode On";
            this.DarkModeButton.ToolTipText = "Dark Mode Toggle";
            this.DarkModeButton.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // HelpTextBox
            // 
            this.HelpTextBox.Location = new System.Drawing.Point(117, 92);
            this.HelpTextBox.Name = "HelpTextBox";
            this.HelpTextBox.ReadOnly = true;
            this.HelpTextBox.Size = new System.Drawing.Size(586, 323);
            this.HelpTextBox.TabIndex = 7;
            this.HelpTextBox.Text = resources.GetString("HelpTextBox.Text");
            this.HelpTextBox.Visible = false;
            // 
            // CloseHelpButton
            // 
            this.CloseHelpButton.Location = new System.Drawing.Point(671, 103);
            this.CloseHelpButton.Name = "CloseHelpButton";
            this.CloseHelpButton.Size = new System.Drawing.Size(20, 20);
            this.CloseHelpButton.TabIndex = 8;
            this.CloseHelpButton.Text = "X";
            this.CloseHelpButton.UseVisualStyleBackColor = true;
            this.CloseHelpButton.Visible = false;
            this.CloseHelpButton.Click += new System.EventHandler(this.CloseHelpButton_Click);
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseHelpButton);
            this.Controls.Add(this.HelpTextBox);
            this.Controls.Add(this.FileToolStrip);
            this.Controls.Add(this.CellNameLabel);
            this.Controls.Add(this.spreadsheetPanel1);
            this.Controls.Add(this.cellInputBox);
            this.Name = "window";
            this.ShowIcon = false;
            this.Text = "Spreadsheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.FileToolStrip.ResumeLayout(false);
            this.FileToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cellInputBox;
        private SS.SpreadsheetPanel spreadsheetPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label CellNameLabel;
        private System.Windows.Forms.ToolStrip FileToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton FileDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripButton DarkModeButton;
        private System.Windows.Forms.ToolStripButton helpButton;
        private System.Windows.Forms.RichTextBox HelpTextBox;
        private System.Windows.Forms.Button CloseHelpButton;
    }
}

