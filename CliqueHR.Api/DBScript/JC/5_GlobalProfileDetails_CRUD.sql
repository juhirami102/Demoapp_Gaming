
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[GetAllGlobalProfileDetails]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[GetAllGlobalProfileDetails]
END
GO
CREATE PROCEDURE [Employee].[GetAllGlobalProfileDetails]
AS
BEGIN
  SELECT
    Id,
    ISNULL(DisplayName, '') SectionName,
    ISNULL(Code, '') SectionCode,
    ISNULL(IsEnable, 0) IsEnable,
    CreatedBy,
    CreatedDate,
    ISNULL(IsActive, 0) IsActive
  FROM [Employee].[GlobalProfileDetails]
  ORDER BY [Sequence] ASC

END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[GetGlobalProfileDetailsById]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[GetGlobalProfileDetailsById]
END
GO
CREATE PROCEDURE [Employee].[GetGlobalProfileDetailsById] (@Id int)
AS
BEGIN
  SELECT
    Id,
    ISNULL(DisplayName, '') SectionName,
    ISNULL(Code, '') SectionCode,
    ISNULL(IsEnable, 0) IsEnable,
    CreatedBy,
    CreatedDate,
    ISNULL(IsActive, 0) IsActive
  FROM [Employee].[GlobalProfileDetails]
  WHERE Id = @Id
END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[AddGlobalProfileDetails]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[AddGlobalProfileDetails]
END
GO
CREATE PROCEDURE [Employee].[AddGlobalProfileDetails] (@DisplayName varchar(500)
, @Code varchar(100)
, @IsEnable bit
, @IsActive bit
, @CreatedBy int)
AS
BEGIN

  DECLARE @Id int
  INSERT INTO [Employee].[GlobalProfileDetails] (DisplayName, Code, IsEnable, CreatedBy, CreatedDate, IsActive)
    VALUES (@DisplayName, @Code, @IsEnable, @CreatedBy, GETDATE(), @IsActive)

 
END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[EditGlobalProfileDetails]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[EditGlobalProfileDetails]
END
GO
CREATE PROCEDURE [Employee].[EditGlobalProfileDetails] 
@globalprofilexml XML 
AS
BEGIN

INSERT INTO [Employee].[GlobalProfileDetails_Audit] (GlobalProfileId, DisplayName, Code, IsEnable, CreatedBy, CreatedDate, IsActive)
SELECT  gpd.Id,gpd.DisplayName,
        gpd.Code,
        gpd.IsEnable,
		fields.value('CreatedBy[1]', 'BIGINT'),
		GETDATE(),
	    1
		FROM @globalprofilexml.nodes('/ArrayOfGlobalProfileModel/GlobalProfileModel') AS xmldata(fields)
		INNER JOIN [Employee].GlobalProfileDetails gpd  ON fields.value('Id[1]', 'INT') = gpd.Id
		WHERE fields.value('SectionName[1]', 'varchar(500)')!=gpd.DisplayName
		 OR fields.value('SectionCode[1]', 'varchar(250)')!=gpd.Code
		  OR fields.value('IsEnable[1]', 'BIT')!=gpd.IsEnable

UPDATE gpd 
SET gpd.DisplayName = fields.value('SectionName[1]', 'varchar(500)'),
gpd.Code = fields.value('SectionCode[1]', 'varchar(250)'),
gpd.IsEnable = fields.value('IsEnable[1]', 'BIT'),
gpd.ModifiedDate = GETDATE(),
gpd.ModifiedBy = fields.value('CreatedBy[1]', 'BIGINT')
FROM
 [Employee].GlobalProfileDetails gpd INNER JOIN @globalprofilexml.nodes('/ArrayOfGlobalProfileModel/GlobalProfileModel') AS xmldata(fields)
 ON fields.value('Id[1]', 'INT') = gpd.Id

  SELECT 1 as Code,'Global Profile Updated successfully' AS Message
END
GO