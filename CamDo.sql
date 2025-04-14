/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     14/04/2025 1:40:19 CH                        */
/*==============================================================*/
create database CamDo
go
use Camdo

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
   TRANGTHAI            varchar(20)          null,
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
   IDKH                 int                  not null,
   HOTEN                varchar(100)         null,
   CCCD                 char(15)             null,
   SDT                  char(10)             null,
   DIACHI               varchar(100)         null,
   NGAYTAO              datetime             null,
   constraint PK_KHACHHANG primary key nonclustered (IDKH)
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
   IDKH                 int                  not null,
   TENTS                varchar(100)         null,
   MOTA                 text                 null,
   GIATRI               bigint               null,
   HINHANH              varchar(255)         null,
   constraint PK_TAISAN primary key nonclustered (IDTS)
)
go

/*==============================================================*/
/* Index: SOHUU_FK                                              */
/*==============================================================*/
create index SOHUU_FK on TAISAN (
IDKH ASC
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
   add constraint FK_TAISAN_SOHUU_KHACHHAN foreign key (IDKH)
      references KHACHHANG (IDKH)
go

alter table THANHTOAN
   add constraint FK_THANHTOA_TRA_HOPDONG foreign key (IDHD)
      references HOPDONG (IDHD)
go

/*==========================================================================================*/

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