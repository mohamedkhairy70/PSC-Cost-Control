USE [CostExternal]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[_Cost_Add_Project_Codes_Category]
		@Name = N'embaby'

SELECT	@return_value as 'Return Value'

GO

select * from C_Cost_Project_Code_Categories