USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'DesigningTestableApplications')
    DROP DATABASE DesigningTestableApplications
	  
/****** Object:  Database [DesigningTestableApplications]    Script Date: 16/06/2015 10:53:19 a.m. ******/
CREATE DATABASE [DesigningTestableApplications]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DesigningTestableApplications', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\DesigningTestableApplications.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DesigningTestableApplications_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQL2012\MSSQL\DATA\DesigningTestableApplications_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [DesigningTestableApplications] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DesigningTestableApplications].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DesigningTestableApplications] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET ARITHABORT OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [DesigningTestableApplications] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DesigningTestableApplications] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DesigningTestableApplications] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DesigningTestableApplications] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DesigningTestableApplications] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET RECOVERY FULL 
GO

ALTER DATABASE [DesigningTestableApplications] SET  MULTI_USER 
GO

ALTER DATABASE [DesigningTestableApplications] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DesigningTestableApplications] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DesigningTestableApplications] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DesigningTestableApplications] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [DesigningTestableApplications] SET  READ_WRITE 
GO