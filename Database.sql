USE [master]
GO
/****** Object:  Database [ConsignmentDemo]    Script Date: 11/28/2020 11:12:03 AM ******/
CREATE DATABASE [ConsignmentDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ConsignmentDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ConsignmentDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ConsignmentDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ConsignmentDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ConsignmentDemo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConsignmentDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConsignmentDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConsignmentDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConsignmentDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ConsignmentDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConsignmentDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET RECOVERY FULL 
GO
ALTER DATABASE [ConsignmentDemo] SET  MULTI_USER 
GO
ALTER DATABASE [ConsignmentDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConsignmentDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ConsignmentDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ConsignmentDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ConsignmentDemo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ConsignmentDemo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ConsignmentDemo', N'ON'
GO
ALTER DATABASE [ConsignmentDemo] SET QUERY_STORE = OFF
GO
USE [ConsignmentDemo]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[Price] [money] NOT NULL,
	[Sold] [bit] NOT NULL,
	[Owner] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDistributed] [bit] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendors]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
	[CommisonRate] [float] NOT NULL,
	[PaymentDue] [money] NOT NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Vendors] FOREIGN KEY([Owner])
REFERENCES [dbo].[Vendors] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Vendors]
GO
/****** Object:  StoredProcedure [dbo].[spItemGetAll]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spItemGetAll]

AS
BEGIN

	SET NOCOUNT ON;

    
	SELECT * from dbo.Items;
END
GO
/****** Object:  StoredProcedure [dbo].[spItemInsert]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spItemInsert]
	@Name nvarchar(200),
	@Description nvarchar(2000),
	@Price money,
	@Sold bit,
	@Owner int,
	@PaymentDistributed bit,
	@Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

    insert into dbo.Items (Name, Description, Price, Sold, Owner, PaymentDistributed)
	values (@Name, @Description, @Price, @Sold, @Owner, @PaymentDistributed);

	select @Id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spVendorGetAll]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVendorGetAll]

AS
BEGIN

	SET NOCOUNT ON;

    
	SELECT * from dbo.Vendors;
END
GO
/****** Object:  StoredProcedure [dbo].[spVendorInsert]    Script Date: 11/28/2020 11:12:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spVendorInsert]
	@FirstName nvarchar(100),
	@LastName nvarchar(150),
	@CommisionRate float,
	@PaymentDue money,
	@Id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

    
	insert into Vendors (FirstName, LastName, CommisonRate, PaymentDue)
	values (@FirstName, @LastName, @CommisionRate, @PaymentDue);

	select @Id = SCOPE_IDENTITY();
END
GO
USE [master]
GO
ALTER DATABASE [ConsignmentDemo] SET  READ_WRITE 
GO
