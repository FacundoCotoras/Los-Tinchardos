create database carniceria;
-- drop database carniceria;
use carniceria;

create table clientes (
    idcliente int primary key auto_increment not null,
    nombre varchar(100),
    telefono varchar(20)
);

create table cortes_de_carne (
    idcc int primary key auto_increment not null,
    nombre varchar(100),
    precio_kg decimal(10, 2)
);

create table carniceros (
    idcarnicero int primary key auto_increment not null,
    nombre varchar(100),
    telefono varchar(20),
    dni varchar(20)
);

create table pedido (
    idpedido int primary key auto_increment not null,
    idcc int,
    cantidad int,
    foreign key (idcc) references cortes_de_carne(idcc)
);

create table ventas (
    idventa int primary key auto_increment not null,
    idcarnicero int,
    idcliente int,
    idpedido int,
    preciot decimal(10, 2),
    foreign key (idcarnicero) references carniceros(idcarnicero),
    foreign key (idcliente) references clientes(idcliente),
    foreign key (idpedido) references pedido(idpedido)
);


insert into clientes (nombre, telefono) values 
('juan pérez', '1122334455'),
('maría lópez', '1155667788'),
('carlos gómez', '1199001122');

insert into cortes_de_carne (nombre, precio_kg) values 
('asado', 8500.00),
('vacío', 9200.00),
('bife de lomo', 11000.00);

insert into carniceros (nombre, telefono, dni) values 
('ricardo díaz', '1133445566', '20123456'),
('josé martínez', '1177889900', '23987654'),
('luis rodríguez', '1144556677', '27456123');

insert into pedido (idcc, cantidad) values 
(1, 2),
(2, 1),
(3, 3);

insert into ventas (idcarnicero, idcliente, idpedido, preciot) values 
(1, 1, 1, 17000.00),
(2, 2, 2, 9200.00),
(3, 3, 3, 33000.00);


select c.nombre
from cortes_de_carne c
where c.idcc = (
    select p.idcc
    from pedido p
    join ventas v on p.idpedido = v.idpedido
    group by p.idcc
    order by count(v.idventa) desc
    limit 1
);


select cl.nombre
from clientes cl
where cl.idcliente = (
    select v.idcliente
    from ventas v
    group by v.idcliente
    order by count(v.idventa) desc
    limit 1
);


select ca.nombre
from carniceros ca
where ca.idcarnicero = (
    select v.idcarnicero
    from ventas v
    group by v.idcarnicero
    order by count(v.idventa) desc
    limit 1
);


select 
    (select cl.nombre from clientes cl where cl.idcliente = v.idcliente) as cliente,
    (select c.nombre from pedido p join cortes_de_carne c on p.idcc = c.idcc where p.idpedido = v.idpedido) as corte,
    (select ca.nombre from carniceros ca where ca.idcarnicero = v.idcarnicero) as carnicero
from ventas v
order by v.preciot desc
limit 1;



select 
    c.nombre,
    (
        select count(v.idventa)
        from pedido p
        join ventas v on p.idpedido = v.idpedido
        where p.idcc = c.idcc
    ) as total_ventas
from cortes_de_carne c;


