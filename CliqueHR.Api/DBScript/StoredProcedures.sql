----------------------------------------------------------------- Center Type ------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllCenterType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllCenterType]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllCenterType] 	
AS
BEGIN
	SELECT Id
          ,CenterTypeName
          ,CreatedBy
          ,CreatedDate
          ,IsActive 
	FROM  [Common].[Master_CenterType]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetCenterTypeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetCenterTypeById]
END
GO
CREATE PROCEDURE [Common].[Master_GetCenterTypeById] 
(
  @Id INT
)
AS
BEGIN
	SELECT Id
          ,CenterTypeName
          ,CreatedBy
          ,CreatedDate
          ,IsActive 
	FROM  [Common].[Master_CenterType]
	WHERE Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddCenterType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddCenterType]
END
Go
CREATE PROCEDURE [Common].[Master_AddCenterType] 
(
  @CenterTypeName NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN

   DECLARE @Id INT 
   INSERT INTO [Common].[Master_CenterType] (CenterTypeName,CreatedBy,CreatedDate,IsActive)
   VALUES (@CenterTypeName,@CreatedBy,GETDATE(),@IsActive)

   --SET @Id = SCOPE_IDENTITY();
   
   --INSERT INTO [Common].[Master_CenterType_Audit] (RefId,CenterTypeName,CreatedBy,CreatedDate,IsActive)
   --VALUES (@Id,@CenterTypeName,@CreatedBy,GETDATE(),@IsActive)
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditCenterType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditCenterType]
END
GO
CREATE PROCEDURE [Common].[Master_EditCenterType] 
(
  @Id INT
 ,@CenterTypeName NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   
    INSERT INTO [Common].[Master_CenterType_Audit] (RefId,CenterTypeName,CreatedBy,CreatedDate,IsActive)
    SELECT Id ,CenterTypeName,CreatedBy,CreatedDate,IsActive FROM [Common].[Master_CenterType] WHERE Id=@Id;
   
   UPDATE [Common].[Master_CenterType]
   SET    CenterTypeName = @CenterTypeName 
         ,CreatedBy = @CreatedBy 
		 ,CreatedDate = GETDATE() 
		 ,IsActive = @IsActive
   WHERE Id =@Id
   
  
END
GO

--------------------------------------------------------------------  Currency -----------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllCurrency]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllCurrency]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllCurrency] 	
AS
BEGIN
	SELECT Id
          ,CurrencyCode
		  ,CurrencyDesc
          ,CreatedBy
          ,CreatedDate
          ,IsActive 
	FROM  [Common].[Master_Currency]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[GetAllCurrencyMapping]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[GetAllCurrencyMapping] 
END
GO
CREATE PROCEDURE [Common].[GetAllCurrencyMapping] 	
AS
BEGIN
	SELECT A.Id
          ,A.CurrencyId
		  ,B.CurrencyCode
		  ,A.IsDefualt
          ,A.CreatedBy
          ,A.CreatedDate
          ,A.IsActive 
	FROM  [Common].[CurrencyMapping] A
	INNER JOIN [Common].[Master_Currency] B ON A.CurrencyId = B.Id

END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[GetCurrencyById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[GetCurrencyById]
END
GO
CREATE PROCEDURE [Common].[GetCurrencyById]
(
  @Id INT
)
AS
BEGIN
	SELECT A.Id
          ,A.CurrencyId
		  ,B.CurrencyCode
		  ,A.IsDefualt
          ,A.CreatedDate
          ,A.IsActive 
	FROM  [Common].[CurrencyMapping] A
	INNER JOIN [Common].[Master_Currency] B ON A.CurrencyId = B.Id
	WHERE A.Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[AddCurrencyMapping]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[AddCurrencyMapping]
END
Go
CREATE PROCEDURE [Common].[AddCurrencyMapping] 
(
  @CurrencyId INT
 ,@IsDefault BIT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN

   INSERT INTO [Common].[CurrencyMapping] (CurrencyId,IsDefualt,CreatedBy,CreatedDate,IsActive)
   VALUES (@CurrencyId,@IsDefault,@CreatedBy,GETDATE(),@IsActive)

END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[EditCurrencyMapping]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[EditCurrencyMapping]
END
GO
CREATE PROCEDURE [Common].[EditCurrencyMapping] 
(
  @Id INT
 ,@CurrencyId INT
 ,@IsDefault BIT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   
    INSERT INTO [Common].[CurrencyMapping_Audit] (RefId,CurrencyId,IsDefualt,CreatedBy,CreatedDate,IsActive)
    SELECT Id ,CurrencyId,IsDefualt,CreatedBy,CreatedDate,IsActive FROM [Common].[CurrencyMapping] WHERE Id=@Id;
   
	   UPDATE [Common].[CurrencyMapping]
	   SET    CurrencyId  =  @CurrencyId
			 ,IsDefualt   =  @IsDefault
			 ,CreatedBy   =  @CreatedBy 
			 ,CreatedDate =  GETDATE() 
			 ,IsActive    =  @IsActive
	   WHERE Id =@Id
   
  
END
GO

---------------------------------------------------------------- Functional Role ---------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllFunctionalRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllFunctionalRole]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllFunctionalRole] 	
AS
BEGIN
	SELECT   Id
			,FRoleName
			,FRoleCode
			,FRoleDesc
			,AttachmentFile
			,CreatedBy
			,CreatedDate
			,IsActive
	FROM    [Common].[Master_FunctionalRole]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetFunctionalRoleById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetFunctionalRoleById]
