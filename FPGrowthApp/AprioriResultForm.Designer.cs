namespace FPGrowthSmartApp
{
    partial class AprioriResultForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // txtLog
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Multiline = true;
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            // Form
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.txtLog);
            this.Text = "Kết quả thuật toán Apriori";
            this.ResumeLayout(false);
        }
    }
}