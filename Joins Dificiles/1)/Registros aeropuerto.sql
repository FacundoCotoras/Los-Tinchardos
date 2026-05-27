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
('2026-05-10', 'EZEIZA', 'Cordoba', 1),
('2026-05-15', 'EZEIZA', 'Mendoza', 2),
('2026-04-20', 'Aeroparque', 'Salta', 3),
('2026-05-01', 'Cordoba', 'Ushuaia', 4),
('2026-05-25', 'Rosario', 'Iguazu', 5);
INSERT INTO Tickets (precio, tipo, id_pasajero, id_vuelo) VALUES
(1500, 'Comercial', 1, 1),
(2500, 'P.clase', 2, 1),
(800, 'Comercial', 3, 2),
(3000, 'P.clase', 4, 2),
(600, 'Comercial', 5, 3);
