-- Usar la base de datos
USE Gimnasio;

-- Registros para Planes
INSERT INTO Planes (tipo, costo) VALUES
('Premiun', 89.99),
('Basico', 45.50),
('Premiun', 99.99),
('Basico', 39.90),
('Premiun', 120.00);

-- Registros para Socios
INSERT INTO Socios (nombre, tipo, fecha_alta) VALUES
('Juan Perez', 'Comercial', '2024-01-15'),
('Maria Gomez', 'P.clase', '2024-02-20'),
('Carlos Diaz', 'Comercial', '2024-03-10'),
('Ana Lopez', 'P.clase', '2024-04-05'),
('Luis Torres', 'Comercial', '2025-01-08');

-- Registros para Pagos
INSERT INTO Pagos (id_socio, id_plan, monto) VALUES
(1, 1, 89.99),
(2, 2, 45.50),
(3, 3, 99.99),
(4, 4, 39.90),
(5, 5, 120.00);