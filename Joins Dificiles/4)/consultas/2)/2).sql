select edificios.nombre as edificio, avg(expensas.Monto) as promedioexpensas
from edificios
inner join unidades
on edificios.IDEdificio = unidades.IDEdificio
inner join expensas
on unidades.IDUnidad = expensas.IDUnidad
where expensas.Estado = 'pago'
group by edificios.IDEdificio, edificios.nombre
having avg(expensas.Monto) >= 20000;