USE [BestQA]
GO
/****** Object:  Table [dbo].[User]    Script Date: 06/24/2015 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserName] [varchar](50) NOT NULL,
	[Money] [int] NOT NULL,
	[Id] [varchar](50) NOT NULL,
 CONSTRAINT [PK__User__C9F284570AD2A005] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 06/24/2015 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [varchar](50) NOT NULL,
	[TagTo] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Tag__3214EC070F975522] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Question]    Script Date: 06/24/2015 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [varchar](50) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Content] [varchar](1000) NOT NULL,
	[SupportCnt] [int] NOT NULL,
	[OpposeCnt] [int] NOT NULL,
	[Reward] [int] NOT NULL,
	[CreatedTime] [datetime] NULL,
	[State] [int] NOT NULL,
	[UserId] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Question__3214EC071367E606] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Post]    Script Date: 06/24/2015 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [varchar](50) NOT NULL,
	[Content] [varchar](1000) NOT NULL,
	[SupportCnt] [int] NOT NULL,
	[OpposeCnt] [int] NOT NULL,
	[CommentTo] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UserId] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Post__3214EC070519C6AF] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 06/24/2015 18:41:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [varchar](50) NOT NULL,
	[Content] [varchar](1000) NOT NULL,
	[SupportCnt] [int] NOT NULL,
	[OpposeCnt] [int] NOT NULL,
	[AnswerTo] [varchar](50) NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UserId] [varchar](50) NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK__Answer__3214EC077F60ED59] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__User__Money__0CBAE877]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__Money__0CBAE877]  DEFAULT ((0)) FOR [Money]
GO
/****** Object:  Default [DF__Question__Suppor__15502E78]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF__Question__Suppor__15502E78]  DEFAULT ((0)) FOR [SupportCnt]
GO
/****** Object:  Default [DF__Question__Oppose__164452B1]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF__Question__Oppose__164452B1]  DEFAULT ((0)) FOR [OpposeCnt]
GO
/****** Object:  Default [DF__Question__Reward__173876EA]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Question] ADD  CONSTRAINT [DF__Question__Reward__173876EA]  DEFAULT ((0)) FOR [Reward]
GO
/****** Object:  Default [DF__Post__SupportCnt__07020F21]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF__Post__SupportCnt__07020F21]  DEFAULT ((0)) FOR [SupportCnt]
GO
/****** Object:  Default [DF__Post__OpposeCnt__07F6335A]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Post] ADD  CONSTRAINT [DF__Post__OpposeCnt__07F6335A]  DEFAULT ((0)) FOR [OpposeCnt]
GO
/****** Object:  Default [DF__Answer__SupportC__014935CB]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF__Answer__SupportC__014935CB]  DEFAULT ((0)) FOR [SupportCnt]
GO
/****** Object:  Default [DF__Answer__OpposeCn__023D5A04]    Script Date: 06/24/2015 18:41:21 ******/
ALTER TABLE [dbo].[Answer] ADD  CONSTRAINT [DF__Answer__OpposeCn__023D5A04]  DEFAULT ((0)) FOR [OpposeCnt]
GO
