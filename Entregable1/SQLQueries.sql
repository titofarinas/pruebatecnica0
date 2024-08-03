use Test



/*
Listado de Clientes con sus direcciones y prestamos asociados, 
cuyos prestamos estén activos y el plazo de financiamiento sea mayo a 36 meses
*/

SELECT 
concat(c.primer_nombre, ' ', c.segundo_nombre, ' ',c.primer_apellido, ' ', c.segundo_apellido) as nombre_completo,
d.descripcion as direccion,
p.prestamo_id,
p.monto_solicitado,
p.monto_aprobado,
p.plazo_financiado,
p.moneda
FROM Cliente c 
inner join Direccion d on c.direccion_id = d.direccion_id
inner join Prestamo p on c.cliente_id = p.cliente_id
where p.estado = 1 and p.plazo_financiado > 36

-- *** Cantidad de Prestamos por estado y moneda con monto mayo a 10,000 dólares ***

select
CASE
    WHEN estado = 1 THEN 'Activo'
    WHEN estado = 0 THEN 'Inactivo'        
END as estado,
count(prestamo_id) as cantidad
from Prestamo 
where monto_aprobado > 10000 and upper(moneda) = 'USD'
group by estado








