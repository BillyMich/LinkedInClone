USE [master]
GO
/****** Object:  Database [LinkedInDb]    Script Date: 9/19/2024 11:48:00 PM ******/
CREATE DATABASE [LinkedInDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LinkedInDb', FILENAME = N'/var/opt/mssql/data/LinkedInDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LinkedInDb_log', FILENAME = N'/var/opt/mssql/data/LinkedInDb_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Advertisement]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[FreeTxt] [nvarchar](1000) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[TimesViewed] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Advertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertisementJobType]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertisementJobType](
	[Id] [int] NOT NULL,
	[JobTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[AdvertisementId] [int] NOT NULL,
 CONSTRAINT [PK_AdvertisementJobType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertismentProfessionalBranch]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertismentProfessionalBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdvertismentId] [int] NOT NULL,
	[ProfessionalBranchId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_AdvertismentProfessionalBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvertismentWorkingLocation]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvertismentWorkingLocation](
	[Id] [int] NOT NULL,
	[WorkingLocationId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[AdvertisementId] [int] NOT NULL,
 CONSTRAINT [PK_AdvertismentWorkingLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chat]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId1] [int] NOT NULL,
	[UserId2] [int] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Chat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatMessage]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[ChatId] [int] NOT NULL,
	[FreeTxt] [nvarchar](200) NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactRequest]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactRequest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRequestId] [int] NOT NULL,
	[UserResiverId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsAccepted] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_ContactRequest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatorId] [int] NOT NULL,
	[FreeTxt] [nchar](1000) NOT NULL,
	[Status] [smallint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[FreeTxt] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostMultimedia]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostMultimedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[FileName] [nvarchar](1000) NOT NULL,
	[DataOfFile] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_PostPhoto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostReaction]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostReaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[ReactionId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_PostReaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFDT_EducationType]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFDT_EducationType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_RFDT_EducationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFDT_JobType]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFDT_JobType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_RFDT_JobType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFDT_ProfessionalBranch]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFDT_ProfessionalBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_ProfessionalBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFDT_Reaction]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFDT_Reaction](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FileName] [nvarchar](200) NOT NULL,
	[DataOfFile] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_RFDT_Reaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RFDT_WorkingLocation]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RFDT_WorkingLocation](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CretedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_RFDT_WorkingLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/19/2024 11:48:00 PM ******/
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
	[Role] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCV]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCV](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FileName] [nvarchar](250) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[DataOfFile] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_CV] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCVFile]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCVFile](
	[Id] [int] NOT NULL,
	[UserCVId] [int] NOT NULL,
	[DateOfFile] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UserCVFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEducation]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEducation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[EducationTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Education] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEducationProfessionalBranch]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEducationProfessionalBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEducationId] [int] NOT NULL,
	[ProfessionalBranchId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UserEducationProfessionalBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExperience]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExperience](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[FreeTxt] [nvarchar](200) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[StartedAt] [date] NOT NULL,
	[EndedAt] [date] NOT NULL,
 CONSTRAINT [PK_Experience] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExperienceJobType]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExperienceJobType](
	[Id] [int] NOT NULL,
	[JobTypeId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
	[UserExpirienceId] [int] NOT NULL,
 CONSTRAINT [PK_UserExperienceJobType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExperienceWorkingLocation]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExperienceWorkingLocation](
	[Id] [int] NOT NULL,
	[WorkingLocationId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdateAt] [datetimeoffset](7) NOT NULL,
	[UserExperienceId] [int] NOT NULL,
 CONSTRAINT [PK_UserExperienceWorkingLocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExpirienceProfessionalBranch]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExpirienceProfessionalBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserExperienceId] [int] NOT NULL,
	[ProfessionalBranchId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdateAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UserExpirienceProfessionalBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPassword]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPassword](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UserPassworld] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPhotoProfile]    Script Date: 9/19/2024 11:48:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPhotoProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FileName] [nvarchar](1000) NOT NULL,
	[DataOfFile] [varbinary](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_UserPhotoProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_Advertisement_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_Advertisement_User]
