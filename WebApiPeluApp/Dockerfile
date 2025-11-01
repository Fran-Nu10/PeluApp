# Etapa base (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar csproj de cada capa
COPY ["WebApiPeluApp/WebApiPeluApp.csproj", "WebApiPeluApp/"]
COPY ["LogicaAccesoDatos/LogicaAccesoDatos.csproj", "LogicaAccesoDatos/"]
COPY ["LogicaAplicacion/LogicaAplicacion.csproj", "LogicaAplicacion/"]
COPY ["LogicaNegocio/LogicaNegocio.csproj", "LogicaNegocio/"]
COPY ["DTOs/DTOs.csproj", "DTOs/"]

RUN dotnet restore "WebApiPeluApp/WebApiPeluApp.csproj"

# Copiar el resto del código
COPY . .

WORKDIR /src/WebApiPeluApp
RUN dotnet publish "WebApiPeluApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final (runtime)
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApiPeluApp.dll"]
