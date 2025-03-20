# QLSVNhomApp

Ứng dụng QLSVNhomApp là một ứng dụng Windows Forms (C#) dùng để quản lý sinh viên, lớp học, điểm thi với các chức năng đăng nhập, quản lý lớp – sinh viên và nhập điểm. Ứng dụng kết nối với SQL Server và sử dụng các stored procedure để thực hiện các nghiệp vụ, trong đó có việc mã hóa dữ liệu bằng thuật toán RSA và SHA1.

## Cấu trúc thư mục
QLSVNhomApp/                      <-- Thư mục gốc của project <br>
├── App.config                    <-- File cấu hình, chứa chuỗi kết nối đến SQL Server<br>
├── Program.cs                    <-- Điểm khởi đầu của ứng dụng<br>
├── Data/                         <br>
│   └── DatabaseHelper.cs         <-- Lớp tiện ích lấy chuỗi kết nối từ file cấu hình<br>
├── Forms/                        <br>
│   ├── LoginForm.cs              <-- Form đăng nhập (UI và xử lý logic đăng nhập)<br>
│   └── MainForm.cs               <-- Form chính quản lý lớp, sinh viên và nhập điểm<br>
├── Utils/                        <br>
│   └── EncryptionHelper.cs       <-- Lớp tiện ích cho các hàm mã hóa (nếu cần xử lý phía client)<br>
└── SQL/                          <br>
    ├── ab.sql                    <-- Script tạo cơ sở dữ liệu, bảng và các khóa ngoại<br>
    ├── c.sql                     <-- Script tạo các stored procedure (SP_INS_PUBLIC_NHANVIEN, SP_SEL_PUBLIC_NHANVIEN)<br>
    ├── data.sql                  <-- Script tạo dữ liệu mẫu (dữ liệu cho bảng NHANVIEN, LOP, HOCPHAN, SINHVIEN, BANGDIEM)<br>
    └── d.sql                     <-- Script tạo các stored procedure mới cần dùng cho ứng dụng (ví dụ: SP_INS_DIEM)<br>


## Yêu cầu hệ thống

- **Visual Studio:**  
  - Cài đặt Visual Studio 2019 (hoặc phiên bản mới hơn) với hỗ trợ phát triển ứng dụng Windows Forms (C#).

- **.NET Framework / .NET Core:**  
  - Dự án có thể được phát triển trên .NET Framework (ví dụ .NET Framework 4.7.2) hoặc .NET Core (.NET 5/6).  
  - Nếu dùng .NET Core, hãy đảm bảo cài đặt phiên bản SDK tương ứng.

- **SQL Server:**  
  - Cài đặt SQL Server (SQL Server Express là đủ) để tạo và quản lý cơ sở dữ liệu.
  - Cài đặt SQL Server Management Studio (SSMS) để chạy các script SQL từ thư mục **SQL**.

- **NuGet Packages:**  
  - Nếu bạn sử dụng .NET Framework, đảm bảo thêm tham chiếu đến assembly **System.Data.SqlClient**:
    - Click chuột phải vào **References** trong Solution Explorer, chọn **Add Reference...** và tìm **System.Data.SqlClient**.
  - Nếu bạn dùng .NET Core hoặc .NET 5/6, cài đặt package **Microsoft.Data.SqlClient** qua NuGet:
    - Mở **Manage NuGet Packages** và cài đặt **Microsoft.Data.SqlClient**.
  - Nếu bạn muốn tiếp tục sử dụng namespace **System.Data.SqlClient** trên .NET Core, bạn cũng có thể cài đặt package **System.Data.SqlClient** thông qua NuGet.

## Hướng dẫn cài đặt và chạy ứng dụng

1. **Clone/Download dự án:**  
   - Tải về mã nguồn của dự án và mở solution trong Visual Studio.

2. **Cấu hình dự án:**
   - Sắp xếp các file theo cấu trúc thư mục như trên.
   - Mở file **App.config** và cập nhật chuỗi kết nối:
     ```xml
     <connectionStrings>
       <add name="QLSVNhomConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=QLSVNhom;Integrated Security=True" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
     Thay `YOUR_SERVER` bằng tên server SQL của bạn.

3. **Cài đặt NuGet packages:**
   - Nếu dùng .NET Framework, kiểm tra rằng **System.Data.SqlClient** đã được thêm.
   - Nếu dùng .NET Core/5/6, cài đặt **Microsoft.Data.SqlClient** (hoặc **System.Data.SqlClient** nếu cần) thông qua NuGet Package Manager.

4. **Thiết lập CSDL:**
   - Mở SQL Server Management Studio (SSMS).
   - Chạy lần lượt các file SQL theo thứ tự sau (trong thư mục **SQL**):
     1. **ab.sql**: Tạo database, bảng và các ràng buộc khóa ngoại.
     2. **c.sql**: Tạo stored procedure cho phần (c).
     3. **data.sql**: Tạo dữ liệu mẫu.
     4. **d.sql**: Tạo stored procedure SP_INS_DIEM và các procedure mới cần dùng cho ứng dụng.
   - Đảm bảo các script này chạy thành công và database QLSVNhom được tạo.

5. **Build và chạy ứng dụng:**
   - Trong Visual Studio, chọn **Build > Build Solution** hoặc nhấn **Ctrl+Shift+B**.
   - Sau khi build thành công, nhấn **F5** để chạy ứng dụng.
   - Form đăng nhập sẽ hiện ra. Nhập thông tin tài khoản và mật khẩu (dựa trên dữ liệu mẫu trong bảng NHANVIEN) để đăng nhập và kiểm tra các chức năng.

6. **Debug và kiểm tra:**
   - Sử dụng các công cụ debug của Visual Studio để kiểm tra và khắc phục lỗi (nếu có).

---

Với các bước và cấu trúc trên, bạn có thể dễ dàng cài đặt, cấu hình và chạy ứng dụng QLSVNhomApp trên Visual Studio. Nếu có thắc mắc hoặc cần hỗ trợ thêm, vui lòng liên hệ với nhóm phát triển hoặc tham khảo tài liệu Microsoft về Windows Forms và NuGet.
