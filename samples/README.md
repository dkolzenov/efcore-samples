# Entity Framework Core [CLI tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) migration commands:

## Reference
`Name` - The name of the migration.  
__For example__: `Initial`

`Project` - Relative path to the project folder of the target project. Default value is the current folder.  
__For example__: `EFCoreSample.Persistence.MySql`

`StartupProject` - Relative path to the project folder of the startup project. Default value is the current folder.  
__For example__: `EFCoreSample.Api`

`Context` - The name of the DbContext class to generate. If the DbContext is only one, then the attribute __is not required__.  
__For example__: `ApplicationDbContext`

## Dotnet ef migration commands

* Create migration
```bash
dotnet ef migrations add `Name` --project `Project` --startup-project `StartupProject` --context `Context`
```

* Update database
```bash
dotnet ef database update --project `Project` --startup-project `StartupProject` --context `Context`
```

* Remove migration
```bash
dotnet ef migrations remove --project `Project` --startup-project `StartupProject` --context `Context`
```

## Connection strings

All connection strings must be located in the [appsettings.json](https://github.com/dkolzenov/efcore-samples/blob/main/samples/EFCoreSample.Api/appsettings.json) file ([learn more about connection strings](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings))

Connection string examples:
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

* MS Access  
```bash
Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EFCoreSample.accdb;Persist Security Info=False
```
[more MS Access examples here](https://www.connectionstrings.com/access)
