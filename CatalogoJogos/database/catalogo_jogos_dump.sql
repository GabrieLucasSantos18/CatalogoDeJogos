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
  preco decimal(4,2) NOT NULL, 
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
