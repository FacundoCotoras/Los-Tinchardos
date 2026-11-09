create database IronBastion;
-- drop database IronBastion
use IronBastion;

create table Players (
    IDPlayer int not null auto_increment primary key,
    Usuario varchar(50),
    Correo varchar(100),
    FechaRegistro date,
    NivelActual int
);

create table Sessions (
    IDSession int not null auto_increment primary key,
    IDPlayer int,
    FechaInicio date,
    FechaFin date,
    TiempoDefendido time,
    DificultadInicial varchar(30),
    foreign key (IDPlayer) references Players(IDPlayer)
);

create table PowerUps (
    IDPowerUp int not null auto_increment primary key,
    Nombre varchar(50),
    Efecto varchar(100),
    Duracion float,
    Descripcion text
);

create table Inventory (
    IDInventory int not null auto_increment primary key,
    IDSession int,
    IDPowerUp int,
    Cantidad int,
    Estado varchar(30),
    foreign key (IDSession) references Sessions(IDSession),
    foreign key (IDPowerUp) references PowerUps(IDPowerUp)
);

create table Waves (
    IDWave int not null auto_increment primary key,
    IDSession int,
    NumeroWave int,
    Dificultad varchar(30),
    EnemigosSpawneados int,
    foreign key (IDSession) references Sessions(IDSession)
);

create table DefenseTypes (
    IDDefenseType int not null auto_increment primary key,
    Nombre varchar(50),
    Costo float,
    DañoBase float,
    VidaBase float,
    Rango float
);

create table DefenseInstances (
    IDDefenseInstance int not null auto_increment primary key,
    IDSession int,
    IDDefenseType int,
    X int,
    Y int,
    VidaActual float,
    EstadoActual varchar(30),
    foreign key (IDSession) references Sessions(IDSession),
    foreign key (IDDefenseType) references DefenseTypes(IDDefenseType)
);

create table EnemyTypes (
    IDEnemyType int not null auto_increment primary key,
    Nombre varchar(50),
    VidaBase float,
    Daño float,
    Velocidad float,
    Resistencia float,
    TipoAtaque varchar(30)
);

create table Bosses (
    IDBoss int not null auto_increment primary key,
    IDEnemyType int,
    HabilidadEspecial text,
    foreign key (IDEnemyType) references EnemyTypes(IDEnemyType)
);

create table EnemyInstances (
    IDEnemyInstance int not null auto_increment primary key,
    IDSession int,
    IDEnemyType int,
    IDWave int,
    X int,
    Y int,
    VidaActual float,
    foreign key (IDSession) references Sessions(IDSession),
    foreign key (IDEnemyType) references EnemyTypes(IDEnemyType),
    foreign key (IDWave) references Waves(IDWave)
);

create table Resources (
    IDResource int not null auto_increment primary key,
    IDSession int,
    Tipo varchar(30),
    Cantidad int,
    foreign key (IDSession) references Sessions(IDSession)
);

create table SessionResults (
    IDResult int not null auto_increment primary key,
    IDSession int,
    MotivoFin text,
    VidaTorre float,
    DefensasDestruidas int,
    EnemigosEliminados int,
    foreign key (IDSession) references Sessions(IDSession)
);

create table LeaderBoards (
    IDLeaderBoard int not null auto_increment primary key,
    IDSession int,
    MotivoFin text,
    VidaTorre float,
    DefensasDestruidas int,
    EnemigosEliminados int,
    foreign key (IDSession) references Sessions(IDSession)
);

create table CombatLogs (
    IDCombatLog int not null auto_increment primary key,
    IDSession int,
    MomentoAccion time,
    TipoAccion varchar(50),
    Origen varchar(100),
    Destino varchar(100),
    ValorImpacto float,
    Coordenadas varchar(100),
    foreign key (IDSession) references Sessions(IDSession)
);

-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$


-- registros

/*
insert into Players
(Usuario, Correo, FechaRegistro, NivelActual)
values
("LaChispa", "agustin.barrionuevoet32@gmail.com", "2026-07-05", 20),
("Vulcan", "facundo.cotoraset32@gmail.com", "2025-01-10", 6),
("Mono", "Benjamin.Salaet32@gmail.com", "2024-02-13", 12);


insert into Sessions
(IDPlayer, FechaInicio, FechaFin, TiempoDefendido, DificultadInicial)
values
(1, "2026-07-05", "2026-07-05", "00:10:35", "Facil"),
(2, "2025-01-10", "2025-01-10", "00:25:43", "Media"),
(3, "2024-02-13", "2024-02-13", "00:37:24", "Dificil");

*/

insert into PowerUps
(Nombre, Efecto, Duracion, Descripcion)
values
("Escudo", "Proteccion", 5, "Protege la torre temporalmente"),
("Doble Daño", "Aumenta el daño", 10, "Duplica el daño de las defensas"),
("Congelacion", "Congelacion temporal", 3, "congela a los enemigos temporalmente");

