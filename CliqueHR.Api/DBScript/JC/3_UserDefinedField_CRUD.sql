
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[GetAllUserDefinedField]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[GetAllUserDefinedField]
END
GO
CREATE PROCEDURE [Employee].[GetAllUserDefinedField]
AS
BEGIN
  SELECT
    udf.Id,
    udf.SectionName,
    udf.SectionCode,
    udf.IsEnable,
    udf.FieldName,
    udf.FieldTypeId,
    ft.Name FieldType,
    
    
    CASE
      WHEN mstFT.Id IS NOT NULL THEN CONVERT(varchar(50), mstFT.Id)
      ELSE udf.FieldValueType
    END FieldTypeValue,
	udf.CreatedBy
  FROM [Employee].[UserDefinedField] udf
  INNER JOIN [Employee].[FieldType] ft
    ON udf.FieldTypeId = ft.Id
  LEFT JOIN [Employee].[mstFieldType] mstFT
    ON udf.FieldValueType = CONVERT(varchar(50), mstFT.Id)
    AND ft.Id = mstFT.[FieldTypeId]
	ORDER BY udf.SectionSequence , udf.FieldSequence
END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[GetUserDefinedFieldById]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[GetUserDefinedFieldById]
END
GO
CREATE PROCEDURE [Employee].[GetUserDefinedFieldById] (@Id int)
AS
BEGIN
  SELECT
    udf.Id,
    udf.SectionName,
    udf.SectionCode,
    udf.IsEnable,
    udf.FieldName,
    udf.FieldTypeId,
    ft.Name FieldType,
    udf.FieldValueType
    --,mstFT.Name
    ,
    CASE
      WHEN mstFT.Name IS NOT NULL THEN CONVERT(varchar(50), mstFT.Id)
      ELSE udf.FieldValueType
    END FieldTypeValue
  FROM [Employee].[UserDefinedField] udf
  INNER JOIN [Employee].[FieldType] ft
    ON udf.FieldTypeId = ft.Id
  LEFT JOIN [Employee].[mstFieldType] mstFT
    ON udf.FieldValueType = CONVERT(varchar(50), mstFT.Id)
    AND ft.Id = mstFT.[FieldTypeId]
  WHERE udf.Id = @Id
END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[AddUserDefinedField]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[AddUserDefinedField]
END
GO
CREATE PROCEDURE [Employee].[AddUserDefinedField] (@SectionName varchar(250)
, @SectionCode varchar(150)
, @IsEnable bit
, @FieldName varchar(500)
, @FieldTypeId int
, @FieldValueType varchar(2000)
, @IsActive bit
, @CreatedBy int)
AS
BEGIN

  DECLARE @Id int
  INSERT INTO [Employee].[UserDefinedField] (SectionName, SectionCode, IsEnable, FieldName, FieldTypeId, FieldValueType, CreatedBy, CreatedDate, IsActive)
    VALUES (@SectionName, @SectionCode, @IsEnable, @FieldName, @FieldTypeId, @FieldValueType, @CreatedBy, GETDATE(), @IsActive)

 
END
GO
IF EXISTS (SELECT
    1
  FROM sysobjects
  WHERE id = OBJECT_ID(N'[Employee].[EditUserDefinedField]')
  AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
  DROP PROCEDURE [Employee].[EditUserDefinedField]
END
GO
CREATE PROCEDURE [Employee].[EditUserDefinedField] 
@userprofilexml XML 
AS
BEGIN


  INSERT INTO [Employee].[UserDefinedField_Audit] (UserDefinedId, SectionName, SectionCode, IsEnable, FieldName, FieldTypeId, FieldValueType, CreatedBy, CreatedDate, IsActive)
   SELECT  udf.Id,udf.SectionName,
        udf.SectionCode,
        udf.IsEnable,
		udf.FieldName,
		udf.FieldTypeId,
		udf.FieldValueType,
		fields.value('CreatedBy[1]', 'BIGINT'),
		GETDATE(),
	    1
		FROM @userprofilexml.nodes('/ArrayOfUserDefinedField/UserDefinedField') AS xmldata(fields)
		INNER JOIN [Employee].[UserDefinedField] udf  ON fields.value('Id[1]', 'INT') = udf.Id
		WHERE fields.value('SectionName[1]', 'varchar(500)')!=udf.SectionName
		OR fields.value('SectionCode[1]', 'varchar(250)')!=udf.SectionCode
		OR fields.value('FieldName[1]', 'varchar(500)')!=udf.FieldName
		OR fields.value('FieldTypeId[1]', 'INT')!=udf.FieldTypeId
		OR fields.value('FieldTypeValue[1]', 'VARCHAR(250)')!=udf.FieldValueType
		OR fields.value('IsEnable[1]', 'BIT')!=udf.IsEnable

  
  UPDATE udf 
SET udf.SectionName = fields.value('SectionName[1]', 'varchar(500)'),
udf.SectionCode = fields.value('SectionCode[1]', 'varchar(250)'),
udf.IsEnable = fields.value('IsEnable[1]', 'BIT'),
udf.FieldName = fields.value('FieldName[1]', 'varchar(500)'),
udf.FieldTypeId = fields.value('FieldTypeId[1]', 'INT'),
udf.FieldValueType = fields.value('FieldTypeValue[1]', 'VARCHAR(250)'),
udf.ModifiedDate = GETDATE(),
udf.ModifiedBy = fields.value('CreatedBy[1]', 'BIGINT')
FROM
 [Employee].[UserDefinedField] udf INNER JOIN @userprofilexml.nodes('/ArrayOfUserDefinedField/UserDefinedField') AS xmldata(fields)
 ON fields.value('Id[1]', 'INT') = udf.Id

  SELECT 1 as Code,'Global Profile Updated successfully' AS Message

  
END
GO