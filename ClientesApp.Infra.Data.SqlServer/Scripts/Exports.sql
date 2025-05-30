--Script para criação da tabela de cliente
CREATE TABLE Cliente(
	Id						UNIQUEIDENTIFIER	PRIMARY KEY,
	Nome					VARCHAR(100)		NOT NULL,
	Email					VARCHAR(50)			NOT NULL,
	Cpf						VARCHAR(11)			NOT NULL,
	DataHoraCriacao			DATETIME			NOT NULL,
	DataHoraUltimaAlteracao	DATETIME			NOT NULL,
	Ativo					BIT					NOT NULL);
GO