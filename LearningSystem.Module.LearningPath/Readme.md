# Introduction
Learning System - Learning Path Module

# EF reference
Run EF Core Migrations from the Module directory, as follows:
```
* Make sure you have installed dotnet-ef tool, if not run the command:
dotnet tool install --global dotnet-ef --version 3.1.1

* Add EntityFrameworkCore.Design package to the project

* Create initial migrations
dotnet ef migrations add Initial

* Remove the last migration in code
dotnet ef migrations remove 

* Create migration script
dotnet ef migrations script <?Last_Migration_Name> -o ./Migrations-Scripts/YYYYmmDD-xxx.sql
```