END
GO
CREATE PROCEDURE [Common].[Master_GetFunctionalRoleById]
(
  @Id INT
)
AS
BEGIN
	SELECT   Id
			,FRoleName
			,FRoleCode
			,FRoleDesc
			,AttachmentFile
			,CreatedBy
			,CreatedDate
			,IsActive
	FROM    [Common].[Master_FunctionalRole]	
	WHERE   Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddFunctionalRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddFunctionalRole]
END
Go
CREATE PROCEDURE [Common].[Master_AddFunctionalRole] 
(
  @FRoleName NVARCHAR(30)
 ,@FRoleCode NVARCHAR(20)
 ,@FRoleDesc NVARCHAR(200)
 ,@AttachmentFile NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN

   INSERT INTO [Common].[Master_FunctionalRole] (FRoleName,FRoleCode,FRoleDesc,AttachmentFile,CreatedBy,CreatedDate,IsActive)
   VALUES (@FRoleName,@FRoleCode,@FRoleDesc,@AttachmentFile,@CreatedBy,GETDATE(),@IsActive)

END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditFunctionalRole]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditFunctionalRole]
END
GO
CREATE PROCEDURE [Common].[Master_EditFunctionalRole] 
(
  @Id INT
 ,@FRoleName NVARCHAR(30)
 ,@FRoleCode NVARCHAR(20)
 ,@FRoleDesc NVARCHAR(200)
 ,@AttachmentFile NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   
    INSERT INTO [Common].[Master_FunctionalRole_Audit] (RefId,FRoleName,FRoleCode,FRoleDesc,AttachmentFile,CreatedBy,CreatedDate,IsActive)
    SELECT Id ,FRoleName,FRoleCode,FRoleDesc,AttachmentFile,CreatedBy,CreatedDate,IsActive FROM [Common].[Master_FunctionalRole] WHERE Id=@Id;
   
	   UPDATE [Common].[Master_FunctionalRole]
	   SET    FRoleName  =  @FRoleName
			 ,FRoleCode   =  @FRoleCode
			 ,FRoleDesc   =  @FRoleDesc
			 ,AttachmentFile   =  @AttachmentFile
			 ,CreatedBy   =  @CreatedBy 
			 ,CreatedDate =  GETDATE() 
			 ,IsActive    =  @IsActive
	   WHERE Id =@Id
   
  
END
GO
-----------------------------------------------------------------  Qualification  -----------------------------------------------


GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllCourseType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllCourseType]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllCourseType] 	
AS
BEGIN
	SELECT   Id
			,TypeName 
			,CreatedBy 
			,CreatedDate 
			,IsActive 
	FROM    [Common].[Master_CourseType]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetCourseTypeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetCourseTypeById]
END
GO
CREATE PROCEDURE [Common].[Master_GetCourseTypeById]
(
  @Id INT
)
AS
BEGIN
	SELECT   Id
			,TypeName 
			,CreatedBy 
			,CreatedDate 
			,IsActive 
	FROM    [Common].[Master_CourseType]	
	WHERE   Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddCourseType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddCourseType]
END
Go
CREATE PROCEDURE [Common].[Master_AddCourseType] 
(
  @TypeName NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   IF NOT EXISTS(SELECT 1 FROM [Common].[Master_CourseType] WHERE TypeName=@TypeName)
   BEGIN
       INSERT INTO [Common].[Master_CourseType] (TypeName,CreatedBy,CreatedDate,IsActive)
       VALUES (@TypeName,@CreatedBy,GETDATE(),@IsActive)

	   SELECT 1 AS Code , 'Record added successfully' AS [Message]
   END
   ELSE
   BEGIN
      SELECT 2 AS Code , 'Record already exists' AS [Message]
   END

END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditCourseType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditCourseType]
END
GO
CREATE PROCEDURE [Common].[Master_EditCourseType] 
(
  @Id INT
 ,@TypeName NVARCHAR(30)
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   
    INSERT INTO [Common].[Master_CourseType_Audit] (RefId,TypeName,CreatedBy,CreatedDate,IsActive)
    SELECT Id ,TypeName,CreatedBy,CreatedDate,IsActive FROM [Common].[Master_CourseType] WHERE Id=@Id;
   
	UPDATE [Common].[Master_CourseType]
	   SET    TypeName  =  @TypeName
			 ,CreatedBy   =  @CreatedBy 
			 ,CreatedDate =  GETDATE() 
			 ,IsActive    =  @IsActive
	   WHERE Id =@Id   

    SELECT 1 AS Code , 'Record updated successfully' AS [Message]
  
END
GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllCourseTitle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllCourseTitle]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllCourseTitle] 	
(
    @StartRow	INT,
	@EndRow	INT,
	@PropertyName VARCHAR(20) = null,
	@Direction	VARCHAR(5) = null,
	@SearchText	VARCHAR(20)
)
AS
BEGIN
	  ;with UserData as (
	SELECT 
	count(A.Id) OVER() as total,
	ROW_NUMBER() OVER (
	order by 
	CASE WHEN @PropertyName IS NULL OR (@PropertyName = 'Id' AND @Direction = 'asc') THEN A.Id END,
	CASE WHEN @PropertyName = 'TitleName' AND @Direction = 'asc' THEN TitleName END asc,
	CASE WHEN @PropertyName = 'TypeName' AND @Direction = 'asc' THEN TypeName END asc
	) as rowno
	        ,A.Id
			,A.TitleName
			,A.CourseTypeId
			,B.TypeName 
			,A.CreatedBy 
			,A.CreatedDate 
			,A.IsActive 
	FROM    [Common].[Master_CourseTitle] A
	INNER JOIN [Common].[Master_CourseType] B ON A.CourseTypeId = B.Id
	WHERE (
	ISNULL(@SearchText, '') = '' OR 
	A.ID like @SearchText+'%' OR 
	TitleName like @SearchText+'%' OR 
	TypeName like @SearchText+'%') 
	)
	select * from UserData
	WHERE rowno > = @StartRow AND rowno <= @EndRow
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetCourseTitleById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetCourseTitleById]
END
GO
CREATE PROCEDURE [Common].[Master_GetCourseTitleById]
(
  @Id INT
)
AS
BEGIN
	SELECT   A.Id
			,A.TitleName
			,A.CourseTypeId
			,B.TypeName AS CourseTypeName
			,A.CreatedBy 
			,A.CreatedDate 
			,A.IsActive 
	FROM    [Common].[Master_CourseTitle]  A
	INNER JOIN [Common].[Master_CourseType] B ON A.CourseTypeId = B.Id	
	WHERE   A.Id = @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddCourseTitle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddCourseTitle]
