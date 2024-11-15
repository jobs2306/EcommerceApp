# Usa la imagen de SDK de .NET 8.0 para compilar y publicar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Instala git para restaurar dependencias desde repositorios si es necesario
RUN apt-get update && apt-get install -y git

# Instala la herramienta dotnet-ef globalmente en el contenedor
RUN dotnet tool install --global dotnet-ef

# Asegura que la herramienta dotnet-ef esté en el PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copia solo el archivo .csproj y realiza la restauración
COPY /*.csproj /src/
WORKDIR /src
RUN dotnet restore

# Copia todo el contenido del proyecto después de la restauración
COPY . /src/

# Compila el proyecto
RUN dotnet build "EcommerceApp.csproj" -c Release -o /app/build

# Publica la aplicación
RUN dotnet publish "EcommerceApp.csproj" -c Release -o /app/publish

# Establece la imagen base con el SDK para permitir comandos de EF
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define el puerto expuesto en el contenedor
EXPOSE 80

# Copia el script de entrada en el contenedor
COPY entrypoint.sh /app/entrypoint.sh

# Configura el script como el punto de entrada
ENTRYPOINT ["/app/entrypoint.sh"]