-- Creacion de base de datos
CREATE DATABASE APIREST_TEST1
GO

USE APIREST_TEST1

-- Creacion de tabla "Employees"
CREATE TABLE Employees (
	EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(50),
	LastName  NVARCHAR(50),
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(100),
	HireDate DATETIME,	
)
GO

-- Procedimiento almacenado para listar empleados.
CREATE PROCEDURE spListEmployees
AS
BEGIN
    SELECT 
		EmployeeId,FirstName,LastName,Email,PhoneNumber,HireDate 
	FROM Employees
END
GO

-- Procedimiento almacenado para encontrar empleado por Id.
CREATE PROCEDURE spFindEmployeeById
    @EmployeeId INT
AS
BEGIN
    SELECT 
		EmployeeId,FirstName,LastName,Email,PhoneNumber,HireDate 
	FROM Employees 
	WHERE EmployeeId = @EmployeeId;
END
GO

-- Procedimiento almacenado para crear empleado.
CREATE PROCEDURE spNewEmployee
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15),
	@HireDate DATETIME
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber,HireDate)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber,@HireDate);
END
GO

-- Procedimiento almacenado para actualizar datos de un empleado.
CREATE PROCEDURE spUpdateEmployee
    @EmployeeId INT,
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15),
	@HireDate DATETIME
AS
BEGIN
    UPDATE Employees
    SET 
		FirstName = @FirstName,
        LastName = @LastName,
        Email = @Email,
        PhoneNumber = @PhoneNumber,
		HireDate = @HireDate
    WHERE EmployeeId = @EmployeeId;
END
GO


-- Procedimiento almacenado para eliminar un empleado.
CREATE PROCEDURE spDeleteEmployee
    @EmployeeId INT
AS
BEGIN
    DELETE FROM Employees 
	WHERE EmployeeId = @EmployeeId;
END
GO


-- Procedimiento almacenado para buscar empleados que hayan sido contratados despues de una fecha
-- Se agrega parametro "HireDate" como filtro mencionado en el requerimiento del documento de la prueba.
CREATE PROCEDURE spListEmployeesByDate
	@HireDate DATETIME  
AS
BEGIN
    SELECT 
		EmployeeId,FirstName,LastName,Email,PhoneNumber,HireDate 
	FROM Employees
	WHERE @HireDate < HireDate;
END
GO




