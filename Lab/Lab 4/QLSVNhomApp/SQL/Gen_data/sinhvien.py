# Tạo dữ liệu mẫu cho bảng SINHVIEN
import pandas as pd
import random
import string

# Danh sách tên phổ biến ở Việt Nam
ho = ["Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Đặng", "Bùi", "Đỗ", "Hồ", "Ngô"]
ten_dem = ["Văn", "Hữu", "Quang", "Minh", "Đăng", "Hoài", "Thanh", "Thị", "Bảo", "Nhật"]
ten = ["An", "Bình", "Chi", "Duy", "Giang", "Hà", "Khoa", "Linh", "Mai", "Nam", "Phương", "Quân", "Sơn", "Trang", "Uyên", "Vỹ"]

# Danh sách các quận ở TP. Hồ Chí Minh
quan_hcm = [
    "Quận 1", "Quận 2", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7", "Quận 8", "Quận 9",
    "Quận 10", "Quận 11", "Quận 12", "Bình Thạnh", "Gò Vấp", "Phú Nhuận", "Tân Bình",
    "Tân Phú", "Bình Tân", "Thủ Đức", "Nhà Bè", "Củ Chi", "Hóc Môn", "Bình Chánh"
]

# Số lượng sinh viên
num_students = 100

students = []

for i in range(1,num_students+1):
    masv = f"SV{str(i).zfill(3)}"
    hoten = f"{random.choice(ho)} {random.choice(ten_dem)} {random.choice(ten)}"
    ngaysinh = f"{random.randint(2002, 2004)}-{random.randint(1, 12):02d}-{random.randint(1, 28):02d}"
    malop = f"L{random.randint(1, 5):02d}"
    diachi = random.choice(quan_hcm)
    
    # Tạo tên đăng nhập từ chữ cái đầu của từng phần trong họ tên
    tendn = "".join([x[0].lower() for x in hoten.split()]) + random.choice(string.ascii_lowercase)
    
    # Mật khẩu là 6 chữ số ngẫu nhiên
    matkhau = "".join(random.choices(string.digits, k=6))
    
    students.append([masv, hoten, ngaysinh,diachi, malop, tendn, matkhau])

# Chuyển thành DataFrame
df_students = pd.DataFrame(students, columns=["MASV", "HOTEN", "NGAYSINH","DIACHI", "MALOP", "TENDN", "MATKHAU"])

# Tạo script SQL
sql_script = """
-- Chèn dữ liệu vào bảng SINHVIEN
INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
VALUES
"""

# Thêm các câu lệnh INSERT
for _, row in df_students.iterrows():
    sql_script += f"('{row['MASV']}', N'{row['HOTEN']}', '{row['NGAYSINH']}', " \
                   f"N'{row['DIACHI']}', '{row['MALOP']}', '{row['TENDN']}', HASHBYTES('SHA1', '{row['MATKHAU']}')),\n"

sql_script = sql_script[:-2] + ";"  # Xóa dấu phẩy cuối cùng và thêm dấu chấm phẩy
sql_script += "\n GO"  # Kết thúc script
# Lưu vào file SQL
sql_script_path = "sinhvien_data.sql"
with open(sql_script_path, "w", encoding="utf-8") as f:
    f.write(sql_script)

# Trả về file cho người dùng
sql_script_path
