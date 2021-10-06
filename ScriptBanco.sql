CREATE DATABASE BDSimuladoDAAW
GO

USE BDSimuladoDAAW
GO

CREATE TABLE Noticias (
	CdNoticia int PRIMARY KEY IDENTITY,
	DsTitulo varchar(60) NOT NULL,
	DtNoticia datetime NOT NULL,
	DsNoticia text NOT NULL
)
GO