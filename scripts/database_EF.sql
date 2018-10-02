USE [master]
GO

/****** Object:  Database [RoomSecurityEntity]    Script Date: 02.10.2018 17:47:27 ******/
CREATE DATABASE [RoomSecurityEntity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoomSecurityEntity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RoomSecurityEntity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoomSecurityEntity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RoomSecurityEntity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [RoomSecurityEntity] SET COMPATIBILITY_LEVEL = 140
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoomSecurityEntity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [RoomSecurityEntity] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET ARITHABORT OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [RoomSecurityEntity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [RoomSecurityEntity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET  DISABLE_BROKER 
GO

ALTER DATABASE [RoomSecurityEntity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [RoomSecurityEntity] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [RoomSecurityEntity] SET  MULTI_USER 
GO

ALTER DATABASE [RoomSecurityEntity] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [RoomSecurityEntity] SET DB_CHAINING OFF 
GO

ALTER DATABASE [RoomSecurityEntity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [RoomSecurityEntity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [RoomSecurityEntity] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [RoomSecurityEntity] SET QUERY_STORE = OFF
GO

USE [RoomSecurityEntity]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [RoomSecurityEntity] SET  READ_WRITE 
GO
