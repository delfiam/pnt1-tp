

-- Activo o me ubico en la base de datos que quiero usar
USE TURNERA;


-- Crear la tabla Persona
CREATE TABLE Persona (
    idPersona INT PRIMARY KEY IDENTITY(1,1),
    dni NVARCHAR(20) NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    Discriminator NVARCHAR(50)  -- Indica si es Paciente o Medico
);

-- Crear la tabla Paciente
CREATE TABLE Paciente (
    idPersona INT PRIMARY KEY, -- Llave primaria que se relaciona con Persona
    obraSocial NVARCHAR(50) NOT NULL, -- Almacena el enum como string
    FOREIGN KEY (idPersona) REFERENCES Persona(idPersona) -- Establece la relación con la tabla Persona
);


-- Create Especialidad enum table
CREATE TABLE Especialidad (
    idEspecialidad INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL
);

-- Insert Especialidad enum values
INSERT INTO Especialidad (nombre) VALUES 
('PEDIATRIA'), ('TRAUMATO'), ('OFTALMO'), ('DERMATOLOGIA');

-- Create ObraSocial enum table
CREATE TABLE ObraSocial (
    idObraSocial INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL
);

-- Insert ObraSocial enum values
INSERT INTO ObraSocial (nombre) VALUES 
('PAMI'), ('OSECAC'), ('OSLERA');

-- Create Medico table
CREATE TABLE Medico (
    idPersona INT PRIMARY KEY, -- Esta clave se refiere a idPersona en Persona
   especialidad NVARCHAR(50) NOT NULL, -- Almacena el enum como string
    FOREIGN KEY (idPersona) REFERENCES Persona(idPersona) -- Establece la relación con la tabla Persona
);

