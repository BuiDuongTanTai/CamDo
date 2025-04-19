/*==============================================================*/
/* DBMS name:      Microsoft SQL Server                         */
/* Created on:     17/04/2025                                   */
/*==============================================================*/

-- Tạo database và sử dụng
CREATE DATABASE CamDo;
GO
USE CamDo;
GO

/*==============================================================*/
/* TẠO BẢNG                                                     */
/*==============================================================*/
CREATE TABLE KHACHHANG (
   CCCD     CHAR(12)        NOT NULL,
   HOTEN    NVARCHAR(100),
   SDT      CHAR(10),
   DIACHI   NVARCHAR(100),
   CONSTRAINT PK_KHACHHANG PRIMARY KEY NONCLUSTERED (CCCD)
);
GO

CREATE TABLE TAIKHOAN (
   USERNAME      CHAR(50)       NOT NULL,
   PASSWORDHASH  VARCHAR(256),
   CONSTRAINT PK_TAIKHOAN PRIMARY KEY NONCLUSTERED (USERNAME)
);
GO

CREATE TABLE TAISAN (
   IDTS     INT               NOT NULL,
   CCCD     CHAR(12)          NOT NULL,
   TENTS    NVARCHAR(100),
   MOTA     NVARCHAR(1000),
   HINHANH  VARCHAR(255),
   CONSTRAINT PK_TAISAN PRIMARY KEY NONCLUSTERED (IDTS)
);
GO

CREATE INDEX SOHUU_FK ON TAISAN (CCCD ASC);
GO

CREATE TABLE HOPDONG (
   IDHD       INT            NOT NULL,
   IDTS       INT            NOT NULL,
   SOTIEN     BIGINT,
   LAISUAT    FLOAT,
   NGAYVAY    DATE,
   HANTRA     DATE,
   TRANGTHAI  NVARCHAR(20),
   CONSTRAINT PK_HOPDONG PRIMARY KEY NONCLUSTERED (IDHD)
);
GO

CREATE INDEX THECHAP_FK ON HOPDONG (IDTS ASC);
GO

CREATE TABLE THANHTOAN (
   IDTT        INT           NOT NULL,
   IDHD        INT           NOT NULL,
   SOTIENTRA   BIGINT,
   NGAYTRA     DATE,
   CONSTRAINT PK_THANHTOAN PRIMARY KEY NONCLUSTERED (IDTT)
);
GO

CREATE INDEX TRA_FK ON THANHTOAN (IDHD ASC);
GO

/*==============================================================*/
/* TẠO KHÓA NGOẠI                                               */
/*==============================================================*/
ALTER TABLE TAISAN
   ADD CONSTRAINT FK_TAISAN_SOHUU_KHACHHAN FOREIGN KEY (CCCD)
   REFERENCES KHACHHANG (CCCD);
GO

ALTER TABLE HOPDONG
   ADD CONSTRAINT FK_HOPDONG_THECHAP_TAISAN FOREIGN KEY (IDTS)
   REFERENCES TAISAN (IDTS);
GO

ALTER TABLE THANHTOAN
   ADD CONSTRAINT FK_THANHTOA_TRA_HOPDONG FOREIGN KEY (IDHD)
   REFERENCES HOPDONG (IDHD);
GO

/*==============================================================*/
/* CHÈN DỮ LIỆU MẪU                                             */
/*==============================================================*/
-- Tài khoản
INSERT INTO TAIKHOAN VALUES 
('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3');
GO

-- Khách hàng
INSERT INTO KHACHHANG (CCCD, HOTEN, SDT, DIACHI) VALUES
('056789012345', N'Nguyễn Văn A', '0123456789', N'Hà Nội'),
('067890123456', N'Trần Thị B', '0987654321', N'TP. Hồ Chí Minh'),
('078901234567', N'Lê Văn C', '0234567890', N'Đà Nẵng');
GO

-- Tài sản
INSERT INTO TAISAN (IDTS, CCCD, TENTS, MOTA, HINHANH) VALUES
(1, '056789012345', N'Tài sản A', N'Mô tả tài sản A', 'path/to/imageA.jpg'),
(2, '056789012345', N'Tài sản B', N'Mô tả tài sản B', 'path/to/imageB.jpg');
GO

-- Hợp đồng
INSERT INTO HOPDONG (IDHD, IDTS, SOTIEN, LAISUAT, NGAYVAY, HANTRA, TRANGTHAI) VALUES
(1, 1, 5500000, 0.5, '2024-10-01', '2025-01-01', N'Đã kết thúc'),        
(2, 2, 200000000, 4.5, '2024-02-01', '2025-07-01', N'Đang hoạt động'),   
(3, 1, 150000000, 4.0, '2024-03-01', '2025-10-01', N'Đang hoạt động'),   
(9, 2, 2000000, 0.4, '2024-02-01', '2025-02-01', N'Nợ'),                 
(10, 2, 1500000, 0.6, '2024-03-01', '2025-03-01', N'Nợ'),                
(11, 1, 2500000, 0.5, '2024-04-01', '2025-04-01', N'Nợ'),                
(12, 2, 3000000, 0.4, '2024-05-01', '2025-05-01', N'Đang hoạt động'),    
(13, 2, 3500000, 0.7, '2024-06-01', '2025-06-01', N'Đang hoạt động'),    
(14, 1, 4000000, 0.5, '2024-07-01', '2025-07-01', N'Đang hoạt động'),    
(15, 2, 4500000, 0.4, '2024-08-01', '2025-01-01', N'Thanh lý'),          
(16, 1, 5000000, 0.6, '2024-09-01', '2025-09-01', N'Thanh lý'),          
(18, 2, 6000000, 0.4, '2024-11-01', '2025-11-01', N'Đang hoạt động'),    
(19, 1, 6500000, 0.5, '2024-12-01', '2025-12-01', N'Đang hoạt động'),    
(20, 1, 7000000, 0.6, '2025-01-01', '2026-01-01', N'Đang hoạt động');    

