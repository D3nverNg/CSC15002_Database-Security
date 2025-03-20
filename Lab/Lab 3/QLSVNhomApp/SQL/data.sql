--data.sql
USE QLSVNhom;
GO

-- 1. Chèn dữ liệu cho bảng NHANVIEN (nhân viên)
-- Các giá trị mật khẩu, lương và PUBKEY được lưu dưới dạng VARBINARY (giả định đã mã hóa hoặc sử dụng CONVERT)
EXEC SP_INS_PUBLIC_NHANVIEN 'NV01', N'NGUYỄN VĂN A', 'nva@company.com', 1500000, N'nva', N'123456';
EXEC SP_INS_PUBLIC_NHANVIEN 'NV02', N'NGUYỄN VĂN B', 'nvb@yahoo.com', 300000, N'nvb', N'111111';
EXEC SP_INS_PUBLIC_NHANVIEN 'NV03', N'NGUYỄN THỊ C', 'ntc@gmail.com', 350000, N'ntc', N'123';
EXEC SP_INS_PUBLIC_NHANVIEN 'NV04', N'PHẠM QUANG DUY', 'pqduy@clc.vn', 5000000, N'pqduy', N'34567';
EXEC SP_INS_PUBLIC_NHANVIEN 'NV05', N'NGUYỄN HỒ ĐĂNG DUY', 'nhdduy@yahoo.com', 99999999, N'nhdduy', N'999';

-- 2. Chèn dữ liệu cho bảng LOP (lớp học)
-- Mỗi lớp được giao cho một nhân viên làm chủ nhiệm
INSERT INTO LOP (MALOP, TENLOP, MANV)
VALUES
('L01', N'Lớp 1', 'NV01'),
('L02', N'Lớp 2', 'NV02'),
('L03', N'Lớp 3', 'NV03'),
('L04', N'Lớp 4', 'NV04'),
('L05', N'Lớp 5', 'NV05');
GO

-- 3. Chèn dữ liệu cho bảng HOCPHAN (học phần)
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC)
VALUES
('HP01', N' DSA', 4),
('HP02', N' Mạng máy tính ', 4),
('HP03', N' OOP', 4),
('HP04', N' Triết học Mác - Lênin ', 3),
('HP05', N' Kỹ năng mềm ', 3);
GO

-- 4. Chèn dữ liệu cho bảng SINHVIEN (100 sinh viên)

