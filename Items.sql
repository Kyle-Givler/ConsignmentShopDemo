USE [ConsignmentDemo]
GO

/****** Object:  Table [dbo].[Items]    Script Date: 11/28/2020 12:31:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items](
	[Name] [nchar](200) NOT NULL,
	[Description] [nchar](2000) NOT NULL,
	[Price] [money] NOT NULL,
	[Sold] [bit] NOT NULL,
	[Owner] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDistributed] [bit] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Vendors] FOREIGN KEY([Owner])
REFERENCES [dbo].[Vendors] ([id])
GO

ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Vendors]
GO


