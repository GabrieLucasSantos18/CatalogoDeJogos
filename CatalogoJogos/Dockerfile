# Etapa 1 – Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "./CatalogoJogos.csproj"
RUN dotnet publish "./CatalogoJogos.csproj" -c Release -o /app

# Etapa 2 – Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

EXPOSE 8080
ENTRYPOINT ["dotnet", "CatalogoJogos.dll"]
