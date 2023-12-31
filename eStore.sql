USE [eStore]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/22/2023 11:23:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Categoryname] [nvarchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 7/22/2023 11:23:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](40) NULL,
	[CompanyName] [nvarchar](40) NULL,
	[City] [nvarchar](20) NULL,
	[Country] [nvarchar](20) NULL,
	[Password] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/22/2023 11:23:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NULL,
	[OrderDate] [datetime] NULL,
	[Required] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[Freight] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 7/22/2023 11:23:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NULL,
	[Quantity] [int] NULL,
	[Discount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/22/2023 11:23:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[ProductName] [varchar](255) NULL,
	[weight] [decimal](10, 2) NULL,
	[UnitPrice] [decimal](10, 2) NULL,
	[UnitsInStock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [Categoryname]) VALUES (1, N'Thuc pham')
INSERT [dbo].[Category] ([CategoryId], [Categoryname]) VALUES (2, N'Dien tu')
INSERT [dbo].[Category] ([CategoryId], [Categoryname]) VALUES (3, N'Xay Dung')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (1, N'buiquydangsnd1@gmail.com', N'FPT Software', N'Ha Noi', N'Viet Nam', N'1234567')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (2, N'tranquangtung@gmail.com', N'FPT Software Cau Giay', N'Ha Noi', N'Viet Nam', N'123456789')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (3, N'phungphuclam@gmail.com', N'VTI', N'Ha Noi', N'Viet Nam', N'123456')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (4, N'nguyekhanhduy@gmail.com', N'Cave', N'Ha Noi', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (6, N'luongbadangninh@gmail.com', N'FSOFT Cau giay', N'Ha Noi', N'Viet Nam', N'123456')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (7, N'luongbadangninh@gmail.com', N'FSOFT ', N'Ha Noi', N'Viet Nam', N'123456')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (9, N'deu9999@gmail.com', N'VTI', N'Lao Cai', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (10, N'deu107@gmail.com', N'VTI', N'Lao Cai', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (12, N'dangbqhe@gmail.com', N'Toyota', N'Ha Noi', N'Viet Nam', N'123')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (13, N'luongbadangninh@gmail.com', N'FSOFT Hoa Lac', N'Ha Noi', N'Viet Nam', N'123456')
INSERT [dbo].[Member] ([MemberId], [Email], [CompanyName], [City], [Country], [Password]) VALUES (15, N'buiha@gmail.com', N'FPT Software', N'Ho Chi Minh', N'Viet Nam', N'123456')
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [Required], [ShippedDate], [Freight]) VALUES (1, 1, CAST(N'2020-08-08T00:00:00.000' AS DateTime), CAST(N'2020-08-08T00:00:00.000' AS DateTime), CAST(N'2020-08-08T00:00:00.000' AS DateTime), CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [Required], [ShippedDate], [Freight]) VALUES (2, 2, CAST(N'2022-07-07T00:00:00.000' AS DateTime), CAST(N'2022-07-07T00:00:00.000' AS DateTime), CAST(N'2022-07-07T00:00:00.000' AS DateTime), CAST(3.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [Required], [ShippedDate], [Freight]) VALUES (3, 3, CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-10-07T00:00:00.000' AS DateTime), CAST(N'2023-11-07T00:00:00.000' AS DateTime), CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderId], [MemberId], [OrderDate], [Required], [ShippedDate], [Freight]) VALUES (4, 4, CAST(N'2023-09-07T23:59:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(N'2023-09-07T00:00:00.000' AS DateTime), CAST(2.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [UnitPrice], [Quantity], [Discount]) VALUES (1, 2, CAST(9.50 AS Decimal(10, 2)), 10, 1)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (2, 1, N'Mi tom chua cay Hao Hao', CAST(3.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (3, 2, N'Iphone 14 Pro Max', CAST(0.20 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (4, 3, N'Xi mang vicen Ninh Binh', CAST(50.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), NULL)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (6, 1, N'Dua Hau ', CAST(10.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (7, 3, N'Gach', CAST(1000.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (8, 1, N'Com Rang Dua', CAST(10.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 10)
INSERT [dbo].[Product] ([ProductId], [CategoryId], [ProductName], [weight], [UnitPrice], [UnitsInStock]) VALUES (11, 3, N'Gach Loai 2', CAST(100.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
