USE [master]
GO
/****** Object:  Database [RestaurantsManager_v2]    Script Date: 7/16/2024 2:08:36 AM ******/
CREATE DATABASE [RestaurantsManager_v2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RestaurantsManager_v2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RestaurantsManager_v2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RestaurantsManager_v2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RestaurantsManager_v2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RestaurantsManager_v2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RestaurantsManager_v2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RestaurantsManager_v2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ARITHABORT OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RestaurantsManager_v2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RestaurantsManager_v2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RestaurantsManager_v2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RestaurantsManager_v2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RestaurantsManager_v2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RestaurantsManager_v2] SET  MULTI_USER 
GO
ALTER DATABASE [RestaurantsManager_v2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RestaurantsManager_v2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RestaurantsManager_v2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RestaurantsManager_v2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RestaurantsManager_v2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RestaurantsManager_v2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RestaurantsManager_v2] SET QUERY_STORE = ON
GO
ALTER DATABASE [RestaurantsManager_v2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RestaurantsManager_v2]
GO
/****** Object:  Table [dbo].[category]    Script Date: 7/16/2024 2:08:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[catID] [int] IDENTITY(1,1) NOT NULL,
	[catName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[catID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 7/16/2024 2:08:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[pID] [int] IDENTITY(1,1) NOT NULL,
	[pName] [varchar](50) NULL,
	[pPrice] [float] NULL,
	[CategoryID] [int] NULL,
	[pImage] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[pID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 7/16/2024 2:08:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
	[phone] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tables]    Script Date: 7/16/2024 2:08:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tables](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 7/16/2024 2:08:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[fullname] [nvarchar](100) NULL,
	[phone] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[category] ON 
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (5, N'Cake')
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (22, N'Main Course')
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (23, N'Fast Food')
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (24, N'Italian')
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (25, N'Healthy')
GO
INSERT [dbo].[category] ([catID], [catName]) VALUES (26, N'Dessert')
GO
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[products] ON 
GO
INSERT [dbo].[products] ([pID], [pName], [pPrice], [CategoryID], [pImage]) VALUES (4, N'Pizza', 12.99, 24, 0x)
GO
INSERT [dbo].[products] ([pID], [pName], [pPrice], [CategoryID], [pImage]) VALUES (5, N'Burger', 8.99, 23, 0x)
GO
INSERT [dbo].[products] ([pID], [pName], [pPrice], [CategoryID], [pImage]) VALUES (6, N'Pasta', 10.5, 24, 0x)
GO
INSERT [dbo].[products] ([pID], [pName], [pPrice], [CategoryID], [pImage]) VALUES (7, N'Salad', 6.75, 25, 0x)
GO
INSERT [dbo].[products] ([pID], [pName], [pPrice], [CategoryID], [pImage]) VALUES (8, N'Ice Cream', 4.25, 26, 0x)
GO
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[staff] ON 
GO
INSERT [dbo].[staff] ([id], [name], [role], [phone]) VALUES (1, N'Alice Johnson', N'Cashier', N'99999999  ')
GO
INSERT [dbo].[staff] ([id], [name], [role], [phone]) VALUES (2, N'Bob Smith', N'Waiter', N'88888888  ')
GO
INSERT [dbo].[staff] ([id], [name], [role], [phone]) VALUES (3, N'Carol White', N'Cleaning', N'77777777  ')
GO
INSERT [dbo].[staff] ([id], [name], [role], [phone]) VALUES (4, N'David Brown', N'Manager', N'66666666  ')
GO
INSERT [dbo].[staff] ([id], [name], [role], [phone]) VALUES (5, N'Eve Black', N'Other', N'8888888999')
GO
SET IDENTITY_INSERT [dbo].[staff] OFF
GO
SET IDENTITY_INSERT [dbo].[tables] ON 
GO
INSERT [dbo].[tables] ([TableId], [TableName]) VALUES (1, N'ban 1')
GO
INSERT [dbo].[tables] ([TableId], [TableName]) VALUES (2, N'ban 2')
GO
INSERT [dbo].[tables] ([TableId], [TableName]) VALUES (3, N'ban 3')
GO
INSERT [dbo].[tables] ([TableId], [TableName]) VALUES (4, N'ban 5')
GO
INSERT [dbo].[tables] ([TableId], [TableName]) VALUES (5, N'ban 7')
GO
SET IDENTITY_INSERT [dbo].[tables] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 
GO
INSERT [dbo].[user] ([userid], [username], [password], [fullname], [phone]) VALUES (1, N'admin', N'admin', N'admin', N'1111111111')
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__user__F3DBC5728D6AAB42]    Script Date: 7/16/2024 2:08:36 AM ******/
ALTER TABLE [dbo].[user] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[category] ([catID])
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [chk_role] CHECK  (([role]='Other' OR [role]='Manager' OR [role]='Cleaning' OR [role]='Waiter' OR [role]='Cashier'))
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [chk_role]
GO
USE [master]
GO
ALTER DATABASE [RestaurantsManager_v2] SET  READ_WRITE 
GO
