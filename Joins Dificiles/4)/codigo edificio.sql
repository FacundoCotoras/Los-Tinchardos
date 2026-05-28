create database consorcio_urbano;
use consorcio_urbano;

create table edificios
(
    IDEdificio int auto_increment primary key,
    nombre varchar(25),
    Direccion varchar(25)
);

create table unidades
(
    IDUnidad int auto_increment primary key,
    NroPiso int(2),
    IDEdificio int,
    foreign key (IDEdificio) references edificios(IDEdificio)
);

create table expensas
(
    IDExpensa int auto_increment primary key,
    IDUnidad int,
    Monto decimal,
    Estado enum('pago', 'impago'),

    foreign key (IDUnidad) references unidades(IDUnidad)
);

