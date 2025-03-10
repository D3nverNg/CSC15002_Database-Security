--data.sql
USE QLSVNhom;
GO

-- 1. Chèn dữ liệu cho bảng NHANVIEN (nhân viên)
-- Các giá trị mật khẩu, lương và PUBKEY được lưu dưới dạng VARBINARY (giả định đã mã hóa hoặc sử dụng CONVERT)

-- 2. Chèn dữ liệu cho bảng LOP (lớp học)
-- Mỗi lớp được giao cho một nhân viên làm chủ nhiệm
INSERT INTO LOP (MALOP, TENLOP, MANV)
VALUES
('L1', N'Lớp 1', 'NV01'),
('L2', N'Lớp 2', 'NV02'),
('L3', N'Lớp 3', 'NV03'),
('L4', N'Lớp 4', 'NV04');
GO

-- 3. Chèn dữ liệu cho bảng HOCPHAN (học phần)
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC)
VALUES
('HP01', 'Toán', 3),
('HP02', 'Lý', 3),
('HP03', 'Hóa', 3),
('HP04', 'Sinh', 3),
('HP05', 'Tin', 3),
('HP06', 'Anh', 2);
GO

-- 4. Chèn dữ liệu cho bảng SINHVIEN (100 sinh viên)
-- Sinh viên được đánh số từ SV001 đến SV100, mỗi sinh viên sẽ được phân bổ vào một trong 4 lớp theo vòng lặp
DECLARE @i INT = 1;
WHILE @i <= 100
BEGIN
    INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
    VALUES (
        N'SV' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3),                       -- MASV: SV001, SV002, ...
        N'Sinh Viên ' + CAST(@i AS VARCHAR(10)),                                  -- HOTEN
        DATEADD(year, -20, GETDATE()),                                           -- NGAYSINH: giả sử sinh 20 tuổi
        N'Địa chỉ ' + CAST(@i AS VARCHAR(10)),                                    -- DIACHI
        CASE 
            WHEN @i % 4 = 1 THEN 'L1'
            WHEN @i % 4 = 2 THEN 'L2'
            WHEN @i % 4 = 3 THEN 'L3'
            ELSE 'L4'
        END,                                                                     -- MALOP: phân bổ đều cho 4 lớp
        'SV' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3),                       -- TENDN: sử dụng MASV làm tên đăng nhập
        CONVERT(VARBINARY(MAX), 'password')                                      -- MATKHAU: dùng giá trị mẫu
    );
    SET @i = @i + 1;
END
GO

-- 5. Chèn dữ liệu cho bảng BANGDIEM (bảng điểm)
-- Giả sử mỗi sinh viên có điểm cho tất cả 6 học phần. Điểm thi được lưu dạng VARBINARY với giá trị giả định.
DECLARE @j INT;
DECLARE @masv VARCHAR(10);
DECLARE @i INT = 1;
WHILE @i <= 100
BEGIN
    SET @masv = 'SV' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3);
    SET @j = 1;
    WHILE @j <= 6
    BEGIN
        INSERT INTO BANGDIEM (MASV, MAHP, DIEMTHI)
        VALUES (
            @masv,
            'HP0' + CAST(@j AS VARCHAR(2)),    -- MAHP: HP01, HP02, ... HP06
            CONVERT(VARBINARY(MAX), CAST((6 + @j) AS VARCHAR(10)))  -- Điểm giả định: 7, 8, ... 12
        );
        SET @j = @j + 1;
    END
    SET @i = @i + 1;
END
GO
