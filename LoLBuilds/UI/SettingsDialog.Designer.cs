namespace com.jcandksolutions.lol.UI {
  partial class SettingsDialog {
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
      System.Windows.Forms.Label label1;
      System.Windows.Forms.Label label2;
      System.Windows.Forms.Label label3;
      this.APIKeyTextBox = new System.Windows.Forms.TextBox();
      this.LocaleTextBox = new System.Windows.Forms.TextBox();
      this.ServerTextBox = new System.Windows.Forms.TextBox();
      this.mOKButton = new System.Windows.Forms.Button();
      this.mCancelButton = new System.Windows.Forms.Button();
      label1 = new System.Windows.Forms.Label();
      label2 = new System.Windows.Forms.Label();
      label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new System.Drawing.Point(12, 9);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(45, 13);
      label1.TabIndex = 0;
      label1.Text = "API Key";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new System.Drawing.Point(12, 35);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(39, 13);
      label2.TabIndex = 0;
      label2.Text = "Locale";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new System.Drawing.Point(12, 61);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(38, 13);
      label3.TabIndex = 0;
      label3.Text = "Server";
      // 
      // APIKeyTextBox
      // 
      this.APIKeyTextBox.Location = new System.Drawing.Point(63, 6);
      this.APIKeyTextBox.Name = "APIKeyTextBox";
      this.APIKeyTextBox.Size = new System.Drawing.Size(170, 20);
      this.APIKeyTextBox.TabIndex = 1;
      // 
      // LocaleTextBox
      // 
      this.LocaleTextBox.Location = new System.Drawing.Point(63, 32);
      this.LocaleTextBox.Name = "LocaleTextBox";
      this.LocaleTextBox.Size = new System.Drawing.Size(170, 20);
      this.LocaleTextBox.TabIndex = 2;
      // 
      // ServerTextBox
      // 
      this.ServerTextBox.Location = new System.Drawing.Point(63, 58);
      this.ServerTextBox.Name = "ServerTextBox";
      this.ServerTextBox.Size = new System.Drawing.Size(170, 20);
      this.ServerTextBox.TabIndex = 3;
      // 
      // mOKButton
      // 
      this.mOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.mOKButton.Location = new System.Drawing.Point(40, 84);
      this.mOKButton.Name = "mOKButton";
      this.mOKButton.Size = new System.Drawing.Size(75, 23);
      this.mOKButton.TabIndex = 4;
      this.mOKButton.Text = "OK";
      this.mOKButton.UseVisualStyleBackColor = true;
      // 
      // mCancelButton
      // 
      this.mCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.mCancelButton.Location = new System.Drawing.Point(132, 84);
      this.mCancelButton.Name = "mCancelButton";
      this.mCancelButton.Size = new System.Drawing.Size(75, 23);
      this.mCancelButton.TabIndex = 5;
      this.mCancelButton.Text = "Cancel";
      this.mCancelButton.UseVisualStyleBackColor = true;
      // 
      // SettingsDialog
      // 
      this.AcceptButton = this.mOKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.mCancelButton;
      this.ClientSize = new System.Drawing.Size(247, 121);
      this.Controls.Add(this.mCancelButton);
      this.Controls.Add(this.mOKButton);
      this.Controls.Add(this.ServerTextBox);
      this.Controls.Add(label3);
      this.Controls.Add(this.LocaleTextBox);
      this.Controls.Add(label2);
      this.Controls.Add(this.APIKeyTextBox);
      this.Controls.Add(label1);
      this.Name = "SettingsDialog";
      this.Text = "Settings";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox APIKeyTextBox;
    private System.Windows.Forms.TextBox LocaleTextBox;
    private System.Windows.Forms.TextBox ServerTextBox;
    private System.Windows.Forms.Button mOKButton;
    private System.Windows.Forms.Button mCancelButton;
  }
}