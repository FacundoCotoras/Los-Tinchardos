select edificios.nombre as edificio, sum(expensas.Monto) as totalimpagas, count(expensas.IDExpensa) as unidades_en_mora
from edificios
inner join unidades
on edificios.IDEdificio = unidades.IDEdificio
inner join expensas
on unidades.IDUnidad = expensas.IDUnidad
where expensas.Estado = 'impago'
group by edificios.IDEdificio, edificios.nombre
having sum(expensas.Monto) > 1000000 and count(expensas.IDExpensa) > 5;


