
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Employee].[GlobalProfileDetails]') AND type in (N'U'))
BEGIN
	Create Table [Employee].[GlobalProfileDetails]
	(
	  Id INT IDENTITY(1,1) PRIMARY KEY
	 ,DisplayName VARCHAR(500) NOT NULL
	 ,Code VARCHAR(100)
	 ,IsEnable BIT NOT NULL
	 ,[Sequence] INT
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,ModifiedDate DATETIME
	 ,ModifiedBy BIGINT
	 ,IsActive BIT Default 0
	)
END
Go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Employee].[GlobalProfileDetails_Audit]') AND type in (N'U'))
BEGIN
	Create Table [Employee].[GlobalProfileDetails_Audit]
	(
	  Id BIGINT IDENTITY(1,1) PRIMARY KEY
	 ,GlobalProfileId INT 
	 ,DisplayName VARCHAR(500) NOT NULL
	 ,Code VARCHAR(100)
	 ,IsEnable BIT NOT NULL
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	 CONSTRAINT Fk_GlobalProfileDetails_Audit FOREIGN KEY (GlobalProfileId) REFERENCES [Employee].[GlobalProfileDetails](Id) 
	)
END
Go