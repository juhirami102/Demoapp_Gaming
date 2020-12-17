-- Create Schema Common
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CenterType]') AND type in (N'U'))
BEGIN
	Create Table [Common].[Master_CenterType]
	(
	  Id INT IDENTITY(1,1) PRIMARY KEY
	 ,CenterTypeName NVARCHAR(50) NOT NULL
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	)
END
Go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CenterType_Audit]') AND type in (N'U'))
BEGIN
	Create Table [Common].[Master_CenterType_Audit]
	(
	  RefId INT 
	 ,CenterTypeName NVARCHAR(50) NOT NULL
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_Currency]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_Currency]
(
   Id INT PRIMARY KEY IDENTITY (1,1)
  ,CurrencyCode NVARCHAR(5)
  ,CurrencyDesc NVARCHAR(30)
  ,CreatedBy INT 
  ,CreatedDate DATETIME
  ,IsActive BIT DEFAULT 0
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[CurrencyMapping]') AND type in (N'U'))
BEGIN
Create Table [Common].[CurrencyMapping]
(
   Id INT PRIMARY KEY IDENTITY (1,1)
  ,CurrencyId INT
  ,IsDefualt BIT DEFAULT 0
  ,CreatedBy INT 
  ,CreatedDate DATETIME
  ,IsActive BIT DEFAULT 0
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[CurrencyMapping_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[CurrencyMapping_Audit]
(
   RefId INT
  ,CurrencyId INT
  ,IsDefualt BIT DEFAULT 0
  ,CreatedBy INT 
  ,CreatedDate DATETIME
  ,IsActive BIT DEFAULT 0
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_FunctionalRole]') AND type in (N'U'))
BEGIN
	Create Table [Common].[Master_FunctionalRole]
	(
	  Id INT IDENTITY(1,1) PRIMARY KEY
	 ,FRoleName NVARCHAR(50) NOT NULL
	 ,FRoleCode NVARCHAR(20) NOT NULL
	 ,FRoleDesc NVARCHAR(200) NOT NULL
	 ,AttachmentFile NVARCHAR(20)  
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	)
END
Go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_FunctionalRole_Audit]') AND type in (N'U'))
BEGIN
	Create Table [Common].[Master_FunctionalRole_Audit]
	(
	  RefId INT IDENTITY(1,1) PRIMARY KEY
	 ,FRoleName NVARCHAR(50) NOT NULL
	 ,FRoleCode NVARCHAR(20) NOT NULL
	 ,FRoleDesc NVARCHAR(200) NOT NULL
	 ,AttachmentFile NVARCHAR(20)  
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	)
END
Go

------------------------------------------------------BandType----------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_BandType]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Common].[Master_BandType]
	(
		 Id INT IDENTITY(1,1) PRIMARY KEY
		 ,TypeName NVARCHAR(100) NOT NULL
		 ,GradesMapping NVARCHAR(200)
		 ,CreatedBy INT NOT NULL
		 ,CreatedDate DATETIME 
		 ,IsActive BIT Default 0
	)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_BandType_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Common].[Master_BandType_Audit]
(
	 RefId INT 
	  ,TypeName NVARCHAR(100) NOT NULL
	 ,GradesMapping NVARCHAR(200)
	 ,UpdatedBy INT NOT NULL
	 ,UpdatedDate DATETIME
	 ,IsActive BIT
)
END
GO

-------------------------------------EmployeeType------------------------
--Create Schema Common
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_EmployeeType]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Common].[Master_EmployeeType]
	(
		 Id INT IDENTITY(1,1) PRIMARY KEY
		 ,TypeName NVARCHAR(100) NOT NULL
		 ,SelfService BIT DEFAULT 0 
		 ,MinAge INT 
		 ,CreatedBy INT NOT NULL
		 ,CreatedDate DATETIME 
		 ,IsActive BIT Default 0
	)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_EmployeeType_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Common].[Master_EmployeeType_Audit]
