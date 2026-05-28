create database ecommerce_tecnologia;
-- drop database ecommerce_tecnologia
use ecommerce_tecnologia;

create table categorias
(
    IDCategoria int auto_increment primary key not null,
    nombre varchar(25)
);

create table productos
(
    IDProducto int auto_increment primary key,
    Nombre varchar(25),
    Precio decimal,
    IDCategoria int,
    foreign key (IDCategoria) references categorias(IDCategoria)
);

create table detalleventa
(
    IDDetalle int auto_increment primary key,
    IDProducto int,
    Cantidad int,
    PrecioUnidad decimal,
    fecha date,

    foreign key (IDProducto) references productos(IDProducto)
);

