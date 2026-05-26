create database Concesionario;
use concesionario;

create table fichasclientes
(
	IDFichaCliente int primary key auto_increment not null,
    nombre varchar(25),
    apellido varchar(25),
    DNI int,
    direccion varchar(25),
    telefono int
);

create table coches
(
	IDCoche int primary key auto_increment not null,
    matricula varchar(7),
    Modelo varchar(25),
    Marcha varchar(25),
    color varchar(25)
);
create table usados
(
	IDUsado int primary key auto_increment not null,
    IDCoche int,
    foreign key (IDCoche) references Coches(IDCoche),
    kilometraje float
);
create table nuevos
(
	IDNuevo int primary key auto_increment not null,
    IDCoche int,
    foreign key (IDCoche) references Coches(IDCoche),
    Stock int
);
create table ventas
(
	IDVenta int primary key auto_increment not null,
    IDCoche int,
    foreign key (IDCoche) references Coches(IDCoche),
    IDFichaCliente int,
    foreign key (IDFichaCliente) references fichasclientes(IDFichaCliente),
    total float,
    Fecha date
);
create table mecanicos
(
    IDMecanico int primary key auto_increment not null,
    nombre varchar(25),
    apellido varchar(25),
    DNI int(10),
    FechaContratacion date,
    salario int(8) 
);
create table reparaciones
(
	IDReparacion int primary key auto_increment not null,
    IDCoche int,
    foreign key (IDCoche) references Coches(IDCoche),
    IDMecanico int,
    foreign key (IDMecanico) references mecanicos(IDMecanico),
    horas float,
    Fecha date
);