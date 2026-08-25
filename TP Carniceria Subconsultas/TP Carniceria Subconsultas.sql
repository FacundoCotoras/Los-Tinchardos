CREATE DATABASE carniceria;
-- drop database carniceria;
USE carniceria;

CREATE TABLE Clientes (
    IDCliente INT PRIMARY KEY AUTO_INCREMENT,
    nombre_c VARCHAR(100) NOT NULL,
    telefono VARCHAR(20)
);

CREATE TABLE Cortes_de_carnes (
    ID_CC INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    precio_kg DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Carniceros (
    ID_Carnicero INT PRIMARY KEY AUTO_INCREMENT,
    nombre_c VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    DNI VARCHAR(20) UNIQUE NOT NULL
);

CREATE TABLE Pedidos (
    IDPedido INT PRIMARY KEY AUTO_INCREMENT,
    ID_CC INT,
    IDCliente INT,
    FOREIGN KEY (ID_CC) REFERENCES Cortes_de_carnes(ID_CC),
    FOREIGN KEY (IDCliente) REFERENCES Clientes(IDCliente)
);

CREATE TABLE Ventas (
    IDVenta INT PRIMARY KEY AUTO_INCREMENT,
    IDPedido INT,
    telefono VARCHAR(20),
    DNI VARCHAR(20),
    ID_Carnicero INT,
    precioT DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (IDPedido) REFERENCES Pedidos(IDPedido),
    FOREIGN KEY (ID_Carnicero) REFERENCES Carniceros(ID_Carnicero)
);

INSERT INTO Clientes (nombre_c, telefono) VALUES 
('Juan Pérez', '1122334455'),
('María López', '1155667788'),
('Carlos Gómez', '1199001122');

INSERT INTO Cortes_de_carnes (nombre, precio_kg) VALUES 
('Asado', 8500.00),
('Vacío', 9200.00),
('Bife de Lomo', 11000.00);

INSERT INTO Carniceros (nombre_c, telefono, DNI) VALUES 
('Ricardo Díaz', '1133445566', '20123456'),
('José Martínez', '1177889900', '23987654'),
('Luis Rodríguez', '1144556677', '27456123');

INSERT INTO Pedidos (ID_CC, IDCliente) VALUES 
(1, 1),
(2, 2),
(3, 3);

INSERT INTO Ventas (IDPedido, telefono, DNI, ID_Carnicero, precioT) VALUES 
(1, '1122334455', '20123456', 1, 17000.00),
(2, '1155667788', '23987654', 2, 27600.00),
(3, '1199001122', '27456123', 3, 11000.00);

SELECT Cortes_de_carnes.nombre
FROM Cortes_de_carnes
JOIN Pedidos ON Cortes_de_carnes.ID_CC = Pedidos.ID_CC
JOIN Ventas ON Pedidos.IDPedido = Ventas.IDPedido
GROUP BY Cortes_de_carnes.ID_CC, Cortes_de_carnes.nombre
ORDER BY COUNT(Ventas.IDVenta) DESC
LIMIT 1;

SELECT Clientes.nombre_c
FROM Clientes
JOIN Pedidos ON Clientes.IDCliente = Pedidos.IDCliente
JOIN Ventas ON Pedidos.IDPedido = Ventas.IDPedido
GROUP BY Clientes.IDCliente, Clientes.nombre_c
ORDER BY COUNT(Ventas.IDVenta) DESC
LIMIT 1;


SELECT Carniceros.nombre_c
FROM Carniceros
JOIN Ventas ON Carniceros.ID_Carnicero = Ventas.ID_Carnicero
GROUP BY Carniceros.ID_Carnicero, Carniceros.nombre_c
ORDER BY COUNT(DISTINCT Ventas.DNI) DESC
LIMIT 1;


SELECT Clientes.nombre_c, Cortes_de_carnes.nombre, Carniceros.nombre_c
FROM Ventas
JOIN Pedidos ON Ventas.IDPedido = Pedidos.IDPedido
JOIN Clientes ON Pedidos.IDCliente = Clientes.IDCliente
JOIN Cortes_de_carnes ON Pedidos.ID_CC = Cortes_de_carnes.ID_CC
JOIN Carniceros ON Ventas.ID_Carnicero = Carniceros.ID_Carnicero
ORDER BY Ventas.precioT DESC
LIMIT 1;


SELECT Cortes_de_carnes.nombre, COUNT(Ventas.IDVenta)
FROM Cortes_de_carnes
LEFT JOIN Pedidos ON Cortes_de_carnes.ID_CC = Pedidos.ID_CC
LEFT JOIN Ventas ON Pedidos.IDPedido = Ventas.IDPedido
GROUP BY Cortes_de_carnes.ID_CC, Cortes_de_carnes.nombre;

