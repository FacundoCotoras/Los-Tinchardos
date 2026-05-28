

insert into edificios (nombre, Direccion)
values
('torre nebula', 'av. solar 1450'),
('residencias quantum', 'calle atlas 932'),
('edificio eclipse', 'boulevard central 210'),
('skyline point', 'av. horizonte 778'),
('portal aurora', 'calle luna 554');

insert into unidades (NroPiso, IDEdificio)
values
(1, 1),
(3, 1),
(5, 2),
(7, 3),
(10, 5);

insert into expensas (IDUnidad, Monto, Estado)
values
(1, 18500, 'pago'),
(2, 22300, 'impago'),
(3, 19800, 'pago'),
(4, 27500, 'impago'),
(5, 31200, 'pago');