GO

-- Cập nhật trạng thái
UPDATE HOPDONG
SET TrangThai = N'Đã kết thúc'
WHERE TrangThai = N'Hoàn tất';
GO

/*==============================================================*/
/* HÀM & THỦ TỤC                                                */
/*==============================================================*/

-- Hàm tạo ID tài sản tự tăng
CREATE FUNCTION fcgetIdAsset()
RETURNS INT
AS
BEGIN
    DECLARE @Id INT, @MaxId INT;
    SELECT @MaxId = MAX(IDTS) FROM TAISAN;
    SET @Id = ISNULL(@MaxId, 0) + 1;
    RETURN @Id;
END;
GO

-- Hàm tạo ID hợp đồng tự tăng
CREATE FUNCTION fcgetIdContract()
RETURNS INT
AS
BEGIN
    DECLARE @Id INT, @MaxId INT;
    SELECT @MaxId = MAX(IDHD) FROM HOPDONG;
    SET @Id = ISNULL(@MaxId, 0) + 1;
    RETURN @Id;
END;
GO

-- Thủ tục đăng nhập
CREATE PROCEDURE spCheckLogin
    @username VARCHAR(100),
    @password VARCHAR(250)
AS
BEGIN
    SELECT * FROM TAIKHOAN WHERE USERNAME = @username AND PASSWORDHASH = @password;
END;
GO

-- Thủ tục cập nhật tài khoản
CREATE PROCEDURE spUpdateUserLogin
    @username VARCHAR(100),
    @password VARCHAR(250)
AS
BEGIN
    UPDATE TAIKHOAN SET PASSWORDHASH = @password WHERE USERNAME = @username;
END;
GO

-- Thủ tục KHÁCH HÀNG
CREATE PROCEDURE spInsertCustomer (@cccd VARCHAR(12), @hoten NVARCHAR(100), @sdt VARCHAR(10), @diachi NVARCHAR(100))
AS BEGIN
    INSERT INTO KHACHHANG VALUES (@cccd, @hoten, @sdt, @diachi);
END;
GO

CREATE PROCEDURE spUpdateCustomer (@cccd VARCHAR, @hoten NVARCHAR(100), @sdt VARCHAR(10), @diachi NVARCHAR(100))
AS BEGIN
    UPDATE KHACHHANG SET HOTEN = @hoten, SDT = @sdt, DIACHI = @diachi WHERE CCCD = @cccd;
END;
GO

CREATE PROCEDURE spDeleteCustomer (@cccd VARCHAR)
AS BEGIN
    DELETE FROM KHACHHANG WHERE CCCD = @cccd;
END;
GO

-- Thủ tục TÀI SẢN
CREATE PROCEDURE spInsertAsset (@idts INT, @cccd CHAR(15), @tents NVARCHAR(100), @mota NVARCHAR(1000), @hinhanh VARCHAR(255))
AS BEGIN
    INSERT INTO TAISAN VALUES (@idts, @cccd, @tents, @mota, @hinhanh);
END;
GO

CREATE PROCEDURE spUpdateAsset (@idts INT, @cccd CHAR(15), @tents NVARCHAR(100), @mota NVARCHAR(1000), @hinhanh VARCHAR(255))
AS BEGIN
    UPDATE TAISAN SET CCCD = @cccd, TENTS = @tents, MOTA = @mota, HINHANH = @hinhanh WHERE IDTS = @idts;
END;
GO

CREATE PROCEDURE spDeleteAsset (@idts INT)
AS BEGIN
    DELETE FROM TAISAN WHERE IDTS = @idts;
END;
GO

-- Thủ tục HỢP ĐỒNG
CREATE PROCEDURE spInsertContract (@idhd INT, @idts INT, @tien BIGINT, @lai FLOAT, @ngayvay DATE, @hantra DATE, @trangthai NVARCHAR(20))
AS BEGIN
    INSERT INTO HOPDONG VALUES (@idhd, @idts, @tien, @lai, @ngayvay, @hantra, @trangthai);
END;
GO

CREATE PROCEDURE spUpdateContract (@idhd INT, @idts INT, @tien BIGINT, @lai FLOAT, @ngayvay DATE, @hantra DATE, @trangthai VARCHAR(20))
AS BEGIN
    UPDATE HOPDONG SET IDTS = @idts, SOTIEN = @tien, LAISUAT = @lai, NGAYVAY = @ngayvay, HANTRA = @hantra, TRANGTHAI = @trangthai WHERE IDHD = @idhd;
END;
GO

CREATE PROCEDURE spDeleteContract (@idhd INT)
AS BEGIN
    DELETE FROM HOPDONG WHERE IDHD = @idhd;
END;
GO
