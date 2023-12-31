USE [EnumDatabase]
GO
/****** Object:  Table [dbo].[MiscSettings]    Script Date: 11/23/2023 8:23:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiscSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TheEnumId] [int] NOT NULL,
 CONSTRAINT [PK_MiscSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheEnum]    Script Date: 11/23/2023 8:23:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheEnum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TheEnum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MiscSettings] ON 

INSERT [dbo].[MiscSettings] ([Id], [Name], [TheEnumId]) VALUES (1, N'First setting', 2)
INSERT [dbo].[MiscSettings] ([Id], [Name], [TheEnumId]) VALUES (2, N'Second setting', 3)
SET IDENTITY_INSERT [dbo].[MiscSettings] OFF
GO
SET IDENTITY_INSERT [dbo].[TheEnum] ON 

INSERT [dbo].[TheEnum] ([Id], [TypeName], [Description]) VALUES (1, N'One', N'First')
INSERT [dbo].[TheEnum] ([Id], [TypeName], [Description]) VALUES (2, N'Two', N'Second')
INSERT [dbo].[TheEnum] ([Id], [TypeName], [Description]) VALUES (3, N'Three', N'Third')
SET IDENTITY_INSERT [dbo].[TheEnum] OFF
GO
USE [master]
GO
ALTER DATABASE [EnumDatabase] SET  READ_WRITE 
GO
