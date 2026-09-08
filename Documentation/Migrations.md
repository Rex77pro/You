# Migrations

The project is using **Entity Framework Core** for database and migrations handling to a **postgreSQL** databse. 

## Prerequisites

This is a short description of, what is included in the project and what is needed to run similar commands for dabase handling.

### Installed globally
* *dotnet-ef*

### Installed locally
* *Microsoft.EntityFrameworkCore*
* *Microsoft.EntityFrameworkCore.Design*
* *Microsoft.EntityFrameworkCore.Tools*
* *Npgsql.EntityFrameworkCore.PostgreSQL*

## Commands

These are the most common and most used commands for drop, migrate and update the database

### Create Migration
`dotnet ef migrations add [migration name] --project [project name](.\You.Infrastructure\) --startup-project [startup project](.\You.Api\)`

### Update (apply migrations)
`dotnet ef database update [startup project](.\You.Api\)`

### Drop database
`dotnet ef database drop --project [project name](.\You.Infrastructure\) --startup-project [startup project](.\You.Api\)`