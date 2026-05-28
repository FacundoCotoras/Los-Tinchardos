
insert into categorias (nombre) values
('gaming extremo'),
('smart home'),
('audio premium'),
('movilidad tech'),
('oficina digital');

insert into productos (Nombre, Precio, IDCategoria) values
('teclado vortex x90', 1850, 1),
('mouse nebula pro', 950, 1),
('camara orbit cam', 3200, 2),
('auriculares pulse max', 2700, 3),
('tablet nova pad', 5200, 5);

insert into detalleventa (IDProducto, Cantidad, PrecioUnidad, fecha) values
(1, 2500, 1850, '2026-05-01'),
(2, 180, 950, '2026-05-03'),
(3, 120, 3200, '2026-05-05'),
(4, 90, 2700, '2026-05-08'),
(5, 75, 5200, '2026-05-10');