END
Go
CREATE PROCEDURE [Common].[Master_AddCourseTitle] 
(
  @TitleName  NVARCHAR(30)
 ,@CourseTypeId INT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   IF NOT EXISTS(SELECT 1 FROM [Common].[Master_CourseTitle] WHERE TitleName = @TitleName)
   BEGIN
	   INSERT INTO [Common].[Master_CourseTitle] (TitleName,CourseTypeId,CreatedBy,CreatedDate,IsActive)
	   VALUES (@TitleName,@CourseTypeId,@CreatedBy,GETDATE(),@IsActive)
	   SELECT 1 AS Code , 'Record added successfully' AS [Message]
   END
   ELSE
   BEGIN
       SELECT 2 AS Code , 'Record already exists' AS [Message]
   END
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditCourseTitle]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditCourseTitle]
END
GO
CREATE PROCEDURE [Common].[Master_EditCourseTitle] 
(
  @Id INT
 ,@TitleName  NVARCHAR(30)
 ,@CourseTypeId INT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   
       DECLARE @title NVARCHAR(50) = (SELECT TitleName FROM [Common].[Master_CourseTitle] WHERE ID=@Id)
       IF NOT EXISTS(SELECT 1 FROM [Common].[Master_CourseTitle] WHERE TitleName = @TitleName) OR (@title=@TitleName)
       BEGIN
		  INSERT INTO [Common].[Master_CourseTitle_Audit] (RefId,TitleName,CourseTypeId,CreatedBy,CreatedDate,IsActive)
		  SELECT Id ,TitleName,CourseTypeId,CreatedBy,CreatedDate,IsActive FROM [Common].[Master_CourseTitle] WHERE Id=@Id;
   
		   UPDATE [Common].[Master_CourseTitle]
		   SET    TitleName  =  @TitleName
				 ,CourseTypeId   =  @CourseTypeId 
				 ,CreatedBy   =  @CreatedBy 
				 ,CreatedDate =  GETDATE() 
				 ,IsActive    =  @IsActive
		   WHERE Id =@Id   

	       SELECT 1 AS Code , 'Record updated successfully' AS [Message]
	   END
       ELSE
	   BEGIN
	        SELECT 2 AS Code , 'Record already exists' AS [Message]
	   END

END
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllMajor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllMajor]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllMajor] 	
AS
BEGIN
	SELECT   A.Id
			,A.MajorName
			,A.TitleId
			,B.TitleName 
			,A.CreatedBy 
			,A.CreatedDate 
			,A.IsActive 
	FROM    [Common].[Master_Major] A
	INNER JOIN [Common].[Master_CourseTitle] B ON A.TitleId = B.id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetMajorById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetMajorById]
END
GO
CREATE PROCEDURE [Common].[Master_GetMajorById]
(
  @Id INT
)
AS
BEGIN
	SELECT   Id
			,MajorName
			,TitleId
			,CreatedBy 
			,CreatedDate 
			,IsActive 
	FROM    [Common].[Master_Major]	
	WHERE   Id = @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddMajor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddMajor]
END
Go
CREATE PROCEDURE [Common].[Master_AddMajor] 
(
  @MajorName  NVARCHAR(30)
 ,@TitleId INT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
   IF NOT EXISTS(SELECT 1 FROM [Common].[Master_Major] WHERE MajorName = @MajorName)
   BEGIN
	   INSERT INTO [Common].[Master_Major] (MajorName,TitleId,CreatedBy,CreatedDate,IsActive)
	   VALUES (@MajorName,@TitleId,@CreatedBy,GETDATE(),@IsActive)
	   SELECT 1 AS Code , 'Record added successfully' AS [Message]
   END
   ELSE
   BEGIN
        SELECT 2 AS Code , 'Record already exists' AS [Message]
   END
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditMajor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditMajor]
END
GO
CREATE PROCEDURE [Common].[Master_EditMajor] 
(
  @Id INT
 ,@MajorName  NVARCHAR(30)
 ,@TitleId INT
 ,@IsActive BIT
 ,@CreatedBy INT
)
AS
BEGIN
    DECLARE @name NVARCHAR(50) = (SELECT MajorName FROM [Common].[Master_Major] WHERE ID=@Id)
    IF NOT EXISTS(SELECT 1 FROM [Common].[Master_Major] WHERE MajorName = @MajorName) OR (@name=@MajorName)
    BEGIN
		INSERT INTO [Common].[Master_Major_Audit] (RefId,MajorName,TitleId,CreatedBy,CreatedDate,IsActive)
		SELECT Id ,MajorName,TitleId,CreatedBy,CreatedDate,IsActive FROM [Common].[Master_Major] WHERE Id=@Id;
   
	   UPDATE [Common].[Master_Major]
	   SET    MajorName  =  @MajorName
	         ,TitleId   =  @TitleId 
			 ,CreatedBy   =  @CreatedBy 
			 ,CreatedDate =  GETDATE() 
			 ,IsActive    =  @IsActive
	   WHERE Id =@Id   ;
       SELECT 1 AS Code , 'Record updated successfully' AS [Message]
	END
    ELSE
	BEGIN
	     SELECT 2 AS Code , 'Record already exists' AS [Message]
	END
