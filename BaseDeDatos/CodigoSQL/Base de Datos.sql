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
    SELECT Nombre, Costo, DañoBase, VidaBase 
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


