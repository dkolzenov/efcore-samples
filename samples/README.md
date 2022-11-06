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

* MySQL  
__For example__: `server=localhost;database=EFCoreSample;user=user;password=password` ([more examples here](https://www.connectionstrings.com/mysql))

* Oracle  
__For example__: `User Id=user;Password=password;Data Source=localhost:5432/EFCoreSample` ([more examples here](https://www.connectionstrings.com/oracle))

* PostgreSQL  
__For example__: `Host=localhost;Port=5432;Database=EFCoreSample;Username=postgres;Password=password` ([more examples here](https://www.connectionstrings.com/postgresql))

* SQLite  
__For example__: `Data Source=EFCoreSample.db` ([more examples here](https://www.connectionstrings.com/sqlite))

* MS SQL Server  
__For example__: `Server=(localdb)\\\\mssqllocaldb;Database=EFCoreSample;Trusted_Connection=True;` ([more examples here](https://www.connectionstrings.com/sql-server))
