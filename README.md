# 📊FP-Growth & Apriori Visualizer (C# WinForms) <p>
Ứng dụng trực quan hóa thuật toán khai thác tập phổ biến (Frequent Itemset Mining) 
được xây dựng trên nền tảng .NET WinForms. Công cụ này giúp người học và nhà nghiên cứu dễ dàng 
so sánh cấu trúc nén dữ liệu của FP-Tree so với cách tiếp cận duyệt ứng viên truyền thống của Apriori.
# 🚀 Tính năng nổi bật <p>
- FP-Tree Visualization: Tự động dựng và vẽ cây FP-Tree bằng GDI+.<p>
- Path Highlighting: Highlight đường dẫn (prefix paths) từ Root đến Item cụ thể để phân tích tập điều kiện.<p>
- Dual Algorithm Support: Hỗ trợ đồng thời thuật toán Apriori để đối chiếu kết quả $L_k$.<p>
- Flexible Data Input:Nhập liệu trực tiếp qua DataGridView.Nạp bộ dữ liệu mẫu (8 giao dịch, 20 giao dịch).Tùy chỉnh ngưỡng hỗ trợ tối thiểu (Minimum Support).<p>
# 🏗️ Cấu trúc Mã nguồn (Source Code Analysis) <p>
## 1. Model & Data Structures (FPNode.cs)<p>
Định nghĩa lớp FPNode để lưu trữ cấu trúc cây. <p>
- Name: Tên của Item (A, B, C...).<p>
- Count: Tần suất xuất hiện tại nhánh đó.<p>
- Children: Danh sách các nút con sử dụng Dictionary<string, FPNode> để tối ưu tốc độ tìm kiếm.<p>
## 2. Core Logic (Form1.cs)<p>
- Xây dựng cây: Duyệt dữ liệu, sắp xếp Item theo tần suất giảm dần và chèn vào cây.<p>
- Thuật toán vẽ (Rendering): Sử dụng đệ quy để tính toán tọa độ các Node, đảm bảo cây cân đối và không bị chồng lấn.<p>
## 3. Giao diện người dùng (Form1.Designer.cs)<p>
- Bên trái: Bảng điều khiển (Sidebar) chứa các thiết lập thông số.<p>
- Bên phải: Canvas vẽ cây (Panel) với chế độ DoubleBuffered giúp hình ảnh mượt mà, không bị nháy.<p>
# 🛠️ Hướng dẫn cài đặt<p>
1. Yêu cầu: Cài đặt Visual Studio (2019 hoặc 2022) và .NET Framework 4.7.2+.<p>
2. Clone Project: (https://github.com/MinhNhut1211/Apriori_FPGrowth/tree/master) <p>
3. Mở Project: Nhấp đúp vào file .sln để mở trong Visual Studio.<p>
4. Build & Run: Nhấn F5 hoặc nút Start.<p>
# 📷 Hình ảnh Demo
<img width="1917" height="794" alt="Screenshot 2026-03-18 143707" src="https://github.com/user-attachments/assets/d980cffa-4e90-4db6-b6fa-4843be0c7358" /> <p>
# Contact <p>
##### Facebook: https://www.facebook.com/tranminhnhut121102 <p>
##### Momo: 0939125541
