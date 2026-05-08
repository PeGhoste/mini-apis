USE master;
GO
DROP DATABASE IF EXISTS DBBancoEmpanadas;
GO

CREATE DATABASE DBBancoEmpanadas;
GO
USE DBBancoEmpanadas;
GO

CREATE TABLE Clientes(
	idCliente int identity(1,1) primary key,
	nombres nvarchar(20),
	apellidos nvarchar(20),
	edad int check(edad >=18),
	fechaNacimiento date default current_timestamp,
	estado nvarchar(10) DEFAULT 'Activo' check(estado in ('Activo','Inactivo'))
);

CREATE TABLE Cuentas(
	idCuenta int identity(1,1) primary key,
	tipoCuenta nvarchar(20) check(tipoCuenta in ('Ahorro', 'Monetaria')),
	numeroCuenta nvarchar(20) not null UNIQUE,
	saldo decimal(12,2) not null,
	fechaCreacion DATE default current_timestamp,
	estado nvarchar(10) DEFAULT 'Activo' check(estado in('Activo', 'Inactivo')),
	fk_idCliente int not null,
	foreign key (fk_idCliente) references Clientes(idCliente)
);
GO

INSERT INTO Clientes(nombres, apellidos, edad, estado) VALUES('Banco', 'Empanadas', '18', 'Activo');
INSERT INTO Cuentas(tipoCuenta, numeroCuenta, saldo, estado, fk_idCliente) VALUES ('Monetaria', '12345678', 1233515.11, 'Activo', 1);
go

SELECT * FROM Clientes;
SELECT * FROM Cuentas;