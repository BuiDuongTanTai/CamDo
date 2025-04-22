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
   HINHANH  NVARCHAR(255),
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

-- Dữ liệu KHACHHANG
INSERT INTO KHACHHANG (CCCD, HOTEN, SDT, DIACHI)
VALUES 
('001122334455', N'Nguyễn Văn A', '0912345678', N'Hà Nội'),
('002233445566', N'Trần Thị B', '0923456789', N'Hồ Chí Minh'),
('003344556677', N'Lê Văn C', '0934567890', N'Đà Nẵng');

-- Dữ liệu TAISAN và HOPDONG (gắn liền)
INSERT INTO TAISAN (IDTS, CCCD, TENTS, MOTA, HINHANH) VALUES 
(1, '001122334455', N'Xe máy Honda', N'Xe máy Honda đời 2020', N'honda2020.jpg'),
(2, '001122334455', N'Laptop Dell', N'Laptop Dell i7', N'dell.jpg'),
(3, '002233445566', N'Điện thoại iPhone', N'iPhone 12 Pro', N'iphone12.jpg'),
(4, '002233445566', N'Nhẫn vàng', N'Nhẫn vàng 18K', N'vang.jpg'),
(5, '003344556677', N'Tivi Sony', N'Tivi Sony 55 inch', N'sony.jpg'),
(6, '003344556677', N'Tủ lạnh Samsung', N'Tủ lạnh Inverter', N'samsung.jpg'),
(7, '001122334455', N'Máy ảnh Canon', N'Máy ảnh Canon EOS', N'canon.jpg'),
(8, '002233445566', N'Xe đạp thể thao', N'Xe đạp Giant', N'giant.jpg'),
(9, '003344556677', N'Máy tính bảng', N'iPad Gen 9', N'ipad.jpg'),
(10,'001122334455', N'Loa Bluetooth', N'Loa JBL Flip', N'jbl.jpg');

INSERT INTO HOPDONG (IDHD, IDTS, SOTIEN, LAISUAT, NGAYVAY, HANTRA, TRANGTHAI) VALUES 
(1, 1, 15000000, 2.5, '2025-01-05', '2025-04-05', N'Còn hiệu lực'),
(2, 2, 10000000, 2.0, '2025-01-10', '2025-04-10', N'Còn hiệu lực'),
(3, 3, 20000000, 3.0, '2025-01-15', '2025-04-15', N'Còn hiệu lực'),
(4, 4, 5000000, 2.2, '2025-01-20', '2025-04-20', N'Đã tất toán'),
(5, 5, 18000000, 2.8, '2025-01-25', '2025-04-25', N'Còn hiệu lực'),
(6, 6, 12000000, 2.3, '2025-01-30', '2025-04-30', N'Còn hiệu lực'),
(7, 7, 7000000, 2.0, '2025-02-04', '2025-05-04', N'Còn hiệu lực'),
(8, 8, 9000000, 2.7, '2025-02-09', '2025-05-09', N'Quá hạn'),
(9, 9, 11000000, 2.5, '2025-02-14', '2025-05-14', N'Còn hiệu lực'),
(10,10, 8000000, 2.1, '2025-02-19', '2025-05-19', N'Còn hiệu lực');

-- Dữ liệu THANHTOAN (một số hợp đồng có thanh toán)
INSERT INTO THANHTOAN (IDTT, IDHD, SOTIENTRA, NGAYTRA) VALUES 
(1, 1, 5000000, '2025-02-05'),
(2, 3, 10000000, '2025-02-16'),
(3, 4, 5000000, '2025-02-25'),
(4, 6, 3000000, '2025-03-01'),
(5, 8, 2000000, '2025-03-05');
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

-- Hàm tạo ID thanh toán tự tăng
CREATE FUNCTION fcgetIdPayment()
RETURNS INT
AS
BEGIN
    DECLARE @Id INT, @MaxId INT;
    SELECT @MaxId = MAX(IDTT) FROM THANHTOAN;
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

CREATE PROCEDURE spUpdateCustomer (@cccd VARCHAR(12), @hoten NVARCHAR(100), @sdt VARCHAR(10), @diachi NVARCHAR(100))
AS BEGIN
    UPDATE KHACHHANG SET HOTEN = @hoten, SDT = @sdt, DIACHI = @diachi WHERE CCCD = @cccd;
END;
GO

CREATE PROCEDURE spDeleteCustomer (@cccd VARCHAR(12))
AS BEGIN
    DELETE FROM KHACHHANG WHERE CCCD = @cccd;
END;
GO

-- Thủ tục TÀI SẢN
CREATE PROCEDURE spInsertAsset (@idts INT, @cccd CHAR(12), @tents NVARCHAR(100), @mota NVARCHAR(1000), @hinhanh VARCHAR(255))
AS BEGIN
    INSERT INTO TAISAN VALUES (@idts, @cccd, @tents, @mota, @hinhanh);
END;
GO

CREATE PROCEDURE spUpdateAsset (@idts INT, @cccd CHAR(12), @tents NVARCHAR(100), @mota NVARCHAR(1000), @hinhanh VARCHAR(255))
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

CREATE PROCEDURE spUpdateContractStatusAuto
AS
BEGIN
    SET NOCOUNT ON;

    -- Trả về các hợp đồng vừa được cập nhật
    UPDATE HOPDONG
    SET TRANGTHAI = N'Quá hạn'
    OUTPUT INSERTED.IDHD, INSERTED.HANTRA
    WHERE HANTRA < GETDATE() AND TRANGTHAI = N'Đang hoạt động';
END;
GO

CREATE PROCEDURE spUpdateContractStatusDone (@idhd INt)
AS BEGIN
    UPDATE HOPDONG SET TRANGTHAI = N'Đã kết thúc' WHERE IDHD = @idhd;
END;
GO

CREATE PROCEDURE spUpdateContractStatusLiquidation (@idhd INT)
AS BEGIN
    UPDATE HOPDONG SET TRANGTHAI = N'Thanh lý' WHERE IDHD = @idhd;
END;
GO

-- Thủ tục THANH TOÁN
CREATE PROCEDURE spInsertPayment (@idtt INT, @idhd INT, @sotientra BIGINT, @ngaytra DATE)
AS BEGIN
    INSERT INTO THANHTOAN VALUES (@idtt, @idhd, @sotientra, @ngaytra);
END;
GO