(
	 RefId INT 
	 ,TypeName NVARCHAR(100) NOT NULL
	 ,SelfService BIT DEFAULT 0 
	 ,MinAge INT 
	 ,UpdatedBy INT NOT NULL
	 ,UpdatedDate DATETIME
	 ,IsActive BIT
)
END
GO
-----------------------------------GradeType-----------------------


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_GradeType]') AND type in (N'U'))
BEGIN
	CREATE TABLE [Common].[Master_GradeType]
	(
		 Id INT IDENTITY(1,1) PRIMARY KEY
		 ,TypeName NVARCHAR(100) NOT NULL
		 ,MinSalary DECIMAL(10,2)
		 ,MaxSalary DECIMAL(10,2)
		 ,CreatedBy INT NOT NULL
		 ,CreatedDate DATETIME 
		 ,IsActive BIT Default 0
	)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_GradeType_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Common].[Master_GradeType_Audit]
(
	 RefId INT 
	 ,TypeName NVARCHAR(100) NOT NULL
	 ,MinSalary DECIMAL(10,2)
	 ,MaxSalary DECIMAL(10,2)
	 ,UpdatedBy INT NOT NULL
	 ,UpdatedDate DATETIME
	 ,IsActive BIT
)
END
GO

-------------------------------------  Qualification Type ------------------------------------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CourseType]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_CourseType]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,TypeName NVARCHAR(50) NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CourseType_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_CourseType_Audit]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,RefId INT NOT NULL
  ,TypeName NVARCHAR(50) NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CourseTitle]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_CourseTitle]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,TitleName NVARCHAR(50) NOT NULL
  ,CourseTypeId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_CourseTitle_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_CourseTitle_Audit]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,RefId INT NOT NULL
  ,TitleName NVARCHAR(50) NOT NULL
  ,CourseTypeId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_Major]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_Major]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,MajorName NVARCHAR(50) NOT NULL
  ,TitleId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_Major_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_Major_Audit]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,RefId INT NOT NULL
  ,MajorName NVARCHAR(50) NOT NULL
  ,TitleId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_University]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_University]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,UniversityName NVARCHAR(30) NOT NULL
  ,CountryId INT NOT NULL
  ,StateId INT NOT NULL
  ,CityId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
  ,IsBlacklist BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_University_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_University_Audit]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,RefId INT NOT NULL
  ,UniversityName NVARCHAR(30) NOT NULL
  ,CountryId INT NOT NULL
  ,StateId INT NOT NULL
  ,CityId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
  ,IsBlacklist BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_Institute]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_Institute]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,InstituteName NVARCHAR(30) NOT NULL
  ,UniversityId INT NOT NULL
  ,CountryId INT NOT NULL
  ,StateId INT NOT NULL
  ,CityId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
  ,IsBlacklist BIT Default 0
)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Common].[Master_Institute_Audit]') AND type in (N'U'))
BEGIN
Create Table [Common].[Master_Institute_Audit]
(
   Id INT IDENTITY(1,1) PRIMARY KEY
  ,RefId INT NOT NULL
  ,InstituteName NVARCHAR(30) NOT NULL
  ,UniversityId INT NOT NULL
  ,CountryId INT NOT NULL
  ,StateId INT NOT NULL
  ,CityId INT NOT NULL
  ,CreatedBy INT NOT NULL
  ,CreatedDate DATETIME
  ,IsActive BIT Default 0
  ,IsBlacklist BIT Default 0
)
END
-----------------------------------------------------------------------------------------------------------------------------------------

