CREATE DATABASE streaming_db;
USE streaming_db;

CREATE TABLE Plataformas (
    id_plataforma INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    anio_fundacion INT
);

CREATE TABLE Directores (
    id_director INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    edad INT,
    sueldo DECIMAL(10,2)
);

CREATE TABLE Personajes (
    id_personaje INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    edad INT,
    genero VARCHAR(50)
);

CREATE TABLE Series (
    id_serie INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(150) NOT NULL,
    genero VARCHAR(100),
    anio_lanzamiento INT,
    id_personaje INT,
    id_director INT,
    id_plataforma INT,
    FOREIGN KEY (id_personaje) REFERENCES Personajes(id_personaje),
    FOREIGN KEY (id_director) REFERENCES Directores(id_director),
    FOREIGN KEY (id_plataforma) REFERENCES Plataformas(id_plataforma)
);

CREATE TABLE Temporadas (
    id_temporada INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(150),
    descripcion TEXT,
    id_serie INT NOT NULL,
    FOREIGN KEY (id_serie) REFERENCES Series(id_serie)
);

CREATE TABLE Episodios (
    id_episodio INT AUTO_INCREMENT PRIMARY KEY,
    nombre_episodio VARCHAR(150) NOT NULL,
    descripcion TEXT,
    puntacion DECIMAL(3,1),
    id_temporada INT NOT NULL,
    FOREIGN KEY (id_temporada) REFERENCES Temporadas(id_temporada)
);