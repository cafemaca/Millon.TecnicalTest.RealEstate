# Technical Test: Millon Real Estate Company

The purpose of this project is to carry out the technical test proposed by MILLON as part of the selection process for the position of Senior .NET Developer.

## Description

A large real estate company needs to create an API to obtain information about properties in United States, this is in a database as shown in the image, your task is to create a set of services:
● Create property building
● Add image from property
● Change price
● Update property
● List property with filters

## Presentación
The presentation of the solution is done through Swagger, which has the endpoints of the requested requirements.

### Base de Datos
La base de datos construída para la solución a nivel de tablas, se presenta el siguiente modelo enitdad/relación:
![Modelo E/R](/images/CoinkDB.png)

El script de creación de la base de datos y sus respectivas tablas se puede apreciar en: [Script Creación de base de datos Coink](ScriptsDB/ScriptCreateCoinkDB.sql)

### Codificación
Los servicios Web API REST se han implementado en .NET Framework 8.0 y con el lenguaje de programación C#.

Estos servicios han sido documentados bajo Swagger para su facil uso en pruebas funcionales y documentación de los mismos:

![Documentación Swagger de los Servicios implementados](/images/SwaggerServicios.png)



### Dependencias
* .NET Framework 8.0.
* Entity Framework 8.0
* Npgsql.EntityFrameworkCore.PostgreSQL 8.0

### Instalación

* Para el desarrollo de esta prueba, se instaló Postgres 17.0, es menester tener una versió instalada de postgres en un servidor determiando
* Descargar el código en el lugar deseado.
* Una vez descargado el código, sedebe proceder a abrir la solución CAFEMACA.Coink.PruebaTecnica.sln
* abierta la solución, se debe modificar el string de conexión a la base de datos deseada. esto se realiza en el archivo appsettings.json y la entrada CAFEMACA.Coink.PruebaTecnicaDbConn

### Ejecución del servicio Web Api Rest

* Desde Visual Studio 2022 o Visual Studio Code se puede realizar su ejecución
* Como en el desarrollo de esta prueba técnica se ha utilizado Entity Framework, la solución ha implementado que si se ejecuta por primera vez, este crea la basde de datos y sus respectivas tablas. Es decir, no es necesario previamente ejecurtar script de creación.

## Autores

Desarrollador

Carlos Fernando Malagón Cano  
[cmalagon@uniandes.edu.co](mailto:cmalagon@uniandes.edu.co)
LinkedIn: [https://www.linkedin.com/in/cmalagon/](https://www.linkedin.com/in/cmalagon/)

## Licencia

Esta solución es parte del cumplimiento de la prueba técnica propuesta para el cargo de Desarrollador BackEnd propuesto por Coink.
Por ende, está prohibida su utilización y reproducción para otros fines diferentes al planteado en esta prueba técnica.

## Conocimientos

Para el desarrollo de este proyecto se utilizó:
* La solución se plantea bajo el manejo del concepto de CLEAN ARCHITECTURE, utilizando un template de Visual Studio desarrollado por el propio autor de este desarrollo de la prueba técnica.
* Manejo de Patrones de Desarrollo como: Options Pattern, Result Pattern, Repository Patter, UnitOfWork Pattern
* Los diferentes servicios implementados poseen el manejo básico de MemoryCache para un mejor tiempo de respuesta de los mismos
* Como buenas prácticas igualmente se maneja procesos como: Health Check, Logging con Serilog
* Como motor de base de datos se utiliza POSTGRES
