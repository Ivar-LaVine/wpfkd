USE [master]
GO
/****** Object:  Database [dental_db]    Script Date: 6/15/2021 8:20:26 AM ******/
CREATE DATABASE [dental_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dental_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dental_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dental_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\dental_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dental_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dental_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dental_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dental_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dental_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dental_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dental_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [dental_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dental_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dental_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dental_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dental_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dental_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dental_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dental_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dental_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dental_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dental_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dental_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dental_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dental_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dental_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dental_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dental_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dental_db] SET RECOVERY FULL 
GO
ALTER DATABASE [dental_db] SET  MULTI_USER 
GO
ALTER DATABASE [dental_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dental_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dental_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dental_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dental_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dental_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dental_db', N'ON'
GO
ALTER DATABASE [dental_db] SET QUERY_STORE = OFF
GO
USE [dental_db]
GO
/****** Object:  Table [dbo].[day]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[day](
	[day_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_day] PRIMARY KEY CLUSTERED 
(
	[day_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[doctor]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctor](
	[doc_id] [int] IDENTITY(1,1) NOT NULL,
	[surname] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[patronymic] [nvarchar](50) NULL,
	[dob] [date] NULL,
	[phone] [nvarchar](20) NULL,
	[mail] [nvarchar](50) NULL,
	[reg_date] [date] NULL,
	[description] [ntext] NULL,
	[pos_id] [int] NULL,
	[photo] [ntext] NULL,
 CONSTRAINT [PK_doctor] PRIMARY KEY CLUSTERED 
(
	[doc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_doctor_mail] UNIQUE NONCLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_doctor_phone] UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[ord_id] [int] IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NULL,
	[pat_id] [int] NULL,
	[date] [date] NULL,
	[time] [time](7) NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[ord_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patient]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patient](
	[pat_id] [int] IDENTITY(1,1) NOT NULL,
	[surname] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[patronymic] [nvarchar](50) NULL,
	[dob] [date] NULL,
	[snills] [nvarchar](20) NULL,
	[oms] [nvarchar](20) NULL,
	[passport] [nvarchar](20) NULL,
	[description] [ntext] NULL,
	[photo] [ntext] NULL,
 CONSTRAINT [PK_patient] PRIMARY KEY CLUSTERED 
(
	[pat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_patient_oms] UNIQUE NONCLUSTERED 
(
	[oms] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_patient_passport] UNIQUE NONCLUSTERED 
(
	[passport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_patient_snills] UNIQUE NONCLUSTERED 
(
	[snills] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[position]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[pos_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[pos_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_position_title] UNIQUE NONCLUSTERED 
(
	[title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[separator]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[separator](
	[sep_id] [int] IDENTITY(1,1) NOT NULL,
	[ser_id] [int] NULL,
	[ord_id] [int] NULL,
 CONSTRAINT [PK_separator] PRIMARY KEY CLUSTERED 
(
	[sep_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[ser_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NULL,
	[price] [money] NULL,
	[description] [ntext] NULL,
	[time] [time](7) NULL,
	[pos_id] [int] NULL,
 CONSTRAINT [PK_service] PRIMARY KEY CLUSTERED 
(
	[ser_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[talon]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[talon](
	[tal_id] [int] IDENTITY(1,1) NOT NULL,
	[pat_id] [int] NULL,
	[ser_id] [int] NULL,
	[tal_date] [date] NULL,
	[tal_time] [time](7) NULL,
	[doc_id] [int] NULL,
 CONSTRAINT [PK_Talon] PRIMARY KEY CLUSTERED 
(
	[tal_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timetable]    Script Date: 6/15/2021 8:20:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timetable](
	[tim_id] [int] IDENTITY(1,1) NOT NULL,
	[day_id] [int] NULL,
	[doc_id] [int] NULL,
	[beg_time] [time](7) NULL,
	[end_time] [time](7) NULL,
 CONSTRAINT [PK_timetable] PRIMARY KEY CLUSTERED 
(
	[tim_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[doctor]  WITH CHECK ADD  CONSTRAINT [FK_doctor_position] FOREIGN KEY([pos_id])
REFERENCES [dbo].[position] ([pos_id])
GO
ALTER TABLE [dbo].[doctor] CHECK CONSTRAINT [FK_doctor_position]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_doctor] FOREIGN KEY([doc_id])
REFERENCES [dbo].[doctor] ([doc_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_doctor]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_patient] FOREIGN KEY([pat_id])
REFERENCES [dbo].[patient] ([pat_id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_patient]
GO
ALTER TABLE [dbo].[separator]  WITH CHECK ADD  CONSTRAINT [FK_separator_order] FOREIGN KEY([ord_id])
REFERENCES [dbo].[order] ([ord_id])
GO
ALTER TABLE [dbo].[separator] CHECK CONSTRAINT [FK_separator_order]
GO
ALTER TABLE [dbo].[separator]  WITH CHECK ADD  CONSTRAINT [FK_separator_service] FOREIGN KEY([ser_id])
REFERENCES [dbo].[service] ([ser_id])
GO
ALTER TABLE [dbo].[separator] CHECK CONSTRAINT [FK_separator_service]
GO
ALTER TABLE [dbo].[service]  WITH CHECK ADD  CONSTRAINT [FK_service_position] FOREIGN KEY([pos_id])
REFERENCES [dbo].[position] ([pos_id])
GO
ALTER TABLE [dbo].[service] CHECK CONSTRAINT [FK_service_position]
GO
ALTER TABLE [dbo].[timetable]  WITH CHECK ADD  CONSTRAINT [FK_timetable_day] FOREIGN KEY([day_id])
REFERENCES [dbo].[day] ([day_id])
GO
ALTER TABLE [dbo].[timetable] CHECK CONSTRAINT [FK_timetable_day]
GO
ALTER TABLE [dbo].[timetable]  WITH CHECK ADD  CONSTRAINT [FK_timetable_doctor] FOREIGN KEY([doc_id])
REFERENCES [dbo].[doctor] ([doc_id])
GO
ALTER TABLE [dbo].[timetable] CHECK CONSTRAINT [FK_timetable_doctor]
GO
USE [master]
GO
ALTER DATABASE [dental_db] SET  READ_WRITE 
GO
