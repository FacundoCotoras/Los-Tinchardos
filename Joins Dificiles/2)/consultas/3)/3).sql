select socios.nombre
from socios
inner join pagos
on socios.IDSocio = pagos.IDSocio
inner join planes
on planes.IDPlan = pagos.IDPlan
group by socios.IDSocio, socios.nombre, planes.IDPlan, planes.tipo
having count(pagos.IDPago) > 3;