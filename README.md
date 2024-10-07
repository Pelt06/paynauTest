# 📚 Catálogo de Personas

¡Bienvenido al proyecto **Catálogo de Personas**! Esta aplicación permite gestionar un catálogo de personas con funcionalidades de creación, lectura, actualización y eliminación (CRUD).

## 🚀 Características

- **Interfaz Intuitiva**: Navegación sencilla y amigable.
- **CRUD Completo**: Agrega, edita y elimina registros de personas.
- **Notificaciones Atractivas**: Usando **SweetAlert** para confirmaciones.
- **Modales Modernos**: Interacción fluida a través de modales para todas las operaciones.

## 🛠️ Tecnologías Utilizadas

- **Frontend**: [Next.js](https://nextjs.org/)
- **Backend**: [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) con Clean Architecture y una base de datos MySQL
- **Gestión de Estado**: React Hooks

## 📦 Instalación

Para comenzar, clona este repositorio y sigue los pasos a continuación:

```bash
# Clona el repositorio
git clone https://github.com/Pelt06/paynauTest.git
```

1. Copia el script de la base de datos ubicado em la carpeta "db" y ejecutalo en tu servidor MySQL para crear la base de datos

2. En el archivo appsetting.json sustituye los campos Port, User y Password dentro del atributo "MySqlConnection" por los que correspondan a tu instancia MySQL

3. Para ejecutar el proyecto debera compilar e iniciar los contenedores de docker con el siguiente comando:
```bash
docker-compose up --build
```
Si los contenedores ya fueron compilados previamente bastará con ejecutar el siguiente comando:
```bash
docker-compose up
```
