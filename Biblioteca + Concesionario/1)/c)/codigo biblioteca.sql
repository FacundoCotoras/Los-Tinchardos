

-- AUTORES
INSERT INTO Autores (nombre, apellido, nacionalidad) VALUES
('Gabriel', 'García Márquez', 'Colombiana'),
('Jorge Luis', 'Borges', 'Argentina'),
('Isabel', 'Allende', 'Chilena'),
('Mario', 'Vargas Llosa', 'Peruana'),
('Julio', 'Cortázar', 'Argentina');

-- EDITORIALES
INSERT INTO Editoriales (nombre, anio_fundacion, ubicacion) VALUES
('Sudamericana', '1939-12-31', 'Buenos Aires'),
('Alfaguara', '1964-10-01', 'Madrid'),
('Planeta', '1949-01-01', 'Barcelona'),
('Anagrama', '1969-05-01', 'Barcelona'),
('Tusquets', '1969-01-01', 'Barcelona');

-- LIBROS 
-- ALTER TABLE Libros ADD COLUMN id_editorial INT; -- necesario por el error
INSERT INTO Libros (titulo, ISBN, id_editorial, paginas) VALUES
('Cien años de soledad', 9780307474728, 1, 417),
('El Aleph', 9788420428327, 1, 192),
('La casa de los espíritus', 9788401352898, 2, 512),
('La ciudad y los perros', 9788420471835, 3, 416),
('Rayuela', 9788437600473, 1, 736);

-- AUTORES_LIBROS 
-- ALTER TABLE Autores_Libros ADD COLUMN id_libro INT, ADD COLUMN id_autor INT; -- necesario
INSERT INTO Autores_Libros (id_libro, id_autor) VALUES
(1, 1), -- Cien años - García Márquez
(2, 2), -- El Aleph - Borges
(3, 3), -- La casa... - Allende
(4, 4), -- La ciudad... - Vargas Llosa
(5, 5); -- Rayuela - Cortázar

-- EJEMPLARES
-- ALTER TABLE ejemplares ADD COLUMN id_libro INT; -- necesario
INSERT INTO ejemplares (localizacion, id_libro) VALUES
('Estante A1', 1),
('Estante A2', 1),
('Estante B1', 2),
('Estante C1', 3),
('Estante D1', 4);

-- USUARIOS
INSERT INTO Usuarios (nombre, apellido, direccion, telefono) VALUES
('Ana', 'López', 'Av. Corrientes 1234', 1155443322),
('Carlos', 'Méndez', 'Av. Santa Fe 456', 1144332211),
('Lucía', 'Gómez', 'Av. Rivadavia 789', 1133221100),
('Pedro', 'Ramírez', 'Av. Cabildo 321', 1122110099),
('Sofía', 'Fernández', 'Av. Belgrano 654', 1111009988);

-- PRESTAMOS 
INSERT INTO Prestamos (fecha_pre, fecha_dev, id_usuario, id_ejemplar) VALUES
('2026-04-01', '2026-04-15', 1, 1),
('2026-04-03', '2026-04-17', 2, 2),
('2026-04-05', '2026-04-19', 3, 3),
('2026-04-10', '2026-04-24', 4, 4),
('2026-04-12', '2026-04-26', 5, 5);