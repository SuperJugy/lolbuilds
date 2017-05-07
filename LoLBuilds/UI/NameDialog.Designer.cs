namespace com.jcandksolutions.lol.UI {
  partial class NameDialog {
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
      this.mOKButton = new System.Windows.Forms.Button();
      this.mCancelButton = new System.Windows.Forms.Button();
      this.NameTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // mOKButton
      // 
      this.mOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.mOKButton.Location = new System.Drawing.Point(51, 38);
      this.mOKButton.Name = "mOKButton";
      this.mOKButton.Size = new System.Drawing.Size(75, 23);
      this.mOKButton.TabIndex = 2;
      this.mOKButton.Text = "OK";
      this.mOKButton.UseVisualStyleBackColor = true;
      // 
      // mCancelButton
      // 
      this.mCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.mCancelButton.Location = new System.Drawing.Point(158, 38);
      this.mCancelButton.Name = "mCancelButton";
      this.mCancelButton.Size = new System.Drawing.Size(75, 23);
      this.mCancelButton.TabIndex = 3;
      this.mCancelButton.Text = "Cancel";
      this.mCancelButton.UseVisualStyleBackColor = true;
      // 
      // NameTextBox
      // 
      this.NameTextBox.Location = new System.Drawing.Point(53, 12);
      this.NameTextBox.Name = "NameTextBox";
      this.NameTextBox.Size = new System.Drawing.Size(200, 20);
      this.NameTextBox.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // NameDialog
      // 
      this.AcceptButton = this.mOKButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.mCancelButton;
      this.ClientSize = new System.Drawing.Size(284, 71);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.NameTextBox);
      this.Controls.Add(this.mCancelButton);
      this.Controls.Add(this.mOKButton);
      this.Name = "NameDialog";
      this.Text = "Name";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button mOKButton;
    private System.Windows.Forms.Button mCancelButton;
    private System.Windows.Forms.TextBox NameTextBox;
    private System.Windows.Forms.Label label1;
  }
}