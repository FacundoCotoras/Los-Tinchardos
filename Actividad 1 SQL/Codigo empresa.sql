create database Empresa;

use Empresa;

create table Empleados(
IDEmpleado Int auto_increment primary key not null,
Nombre varchar(18),
Apellido varchar(20) not null,
Sector enum("ADM" , "VENTAS" , "COMPRAS" , "RRHH" ),
Edad int(2) not null Default 35,
Sexo  enum("F" , "M" ),
Barrio_vivienda varchar(20) Default "BELGRANO" ,
CodPostal Int(4),
Ingreso Year not null,
Sueldo Decimal not null,
Antiguedad Decimal not null Default 250,
Celular varchar(15) not null
);



insert into Empleados(IDEmpleado, Nombre, Apellido, Sector, Edad, Sexo, Barrio_viviend, CodPostal, Ingreso, Sueldo, Antiguedad, Celular)
values('Agustin','Barrionuevo','ADM', 'M',37,'Flores', 4825 , 2011 , 450 ,675800000978145),
('Pablo','Fernandez','RRHH', 37, 'M' , 7455 , 2011 , 450 , 675800000978145),
('Violeta','sala', 'RRHH', 45 ,'F',7812, 2011 , 450 , 457681643720152),
('Rigoberto','Papon','RRHH', 54 ,'F', 2011, 450, 146597321659784),
('Roberto','Sanchez','RRHH', 40 ,'M','Almagro', 2011, 450,124675872365845),
('Humberto','Rodriguez','VENTAS', 42 ,'M','Chacarita', 2011, 450,4356781956428375),
('Alfonso','Perez','COMPRAS', 46 ,'M','Almagro', 2015, 450,457689154673254),
('Alfonsa','Gomez','VENTAS', 56 ,'F','Flores', 2017, 450,457682134578965),
('Federico','Bouzon',39,'ADM', 25 ,'M','Rosario', 2017, 450,754689451230459),
('Josefina','Floralez','ADM', 26 ,'F', 2017, 450,1245768325476914),
('Benjamin','Slabovick','ADM', 38 ,'M','Colegiales', 2016, 450,157346815942057),
('Alexis','Bulliet','VENTAS', 67 ,'M','Colegiales', 2016, 450,314682759142530),
('Victoria','Acosta','VENTAS' ,50 ,'F','Chacarita', 2012, 450,346518794205136),
('José','Carlos','ADM', 66 ,'M','Palermo', 2013, 435697182564739),
('Jorge', 'Gonzalez', 'VENTAS', 26 ,'M','Almagro', 2019, 450,351672890435498);

Select Nombre, Apellido From Empleados
Where Barrio_vivienda = 'Belgrano';

select Apellido, edad from Empleados
Where Fecha = 2010 or Fecha =2011 or Fecha=2012;

select Nombre,Apellido,edad from Empleados 
where Sexo = 'F' and Sector = 'RRHH';

select Apellido, Sector, Celular from Empleados;

select Nombre, Apellido, Sueldo from Empleados
Where Barrio_vivienda = 'Almagro' or Barrio_vivienda = 'Flores'
order by Apellido Desc;

select Total_empleados from Empleados;

select apellido, edad from empleados
order by edad desc limit 1;
select nombre, apellido, edad from empleados
order by edad asc limit 1;

select edad from empleados;

select edad from Empleados 
where Sector = 'RRHH';
