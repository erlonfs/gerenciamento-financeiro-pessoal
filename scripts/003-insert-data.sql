USE GerenciamentoFinanceiro;
GO

INSERT INTO COMP.FormaPagto(Id, Nome) VALUES(1, 'Débito');
INSERT INTO COMP.FormaPagto(Id, Nome) VALUES(2, 'Crédito');
INSERT INTO COMP.FormaPagto(Id, Nome) VALUES(3, 'Dinheiro');
INSERT INTO COMP.FormaPagto(Id, Nome) VALUES(4, 'Boleto');
GO

INSERT INTO COMP.LancamentoTipo(Id, Nome) VALUES(1, 'Receita');
INSERT INTO COMP.LancamentoTipo(Id, Nome) VALUES(2, 'Despesa');
GO
