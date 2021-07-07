-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-06-2021 a las 21:56:00
-- Versión del servidor: 10.4.18-MariaDB
-- Versión de PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dv-tp-plataformasdedesarrollo`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alojamientos`
--

CREATE TABLE `alojamientos` (
  `codigo` int(11) NOT NULL,
  `ciudad` varchar(100) NOT NULL,
  `barrio` varchar(100) NOT NULL,
  `estrellas` int(2) NOT NULL,
  `cantidadDePersonas` int(2) DEFAULT NULL,
  `tv` tinyint(1) NOT NULL,
  `precioPorPersona` float UNSIGNED DEFAULT 0,
  `precioPorDia` float UNSIGNED DEFAULT 0,
  `habitaciones` int(2) DEFAULT 0,
  `banios` int(2) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `alojamientos`
--

INSERT INTO `alojamientos` (`codigo`, `ciudad`, `barrio`, `estrellas`, `cantidadDePersonas`, `tv`, `precioPorPersona`, `precioPorDia`, `habitaciones`, `banios`) VALUES
(103301, 'rosario', 'centro', 1, 3, 1, 0, 3500, 1, 1),
(123111, 'carlos paz', 'centro', 1, 1, 1, 4500, 0, 0, 0),
(234432, 'buenos aires', 'sur', 2, 4, 1, 0, 4000, 2, 1),
(315434, 'rosario', 'centro', 1, 2, 0, 1800, 0, 0, 0),
(332131, 'carlos paz', 'norte', 2, 3, 1, 0, 6000, 2, 1),
(523423, 'buenos aires', 'palermo', 2, 1, 1, 3000, 0, 0, 0),
(843511, 'buenos aires', 'puerto madero', 1, 1, 1, 3500, 0, 0, 0),
(856722, 'carlos paz', 'centro', 1, 6, 1, 0, 2400, 2, 1),
(987789, 'carlos paz', 'sur', 1, 6, 1, 0, 2800, 1, 1);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `cabanias`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `cabanias` (
`codigo` int(11)
,`ciudad` varchar(100)
,`barrio` varchar(100)
,`estrellas` int(2)
,`cantidadDePersonas` int(2)
,`tv` tinyint(1)
,`precioPorDia` float unsigned
,`habitaciones` int(2)
,`banios` int(2)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `hoteles`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `hoteles` (
`codigo` int(11)
,`ciudad` varchar(100)
,`barrio` varchar(100)
,`estrellas` int(2)
,`cantidadDePersonas` int(2)
,`tv` tinyint(1)
,`precioPorPersona` float unsigned
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reservas`
--

CREATE TABLE `reservas` (
  `id` int(50) UNSIGNED NOT NULL,
  `fechaDesde` datetime NOT NULL,
  `fechaHasta` datetime NOT NULL,
  `alojamiento_codigo` int(11) UNSIGNED NOT NULL,
  `usuario_dni` int(10) UNSIGNED NOT NULL,
  `precio` double UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `reservas`
--

INSERT INTO `reservas` (`id`, `fechaDesde`, `fechaHasta`, `alojamiento_codigo`, `usuario_dni`, `precio`) VALUES
(3, '2021-06-04 00:00:00', '2021-06-09 00:00:00', 332131, 12312312, 30000),
(4, '2021-05-14 00:00:00', '2021-05-22 00:00:00', 523423, 12312312, 24000),
(5, '2021-05-14 00:00:00', '2021-05-19 00:00:00', 234432, 12312312, 20000),
(6, '2021-05-14 00:00:00', '2021-05-15 00:00:00', 123111, 12378956, 4500),
(7, '2021-05-14 00:00:00', '2021-05-15 00:00:00', 103301, 12378956, 3500),
(8, '2021-05-14 00:00:00', '2021-05-22 00:00:00', 987789, 12378956, 22400),
(9, '2021-05-14 00:00:00', '2021-05-22 00:00:00', 843511, 43987789, 28000),
(10, '2021-05-19 00:00:00', '2021-05-22 00:00:00', 856722, 43987789, 7200),
(11, '2021-06-03 00:00:00', '2021-06-10 00:00:00', 856722, 43987789, 16800),
(14, '2021-06-07 00:00:00', '2021-06-10 00:00:00', 315434, 23443243, 10800),
(15, '2021-06-07 00:00:00', '2021-06-10 00:00:00', 103301, 23443243, 10500),
(16, '2021-06-23 00:00:00', '2021-06-25 00:00:00', 856722, 23443243, 4800),
(21, '2021-06-09 00:00:00', '2021-06-15 00:00:00', 843511, 44567567, 21000),
(22, '2021-06-11 00:00:00', '2021-06-12 00:00:00', 987789, 12312312, 2800),
(23, '2021-07-01 00:00:00', '2021-07-05 00:00:00', 523423, 12312312, 12000),
(24, '2021-06-18 00:00:00', '2021-06-19 00:00:00', 843511, 12312312, 3500);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `dni` int(10) UNSIGNED NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `isAdmin` tinyint(1) DEFAULT 0,
  `isBloqueado` tinyint(1) DEFAULT 0,
  `intentos` int(4) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`dni`, `nombre`, `email`, `password`, `isAdmin`, `isBloqueado`) VALUES
(12312312, 'nuevoNombre', 'nuevoEmail@prueba.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0),
(12378956, 'cliente1', 'cliente1@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0),
(23443243, 'cliente2', 'cliente2@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0),
(40393222, 'admin', 'admin@admin.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 1, 0),
(43243243, 'cliente3', 'cliente3@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 1),
(43987789, 'cliente4', 'cliente4@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0),
(44567567, 'pepe', 'pepe@gmail.com', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 0, 0);

-- --------------------------------------------------------

--
-- Estructura para la vista `cabanias`
--
DROP TABLE IF EXISTS `cabanias`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `cabanias`  AS SELECT `alojamientos`.`codigo` AS `codigo`, `alojamientos`.`ciudad` AS `ciudad`, `alojamientos`.`barrio` AS `barrio`, `alojamientos`.`estrellas` AS `estrellas`, `alojamientos`.`cantidadDePersonas` AS `cantidadDePersonas`, `alojamientos`.`tv` AS `tv`, `alojamientos`.`precioPorDia` AS `precioPorDia`, `alojamientos`.`habitaciones` AS `habitaciones`, `alojamientos`.`banios` AS `banios` FROM `alojamientos` WHERE `alojamientos`.`precioPorPersona` = 0 ;

-- --------------------------------------------------------

--
-- Estructura para la vista `hoteles`
--
DROP TABLE IF EXISTS `hoteles`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `hoteles`  AS SELECT `alojamientos`.`codigo` AS `codigo`, `alojamientos`.`ciudad` AS `ciudad`, `alojamientos`.`barrio` AS `barrio`, `alojamientos`.`estrellas` AS `estrellas`, `alojamientos`.`cantidadDePersonas` AS `cantidadDePersonas`, `alojamientos`.`tv` AS `tv`, `alojamientos`.`precioPorPersona` AS `precioPorPersona` FROM `alojamientos` WHERE `alojamientos`.`precioPorPersona` <> 0 ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `alojamientos`
--
ALTER TABLE `alojamientos`
  ADD PRIMARY KEY (`codigo`);

--
-- Indices de la tabla `reservas`
--
ALTER TABLE `reservas`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`dni`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `reservas`
--
ALTER TABLE `reservas`
  MODIFY `id` int(50) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
