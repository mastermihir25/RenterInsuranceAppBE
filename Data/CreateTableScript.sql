USE [master]
GO
/****** Object:  Database [RenterInsurancedb]    Script Date: 2024-11-30 10:05:32 PM ******/
CREATE DATABASE [RenterInsurancedb]

GO
USE [RenterInsurancedb]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 2024-11-30 10:05:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](5000) NULL,
	[Value] [decimal](18, 0) NULL,
	[Category] [varchar](5000) NULL
) ON [PRIMARY]
GO
