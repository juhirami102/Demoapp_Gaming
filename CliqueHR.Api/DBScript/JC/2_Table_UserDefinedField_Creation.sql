
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Employee].[FieldType]') AND type in (N'U'))
BEGIN
	Create Table [Employee].[FieldType]
	(
	  Id INT IDENTITY(1,1) PRIMARY KEY
	 ,Name VARCHAR(250) NOT NULL
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	)
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Employee].[UserDefinedField]') AND type in (N'U'))
BEGIN
	Create Table [Employee].[UserDefinedField]
	(
	  Id INT IDENTITY(1,1) PRIMARY KEY
	 ,SectionName VARCHAR(250) NOT NULL
	 ,SectionCode VARCHAR(150) NOT NULL
	 ,IsEnable BIT NOT NULL
	 ,FieldName VARCHAR(500)
	 ,FieldTypeId  INT FOREIGN KEY REFERENCES [Employee].[FieldType](Id)
	 ,FieldValueType VARCHAR(2000)
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0
	 ,SectionSequence INT 
	 ,FieldSequence INT
	 ,ModifiedDate DATETIME
	 ,ModifiedBy BIGINT
	 CONSTRAINT Fk_FieldType_UserDefinedField FOREIGN KEY (FieldTypeId) REFERENCES [Employee].[FieldType](Id) 
	)
END
Go
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Employee].[UserDefinedField_Audit]') AND type in (N'U'))
BEGIN
	Create Table [Employee].[UserDefinedField_Audit]
	(
	  Id BIGINT IDENTITY(1,1) PRIMARY KEY
	 ,UserDefinedId INT 
	 ,SectionName VARCHAR(250) NOT NULL
	 ,SectionCode VARCHAR(150) NOT NULL
	 ,IsEnable BIT NOT NULL
	 ,FieldName VARCHAR(500)
	 ,FieldTypeId  INT
	 ,FieldValueType VARCHAR(2000)
	 ,CreatedBy INT NOT NULL
	 ,CreatedDate DATETIME 
	 ,IsActive BIT Default 0,
	 CONSTRAINT Fk_UserDefinedField_Audit FOREIGN KEY (UserDefinedId) REFERENCES [Employee].[UserDefinedField](Id) 
	)
END
Go

