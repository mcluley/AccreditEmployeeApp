USE [AccreditHRSite]
GO

/****** Object:  Table [dbo].[Statuses]    Script Date: 27/01/2025 13:55:52 ******/
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

ALTER TABLE [dbo].[Statuses] ADD  CONSTRAINT [DF_EmployeeStatus_Active]  DEFAULT ((1)) FOR [IsActive]
GO


