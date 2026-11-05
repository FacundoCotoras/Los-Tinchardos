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


delimiter  //
create procedure MiInfo(IN usuario VARCHAR(150), correo VARCHAR(150), nivelactual int, fecharegistro date)
begin
SELECT usuario, correo, nivelacutal, fecharegistro FROM players WHERE usuario = xusuario;
end//
delimiter  ;


delimiter  //
create procedure MejoresJugadores(IN usuario VARCHAR(150), nivelactual int)
begin
SELECT usuario, nivelacutal FROM players order by nivelactual desc limit 10;
end//
delimiter  


select nombre, efecto, duracion, descripcion
from powerups;

select nombre, costo, dañobase, vidabase
from defensetypes
order by costo asc;

select players.usuario, sessions.fechainicio, sessions.dificultadinicial
from players
inner join sessions
on players.idplayer = sessions.idplayer;


delimiter  //
create procedure Poderes(IN  nombre varchar (25), efecto varchar (25), duracion float, descripcion text)
begin
SELECT nombre, efecto, duracion, descripcion FROM powerups;
end//
delimiter 