/*
insert into Inventory
(IDSession, IDPowerUp, Cantidad, Estado)
values
(1, 1, 3, "Disponible"),
(2, 2, 2, "Utilizado"),
(3, 3, 1, "Disponible");


insert into Waves
(IDSession, NumeroWave, Dificultad, EnemigosSpawneados)
values
(1, 1, "Facil", 10),
(2, 1, "Media", 20),
(3, 1, "Dificil", 30);

*/

insert into DefenseTypes
(Nombre, Costo, DañoBase, VidaBase, Rango)
values
("Cañon", 100, 30, 100, 160),
("Torreta", 150, 10, 100, 220),
("Lanzacohetes", 250, 70, 100, 170);

/*

insert into DefenseInstances
(IDSession, IDDefenseType, X, Y, VidaActual, EstadoActual)
values
(1, 1, 10, 20, 100, "Activa"),
(2, 2, 15, 25, 80, "Activa"),
(3, 3, 20, 30, 60, "Dañada");

*/

insert into EnemyTypes
(Nombre, VidaBase, Daño, Velocidad, Resistencia, TipoAtaque)
values
("Enemigo Basico", 100, 10, 1, 0, "Normal"),
("Enemigo Rapido", 60, 8, 2, 0, "Normal"),
("Tanque", 250, 20, 0.5, 25, "Normal"),
("Jefe", 1000, 50, 0.8, 50, "Especial");


insert into Bosses
(IDEnemyType, HabilidadEspecial)
values
(4, "Invocacion: invoca mas topos");


/*

insert into EnemyInstances
(IDSession, IDEnemyType, IDWave, X, Y, VidaActual)
values
(1, 1, 1, 1, 1, 100),
(2, 2, 2, 1, 1, 60),
(3, 4, 3, 1, 1, 1000);


insert into Resources
(IDSession, Tipo, Cantidad)
values
(1, "Madera", 500),
(2, "Piedra", 300),
(3, "Metal", 250);


insert into SessionResults
(IDSession, MotivoFin, VidaTorre, DefensasDestruidas, EnemigosEliminados)
values
(1, "Victoria", 100, 0, 30),
(2, "Derrota", 0, 4, 5),
(3, "Victoria", 80, 3, 22);


insert into LeaderBoards
(IDSession, MotivoFin, VidaTorre, DefensasDestruidas, EnemigosEliminados)
values
(1, "Victoria", 100, 0, 30),
(2, "Derrota", 0, 4, 5),
(3, "Victoria", 80, 3, 22);


insert into CombatLogs
(IDSession, MomentoAccion, TipoAccion, Origen, Destino, ValorImpacto, Coordenadas)
values
(1, "00:04:15", "Ataque", "Cañon", "Enemigo Basico", 30, "10,20"),
(2, "00:05:33", "Ataque", "Torreta", "Enemigo Rapido", 10, "15,25"),
(3, "00:08:25", "Ataque", "Lanzacohetes", "Jefe", 70, "20,30");

*/
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
-- $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

-- Esta consulta nos da la informacion personal del usuario

DROP PROCEDURE IF EXISTS MiInfo;
DELIMITER //
CREATE PROCEDURE MiInfo(
    IN xusuario VARCHAR(50) -- Solo necesitamos recibir el usuario como filtro desde C#
)
BEGIN
    SELECT Usuario, Correo, NivelActual, FechaRegistro 
    FROM Players 
    WHERE Usuario = xusuario;
END//
DELIMITER ;

-- Esta consulta nos dice el top 10 de jugadores ordenados por su nivel descendentemente

DROP PROCEDURE IF EXISTS MejoresJugadores;
DELIMITER //
CREATE PROCEDURE MejoresJugadores() -- No necesitamos parámetros IN porque es un top global, no necesitamos llevar un dato desde C#
BEGIN
    SELECT Usuario, NivelActual 
    FROM Players 
    ORDER BY NivelActual DESC 
    LIMIT 10;
END//
DELIMITER ;

-- Catálogo de todos los poderes del juego

DROP PROCEDURE IF EXISTS Poderes;
DELIMITER //
CREATE PROCEDURE Poderes() -- No necesitamos parametros, es un catalogo de todos los poderes
BEGIN
    SELECT Nombre, Efecto, Duracion, Descripcion 
    FROM PowerUps 
    ORDER BY Nombre ASC;
END//
DELIMITER ;

-- Catálogo de todas las defensas del juego ordenadas por costo ascendentemente

DROP PROCEDURE IF EXISTS Defensas;
DELIMITER //
CREATE PROCEDURE Defensas() 
BEGIN
    SELECT Nombre, Costo, DañoBase, VidaBase, Rango
    FROM DefenseTypes 
    ORDER BY Costo ASC;
END//
DELIMITER ;

-- Muestra el historial de sesiones de un jugador especifico

DROP PROCEDURE IF EXISTS Sesiones;
DELIMITER //
CREATE PROCEDURE Sesiones(
    IN xusuario VARCHAR(50) -- Filtro para recibir desde C# el usuario
)
BEGIN
    SELECT p.Usuario, s.FechaInicio, s.DificultadInicial 
    FROM Players p
    INNER JOIN Sessions s ON p.IDPlayer = s.IDPlayer
    WHERE p.Usuario = xusuario; -- Filtramos para que no traiga las sesiones de todo el mundo
END//
DELIMITER ;

