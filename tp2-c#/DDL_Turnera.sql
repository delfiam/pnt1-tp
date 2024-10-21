-- Instrucción para crear la base de datos
CREATE DATABASE TURNERA


-- Activo o me ubico en la base de datos que quiero usar
USE TURNERA;

-- Create Clinica table
CREATE TABLE Clinica (
    idClinica INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL
);

-- Create Turnera table
CREATE TABLE Turnera (
    idTurnera INT PRIMARY KEY IDENTITY(1,1),
    idClinica INT,
    FOREIGN KEY (idClinica) REFERENCES Clinica(idClinica)
);

-- Create Persona table
CREATE TABLE Persona (
    idPersona INT PRIMARY KEY IDENTITY(1,1),
    dni VARCHAR(20) NOT NULL,
    nombre VARCHAR(100) NOT NULL
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
    idMedico INT PRIMARY KEY,
    idEspecialidad INT,
    FOREIGN KEY (idMedico) REFERENCES Persona(idPersona),
    FOREIGN KEY (idEspecialidad) REFERENCES Especialidad(idEspecialidad)
);

-- Create Paciente table
CREATE TABLE Paciente (
    idPaciente INT PRIMARY KEY,
    idObraSocial INT,
    FOREIGN KEY (idPaciente) REFERENCES Persona(idPersona),
    FOREIGN KEY (idObraSocial) REFERENCES ObraSocial(idObraSocial)
);

-- Create Ticket table
CREATE TABLE Ticket (
    idTicket INT PRIMARY KEY IDENTITY(1,1),
    idTurnera INT,
    nroTurno INT NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    idPaciente INT,
    idMedico INT,
    FOREIGN KEY (idTurnera) REFERENCES Turnera(idTurnera),
    FOREIGN KEY (idPaciente) REFERENCES Paciente(idPaciente),
    FOREIGN KEY (idMedico) REFERENCES Medico(idMedico)
);