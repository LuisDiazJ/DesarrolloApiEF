# DesarrolloApiEF

# Descripción

El proyecto DesarroloApiEF es una aplicación basada en .NET que se centra en la gestión y seguimiento de animales en una granja. La aplicación utiliza Entity Framework Core para interactuar con una base de datos SQLite, proporcionando así una solución robusta y eficiente para el almacenamiento de información.

Objetivos

Gestión de Animales: Permite registrar información detallada sobre cada animal, incluyendo nombre, fecha de nacimiento, género, precio, estado y comentarios asociados.

Relaciones con Razas: Establece relaciones con las razas de los animales a través de una propiedad de navegación, permitiendo la asociación de cada animal con una raza específica.

Operaciones CRUD: Ofrece operaciones de creación, lectura, actualización y eliminación (CRUD) para mantener y gestionar la información de los animales.

Características Clave

Base de Datos SQLite: Utiliza una base de datos SQLite para garantizar una implementación ligera y fácilmente desplegable.

API RESTful: Proporciona una API RESTful que permite la comunicación con la aplicación para realizar operaciones CRUD.

Entity Framework Core: Emplea Entity Framework Core como ORM (Object-Relational Mapping) para facilitar la interacción con la base de datos y simplificar el manejo de datos.

Validación de Datos: Implementa validaciones de datos a través de atributos de validación, asegurando la integridad y consistencia de la información almacenada.

Este proyecto tiene como objetivo brindar una solución flexible y escalable para la gestión de animales en entornos agrícolas, proporcionando una interfaz fácil de usar y manteniendo la integridad de los datos a lo largo del tiempo.


## Instrucciones de Despliegue

### Requisitos Previos

Asegúrate de tener instalados los siguientes componentes:

- [SDK de .NET Core](https://dotnet.microsoft.com/download)
- [Gestor de Base de Datos SQLite](https://www.sqlite.org/download.html)

### Configuración

1. **Clona el repositorio:**

    ```bash
    git clone https://github.com/tu-usuario/tu-proyecto.git
    cd tu-proyecto
    ```

2. **Restaura las dependencias del proyecto:**

    ```bash
    dotnet restore
    ```

3. **Aplica las migraciones de la base de datos:**

    ```bash
    dotnet ef database update
    ```

    Esto creará la base de datos SQLite según las migraciones definidas en tu proyecto.

4. **Ejecuta la aplicación:**

    ```bash
    dotnet run
    ```

    La aplicación estará disponible en `https://localhost:5001` por defecto.

### Uso

- Accede a la API en tu navegador o utilizando herramientas como [Postman](https://www.postman.com/) para interactuar con los endpoints.

### Notas Adicionales

- Siéntete libre de ajustar la cadena de conexión de la base de datos en el archivo `program.cs` según sea necesario.

¡Listo! Ahora deberías tener tu aplicación desplegada y lista para su uso localmente.
