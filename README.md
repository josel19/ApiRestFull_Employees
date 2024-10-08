## API RESTFULL Employees

## Descripción
Esto es un proyecto de APIRESTFULL desarrollado en .NET Core que tiene como función gestionar una base de datos de empleados.
Esta API proporciona la funcionalidad de realizar operaciones CRUD sencillas basadas en los registros de los empleados.
Todos los request hechos funcionan con procedimientos almacenados desde la base de datos SQL server

## Base de Datos
La base de datos en SQL Server incluye una tabla `Employees`, la cual tiene 1 procedimiento almacenado por cada respectivo
EndPoint(Un total de 6). En la carpeta raíz del repositorio podrá encontrar un archivo SQL llamado `BD_APIREST_TEST1` él 
cuál contendrá todas las instrucciones SQL para importarlo en su gestor de base de datos SQLServer. 

## EndPoints
- **Crear un nuevo empleado:** `POST /employees`
- **Obtener la lista de empleados:** `GET /employees`
- **Obtener un empleado por ID:** `GET /employees/{id}`
- **Actualizar un empleado:** `PUT /employees/{id}`
- **Eliminar un empleado:** `DELETE /employees/{id}`
- **Obtener la lista de empleados a partir de una fecha de contratación:** `POST: /Employee/bydate`

## Instalación
1. Clonar repositorio:
```bash
git clone https://github.com/josel19/ApiRestFull_Employees
```
2. Configurar base de datos:
   - Abrir gestor de base de datos SQLserver.
   - Importar el archivo `BD_APIREST_TEST1` encontrado en la carpeta raíz del repositorio en su gestor de base de datos.
   - Configurar cadena de conexion de base de datos encontrada en el archivo `appsettings.json` de la carpeta raíz según sea requerido:
     
   Servidor Local
    ```bash
     "ConnectionStrings": {
        "conexionBD": "Server=localhost;Database=APIREST_TEST1;Trusted_Connection=True;Encrypt=False;"
      }
   ```  
   Otros Servidores
   ```bash
     "ConnectionStrings": {
        "DefaultConnection": "Server=nombre_servidor;Database=BD_APIREST_TEST1;User Id=id_user;Password=user_password;"
      }
   ```    
3. Restaurar dependecias:
   - Abrir una consola cmd en la carpeta raíz del proyecto y ejecutar el siguiente comando:
   ```bash
   dotnet restore
   ```
4. Ejecutar  aplicación:
   ```bash
   dotnet run
   ```

