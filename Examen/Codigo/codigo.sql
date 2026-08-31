create database Examen;
-- drop database Examen
use Examen;

create table Tecnicos
(
ID_Tecnico int primary key auto_increment not null,
Nombre varchar(25), 
Apellido varchar(25),
TipoServicio enum ("Preventivo", "Correctivo")
);

create table Marcas
(
ID_Marca int primary key auto_increment not null,
Nombre varchar(25)
);

create table Autos
(
ID_Auto int primary key auto_increment not null,
Modelo varchar(25),
Precio float,
Bateria float,
ID_Marca int,
foreign key (ID_Marca) references Marcas(ID_Marca)
);


create table Organizaciones
(
ID_Organizacion int primary key auto_increment not null,
Nombre varchar(25),
ID_Auto int,
foreign key (ID_Auto) references Autos(ID_Auto),
ID_Tecnico int,
foreign key (ID_Tecnico) references Tecnicos(ID_Tecnico)
);

create table Revisiones
(
ID_Revision int primary key auto_increment not null,
Fecha date,
Estado enum ("Perfecto","Malo","En revision"),
Costo float,
ID_Auto int,
foreign key (ID_Auto) references Autos(ID_Auto),
ID_Tecnico int,
foreign key (ID_Tecnico) references Tecnicos(ID_Tecnico)
);

insert into Tecnicos(Nombre, Apellido, TipoServicio) values
("Agustin", "Barrionuevo", "Preventivo"),
("Santiago", "Fidani", "Correctivo"),
("Federico", "Bouzon", "Preventivo");

insert into Marcas(Nombre) values
("Ferrari"),
("BMW"),
("Peugeot");

insert into Autos(Modelo, Precio, ID_Marca, Bateria) values
("Raptor", 1000, 3, 1000),
("Golf GTI", 40000, 2, 500),
("Mitsubishi", 15000, 3, 50);

insert into Organizaciones(ID_Tecnico, ID_Auto, Nombre) values
(1, 1, "Boca"),
(2, 2, "River"),
(3, 3, "Estudiantes");

insert into Revisiones(Fecha, Estado, Costo, ID_Auto, ID_Tecnico) values
("2020-04-26", "Perfecto", 1000, 1, 1),
("2024-07-05", "Malo", 500, 2 ,1  ),
("2025-04-28", "En Revision", 600, 3, 1),
("2021-04-28", "En Revision", 800, 3, 1);

select Autos.Modelo, Organizacion.Nombre, Tecnico.Nombre
from Autos
inner join Organizaciones
on Autos.ID_Auto = Organizacion.ID_Auto
inner join Tecnicos
on Tecnicos.ID_Tecnico = Organizacion.ID_Tecnico
group by Autos.Modelo;

select Revisiones.Costo
from Revisiones 
where Revisiones.Costo >(
select avg(Revisiones.Costo) 
from Revisiones
);

Select * from Revisiones;

select Tecnicos.Nombre, Revisiones.ID_Tecnico
from Tecnicos
inner join Revisiones
on Tecnicos.ID_Tecnico = Revisiones.ID_Tecnico
group by Revisiones.ID_Tecnico
having Revisiones.ID_Tecnico > 3;

select Auto.Modelo, Revisiones.ID_Auto
from Autos
inner join Revisiones
on Revisiones.ID_Auto = Autos.ID_Auto
order by Re ascii()
limit 1;

