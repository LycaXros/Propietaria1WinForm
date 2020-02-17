IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EmployeePuesto]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[V_EmployeePuesto]
AS
SELECT 
FROM   
       '