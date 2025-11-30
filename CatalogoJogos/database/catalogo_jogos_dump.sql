-- phpMyAdmin SQL Dump
-- version 5.2.1 
-- https://www.phpmyadmin.net/ 
-- 
-- Host: 127.0.0.1 
-- Tempo de geração: 26/11/2025 às 02:02 
-- Versão do servidor: 10.4.32-MariaDB 
-- Versão do PHP: 8.2.12 

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO"; 
START TRANSACTION; 
SET time_zone = "+00:00"; 

-- 
-- Banco de dados: catalogo_jogos 
-- 

CREATE DATABASE IF NOT EXISTS catalogo_jogos DEFAULT CHARACTER 
SET utf8mb4 COLLATE utf8mb4_general_ci; 
USE catalogo_jogos; 

-- --------------------------------------------------------

-- 
-- Estrutura para tabela jogo 
-- 

CREATE TABLE jogo ( 
  ID_jogo int(11) NOT NULL, 
  titulo varchar(150) NOT NULL, 
  descricao text NOT NULL, 
  genero varchar(40) NOT NULL, 
  preco decimal(6,2) NOT NULL, 
  tamanho bigint(20) NOT NULL, 
  classificacao tinyint(2) NOT NULL, 
  avaliacao varchar(30) NOT NULL, 
  data_lancamento datetime NOT NULL DEFAULT current_timestamp(), 
  desenvolvedora varchar(35) NOT NULL, 
  plataforma text NOT NULL 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci; 

-- -------------------------------------------------------- 

-- 
-- Estrutura para tabela jogoconsole 
-- 

CREATE TABLE jogoconsole ( 
  ID_jogoconsole int(11) NOT NULL, 
  ID_jogo int(11) NOT NULL, 
  console_especifico varchar(15) NOT NULL, 
  suporte_multiplayer tinyint(1) NOT NULL 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci; 

-- -------------------------------------------------------- 

-- 
-- Estrutura para tabela jogomobile 
-- 

CREATE TABLE jogomobile ( 
  ID_jogomobile int(11) NOT NULL, 
  ID_jogo int(11) NOT NULL, 
  precisa_conexao tinyint(1) NOT NULL 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci; 

-- -------------------------------------------------------- 

-- 
-- Estrutura para tabela jogopc 
-- 

CREATE TABLE jogopc ( 
  ID_jogopc int(11) NOT NULL, 
  ID_jogo int(11) NOT NULL, 
  requisitos_minimos text NOT NULL, 
  requisitos_recomendados text NOT NULL 
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci; 

-- 
-- Índices para tabelas despejadas 
-- 

-- 
-- Índices de tabela jogo 
-- 

ALTER TABLE jogo 
  ADD PRIMARY KEY (ID_jogo); 

-- 
-- Índices de tabela jogoconsole 
-- 

ALTER TABLE jogoconsole 
  ADD PRIMARY KEY (ID_jogoconsole), 
  ADD KEY fkconsole_ID_jogo (ID_jogo); 

-- 
-- Índices de tabela jogomobile 
-- 

ALTER TABLE jogomobile 
  ADD PRIMARY KEY (ID_jogomobile), 
  ADD KEY fkmobile_ID_jogo (ID_jogo); 

-- 
-- Índices de tabela jogopc 
-- 

ALTER TABLE jogopc 
  ADD PRIMARY KEY (ID_jogopc), 
  ADD KEY fkpc_ID_jogo (ID_jogo); 

-- 
-- AUTO_INCREMENT para tabelas despejadas 
-- 

-- 
-- AUTO_INCREMENT de tabela jogo 
-- 

ALTER TABLE jogo 
  MODIFY ID_jogo int(11) NOT NULL AUTO_INCREMENT; 

-- 
-- AUTO_INCREMENT de tabela jogoconsole 
-- 

ALTER TABLE jogoconsole 
  MODIFY ID_jogoconsole int(11) NOT NULL AUTO_INCREMENT; 

-- 
-- AUTO_INCREMENT de tabela jogomobile 
-- 

ALTER TABLE jogomobile
  MODIFY ID_jogomobile int(11) NOT NULL AUTO_INCREMENT; 

-- 
-- AUTO_INCREMENT de tabela jogopc 
-- 

ALTER TABLE jogopc 
  MODIFY ID_jogopc int(11) NOT NULL AUTO_INCREMENT; 

-- 
-- Restrições para tabelas despejadas 
-- 

-- 
-- Restrições para tabelas jogoconsole 
-- 

ALTER TABLE jogoconsole 
  ADD CONSTRAINT fkconsole_ID_jogo FOREIGN KEY (ID_jogo) 
REFERENCES jogo (ID_jogo); 

-- 
-- Restrições para tabelas jogomobile 
-- 

ALTER TABLE jogomobile 
  ADD CONSTRAINT fkmobile_ID_jogo FOREIGN KEY (ID_jogo) 
REFERENCES jogo (ID_jogo); 

-- 
-- Restrições para tabelas jogopc 
-- 

ALTER TABLE jogopc 
  ADD CONSTRAINT fkpc_ID_jogo FOREIGN KEY (ID_jogo) 
REFERENCES jogo (ID_jogo); COMMIT;

--
-- Inserções para tabelas jogopc
--

INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (1, 'Cyberpunk 2077', 'RPG futurista mundo aberto', 'RPG', 199.90, 70000, 18, '9.0', NOW(), 'CD Projekt Red', 'PC');

INSERT INTO jogopc (ID_jogo, requisitos_minimos, requisitos_recomendados)
VALUES (1, 'i5 / GTX 960 / 8GB RAM', 'i7 / RTX 2060 / 16GB RAM');


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (2, 'Valorant', 'FPS tático 5v5', 'FPS', 0.00, 30000, 14, '8.8', NOW(), 'Riot Games', 'PC');

INSERT INTO jogopc (ID_jogo, requisitos_minimos, requisitos_recomendados)
VALUES (2, 'i3 / GT 730 / 4GB RAM', 'i5 / GTX 1050 / 8GB RAM');


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (3, 'Microsoft Flight Simulator', 'Simulação realista de aviação', 'Simulação', 249.99, 120000, 12, '9.5', NOW(), 'Microsoft', 'PC');

INSERT INTO jogopc (ID_jogo, requisitos_minimos, requisitos_recomendados)
VALUES (3, 'i5 / GTX 770 / 8GB RAM', 'i7 / RTX 2080 / 32GB RAM');

--
-- Inserções para tabelas jogoconsole
--

INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (4, 'God of War Ragnarok', 'Jornada de Kratos e Atreus', 'Ação', 299.99, 90000, 18, '9.8', NOW(), 'Santa Monica Studio', 'Console');

INSERT INTO jogoconsole (ID_jogo, console_especifico, suporte_multiplayer)
VALUES (4, 'PlayStation 5', 0);


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (5, 'Halo Infinite', 'Campanha e multiplayer futurista', 'FPS', 259.99, 80000, 16, '8.9', NOW(), '343 Industries', 'Console');

INSERT INTO jogoconsole (ID_jogo, console_especifico, suporte_multiplayer)
VALUES (5, 'Xbox Series X', 1);


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (6, 'Mario Kart 8 Deluxe', 'Corridas com personagens Nintendo', 'Corrida', 249.99, 5000, 3, '9.2', NOW(), 'Nintendo', 'Console');

INSERT INTO jogoconsole (ID_jogo, console_especifico, suporte_multiplayer)
VALUES (6, 'Nintendo Switch', 1);

--
-- Inserções para tabelas jogomobile
--

INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (7, 'Clash Royale', 'Batalhas PvP em tempo real', 'Estratégia', 0.00, 250, 10, '8.5', NOW(), 'Supercell', 'Mobile');

INSERT INTO jogomobile (ID_jogo, precisa_conexao)
VALUES (7, 1);


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (8, 'Minecraft Pocket Edition', 'Sobrevivência e construção', 'Aventura', 29.90, 300, 7, '9.4', NOW(), 'Mojang', 'Mobile');

INSERT INTO jogomobile (ID_jogo, precisa_conexao)
VALUES (8, 0);


INSERT INTO jogo (ID_jogo, titulo, descricao, genero, preco, tamanho, classificacao, avaliacao, data_lancamento, desenvolvedora, plataforma)
VALUES (9, 'PUBG Mobile', 'Battle Royale 100 jogadores', 'FPS', 0.00, 2200, 16, '8.9', NOW(), 'Tencent', 'Mobile');

INSERT INTO jogomobile (ID_jogo, precisa_conexao)
VALUES (9, 1);
