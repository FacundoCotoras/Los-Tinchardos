select edificios.nombre as edificio, sum(expensas.Monto) as recaudaciontotal
from edificios
inner join unidades
on edificios.IDEdificio = unidades.IDEdificio
inner join expensas
on unidades.IDUnidad = expensas.IDUnidad
where expensas.Estado = 'pago'
group by edificios.IDEdificio, edificios.nombre
order by recaudaciontotal desc
limit 3;
