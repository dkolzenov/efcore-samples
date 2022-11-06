# Entity Framework Core providers sample

### ★ Put a star if the repository was useful ★

##

### The repository was created as a demonstration of working with various database providers using ORM Entity Framework Core

## Providers
* [SQLite](https://www.sqlite.org)
* [MS SQL Server](https://www.microsoft.com/en-us/sql-server)
* [MySQL](https://www.mysql.com)
* [PostgreSQL](https://www.postgresql.org)
* [Oracle](https://www.oracle.com/database)

[Learn more about supported database providers for Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/providers)

## Configuring migrations

1. After opening terminal (command line), install dotnet ef tool (if it is not already installed) by entering the following command:
`dotnet tool install --global dotnet-ef`

2. Make sure that correct connection string is entered in the [appsettings.json](https://github.com/dkolzenov/efcore-samples/blob/main/samples/EFCoreSample.Api/appsettings.json) file ([learn more about connection strings](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings))

3. From terminal (command line) go to [samples](https://github.com/dkolzenov/efcore-samples/tree/main/samples) directory

4. Command to add migration:
```bash
dotnet ef migrations add `Name` --project `Project` --startup-project `StartupProject` --context `Context`
```

5. Command to update a database:
```bash
dotnet ef database update --project `Project` --startup-project `StartupProject` --context `Context`
```

6. Command to remove migration:
```bash
dotnet ef migrations remove --project `Project` --startup-project `StartupProject` --context `Context`
```

[Learn more about dotnet ef commands and parameters](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Reference for migration commands:

`Name` - The name of the migration.  
__For example__: `Initial`

`Project` - Relative path to the project folder of the target project. Default value is the current folder.  
__For example__: `EFCoreSample.Persistence.Sqlite`

`StartupProject` - Relative path to the project folder of the startup project. Default value is the current folder.  
__For example__: `EFCoreSample.Api`

`Context` - The name of the DbContext class to generate. If the DbContext is only one, then the attribute __is not required__.  
__For example__: `ApplicationDbContext`

## Connection strings

All connection strings must be located in the [appsettings.json](https://github.com/dkolzenov/efcore-samples/blob/main/samples/EFCoreSample.Api/appsettings.json) file ([learn more about connection strings](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings))

Connection strings example:
* MySQL
```bash
server=localhost;database=EFCoreSample;user=user;password=password
```
[more MySQL examples here](https://www.connectionstrings.com/mysql)

* Oracle
```bash
User Id=user;Password=password;Data Source=localhost:5432/EFCoreSample
```
[more Oracle examples here](https://www.connectionstrings.com/oracle)

* PostgreSQL
```bash
Host=localhost;Port=5432;Database=EFCoreSample;Username=postgres;Password=password
```
[more PostgreSQL examples here](https://www.connectionstrings.com/postgresql)

* SQLite
```bash
Data Source=EFCoreSample.db
```
[more SQLite examples here](https://www.connectionstrings.com/sqlite)

* MS SQL Server  
```bash
Server=(localdb)\\\\mssqllocaldb;Database=EFCoreSample;Trusted_Connection=True;
```
[more MS SQL Server examples here](https://www.connectionstrings.com/sql-server)

## Pay attention
In this example, the [EFCoreSample.Api](https://github.com/dkolzenov/efcore-samples/tree/main/samples/EFCoreSample.Api) project is connected to all database providers at once, which is basically impossible in a real project:
`one project cannot contain multiple providers, the code given is just an EXAMPLE of how to initialize a context using different providers`