END
GO
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllUniversity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllUniversity]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllUniversity] 	
AS
BEGIN
	SELECT   Id
			,UniversityName
			,CountryId
			,StateId
			,CityId
			,CreatedBy 
			,CreatedDate 
			,IsActive 
			,IsBlacklist
	FROM    [Common].[Master_University]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetUniversityById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetUniversityById]
END
GO
CREATE PROCEDURE [Common].[Master_GetUniversityById]
(
  @Id INT
)
AS
BEGIN
	SELECT   Id
			,UniversityName
			,CountryId
			,StateId
			,CityId
			,CreatedBy 
			,CreatedDate 
			,IsActive 
			,IsBlacklist
	FROM    [Common].[Master_University]	
	WHERE   Id = @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddUniversity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddUniversity]
END
Go
CREATE PROCEDURE [Common].[Master_AddUniversity] 
(
  @UniversityName  NVARCHAR(30)
 ,@CountryId INT
 ,@StateId INT
 ,@CityId INT
 ,@IsActive BIT
 ,@CreatedBy INT
 ,@IsBlacklist BIT
)
AS
BEGIN
   IF NOT EXISTS(SELECT 1 FROM [Common].[Master_University] WHERE UniversityName = @UniversityName)
   BEGIN
	   INSERT INTO [Common].[Master_University] (UniversityName,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist)
	   VALUES (@UniversityName,@CountryId,@StateId,@CityId,@CreatedBy,GETDATE(),@IsActive,@IsBlacklist);
	   SELECT 1 AS Code , 'Record added successfully' AS [Message]
   END
   ELSE
   BEGIN
        SELECT 2 AS Code , 'Record already exists' AS [Message]
   END
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditUniversity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditUniversity]
END
GO
CREATE PROCEDURE [Common].[Master_EditUniversity] 
(
  @Id INT
 ,@UniversityName  NVARCHAR(30)
 ,@CountryId INT
 ,@StateId INT
 ,@CityId INT
 ,@IsActive BIT
 ,@IsBlacklist BIT
 ,@CreatedBy INT
)
AS
BEGIN
    DECLARE @name NVARCHAR(50) = (SELECT UniversityName FROM [Common].[Master_University] WHERE ID=@Id)
    IF NOT EXISTS(SELECT 1 FROM [Common].[Master_University] WHERE UniversityName = @UniversityName) OR (@name=@UniversityName)
    BEGIN
		INSERT INTO [Common].[Master_University_Audit] (RefId,UniversityName,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist)
		SELECT Id ,UniversityName,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist FROM [Common].[Master_University] WHERE Id=@Id;
   
	    UPDATE [Common].[Master_University]
	    SET    UniversityName  =  @UniversityName
	          ,CountryId   =  @CountryId 
		 	 ,StateId   =  @StateId 
		 	 ,CityId   =  @CityId 
		 	 ,CreatedBy   =  @CreatedBy 
		 	 ,CreatedDate =  GETDATE() 
		 	 ,IsActive    =  @IsActive
		 	 ,IsBlacklist = @IsBlacklist
	    WHERE Id =@Id   
        SELECT 1 AS Code , 'Record updated successfully' AS [Message]
	END
    ELSE
	BEGIN
	     SELECT 2 AS Code , 'Record already exists' AS [Message]
	END
END
GO
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllInstitute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllInstitute]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllInstitute] 	
AS
BEGIN
	SELECT   Id
			,InstituteName
			,UniversityId
			,CountryId
			,StateId
			,CityId
			,CreatedBy 
			,CreatedDate 
			,IsActive 
			,IsBlacklist
	FROM    [Common].[Master_Institute]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetInstituteById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetInstituteById]
END
GO
CREATE PROCEDURE [Common].[Master_GetInstituteById]
(
  @Id INT
)
AS
BEGIN
	SELECT   Id
			,InstituteName
			,UniversityId
			,CountryId
			,StateId
			,CityId
			,CreatedBy 
			,CreatedDate 
			,IsActive 
			,IsBlacklist
	FROM    [Common].[Master_Institute]	
	WHERE   Id = @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddInstitute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddInstitute]
