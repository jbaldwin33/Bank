namespace Bank
{
  partial class AccountActivity
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
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.lblActivity = new System.Windows.Forms.Label();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add(this.lblActivity);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 24);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(776, 414);
      this.flowLayoutPanel1.TabIndex = 0;
      // 
      // lblActivity
      // 
      this.lblActivity.AutoSize = true;
      this.lblActivity.Location = new System.Drawing.Point(15, 15);
      this.lblActivity.Margin = new System.Windows.Forms.Padding(15, 15, 15, 0);
      this.lblActivity.Name = "lblActivity";
      this.lblActivity.Size = new System.Drawing.Size(157, 20);
      this.lblActivity.TabIndex = 0;
      this.lblActivity.Text = "Account Activity For: ";
      // 
      // AccountActivity
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Name = "AccountActivity";
      this.Text = "AccountActivity";
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label lblActivity;
  }
}