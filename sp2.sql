CREATE PROC _Cost_Add_Project_Codes_Category
@Name AS NVARCHAR(100)
AS
BEGIN
  INSERT INTO _Cost_Project_Code_Categories (Name) SELECT @Name
END 

GO

CREATE PROC _Cost_Add_Unified_Codes_Category
@Name AS NVARCHAR(100)
AS
BEGIN
  INSERT INTO _Cost_Unified_Code_Category (Name) SELECT @Name
END 

