USE [zhuangkao]
GO
/****** Object:  Table [dbo].[zkuser]    Script Date: 08/26/2008 22:32:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[zkuser](
	[myorder] [int] NOT NULL,
	[idcardnumber] [char](100) NULL,
	[username] [char](10) NULL,
	[nickname] [char](30) NULL,
	[password] [char](30) NULL,
	[class] [int] NULL,
 CONSTRAINT [PK_zkuser] PRIMARY KEY CLUSTERED 
(
	[myorder] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
