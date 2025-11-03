💈 PeluApp — Web API .NET 8 con Clean Architecture, JWT, Docker & Railway

Aplicación backend modular, escalable y productiva, desarrollada en .NET 8 bajo los principios de Clean Architecture y SOLID, desplegada en contenedores Docker y hospedada en Railway.

🧠 Descripción general

PeluApp es una aplicación backend orientada a la gestión de una peluquería o centro de servicios, construida con una arquitectura limpia, desacoplada y preparada para entornos productivos modernos.
Incluye autenticación JWT, Swagger para documentación, y despliegue continuo en Railway con integración directa desde GitHub.

Este proyecto fue diseñado como un caso de estudio profesional para demostrar buenas prácticas de arquitectura, control de versiones, CI/CD y despliegue en la nube.

🧩 Stack Tecnológico
Categoría	Tecnología
Lenguaje	C# (.NET 8)
Framework	ASP.NET Core Web API
Base de datos	SQL Server
Autenticación	JWT (JSON Web Token)
Arquitectura	Clean Architecture + SOLID
Contenedores	Docker (multi-stage build)
Despliegue	Railway Cloud Platform
Control de versiones	Git + GitHub (main/master)
Documentación	Swagger / OpenAPI
🏗️ Arquitectura del Proyecto

El proyecto sigue los principios de Clean Architecture, manteniendo las dependencias invertidas y las capas claramente separadas.

PeluApp.sln
│
├── DTOs/                     → Clases de transferencia de datos
│
├── LogicaAccesoDatos/        → Acceso a datos (Entity Framework, SQL, repositorios)
│
├── LogicaAplicacion/         → Casos de uso, validaciones y servicios de aplicación
│
├── LogicaNegocio/            → Entidades del dominio y lógica de negocio
│
├── PeluAppMVC/               → (Cliente web MVC opcional)
│
└── WebApiPeluApp/            → API principal (controladores, configuración, Program.cs)
     ├── Controllers/
     ├── appsettings.json
     ├── Program.cs
     ├── Dockerfile
     └── Properties/

⚙️ Principios aplicados
🧩 Clean Architecture

Independencia de frameworks y UI.

Dependencias unidireccionales hacia el dominio.

Separación clara entre lógica de negocio y lógica de infraestructura.

💡 Principios SOLID

Single Responsibility: cada capa tiene una única responsabilidad.

Open/Closed: código abierto a extensión, cerrado a modificación.

Liskov Substitution: uso de interfaces y polimorfismo.

Interface Segregation: interfaces pequeñas, específicas.

Dependency Inversion: inversión de dependencias mediante inyección.

🔐 Autenticación JWT

El sistema implementa autenticación basada en tokens JWT, permitiendo un flujo seguro para usuarios registrados:

El usuario inicia sesión con credenciales válidas.

El servidor genera un token firmado con JWT_SECRET.

Las solicitudes posteriores incluyen Authorization: Bearer <token>.

Variables configurables:

JWT_SECRET = "clave_segura_para_firma"
TOKEN_EXPIRATION = 60 (minutos)

🧰 Dockerización

La aplicación utiliza un Dockerfile multi-stage, optimizando la construcción y ejecución del contenedor:

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY WebApiPeluApp.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=build /app/publish ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "WebApiPeluApp.dll"]

Comandos básicos
# Construir imagen
docker build -t peluapp:latest .

# Ejecutar contenedor
docker run -d -p 8080:8080 --name peluapp peluapp:latest

☁️ Despliegue en Railway

El proyecto fue desplegado exitosamente en Railway, con build automático desde GitHub.
Railway detecta el Dockerfile y genera la imagen sin comandos personalizados.

Variables de entorno configuradas en producción:
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_HTTP_PORTS=8080
PORT=8080
ENABLE_SWAGGER=true
JWT_SECRET=***************
DB_CONNECTION_STRING=Server=(local)\SQLEXPRESS;Database=PeluApp1;Trusted_Connection=True;TrustServerCertificate=True

Endpoints de validación:

🔹 /swagger → Documentación interactiva

🔹 /health → Verificación de estado

🔹 /api/... → Endpoints principales

🔍 CI/CD y control de versiones

Repositorio GitHub: con historial limpio y conflictos resueltos manualmente (sin merges huérfanos).

Integración continua: Railway redeploya automáticamente en cada git push a master.

Rollback rápido: mediante el panel de Deployments de Railway.

🌐 Resultado final

✅ API corriendo en producción
🌍 URL pública: https://peluapp-production.up.railway.app/swagger
💬 Logs monitoreados desde Railway Dashboard
📦 Contenedores Docker locales replican el mismo entorno que producción

🎯 Próximos pasos

🔹 Implementar frontend en React para convertir PeluApp en una solución Full Stack.
🔹 Integrar sistema de autorización por roles (admin, usuario).
🔹 Añadir test unitarios y de integración con xUnit o NUnit.
🔹 Conectar el pipeline CI/CD con GitHub Actions.

📸 Capturas
Railway	Docker	Swagger

	
	
👤 Autor

Franco Núñez
💼 Desarrollador Backend (.NET, C#, SQL, Docker)
📍 Uruguay
📫 LinkedIn
 • GitHub
