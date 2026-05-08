-- Drop DB
USE master;
DROP DATABASE IF EXISTS DBLogin;
GO

-- Create DB
CREATE DATABASE DBLogin;
GO
USE DBLogin;
GO

-- Entidades
CREATE TABLE Empleados(
	idEmpleado INT IDENTITY(1,1) PRIMARY KEY, -- Atributos
	nombres NVARCHAR(50) NOT NULL,
	apellidos NVARCHAR(50) NOT NULL,
	edad INT NOT NULL,
	pais NVARCHAR(20)
);

CREATE TABLE Usuarios(
	idUsuario INT IDENTITY (1,1) PRIMARY KEY,
	usuario NVARCHAR(20) NOT NULL,
	pass NVARCHAR(20) NOT NULL,
	fk_IdEmpleado INT,
	FOREIGN KEY (fk_IdEmpleado) REFERENCES Empleados(idEmpleado)
);
GO

-- Inserts
-- Employees
INSERT INTO Empleados (nombres, apellidos, edad, pais) VALUES
('Juan', 'Perez', 25, 'Guatemala'),
('Maria', 'Lopez', 30, 'Mexico'),
('Carlos', 'Gomez', 22, NULL),
('Ana', 'Martinez', 28, 'Guatemala'),
('Luis', 'Rodriguez', 35, 'El Salvador'),
('Sofia', 'Hernandez', 19, NULL),
('Pedro', 'Ramirez', 40, 'Mexico'),
('Lucia', 'Torres', 27, 'Guatemala'),
('Diego', 'Flores', 33, ''),
('Elena', 'Vasquez', 45, 'El Salvador');
GO

-- Users
INSERT INTO Usuarios (usuario, pass, fk_IdEmpleado) VALUES
('juanp', '1234', 1),
('marial', '1234', 2),
('anamtz', '1234', 4),
('luisr', '1234', 5),
('pedror', '1234', 7),
('luciat', '1234', 8),
('elenav', '1234', 10);
GO


-- Statement Procedures
-- Create
CREATE PROCEDURE sp_CrearEmpleado
	@nombres NVARCHAR(50),
	@apellidos NVARCHAR(50),
	@edad INT
AS
BEGIN
	INSERT INTO Empleados(nombres,apellidos,edad) VALUES (@nombres,@apellidos,@edad);
END;
GO

EXEC sp_CrearEmpleado 'Hola', 'Mundo', 20;
SELECT * FROM Empleados;
GO

-- Update
CREATE PROCEDURE sp_ActualizarEmpleado
	@idEmpleado INT,
	@nombres NVARCHAR(50),
	@apellidos	NVARCHAR(50),
	@edad	INT,
	@pais NVARCHAR(20)
AS
BEGIN
	UPDATE Empleados
		SET nombres = @nombres,
			apellidos = @apellidos,
			edad = @edad,
			pais = @pais
		WHERE idEmpleado = @idEmpleado;
END;
GO
EXEC sp_ActualizarEmpleado 1, 'Mundo', 'Hola', 22, 'Guatemala';
SELECT * FROM Empleados;

-- ========================================
-- PARTE 1: BÁSICOS + FILTROS
-- ========================================

-- Ejercicio 1: Obtén todos los empleados que no tienen país asignadoRE
SELECT * FROM Empleados WHERE pais IS NOT NULL OR TRIM(pais) = '';

-- Ejercicio 2: Lista los empleados cuya edad sea mayor a 25 y menor a 40
SELECT * FROM Empleados WHERE edad BETWEEN 25 AND 40; 

-- Ejercicio 3: Obtén empleados cuyo apellido contenga la letra "o"
SELECT * FROM Empleados WHERE apellidos LIKE '%o%';

-- ========================================
-- PARTE 2: ORDER BY
-- ========================================

-- Ejercicio 4: Lista todos los empleados ordenados por:
-- 1. País (A-Z)
-- 2. Edad (de mayor a menor dentro del mismo país)
SELECT * FROM Empleados ORDER BY pais ASC, edad DESC;

-- ========================================
-- PARTE 3: GROUP BY
-- ========================================

-- Ejercicio 5: Muestra la cantidad de empleados por edad
SELECT e.edad, COUNT(*) as totalEmpleados FROM Empleados e GROUP BY edad;

-- Ejercicio 6: Muestra la edad promedio de todos los empleados,
-- pero solo por país que no sea NULL
SELECT AVG(e.edad) AS edadPromedio, e.pais 
FROM Empleados e 
WHERE e.pais IS NOT NULL OR TRIM(e.pais) = ''
GROUP BY e.pais;

-- Ejercicio 7: Muestra los países donde hay más de 2 empleados
SELECT pais, COUNT(*) as cantidadEmpleados 
FROM Empleados 
WHERE pais IS NOT NULL OR TRIM(pais) = '' 
GROUP BY pais HAVING COUNT(*) > 2; -- HAVING es para filtrar resultados después de agrupar

-- ========================================
-- PARTE 4: JOINS
-- ========================================

-- Ejercicio 8: Muestra:
-- usuario
-- nombre del empleado
-- país
-- (Solo los que sí tienen usuario)
SELECT u.usuario, e.nombres, e.pais FROM Empleados e JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado;

-- Ejercicio 9: Muestra todos los empleados y su usuario (si tienen)
SELECT e.*, u.usuario FROM Empleados e LEFT JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado;

-- Ejercicio 10: Cuenta cuántos usuarios hay por edad del empleado
SELECT e.edad, COUNT(*) as usuariosEdadEmpleo FROM Empleados e JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado GROUP BY e.edad;

-- ========================================
-- PARTE 5: LÓGICA
-- ========================================

-- Ejercicio 11: Obtén los empleados que tienen la edad máxima
SELECT nombres, edad 
FROM Empleados 
WHERE edad = (SELECT MAX(edad) FROM Empleados);

-- Ejercicio 12: Obtén los empleados que tienen la edad mínima
SELECT nombres, edad
FROM Empleados
WHERE edad = (SELECT MIN(edad) FROM Empleados);

-- Ejercicio 13: Lista los empleados cuya edad es mayor al promedio general
SELECT nombres, edad
FROM Empleados
WHERE edad > (SELECT AVG(edad) FROM Empleados);

-- ========================================
-- PARTE 6: SUBCONSULTAS
-- ========================================

-- Ejercicio 14: Obtén los usuarios cuyo empleado tiene la edad más alta
SELECT u.*, e.nombres as Empleado
FROM Empleados e 
JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado
WHERE edad = (SELECT MAX(edad) FROM Empleados);

-- Ejercicio 15: Lista los países junto con la cantidad de usuarios
-- que pertenecen a ese país
SELECT e.pais, COUNT(u.fk_IdEmpleado) as Usuarios 
FROM Empleados e JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado
GROUP BY e.pais;

-- ========================================
-- PARTE 7: BONUS
-- ========================================

-- Ejercicio 16: Muestra:
-- país
-- cantidad de empleados
-- edad promedio
-- Ordenado por el promedio de edad de mayor a menor
SELECT pais, COUNT(idEmpleado) as Empleados, AVG(edad) AS EdadPromedio 
FROM Empleados
WHERE pais IS NOT NULL AND TRIM(pais) <> ''
GROUP BY pais
ORDER BY EdadPromedio DESC;

-- Ejercicio 17: Obtén los empleados que NO tienen usuario asignado
SELECT e.*, u.idUsuario FROM Empleados e LEFT JOIN Usuarios u ON u.fk_IdEmpleado = e.idEmpleado
WHERE u.fk_IdEmpleado IS NULL;
