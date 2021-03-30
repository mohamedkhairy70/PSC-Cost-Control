CREATE PROC _COST_Update_Project_Code
@forId INT ,@description AS NVARCHAR(150),@unifiedCode_Id INT,@CategoryId AS INT 
AS
BEGIN
SET NOCOUNT ON;
UPDATE _Cost_Project_Codes 
SET Description=@description ,Unified_Code_Id=@unifiedCode_Id,Category_Id=@CategoryId
WHERE Id=@forId
END

CREATE TYPE _Cost_Update_Hireachy_Type AS TABLE (
Id int PRIMARY KEY,
NewParent INT,
NewCode INT
);
GO
CREATE PROC _COST_Update_Project_Codes_Hireachy @list as _Cost_Update_Hireachy_Type READONLY
as 
BEGIN
SET NOCOUNT ON;
UPDATE _Cost_Project_Codes  
SET Parent=l.NewParent,Code=l.NewCode
FROM @list AS l
WHERE l.Id=_Cost_Project_Codes.Id
END

 GO

CREATE PROC _COST_Delete_By_Id
@table NVARCHAR(MAX),@id INT 
AS
BEGIN
DECLARE @SQL NVARCHAR(MAX);
SET @SQL='DELETE FROM '+@table +'WHERE'+'Id='+@id
EXECUTE @SQL
END
