

select categorias.nombre as categoria, avg(productos.Precio) as promedio_precio, sum(detalleventa.Cantidad) as productos_vendidos
from categorias
inner join productos
on categorias.IDCategoria = productos.IDCategoria
inner join detalleventa
on productos.IDProducto = detalleventa.IDProducto
group by categorias.IDCategoria, categorias.nombre
having avg(productos.Precio) > 1500
and sum(detalleventa.Cantidad) >= 10;


