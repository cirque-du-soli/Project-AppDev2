USE [TicketDb]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 3/25/2024 8:57:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Department] [nvarchar](100) NOT NULL,
	[Subject] [nvarchar](250) NOT NULL,
	[RegDate] [date] NOT NULL,
	[Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([ID], [Department], [Subject], [RegDate], [Details]) VALUES (1, N'System.Windows.Controls.ComboBoxItem: Accounts', N'gdgdg', CAST(N'2024-03-12' AS Date), N'')
INSERT [dbo].[Tickets] ([ID], [Department], [Subject], [RegDate], [Details]) VALUES (2, N'System.Windows.Controls.ComboBoxItem: Administration', N'gdsgdsgsg', CAST(N'2024-03-20' AS Date), N'dgsgdgdfgdgfg dgdgdg trdggd')
INSERT [dbo].[Tickets] ([ID], [Department], [Subject], [RegDate], [Details]) VALUES (3, N'System.Windows.Controls.ComboBoxItem: HR', N'htere', CAST(N'2024-03-12' AS Date), N'')
INSERT [dbo].[Tickets] ([ID], [Department], [Subject], [RegDate], [Details]) VALUES (4, N'Accounts', N'gjgj', CAST(N'2024-03-19' AS Date), N'')
INSERT [dbo].[Tickets] ([ID], [Department], [Subject], [RegDate], [Details]) VALUES (5, N'HR', N'my desktop screen is black', CAST(N'2024-03-20' AS Date), N'tafjslajf afjal faj f lajf laj flaj lajflajflafj aljf fadljaljfd')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
