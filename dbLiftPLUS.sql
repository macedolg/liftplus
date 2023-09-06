drop database dbLiftPLUS;

create database dbLiftPLUS;

use dbLiftPLUS;

-- Tabela Usuário

CREATE TABLE Usuarios (

    usuarioId INT PRIMARY KEY auto_increment,

    usuarioNome VARCHAR(255),

    Peso DOUBLE,

    Altura DOUBLE,

    Sexo CHAR(1),

    Senha VARCHAR(255),

    Email VARCHAR(255)

);

 

-- Tabela Treino

CREATE TABLE Treinos (

    ID INT PRIMARY KEY auto_increment,

    Nome VARCHAR(255),

    GrupoMuscular VARCHAR(255),

    dataRegistro DATE,

    UsuarioID INT,

    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(usuarioId)

);

 

-- Tabela Exercício

CREATE TABLE Exercicios (

    ID INT PRIMARY KEY auto_increment,

    Nome VARCHAR(255),

    Musculo VARCHAR(255),

    TreinoID INT,

    FOREIGN KEY (TreinoID) REFERENCES Treinos(ID)

);

 

 

 

-- SIMULANDO INSERTS

 

-- Usuário

INSERT INTO Usuarios (usuarioNome, Peso, Altura, Sexo, Senha, Email)

VALUES ('João', 70.5, 175.0, 'M', 'senha123', 'joao@example.com'),

('Maria', 60.0, 160.0, 'F', 'senha456', 'maria@example.com');

 

-- Treino

INSERT INTO Treinos (Nome, GrupoMuscular, dataRegistro)

VALUES ( 'Treino de Pernas', 'Pernas', '2023-09-02'),

('Treino de Peito', 'Peito', '2023-09-02');

    

-- Exercício

INSERT INTO Exercicios (Nome, Musculo)

VALUES ('Agachamento', 'Pernas'),

('Leg Press', 'Pernas'),

    ('Supino', 'Peito'),

    ('Crucifixo', 'Peito');