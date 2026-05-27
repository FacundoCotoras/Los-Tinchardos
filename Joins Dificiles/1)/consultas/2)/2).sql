SELECT 
    v.id_vuelo, 
    AVG(t.precio) AS promedio
FROM Vuelos v
INNER JOIN Tickets t ON v.id_vuelo = t.id_vuelo
WHERE v.origen = 'EZEIZA'
GROUP BY v.id_vuelo
HAVING AVG(t.precio) > 500;