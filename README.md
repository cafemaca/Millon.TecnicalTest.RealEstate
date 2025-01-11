# Technical Test: Millon Real Estate Company

The purpose of this project is to carry out the technical test proposed by MILLON as part of the selection process for the position of Senior .NET Developer.

## Description

A large real estate company needs to create an API to obtain information about properties in United States, this is in a database as shown in the image, your task is to create a set of services:
* Create property building
* Add image from property
* Change price
* Update property
* List property with filters

## Presentation
The presentation of the solution is done through Swagger, which has the endpoints of the requested requirements:
### Create property building
This requirement is developed in the endpoint `/api/v1/Properties`
### Add image from property
This requirement is developed in the endpoint `/api/v1/Properties/{id}/AddImage`
### Change price
This requirement is developed in the endpoint `/api/v1/Properties/{id}/UpdatePrice`
### Update property
This requirement is developed in the endpoint `/api/v1/Properties/{Id}` where Id is the Property Id (unique).
### List property with filters
This requirement is developed in the endpoint `/api/v1/Properties/Paging` where the parameters are developed like this:
* "SearchTerm">This nullable string property is used to store a search term entered by the user. When this value is set, it can be used to filter the data based on the given search term, typically by matching the term with the content in one or more columns.
* "ColumnFilters">This nullable string property is designed to store additional filtering criteria based on specific columns. The format for this property is not defined in the code snippet, but it could be, for example, a JSON string representing column names and their corresponding filter values. `{[{"ColumnName": "columnname","Value": "value"}]}`
* "OrderBy">This property is a nullable string and is used to store the column name and sort order for sorting the data. For example, `{[{"ColumnName": "columnname","DESC": "True"}]}`.
* "PageIndex">An integer property representing the current page number. It is initialized to 1 by default.
* "PageSize">A public integer property with the Page Size.

### Data Base
The database is related to the one identified in the technical test approach. Its name is: RealEstateDB.
No creation script required. The application creates it at the first moment of execution

### Coding
The REST API Web services have been implemented in the .NET Framework 9.0 and with the C# programming language.

These services have been documented under Swagger for easy use in functional testing and documentation:

### Required manage
* .NET Framework 9.0.
* Entity Framework 9.0
* SQL Server

### installation
* Download the code to the desired location.
* Once the code has been downloaded, you must proceed to open the solution `Millon.TecnicalTest.RealEstate.sln`
* open the solution, you must modify the connection string to the desired database. this is done in the appsettings.json file and the entry `Millon.TecnicalTest.RealEstateDbConn`

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
