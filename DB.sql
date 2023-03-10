USE [master]
GO
/****** Object:  Database [PurchaseOrder_DB]    Script Date: 3/7/2023 9:30:31 PM ******/
CREATE DATABASE [PurchaseOrder_DB]
GO
ALTER DATABASE [PurchaseOrder_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PurchaseOrder_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PurchaseOrder_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PurchaseOrder_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PurchaseOrder_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PurchaseOrder_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PurchaseOrder_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PurchaseOrder_DB] SET  MULTI_USER 
GO
ALTER DATABASE [PurchaseOrder_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PurchaseOrder_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PurchaseOrder_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PurchaseOrder_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PurchaseOrder_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PurchaseOrder_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PurchaseOrder_DB] SET QUERY_STORE = OFF
GO
USE [PurchaseOrder_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerScubscription]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerScubscription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[SubscriptionId] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_CustomerScubscription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductCode] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Qty] [int] NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[SubscriptionId] [int] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[DeliveryAddress] [nvarchar](max) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[NetTotal] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[Category] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[SubscriptionId] [int] NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 3/7/2023 9:30:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubscriptionName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Subscriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221203083844_v1', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221203103853_v2', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230227114335_v1.0', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230306080755_AddedOrder', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230306085114_dbChange-1', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230306101044_dbChange-2', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230307050502_db-change-3', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230307091739_db-change-4', N'6.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230307091907_db-change-5', N'6.0.8')
GO
SET IDENTITY_INSERT [dbo].[CustomerScubscription] ON 

