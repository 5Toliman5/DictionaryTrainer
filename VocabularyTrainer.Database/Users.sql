﻿CREATE TABLE [dbo].[Users]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Name] [nvarchar](64) NOT NULL UNIQUE,
	[Info] [nvarchar](max) NULL,
	[Login] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](32) NOT NULL
)
