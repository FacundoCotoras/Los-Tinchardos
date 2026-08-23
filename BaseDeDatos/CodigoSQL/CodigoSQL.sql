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
    TiempoDefendido int,
    DificultadInicial varchar(30),
    foreign key (IDPlayer) references Players(IDPlayer)
);

create table PowerUps (
    IDPowerUp int not null auto_increment primary key,
    Nombre varchar(50),
    Efecto varchar(100),
    Duracion double,
    Descripcion varchar(200)
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
    Costo double,
    DañoBase double,
    VidaBase double,
    Rango double
);

create table DefenseInstances (
    IDDefenseInstance int not null auto_increment primary key,
    IDSession int,
    IDDefenseType int,
    X int,
    Y int,
    VidaActual double,
    EstadoActual varchar(30),
    foreign key (IDSession) references Sessions(IDSession),
    foreign key (IDDefenseType) references DefenseTypes(IDDefenseType)
);

create table EnemyTypes (
    IDEnemyType int not null auto_increment primary key,
    Nombre varchar(50),
    VidaBase double,
    Daño double,
    Velocidad double,
    Resistencia double,
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
    VidaActual double,
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
    VidaTorre double,
    DefensasDestruidas int,
    EnemigosEliminados int,
    foreign key (IDSession) references Sessions(IDSession)
);

create table LeaderBoards (
    IDLeaderBoard int not null auto_increment primary key,
    IDSession int,
    MotivoFin text,
    VidaTorre double,
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
    ValorImpacto double,
    Coordenadas varchar(100),
    foreign key (IDSession) references Sessions(IDSession)
);
