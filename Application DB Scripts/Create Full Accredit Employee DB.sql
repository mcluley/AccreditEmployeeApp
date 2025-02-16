USE [master]
GO
/****** Object:  Database [AccreditHRSite]    Script Date: 27/01/2025 13:51:09 ******/
CREATE DATABASE [AccreditHRSite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AccredditHRSite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AccredditHRSite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AccredditHRSite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AccredditHRSite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AccreditHRSite] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AccreditHRSite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AccreditHRSite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AccreditHRSite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AccreditHRSite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AccreditHRSite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AccreditHRSite] SET ARITHABORT OFF 
GO
ALTER DATABASE [AccreditHRSite] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AccreditHRSite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AccreditHRSite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AccreditHRSite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AccreditHRSite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AccreditHRSite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AccreditHRSite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AccreditHRSite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AccreditHRSite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AccreditHRSite] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AccreditHRSite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AccreditHRSite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AccreditHRSite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AccreditHRSite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AccreditHRSite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AccreditHRSite] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AccreditHRSite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AccreditHRSite] SET RECOVERY FULL 
GO
ALTER DATABASE [AccreditHRSite] SET  MULTI_USER 
GO
ALTER DATABASE [AccreditHRSite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AccreditHRSite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AccreditHRSite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AccreditHRSite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AccreditHRSite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AccreditHRSite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AccreditHRSite', N'ON'
GO
ALTER DATABASE [AccreditHRSite] SET QUERY_STORE = OFF
GO
USE [AccreditHRSite]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 27/01/2025 13:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentDescription] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 27/01/2025 13:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNumber] [varchar](10) NOT NULL,
	[Firstname] [nvarchar](30) NOT NULL,
	[Lastname] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[StatusID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeeDetails] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 27/01/2025 13:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [nvarchar](15) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_EmployeeStatus] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departments] ADD  CONSTRAINT [DF_Department_Active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Employees] ADD  CONSTRAINT [DF_Employees_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Statuses] ADD  CONSTRAINT [DF_EmployeeStatus_Active]  DEFAULT ((1)) FOR [IsActive]
GO
USE [master]
GO
ALTER DATABASE [AccreditHRSite] SET  READ_WRITE 
GO
