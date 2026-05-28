select  al.titulo as Album, ar.nombre as Artista, AVG(r.cant_reproduccion) as Promedio_Reproducciones
from Albumes al
inner join Artistas ar on al.id_artista = ar.id_artista
inner join Reproducciones r on al.id_album = r.id_album
group by al.id_album, al.titulo, ar.nombre
having AVG(r.cant_reproduccion) > 50000;

