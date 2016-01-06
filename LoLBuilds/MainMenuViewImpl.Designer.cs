namespace com.jcandksolutions.lol {
  partial class MainMenuViewImpl {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.UpdateDBButton = new System.Windows.Forms.Button();
      this.BuildBrowserButton = new System.Windows.Forms.Button();
      this.BuildEditorButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.CalculatorButton = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // UpdateDBButton
      // 
      this.UpdateDBButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UpdateDBButton.Location = new System.Drawing.Point(3, 3);
      this.UpdateDBButton.Name = "UpdateDBButton";
      this.UpdateDBButton.Size = new System.Drawing.Size(278, 53);
      this.UpdateDBButton.TabIndex = 0;
      this.UpdateDBButton.Text = "Update DB";
      this.UpdateDBButton.UseVisualStyleBackColor = true;
      this.UpdateDBButton.Click += new System.EventHandler(this.UpdateDBButton_Click);
      // 
      // BuildBrowserButton
      // 
      this.BuildBrowserButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BuildBrowserButton.Location = new System.Drawing.Point(3, 62);
      this.BuildBrowserButton.Name = "BuildBrowserButton";
      this.BuildBrowserButton.Size = new System.Drawing.Size(278, 53);
      this.BuildBrowserButton.TabIndex = 1;
      this.BuildBrowserButton.Text = "View Builds";
      this.BuildBrowserButton.UseVisualStyleBackColor = true;
      this.BuildBrowserButton.Click += new System.EventHandler(this.BuildBrowserButton_Click);
      // 
      // BuildEditorButton
      // 
      this.BuildEditorButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BuildEditorButton.Location = new System.Drawing.Point(3, 121);
      this.BuildEditorButton.Name = "BuildEditorButton";
      this.BuildEditorButton.Size = new System.Drawing.Size(278, 53);
      this.BuildEditorButton.TabIndex = 2;
      this.BuildEditorButton.Text = "Edit Builds";
      this.BuildEditorButton.UseVisualStyleBackColor = true;
      this.BuildEditorButton.Click += new System.EventHandler(this.BuildEditorButton_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.UpdateDBButton, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.BuildBrowserButton, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.BuildEditorButton, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.CalculatorButton, 0, 3);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 238);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // CalculatorButton
      // 
      this.CalculatorButton.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CalculatorButton.Location = new System.Drawing.Point(3, 180);
      this.CalculatorButton.Name = "CalculatorButton";
      this.CalculatorButton.Size = new System.Drawing.Size(278, 55);
      this.CalculatorButton.TabIndex = 3;
      this.CalculatorButton.Text = "Calculator";
      this.CalculatorButton.UseVisualStyleBackColor = true;
      this.CalculatorButton.Click += new System.EventHandler(this.CalculatorButton_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(284, 24);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
      this.settingsToolStripMenuItem.Text = "Settings...";
      this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
      // 
      // MainMenuView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainMenuView";
      this.Text = "Lol Builds";
      this.Load += new System.EventHandler(this.MainMenuView_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button UpdateDBButton;
    private System.Windows.Forms.Button BuildBrowserButton;
    private System.Windows.Forms.Button BuildEditorButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button CalculatorButton;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
  }
}