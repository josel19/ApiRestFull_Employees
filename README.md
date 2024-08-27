## API RESTful Employees

## Descripción
Esto es un proyecto de APIREStFULL desarrollado en .NET Core que tiene como función gestionar una base de datos de empleados.
Esta API proporciona la funcionalidad de realizar operaciones CRUD sencillas basadas en los registros de los empleados.
Todos los request hechos funcionan con procedimientos almacenados desde la base de datos SQL server

## Base de Datos
La base de datos en SQL Server incluye una tabla `Employees`, la cual tiene 1 procedimiento almacenado por cada respectivo.
EndPoint(Un total de 6). En la carpeta raíz del repositorio podrá encontrar un archivo SQL llamado **BD_APIREST_TEST1** él 
cuál contendrá todas las instrucciones SQL para importarlo en su gestor de base de datos SQLServer. 

## EndPoints
- **Crear un nuevo empleado:** `POST /employees`
- **Obtener la lista de empleados:** `GET /employees`
- **Obtener un empleado por ID:** `GET /employees/{id}`
- **Actualizar un empleado:** `PUT /employees/{id}`
- **Eliminar un empleado:** `DELETE /employees/{id}`
- **Obtener la lista de empleados a partir de una fecha contratación:** `POST: /Employee/bydate`

## Instalación
1. Clonar repositorio:
`git clone https://github.com/tu_usuario/tu_repositorio.git`
2. Configurar base de datos:
   - Abrir gestor de base de datos SQLserver.
   - Importar un escribir el archivo BD_APIREST_TEST1 encontrado en la carpeta raiz del repositorio.
   - Configurar cadena de conexion de base de datos segun sea requerido:
   ```bash
     `"ConnectionStrings": {
        "DefaultConnection": "Server=nombre_servidor;Database=BD_APIREST_TEST1;User Id=id_user;Password=user_password;"
      }`    
3. Restaurar dependecias:
   - Abrir una consola cmd en la carpeta raíz del proyecto y ejecutar el iguiente comando:
     `dotnet restore`
4. Ejecutar  aplicacion:
   `dotnet run`

