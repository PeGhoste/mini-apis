CREATE DATABASE DBInventario;
GO
USE DBInventario;
GO

CREATE TABLE Productos(
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500) NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Categoria NVARCHAR(50) NULL
);
GO

INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, Categoria)
VALUES ('Producto 1', 'Descripción del producto 1', 10.99, 100, 'Categoría A');
GO