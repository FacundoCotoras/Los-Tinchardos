select categorias.nombre as categoria, sum(detalleventa.Cantidad * detalleventa.PrecioUnidad) as recaudaciontotal
from categorias
inner join productos
on categorias.IDCategoria = productos.IDCategoria
inner join detalleventa
on productos.IDProducto = detalleventa.IDProducto
where productos.Precio < 100
group by categorias.IDCategoria, categorias.nombre 
having sum(detalleventa.Cantidad * detalleventa.PrecioUnidad) < 5000;
