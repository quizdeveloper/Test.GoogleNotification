# Test.GoogleNotification
Below is DB (MSSQL)


CREATE DATABASE [GoogleNotification]

GO

USE [GoogleNotification]

GO


/****** Object:  Table [dbo].[NotifyHistory]    Script Date: 2/24/2022 4:59:57 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[NotifyHistory](

	[NotifyHistoryId] [int] IDENTITY(1,1) NOT NULL,
	
	[UserId] [int] NULL,
	
	[PushDate] [datetime] NULL,
	
	[Status] [bit] NULL,
	
	[Message] [nvarchar](500) NULL,
	
	[Title] [nvarchar](100) NULL,
	
	[Link] [varchar](150) NULL,
	
 CONSTRAINT [PK_NotifyHistory] PRIMARY KEY CLUSTERED 
 
(
	[NotifyHistoryId] ASC
	
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[User]    Script Date: 2/24/2022 4:59:57 PM ******/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[User](

	[UserId] [int] IDENTITY(1,1) NOT NULL,
	
	[IpAddress] [nvarchar](100) NULL,
	
	[SubscribeToken] [varchar](500) NULL,
	
	[CreatedDate] [datetime] NULL,
	
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
 
(

	[UserId] ASC
	
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]