-- Chèn dữ liệu vào bảng SINHVIEN
INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
VALUES
('SV001', N'Ngô Đăng Sơn', '2004-06-03', N'Hóc Môn', 'L03', 'nđsl', HASHBYTES('SHA1', '543903')),
('SV002', N'Nguyễn Hữu Bình', '2004-12-12', N'Quận 6', 'L02', 'nhbv', HASHBYTES('SHA1', '829271')),
('SV003', N'Đặng Thị Trang', '2003-09-09', N'Quận 8', 'L04', 'đtth', HASHBYTES('SHA1', '377572')),
('SV004', N'Ngô Thị Vỹ', '2003-10-23', N'Củ Chi', 'L04', 'ntvt', HASHBYTES('SHA1', '765260')),
('SV005', N'Trần Nhật Bình', '2003-08-02', N'Quận 5', 'L05', 'tnbr', HASHBYTES('SHA1', '166786')),
('SV006', N'Bùi Quang Sơn', '2004-03-04', N'Tân Bình', 'L03', 'bqsx', HASHBYTES('SHA1', '757646')),
('SV007', N'Phạm Thị Nam', '2002-02-27', N'Quận 10', 'L02', 'ptnl', HASHBYTES('SHA1', '025861')),
('SV008', N'Đỗ Hoài Chi', '2003-01-21', N'Tân Phú', 'L02', 'đhcr', HASHBYTES('SHA1', '257508')),
('SV009', N'Lê Thanh Hà', '2003-10-22', N'Quận 5', 'L05', 'lthb', HASHBYTES('SHA1', '569683')),
('SV010', N'Bùi Bảo Chi', '2003-01-07', N'Quận 10', 'L01', 'bbcv', HASHBYTES('SHA1', '661385')),
('SV011', N'Trần Hoài Sơn', '2003-06-03', N'Nhà Bè', 'L04', 'thsb', HASHBYTES('SHA1', '546382')),
('SV012', N'Nguyễn Nhật Sơn', '2002-10-14', N'Bình Tân', 'L04', 'nnsc', HASHBYTES('SHA1', '138945')),
('SV013', N'Phạm Đăng Vỹ', '2002-09-19', N'Tân Bình', 'L03', 'pđvk', HASHBYTES('SHA1', '127001')),
('SV014', N'Đặng Minh Sơn', '2003-08-18', N'Bình Chánh', 'L05', 'đmsd', HASHBYTES('SHA1', '026280')),
('SV015', N'Nguyễn Quang Sơn', '2003-09-18', N'Phú Nhuận', 'L04', 'nqsy', HASHBYTES('SHA1', '979168')),
('SV016', N'Bùi Hữu Phương', '2002-09-14', N'Quận 10', 'L02', 'bhpx', HASHBYTES('SHA1', '990057')),
('SV017', N'Lê Văn Quân', '2004-09-03', N'Bình Tân', 'L01', 'lvqj', HASHBYTES('SHA1', '882328')),
('SV018', N'Lê Bảo Bình', '2004-11-08', N'Quận 12', 'L03', 'lbbd', HASHBYTES('SHA1', '476314')),
('SV019', N'Ngô Văn Quân', '2003-04-12', N'Quận 11', 'L01', 'nvqr', HASHBYTES('SHA1', '005257')),
('SV020', N'Phạm Nhật Quân', '2002-02-08', N'Quận 1', 'L05', 'pnqd', HASHBYTES('SHA1', '999105')),
('SV021', N'Đỗ Hoài Khoa', '2004-04-19', N'Quận 7', 'L03', 'đhkv', HASHBYTES('SHA1', '136252')),
('SV022', N'Ngô Bảo Sơn', '2004-01-23', N'Quận 12', 'L02', 'nbsz', HASHBYTES('SHA1', '740202')),
('SV023', N'Bùi Bảo Khoa', '2004-02-09', N'Tân Bình', 'L03', 'bbkd', HASHBYTES('SHA1', '937489')),
('SV024', N'Trần Đăng An', '2004-02-12', N'Quận 8', 'L05', 'tđad', HASHBYTES('SHA1', '432463')),
('SV025', N'Đỗ Văn Linh', '2003-09-20', N'Quận 10', 'L02', 'đvly', HASHBYTES('SHA1', '975816')),
('SV026', N'Phạm Quang Khoa', '2003-10-08', N'Quận 11', 'L01', 'pqko', HASHBYTES('SHA1', '603081')),
('SV027', N'Hoàng Hoài Nam', '2002-12-28', N'Quận 10', 'L01', 'hhnf', HASHBYTES('SHA1', '332253')),
('SV028', N'Bùi Nhật Bình', '2002-09-17', N'Quận 4', 'L04', 'bnbk', HASHBYTES('SHA1', '253507')),
('SV029', N'Phạm Hữu Uyên', '2004-03-24', N'Quận 12', 'L05', 'phuu', HASHBYTES('SHA1', '209941')),
('SV030', N'Trần Bảo Sơn', '2004-04-15', N'Quận 8', 'L04', 'tbsx', HASHBYTES('SHA1', '336664')),
('SV031', N'Hoàng Đăng Giang', '2002-12-12', N'Tân Bình', 'L04', 'hđgl', HASHBYTES('SHA1', '206618')),
('SV032', N'Phạm Minh Nam', '2002-11-16', N'Tân Bình', 'L01', 'pmnn', HASHBYTES('SHA1', '371354')),
('SV033', N'Bùi Văn Sơn', '2002-03-11', N'Quận 9', 'L03', 'bvsj', HASHBYTES('SHA1', '007233')),
('SV034', N'Trần Bảo Uyên', '2004-10-05', N'Nhà Bè', 'L01', 'tbua', HASHBYTES('SHA1', '539336')),
('SV035', N'Hoàng Hữu Uyên', '2002-10-21', N'Quận 11', 'L02', 'hhug', HASHBYTES('SHA1', '709764')),
('SV036', N'Hồ Nhật Bình', '2003-12-10', N'Quận 8', 'L02', 'hnby', HASHBYTES('SHA1', '325483')),
('SV037', N'Hồ Thị Phương', '2002-03-03', N'Quận 3', 'L03', 'htpb', HASHBYTES('SHA1', '076912')),
('SV038', N'Lê Thị Nam', '2003-11-21', N'Nhà Bè', 'L02', 'ltnb', HASHBYTES('SHA1', '595682')),
('SV039', N'Lê Hoài Nam', '2003-05-18', N'Tân Bình', 'L01', 'lhne', HASHBYTES('SHA1', '980282')),
('SV040', N'Trần Hoài Trang', '2002-08-17', N'Thủ Đức', 'L02', 'thty', HASHBYTES('SHA1', '430420')),
('SV041', N'Đặng Thị Hà', '2003-07-08', N'Tân Bình', 'L04', 'đthd', HASHBYTES('SHA1', '774148')),
('SV042', N'Ngô Bảo Uyên', '2003-02-16', N'Quận 7', 'L05', 'nbuh', HASHBYTES('SHA1', '702151')),
('SV043', N'Lê Đăng Mai', '2003-01-27', N'Quận 9', 'L04', 'lđms', HASHBYTES('SHA1', '453564')),
('SV044', N'Đặng Thị Uyên', '2003-01-22', N'Quận 6', 'L02', 'đtul', HASHBYTES('SHA1', '887244')),
('SV045', N'Trần Thị Hà', '2002-06-26', N'Bình Chánh', 'L01', 'tthl', HASHBYTES('SHA1', '079883')),
('SV046', N'Đặng Thanh Hà', '2003-01-28', N'Thủ Đức', 'L02', 'đthx', HASHBYTES('SHA1', '058117')),
('SV047', N'Đặng Nhật Mai', '2004-11-19', N'Nhà Bè', 'L01', 'đnmz', HASHBYTES('SHA1', '334917')),
('SV048', N'Hoàng Đăng Giang', '2004-09-22', N'Quận 2', 'L05', 'hđgx', HASHBYTES('SHA1', '427370')),
('SV049', N'Đặng Hữu Bình', '2003-05-22', N'Quận 2', 'L02', 'đhbk', HASHBYTES('SHA1', '574508')),
('SV050', N'Phạm Bảo Chi', '2002-10-04', N'Quận 11', 'L02', 'pbcy', HASHBYTES('SHA1', '749992')),
('SV051', N'Phạm Nhật Hà', '2004-09-13', N'Quận 3', 'L01', 'pnhr', HASHBYTES('SHA1', '124476')),
('SV052', N'Hoàng Thị Trang', '2002-09-26', N'Bình Tân', 'L01', 'httv', HASHBYTES('SHA1', '401803')),
('SV053', N'Đặng Bảo Khoa', '2004-02-19', N'Quận 2', 'L04', 'đbka', HASHBYTES('SHA1', '398527')),
('SV054', N'Đỗ Thanh Linh', '2003-11-18', N'Quận 11', 'L04', 'đtli', HASHBYTES('SHA1', '265349')),
('SV055', N'Nguyễn Hoài Linh', '2002-04-22', N'Bình Chánh', 'L02', 'nhlt', HASHBYTES('SHA1', '798445')),
('SV056', N'Đặng Minh Khoa', '2004-01-19', N'Quận 5', 'L01', 'đmkx', HASHBYTES('SHA1', '876733')),
('SV057', N'Hồ Văn Phương', '2004-01-04', N'Bình Chánh', 'L03', 'hvph', HASHBYTES('SHA1', '590961')),
('SV058', N'Bùi Nhật An', '2003-05-12', N'Quận 11', 'L05', 'bnab', HASHBYTES('SHA1', '041449')),
('SV059', N'Hoàng Hoài Uyên', '2003-12-16', N'Quận 2', 'L05', 'hhuk', HASHBYTES('SHA1', '461768')),
('SV060', N'Bùi Bảo Nam', '2003-04-02', N'Quận 11', 'L05', 'bbnh', HASHBYTES('SHA1', '397992')),
('SV061', N'Ngô Đăng Khoa', '2003-02-11', N'Gò Vấp', 'L01', 'nđkr', HASHBYTES('SHA1', '428169')),
('SV062', N'Đặng Quang Nam', '2003-10-10', N'Hóc Môn', 'L04', 'đqnm', HASHBYTES('SHA1', '970379')),
('SV063', N'Hoàng Nhật Trang', '2002-09-26', N'Quận 3', 'L03', 'hnth', HASHBYTES('SHA1', '022267')),
('SV064', N'Đặng Thanh Duy', '2004-12-22', N'Quận 7', 'L04', 'đtda', HASHBYTES('SHA1', '620692')),
('SV065', N'Bùi Thanh Uyên', '2004-01-14', N'Tân Bình', 'L04', 'btub', HASHBYTES('SHA1', '855861')),
('SV066', N'Ngô Văn Duy', '2003-02-16', N'Gò Vấp', 'L05', 'nvdi', HASHBYTES('SHA1', '368994')),
('SV067', N'Lê Nhật Quân', '2004-11-26', N'Thủ Đức', 'L04', 'lnqu', HASHBYTES('SHA1', '946690')),
('SV068', N'Phạm Quang Khoa', '2003-04-14', N'Quận 10', 'L03', 'pqkq', HASHBYTES('SHA1', '553625')),
('SV069', N'Lê Thanh Uyên', '2002-05-21', N'Quận 9', 'L05', 'ltun', HASHBYTES('SHA1', '667316')),
('SV070', N'Đặng Bảo An', '2004-02-08', N'Quận 4', 'L01', 'đbap', HASHBYTES('SHA1', '288237')),
('SV071', N'Hoàng Đăng Mai', '2003-07-04', N'Quận 6', 'L03', 'hđmv', HASHBYTES('SHA1', '996051')),
('SV072', N'Hoàng Đăng Sơn', '2002-12-11', N'Tân Phú', 'L02', 'hđsi', HASHBYTES('SHA1', '791806')),
('SV073', N'Bùi Hữu Sơn', '2004-03-03', N'Phú Nhuận', 'L02', 'bhst', HASHBYTES('SHA1', '414256')),
('SV074', N'Nguyễn Nhật Duy', '2003-10-28', N'Quận 2', 'L02', 'nndg', HASHBYTES('SHA1', '727157')),
('SV075', N'Đỗ Minh Phương', '2003-05-06', N'Gò Vấp', 'L03', 'đmpd', HASHBYTES('SHA1', '864109')),
('SV076', N'Đặng Hữu Sơn', '2003-03-18', N'Nhà Bè', 'L05', 'đhsi', HASHBYTES('SHA1', '141327')),
('SV077', N'Trần Bảo Uyên', '2004-12-14', N'Thủ Đức', 'L03', 'tbum', HASHBYTES('SHA1', '994817')),
('SV078', N'Đỗ Minh An', '2003-11-08', N'Củ Chi', 'L05', 'đmar', HASHBYTES('SHA1', '540453')),
('SV079', N'Trần Bảo Phương', '2003-08-08', N'Thủ Đức', 'L05', 'tbpx', HASHBYTES('SHA1', '772077')),
('SV080', N'Lê Minh Phương', '2004-03-13', N'Quận 11', 'L05', 'lmph', HASHBYTES('SHA1', '622423')),
('SV081', N'Trần Đăng Mai', '2004-07-25', N'Bình Thạnh', 'L05', 'tđmk', HASHBYTES('SHA1', '584317')),
('SV082', N'Trần Nhật An', '2002-05-27', N'Quận 12', 'L05', 'tnas', HASHBYTES('SHA1', '957689')),
('SV083', N'Ngô Bảo Hà', '2003-05-25', N'Quận 3', 'L03', 'nbha', HASHBYTES('SHA1', '138640')),
('SV084', N'Trần Văn Chi', '2004-03-18', N'Quận 9', 'L05', 'tvcz', HASHBYTES('SHA1', '570760')),
('SV085', N'Hồ Nhật Trang', '2003-04-01', N'Quận 8', 'L02', 'hntk', HASHBYTES('SHA1', '105756')),
('SV086', N'Đỗ Đăng Sơn', '2004-01-12', N'Bình Thạnh', 'L02', 'đđse', HASHBYTES('SHA1', '723335')),
('SV087', N'Hồ Hữu An', '2003-05-20', N'Gò Vấp', 'L01', 'hhaa', HASHBYTES('SHA1', '271795')),
('SV088', N'Nguyễn Văn Mai', '2004-11-26', N'Bình Thạnh', 'L02', 'nvmg', HASHBYTES('SHA1', '433241')),
('SV089', N'Hoàng Đăng Chi', '2003-11-09', N'Phú Nhuận', 'L05', 'hđcl', HASHBYTES('SHA1', '210291')),
('SV090', N'Đỗ Hoài An', '2002-12-16', N'Quận 2', 'L01', 'đhaq', HASHBYTES('SHA1', '226789')),
('SV091', N'Nguyễn Văn An', '2002-05-10', N'Củ Chi', 'L01', 'nvaw', HASHBYTES('SHA1', '645604')),
('SV092', N'Lê Hoài Hà', '2003-03-25', N'Quận 1', 'L04', 'lhhr', HASHBYTES('SHA1', '205023')),
('SV093', N'Hồ Bảo Vỹ', '2003-04-01', N'Bình Chánh', 'L04', 'hbvb', HASHBYTES('SHA1', '346765')),
('SV094', N'Đặng Quang Trang', '2004-10-10', N'Thủ Đức', 'L05', 'đqtz', HASHBYTES('SHA1', '867042')),
('SV095', N'Đặng Thanh Sơn', '2003-12-15', N'Quận 10', 'L01', 'đtsf', HASHBYTES('SHA1', '464655')),
('SV096', N'Hồ Hữu Mai', '2002-11-18', N'Tân Phú', 'L04', 'hhmy', HASHBYTES('SHA1', '142187')),
('SV097', N'Nguyễn Đăng Trang', '2004-06-19', N'Bình Thạnh', 'L02', 'nđtg', HASHBYTES('SHA1', '550221')),
('SV098', N'Lê Minh Bình', '2002-04-27', N'Hóc Môn', 'L01', 'lmbq', HASHBYTES('SHA1', '879350')),
('SV099', N'Hồ Hoài Khoa', '2002-05-19', N'Tân Phú', 'L05', 'hhkl', HASHBYTES('SHA1', '218955')),
('SV100', N'Ngô Hữu Linh', '2003-11-25', N'Quận 6', 'L02', 'nhlx', HASHBYTES('SHA1', '253322'));
 GO

-- 5. Chèn dữ liệu cho bảng BANGDIEM (bảng điểm)
EXEC SP_INS_DIEM 'SV001','HP01','9','NV01','';
EXEC SP_INS_DIEM 'SV001','HP02','8','NV01','';
EXEC SP_INS_DIEM 'SV001','HP05','10','NV01','';
EXEC SP_INS_DIEM 'SV002','HP01','9','NV04','';
EXEC SP_INS_DIEM 'SV003','HP04','5','NV04','';
EXEC SP_INS_DIEM 'SV003','HP03','7','NV04','';
EXEC SP_INS_DIEM 'SV004','HP02','10','NV04','';
EXEC SP_INS_DIEM 'SV005','HP01','5','NV01','';
EXEC SP_INS_DIEM 'SV005','HP03','7','NV01','';
EXEC SP_INS_DIEM 'SV006','HP05','7','NV02','';
EXEC SP_INS_DIEM 'SV007','HP05','8','NV02','';
EXEC SP_INS_DIEM 'SV010','HP05','8','NV01','';
EXEC SP_INS_DIEM 'SV100','HP04','10','NV03','';