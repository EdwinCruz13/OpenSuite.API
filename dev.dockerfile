# Imagen base con SDK (para poder compilar y usar hot reload)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev
WORKDIR /src

# Copiamos los csproj primero (para cachear dependencias)
COPY ["OpenSuite.API/OpenSuite.API.csproj", "OpenSuite.API/"]
COPY ["Negocio/Negocio.csproj", "Negocio/"]
COPY ["Datos/Datos.csproj", "Datos/"]
COPY ["Entidades/Entidades.csproj", "Entidades/"]

RUN dotnet restore "OpenSuite.API/OpenSuite.API.csproj"

# Copiamos todo el código
COPY . .

WORKDIR "/src/OpenSuite.API"

# Exponemos puerto
EXPOSE 8080

# Hot reload en desarrollo
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:8080"]

# Ejecutar para crear la imangen
# docker build -f dev.dockerfile -t opensuite-dev .

# ejecutar para crear docker
# docker run -it --rm -p 5000:8080 -v C:\ruta\absoluta\OpenSuite:/src opensuite-dev

