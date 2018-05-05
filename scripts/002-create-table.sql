DROP TABLE COMP.Lancamento;
DROP TABLE COMP.Competencia;

CREATE TABLE COMP.Competencia(
	Id INT IDENTITY NOT NULL,
	DataCriacao DATETIME NOT NULL,
	Mes INT NOT NULL,
	Ano INT NOT NULL
)
GO
ALTER TABLE COMP.Competencia ADD CONSTRAINT PK_Competencia PRIMARY KEY (Id)
GO

CREATE TABLE COMP.Lancamento(
	Id INT IDENTITY NOT NULL,
	DataCriacao DATETIME NOT NULL,
	CompetenciaId INT NOT NULL
)
GO
ALTER TABLE COMP.Lancamento ADD CONSTRAINT PK_Lancamento PRIMARY KEY (Id)
ALTER TABLE COMP.Lancamento ADD CONSTRAINT FK_Lancamento_Competencia FOREIGN KEY (CompetenciaId) REFERENCES COMP.Competencia(Id);
GO