select socios.nombre, count(pagos.IDPago) as CantidadDePagos, sum(pagos.monto) as Total
from socios
inner join pagos
on pagos.IDSocio = socios.IDSocio
group by socios.nombre
having sum(pagos.monto) >= 32000;