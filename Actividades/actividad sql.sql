Create database Empresa;
Use Empresa;
Create Table Empleados(
IDEmpleado Int auto_increment primary key not null,
Nombre varchar(18),
Apellido varchar(20) not null,
Sector enum("adm", "Ventas", "Compras", "RRHH"),
Edad int(35) not null default 35,
Sexo char,
Barrio_vivienda varchar(20) default 'Belgrano',
CodPostal int(4),
Ingreso int(4) not null,
Sueldo float(8) not null,
Antiguedad float(8) not null default 350,
Celular int(15) not null
);


insert into Empleados(Nombre, Apellido, Sector, Edad, Sexo, Barrio_vivienda, CodPostal, Ingreso, Sueldo, Antiguedad, Celular) -- Adm, Ventas, Compras, RRHH
values ("Juan", "Gomez", "ventas", 54, "M", "Chacarita", 1427, 2011, 4000, 600, 1122345678 ),
("Enzo", "Jones", "adm", 47, "M", "Almagro", 1173, 2016, 3500, 380, 1122345679 ),
("Maria", "Caballero", "compras", 35, "F", default, 1428, 2019, 2500, 300, 1122345680 ),
("Julio", "Rodriguez", "RRHH", 43, "M", "Flores", 1406, 2011, 4000, 600, 1122345681 ),
("Ana", "Martinez", "adm", 23, "F", "Almagro", 1173, 2024, 2200, 25, 1122345682 ),
("Santino", "Cordera", "ventas", 40, "M", "Palermo", 1414, 2011, 4000, 600, 1122345683 ),
("Carlos", "Perez", "RRHH", 65, "M", "Flores", 1406, 2011, 4000, 600, 1122345684 ),
("Marta", "Herrera", "compras", 55, "F", "Recoleta", 1010, 2011, 4000, 600, 1122345685 ),
("Jonas", "Correa", "RRHH", 32, "M", "Recoleta", 1010, 2023, 2000, 15, 1122345686 ),
("Sofia", "Corridoni", "compras", 43, "F", "La Boca", 1161, 2013, 3500, 400, 1122345687 ),
("Martin", "Kaiser", "RRHH", 61, "M", "Belgrano", 1428, 2011, 4000, 600, 1122345688 ),
("Facundo", "Fernandez", "adm", 43, "M", "Chacarita", 1427, 2014, 3500, 380, 1122345689 ),
("Francisca", "Lima", "ventas", 67, "F", "Belgrano", 1428, 2010, 4200, 610, 1122345690 ),
("Antonella", "Nero", "RRHH", 18, "F", "Villa Martelli", 1003, 2026, 1400, 0, 1122345691 ),
("Franco", "Carreras", "RRHH", 18, "M", "Palermo", 1414, 2026, 1400, 0, 1122644893 );


select *
from Empleados;
select Nombre, Apellido, Barrio_vivienda
from Empleados
where Barrio_vivienda = "Belgrano";

select Apellido, edad, Ingreso
from Empleados
where Ingreso = 2010 or Ingreso = 2011 or Ingreso = 2012;

select Nombre, Apellido, Sexo, Sector
from Empleados
where Sexo = "F" and Sector = "RRHH";

select Apellido, Sector, Celular
from Empleados;

select Apellido, Nombre, Sueldo
from Empleados
where Barrio_vivienda = "Almagro" or Barrio_vivienda = "Flores"
Order by Apellido desc;

select count(IDEmpleado)
from Empleados;


select nombre, apellido, edad
from empleados
where edad = (select max(edad) from empleados)
   or edad = (select min(edad) from empleados);
   
   select avg(edad)
   from empleados;
   
	select avg(edad)
   from empleados
   where sector ="RRHH";

