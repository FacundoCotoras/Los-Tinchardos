create database IronBastion;
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
    TipoAtaque varchar(30),
    Recompensa int
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

insert into PowerUps
(Nombre, Efecto, Duracion, Descripcion)
values
("Escudo", "Proteccion", 5, "Protege la torre temporalmente"),
("Doble Daño", "Aumenta el daño", 10, "Duplica el daño de las defensas"),
("Congelacion", "Congelacion temporal", 3, "congela a los enemigos temporalmente");


insert into DefenseTypes
(Nombre, Costo, DañoBase, VidaBase, Rango)
values
("Cañon", 100, 30, 100, 160),
("Torreta", 150, 10, 100, 220),
("Lanzacohetes", 250, 70, 100, 170);

insert into EnemyTypes
(Nombre, VidaBase, Daño, Velocidad, Resistencia, TipoAtaque, Recompensa)
values
("Enemigo Basico", 100, 10, 1, 0, "Normal", 25),
("Enemigo Rapido", 60, 8, 2, 0, "Normal", 15),
("Tanque", 250, 20, 0.5, 25, "Normal", 75),
("Jefe", 1000, 50, 0.8, 50, "Especial", 300);


insert into Bosses
(IDEnemyType, HabilidadEspecial)
values
(4, "Invocacion: invoca mas topos");


DROP PROCEDURE IF EXISTS MiInfo;
DELIMITER //
CREATE PROCEDURE MiInfo(
    IN xusuario VARCHAR(50) 
)
BEGIN
    SELECT Usuario, Correo, NivelActual, FechaRegistro 
    FROM Players 
    WHERE Usuario = xusuario;
END//
DELIMITER ;


DROP PROCEDURE IF EXISTS MejoresJugadores;
DELIMITER //
CREATE PROCEDURE MejoresJugadores() 
BEGIN
    SELECT Usuario, NivelActual 
    FROM Players 
    ORDER BY NivelActual DESC 
    LIMIT 10;
END//
DELIMITER ;


DROP PROCEDURE IF EXISTS Poderes;
DELIMITER //
CREATE PROCEDURE Poderes()
BEGIN
    SELECT Nombre, Efecto, Duracion, Descripcion 
    FROM PowerUps 
    ORDER BY Nombre ASC;
END//
DELIMITER ;

DROP PROCEDURE IF EXISTS Defensas;
DELIMITER //
CREATE PROCEDURE Defensas() 
BEGIN
    SELECT Nombre, Costo, DañoBase, VidaBase, Rango
    FROM DefenseTypes 
    ORDER BY Costo ASC;
END//
DELIMITER ;

DROP PROCEDURE IF EXISTS Sesiones;
DELIMITER //
CREATE PROCEDURE Sesiones(
    IN xusuario VARCHAR(50) 
)
BEGIN
    SELECT p.Usuario, s.FechaInicio, s.DificultadInicial 
    FROM Players p
    INNER JOIN Sessions s ON p.IDPlayer = s.IDPlayer
    WHERE p.Usuario = xusuario; 
END//
DELIMITER ;

DROP PROCEDURE IF EXISTS Enemigos;
DELIMITER //
CREATE PROCEDURE Enemigos()
BEGIN
    SELECT Nombre, VidaBase, Daño, Velocidad, Resistencia, TipoAtaque, Recompensa
    FROM EnemyTypes;
END//

DELIMITER ;

 
