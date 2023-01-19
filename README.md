# Backend .Net 6
 Este proyecto  fue desarrollado con la Arquitectura N-Capas con Orientación al Dominio

##Tener en cuenta lo siguiente:
Para poder hacer la migración de la base de datos es importante que modifiquen el appsettings.json de la capa de servicios. En la siguiente imagen se indica donde

![image](https://user-images.githubusercontent.com/36134674/213505813-d1f7415b-baf4-4d80-a4e2-24e239251143.png)

Una vez configurado la conexión se debe proceder a la ejecución de la migración, deben tener muy presente que para la migración en la consola de aadministrador de paquetes de NuGet, 
en Proyecto predeterminado deben seleccionar la capa fi-group.InfraStructure.Repository que está en la carpeta Infrastructure. En esta capa se encuentra el DataContext configurado para el uso de EF en la aplicación
En la siguiente imagen indico donde está la capa de Infrastructure

![image](https://user-images.githubusercontent.com/36134674/213508614-aaf504bc-610e-4217-8763-ffb728203006.png)

Una vez ejecutada la migración pueden proceder a ejecutar Update-Database para la construcción de la base de datos. Por favor tener presente la configuración anterior de el stringconnection en la capa de servicios en el appsettings.json

Ya ejecutado lo anterior procedan a ejecutar el proyecto poniendo como proyecto principal fi-group.Services.WebAPIRest para la ejecución.

![image](https://user-images.githubusercontent.com/36134674/213510847-0bb6f480-50d9-4a16-8575-c05c6573ff38.png)
