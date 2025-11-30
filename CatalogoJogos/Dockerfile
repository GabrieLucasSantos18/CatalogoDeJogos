FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY CatalogoJogos. csproj

RUN dotnet restore "./CatalogoJogos.csproj"

COPY . .
RUN dotnet publish "./CatalogoJogos.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE URLS=http://+:8181
EXPOSE 8181
ENTRYPOINT ["dotnet", "CatalogoJogos.dll"]
