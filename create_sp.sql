
use Test

go
---  Direccion ---
CREATE PROCEDURE sp_InsertDireccion
    @descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Direccion (descripcion)
    VALUES (@descripcion);

    SELECT SCOPE_IDENTITY() AS direccion_id;
END;

go


CREATE PROCEDURE sp_GetDireccion
    @direccion_id INT
AS
BEGIN
    SELECT * 
    FROM Direccion
    WHERE direccion_id = @direccion_id;
END;


go

CREATE PROCEDURE sp_UpdateDireccion
    @direccion_id INT,
    @descripcion VARCHAR(100)
AS
BEGIN
    UPDATE Direccion
    SET descripcion = @descripcion
    WHERE direccion_id = @direccion_id;
END;

go

CREATE PROCEDURE sp_DeleteDireccion
    @direccion_id INT
AS
BEGIN
    DELETE FROM Direccion
    WHERE direccion_id = @direccion_id;
END;

go

---  Cliente ---

CREATE PROCEDURE sp_InsertCliente
    @numero_identificacion VARCHAR(50),
    @tipo_identificacion VARCHAR(50),
    @primer_nombre VARCHAR(50),
    @segundo_nombre VARCHAR(50),
    @primer_apellido VARCHAR(50),
    @segundo_apellido VARCHAR(50),
    @direccion_id INT,
    @estado BIT
AS
BEGIN
    INSERT INTO Cliente (numero_identificacion, tipo_identificacion, primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, direccion_id, estado)
    VALUES (@numero_identificacion, @tipo_identificacion, @primer_nombre, @segundo_nombre, @primer_apellido, @segundo_apellido, @direccion_id, @estado);

    SELECT SCOPE_IDENTITY() AS cliente_id;
END;


go 

CREATE PROCEDURE sp_GetCliente
    @cliente_id INT
AS
BEGIN
    SELECT c.*, d.descripcion as direccion 
    FROM Cliente c
    INNER JOIN Direccion d on c.direccion_id = d.direccion_id
    WHERE cliente_id = @cliente_id;
END;

go

CREATE PROCEDURE sp_UpdateCliente
    @cliente_id INT,
    @numero_identificacion VARCHAR(50),
    @tipo_identificacion VARCHAR(50),
    @primer_nombre VARCHAR(50),
    @segundo_nombre VARCHAR(50),
    @primer_apellido VARCHAR(50),
    @segundo_apellido VARCHAR(50),
    @direccion_id INT,
    @estado BIT
AS
BEGIN
    UPDATE Cliente
    SET numero_identificacion = @numero_identificacion,
        tipo_identificacion = @tipo_identificacion,
        primer_nombre = @primer_nombre,
        segundo_nombre = @segundo_nombre,
        primer_apellido = @primer_apellido,
        segundo_apellido = @segundo_apellido,
        direccion_id = @direccion_id,
        estado = @estado
    WHERE cliente_id = @cliente_id;
END;

go

CREATE PROCEDURE sp_DeleteCliente
    @cliente_id INT
AS
BEGIN
    DELETE FROM Cliente
    WHERE cliente_id = @cliente_id;
END;

go

CREATE PROCEDURE sp_GetClientesActivos
AS
BEGIN    
    SELECT 
        *
    FROM 
        Cliente
    WHERE 
        estado = 1; 

END

go

---  Prestamo ---

CREATE PROCEDURE sp_InsertPrestamo
    @tipo VARCHAR(50),
    @cliente_id INT,
    @fecha_inicio DATETIME,
    @fecha_fin DATETIME,
    @monto_solicitado DECIMAL(10,4),
    @moneda VARCHAR(10),
    @monto_aprobado DECIMAL(10,4),
    @plazo_financiado INT,
    @estado BIT
AS
BEGIN
    INSERT INTO Prestamo (tipo, cliente_id, fecha_inicio, fecha_fin, monto_solicitado, moneda, monto_aprobado, plazo_financiado, estado)
    VALUES (@tipo, @cliente_id, @fecha_inicio, @fecha_fin, @monto_solicitado, @moneda, @monto_aprobado, @plazo_financiado, @estado);

    SELECT SCOPE_IDENTITY() AS prestamo_id;
END;


go

CREATE PROCEDURE sp_GetPrestamo
    @prestamo_id INT
AS
BEGIN
    SELECT * 
    FROM Prestamo
    WHERE prestamo_id = @prestamo_id;
END;

go

CREATE PROCEDURE sp_UpdatePrestamo
    @prestamo_id INT,
    @tipo VARCHAR(50),
    @cliente_id INT,
    @fecha_inicio DATETIME,
    @fecha_fin DATETIME,
    @monto_solicitado DECIMAL(10,4),
    @moneda VARCHAR(10),
    @monto_aprobado DECIMAL(10,4),
    @plazo_financiado INT,
    @estado BIT
AS
BEGIN
    UPDATE Prestamo
    SET tipo = @tipo,
        cliente_id = @cliente_id,
        fecha_inicio = @fecha_inicio,
        fecha_fin = @fecha_fin,
        monto_solicitado = @monto_solicitado,
        moneda = @moneda,
        monto_aprobado = @monto_aprobado,
        plazo_financiado = @plazo_financiado,
        estado = @estado
    WHERE prestamo_id = @prestamo_id;
END;

go

CREATE PROCEDURE sp_DeletePrestamo
    @prestamo_id INT
AS
BEGIN
    DELETE FROM Prestamo
    WHERE prestamo_id = @prestamo_id;
END;
