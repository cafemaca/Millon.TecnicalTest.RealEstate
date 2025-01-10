# Technical Test: Millon Real Estate Company

The purpose of this project is to carry out the technical test proposed by MILLON as part of the selection process for the position of Senior .NET Developer.

## Description

A large real estate company needs to create an API to obtain information about properties in United States, this is in a database as shown in the image, your task is to create a set of services:
● Create property building
● Add image from property
● Change price
● Update property
● List property with filters

## Presentation
The presentation of the solution is done through Swagger, which has the endpoints of the requested requirements.

### Data Base
La base de datos construída para la solución a nivel de tablas, se presenta el siguiente modelo enitdad/relación:
![Modelo E/R](/images/CoinkDB.png)

El script de creación de la base de datos y sus respectivas tablas se puede apreciar en: [Script Creación de base de datos Coink](ScriptsDB/ScriptCreateCoinkDB.sql)

### Coding
The REST API Web services have been implemented in the .NET Framework 9.0 and with the C# programming language.

These services have been documented under Swagger for easy use in functional testing and documentation:

![Documentación Swagger de los Servicios implementados](/images/SwaggerServicios.png)



### Required manage
* .NET Framework 9.0.
* Entity Framework 9.0
* Npgsql.EntityFrameworkCore.PostgreSQL 8.0

### installation

* Para el desarrollo de esta prueba, se instaló Postgres 17.0, es menester tener una versió instalada de postgres en un servidor determiando
* Descargar el código en el lugar deseado.
* Una vez descargado el código, sedebe proceder a abrir la solución CAFEMACA.Coink.PruebaTecnica.sln
* abierta la solución, se debe modificar el string de conexión a la base de datos deseada. esto se realiza en el archivo appsettings.json y la entrada CAFEMACA.Coink.PruebaTecnicaDbConn

### Running Web Api Rest Service

* From Visual Studio 2022 or Visual Studio Code it can be executed
* As Entity Framework has been used in the development of this technical test, the solution has implemented that if it is executed for the first time, it creates the database and its respective tables. That is, it is not necessary to previously execute a creation script.
## Autores

Developer

Carlos Fernando Malagón Cano  
[cmalagon@uniandes.edu.co](mailto:cmalagon@uniandes.edu.co)
LinkedIn: [https://www.linkedin.com/in/cmalagon/](https://www.linkedin.com/in/cmalagon/)

## License

This solution is part of the fulfillment of the technical test proposed for the position of BackEnd Developer proposed by Coink.
Therefore, its use and reproduction for purposes other than those proposed in this technical test is prohibited.

## Knowledge

For the development of this project we used:
* The solution is proposed under the management of the CLEAN ARCHITECTURE concept, using a Visual Studio template developed by the author of this technical test development.
* Management of Development Patterns such as: Options Pattern, Result Pattern, Repository Pattern, UnitOfWork Pattern
* The different services implemented have basic MemoryCache management for a better response time
* As good practices, processes such as: Health Check, Logging with Serilog are also managed.
* POSTGRES is used as the database engine
