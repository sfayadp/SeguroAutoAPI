# SeguroAutoAPI

API RESTful para la gestión de pólizas de seguro de autos.

## Tabla de contenidos

- [Tecnologías utilizadas](#tecnologías-utilizadas)
- [Requerimientos](#requerimientos)
- [Configuración del proyecto](#configuración-del-proyecto)
- [Ejecución de la aplicación](#ejecución-de-la-aplicación)
- [Ejecución de pruebas](#ejecución-de-pruebas)
- [Documentación de la API](#documentación-de-la-api)

## Tecnologías utilizadas

- ASP.NET Core 6.0
- Entity Framework Core 6.0
- SQL Server
- AutoMapper
- NUnit
- Moq
- Swagger

## Requerimientos

- .NET SDK 6.0
- SQL Server

## Configuración del proyecto

1. Clonar el repositorio
2. Abrir la solución `SeguroAutoAPI.sln` en Visual Studio
3. Abrir la ventana de `Package Manager Console` y seleccionar el proyecto `SeguroAutoAPI`
4. Crea una base de datos en SQL Server.
5. Actualiza la cadena de conexión en el archivo appsettings.json para que apunte a la base de datos creada en el paso anterior.
6. Ejecutar el comando dotnet ef migrations add InitialMigration para generar el modelo 
7. Ejecutar el comando `Update-Database` para crear la base de datos
8. Compilar la solución

## Ejecución de la aplicación

1. Abrir la ventana de `Package Manager Console` y seleccionar el proyecto `SeguroAutoAPI`
2. Ejecutar el comando `dotnet run`
3. La aplicación estará disponible en `http://localhost:5000`

## Ejecución de pruebas

1. Abrir la ventana de `Test Explorer`
2. Seleccionar la opción `Run All Tests`
3. Se ejecutarán los tests unitarios y de integración

## Documentación de la API

La documentación de la API se genera automáticamente con Swagger. Para acceder a ella:

1. Ejecutar la aplicación
2. Abrir un navegador web
3. Navegar a `http://localhost:5000/swagger`

