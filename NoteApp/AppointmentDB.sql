USE [master]
GO
/****** Object:  Database [Appointments]    Script Date: 27.08.2021 14:48:35 ******/
CREATE DATABASE [Appointments]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Appointments', FILENAME = N'C:\Users\terez\Appointments.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Appointments_log', FILENAME = N'C:\Users\terez\Appointments_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Appointments] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Appointments].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Appointments] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Appointments] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Appointments] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Appointments] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Appointments] SET ARITHABORT OFF 
GO
ALTER DATABASE [Appointments] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Appointments] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Appointments] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Appointments] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Appointments] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Appointments] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Appointments] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Appointments] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Appointments] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Appointments] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Appointments] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Appointments] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Appointments] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Appointments] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Appointments] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Appointments] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Appointments] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Appointments] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Appointments] SET  MULTI_USER 
GO
ALTER DATABASE [Appointments] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Appointments] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Appointments] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Appointments] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Appointments] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Appointments] SET QUERY_STORE = OFF
GO
USE [Appointments]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Appointments]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 27.08.2021 14:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ExpiringDate] [date] NOT NULL,
	[Importance] [int] NOT NULL,
	[Done] [bit] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([Id], [Title], [Description], [ExpiringDate], [Importance], [Done]) VALUES (4, N'Power Point', N'Finish presentation for work', CAST(N'2021-08-29' AS Date), 3, 0)
INSERT [dbo].[Appointment] ([Id], [Title], [Description], [ExpiringDate], [Importance], [Done]) VALUES (5, N'Birthday Party', N'Twenty one years', CAST(N'2021-08-31' AS Date), 2, 0)
INSERT [dbo].[Appointment] ([Id], [Title], [Description], [ExpiringDate], [Importance], [Done]) VALUES (6, N'Cena da Alice', N'Con gli amici', CAST(N'2021-08-29' AS Date), 2, 0)
INSERT [dbo].[Appointment] ([Id], [Title], [Description], [ExpiringDate], [Importance], [Done]) VALUES (7, N'Green Day', N'party', CAST(N'2021-09-30' AS Date), 3, 0)
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
USE [master]
GO
ALTER DATABASE [Appointments] SET  READ_WRITE 
GO