/* --------------------- Admin Panel : Company --------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[SecuritySettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[SecuritySettings](
	[PasswordExpiryIndays] [int] NULL,
	[SessionTimeOutInMins] [int] NULL,
	[HideMobileNumberFromEd] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[SecuritySettings_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[SecuritySettings_Audit](
	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[PasswordExpiryIndays] [int] NULL,
	[SessionTimeOutInMins] [int] NULL,
	[HideMobileNumberFromEd] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[PageSettings]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[PageSettings](
	[LoginPageBackGroundImgOne] [varchar](100) NULL,
	[LoginPageBackGroundImgTwo] [varchar](100) NULL,
	[LoginPageBackGroundImgThree] [varchar](100) NULL,
	[DashboardPageBackGroundImgOne] [varchar](100) NULL,
	[DashboardPageBackGroundImgTwo] [varchar](100) NULL,
	[DashboardPageBackGroundImgThree] [varchar](100) NULL,
	[DashboardPageBackGroundImgFour] [varchar](100) NULL,
	[DashboardPageBackGroundImgFive] [varchar](100) NULL,
	[SlideShoutContent] [int] NULL,
	[IsBirthdayVisible] [bit] NULL,
	[IsWorkAnniversaryVisible] [bit] NULL,
	[IsMarriageAnniversaryVisible] [bit] NULL,
	[IsExitVisible] [bit] NULL,
	[IsNewJoineeVisible] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[PageSettings_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[PageSettings_Audit](
	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[LoginPageBackGroundImgOne] [varchar](100) NULL,
	[LoginPageBackGroundImgTwo] [varchar](100) NULL,
	[LoginPageBackGroundImgThree] [varchar](100) NULL,
	[DashboardPageBackGroundImgOne] [varchar](100) NULL,
	[DashboardPageBackGroundImgTwo] [varchar](100) NULL,
	[DashboardPageBackGroundImgThree] [varchar](100) NULL,
	[DashboardPageBackGroundImgFour] [varchar](100) NULL,
	[DashboardPageBackGroundImgFive] [varchar](100) NULL,
	[SlideShoutContent] [int] NULL,
	[IsBirthdayVisible] [bit] NULL,
	[IsWorkAnniversaryVisible] [bit] NULL,
	[IsMarriageAnniversaryVisible] [bit] NULL,
	[IsExitVisible] [bit] NULL,
	[IsNewJoineeVisible] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[GroupCompany]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[GroupCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](10) NULL,
	[TypeId] [int] NOT NULL,
	[IncorporationDate] [datetime] NULL,
	[Address] [varchar](250) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [bigint] NULL,
	[PinCode] [int] NULL,
	[ContcatNo] [varchar](50) NULL,
	[WebSite] [varchar](30) NULL,
	[PAN] [varchar](50) NULL,
	[TAN] [varchar](50) NULL,
	[GSTIN] [varchar](100) NULL,
	[PF] [nvarchar](100) NULL,
	[ESIC] [nvarchar](100) NULL,
	[Logo] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[GroupCompany_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[GroupCompany_Audit](
	[AuditId] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](10) NULL,
	[TypeId] [int] NOT NULL,
	[IncorporationDate] [datetime] NULL,
	[Address] [varchar](250) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [bigint] NULL,
	[PinCode] [int] NULL,
	[ContcatNo] [varchar](50) NULL,
	[WebSite] [varchar](100) NULL,
	[PAN] [varchar](50) NULL,
	[TAN] [varchar](50) NULL,
	[GSTIN] [varchar](100) NULL,
	[PF] [nvarchar](100) NULL,
	[ESIC] [nvarchar](100) NULL,
	[Logo] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[Entity]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[Entity](
	[Id] [int] IDENTITY NOT NULL,
	[Name] [Varchar](50) NOT NULL, 
	[Code] [varchar](50) NULL,
	[TypeId] [int] NOT NULL,
	[IncorporationDate] DATETIME NULL,
	[Address] [varchar](250) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [bigint] NULL,
	[PinCode] [int] NULL,
	[ContcatNo] [varchar](50) NULL,
	[WebSite] [Varchar](100) NULL,
	[PAN][varchar](50)NULL,
	[TAN][varchar](50)NULL,
	[GSTIN][varchar](100)NULL,
	[PF][varchar](100)NULL,
	[ESIC][varchar](100)NULL,
	[Logo][varchar](100) NULL,
	[IsActive] BIT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint],
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint],
) ON [PRIMARY]
ALTER TABLE [Company].[Entity] ADD  DEFAULT (GETDATE()) FOR [CreatedOn]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Company].[Entity_Audit]') AND type in (N'U'))
BEGIN
CREATE TABLE [Company].[Entity_Audit](
	[AuditId] bigint IDENTITY NOT NULL,
	[Id] [int] NOT NULL,
	[Name] [Varchar](50) NOT NULL, 
	[Code] [varchar](50) NULL,
	[TypeId] [int] NOT NULL,
	[IncorporationDate] DATETIME NULL,
	[Address] [varchar](250) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[CityId] [bigint] NULL,
	[PinCode] [int] NULL,
	[ContcatNo] [varchar](50) NULL,
	[WebSite] [Varchar](100) NULL,
	[PAN][varchar](50)NULL,
	[TAN][varchar](50)NULL,
	[GSTIN][varchar](100)NULL,
	[PF][varchar](100)NULL,
	[ESIC][varchar](100)NULL,
	[Logo][varchar](100) NULL,
	[IsActive] BIT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint]
) ON [PRIMARY]
ALTER TABLE [Company].[Entity_Audit] ADD  DEFAULT (GETDATE()) FOR [CreatedOn]
END
GO