FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /foodie

# Build da aplicacao
COPY . ./

RUN dotnet publish -c Release -o out

EXPOSE 8080

# Build da imagem
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /foodie
COPY --from=build-env /foodie/out .
ENTRYPOINT ["dotnet", "FoodieAPI.Web.dll"]