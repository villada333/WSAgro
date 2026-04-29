# Establecer la imagen base para el entorno de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Configurar zona horaria
RUN apt-get update \
    && apt-get install -y tzdata \
    && ln -fs /usr/share/zoneinfo/America/Bogota /etc/localtime \
    && dpkg-reconfigure --frontend noninteractive tzdata

# Establecer la imagen base para el entorno de desarrollo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de proyecto y restaurar dependencias
COPY ["WSAgro/WSAgro.csproj", "WSAgro/"]
COPY ["WSAgro.SERVICE/WSAgro.SERVICE.csproj", "WSAgro.SERVICE/"]
COPY ["WSAgro.DAO/WSAgro.DAO.csproj", "WSAgro.DAO/"]
COPY ["WSAgro.DTO/WSAgro.DTO.csproj", "WSAgro.DTO/"]
RUN dotnet restore "WSAgro/WSAgro.csproj"

# Copiar el resto del código fuente y construir
COPY . .
WORKDIR "/src/WSAgro"
RUN dotnet build "WSAgro.csproj" -c Release -o /app/build

# Publicar el proyecto
FROM build AS publish
RUN dotnet publish "WSAgro.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Usar la imagen de runtime para la fase final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WSAgro.dll"]
