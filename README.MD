
# ASPNET CORE - Foodie API

This is a personal project, cloning the flow of the [**IFood app**](https://www.ifood.com.br/). With the purpose of studying and practicing some .NET skills, SOLID and Clean Code development topics.
Reminder: this is just the API, the mobile app is in this location: [FooodieApp](https://github.com/miguelpombodev/foodie-app-expo)
## Badges

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg?style=for-the-badge)](https://choosealicense.com/licenses/mit/)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![GitHub Actions](https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?style=for-the-badge&logo=redis&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-%234ea94b.svg?style=for-the-badge&logo=mongodb&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

## This project uses

- Entity Framework;
- Fluent Mapping; 
- JWT Authentication;
- Serilog;
- xUnit;
- Github Actions
- MongoDB
- Redis

## Cloning and starting the project with Docker Compose
Clone the project with SSH
```bash
  git clone git@github.com:miguelpombodev/Foodie-API.git Foodie-API
```
or clone with HTTP

```bash
  git clone https://github.com/miguelpombodev/Foodie-API.git Foodie-API
```

Go to the directory

```bash
  cd Foodie-API
```

In the **appsettings.Development.json** file is set up to use the values of the standalone container, so you can create the container with the credentials you might like:
```bash
  "MainDatabase": "Server=localhost,1433;Database=Foodie_DB;User ID=sa;Password='<YOUR_PASSWORD>';TrustServerCertificate=true"
```

Then if you choose to use Docker Compose, now just run:
```bash
  docker-compose up
```
So all the services will be created as needed, however the ASPNETCORE_ENVIRONMENT __env var__ is set to **"Production"** value

### With StandAlones
Another way is to use a standalone container, to use it, just build your own SQL Server Container in this way:
```bash
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<STRONG_PASSWORD>" -p 1433:1433 -d --name <CONTAINER_NAME> mcr.microsoft.com/mssql/server:2022-latest
```
After the database configuration, you need to run the structural script:
[Database Structural Script 😄](https://github.com/miguelpombodev/Database-scripts/blob/main/SQL%20Server/Foodie_API_Script.sql)

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

