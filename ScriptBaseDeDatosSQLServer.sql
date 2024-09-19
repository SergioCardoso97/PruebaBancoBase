USE [master]
GO

CREATE DATABASE [PruebaBancoBase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaBancoBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SERVERSERGIO\MSSQL\DATA\PruebaBancoBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaBancoBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SERVERSERGIO\MSSQL\DATA\PruebaBancoBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [PruebaBancoBase]
GO

create table TblClientes(
	Id int identity not null primary key,
	Nombre varchar(250) not null,
	RFC varchar(13) not null,
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table TblVendedores(
	Id int identity not null primary key,
	Nombre varchar(250) not null,
	RFC varchar(13) not null,
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table TblProductos(
	Id int identity not null primary key,
	IdTblVendedor int not null foreign key references TblVendedores(Id), 
	Producto varchar(250) not null,
	Precio float not null,
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table CatEstatusPago(
	Id int identity not null primary key,
	Estatus varchar(250) not null,
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table TblOrdenes(
	Id int identity not null primary key,	
	IdTblCliente int not null foreign key references TblClientes(Id),
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table RelOrdenesProductos(
	Id int identity not null primary key,	
	IdTblProductos int not null foreign key references TblProductos(Id),
	IdTblOrdenes int not null foreign key references TblOrdenes(Id),
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)
create table TblPagos(
	Id int identity not null primary key,
	IdTblCliente int not null foreign key references TblClientes(Id), 
	IdTblVendedores int not null foreign key references TblVendedores(Id), 
	IdTblOrdenes int not null foreign key references TblOrdenes(Id),
	IdCatEstatus int not null foreign key references CatEstatusPago(Id), 
	Concepto varchar(250) not null,
	CantidadProductos int not null,
	MontoTotal float not null,	
	Activo bit default 1 not null,
	FechaCreacion datetime default getDate() not null,
)

USE [PruebaBancoBase]
GO

INSERT INTO [dbo].[CatEstatusPago] ([Estatus]) VALUES ('Pendiente'); 
INSERT INTO [dbo].[CatEstatusPago] ([Estatus]) VALUES ('Pagado');
INSERT INTO [dbo].[CatEstatusPago] ([Estatus]) VALUES ('Rechazado');


INSERT INTO [dbo].[TblClientes] ([Nombre], [RFC]) VALUES ('Cliente 1', 'YFJQ751009HGA');
INSERT INTO [dbo].[TblClientes] ([Nombre], [RFC]) VALUES ('Cliente 2', 'GOME341120YR0');



INSERT INTO [dbo].[TblVendedores] ([Nombre], [RFC]) VALUES ('Vendedor 1', 'BRB311010ST7');
INSERT INTO [dbo].[TblVendedores] ([Nombre], [RFC]) VALUES ('Vendedor 2', 'QUF130716QH3');



INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (1, 'Martillo', 250.65);
INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (1, 'Pinzas', 145.00);
INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (1, 'Taladro', 650.95);
INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (2, 'Desarmador', 95.50);
INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (2, 'Escalera', 790.88);
INSERT INTO [dbo].[TblProductos] ([IdTblVendedor],[Producto], [Precio]) VALUES (2, 'Serrucho', 263.16);