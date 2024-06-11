USE [master]
GO
/****** Object:  Database [LinkedInDb]    Script Date: 4/17/2024 11:28:58 PM ******/
CREATE DATABASE [LinkedInDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LinkedInDb', FILENAME = N'/var/opt/mssql/data/LinkedInDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LinkedInDb_log', FILENAME = N'/var/opt/mssql/data/LinkedInDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LinkedInDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LinkedInDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LinkedInDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LinkedInDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LinkedInDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LinkedInDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LinkedInDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LinkedInDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LinkedInDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LinkedInDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LinkedInDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LinkedInDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LinkedInDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LinkedInDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LinkedInDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LinkedInDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LinkedInDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LinkedInDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LinkedInDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LinkedInDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LinkedInDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LinkedInDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LinkedInDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LinkedInDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LinkedInDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LinkedInDb] SET  MULTI_USER 
GO
ALTER DATABASE [LinkedInDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LinkedInDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LinkedInDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LinkedInDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LinkedInDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LinkedInDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LinkedInDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [LinkedInDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LinkedInDb]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
	[FreeTxt] [nvarchar](1000) NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[FreeTxt] [nvarchar](200) NOT NULL,
	[CreatedId] [datetimeoffset](7) NOT NULL,
	[UpdatedId] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactRequest]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRequestId] [int] NOT NULL,
	[UserResiverId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
	[IsAccepted] [bit] NOT NULL,
 CONSTRAINT [PK_ContactRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CV]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UrlBath] [nvarchar](250) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_CV] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Education]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Education](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experience]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experience](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Message]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[ResiverId] [int] NOT NULL,
	[FreeTxt] [nvarchar](200) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[FreeTxt] [nchar](1000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[MultimediaUrlPath] [nvarchar](250) NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/17/2024 11:28:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Role] [tinyint] NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[DateUpdated] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_User]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[ContactRequest]  WITH CHECK ADD  CONSTRAINT [FK_ContactRequest_User] FOREIGN KEY([UserResiverId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ContactRequest] CHECK CONSTRAINT [FK_ContactRequest_User]
GO
ALTER TABLE [dbo].[ContactRequest]  WITH CHECK ADD  CONSTRAINT [FK_ContactRequest_User1] FOREIGN KEY([UserRequestId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ContactRequest] CHECK CONSTRAINT [FK_ContactRequest_User1]
GO
ALTER TABLE [dbo].[CV]  WITH CHECK ADD  CONSTRAINT [FK_CV_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CV] CHECK CONSTRAINT [FK_CV_User]
GO
ALTER TABLE [dbo].[Education]  WITH CHECK ADD  CONSTRAINT [FK_Education_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Education] CHECK CONSTRAINT [FK_Education_User]
GO
ALTER TABLE [dbo].[Experience]  WITH CHECK ADD  CONSTRAINT [FK_Experience_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Experience] CHECK CONSTRAINT [FK_Experience_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([ResiverId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([SenderId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
USE [master]
GO
ALTER DATABASE [LinkedInDb] SET  READ_WRITE 
GO
