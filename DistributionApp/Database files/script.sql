USE [master]
GO
/****** Object:  Database [DistributionDb]    Script Date: 8/28/2018 9:47:53 PM ******/
CREATE DATABASE [DistributionDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DistributionDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DistributionDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DistributionDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DistributionDb.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DistributionDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DistributionDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DistributionDb] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [DistributionDb] SET ANSI_NULLS ON 
GO
ALTER DATABASE [DistributionDb] SET ANSI_PADDING ON 
GO
ALTER DATABASE [DistributionDb] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [DistributionDb] SET ARITHABORT ON 
GO
ALTER DATABASE [DistributionDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DistributionDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DistributionDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DistributionDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DistributionDb] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [DistributionDb] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [DistributionDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DistributionDb] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [DistributionDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DistributionDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DistributionDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DistributionDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DistributionDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DistributionDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DistributionDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DistributionDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DistributionDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DistributionDb] SET RECOVERY FULL 
GO
ALTER DATABASE [DistributionDb] SET  MULTI_USER 
GO
ALTER DATABASE [DistributionDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DistributionDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DistributionDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DistributionDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DistributionDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DistributionDb] SET QUERY_STORE = OFF
GO
USE [DistributionDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DistributionDb]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address1] [varchar](50) NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[CreditLimit] [decimal](18, 0) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
 CONSTRAINT [PK__Customer__A4AE64D8BB132FA0] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Qty] [int] NULL,
	[BatchNumber] [varchar](50) NULL,
	[ExpiryDate] [date] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderDate] [date] NULL,
	[InvoiceCreated] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
	[PricePerUnit] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiveGood]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveGood](
	[ReceiveGoodId] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NULL,
	[TruckNumber] [varchar](50) NULL,
	[ReceiveDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_ReceiveGoods] PRIMARY KEY CLUSTERED 
(
	[ReceiveGoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiveGoodDetails]    Script Date: 8/28/2018 9:47:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiveGoodDetails](
	[ReceiveGoodDetailId] [int] IDENTITY(1,1) NOT NULL,
	[ReceiveGoodId] [int] NULL,
	[ProductId] [int] NULL,
	[BatchNumber] [varchar](50) NULL,
	[ExpiryDate] [date] NULL,
	[Quantity] [int] NULL,
	[TotalValue] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ReceiveGoodDetails] PRIMARY KEY CLUSTERED 
(
	[ReceiveGoodDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Product]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[ReceiveGoodDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveGoodDetails_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ReceiveGoodDetails] CHECK CONSTRAINT [FK_ReceiveGoodDetails_Product]
GO
ALTER TABLE [dbo].[ReceiveGoodDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReceiveGoodDetails_ReceiveGood] FOREIGN KEY([ReceiveGoodId])
REFERENCES [dbo].[ReceiveGood] ([ReceiveGoodId])
GO
ALTER TABLE [dbo].[ReceiveGoodDetails] CHECK CONSTRAINT [FK_ReceiveGoodDetails_ReceiveGood]
GO
USE [master]
GO
ALTER DATABASE [DistributionDb] SET  READ_WRITE 
GO
