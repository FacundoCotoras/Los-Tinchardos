create database pokemon;
-- drop database pokemon
use pokemon;

create table usuarios (
    idusuario int auto_increment,
    nombre varchar(100),
    apellido varchar(100),
    correo varchar(150),
    contraseña varchar(255),
    primary key (idusuario)
);

create table partidas (
    idpartida int auto_increment,
    puntoguardado varchar(100),
    tiempodejuego varchar(50),
    idusuario int,
    primary key (idpartida),
    foreign key (idusuario) references usuarios(idusuario)
);

create table Cuidades (
    idcuidad int auto_increment,
    nombre varchar(100),
    primary key (idcuidad)
);

create table gyms (
    idgym int auto_increment,
    consecucion varchar(100),
    idcuidad int,
    primary key (idgym),
    foreign key (idcuidad) references Cuidades(idcuidad)
);

create table guardados (
    idguardado int auto_increment,
    levelcap int,
    idpartida int,
    idgym int,
    fechaguardado datetime,
    primary key (idguardado),
    foreign key (idpartida) references partidas(idpartida),
    foreign key (idgym) references gyms(idgym)
);

create table mochilas (
    idmochila int auto_increment,
    idguardado int,
    primary key (idmochila),
    foreign key (idguardado) references guardados(idguardado)
);

create table objetos (
    idobjeto int auto_increment,
    nombre varchar(100),
    descripcion text,
    cantidad int,
    idmochila int,
    primary key (idobjeto),
    foreign key (idmochila) references mochilas(idmochila)
);

create table tipos (
    idtipo int auto_increment,
    nombre varchar(100),
    primary key (idtipo)
);

create table especies (
    idespecie int auto_increment,
    nombreespecie varchar(100),
    idtipo1 int,
    idtipo2 int,
    primary key (idespecie),
    foreign key (idtipo1) references tipos(idtipo),
    foreign key (idtipo2) references tipos(idtipo)
);

create table rutas (
    idruta int auto_increment,
    nombre varchar(100),
    primary key (idruta)
);

create table `rutas-especies` (
    idruta_especie int auto_increment,
    idruta int,
    idespecie int,
    primary key (idruta_especie),
    foreign key (idruta) references rutas(idruta),
    foreign key (idespecie) references especies(idespecie)
);

create table evoluciones (
    idevolucion int auto_increment,
    idespecie int,
    idespecieevo int,
    condición varchar(100),
    primary key (idevolucion),
    foreign key (idespecie) references especies(idespecie),
    foreign key (idespecieevo) references especies(idespecie)
);

create table movimientos (
    idmovimiento int auto_increment,
    nombre varchar(100),
    idtipo int,
    pp int,
    efecto text,
    daño int,
    curacion int,
    primary key (idmovimiento),
    foreign key (idtipo) references tipos(idtipo)
);

create table `cantidad-movimientos` (
    idcantidad int auto_increment,
    idespecie int,
    idmovimiento int,
    primary key (idcantidad),
    foreign key (idespecie) references especies(idespecie),
    foreign key (idmovimiento) references movimientos(idmovimiento)
);

create table ivs (
    idiv int auto_increment,
    ps int,
    ataque int,
    ataqueespecial int,
    defensa int,
    defensaespecial int,
    velocidad int,
    primary key (idiv)
);

create table pokemones (
    idpokemon int auto_increment,
    nombre varchar(100),
    nivel int,
    altura decimal(5,2),
    peso decimal(5,2),
    idiv int,
    primary key (idpokemon),
    foreign key (idiv) references ivs(idiv)
);

create table pcs (
    idpc int auto_increment,
    idguardado int,
    idpokemon int,
    primary key (idpc),
    foreign key (idguardado) references guardados(idguardado),
    foreign key (idpokemon) references pokemones(idpokemon)
);
);
