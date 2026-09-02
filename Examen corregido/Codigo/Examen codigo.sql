create database Examen;
-- drop database Examen
use Examen;

create table Organizaciones
(
ID_Organizacion int primary key auto_increment not null,
Nombre varchar(25)
);

create table Marcas
(
ID_Marca int primary key auto_increment not null,
Nombre varchar(25)
);

create table Tecnicos
(
ID_Tecnico int primary key auto_increment not null,
Nombre varchar(25),
Apellido varchar(25)
);

create table Autos
(
ID_Auto int primary key auto_increment not null,
Modelo varchar(25),
Precio float,
Capacidadbateria float,
ID_Marca int,
ID_Organizacion int,
foreign key (ID_Marca) references Marcas(ID_Marca),
foreign key (ID_Organizacion) references Organizaciones(ID_Organizacion)
);

create table Revisiones
(
ID_Revision int primary key auto_increment not null,
Fecha date,
Estado enum ("Perfecto","Malo","En Revision"),
Nivelbateria float,
Costo float,
Tiposervicio enum ("Preventivo","Correctivo"),
ID_Auto int,
ID_Tecnico int,
foreign key (ID_Auto) references Autos(ID_Auto),
foreign key (ID_Tecnico) references Tecnicos(ID_Tecnico)
);

create table Piezas
(
ID_Pieza int primary key auto_increment not null,
Nombre varchar(25),
Precio float
);

create table Revisiones_Piezas
(
ID_Revision_Pieza int primary key auto_increment not null,
ID_Revision int,
ID_Pieza int,
Cantidad int,
foreign key (ID_Revision) references Revisiones(ID_Revision),
foreign key (ID_Pieza) references Piezas(ID_Pieza)
);

insert into Organizaciones(Nombre) values
("Boca"),
("River"),
("Estudiantes");


insert into Marcas(Nombre) values
("Ferrari"),
("BMW"),
("Peugeot");


insert into Tecnicos(Nombre, Apellido) values
("Agustin", "Barrionuevo"),
("Santiago", "Fidani"),
("Federico", "Bouzon");


insert into Autos(Modelo, Precio, Capacidadbateria, ID_Marca, ID_Organizacion) values
("Raptor", 1000, 1000, 3, 1),
("Golf GTI", 40000, 500, 2, 1),
("Mitsubishi", 15000, 50, 3, 2),
("Porsche Taycan", 90000, 800, 1, 2),
("Tesla Model S", 75000, 1000, 2, 3);


insert into Revisiones(Fecha, Estado, Nivelbateria, Costo, Tiposervicio, ID_Auto, ID_Tecnico) values
("2020-04-26", "Perfecto", 90, 1000, "Preventivo", 1, 1),
("2024-07-05", "Malo", 50, 500, "Correctivo", 2, 1),
("2025-04-28", "En Revision", 70, 600, "Preventivo", 3, 2),
("2021-04-28", "En Revision", 40, 800, "Correctivo", 3, 1),
("2025-06-15", "Perfecto", 85, 1200, "Preventivo", 4, 3);


insert into Piezas(Nombre, Precio) values
("Bateria", 5000),
("Freno", 2000),
("Motor", 10000);


insert into Revisiones_Piezas(ID_Revision, ID_Pieza, Cantidad) values
(1, 1, 1),
(2, 2, 2),
(3, 3, 1),
(4, 2, 1),
(5, 1, 1);

select Autos.Modelo, Organizaciones.Nombre, Tecnicos.Nombre
from Autos
inner join Organizaciones
on Autos.ID_Organizacion = Organizaciones.ID_Organizacion
inner join Revisiones
on Revisiones.ID_Auto = Autos.ID_Auto
inner join Tecnicos
on Revisiones.ID_Tecnico = Tecnicos.ID_Tecnico
group by Autos.Modelo;

select Revisiones.Costo 
from Revisiones
where Revisiones.Costo > (
select avg(Revisiones.Costo)
from Revisiones
);

select Tecnicos.Nombre, Revisiones.ID_Revision
from Tecnicos
inner join Revisiones
on Revisiones.ID_Tecnico = Tecnicos.ID_Tecnico
group by Tecnicos.Nombre
having count(Revisiones.ID_Revision) > 3;

select Autos.Modelo, Revisiones.ID_revision
from Autos
inner join Revisiones
on Autos.ID_Auto = Revisiones.ID_Auto
group by Autos.Modelo asc
limit 1;

select Organizaciones.Nombre, Revisiones.Nivelbateria
from Organizaciones
inner join Autos
on Autos.ID_Organizacion = Organizaciones.ID_Organizacion
inner join Revisiones
on Revisiones.ID_Auto = Autos.ID_Auto
where Revisiones.Nivelbateria < (
select avg(Revisiones.Nivelbateria)
from Revisiones
);

select Tecnicos.Nombre, count(Revisiones.Tiposervicio)
from Tecnicos
inner join Revisiones
on Tecnicos.ID_Tecnico = Revisiones.ID_Tecnico
where Revisiones.Tiposervicio = "Correctivo"
group by Tecnicos.Nombre 
order by count(Revisiones.Tiposervicio) desc
limit 3;