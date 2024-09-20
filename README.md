# PruebaBancoBase

Hola, soy Sergio Cardoso por medio de este repositorio entrego el examen que se fue asignado.

Me gustaría primero presentar el diagrama de ER  del sistema:
![alt text](image.png)

El motor de base de datos utilizado fue SQL SERVER y se agrega el archivo "ScriptBaseDeDatosSQLServer.sql", el cual contiene todos los pasos para crear la base de datos, es importante mencionar que este archivo es el primero que debe ser ejecutado

Agrego también el Dockerfile de la API construida con .NET y su archivo de docker-compose, para un fácil despliegue en un contenedor docker

**Nota** En la API existe el archivo "appsettings.json" en donde se encuentra actualmente la cadena de conexión a la base de datos, es importante agregar los campos de "User ID" y "Password" del servidor o máquina en la que se ejecutará el contenedor.
![alt text](image-1.png)


Para el patrón de diseño me basé en una arquitectura de microservicios con programación por capas utilizando principalmente la inyección de dependencias.

Los servicios fueron del tipo REST

No agregue la Colección en Postman, ya que habilite el swagger de la API y desde ahí es posible hacer las pruebas a los endpoints.


Una vez que este el contenedor corriendo para acceder al swagger y hacer las pruebas es necesario ingresar a esta URL:

http://localhost:8081/swagger/index.html


