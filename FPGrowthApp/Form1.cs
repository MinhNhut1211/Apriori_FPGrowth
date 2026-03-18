using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FPGrowthSmartApp
{
    public partial class Form1 : Form
    {
        public class FPNode
        {
            public string Name { get; set; }
            public int Count { get; set; }
            public FPNode Parent { get; set; }
            public Dictionary<string, FPNode> Children { get; set; } = new Dictionary<string, FPNode>();

            public FPNode(string name, int count, FPNode parent)
            {
                Name = name;
                Count = count;
                Parent = parent;
            }
        }

        private FPNode lastRoot = null;

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            // Mặc định chọn dữ liệu mẫu
            rbSample.Checked = true;
            LoadSampleData();
        }

        private void InitializeGrid()
        {
            dgvData.Columns.Clear();
            dgvData.Columns.Add("TID", "Mã Giao Dịch (TID)");
            dgvData.Columns.Add("Items", "Nội dung (Cách nhau dấu phẩy)");
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadSampleData()
        {
            dgvData.Rows.Clear();
            dgvData.Rows.Add("T01", "A, B, C, E");
            dgvData.Rows.Add("T02", "A, B, C, F");
            dgvData.Rows.Add("T03", "A, B, C");
            dgvData.Rows.Add("T04", "A, B, D");
            dgvData.Rows.Add("T05", "A, C, E");
            dgvData.Rows.Add("T06", "A, B, C, E");
            dgvData.Rows.Add("T07", "B, C, E");
            dgvData.Rows.Add("T08", "A, B, C, D, E");
            dgvData.Rows.Add("T09", "A, B");
            dgvData.Rows.Add("T10", "A, B, C, E");

            // Nhóm 2: Thêm các giao dịch mới để tăng độ phức tạp
            dgvData.Rows.Add("T11", "A, C, G");
            dgvData.Rows.Add("T12", "B, D, F");
            dgvData.Rows.Add("T13", "A, B, C, G, E");
            dgvData.Rows.Add("T14", "B, C, D, E");
            dgvData.Rows.Add("T15", "A, B, C, D, F");
            dgvData.Rows.Add("T16", "A, E, G");
            dgvData.Rows.Add("T17", "A, B, C, E, F");
            dgvData.Rows.Add("T18", "B, C, G");
            dgvData.Rows.Add("T19", "A, B, D, E");
            dgvData.Rows.Add("T20", "A, B, C, D, E, G");
        }

        private void rbSample_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSample.Checked)
            {
                LoadSampleData();
                dgvData.ReadOnly = true; // Không cho sửa khi dùng mẫu
            }
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManual.Checked)
            {
                dgvData.Rows.Clear();
                dgvData.ReadOnly = false; // Cho phép nhập tay
                MessageBox.Show("Mời bạn nhập dữ liệu trực tiếp vào bảng bên dưới!", "Thông báo");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            lastRoot = null;
            pnlTree.Invalidate();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var transactions = new List<List<string>>();
            var itemCounts = new Dictionary<string, int>();

            // Đọc dữ liệu từ Grid
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[1].Value == null) continue;
                var items = row.Cells[1].Value.ToString().Split(',')
                            .Select(x => x.Trim().ToUpper())
                            .Where(x => !string.IsNullOrEmpty(x)).ToList();
                if (items.Count == 0) continue;

                transactions.Add(items);
                foreach (var item in items)
                {
                    if (itemCounts.ContainsKey(item)) itemCounts[item]++;
                    else itemCounts[item] = 1;
                }
            }

            if (transactions.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!"); return;
            }

            int minSup = (int)numMinSup.Value;
            var headerTable = itemCounts.Where(x => x.Value >= minSup)
                                        .OrderByDescending(x => x.Value)
                                        .ThenBy(x => x.Key)
                                        .Select(x => x.Key).ToList();

            FPNode root = new FPNode("Root", 0, null);
            foreach (var trans in transactions)
            {
                var sortedTrans = trans.Where(x => headerTable.Contains(x))
                                       .OrderBy(x => headerTable.IndexOf(x)).ToList();

                FPNode current = root;
                foreach (var item in sortedTrans)
                {
                    if (current.Children.ContainsKey(item)) current.Children[item].Count++;
                    else
                    {
                        var newNode = new FPNode(item, 1, current);
                        current.Children.Add(item, newNode);
                    }
                    current = current.Children[item];
                }
            }

            lastRoot = root;
            pnlTree.Invalidate();
        }

        private void pnlTree_Paint(object sender, PaintEventArgs e)
        {
            if (lastRoot == null) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            string target = txtSearch.Text.Trim().ToUpper();
            RenderNode(e.Graphics, lastRoot, pnlTree.Width / 2, 40, pnlTree.Width / 4, target);
        }

        private bool RenderNode(Graphics g, FPNode node, int x, int y, int xOffset, string target)
        {
            bool isPath = (!string.IsNullOrEmpty(target) && (node.Name == target || HasTargetInDescendants(node, target)));

            int count = 0;
            foreach (var child in node.Children.Values)
            {
                int childX = (node.Children.Count == 1) ? x : x - xOffset + (count * xOffset * 2 / (node.Children.Count - 1));
                int childY = y + 70;

                bool childIsPath = (!string.IsNullOrEmpty(target) && (child.Name == target || HasTargetInDescendants(child, target)));

                Pen linePen = childIsPath ? new Pen(Color.Red, 2) : Pens.LightGray;
                g.DrawLine(linePen, x, y + 15, childX, childY - 15);
                RenderNode(g, child, childX, childY, xOffset / 2, target);
                count++;
            }

            int radius = 18;
            Brush fillBrush = (node.Name == target) ? Brushes.Orange : (node.Name == "Root" ? Brushes.LightGray : Brushes.White);
            Pen borderPen = isPath ? new Pen(Color.Red, 2) : Pens.Black;

            g.FillEllipse(fillBrush, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(borderPen, x - radius, y - radius, radius * 2, radius * 2);

            string label = node.Name == "Root" ? "{}" : $"{node.Name}:{node.Count}";
            g.DrawString(label, new Font("Arial", 8, isPath ? FontStyle.Bold : FontStyle.Regular), Brushes.Black, x - 12, y - 6);

            return isPath;
        }

        private bool HasTargetInDescendants(FPNode node, string target)
        {
            if (node.Name == target) return true;
            return node.Children.Values.Any(c => HasTargetInDescendants(c, target));
        }
        private void HighlightItemPath(FPNode root, string targetItem)
        {
            using (Graphics g = pnlTree.CreateGraphics())
            {
                g.Clear(Color.White);
                RenderNodeWithHighlight(g, root, pnlTree.Width / 2, 30, pnlTree.Width / 4, targetItem);
            }
        }

        private bool RenderNodeWithHighlight(Graphics g, FPNode node, int x, int y, int xOffset, string target)
        {
            bool isPath = (node.Name == target);

            // Đệ quy vẽ các con trước để xác định xem nút hiện tại có nằm trên đường dẫn không
            int count = 0;
            foreach (var child in node.Children.Values)
            {
                int childX = (node.Children.Count == 1) ? x : x - xOffset + (count * xOffset * 2 / (node.Children.Count - 1));
                int childY = y + 70;

                if (RenderNodeWithHighlight(g, child, childX, childY, xOffset / 2, target))
                {
                    isPath = true; // Nếu con thuộc đường dẫn, thì cha cũng thuộc đường dẫn
                    g.DrawLine(new Pen(Color.Red, 2), x, y + 20, childX, childY - 20); // Vẽ đường nối màu đỏ
                }
                else
                {
                    g.DrawLine(Pens.LightGray, x, y + 20, childX, childY - 20);
                }
                count++;
            }

            // Vẽ nút
            int radius = 20;
            Brush fillBrush = isPath ? Brushes.Orange : (node.Name == "Root" ? Brushes.LightGray : Brushes.White);
            Pen borderPen = isPath ? new Pen(Color.Red, 2) : Pens.Black;

            g.FillEllipse(fillBrush, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(borderPen, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawString($"{node.Name}:{node.Count}", this.Font, Brushes.Black, x - 15, y - 7);

            return isPath;
        }
        private void btnApriori_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ DataGridView hiện tại
            var transactions = new List<List<string>>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[1].Value == null) continue;
                var items = row.Cells[1].Value.ToString().Split(',')
                            .Select(x => x.Trim().ToUpper())
                            .Where(x => !string.IsNullOrEmpty(x)).ToList();
                if (items.Count > 0) transactions.Add(items);
            }

            if (transactions.Count == 0) return;

            // Mở Form Apriori và truyền dữ liệu sang
            AprioriResultForm aprioriForm = new AprioriResultForm(transactions, (int)numMinSup.Value);
            aprioriForm.Show(); // Hiển thị cửa sổ kết quả
        }
    }
}