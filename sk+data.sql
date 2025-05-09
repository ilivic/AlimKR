USE [AlimBD]
GO
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 02.05.2025 13:15:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[id_CategoryProduct] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CategoryProduct] PRIMARY KEY CLUSTERED 
(
	[id_CategoryProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 02.05.2025 13:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [text] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 02.05.2025 13:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id_Employee] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [text] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DataStart] [date] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id_Employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 02.05.2025 13:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[Count] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[CategoryProduct_id] [int] NOT NULL,
	[Employe_id] [int] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 02.05.2025 13:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[id_sale] [int] IDENTITY(1,1) NOT NULL,
	[Product_id] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Cost] [money] NOT NULL,
	[Client_id] [int] NOT NULL,
	[Employe_id] [int] NULL,
	[DateSale] [datetime] NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[id_sale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryProduct] ON 

INSERT [dbo].[CategoryProduct] ([id_CategoryProduct], [Title]) VALUES (1, N'Категория 1')
INSERT [dbo].[CategoryProduct] ([id_CategoryProduct], [Title]) VALUES (2, N'Категория 2')
INSERT [dbo].[CategoryProduct] ([id_CategoryProduct], [Title]) VALUES (3, N'Категория 3')
INSERT [dbo].[CategoryProduct] ([id_CategoryProduct], [Title]) VALUES (4, N'Категория 4')
INSERT [dbo].[CategoryProduct] ([id_CategoryProduct], [Title]) VALUES (5, N'Категория 5')
SET IDENTITY_INSERT [dbo].[CategoryProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([id_client], [FullName], [Login], [Password]) VALUES (1, N'Иванов Иван Иванович', N'123', N'123')
INSERT [dbo].[Client] ([id_client], [FullName], [Login], [Password]) VALUES (2, N'Коля', N'11', N'11')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([id_Employee], [FullName], [Code], [IsActive], [DataStart]) VALUES (1, N'Ваня', N'1234', 1, CAST(N'2012-12-12' AS Date))
INSERT [dbo].[Employee] ([id_Employee], [FullName], [Code], [IsActive], [DataStart]) VALUES (2, N'Алл', N'12345', 0, CAST(N'2025-04-30' AS Date))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id_product], [Title], [Description], [Count], [Price], [CategoryProduct_id], [Employe_id], [IsActive]) VALUES (1, N'123', N'123', 123, 123.0000, 1, 1, 0)
INSERT [dbo].[Product] ([id_product], [Title], [Description], [Count], [Price], [CategoryProduct_id], [Employe_id], [IsActive]) VALUES (2, N'1234', N'1234', 1232, 1234.0000, 2, 1, 1)
INSERT [dbo].[Product] ([id_product], [Title], [Description], [Count], [Price], [CategoryProduct_id], [Employe_id], [IsActive]) VALUES (3, N'флофцврлфцв', N'флцорвфоцрвфцлорвло', 11, 21.0000, 3, 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([id_sale], [Product_id], [Count], [Cost], [Client_id], [Employe_id], [DateSale]) VALUES (1, 2, 1, 1234.0000, 1, 1, CAST(N'2025-04-30T21:23:32.410' AS DateTime))
INSERT [dbo].[Sales] ([id_sale], [Product_id], [Count], [Cost], [Client_id], [Employe_id], [DateSale]) VALUES (2, 2, 1, 1234.0000, 2, 1, CAST(N'2025-04-30T21:50:15.730' AS DateTime))
SET IDENTITY_INSERT [dbo].[Sales] OFF
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_CategoryProduct] FOREIGN KEY([CategoryProduct_id])
REFERENCES [dbo].[CategoryProduct] ([id_CategoryProduct])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_CategoryProduct]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Employee] FOREIGN KEY([Employe_id])
REFERENCES [dbo].[Employee] ([id_Employee])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Employee]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Client] FOREIGN KEY([Client_id])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Client]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Employee] FOREIGN KEY([Employe_id])
REFERENCES [dbo].[Employee] ([id_Employee])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Employee]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Product] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([id_product])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Product]
GO
