CREATE TYPE [dbo].[_Cost_Project_Codes_List] AS TABLE(
	[Decription] [nvarchar](max) NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Unified_Code_Id] [int] NOT NULL,
	[Parent] [int] NOT NULL,
	[Code] [nvarchar](MAX) NULL,
	[project_Id] [int] NOT NULL
)
GO
CREATE TYPE [dbo].[_Cost_Unified_Codes_List] AS TABLE(
	[Title] [nvarchar](max) NOT NULL,
	[Category_Id] [int] NOT NULL,
	[Parent] [int] NOT NULL,
	[Code] [nvarchar](MAX) NULL
)
GO

CREATE PROC [dbo].[_Cost_SP_Insert_Project_Codes]
@list as _Cost_Project_Codes_List READONLY 
AS 
BEGIN 
  SET NOCOUNT ON;

  INSERT INTO _Cost_Project_Codes (Description,Unified_Code_Id,Category_Id,Node,Project_Id,Parent,Code)
  SELECT Decription,Unified_Code_Id,Category_Id,CAST(Code AS hierarchyid),project_Id,Parent,Code
  FROM @LIST
END 

GO
CREATE PROC [dbo].[_Cost_SP_Insert_Unified_Codes]
@list as _Cost_Unified_Codes_List READONLY
AS
BEGIN
   SET NOCOUNT ON;
   
   INSERT INTO _Cost_Unified_Codes (Title,Node,Category_Id,Parent,Code)
   SELECT Title,CAST(Code AS hierarchyid),Category_Id,Parent,Code
   FROM @list

END
GO
