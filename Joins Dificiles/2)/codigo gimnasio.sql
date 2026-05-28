create database Gimnasio;
create table Planes(
id_plan int primary key auto_increment not null,
tipo enum('Premiun','Basico'),
costo decimal(4,2)
);
create table Socios(
id_socio int primary key auto_increment not null,
nombre varchar(25),
tipo enum("Comercial","P.clase"),
fecha_alta date
);
create table Pagos(
id_pago int primary key auto_increment not null,
id_socio int,
id_plan int,
foreign key(id_plan) references Planes(id_plan),
foreign key(id_socio) references Socios(id_socio),
monto decimal(10,2)
);