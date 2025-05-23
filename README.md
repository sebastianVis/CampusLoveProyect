# CampusLoveProyect

CampusLoveProyect es una aplicación de matchmaking diseñada para conectar estudiantes universitarios basándose en sus intereses compartidos. Desarrollada en C# utilizando .NET 8 y PostgreSQL, esta aplicación busca facilitar la creación de conexiones significativas dentro de la comunidad estudiantil.

## Características

- **Registro y autenticación de usuarios:** Permite a los estudiantes crear cuentas y acceder de forma segura.
- **Gestión de intereses:** Los usuarios pueden seleccionar y actualizar sus intereses personales.
- **Sistema de emparejamiento:** Algoritmo que sugiere conexiones basadas en intereses comunes.
- **Arquitectura limpia:** Separación clara entre las capas de aplicación, dominio e infraestructura.

## Tecnologías utilizadas

- **Lenguaje:** C# (.NET 8)
- **Base de datos:** PostgreSQL
- **ORM:** Npgsql
- **Arquitectura:** Basada en capas (Application, Domain, Infrastructure)
- **Gestión de dependencias:** NuGet

## Estructura del proyecto

```
CampusLoveProyect/
├── Application/       # Lógica de negocio y casos de uso
├── Domain/            # Entidades y interfaces del dominio
├── Infrastructure/    # Implementaciones de acceso a datos y servicios externos
├── Program.cs         # Punto de entrada de la aplicación
├── CampusLove.sln     # Solución de Visual Studio
└── README.md          # Documentación del proyecto
```

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Instalación y ejecución

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/sebastianVis/CampusLoveProyect.git
   cd CampusLoveProyect
   ```

2. **Configurar la base de datos:**

   - Crear una base de datos en PostgreSQL.
   - Actualizar la cadena de conexión en el archivo de configuración correspondiente.

3. **Restaurar dependencias y compilar:**

   ```bash
   dotnet restore
   dotnet build
   ```

4. **Ejecutar la aplicación:**

   ```bash
   dotnet run
   ```

## Contribuciones

¡Las contribuciones son bienvenidas! Si deseas colaborar:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu funcionalidad (`git checkout -b nueva-funcionalidad`).
3. Realiza tus cambios y haz commits descriptivos.
4. Envía un pull request detallando tus modificaciones.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
