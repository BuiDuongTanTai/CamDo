/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     17/04/2025 2:50:40 CH                        */
/*==============================================================*/

create database CamDo
go
use CamDo

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('HOPDONG') and o.name = 'FK_HOPDONG_THECHAP_TAISAN')
alter table HOPDONG
   drop constraint FK_HOPDONG_THECHAP_TAISAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TAISAN') and o.name = 'FK_TAISAN_SOHUU_KHACHHAN')
alter table TAISAN
   drop constraint FK_TAISAN_SOHUU_KHACHHAN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('THANHTOAN') and o.name = 'FK_THANHTOA_TRA_HOPDONG')
alter table THANHTOAN
   drop constraint FK_THANHTOA_TRA_HOPDONG
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('HOPDONG')
            and   name  = 'THECHAP_FK'
            and   indid > 0
            and   indid < 255)
   drop index HOPDONG.THECHAP_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HOPDONG')
            and   type = 'U')
   drop table HOPDONG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('KHACHHANG')
            and   type = 'U')
   drop table KHACHHANG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAIKHOAN')
            and   type = 'U')
   drop table TAIKHOAN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TAISAN')
            and   name  = 'SOHUU_FK'
            and   indid > 0
            and   indid < 255)
   drop index TAISAN.SOHUU_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TAISAN')
            and   type = 'U')
   drop table TAISAN
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('THANHTOAN')
            and   name  = 'TRA_FK'
            and   indid > 0
            and   indid < 255)
   drop index THANHTOAN.TRA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('THANHTOAN')
            and   type = 'U')
   drop table THANHTOAN
go

/*==============================================================*/
/* Table: HOPDONG                                               */
/*==============================================================*/
create table HOPDONG (
   IDHD                 int                  not null,
   IDTS                 int                  not null,
   SOTIEN               bigint               null,
   LAISUAT              float                null,
   NGAYVAY              datetime             null,
   HANTRA               datetime             null,
   TRANGTHAI            nvarchar(20)          null,
   constraint PK_HOPDONG primary key nonclustered (IDHD)
)
go

/*==============================================================*/
/* Index: THECHAP_FK                                            */
/*==============================================================*/
create index THECHAP_FK on HOPDONG (
IDTS ASC
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   CCCD                 char(15)             not null,
   HOTEN                nvarchar(100)         null,
   SDT                  char(10)             null,
   DIACHI               nvarchar(100)         null,
   constraint PK_KHACHHANG primary key nonclustered (CCCD)
)
go

/*==============================================================*/
/* Table: TAIKHOAN                                              */
/*==============================================================*/
create table TAIKHOAN (
   USERNAME             char(50)             not null,
   PASSWORDHASH         varchar(256)         null,
   constraint PK_TAIKHOAN primary key nonclustered (USERNAME)
)
go

/*==============================================================*/
/* Table: TAISAN                                                */
/*==============================================================*/
create table TAISAN (
   IDTS                 int                  not null,
   CCCD                 char(15)             not null,
   TENTS                nvarchar(100)         null,
   MOTA                 text                 null,
   HINHANH              varchar(255)         null,
   constraint PK_TAISAN primary key nonclustered (IDTS)
)
go

/*==============================================================*/
/* Index: SOHUU_FK                                              */
/*==============================================================*/
create index SOHUU_FK on TAISAN (
CCCD ASC
)
go

/*==============================================================*/
/* Table: THANHTOAN                                             */
/*==============================================================*/
create table THANHTOAN (
   IDTT                 int                  not null,
   IDHD                 int                  not null,
   SOTIENTRA            bigint               null,
   NGAYTRA              datetime             null,
   constraint PK_THANHTOAN primary key nonclustered (IDTT)
)
go

/*==============================================================*/
/* Index: TRA_FK                                                */
/*==============================================================*/
create index TRA_FK on THANHTOAN (
IDHD ASC
)
go

