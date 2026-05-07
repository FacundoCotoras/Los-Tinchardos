create database Biblioteca;

create table Autores(
id_autor int primary key auto_increment not null,
nombre varchar(20),
apellido varchar(20),
nacionalidad varchar(20)
);
create table Editoriales(
id_editorial int primary key auto_increment not null,
nombre varchar(20),
anio_fundacion date,
ubicacion varchar(20)
);
create table Libros(
id_libro int primary key auto_increment not null,
titulo varchar(30),
ISBN int(13),
foreign key(id_editorial) references Editoriales(id_editorial),
paginas int(5) 
);
create table Autores_Libros(
foreign key(id_libro) references Libros(id_libro),
foreign key(id_autor) references Autores(id_autor)
);
create table ejemplares(
id_ejemplar int primary key auto_increment not null,
localizacion varchar(20),
foreign key(id_libro) references Libros(id_libro)
);
create table Usuarios(
id_usuario int primary key auto_increment not null,
nombre varchar(20),
apellido varchar(20),
direccion varchar(25),
telefono int(10)
);
create table Prestamos(
id_prestamo int auto_increment primary key not null,
fecha_pre date,
fecha_dev date,
foreign key(id_usuario) references Usuario(id_usuario),
foreign key(id_ejemplar) references Ejemplares(id_ejemplar)
);
