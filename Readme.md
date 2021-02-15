# Introduction
ASP.NET Core codebase containing modularized architecture

# How it works
This is using ASP.NET Core with:

* CQRS and MediatR
  - Simplifying Development and Separating Concerns with MediatR
  - CQRS with MediatR and AutoMapper
  - Thin Controllers with CQRS and MediatR
* Unit of Work with Repository pattern
* AutoMapper
* Fluent Validation

# Getting started
Install the .NET Core SDK and lots of documentation: https://www.microsoft.com/net/download/core
Documentation for ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/

# Swagger URL
https://localhost:5555/swagger

# Layers inside the application
- Controllers layer ( REST API Web adapters, Jobs )
- Application layer ( Use cases, Application rules ) 
- Domain layer ( core business rules )
- Infrastructure layer ( Data providers DB, Message Queue, File system, etc. )

# References:
https://github.com/dotnet-architecture/eShopOnWeb/tree/master/src
https://github.com/jbogard/ContosoUniversityCore
https://github.com/gothinkster/aspnetcore-realworld-example-app/tree/master/src/Conduit
