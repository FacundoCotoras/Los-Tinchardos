
select categorias.nombre as categoria, productos.Nombre as producto, sum(detalleventa.Cantidad) as total_vendido
from categorias 
inner join productos 
on categorias.IDCategoria = productos.IDCategoria
inner join detalleventa 
on productos.IDProducto = detalleventa.IDProducto
group by categorias.IDCategoria, productos.IDproducto
having sum(detalleventa.Cantidad) > 500
order by total_vendido desc
limit 1;