INSERT [dbo].[CustomerScubscription] ([Id], [CustomerId], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (7, 1, 2, NULL, CAST(N'2023-03-06T18:42:49.7429258' AS DateTime2), 0, 0)
INSERT [dbo].[CustomerScubscription] ([Id], [CustomerId], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (8, 2, 2, NULL, CAST(N'2023-03-07T10:00:19.4463830' AS DateTime2), 0, 0)
INSERT [dbo].[CustomerScubscription] ([Id], [CustomerId], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (10, 1, 2, NULL, CAST(N'2023-03-07T12:53:44.8809486' AS DateTime2), 0, 0)
INSERT [dbo].[CustomerScubscription] ([Id], [CustomerId], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (11, 1, 2, NULL, CAST(N'2023-03-07T18:56:48.8440400' AS DateTime2), 0, 0)
INSERT [dbo].[CustomerScubscription] ([Id], [CustomerId], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (12, 2, 2, NULL, CAST(N'2023-03-07T20:18:12.7720341' AS DateTime2), 0, 0)
SET IDENTITY_INSERT [dbo].[CustomerScubscription] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (12, 10, 2, N'Prod001', N'Prod1 test', 2, CAST(50.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, CAST(N'2023-03-07T12:53:38.2429651' AS DateTime2), CAST(N'2023-03-07T12:53:38.2429666' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (13, 10, 5, N'Prod002', N'Prod1 test 2', 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 2, CAST(N'2023-03-07T12:53:38.2429700' AS DateTime2), CAST(N'2023-03-07T12:53:38.2429700' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (14, 11, 2, N'Prod001', N'Prod1 test', 2, CAST(50.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, CAST(N'2023-03-07T18:56:48.8417076' AS DateTime2), CAST(N'2023-03-07T18:56:48.8417104' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (15, 11, 5, N'Prod002', N'Prod1 test 2', 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 2, CAST(N'2023-03-07T18:56:48.8417191' AS DateTime2), CAST(N'2023-03-07T18:56:48.8417193' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (18, 12, 2, N'Prod001', N'Prod1 test', 2, CAST(50.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, CAST(N'2023-03-07T20:18:12.7708149' AS DateTime2), CAST(N'2023-03-07T20:18:12.7708172' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (19, 12, 5, N'Prod002', N'Prod1 test 2', 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 2, CAST(N'2023-03-07T20:18:12.7708245' AS DateTime2), CAST(N'2023-03-07T20:18:12.7708247' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (20, 8, 2, N'Prod001 ..', N'Prod1 test', 2, CAST(50.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), NULL, CAST(N'2023-03-07T20:23:30.7146555' AS DateTime2), CAST(N'2023-03-07T20:23:30.7146577' AS DateTime2), NULL, NULL)
INSERT [dbo].[OrderItems] ([Id], [OrderId], [ProductId], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [SubscriptionId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (21, 8, 5, N'Prod002...', N'Prod1 test 2', 1, CAST(50.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), 2, CAST(N'2023-03-07T20:23:30.7153681' AS DateTime2), CAST(N'2023-03-07T20:23:30.7153691' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [CustomerName], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (8, CAST(N'2023-03-07T09:59:14.4087252' AS DateTime2), 2, N'TEst Cust..', N'CA', N'Test data', CAST(120.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(N'2023-03-07T09:59:46.9692898' AS DateTime2), CAST(N'2023-03-07T09:58:50.0907519' AS DateTime2), 1, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [CustomerName], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (10, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, N'TEst Cust Updated', N'CA', N'Test data', CAST(120.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(N'2023-03-07T18:59:15.8697325' AS DateTime2), CAST(N'2023-03-07T18:59:15.8697615' AS DateTime2), NULL, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [CustomerName], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (11, CAST(N'2023-03-07T18:56:48.8417209' AS DateTime2), 1, N'TEst Cust', N'CA', N'Test data', CAST(120.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(N'2023-03-07T18:56:48.8422772' AS DateTime2), CAST(N'2023-03-07T18:56:48.8297340' AS DateTime2), 1, NULL)
INSERT [dbo].[Orders] ([Id], [OrderDate], [CustomerId], [CustomerName], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (12, CAST(N'2023-03-07T20:18:12.7708264' AS DateTime2), 2, N'TEst Cust', N'CA', N'Test data', CAST(120.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(140.00 AS Decimal(18, 2)), CAST(N'2023-03-07T20:18:12.7710577' AS DateTime2), CAST(N'2023-03-07T20:18:12.7466593' AS DateTime2), 1, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (2, 1, 1, 1, CAST(N'2023-03-07T20:02:18.5733333' AS DateTime2), N'Product 2 Updated2', CAST(1000.00 AS Decimal(18, 2)), N'Test Data', 0, CAST(N'2023-03-07T20:16:56.1272206' AS DateTime2))
INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (3, 1, 1, 1, CAST(N'2023-03-06T17:18:10.0533333' AS DateTime2), N'Product 3', CAST(300.00 AS Decimal(18, 2)), N'Test Data', 0, CAST(N'2023-03-06T17:18:10.0533333' AS DateTime2))
INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (10, 1, 1, 1, CAST(N'2023-03-07T19:08:37.0498744' AS DateTime2), N'Video ''Comprehensive First Aid Training''', CAST(599.00 AS Decimal(18, 2)), N'Test Data from Assigment ', 0, CAST(N'2023-03-07T19:08:37.0497828' AS DateTime2))
INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (11, 1, 1, 1, CAST(N'2023-03-07T19:08:37.0498744' AS DateTime2), N'Book ''The girl on the train''', CAST(99.00 AS Decimal(18, 2)), N'Test Data from Assigment ', 0, CAST(N'2023-03-07T19:08:37.0497828' AS DateTime2))
INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (12, 1, 1, 2, CAST(N'2023-03-07T19:08:37.0498744' AS DateTime2), N'Book Club Membership', CAST(299.00 AS Decimal(18, 2)), N'Test Data from Assigment ', 2, CAST(N'2023-03-07T19:08:37.0497828' AS DateTime2))
INSERT [dbo].[Products] ([Id], [CreatedBy], [UpdatedBy], [Category], [CreatedOn], [Name], [Price], [Remarks], [SubscriptionId], [UpdatedOn]) VALUES (13, 1, 1, 2, CAST(N'2023-03-07T19:08:37.0498744' AS DateTime2), N'Video Club Membership', CAST(599.00 AS Decimal(18, 2)), N'Test Data from Assigment ', 3, CAST(N'2023-03-07T19:08:37.0497828' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscriptions] ON 

INSERT [dbo].[Subscriptions] ([Id], [SubscriptionName], [Description], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (2, N'30 Days', N'30', CAST(N'2023-03-06T17:18:10.0533333' AS DateTime2), CAST(N'2023-03-06T17:18:10.0533333' AS DateTime2), 1, 1)
INSERT [dbo].[Subscriptions] ([Id], [SubscriptionName], [Description], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (3, N'90 Days', N'90', CAST(N'2023-03-06T17:18:10.0566667' AS DateTime2), CAST(N'2023-03-06T17:18:10.0566667' AS DateTime2), 1, 1)
INSERT [dbo].[Subscriptions] ([Id], [SubscriptionName], [Description], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy]) VALUES (4, N'1 Year', N'Annual', CAST(N'2023-03-06T17:18:10.0566667' AS DateTime2), CAST(N'2023-03-06T17:18:10.0566667' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[Subscriptions] OFF
GO
/****** Object:  Index [IX_OrderItems_OrderId]    Script Date: 3/7/2023 9:30:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderItems_OrderId] ON [dbo].[OrderItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT ((0.0)) FOR [SalesPrice]
GO
ALTER TABLE [dbo].[OrderItems] ADD  DEFAULT ((0.0)) FOR [Total]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (N'') FOR [CustomerName]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [Total]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [Tax]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0)) FOR [NetTotal]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Category]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrdersItems_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrdersItems_Orders]
GO
USE [master]
GO
ALTER DATABASE [PurchaseOrder_DB] SET  READ_WRITE 
GO
