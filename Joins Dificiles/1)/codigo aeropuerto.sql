create database Aeropuerto;
create table Pasajeros(
id_pasajero int primary key auto_increment not null,
nombreCompleto varchar(30),
DNI int(10)
);
create table Tickets(
id_ticket int primary key auto_increment not null,
precio int(5),
tipo enum("Comercial","P.clase"),
id_pasajero int,
id_vuelo int,
 foreign key(id_pasajero) references Pasajeros(id_pasajero),
 foreign key(id_vuelo) references Vuelos(id_vuelo)
);
create table Vuelos(
id_vuelo int primary key auto_increment not null,
fecha date,
origen varchar(25),
destino varchar(25),
foreign key(id_avion) references Aviones(id_avion)
);
create table Aviones(
id_avion int primary key auto_increment not null,
modelo varchar(20),
capacidad int(10) 
);
