USE [master]
GO
/****** Object:  Database [Limedika_Task]    Script Date: 2020-04-27 00:21:05 ******/
CREATE DATABASE [Limedika_Task]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Limedika_Task', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Limedika_Task.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Limedika_Task_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Limedika_Task_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Limedika_Task] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Limedika_Task].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Limedika_Task] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Limedika_Task] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Limedika_Task] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Limedika_Task] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Limedika_Task] SET ARITHABORT OFF 
GO
ALTER DATABASE [Limedika_Task] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Limedika_Task] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Limedika_Task] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Limedika_Task] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Limedika_Task] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Limedika_Task] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Limedika_Task] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Limedika_Task] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Limedika_Task] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Limedika_Task] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Limedika_Task] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Limedika_Task] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Limedika_Task] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Limedika_Task] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Limedika_Task] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Limedika_Task] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Limedika_Task] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Limedika_Task] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Limedika_Task] SET  MULTI_USER 
GO
ALTER DATABASE [Limedika_Task] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Limedika_Task] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Limedika_Task] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Limedika_Task] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Limedika_Task] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Limedika_Task] SET QUERY_STORE = OFF
GO
USE [Limedika_Task]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2020-04-27 00:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Name] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[PostCode] [nvarchar](10) NULL,
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 2020-04-27 00:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Action] [nvarchar](255) NOT NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logs] ADD  CONSTRAINT [DF_Logs_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  StoredProcedure [dbo].[CreateLog]    Script Date: 2020-04-27 00:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proceDURE [dbo].[CreateLog]
(
	@Action nvarchar(255)
)
AS
BEGIn
	BEGIN
		Insert Into [Logs] ([Action]) Values(@Action);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetClients]    Script Date: 2020-04-27 00:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClients]
AS
BEGIN
		Select * From [Clients]
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateClient]    Script Date: 2020-04-27 00:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateClient]
(
	@ClientID int,
	@Name nvarchar(255),
	@Address nvarchar(255),
	@PostCode nvarchar(10)
)
AS
BEGIN
	if exists (Select * From [Clients] WHERE ClientID = @ClientID)
	BEGIN
		Update [Clients] Set [Name] = @Name, [Address] = @Address, PostCode = @PostCode Where ClientID = @ClientID;
		Select Cast(@ClientID as int);
	END
	else
	BEGIN
		Insert Into [Clients] ([Name], [Address], PostCode) Values(@Name, @Address, @PostCode);
		Select Cast(SCOPE_IDENTITY() as int);
	END
END
GO
USE [master]
GO
ALTER DATABASE [Limedika_Task] SET  READ_WRITE 
GO
