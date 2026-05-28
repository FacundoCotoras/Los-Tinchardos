create database Streaming;
create table Artitas(
id_artista int primary key auto_increment not null,
nombre varchar(20)
);
create table Albunes(
id_album int primary key auto_increment not null,
titulo varchar(20),
id_artista int,
foreign key(id_artista) references Aritistas(id_artista)
);
create table Reproducciones(
id_reproduccion int primary key auto_increment not null,
cant_reproduccion int(8) 
);