GO
ALTER TABLE [dbo].[AdvertisementJobType]  WITH CHECK ADD  CONSTRAINT [FK_AdvertisementJobType_RFDT_JobType] FOREIGN KEY([JobTypeId])
REFERENCES [dbo].[RFDT_JobType] ([Id])
GO
ALTER TABLE [dbo].[AdvertisementJobType] CHECK CONSTRAINT [FK_AdvertisementJobType_RFDT_JobType]
GO
ALTER TABLE [dbo].[AdvertismentProfessionalBranch]  WITH CHECK ADD  CONSTRAINT [FK_AdvertismentProfessionalBranch_Advertisement] FOREIGN KEY([AdvertismentId])
REFERENCES [dbo].[Advertisement] ([Id])
GO
ALTER TABLE [dbo].[AdvertismentProfessionalBranch] CHECK CONSTRAINT [FK_AdvertismentProfessionalBranch_Advertisement]
GO
ALTER TABLE [dbo].[AdvertismentProfessionalBranch]  WITH CHECK ADD  CONSTRAINT [FK_AdvertismentProfessionalBranch_ProfessionalBranch] FOREIGN KEY([ProfessionalBranchId])
REFERENCES [dbo].[RFDT_ProfessionalBranch] ([Id])
GO
ALTER TABLE [dbo].[AdvertismentProfessionalBranch] CHECK CONSTRAINT [FK_AdvertismentProfessionalBranch_ProfessionalBranch]
GO
ALTER TABLE [dbo].[AdvertismentWorkingLocation]  WITH CHECK ADD  CONSTRAINT [FK_AdvertismentWorkingLocation_Advertisement] FOREIGN KEY([WorkingLocationId])
REFERENCES [dbo].[Advertisement] ([Id])
GO
ALTER TABLE [dbo].[AdvertismentWorkingLocation] CHECK CONSTRAINT [FK_AdvertismentWorkingLocation_Advertisement]
GO
ALTER TABLE [dbo].[AdvertismentWorkingLocation]  WITH CHECK ADD  CONSTRAINT [FK_AdvertismentWorkingLocation_RFDT_WorkingLocation] FOREIGN KEY([WorkingLocationId])
REFERENCES [dbo].[RFDT_WorkingLocation] ([Id])
GO
ALTER TABLE [dbo].[AdvertismentWorkingLocation] CHECK CONSTRAINT [FK_AdvertismentWorkingLocation_RFDT_WorkingLocation]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_User] FOREIGN KEY([UserId1])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_User]
GO
ALTER TABLE [dbo].[Chat]  WITH CHECK ADD  CONSTRAINT [FK_Chat_User1] FOREIGN KEY([UserId2])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Chat] CHECK CONSTRAINT [FK_Chat_User1]
GO
ALTER TABLE [dbo].[ChatMessage]  WITH CHECK ADD  CONSTRAINT [FK_ChatMessage_Chat] FOREIGN KEY([ChatId])
REFERENCES [dbo].[Chat] ([Id])
GO
ALTER TABLE [dbo].[ChatMessage] CHECK CONSTRAINT [FK_ChatMessage_Chat]
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
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_Comment_Post]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[PostMultimedia]  WITH CHECK ADD  CONSTRAINT [FK_PostPhoto_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostMultimedia] CHECK CONSTRAINT [FK_PostPhoto_Post]
GO
ALTER TABLE [dbo].[PostReaction]  WITH CHECK ADD  CONSTRAINT [FK_PostReaction_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([Id])
GO
ALTER TABLE [dbo].[PostReaction] CHECK CONSTRAINT [FK_PostReaction_Post]
GO
ALTER TABLE [dbo].[PostReaction]  WITH CHECK ADD  CONSTRAINT [FK_PostReaction_RFDT_Reaction] FOREIGN KEY([ReactionId])
REFERENCES [dbo].[RFDT_Reaction] ([Id])
GO
ALTER TABLE [dbo].[PostReaction] CHECK CONSTRAINT [FK_PostReaction_RFDT_Reaction]
GO
ALTER TABLE [dbo].[UserCV]  WITH CHECK ADD  CONSTRAINT [FK_CV_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserCV] CHECK CONSTRAINT [FK_CV_User]
GO
ALTER TABLE [dbo].[UserEducation]  WITH CHECK ADD  CONSTRAINT [FK_Education_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserEducation] CHECK CONSTRAINT [FK_Education_User]
GO
ALTER TABLE [dbo].[UserEducation]  WITH CHECK ADD  CONSTRAINT [FK_UserEducation_RFDT_EducationType] FOREIGN KEY([EducationTypeId])
REFERENCES [dbo].[RFDT_EducationType] ([Id])
GO
ALTER TABLE [dbo].[UserEducation] CHECK CONSTRAINT [FK_UserEducation_RFDT_EducationType]
GO
ALTER TABLE [dbo].[UserEducationProfessionalBranch]  WITH CHECK ADD  CONSTRAINT [FK_UserEducationProfessionalBranch_ProfessionalBranch] FOREIGN KEY([ProfessionalBranchId])
REFERENCES [dbo].[RFDT_ProfessionalBranch] ([Id])
GO
ALTER TABLE [dbo].[UserEducationProfessionalBranch] CHECK CONSTRAINT [FK_UserEducationProfessionalBranch_ProfessionalBranch]
GO
ALTER TABLE [dbo].[UserEducationProfessionalBranch]  WITH CHECK ADD  CONSTRAINT [FK_UserEducationProfessionalBranch_UserEducation] FOREIGN KEY([UserEducationId])
REFERENCES [dbo].[UserEducation] ([Id])
GO
ALTER TABLE [dbo].[UserEducationProfessionalBranch] CHECK CONSTRAINT [FK_UserEducationProfessionalBranch_UserEducation]
GO
ALTER TABLE [dbo].[UserExperience]  WITH CHECK ADD  CONSTRAINT [FK_Experience_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserExperience] CHECK CONSTRAINT [FK_Experience_User]
GO
ALTER TABLE [dbo].[UserExperienceJobType]  WITH CHECK ADD  CONSTRAINT [FK_UserExperienceJobType_RFDT_JobType] FOREIGN KEY([JobTypeId])
REFERENCES [dbo].[RFDT_JobType] ([Id])
GO
ALTER TABLE [dbo].[UserExperienceJobType] CHECK CONSTRAINT [FK_UserExperienceJobType_RFDT_JobType]
GO
ALTER TABLE [dbo].[UserExperienceJobType]  WITH CHECK ADD  CONSTRAINT [FK_UserExperienceJobType_UserExperience] FOREIGN KEY([UserExpirienceId])
REFERENCES [dbo].[UserExperience] ([Id])
GO
ALTER TABLE [dbo].[UserExperienceJobType] CHECK CONSTRAINT [FK_UserExperienceJobType_UserExperience]
GO
ALTER TABLE [dbo].[UserExperienceWorkingLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserExperienceWorkingLocation_RFDT_WorkingLocation] FOREIGN KEY([WorkingLocationId])
REFERENCES [dbo].[RFDT_WorkingLocation] ([Id])
GO
ALTER TABLE [dbo].[UserExperienceWorkingLocation] CHECK CONSTRAINT [FK_UserExperienceWorkingLocation_RFDT_WorkingLocation]
GO
ALTER TABLE [dbo].[UserExperienceWorkingLocation]  WITH CHECK ADD  CONSTRAINT [FK_UserExperienceWorkingLocation_UserExperience] FOREIGN KEY([UserExperienceId])
REFERENCES [dbo].[UserExperience] ([Id])
GO
ALTER TABLE [dbo].[UserExperienceWorkingLocation] CHECK CONSTRAINT [FK_UserExperienceWorkingLocation_UserExperience]
GO
ALTER TABLE [dbo].[UserExpirienceProfessionalBranch]  WITH CHECK ADD  CONSTRAINT [FK_UserExpirienceProfessionalBranch_UserExperience] FOREIGN KEY([UserExperienceId])
REFERENCES [dbo].[UserExperience] ([Id])
GO
ALTER TABLE [dbo].[UserExpirienceProfessionalBranch] CHECK CONSTRAINT [FK_UserExpirienceProfessionalBranch_UserExperience]
GO
ALTER TABLE [dbo].[UserPassword]  WITH CHECK ADD  CONSTRAINT [FK_UserPassworld_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPassword] CHECK CONSTRAINT [FK_UserPassworld_User]
GO
ALTER TABLE [dbo].[UserPhotoProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserPhotoProfile_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserPhotoProfile] CHECK CONSTRAINT [FK_UserPhotoProfile_User]
GO