alter table HOPDONG
   add constraint FK_HOPDONG_THECHAP_TAISAN foreign key (IDTS)
      references TAISAN (IDTS)
go

alter table TAISAN
   add constraint FK_TAISAN_SOHUU_KHACHHAN foreign key (CCCD)
      references KHACHHANG (CCCD)
go

alter table THANHTOAN
   add constraint FK_THANHTOA_TRA_HOPDONG foreign key (IDHD)
      references HOPDONG (IDHD)
go


/*==============================================================================================================================================*/


/*TAIKHOAN------------------------------------------------------------------------------------------------------------------*/
insert into TAIKHOAN values ('admin', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3');

--drop procedure spCheckLogin
create procedure spCheckLogin
(
		@username		varchar(100),
		@password		varchar(250)
)
	as
	Begin
				select	* from TAIKHOAN
				where	USERNAME= @username
				and		PASSWORDHASH=@password				
	End
Go
--drop procedure spUpdateUserLogin
create procedure spUpdateUserLogin
(
		@username		varchar(100),
		@password		varchar(250)				
)
as
Begin
		update TAIKHOAN set 
		USERNAME=@username,
		PASSWORDHASH=@password
		where USERNAME = @username
End

/*KHACHHANG------------------------------------------------------------------------------------------------------------------*/
INSERT INTO KHACHHANG (CCCD, HOTEN, SDT, DIACHI) VALUES
('056789012345', N'Nguyễn Văn A', '0123456789', N'Hà Nội'),
('067890123456', N'Trần Thị B', '0987654321', N'TP. Hồ Chí Minh'),
('078901234567', N'Lê Văn C', '0234567890', N'Đà Nẵng');
select * from KHACHHANG

-- drop procedure spInsertCustomer
create procedure spInsertCustomer
(
		@cccd			varchar(12),
		@hoten			nvarchar(100),
		@sdt			varchar(10),
		@diachi			nvarchar(100)
)
AS
BEGIN
    -- Chèn dữ liệu vào bảng Contracts
    INSERT INTO KHACHHANG(CCCD, HOTEN, SDT, DIACHI)
    VALUES (@cccd, @hoten, @sdt, @diachi);
END
GO

--drop procedure spUpdateCustomer
CREATE PROCEDURE spUpdateCustomer
(
    @cccd          varchar,
    @hoten         nvarchar(100),
    @sdt           varchar(10),
    @diachi        nvarchar(100)
)
AS
BEGIN
    UPDATE KHACHHANG
    SET HOTEN = @hoten,
        SDT = @sdt,
        DIACHI = @diachi
    WHERE CCCD = @cccd;
END
GO

--drop procedure spDeleteCustomer
CREATE PROCEDURE spDeleteCustomer
(
    @cccd          varchar
)
AS
BEGIN
    DELETE FROM KHACHHANG
    WHERE CCCD = @cccd;
END
GO





/*TAISAN------------------------------------------------------------------------------------------------------------------*/
INSERT INTO TAISAN (IDTS, CCCD, TENTS, MOTA, HINHANH) VALUES
(1, '123456789012345', N'Tài sản A', N'Mô tả tài sản A', 'path/to/imageA.jpg'),
(2, '345678901234567', N'Tài sản B', N'Mô tả tài sản B', 'path/to/imageB.jpg');

go
-- drop function fcgetIdAsset
Create function fcgetIdAsset()
	returns int
	As
	Begin
		Declare @Id int
		Declare @MaxId int
		
		Select @MaxId = MAX(IDTS) from TAISAN
						
		if exists (select IDTS from TAISAN)
			set @Id = @MaxId+1
		else
			set @Id = 1
		return @Id
End

go
--drop procedure spInsertAsset
CREATE PROCEDURE spInsertAsset
(
    @idts          int,
    @cccd          char(15),
    @tents         nvarchar(100),
    @mota          text,
    @hinhanh       varchar(255)
)
AS
BEGIN
    -- Chèn dữ liệu vào bảng TAISAN
    INSERT INTO TAISAN(IDTS, CCCD, TENTS, MOTA, HINHANH)
    VALUES (@idts, @cccd, @tents, @mota, @hinhanh);
END
GO

--drop procedure spUpdateAsset
CREATE PROCEDURE spUpdateAsset
(
    @idts          int,
    @cccd          char(15),
    @tents         nvarchar(100),
    @mota          text,
    @hinhanh       varchar(255)
)
AS
BEGIN
    -- Cập nhật dữ liệu vào bảng TAISAN
    UPDATE TAISAN
    SET CCCD = @cccd,
        TENTS = @tents,
        MOTA = @mota,
        HINHANH = @hinhanh
    WHERE IDTS = @idts;
END
GO


--drop procedure spDeleteAsset
CREATE PROCEDURE spDeleteAsset
(
    @idts          int
)
AS
BEGIN
    -- Xóa dữ liệu khỏi bảng TAISAN
    DELETE FROM TAISAN
    WHERE IDTS = @idts;
END
GO


/*HOPDONG------------------------------------------------------------------------------------------------------------------*/
INSERT INTO HOPDONG VALUES(2, 2, 200000000, 4.5, '2023-02-01', '2025-02-01', N'Đang hoạt động')
INSERT INTO HOPDONG VALUES(3, 1, 150000000, 4.0, '2023-03-01', '2025-03-01', N'Hoàn tất')
SELECT * FROM HOPDONG;

go
-- drop function fcgetIdContract
Create function fcgetIdContract()
	returns int
	As
	Begin
		Declare @Id int
		Declare @MaxId int
		
		Select @MaxId = MAX(IDHD) from HOPDONG
						
		if exists (select IDHD from HOPDONG)
			set @Id = @MaxId+1
		else
			set @Id = 1
		return @Id
End
go

-- drop procedure spInsertContract
create procedure spInsertContract
( 
		@idhd			int,
		@idts			int,
		@tien			bigint,
		@lai			float,
		@ngayvay		datetime,
		@hantra			datetime,
		@trangthai		varchar(20)
)
AS
BEGIN
    -- Chèn dữ liệu vào bảng Contracts
    INSERT INTO HOPDONG (IDHD, IDTS, SOTIEN, LAISUAT, NGAYVAY, HANTRA, TRANGTHAI)
    VALUES (@idhd, @idts, @tien, @lai, @ngayvay, @hantra, @trangthai);
END
GO
-- drop procedure spUpdateContract
CREATE PROCEDURE spUpdateContract
( 
    @idhd        INT,
    @idts        INT,
    @tien        BIGINT,
    @lai         FLOAT,
    @ngayvay     DATETIME,
    @hantra      DATETIME,
    @trangthai   VARCHAR(20)
)
AS
BEGIN
    -- Cập nhật thông tin hợp đồng trong bảng HOPDONG
    UPDATE HOPDONG
    SET 
        IDTS = @idts,
        SOTIEN = @tien,
        LAISUAT = @lai,
        NGAYVAY = @ngayvay,
        HANTRA = @hantra,
        TRANGTHAI = @trangthai
    WHERE 
        IDHD = @idhd; -- Điều kiện cập nhật
END
GO
--drop procedure spDeleteContract
CREATE PROCEDURE spDeleteContract
(
    @idhd INT 
)
AS
BEGIN
    DELETE FROM HOPDONG
    WHERE IDHD = @idhd;
END
GO

--drop procedure spFindViewContract
--CREATE PROCEDURE spFindViewContract
--AS
--BEGIN
--    SELECT 
--        IDHD,
--        IDTS,
--        SOTIEN,
--        LAISUAT,
--        NGAYVAY,
--        HANTRA,
--        TRANGTHAI
--    FROM 
--        HOPDONG;
--END
--GO








