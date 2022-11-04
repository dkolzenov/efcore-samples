# Entity Framework Core [CLI tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) migration commands:

## Reference
`Name` - The name of the migration.  
__For example__: `Initial`

`Project` - Relative path to the project folder of the target project. Default value is the current folder.  
__For example__: `EFCoreSample.Persistence.MySql`

`StartupProject` - Relative path to the project folder of the startup project. Default value is the current folder.  
__For example__: `EFCoreSample.Api`

`Context` - The name of the DbContext class to generate. If the DbContext is only one, then the attribute _is not required_.  
__For example__: `ApplicationDbContext`

## __Dotnet ef__ migration commands

* Create migration
```bash
dotnet ef migrations add `Name` --project `Project` --startup-project `StartupProject` --context `Context`
```

* Update database
```bash
dotnet ef database update --project `Project` --startup-project `StartupProject`
```

* Remove migration
```bash
dotnet ef migrations remove --project `Project` --startup-project `StartupProject`
```
