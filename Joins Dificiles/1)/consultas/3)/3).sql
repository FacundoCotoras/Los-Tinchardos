SELECT 
    a.modelo, 
    COUNT(*) AS vuelos
FROM Aviones a
INNER JOIN Vuelos v ON a.id_avion = v.id_avion
WHERE v.fecha <= '2026-05-31'
GROUP BY a.modelo
HAVING COUNT(*) > 50;