END
Go
CREATE PROCEDURE [Common].[Master_AddInstitute] 
(
  @InstituteName  NVARCHAR(30)
 ,@UniversityId INT
 ,@CountryId INT
 ,@StateId INT
 ,@CityId INT
 ,@IsActive BIT
 ,@CreatedBy INT
 ,@IsBlacklist BIT
)
AS
BEGIN
  IF NOT EXISTS(SELECT 1 FROM [Common].[Master_Institute] WHERE InstituteName = @InstituteName)
  BEGIN
	   INSERT INTO [Common].[Master_Institute] (InstituteName,UniversityId,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist)
	   VALUES (@InstituteName,@UniversityId,@CountryId,@StateId,@CityId,@CreatedBy,GETDATE(),@IsActive,@IsBlacklist);
	    SELECT 1 AS Code , 'Record added successfully' AS [Message]
  END
  ELSE
  BEGIN
       SELECT 2 AS Code , 'Record already exists' AS [Message]
  END
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditInstitute]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditInstitute]
END
GO
CREATE PROCEDURE [Common].[Master_EditInstitute] 
(
  @Id INT
 ,@InstituteName  NVARCHAR(30)
 ,@UniversityId INT
 ,@CountryId INT
 ,@StateId INT
 ,@CityId INT
 ,@IsActive BIT
 ,@IsBlacklist BIT
 ,@CreatedBy INT
)
AS
BEGIN
    DECLARE @name NVARCHAR(50) = (SELECT InstituteName FROM [Common].[Master_Institute] WHERE ID=@Id)
    IF NOT EXISTS(SELECT 1 FROM [Common].[Master_Institute] WHERE InstituteName = @InstituteName) OR (@name=@InstituteName)
    BEGIN
		INSERT INTO [Common].[Master_Institute_Audit] (RefId,InstituteName,UniversityId,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist)
		SELECT Id ,InstituteName,UniversityId,CountryId,StateId,CityId,CreatedBy,CreatedDate,IsActive,IsBlacklist FROM [Common].[Master_Institute] WHERE Id=@Id;
   
	    UPDATE [Common].[Master_Institute]
	    SET    InstituteName  =  @InstituteName
	          ,UniversityId = @UniversityId
	          ,CountryId   =  @CountryId 
		 	 ,StateId   =  @StateId 
		 	 ,CityId   =  @CityId 
		 	 ,CreatedBy   =  @CreatedBy 
		 	 ,CreatedDate =  GETDATE() 
		 	 ,IsActive    =  @IsActive
		 	 ,IsBlacklist = @IsBlacklist
	    WHERE Id =@Id  ;
		SELECT 1 AS Code , 'Record updated successfully' AS [Message]
	END
    ELSE
	BEGIN
	     SELECT 2 AS Code , 'Record already exists' AS [Message]
	END
  
END
GO



-----------------------------------------------------------------EmployeeType------------------------------------------

GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllEmployeeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllEmployeeType]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllEmployeeType]
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SET NOCOUNT ON;
	SELECT Id
				,TypeName
				,SelfService
				,MinAge
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_EmployeeType]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetEmployeeTypeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetEmployeeTypeById]
END
GO
CREATE PROCEDURE [Common].[Master_GetEmployeeTypeById] 
(
  @Id INT
)
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SET NOCOUNT ON;
	SELECT Id
				,TypeName
				,SelfService
				,MinAge
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_EmployeeType]
	WHERE Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddEmployeeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddEmployeeType]
END
Go
CREATE PROCEDURE [Common].[Master_AddEmployeeType]
(
  @TypeName NVARCHAR(100),
  @SelfService BIT,
  @MinAge INT,
  @CreatedBy INT
)
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SET NOCOUNT ON;
   INSERT INTO [Common].[Master_EmployeeType] (TypeName,SelfService,MinAge,CreatedBy,IsActive)
   VALUES (@TypeName,@SelfService,@MinAge,@CreatedBy,1)
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditEmployeeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditEmployeeType]
END
GO
CREATE PROCEDURE [Common].[Master_EditEmployeeType]
(
	@Id INT
    ,@TypeName NVARCHAR(100)
	,@SelfService BIT
	,@MinAge INT
	,@CreatedBy INT
	,@IsActive BIT
)
AS
BEGIN
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SET NOCOUNT ON;
   INSERT INTO [Common].[Master_EmployeeType_Audit] (RefId,TypeName,SelfService,MinAge,UpdatedBy,IsActive)
   SELECT Id
				,TypeName
				,SelfService
				,MinAge
				,CreatedBy
				,IsActive 
				FROM [Common].[Master_EmployeeType] WHERE id=@Id

   UPDATE [Common].[Master_EmployeeType]
			SET
				TypeName=@TypeName
				,SelfService=@SelfService
				,MinAge=@MinAge
				,CreatedBy=@CreatedBy
				,IsActive=@IsActive
			WHERE Id =@Id

END
GO

---------------------------------------------------------------------GradeType---------------------------------------

GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllGradeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllGradeType]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllGradeType]
AS
BEGIN
	SELECT Id
				,TypeName
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_GradeType]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetGradeTypeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetGradeTypeById]
END
GO
CREATE PROCEDURE [Common].[Master_GetGradeTypeById] 
(
  @Id INT
)
AS
BEGIN
	SELECT Id
				,TypeName
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_GradeType]
	WHERE Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddGradeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddGradeType]
END
Go
CREATE PROCEDURE [Common].[Master_AddGradeType]
(
  @TypeName NVARCHAR(100),
  @CreatedBy INT,
  @IsActive BIT
)
AS
BEGIN
   INSERT INTO [Common].[Master_GradeType] (TypeName,CreatedBy,IsActive)
   VALUES (@TypeName,@CreatedBy,@IsActive)
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditGradeType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditGradeType]
END
GO
CREATE PROCEDURE [Common].[Master_EditGradeType]
(
	@Id INT
    ,@TypeName NVARCHAR(100)
	,@CreatedBy INT
	,@IsActive BIT
)
AS
BEGIN

   INSERT INTO [Common].[Master_GradeType_Audit] (RefId,TypeName,UpdatedBy,IsActive)
   SELECT Id
				,TypeName
				,CreatedBy
				,IsActive 
				FROM [Common].[Master_GradeType] WHERE id=@Id

   UPDATE [Common].[Master_GradeType]
			SET
				TypeName=@TypeName
				,CreatedBy=@CreatedBy
				,IsActive=@IsActive
			WHERE Id =@Id

END
GO
-----------------------------------------------------------------------------------BandType------------------------------------

GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetAllBandType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetAllBandType]
END
GO
CREATE PROCEDURE [Common].[Master_GetAllBandType]
AS
BEGIN
	SELECT Id
				,TypeName
				,GradesMapping
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_BandType]
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_GetBandTypeById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_GetBandTypeById]
END
GO
CREATE PROCEDURE [Common].[Master_GetBandTypeById] 
(
  @Id INT
)
AS
BEGIN
	SELECT Id
				,TypeName
				,GradesMapping
				,CreatedBy
				,CreatedDate
				,IsActive
	FROM  [Common].[Master_BandType]
	WHERE Id= @Id
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_AddBandType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_AddBandType]
END
Go
CREATE PROCEDURE [Common].[Master_AddBandType]
(
  @TypeName NVARCHAR(100),
  @GradesMapping NVARCHAR(200),
  @CreatedBy INT,
  @IsActive BIT
)
AS
BEGIN
   INSERT INTO [Common].[Master_BandType] (TypeName,GradesMapping,CreatedBy,IsActive)
   VALUES (@TypeName,@GradesMapping,@CreatedBy,@IsActive)
END
GO
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Common].[Master_EditBandType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [Common].[Master_EditBandType]
END
GO
CREATE PROCEDURE [Common].[Master_EditBandType]
(
	@Id INT
    ,@TypeName NVARCHAR(100)
	,@GradesMapping VARCHAR(200)
	,@CreatedBy INT
	,@IsActive BIT
)
AS
BEGIN

   INSERT INTO [Common].[Master_BandType_Audit] (RefId,TypeName,GradesMapping,UpdatedBy,IsActive)
   SELECT Id
				,TypeName
				,GradesMapping
				,CreatedBy
				,IsActive 
				FROM [Common].[Master_BandType] WHERE id=@Id

   UPDATE [Common].[Master_BandType]
			SET
				TypeName=@TypeName
				,GradesMapping=@GradesMapping
				,CreatedBy=@CreatedBy
				,IsActive=@IsActive
			WHERE Id =@Id

END
GO
/*------------------- Admin Panel : Company --------------------------*/
IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Company].[PageSetting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
DROP PROCEDURE [Company].[PageSetting]
END
GO
CREATE PROCEDURE [Company].[PageSetting]
(
@TransType VARCHAR(25),
@LoginPageBackGroundImgOne VARCHAR(100)=NULL,
@LoginPageBackGroundImgTwo VARCHAR(100)=NULL,
@LoginPageBackGroundImgThree VARCHAR(100)=NULL,
@DashboardPageBackGroundImgOne VARCHAR(100)=NULL,
@DashboardPageBackGroundImgTwo VARCHAR(100)=NULL,
@DashboardPageBackGroundImgThree VARCHAR(100)=NULL,
@DashboardPageBackGroundImgFour VARCHAR(100)=NULL,
@DashboardPageBackGroundImgFive VARCHAR(100)=NULL,
@SlideShoutContent INT=NULL,
@IsBirthdayVisible BIT=NULL,
@IsWorkAnniversaryVisible BIT=NULL,
@IsMarriageAnniversaryVisible BIT=NULL,
@IsExitVisible BIT=NULL,
@IsNewJoineeVisible BIT=NULL,
@CreatedBy [bigint]=NULL,
@ModifiedBy [bigint]=NULL
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	IF @TransType='SAVE'
	BEGIN
			DECLARE @Status AS INT,
					@Message AS VARCHAR(50)

			IF NOT EXISTS(SELECT 1 FROM  [Company].[PageSettings])
			BEGIN
				INSERT INTO [Company].[PageSettings](LoginPageBackGroundImgOne,LoginPageBackGroundImgTwo,LoginPageBackGroundImgThree,DashboardPageBackGroundImgOne,DashboardPageBackGroundImgTwo,DashboardPageBackGroundImgThree,DashboardPageBackGroundImgFour,DashboardPageBackGroundImgFive,SlideShoutContent,IsBirthdayVisible,IsWorkAnniversaryVisible,IsMarriageAnniversaryVisible,IsExitVisible,IsNewJoineeVisible,CreatedBy,CreatedOn)
				VALUES(@LoginPageBackGroundImgOne,@LoginPageBackGroundImgTwo,@LoginPageBackGroundImgThree,@DashboardPageBackGroundImgOne,@DashboardPageBackGroundImgTwo,@DashboardPageBackGroundImgThree,@DashboardPageBackGroundImgFour,@DashboardPageBackGroundImgFive,@SlideShoutContent,@IsBirthdayVisible,@IsWorkAnniversaryVisible,@IsMarriageAnniversaryVisible,@IsExitVisible,@IsNewJoineeVisible,@CreatedBy,GETDATE())

							
				SET @Status=1
				SET @Message='Page settings created successfully.'
			END
			ELSE
			BEGIN
				INSERT INTO [Company].[PageSettings_Audit](LoginPageBackGroundImgOne,LoginPageBackGroundImgTwo,LoginPageBackGroundImgThree,DashboardPageBackGroundImgOne,DashboardPageBackGroundImgTwo,DashboardPageBackGroundImgThree,DashboardPageBackGroundImgFour,DashboardPageBackGroundImgFive,SlideShoutContent,IsBirthdayVisible,IsWorkAnniversaryVisible,IsMarriageAnniversaryVisible,IsExitVisible,IsNewJoineeVisible,CreatedBy,CreatedOn)
				SELECT LoginPageBackGroundImgOne,LoginPageBackGroundImgTwo,LoginPageBackGroundImgThree,DashboardPageBackGroundImgOne,DashboardPageBackGroundImgTwo,DashboardPageBackGroundImgThree,DashboardPageBackGroundImgFour,DashboardPageBackGroundImgFive,SlideShoutContent,IsBirthdayVisible,IsWorkAnniversaryVisible,IsMarriageAnniversaryVisible,IsExitVisible,IsNewJoineeVisible,CreatedBy,ISNULL(ModifiedOn,CreatedOn)
				FROM  [Company].[PageSettings] 

				UPDATE [Company].[PageSettings]
				SET LoginPageBackGroundImgOne=@LoginPageBackGroundImgOne,LoginPageBackGroundImgTwo=@LoginPageBackGroundImgTwo,LoginPageBackGroundImgThree=@LoginPageBackGroundImgThree,
					DashboardPageBackGroundImgOne=@DashboardPageBackGroundImgOne,DashboardPageBackGroundImgTwo=@DashboardPageBackGroundImgTwo,DashboardPageBackGroundImgThree=@DashboardPageBackGroundImgThree,
					DashboardPageBackGroundImgFour=@DashboardPageBackGroundImgFour,DashboardPageBackGroundImgFive=@DashboardPageBackGroundImgFive,
					SlideShoutContent=@SlideShoutContent,IsBirthdayVisible=@IsBirthdayVisible,IsWorkAnniversaryVisible=@IsWorkAnniversaryVisible,
					IsMarriageAnniversaryVisible=@IsMarriageAnniversaryVisible,IsExitVisible=@IsExitVisible,IsNewJoineeVisible=@IsNewJoineeVisible,
					ModifiedOn=GETDATE(),ModifiedBy=@ModifiedBy
				
				
				SET @Status=1
				SET @Message='Page settings modified successfully.'
			END
			SELECT @Status AS Code,@Message As [Message]
	END
	ELSE IF @TransType='FETCH'
	BEGIN
			SELECT LoginPageBackGroundImgOne,LoginPageBackGroundImgTwo,LoginPageBackGroundImgThree,
				   DashboardPageBackGroundImgOne,DashboardPageBackGroundImgTwo,DashboardPageBackGroundImgThree,
				   DashboardPageBackGroundImgFour,DashboardPageBackGroundImgFive,
				   SlideShoutContent,IsBirthdayVisible,IsWorkAnniversaryVisible,IsMarriageAnniversaryVisible,IsExitVisible,IsNewJoineeVisible
			FROM  [Company].[PageSettings]
	END
END
GO

IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Company].[SecuritySetting]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
DROP PROCEDURE [Company].[SecuritySetting]
END
GO

CREATE PROCEDURE [Company].[SecuritySetting]
(
@TransType VARCHAR(25),
@PasswordExpiryIndays INT= NULL,
@SessionTimeOutInMins INT =NULL,
@HideMobileNumberFromEd VARCHAR(20)= NULL,
@CreatedBy [bigint] =NULL,
@ModifiedBy [bigint] =NULL
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	IF @TransType='SAVE'
	BEGIN
			DECLARE @Status AS INT,
					@Message AS VARCHAR(50)

			IF NOT EXISTS(SELECT 1 FROM [Company].[SecuritySettings])
			BEGIN
					INSERT INTO [Company].[SecuritySettings](PasswordExpiryIndays,SessionTimeOutInMins,HideMobileNumberFromEd,CreatedBy,CreatedOn)
					VALUES(@PasswordExpiryIndays,@SessionTimeOutInMins,@HideMobileNumberFromEd,@CreatedBy,GETDATE())

					SET @Status=1
					SET @Message='Security settings created successfully.'
			END
			ELSE
			BEGIN
					INSERT INTO  [Company].[SecuritySettings_Audit](PasswordExpiryIndays,SessionTimeOutInMins,HideMobileNumberFromEd,CreatedBy,CreatedOn)
					SELECT PasswordExpiryIndays,SessionTimeOutInMins,HideMobileNumberFromEd,CreatedBy,ISNULL(ModifiedOn,CreatedOn)
					FROM [Company].[SecuritySettings]
	
				
					UPDATE [Company].[SecuritySettings]
					SET PasswordExpiryIndays=@PasswordExpiryIndays,SessionTimeOutInMins=@SessionTimeOutInMins,HideMobileNumberFromEd=@HideMobileNumberFromEd,
						ModifiedBy=@ModifiedBy,ModifiedOn=GETDATE()


					SET @Status=1
					SET @Message='Security settings modified successfully.'
			END
			SELECT @Status AS Code,@Message As [Message]
	END
	ELSE IF @TransType='FETCH'
	BEGIN
			SELECT PasswordExpiryIndays,SessionTimeOutInMins,HideMobileNumberFromEd
			FROM [Company].[SecuritySettings]
	END
END
GO

IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Company].[GroupCompanyDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
DROP PROCEDURE [Company].[GroupCompanyDetails]
END
GO

CREATE PROCEDURE [Company].[GroupCompanyDetails] 
(	
@Id INT=NULL,
@TransType [Varchar](25),
@Name [Varchar](50)=NULL,
@Code [varchar](50)=NULL,
@TypeId [bigint]=NULL,
@IncorporationDate DATETIME=NULL,
@Address [varchar](250)=NULL,
@CountryId [int]=NULL,
@StateId [int]=NULL,
@CityId [bigint]=NULL,
@PinCode [int]=NULL,
@ContcatNo [varchar](50)=NULL,
@WebSite [Varchar](100)=NULL,
@PAN[varchar](50)=NULL,
@TAN[varchar](50)=NULL,
@GSTIN[varchar](100)=NULL,
@PF[varchar](100)=NULL,
@ESIC[varchar](100)=NULL,
@Logo[varchar](100)=NULL,
@CreatedBy [bigint]=NULL,
@ModifiedBy [bigint]=NULL
)
AS 
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	IF @TransType='SAVE'
	BEGIN
			DECLARE @Status AS INT,
					@Message AS VARCHAR(50)

			IF @Id=0 AND NOT EXISTS(SELECT 1 FROM [Company].[GroupCompany])
			BEGIN
					INSERT INTO [Company].[GroupCompany](Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,CreatedBy,CreatedOn)
					VALUES(@Name,@Code,@TypeId,@IncorporationDate,@Address,@CountryId,@StateId,@CityId,@PinCode,@ContcatNo,@WebSite,@PAN,@TAN,@GSTIN,@PF,@ESIC,@Logo,@CreatedBy,GETDATE())

					SET @Status=1
					SET @Message='Group Company created successfully.'
			END
			ELSE IF @Id>0 AND  EXISTS(SELECT 1 FROM [Company].[GroupCompany] WHERE Code=@Code)
			BEGIN
					INSERT INTO [Company].[GroupCompany_Audit](Id,Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,CreatedBy,CreatedOn)
					SELECT @Id,Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,CreatedBy,CreatedOn
					FROM [Company].[GroupCompany]
					WHERE Id=@Id

					UPDATE [Company].[GroupCompany]
					SET Name=@Name,Code=@Code,TypeId=@TypeId,IncorporationDate=@IncorporationDate,[Address]=@Address,CountryId=@CountryId,StateId=@StateId,CityId=@CityId,
						PinCode=@PinCode,ContcatNo=@ContcatNo,WebSite=@WebSite,PAN=@PAN,[TAN]=@TAN,GSTIN=@GSTIN,PF=@PF,ESIC=@ESIC,Logo=@Logo,
						ModifiedOn=GETDATE(),ModifiedBy=@ModifiedBy
					WHERE Id=@Id

			
					SET @Status=1
					SET @Message='Group Company modified successfully.'
			END
			SELECT @Status AS Code,@Message As [Message]
	END
	ELSE IF @TransType='FETCH'
	BEGIN
			SELECT Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo
			FROM [Company].[GroupCompany]
	END

END
GO

IF EXISTS ( SELECT 1 FROM  sysobjects WHERE id = object_id(N'[Company].[EntityDetails]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
DROP PROCEDURE [Company].[EntityDetails]
END
GO

CREATE PROCEDURE [Company].[EntityDetails] 
(	
@Id INT=NULL,
@TransType [Varchar](25),
@Name [Varchar](50)=NULL,
@Code [varchar](50)=NULL,
@TypeId [bigint]=NULL,
@IncorporationDate DATETIME=NULL,
@Address [varchar](250)=NULL,
@CountryId [int]=NULL,
@StateId [int]=NULL,
@CityId [bigint]=NULL,
@PinCode [int]=NULL,
@ContcatNo [varchar](50)=NULL,
@WebSite [Varchar](100)=NULL,
@PAN[varchar](50)=NULL,
@TAN[varchar](50)=NULL,
@GSTIN[varchar](100)=NULL,
@PF[varchar](100)=NULL,
@ESIC[varchar](100)=NULL,
@Logo[varchar](100)=NULL,
@IsActive BIT=NULL,
@CreatedBy [bigint]=NULL,
@ModifiedBy [bigint]=NULL
)
AS 
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	SET NOCOUNT ON

	IF @TransType='SAVE'
	BEGIN
			DECLARE @Status AS INT,
					@Message AS VARCHAR(50)

			IF @Id=0 AND NOT EXISTS(SELECT 1 FROM [Company].[Entity] Where Code=@Code)
			BEGIN
					INSERT INTO [Company].[Entity](Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,IsActive,CreatedBy,CreatedOn)
					VALUES(@Name,@Code,@TypeId,@IncorporationDate,@Address,@CountryId,@StateId,@CityId,@PinCode,@ContcatNo,@WebSite,@PAN,@TAN,@GSTIN,@PF,@ESIC,@Logo,1,@CreatedBy,GETDATE())

					SET @Status=1
					SET @Message='Entity created successfully.'
			END
			ELSE IF @Id>0
			BEGIN
					INSERT INTO [Company].[Entity_Audit](Id,Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,IsActive,CreatedBy,CreatedOn)
					SELECT @Id,Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo,IsActive,CreatedBy,CreatedOn
					FROM [Company].[Entity]
					WHERE Id=@Id
					
					UPDATE [Company].[Entity]
					SET Name=@Name,Code=@Code,TypeId=@TypeId,IncorporationDate=@IncorporationDate,[Address]=@Address,CountryId=@CountryId,StateId=@StateId,CityId=@CityId,
						PinCode=@PinCode,ContcatNo=@ContcatNo,WebSite=@WebSite,PAN=@PAN,[TAN]=@TAN,GSTIN=@GSTIN,PF=@PF,ESIC=@ESIC,Logo=@Logo,IsActive=@IsActive,
						ModifiedOn=GETDATE(),ModifiedBy=@ModifiedBy
					WHERE Id=@Id

					SET @Status=1
					SET @Message='Entity modified successfully.'
			END
			SELECT @Status AS Code,@Message As [Message]
	END
	ELSE IF @TransType='FETCH'
	BEGIN
			SELECT Id,[Name],Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo
			FROM [Company].[Entity]
	END
	ELSE IF @TransType='FETCHBYENTITYID'
	BEGIN
			SELECT Id,Name,Code,TypeId,IncorporationDate,[Address],CountryId,StateId,CityId,PinCode,ContcatNo,WebSite,PAN,[TAN],GSTIN,PF,ESIC,Logo
			FROM [Company].[Entity]
			WHERE Id=@Id
	END
END
GO







