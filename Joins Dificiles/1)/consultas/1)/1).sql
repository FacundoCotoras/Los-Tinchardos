SELECT 
    a.modelo, 
    SUM(t.precio) AS total_recaudado,
    COUNT(t.id_pasajero) AS total_pasajeros
FROM Aviones a
INNER JOIN Vuelos v ON a.id_avion = v.id_avion
INNER JOIN Tickets t ON v.id_vuelo = t.id_vuelo
GROUP BY a.modelo
HAVING SUM(t.precio) > 2000000 
   AND COUNT(t.id_pasajero) > 100;