USE [master]
GO

CREATE DATABASE [MayAnh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MayAnh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MayAnh.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MayAnh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MayAnh_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MayAnh] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MayAnh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MayAnh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MayAnh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MayAnh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MayAnh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MayAnh] SET ARITHABORT OFF 
GO
ALTER DATABASE [MayAnh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MayAnh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MayAnh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MayAnh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MayAnh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MayAnh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MayAnh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MayAnh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MayAnh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MayAnh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MayAnh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MayAnh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MayAnh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MayAnh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MayAnh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MayAnh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MayAnh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MayAnh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MayAnh] SET  MULTI_USER 
GO
ALTER DATABASE [MayAnh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MayAnh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MayAnh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MayAnh] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MayAnh] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MayAnh]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[MaTK] [nvarchar](10) NOT NULL,
	[TenDN] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](20) NULL,
	[Quyen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DMMAYANH](
	[MaDM] [nvarchar](20) NOT NULL,
	[TieuDe] [nvarchar](50) NULL,
	[AnhDaiDien] [text] NULL,
	[GiaBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MAYANH](
	[MaAnh] [nvarchar](20) NOT NULL,
	[TieuDe] [nvarchar](50) NULL,
	[AnhDaiDien] [text] NULL,
	[GiaBan] [int] NULL,
	[SoLuong] [int] NULL,
	[MoTa] [nvarchar](max) NULL,
	[MaDM] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
GO
SET ANSI_PADDING OFF
GO

INSERT [dbo].[taikhoan] ([MaTK], [TenDN], [MatKhau], [Quyen]) VALUES ('Ma01', 'admin', '123456', 'admin')
INSERT [dbo].[taikhoan] ([MaTK], [TenDN], [MatKhau], [Quyen]) VALUES ('Ma02', 'admin1', '123456', 'admin1')
INSERT [dbo].[taikhoan] ([MaTK], [TenDN], [MatKhau], [Quyen]) VALUES ('Ma03', 'admin2', '123456', 'admin2')

INSERT [dbo].[DMMAYANH] ([MaDM], [TieuDe], [AnhDaiDien], [GiaBan]) VALUES ('MaDM01','CANON','canon-logo.jpg',3000000)
INSERT [dbo].[DMMAYANH] ([MaDM], [TieuDe], [AnhDaiDien], [GiaBan]) VALUES ('MaDM02','SONY','sony-logo.jpg',5000000)
INSERT [dbo].[DMMAYANH] ([MaDM], [TieuDe], [AnhDaiDien], [GiaBan]) VALUES ('MaDM03','LG','lg-logo.jpg',2000000)
INSERT [dbo].[DMMAYANH] ([MaDM], [TieuDe], [AnhDaiDien], [GiaBan]) VALUES ('MaDM04','PANASONIC','panasonic-logo.jpg',8000000)

INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA1','CANON','canon1.jpg',2000000,10,'CANON Ixus','MaDM01')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA2','CANON','canon2.jpg',1000000,15,'CANON PowerShut','MaDM01')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA3','CANON','canon3.jpg',3000000,12,'CANON EOS','MaDM01')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA4','SONY','sony1.jpg',3000000,10,'SONY Alpha','MaDM02')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA5','SONY','sony2.jpg',4000000,15,'SONY SV-E10 Kit','MaDM02')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA6','SONY','sony3.jpg',5000000,12,'SONY DSC','MaDM02')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA7','LG','lg1.jpg',1000000,10,'LG PC389S','MaDM03')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA8','LG','lg2.jpg',1200000,15,'LG Poket','MaDM03')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA9','LG','lg3.jpg',1500000,12,'LG L-03C','MaDM03')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA10','PANASONIC','panasonic1.jpg',3000000,10,'PANASONIC Lumix','MaDM04')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA11','PANASONIC','panasonic2.jpg',5000000,15,'PANASONIC DMC-Lx100','MaDM04')
INSERT [dbo].[MAYANH] ([MaAnh], [TieuDe], [AnhDaiDien], [GiaBan], [SoLuong], [MoTa], [MaDM]) VALUES('MaMA12','PANASONIC','panasonic3.jpg',4000000,12,'PANASONIC FZ60','MaDM04')

GO
ALTER TABLE [dbo].[taikhoan] ADD UNIQUE NONCLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MAYANH]  WITH CHECK ADD FOREIGN KEY([MaDM])
REFERENCES [dbo].[DMMAYANH] ([MaDM])
ON UPDATE CASCADE
ON DELETE CASCADE
GO