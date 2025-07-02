CREATE DATABASE Peliculas;

USE 
Peliculas
GO
CREATE TABLE Director(
idDirector INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(200),
nationality VARCHAR(100),
age INT,
active BIT);

CREATE TABLE Movies(
idMovie INT IDENTITY(1,1) PRIMARY KEY,
idDirector INT,
name VARCHAR(100),
release_year DATE,
gender VARCHAR(50),
duration TIME,
FOREIGN KEY(idDirector) REFERENCES Director(idDirector));

