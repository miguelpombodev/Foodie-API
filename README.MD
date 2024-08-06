
# ASPNET CORE - Foodie API

This is a personal project, cloning the flow of the [**IFood** app](https://www.ifood.com.br/). With the purpose of studying and practicing some .NET skills, SOLID and Clean Code development topics.
Reminder: this is just the API, the mobile app is in this location: [FooodieApp](https://github.com/miguelpombodev/foodie-app-expo)
## Badges

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


## This project uses

- Entity Framework;
- Fluent Mapping; 
- JWT Authentication;
- Serilog;
- xUnit;
- Github Actions

## Cloning and starting the project with Docker Compose
Clone the project with SSH
```bash
  git clone git@github.com:miguelpombodev/Foodie-API.git
```
or clone with HTTP

```bash
  git clone https://github.com/miguelpombodev/Foodie-API.git
```

Go to the directory

```bash
  cd Foodie-API
```

In the **appsettings.Development.json** file is set up to use the values of the Docker Compose yaml file:
```bash
  "MainDatabase": "Server=foodie_db,1433;Database=Foodie_DB;User ID=sa;Password='123456QWERT@#';TrustServerCertificate=true"
```

If you want to use a standalone container, created just with a 
```bash
  docker run
```
you need to change the **"foodie_db"** to **localhost**, and the credentials that you have chosen.

Then if you choose to use Docker Compose, now just run:
```bash
  docker-compose up
```
After the database configuration, you need to run the structural script:
[Database Structural Script 😄](https://github.com/miguelpombodev/Database-scripts/blob/main/SQL%20Server/Foodie_API_Script.sql)

### With StandAlones
Another way is to use a standalone container, to use it, just build your own SQL Server Container in this way:
```bash
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<STRONG_PASSWORD>" -p 1433:1433 -d --name <CONTAINER_NAME> mcr.microsoft.com/mssql/server:2022-latest
```

And then check if it is started, with the command:
```bash
  docker ps 
```

Now you can build and start the project with:
```bash
  dotnet build && dotnet run ./Foddie-API.Web/Foddie-API.Web.csproj
```

## License
[MIT](https://choosealicense.com/licenses/mit/)

