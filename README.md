# ExaParcial_SandovalRamos

## Descripción

API REST desarrollada en ASP.NET Core para la gestión de citas médicas de una clínica privada.

## Funcionalidades

- Gestión de pacientes
- Gestión de médicos
- Gestión de citas médicas
- Operaciones CRUD
- Validaciones mediante Data Annotations
- Middleware para manejo de excepciones
- Almacenamiento en memoria mediante listas

## Tecnologías Utilizadas

- C#
- .NET
- ASP.NET Core Web API
- Postman
- GitHub

## Endpoints Principales

### Pacientes
- GET /api/pacientes
- POST /api/pacientes
- PUT /api/pacientes
- DELETE /api/pacientes/{id}

### Medicos
- GET /api/medicos
- POST /api/medicos
- PUT /api/medicos
- DELETE /api/medicos/{id}

### Citas
- GET /api/citas
- POST /api/citas
- PUT /api/citas
- DELETE /api/citas/{id}

## Ejecución

```bash
dotnet restore
dotnet run