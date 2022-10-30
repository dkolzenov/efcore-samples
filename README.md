# Entity Framework Core samples

### Ставь звезду, если репозиторий был полезен / Put a star if the repository was useful

##

###### `RU Translate`
### Репозиторий создан в качестве демонстрации работы с различными провайдерами (поставщиками) баз данных с использованием ORM Entity Framework Core

## Провайдеры (поставщики)
* [SQLite](https://www.sqlite.org)
* [MS SQL Server](https://www.microsoft.com/ru-ru/sql-server)
* [MySQL](https://www.mysql.com)
* [PostgreSQL](https://www.postgresql.org)
* [Oracle](https://www.oracle.com/database)

[Подробнее о поддерживаемых провайдерах (поставщиках) баз данных для Entity Framework Core](https://learn.microsoft.com/ru-ru/ef/core/providers)

## Настройка миграции

В данном примере миграция была создана с использованием провайдера (поставщика) SQLite:

1. Открыв терминал (командную строку), установить инструмент dotnet ef (если он ещё не установлен), введя следующую команду:
`dotnet tool install --global dotnet-ef`

2. Убедиться, что в файле [samples/EFCoreSample.Api/appsettings.json](https://github.com/dkolzenov/efcore-samples/blob/main/samples/EFCoreSample.Api/appsettings.json) введена корректная строка подключения ([подробнее о строках подключения](https://learn.microsoft.com/ru-ru/ef/core/miscellaneous/connection-strings))

3. Из терминала (командной строки) перейди в каталог [/samples](https://github.com/dkolzenov/efcore-samples/tree/main/samples)

4. Команда для добавления миграции:
`dotnet ef migrations add Initial --project EFCoreSample.Persistence.Sqlite --startup-project EFCoreSample.Api`

5. Команда для создания (обновления) базы данных:
`dotnet ef database update --project EFCoreSample.Persistence.Sqlite --startup-project EFCoreSample.Api`

[Подробнее о командах и параметрах dotnet ef](https://learn.microsoft.com/ru-ru/ef/core/cli/dotnet)

## Обрати внимание
В данном примере проект [EFCoreSample.Api](https://github.com/dkolzenov/efcore-samples/tree/main/samples/EFCoreSample.Api) связан со всеми провайдерами (поставщиками) баз данных сразу, что в принципе невозможно в реальном проекте:
`один проект не может содержать несколько поставщиков, приведенный код является лишь ПРИМЕРОМ того, как инициализировать контекст с использованием разных поставщиков`

##
##
##

###### `EN translate`
### The repository was created as a demonstration of working with various database providers using ORM Entity Framework Core

## Providers
* [SQLite](https://www.sqlite.org)
* [MS SQL Server](https://www.microsoft.com/en-us/sql-server)
* [MySQL](https://www.mysql.com)
* [PostgreSQL](https://www.postgresql.org)
* [Oracle](https://www.oracle.com/database)

[Learn more about supported database providers for Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/providers)

## Configuring migration

In this example, a migration was created using SQLite provider:

1. After opening terminal (command line), install dotnet ef tool (if it is not already installed) by entering the following command:
`dotnet tool install --global dotnet-ef`

2. Make sure that correct connection string is entered in the [samples/EFCoreSample.Api/appsettings.json](https://github.com/dkolzenov/efcore-samples/blob/main/samples/EFCoreSample.Api/appsettings.json) file ([learn more about connection strings](https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings))

3. From terminal (command line) go to [/samples](https://github.com/dkolzenov/efcore-samples/tree/main/samples) directory

4. Command to add migration:
`dotnet ef migrations add Initial --project EFCoreSample.Persistence.Sqlite --startup-project EFCoreSample.Api`

5. Command to update a database:
`dotnet ef database update --project EFCoreSample.Persistence.Sqlite --startup-project EFCoreSample.Api`

[Learn more about dotnet ef commands and parameters](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

## Pay attention
In this example, the [EFCoreSample.Api](https://github.com/dkolzenov/efcore-samples/tree/main/samples/EFCoreSample.Api) project is connected to all database providers at once, which is basically impossible in a real project:
`one project cannot contain multiple providers, the code given is just an EXAMPLE of how to initialize a context using different providers`
