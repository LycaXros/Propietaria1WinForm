use [RRHH_DATA]

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_EmployeePuesto]'))
EXEC dbo.sp_executesql @statement = N'

CREATE VIEW [dbo].[V_EmployeePuesto]
AS
SELECT E.Cedula, E.Nombre, E.FechaIngreso, E.Departamento, E.Salario, P.Nombre as "Puesto"
FROM   RRHH_DATA.dbo.Empleados as E join RRHH_DATA.dbo.Puestos as P on E.PuestoId = P.Id 
WHERE E.Estado = 1    '