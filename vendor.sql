USE [ConsignmentDemo]
GO

/****** Object:  Table [dbo].[Vendors]    Script Date: 11/28/2020 12:31:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NOT NULL,
	[LastName] [nchar](150) NULL,
	[CommisonRate] [float] NULL,
	[PaymentDue] [money] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


