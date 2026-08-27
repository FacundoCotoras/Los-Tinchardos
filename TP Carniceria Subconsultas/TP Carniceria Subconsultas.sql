CREATE DATABASE carniceria;
-- DROP DATABASE carniceria;
USE carniceria;

CREATE TABLE Clientes (
    IDCliente int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nombre varchar(100),
    telefono varchar(20)
);

CREATE TABLE Cortes_de_Carne (
    IDcc int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nombre varchar(100),
    precio_kg decimal(10, 2)
);

CREATE TABLE Carniceros (
    IDcarnicero int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    nombre varchar(100),
    telefono varchar(20),
    DNI varchar(20)
);

CREATE TABLE Pedido (
    IDpedido int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    IDcc int,
    cantidad int,
    FOREIGN KEY (IDcc) REFERENCES Cortes_de_Carne(IDcc)
);

CREATE TABLE Ventas (
    IDventa int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    IDcarnicero int,
    IDcliente int,
    IDpedido int,
    precioT decimal(10, 2),
    FOREIGN KEY (IDcarnicero) REFERENCES Carniceros(IDcarnicero),
    FOREIGN KEY (IDcliente) REFERENCES Clientes(IDCliente),
    FOREIGN KEY (IDpedido) REFERENCES Pedido(IDpedido)
);


INSERT INTO Clientes (nombre, telefono) VALUES 
('Juan Pérez', '1122334455'),
('María López', '1155667788'),
('Carlos Gómez', '1199001122');

INSERT INTO Cortes_de_Carne (nombre, precio_kg) VALUES 
('Asado', 8500.00),
('Vacío', 9200.00),
('Bife de Lomo', 11000.00);

INSERT INTO Carniceros (nombre, telefono, DNI) VALUES 
('Ricardo Díaz', '1133445566', '20123456'),
('José Martínez', '1177889900', '23987654'),
('Luis Rodríguez', '1144556677', '27456123');

INSERT INTO Pedido (IDcc, cantidad) VALUES 
(1, 2),
(2, 1),
(3, 3);

INSERT INTO Ventas (IDcarnicero, IDcliente, IDpedido, precioT) VALUES 
(1, 1, 1, 17000.00),
(2, 2, 2, 9200.00),
(3, 3, 3, 33000.00);


SELECT c.nombre
FROM Cortes_de_Carne c
WHERE c.IDcc = (
    SELECT p.IDcc
    FROM Pedido p
    JOIN Ventas v ON p.IDpedido = v.IDpedido
    GROUP BY p.IDcc
    ORDER BY COUNT(v.IDventa) DESC
    LIMIT 1
);


SELECT cl.nombre
FROM Clientes cl
WHERE cl.IDCliente = (
    SELECT v.IDcliente
    FROM Ventas v
    GROUP BY v.IDcliente
    ORDER BY COUNT(v.IDventa) DESC
    LIMIT 1
);


SELECT ca.nombre
FROM Carniceros ca
WHERE ca.IDcarnicero = (
    SELECT v.IDcarnicero
    FROM Ventas v
    GROUP BY v.IDcarnicero
    ORDER BY COUNT(v.IDventa) DESC
    LIMIT 1
);


SELECT 
    (SELECT cl.nombre FROM Clientes cl WHERE cl.IDCliente = v.IDcliente) AS cliente,
    (SELECT c.nombre FROM Pedido p JOIN Cortes_de_Carne c ON p.IDcc = c.IDcc WHERE p.IDpedido = v.IDpedido) AS corte,
    (SELECT ca.nombre FROM Carniceros ca WHERE ca.IDcarnicero = v.IDcarnicero) AS carnicero
FROM Ventas v
ORDER BY v.precioT DESC
LIMIT 1;



SELECT 
    c.nombre,
    (
        SELECT COUNT(v.IDventa)
        FROM Pedido p
        JOIN Ventas v ON p.IDpedido = v.IDpedido
        WHERE p.IDcc = c.IDcc
    ) AS total_ventas
FROM Cortes_de_Carne c;


