use ejercicio;
INSERT INTO Cantantes (Nombre, Apellido, GeneroPrincipal) VALUES
('Juan','Pérez','Rock'),
('María','López','Pop'),
('Carlos','Gómez','Tango'),
('Lucía','Martínez','Jazz'),
('Pedro','Fernández','Reggaeton'),
('Ana','Suárez','Folklore'),
('Diego','Ramírez','Trap'),
('Sofía','Torres','HipHop'),
('Martín','Castro','Metal'),
('Laura','Domínguez','Rap');

INSERT INTO Discos (Nombre, FechaLanzamiento, IDCantante) VALUES
('Entre Sombras y Luces','2020-05-01',1),
('Cielo de Cristal','2021-06-15',2),
('Milonga del Ayer','2019-03-20',3),
('Noches de Improvisación','2022-11-10',4),
('Perreo Infinito','2023-01-05',5),
('Raíces del Norte','2018-07-07',6),
('Sueños de Barrio','2024-02-14',7),
('Paisajes Invisibles','2020-09-09',8),
('Furia de Acero','2021-12-12',9),
('Sinfonía del Tiempo','2017-04-04',10);

INSERT INTO Canciones (Nombre, FechaLanzamiento, Duracion, IDDisco) VALUES
('Fuego en la Ciudad','2020-05-01','00:03:45',1),   
('Estrella Fugaz','2021-06-15','00:04:10',2),       
('Barrio Viejo','2019-03-20','00:05:00',3),         
('Notas en Azul','2022-11-10','00:06:30',4),       
('Baila Morena','2023-01-05','00:03:20',5),         
('Viento Pampeano','2018-07-07','00:04:50',6),      
('Luces Rojas','2024-02-14','00:02:55',7),          
('Rimas del Barrio','2020-09-09','00:03:40',8),     
('Sombras de Hierro','2021-12-12','00:05:15',9),    
('Palabras de Calle','2017-04-04','00:07:00',10); 

INSERT INTO Bandas (Nombre, FechaInicio) VALUES
('Ruta 66','2015-01-01'),
('Estrella Pop','2018-02-02'),
('La Guardia Vieja','2010-03-03'),
('Blue Note','2019-04-04'),
('Flow del Barrio','2020-05-05'),
('Los del Monte','2012-06-06'),
('Barrio 420','2023-07-07'),
('Rima Urbana','2016-08-08'),
('Acero Mortal','2014-09-09'),
('Verso Libre','2000-10-10');

INSERT INTO Fans (Nombre, Edad, Genero) VALUES
('Luis',20,'M'),
('Carla',22,'F'),
('Jorge',25,'M'),
('Marta',30,'F'),
('Andrés',18,'M'),
('Valeria',27,'F'),
('Tomás',19,'M'),
('Paula',24,'F'),
('Ricardo',28,'M'),
('Natalia',21,'F');

INSERT INTO Estadios (Nombre, Capacidad, Ubicacion) VALUES
('Estadio Central',400,'Buenos Aires'),
('Arena Norte',323,'Rosario'),
('Teatro Sur',10000,'Córdoba'),
('Estadio Este',45000,'La Plata'),
('Coliseo Oeste',674,'Mendoza'),
('SuperArchiHiperMegaArenaProMax',999999,'Buenos Aires'),
('Auditorio Río',15000,'Santa Fe'),
('Estadio Patagónico',654,'Neuquén'),
('Arena Litoral',326,'Corrientes'),
('Estadio Federal',231,'San Juan');

INSERT INTO Conciertos (FechaInicio, IDEstadio) VALUES
('2024-01-10',1),
('2024-02-15',2),
('2024-03-20',3),
('2024-04-25',4),
('2024-05-30',5),
('2024-06-05',6),
('2024-07-12',7),
('2024-08-18',8),
('2024-09-22',9),
('2024-10-28',10);

INSERT INTO Entradas (Precio, Tipo, IDConcierto, IDFan) VALUES
(5000,'VIP',1,1),
(3000,'Campo',1,2),
(2500,'PlateaAlta',2,3),
(4000,'PlateaBaja',2,4),
(6000,'Palco',3,5),
(2000,'Campo',3,6),
(3500,'PlateaAlta',4,7),
(4500,'PlateaBaja',4,8),
(7000,'VIP',5,9),
(2800,'Campo',5,10);

INSERT INTO Publicos (IDEntrada) VALUES
(1),(2),(3),(4),(5),(6),(7),(8),(9),(10);

INSERT INTO CancionesCantantes (RolCantante, IDCantante, IDCancion) VALUES
('principal',1,1),
('secundario',2,1),
('principal',2,2),
('secundario',3,2),
('principal',3,3),
('secundario',4,3),
('principal',4,4),
('secundario',5,4),
('principal',5,5),
('secundario',6,5),
('principal',6,6),
('secundario',7,6),
('principal',7,7),
('secundario',8,7),
('principal',8,8),
('secundario',9,8),
('principal',9,9),
('secundario',10,9),
('principal',10,10),
('secundario',1,10);

INSERT INTO BandasCantantes (IDBanda, IDCantante) VALUES
(1,1),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7),(8,8),(9,9),(10,10);

INSERT INTO ConciertosCantantes (IDConcierto, IDCantante) VALUES
(1,1),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7),(8,8),(9,9),(10,10);

INSERT INTO Conciertos_Discos (IDConcierto, IDDisco) VALUES
(1,1),(2,2),(3,3),(4,4),(5,5),(6,6),(7,7),(8,8),(9,9),(10,10);

select nombre
from estadios
where Capacidad > 500;

select Canciones.Nombre, Cantantes.Nombre, Cantantes.Apellido, CancionesCantantes.RolCantante
from Canciones, CancionesCantantes, Cantantes
where Canciones.IDCancion = CancionesCantantes.IDCancion
and Cantantes.IDCantante = CancionesCantantes.IDCantante;

select nombre
from canciones
where IDDisco= 2;

SELECT Conciertos.IDConcierto
FROM Conciertos, ConciertosCantantes
WHERE Conciertos.IDConcierto = ConciertosCantantes.IDConcierto
AND ConciertosCantantes.IDCantante = 5;
