create database dbLiftPLUS;

use dbLiftPLUS;

-- Tabela Usuário

CREATE TABLE Usuarios (

    usuarioId INT PRIMARY KEY,

    usuarioNome VARCHAR(255),

    Peso DOUBLE,

    Altura DOUBLE,

    Sexo CHAR(1),

    Senha VARCHAR(255),

    Email VARCHAR(255)

);

 

-- Tabela Treino

CREATE TABLE Treinos (

    ID INT PRIMARY KEY,

    Nome VARCHAR(255),

    GrupoMuscular VARCHAR(255),

    dataRegistro DATE,

    UsuarioID INT,

    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(usuarioId)

);

 

-- Tabela Exercício

CREATE TABLE Exercicios (

    ID INT PRIMARY KEY,

    Nome VARCHAR(255),

    Musculo VARCHAR(255),

    TreinoID INT,

    FOREIGN KEY (TreinoID) REFERENCES Treinos(ID)

);

 

 

 

-- SIMULANDO INSERTS

 

-- Usuário

INSERT INTO Usuarios (usuarioId, usuarioNome, Peso, Altura, Sexo, Senha, Email)

VALUES (1, 'João', 70.5, 175.0, 'M', 'senha123', 'joao@example.com'),

(2, 'Maria', 60.0, 160.0, 'F', 'senha456', 'maria@example.com');

 

-- Treino

INSERT INTO Treinos (ID, Nome, GrupoMuscular, dataRegistro, UsuarioID)

VALUES (1, 'Treino de Pernas', 'Pernas', '2023-09-02', 1),

(2, 'Treino de Peito', 'Peito', '2023-09-02', 2);

    

-- Exercício

INSERT INTO Exercicios (ID, Nome, Musculo, TreinoID)

VALUES (1, 'Agachamento', 'Pernas', 1),

(2, 'Leg Press', 'Pernas', 1),

    (3, 'Supino', 'Peito', 2),

    (4, 'Crucifixo', 'Peito', 2);