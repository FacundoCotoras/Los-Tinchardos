select usuario, correo, nivelactual
from players;

select usuario, nivelactual
from players

where nivelactual > 5;
select nombre, efecto, duracion
from powerups
where duracion > 10;

select nombre, costo, dañobase, vidabase
from defensetypes
order by costo asc;

select players.usuario, sessions.fechainicio, sessions.dificultadinicial
from players
inner join sessions
on players.idplayer = sessions.idplayer;
