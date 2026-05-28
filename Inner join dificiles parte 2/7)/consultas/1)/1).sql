
select artistas.nombre, reproducciones.cant_reproduccion
from albumes
inner join artistas
on artistas.id_artista = albumes.id_artista
inner join reproducciones
on reproducciones.id_album = albumes.id_album
group by artistas.id_artista, albumes.id_album
having count(albumes.id_album) > 3 and reproducciones.cant_reproduccion > 1000000;

