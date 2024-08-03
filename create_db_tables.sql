create database Test

go

use Test

go


create table Direccion(
direccion_id int primary key identity,
descripcion varchar(100)
)

go

create table Cliente(
cliente_id int primary key identity,
numero_identificacion varchar(50),
tipo_identificacion varchar(50),
primer_nombre varchar(50),
segundo_nombre varchar(50),	
primer_apellido varchar(50),
segundo_apellido varchar(50),
direccion_id int references Direccion(direccion_id),
estado bit
)

go

create table Prestamo(
prestamo_id int primary key identity,
tipo varchar(50),
cliente_id int references Cliente(cliente_id),
fecha_inicio datetime,
fecha_fin datetime,
monto_solicitado decimal(10,4),
moneda varchar(10),
monto_aprobado decimal(10,4),
plazo_financiado int,
estado bit
)

--  indice en la columna direccion_id de la tabla Cliente
CREATE INDEX idx_cliente_direccion_id ON Cliente(direccion_id);

-- indice en la columna cliente_id de la tabla Prestamo
CREATE INDEX idx_prestamo_cliente_id ON Prestamo(cliente_id);


go

INSERT INTO Direccion (descripcion)
VALUES 
('Residencial el dorado, Managua'),
('Barrio 1ro mayo, Managua'),
('Barrio monimbo, Masaya');

go

INSERT INTO Cliente (numero_identificacion, tipo_identificacion, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, direccion_id, estado)
VALUES
('123456789', 'Cédula', 'Juan', 'Carlos', 'Pérez', 'Gómez', 1, 1),
('987654321', 'Cédula', 'María', 'Elena', 'Rodríguez', 'López', 2, 1),
('456123789', 'Pasaporte', 'Luis', 'Fernando', 'Martínez', 'Ruiz', 3, 1);


go

INSERT INTO Prestamo (tipo, cliente_id, fecha_inicio, fecha_fin, monto_solicitado, moneda, monto_aprobado, plazo_financiado, estado)
VALUES
('Hipotecario', 1, '2024-01-01', '2029-01-01', 100000.00, 'USD', 95000.00, 60, 1),
('Personal', 2, '2023-06-15', '2024-06-15', 5000.00, 'USD', 4500.00, 12, 1),
('Automotriz', 3, '2022-09-01', '2026-09-01', 20000.00, 'USD', 19000.00, 48, 1);
