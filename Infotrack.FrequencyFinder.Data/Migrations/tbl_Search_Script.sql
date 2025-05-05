USE [Infotrack]
GO
/****** Object:  Table [dbo].[Search]    Script Date: 05/05/2025 21:34:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Search](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SearchQuery] [nvarchar](100) NOT NULL,
	[SearchEngine] [nvarchar](100) NULL,
	[SearchRank] [nvarchar](100) NULL,
	[SearchOn] [datetime] NULL,
	[SearchBy] [nvarchar](100) NULL,
 CONSTRAINT [PK_Search] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 70, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Search] ON 
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (1, N'test1234', N'Google', N'Not Found', CAST(N'2025-05-03T12:53:51.977' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (2, N'land registry search', N'Google', N'16', CAST(N'2025-05-03T12:53:51.977' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (3, N'infotrack', N'Bing', N'1, 2, 3, 9', CAST(N'2025-05-03T15:14:36.310' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (4, N'infotrack', N'Bing', N'1, 2, 3, 9', CAST(N'2025-05-03T16:20:10.843' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (5, N'infotrack', N'Bing', N'1, 2, 3, 9', CAST(N'2025-05-03T16:35:31.660' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (6, N'land registry search', N'Yahoo', N'Not Found', CAST(N'2025-05-03T16:59:46.007' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (7, N'land registry search', N'Yahoo', N'Not Found', CAST(N'2025-05-03T21:23:35.350' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (8, N'land registry search', N'Yahoo', N'Not Found', CAST(N'2025-05-03T21:23:35.350' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (9, N'land registry search', N'Yahoo', N'Not Found', CAST(N'2025-05-03T21:23:35.350' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (10, N'land registry search', N'Google', N'Not Found', CAST(N'2025-05-03T21:28:24.717' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (11, N'land registry search', N'Google', N'Not Found', CAST(N'2025-05-03T21:28:46.477' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (12, N'land registry search', N'Google', N'Not Found', CAST(N'2025-05-04T17:37:33.220' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (13, N'land registry search', N'Google', N'17', CAST(N'2025-05-04T17:43:19.080' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (14, N'infotrack', N'Bing', N'1, 2, 8, 14, 18, 19', CAST(N'2025-05-04T17:44:58.550' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (15, N'infotrack', N'Yahoo', N'Not Found', CAST(N'2025-05-04T17:45:23.740' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (16, N'infotrack', N'Bing', N'1, 4, 6, 7, 8, 9', CAST(N'2025-05-04T18:26:34.067' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (17, N'land registry search', N'Google', N'18', CAST(N'2025-05-04T18:27:09.053' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (18, N'land registry search', N'Google', N'19', CAST(N'2025-05-04T18:27:29.757' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (19, N'land registry search', N'Google', N'17', CAST(N'2025-05-05T09:48:43.963' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (20, N'infotrack', N'Bing', N'1, 4, 6, 7, 8, 9', CAST(N'2025-05-05T09:49:49.933' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (21, N'infotrack', N'Yahoo', N'Not Found', CAST(N'2025-05-05T09:50:31.023' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (22, N'infotrack', N'Google', N'1', CAST(N'2025-05-05T09:54:55.213' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (23, N'land registry search', N'Google', N'19', CAST(N'2025-05-05T09:59:16.583' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (24, N'land registry search', N'Google', N'17', CAST(N'2025-05-05T10:13:51.313' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (25, N'land registry search', N'Google', N'17', CAST(N'2025-05-05T12:46:16.460' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (26, N'infotrack', N'Bing', N'1, 4, 6, 7, 8, 9', CAST(N'2025-05-05T14:15:46.080' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (27, N'land registry search', N'Google', N'13', CAST(N'2025-05-05T15:05:53.593' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (28, N'land registry search', N'Bing', N'Not Found', CAST(N'2025-05-05T15:24:34.017' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (29, N'infotrack', N'Bing', N'1, 4, 6, 7, 8, 9', CAST(N'2025-05-05T15:35:07.330' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (30, N'infotrack', N'Yahoo', N'Not Found', CAST(N'2025-05-05T15:40:30.310' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (31, N'land registry search', N'Google', N'18', CAST(N'2025-05-05T21:11:13.980' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (32, N'land registry search', N'Bing', N'Not Found', CAST(N'2025-05-05T21:11:50.650' AS DateTime), N'WebUser')
GO
INSERT [dbo].[Search] ([Id], [SearchQuery], [SearchEngine], [SearchRank], [SearchOn], [SearchBy]) VALUES (33, N'infotrack', N'Yahoo', N'Not Found', CAST(N'2025-05-05T21:11:59.277' AS DateTime), N'WebUser')
GO
SET IDENTITY_INSERT [dbo].[Search] OFF
GO
ALTER TABLE [dbo].[Search] ADD  CONSTRAINT [DF_Search_SearchOn]  DEFAULT (getdate()) FOR [SearchOn]
GO
