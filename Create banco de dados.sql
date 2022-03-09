Create Database PRODUTOSTORE;
GO

Use PRODUTOSTORE;
GO

Create Table tblCategoriaProduto (
    Id int not null IDENTITY(1,1) PRIMARY KEY,
    Nome varchar(250) not null,
    Descricao varchar(250) not null,
    Ativo bit not null
);
GO

CREATE INDEX idx_ID_NOME
ON tblCategoriaProduto (Id, Nome);
GO

CREATE INDEX idx_ID_Descricao
ON tblCategoriaProduto (Id, Descricao);
GO

CREATE INDEX idx_ID_Nome_Descricao
ON tblCategoriaProduto (Id, Nome, Descricao);
GO

CREATE TABLE tblProduto (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Nome varchar(250) NOT NULL,
    Descricao varchar(250) not null,
    Ativo bit not null,
    Perecivel bit not null,
    CategoriaID int FOREIGN KEY REFERENCES tblCategoriaProduto(Id)
);
Go

CREATE INDEX idx_ID_Descricao
ON tblProduto (Id, Descricao);
GO

CREATE INDEX idx_ID_Nome
ON tblProduto (Id, Nome);
GO

CREATE INDEX idx_ID_Nome_Descricao
ON tblProduto (Id, Nome, Descricao);
GO

CREATE INDEX idx_ID_Nome_Categoria
ON tblProduto (Id, Nome, CategoriaID);
GO