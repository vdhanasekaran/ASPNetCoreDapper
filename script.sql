USE [Employee]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 6/23/2019 12:59:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [varchar](500) NULL,
	[EmployeeDesignation] [varchar](500) NULL,
	[Contact] [varchar](500) NULL,
	[Address] [varchar](500) NULL,
	[DOJ] [date] NULL,
 CONSTRAINT [PK_GroupMeeting-2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[EmployeeDetails] ON 

INSERT [dbo].[EmployeeDetails] ([Id], [EmployeeName], [EmployeeDesignation], [Contact], [Address], [DOJ]) VALUES (2, N'Abraham', N'Mechanical Engineer', N'8756239012', N'Pollachi', CAST(N'2019-06-23' AS Date))
INSERT [dbo].[EmployeeDetails] ([Id], [EmployeeName], [EmployeeDesignation], [Contact], [Address], [DOJ]) VALUES (3, N'Ferguson', N'Production Engineer', N'7896234165', N'Sulur', CAST(N'2019-06-23' AS Date))
INSERT [dbo].[EmployeeDetails] ([Id], [EmployeeName], [EmployeeDesignation], [Contact], [Address], [DOJ]) VALUES (4, N'Karti', N'Software Engineer', N'97897789', N'Komarapalayam', CAST(N'2018-05-22' AS Date))
SET IDENTITY_INSERT [dbo].[EmployeeDetails] OFF
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 6/23/2019 12:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteEmployee]
(    
    @Id int     
)    
As    
BEGIN    
    DELETE FROM EmployeeDetails WHERE Id=@Id    
END 
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeByID]    Script Date: 6/23/2019 12:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetEmployeeByID](@Id int)    
AS    
BEGIN    
     SELECT * FROM EmployeeDetails where id=@Id    
END 

GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeDetails]    Script Date: 6/23/2019 12:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[GetEmployeeDetails]
AS    
BEGIN    
     SELECT * FROM EmployeeDetails    
END 


GO
/****** Object:  StoredProcedure [dbo].[InsertEmployee]    Script Date: 6/23/2019 12:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertEmployee]
(    
    @EmployeeName varchar(50),    
    @EmployeeDesignation varchar(50),    
    @Contact varchar(50),    
    @Address varchar(50),    
    @DOJ date    
)    
As    
BEGIN    
    
 INSERT INTO EmployeeDetails(EmployeeName,EmployeeDesignation,Contact,Address,DOJ)    
 VALUES(@EmployeeName,@EmployeeDesignation,@Contact,@Address,@DOJ)    
    
END 

GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 6/23/2019 12:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateEmployee]
    (    
        @Id int,    
        @EmployeeName varchar(50),    
        @EmployeeDesignation varchar(50),    
        @Contact varchar(50),    
        @Address varchar(50),    
        @DOJ date    
    )    
    As    
    BEGIN    
         UPDATE EmployeeDetails   
         SET EmployeeName =@EmployeeName,    
         EmployeeDesignation =@EmployeeDesignation,    
         Contact = @Contact,    
         Address = @Address,    
         DOJ =@DOJ    
         Where Id=@Id    
    END    
GO
