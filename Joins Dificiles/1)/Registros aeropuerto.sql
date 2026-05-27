USE Aeropuerto;


INSERT INTO Aviones (modelo, capacidad) VALUES
('Boeing 737-800', 189),
('Airbus A320', 180),
('Boeing 787-9', 296),
('Embraer E190', 114),
('Airbus A350-900', 325);


INSERT INTO Pasajeros (nombreCompleto, DNI) VALUES
('Juan Perez', 32456789),
('Maria Gonzalez', 28945123),
('Carlos Lopez', 35678901),
('Ana Martinez', 30214567),
('Luis Fernandez', 33789012);


INSERT INTO Vuelos (fecha, origen, destino, id_avion) VALUES
('2026-06-15', 'Buenos Aires', 'Cordoba', 1),
('2026-06-16', 'Mendoza', 'Buenos Aires', 2),
('2026-06-17', 'Bariloche', 'Salta', 3),
('2026-06-18', 'Rosario', 'Ushuaia', 4),
('2026-06-19', 'Cordoba', 'Iguazu', 5);


INSERT INTO Tickets (precio, tipo, id_pasajero, id_vuelo) VALUES
(45000, 'Comercial', 1, 1),
(95000, 'P.clase', 2, 2),
(52000, 'Comercial', 3, 3),
(88000, 'P.clase', 4, 4),
(67000, 'Comercial', 5, 5);
