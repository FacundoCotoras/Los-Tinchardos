drop procedure if exists NuevoUsuario;
drop procedure if exists ValidarSesion;

delimiter //
create procedure NuevoUsuario(IN xcorreo Varchar(150), IN xnombre varchar(100), IN xcontrasena varchar(255), IN xapellido varchar(100))
    begin
        if exists(select correo from usuarios where correo=xcorreo) then
            select "1" as resultado;
        else
            insert into usuarios(correo, nombre, contraseña, apellido) values (xcorreo, xnombre, xcontrasena, xapellido);
            select "3" as resultado,
            idusuario as id from usuarios WHERE correo = xcorreo;
        end if;
    end//
delimiter  ;

delimiter  //
create procedure ValidarSesion(IN xcorreo VARCHAR(150))
begin
SELECT idusuario, nombre, correo, contraseña AS clave FROM usuarios WHERE correo = xcorreo;
end//
delimiter  ;
