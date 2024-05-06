create database DbTienda2;
go

use DbTienda2;
go

create table producto(
idproducto int primary key identity(1,1),
nombre varchar(150) not null,
descripcion varchar(max) not null,
cantidad int not null,
precio decimal(10,2) not null,
fecharegistro datetime2 not null default current_timestamp
)
go