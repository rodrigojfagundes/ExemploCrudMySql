-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 14-Jun-2022 às 21:04
-- Versão do servidor: 10.4.24-MariaDB
-- versão do PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `exemplo_crud`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `documento`
--

CREATE TABLE `documento` (
  `Codigo` int(11) NOT NULL,
  `Titulo` varchar(30) DEFAULT NULL,
  `Processo` varchar(30) DEFAULT NULL,
  `Categoria` varchar(30) DEFAULT NULL,
  `Arquivo` varchar(1024) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `documento`
--

INSERT INTO `documento` (`Codigo`, `Titulo`, `Processo`, `Categoria`, `Arquivo`) VALUES
(1, 'Criar nova classe', 'Concluido', 'Desenvolvimento', 'localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/Usuario_arquivo_77.pdf'),
(2, 'Teste QualyTeam', 'Concluido', 'Categoria de Teste', 'localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/Usuario_arquivo_30.pdf'),
(3, 'Abc', 'Andamento', 'Categoria Abc', 'localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/Usuario_arquivo_245.pdf'),
(4, 'QualyTeam Teste', 'Andamento', 'Teste', 'localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/Usuario_arquivo_529.pdf'),
(5, 'Teste 1', 'Concluido', 'Categoria de Teste', 'localhost:5000/Arquivos/Arquivos_Usuario/Recebidos/Usuario_arquivo_285.pdf');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `documento`
--
ALTER TABLE `documento`
  ADD PRIMARY KEY (`Codigo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
