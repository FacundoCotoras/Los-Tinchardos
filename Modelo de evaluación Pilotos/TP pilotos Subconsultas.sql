create database formula_carreras;
use formula_carreras;

create table pilotos (
    id_piloto int primary key not null,
    nombre_c varchar(100),
    edad int
);

create table autos (
    id_auto int primary key not null,
    precio decimal(15,2),
    anio_presupuesto int
);

create table escuderia (
    id_escuderia int primary key not null,
    nombre varchar(100),
    presupuesto decimal(15,2),
    id_piloto int,
    id_auto int,
    foreign key (id_piloto) references pilotos(id_piloto),
    foreign key (id_auto) references autos(id_auto)
);

create table carreras (
    id_carrera int primary key not null,
    nombre varchar(100),
    pais varchar(50),
    anio int,
    km decimal(6,2)
);

create table participaciones (
    id_participacion int primary key not null,
    id_carrera int,
    id_piloto int,
    puesto int,
    foreign key (id_carrera) references carreras(id_carrera),
    foreign key (id_piloto) references pilotos(id_piloto)
);
insert into pilotos (id_piloto, nombre_c, edad) values 
(1, 'franco colapinto', 23),
(2, 'lewis hamilton', 41),
(3, 'max verstappen', 28);

insert into autos (id_auto, precio, anio_presupuesto) values 
(101, 15000000.00, 2026),
(102, 14500000.00, 2026),
(103, 16000000.00, 2026);

insert into escuderia (id_escuderia, nombre, presupuesto, id_piloto, id_auto) values 
(10, 'williams', 135000000.00, 1, 101),
(20, 'ferrari', 140000000.00, 2, 102),
(30, 'red bull', 145000000.00, 3, 103);

insert into carreras (id_carrera, nombre, pais, anio, km) values 
(501, 'gran premio de monaco', 'monaco', 2026, 260.28),
(502, 'gran premio de monza', 'italia', 2026, 306.72),
(503, 'gran premio de interlagos', 'brasil', 2026, 305.90);

insert into participaciones (id_participacion, id_carrera, id_piloto, puesto) values 
(1001, 501, 1, 8),
(1002, 501, 2, 3),
(1003, 502, 3, 1);

select p.nombre_c as piloto, e.nombre as escuderia
from pilotos p
join escuderia e on p.id_piloto = e.id_piloto;

select e.nombre, e.presupuesto
from escuderia e
where e.presupuesto > (
    select avg(es.presupuesto)
    from escuderia es
    where es.id_escuderia != e.id_escuderia
);

select * 
from autos 
where precio = (select max(precio) from autos);

select pais, nombre, anio, km
from carreras
where km > 20
order by pais, anio asc;

select c.anio, pi.edad, pi.nombre_c
from participaciones p
inner join carreras c on c.id_carrera = p.id_carrera
inner join pilotos pi on pi.id_piloto = p.id_piloto
where pi.edad > 25
  and c.anio > 2020
  and p.puesto = 1;


