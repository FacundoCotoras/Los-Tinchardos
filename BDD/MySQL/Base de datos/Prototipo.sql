create database pokemon;
-- drop database pokemon
use pokemon;

create table Usuarios(
IDusuario int auto_increment primary key,
nombre varchar(25),
apellido varchar(25),
correo varchar(25),
contraseña int(12)
);
create table Tipos(
IDtipo int auto_increment primary key,
nombre varchar(15)
);
create table Especies(
IDespecie int auto_increment primary key,
nombre varchar(25),
lugar
IDtipo1 int,
IDtipo2 int not null,

foreign key (IDtipo1) references TIPOS(IDtipo),
foreign key (IDtipo2) references TIPOS(IDtipo)
);
