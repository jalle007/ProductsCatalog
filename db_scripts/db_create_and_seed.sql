USE [master]
GO
/****** Object:  Database [LocalDb]    Script Date: 23/04/2021 10:39:45 ******/
CREATE DATABASE [LocalDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LocalDb', FILENAME = N'e:\Projects\TESTS\euris\db\LocalDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LocalDb_log', FILENAME = N'e:\Projects\TESTS\euris\db\LocalDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LocalDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LocalDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LocalDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LocalDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LocalDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LocalDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LocalDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LocalDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LocalDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LocalDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LocalDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LocalDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LocalDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LocalDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LocalDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LocalDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LocalDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LocalDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LocalDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LocalDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LocalDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LocalDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LocalDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LocalDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LocalDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LocalDb] SET  MULTI_USER 
GO
ALTER DATABASE [LocalDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LocalDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LocalDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LocalDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LocalDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LocalDb] SET QUERY_STORE = OFF
GO
USE [LocalDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LocalDb]
GO
/****** Object:  Table [dbo].[Catalog]    Script Date: 23/04/2021 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Product] [nvarchar](50) NULL,
	[Picture] [nchar](1000) NULL,
 CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23/04/2021 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Price] [float] NULL,
	[Picture] [nchar](1000) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCatalog]    Script Date: 23/04/2021 10:39:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCatalog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CatalogId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Catalog] ON 

INSERT [dbo].[Catalog] ([Id], [Code], [Description], [Product], [Picture]) VALUES (1, N'LAP01', N'Laptops', NULL, N'LAP01.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ')
INSERT [dbo].[Catalog] ([Id], [Code], [Description], [Product], [Picture]) VALUES (2, N'MEN01', N'Men''s Shoes', NULL, N'MEN01.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ')
INSERT [dbo].[Catalog] ([Id], [Code], [Description], [Product], [Picture]) VALUES (3, N'WAT01', N'Watches', NULL, N'WAT01.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ')
SET IDENTITY_INSERT [dbo].[Catalog] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (1, N'PUM01', N'PUMA Men''s Vista Sneakers', 39.99, N's1.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (2, N'ADI01', N'Adidas Advantage Base Shoes', 29.99, N's2.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (3, N'ALP01', N'Alpine Swiss Mens Flip Flops ', 10.99, N's3.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (4, N'NEW01', N'New Breitling Superocean 36 ', 1050, N's-l225.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (5, N'TAG01', N'Tag Heuer WAV511B.BA0900 ', 500, N's-l2251.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (6, N'ALI01', N'Alienware M15 R2 i9-9980HK 16GB', 2999.99, N'l1.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (7, N'DEL01', N'Dell XPS 13 9310 Laptop 15.6" ', 1049.99, N'l2.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
INSERT [dbo].[Product] ([Id], [Code], [Description], [Price], [Picture]) VALUES (8, N'HPS01', N'HP Spectre x360 2-in-1 15.6"', 1059.99, N'l3.png                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCatalog] ON 

INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (1, 6, 1)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (2, 7, 1)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (3, 8, 1)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (4, 1, 2)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (5, 2, 2)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (6, 3, 2)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (7, 4, 3)
INSERT [dbo].[ProductCatalog] ([Id], [ProductId], [CatalogId]) VALUES (8, 5, 3)
SET IDENTITY_INSERT [dbo].[ProductCatalog] OFF
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [fk_Catalog_Id] FOREIGN KEY([CatalogId])
REFERENCES [dbo].[Catalog] ([Id])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [fk_Catalog_Id]
GO
ALTER TABLE [dbo].[ProductCatalog]  WITH CHECK ADD  CONSTRAINT [fk_Product_Id] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductCatalog] CHECK CONSTRAINT [fk_Product_Id]
GO
USE [master]
GO
ALTER DATABASE [LocalDb] SET  READ_WRITE 
GO
