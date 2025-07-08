CREATE DATABASE Tienda

USE Tienda

CREATE TABLE Ventas (
    id INT PRIMARY KEY IDENTITY,
    producto VARCHAR(100) NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
	totalGanacia DECIMAL(10, 2) NOT NULL,
    creadoPor VARCHAR(50),
    creadoEn DATETIME DEFAULT GETDATE(),
    actualizadoPor VARCHAR(50),
    actualizadoEn DATETIME
);



INSERT INTO Ventas (producto, cantidad, precio, totalGanacia, creadoPor, creadoEn, actualizadoPor, actualizadoEn)
VALUES 
('Laptop HP', 2, 12000.00, 24000.00, 'admin', '', '', ''),
('Mouse Logitech', 5, 350.00, 1750.00, 'admin', '', '', ''),
('Monitor Samsung 24"', 1, 4500.00, 4500.00, 'admin', '', '', ''),
('Teclado Mec�nico', 3, 1100.00, 3300.00, 'admin', '', '', ''),
('Aud�fonos Sony', 4, 850.00, 3400.00, 'admin', '', '', ''),
('Tablet Lenovo', 1, 7800.00, 7800.00, 'admin', '', '', ''),
('C�mara Web', 2, 950.00, 1900.00, 'admin', '', '', '');




CREATE PROCEDURE [dbo].[sp_Create_Venta]
	@producto VARCHAR(100),
    @cantidad INT,
    @precio DECIMAL(10, 2),
	@totalGanancia DECIMAL(10, 2),
    @creadoPor VARCHAR(50),
    @creadoEn DATETIME,
    @actualizadoPor VARCHAR(50),
    @actualizadoEn DATETIME
AS
BEGIN
	INSERT INTO Ventas(producto, cantidad, precio, totalGanancia, creadoPor, creadoEn, actualizadoPor, actualizadoEn)
    VALUES (@producto, @cantidad, @precio, @totalGanancia, @creadoPor, @creadoEn, @actualizadoPor, @actualizadoEn);
    SELECT SCOPE_IDENTITY() AS Id;
END


CREATE PROCEDURE [dbo].[sp_Update_Venta]
	@id INT,
	@producto VARCHAR(100),
    @cantidad INT,
    @precio DECIMAL(10, 2),
	@totalGanancia DECIMAL(10, 2),
    @creadoPor VARCHAR(50),
    @creadoEn DATETIME,
    @actualizadoPor VARCHAR(50),
    @actualizadoEn DATETIME
AS
BEGIN
	UPDATE Ventas
	SET
		producto = @producto,
		cantidad = @cantidad,
		precio = @precio,
		totalGanancia = @totalGanancia,
		creadoPor = @creadoPor,
		creadoEn = @creadoEn,
		actualizadoPor = @actualizadoPor,
		actualizadoEn = @actualizadoEn
	WHERE id = @id;
END


CREATE PROCEDURE [dbo].[sp_Delete_Venta]
	@id INT
AS
BEGIN
	DELETE FROM Ventas WHERE id = @id;
END


CREATE PROCEDURE [dbo].[sp_GetById_Venta]
	@id INT
AS
BEGIN
	SELECT * FROM Ventas WHERE id = @id
END


CREATE PROCEDURE [dbo].[sp_GetAll_Venta]
AS
BEGIN
	SELECT * FROM Ventas
END