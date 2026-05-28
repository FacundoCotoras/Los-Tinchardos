select planes.tipo, sum(pagos.monto) as Recaudado
from planes
inner join pagos
on pagos.IDPlan = planes.IDPlan
inner join socios
on socios.IDSocio = pagos.IDSocio
group by planes.IDPlan
having count(socios.IDSocio) > 50 and sum(pagos.monto) > 50000;