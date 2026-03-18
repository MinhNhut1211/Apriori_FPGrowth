namespace FPGrowthSmartApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các thành phần giao diện
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Button btnApriori;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.NumericUpDown numMinSup;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rbSample;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.Label lblSup;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlControl;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.rbSample = new System.Windows.Forms.RadioButton();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.lblSup = new System.Windows.Forms.Label();
            this.numMinSup = new System.Windows.Forms.NumericUpDown();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApriori = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(16, 62);
            this.dgvData.Margin = new System.Windows.Forms.Padding(4);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(387, 431);
            this.dgvData.TabIndex = 2;
            // 
            // pnlTree
            // 
            this.pnlTree.BackColor = System.Drawing.Color.White;
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTree.Location = new System.Drawing.Point(427, 0);
            this.pnlTree.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(1040, 738);
            this.pnlTree.TabIndex = 0;
            this.pnlTree.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTree_Paint);
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControl.Controls.Add(this.rbSample);
            this.pnlControl.Controls.Add(this.rbManual);
            this.pnlControl.Controls.Add(this.dgvData);
            this.pnlControl.Controls.Add(this.lblSup);
            this.pnlControl.Controls.Add(this.numMinSup);
            this.pnlControl.Controls.Add(this.lblSearch);
            this.pnlControl.Controls.Add(this.txtSearch);
            this.pnlControl.Controls.Add(this.btnRun);
            this.pnlControl.Controls.Add(this.btnClear);
            this.pnlControl.Controls.Add(this.btnApriori);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(427, 738);
            this.pnlControl.TabIndex = 1;
            // 
            // rbSample
            // 
            this.rbSample.Location = new System.Drawing.Point(27, 18);
            this.rbSample.Margin = new System.Windows.Forms.Padding(4);
            this.rbSample.Name = "rbSample";
            this.rbSample.Size = new System.Drawing.Size(160, 30);
            this.rbSample.TabIndex = 0;
            this.rbSample.Text = "Dữ liệu mẫu";
            this.rbSample.CheckedChanged += new System.EventHandler(this.rbSample_CheckedChanged);
            // 
            // rbManual
            // 
            this.rbManual.Location = new System.Drawing.Point(200, 18);
            this.rbManual.Margin = new System.Windows.Forms.Padding(4);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(160, 30);
            this.rbManual.TabIndex = 1;
            this.rbManual.Text = "Tự nhập tay";
            this.rbManual.CheckedChanged += new System.EventHandler(this.rbManual_CheckedChanged);
            // 
            // lblSup
            // 
            this.lblSup.Location = new System.Drawing.Point(16, 511);
            this.lblSup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSup.Name = "lblSup";
            this.lblSup.Size = new System.Drawing.Size(133, 28);
            this.lblSup.TabIndex = 3;
            this.lblSup.Text = "Min Support:";
            // 
            // numMinSup
            // 
            this.numMinSup.Location = new System.Drawing.Point(157, 509);
            this.numMinSup.Margin = new System.Windows.Forms.Padding(4);
            this.numMinSup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinSup.Name = "numMinSup";
            this.numMinSup.Size = new System.Drawing.Size(160, 22);
            this.numMinSup.TabIndex = 4;
            this.numMinSup.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(16, 548);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(133, 28);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Highlight Item:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(157, 545);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(105, 22);
            this.txtSearch.TabIndex = 6;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(12, 631);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(387, 49);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "CHẠY THUẬT TOÁN";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(16, 688);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(387, 37);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Làm mới bảng vẽ";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApriori
            // 
            this.btnApriori.BackColor = System.Drawing.Color.Orange;
            this.btnApriori.ForeColor = System.Drawing.Color.White;
            this.btnApriori.Location = new System.Drawing.Point(59, 584);
            this.btnApriori.Name = "btnApriori";
            this.btnApriori.Size = new System.Drawing.Size(290, 40);
            this.btnApriori.TabIndex = 9;
            this.btnApriori.Text = "XEM KẾT QUẢ APRIORI";
            this.btnApriori.UseVisualStyleBackColor = false;
            this.btnApriori.Click += new System.EventHandler(this.btnApriori_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 738);
            this.Controls.Add(this.pnlTree);
            this.Controls.Add(this.pnlControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FP-Growth Tree Visualizer - Professional Version";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinSup)).EndInit();
            this.ResumeLayout(false);

        }
    }
}