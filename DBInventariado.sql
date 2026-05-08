USE master;
DROP DATABASE IF EXISTS DBInventariado;
GO

CREATE DATABASE DBInventariado;
GO
USE DBInventariado;
GO

CREATE TABLE Categorias(
	idCategoria INT IDENTITY(1,1) PRIMARY KEY,
	categoria NVARCHAR(20) NOT NULL UNIQUE,
	descripcion NVARCHAR(100),
	estado NVARCHAR(10) DEFAULT 'Activo' CHECK(estado IN ('Activo', 'Inactivo')),
);

CREATE TABLE Productos(
	idProducto INT IDENTITY(1,1) PRIMARY KEY,
	nombre NVARCHAR(20) NOT NULL,
	descripcion NVARCHAR(100),
	precio DECIMAL (10,2) NOT NULL,
	stock INT NOT NULL check(stock >= 0),
	fecha DATE DEFAULT CURRENT_TIMESTAMP,
	estado NVARCHAR(10) DEFAULT 'Activo' CHECK(estado IN ('Activo', 'Inactivo')),
	fk_idCategoria INT NOT NULL,
	FOREIGN KEY (fk_idCategoria) REFERENCES Categorias(idCategoria)
);

SELECT * FROM Categorias;

SELECT * FROM Categorias WHERE idCategoria = 1;