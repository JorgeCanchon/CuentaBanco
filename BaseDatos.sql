USE master
GO
DROP DATABASE IF EXISTS CuentaBanco
GO
CREATE DATABASE CuentaBanco
GO
USE [CuentaBanco]
GO
CREATE TABLE [dbo].[Cliente](
	[ID] [int] NOT NULL,
	[Contrasena] [nvarchar](150) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__Cliente__3214EC27B26AA5B8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Cuenta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NumeroCuenta] [varchar](150) NOT NULL,
	[TipoCuenta] [varchar](50) NOT NULL,
	[SaldoInicial] [decimal](18, 0) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK__Cuenta__3214EC27D94C02DA] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Movimientos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TipoMovimiento] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[Saldo] [decimal](18, 0) NOT NULL,
	[IDCliente] [int] NOT NULL,
	[IDCuenta] [int] NULL,
 CONSTRAINT [PK__Movimien__3214EC2785E80275] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Persona](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Genero] [varchar](150) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Identificacion] [varchar](100) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[Telefono] [varchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF__Cliente__Estado__267ABA7A]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Cuenta] ADD  CONSTRAINT [DF__Cuenta__Estado__2A4B4B5E]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK__Cuenta__IDClient__2B3F6F97] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK__Cuenta__IDClient__2B3F6F97]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK__Movimient__IDCli__403A8C7D] FOREIGN KEY([IDCliente])
REFERENCES [dbo].[Cliente] ([ID])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK__Movimient__IDCli__403A8C7D]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK__Movimient__IDCue__412EB0B6] FOREIGN KEY([IDCuenta])
REFERENCES [dbo].[Cuenta] ([ID])
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK__Movimient__IDCue__412EB0B6]
GO
-- =============================================
-- Author:		Jorge Canchon
-- Create date: 15/11/2022
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ReporteEstadoDeCuenta
	@Identificacion VARCHAR(100),
	@FechaInicio DATETIME,
	@FechaFinal DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT M.Fecha, P.Nombre, C.NumeroCuenta, C.TipoCuenta, M.Saldo, C.Estado, 
		CASE WHEN M.TipoMovimiento = 'debito' 
			THEN CONCAT('-',M.Valor) 
			ELSE CONCAT('',M.Valor) 
		END [Valor], 
		CASE WHEN M.TipoMovimiento = 'debito' 
			THEN M.Saldo - M.Valor
			ELSE M.Saldo + M.Valor
		END SaldoDisponible
	FROM Movimientos M
	INNER JOIN Cuenta C ON M.IDCuenta = C.ID
	INNER JOIN Cliente CT ON CT.ID = M.IDCliente
	INNER JOIN Persona P ON P.ID = CT.ID
	WHERE P.Identificacion = @Identificacion AND
		M.Fecha BETWEEN @FechaInicio AND @FechaFinal
END
GO