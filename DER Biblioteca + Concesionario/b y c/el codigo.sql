create database Biblioteca;

create table Usuarios(
 id_usuario int auto_increment primary key not null,
 nombre varchar(20) not null,
 apellido varchar(20) not null,
 telefono int(8) ,
 direccion varchar(20)
);

create table Prestamos(
id_prestamo int auto_increment primary key not null,
fecha_devolucion date,
fecha_prestamo date,
foreign key(id_usuario) references Usuarios(id_usuario)
);

create table Libros(
id_libro int auto_increment primary key not null,
titulo varchar(30),
ISBN int(13),
pagina int(5),
foreign key(id_editorial) references Editoriales(id_editorial),
foreign key(id_ejemplar) references Ejemplaeres(id_ejemplar)
);
create table Editoriales(
id_editorial int auto_increment primary key not null,
nombre varchar(30),
año_funcadacion date,
ubicaion varchar(20)  
);
create table Ejemplares(
id_ejemplar int auto_increment primary key not null,
localizacion varchar(20),
foreign key(id_libro) references Libros(id_libro)
);
create table Autores(
id_autor int auto_increment primary key not null,
nombre varchar(20),
apellido varchar(20),
nacionalidad varchar(20)
);
create table autores_libros(
foreign key(id_autor) references Autores(id_autor),
foreign key(id_libro) references Libros(id_libro)
);
insert into editoriales (nombre, año_funcadacion, ubicaion) values
('sudamericana', '1939-01-01', 'buenos aires'),
('alfaguara', '1964-01-01', 'madrid'),
('planeta', '1949-01-01', 'barcelona'),
('siglo xxi', '1965-01-01', 'méxico'),
('tusquets', '1969-01-01', 'barcelona');

insert into autores (nombre, apellido, nacionalidad) values
('gabriel', 'garcía márquez', 'colombiana'),
('isabel', 'allende', 'chilena'),
('jorge luis', 'borges', 'argentina'),
('julio', 'cortázar', 'argentina'),
('mario', 'vargas llosa', 'peruana');

insert into libros (titulo, isbn, pagina, id_editorial) values
('cien años de soledad', 9780307, 496, 1),
('la casa de los espíritus', 9781501, 448, 3),
('ficciones', 9780307, 224, 1),
('rayuela', 9780307, 600, 2),
('la ciudad y los perros', 9786124, 464, 5);

insert into ejemplares (localizacion, id_libro) values
('estante a1', 1),
('estante a2', 1),
('estante b1', 2),
('estante c1', 3),
('estante d1', 4);

insert into autores_libros (id_autor, id_libro) values
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

insert into usuarios (nombre, apellido, telefono, direccion) values
('juan', 'perez', 44556677, 'av. corrientes 123'),
('maría', 'garcía', 22334455, 'calle falsa 123'),
('carlos', 'lópez', 99887766, 'rivadavia 500'),
('ana', 'martínez', 55664422, 'santa fe 2500'),
('luis', 'rodríguez', 66778899, 'belgrano 800');

insert into prestamos (fecha_devolucion, fecha_prestamo, id_usuario) values
('2023-10-15', '2023-10-01', 1),
('2023-10-19', '2023-10-05', 2),
('2023-10-24', '2023-10-10', 3),
('2023-10-26', '2023-10-12', 4),
('2023-10-29', '2023-10-15', 5);

 
