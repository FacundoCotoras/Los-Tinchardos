SELECT ar.nombre as Artista, SUM(r.cant_reproduccion) as Total_Reproducciones
FROM Artistas ar
inner join Albumes al on ar.id_artista = al.id_artista
inner join Reproducciones r on al.id_album = r.id_album
group by ar.id_artista, ar.nombre
order by Total_Reproducciones ASC
LIMIT 1;


