# Encuesta
El presente repositorio, se utiliza para albergar un proyecto de una encuesta

## Comenzando 馃殌

_Estas instrucciones te permitir谩n obtener una copia del proyecto en funcionamiento en tu m谩quina local para prop贸sitos de desarrollo y pruebas._
_Solo debes descargar el proyecto, previa instalac贸n de los requisitos y ejecutar el proyecto._

### Pre-requisitos 馃搵

_Que cosas necesitas para instalar el software_

```
Visual Studio 2019
Net Core 5.0
Microsoft Sql Server 2014
```

### Instalaci贸n 馃敡

_Para poder editar y ejecutar el proyecto deber谩s:_

_Instalar Visual Studio 2019 o Visual Studio Community 2019_
_Instalar NET Core 5.0_
_Restaurar la base de datos_
_Correr script con ejemplos de registro en tablas_
_Modificar la cadena de conexi贸n a tu servidor_

### Forma de uso 馃敡

Despu茅s de seguir las instrucciones de instalaci贸n debes realizar lo siguiente:

* Crear un usuario desde el endpoint /api/Usuarios
* Loguearte con el usuario creado desde el endpoint /api/Login/v1/dologin
* Crear una encuesta desde el endpoint POST /api/Encuesta
* Crear las preguntas para determinada encuesta desde el endpoint POST /api/ListadoCampos estas preguntas en el tipo de campo solo aceptaran el texto (Numero, Texto o Fecha)
* Para contestar la encuesta deberas utilizar el endpoint POST /api/CompletarEncuesta
* Para ver el resultado de todas las encuestas deberas utilizar el endpoint GET /api/Encuesta/respuestas/{id}

_Para todas las entidades se habilitaron los endpoints para realizar un CRUD y puedes visualizarlos al ejecutar el proyecto. Estos se mostraran por medio de Swagger_

* El CRUD de la TblEncuesta administra los encabezados de las encuestas
* El CRUD de la TblListadoCampos administra las preguntas de una encuesta
* El CRUD de la TblRespuestas administra las respuestas obtenidas de una encuesta

## Construido con 馃洜锔?

* [C#] -Lenguaje de programaci贸n
* [Net Core 5.0](https://dotnet.microsoft.com/download/dotnet/3.1) -Framework para creaci贸n de aplicaciones
* [SQL Server 2014](https://www.microsoft.com/es-es/download/details.aspx?id=42299) -Gestor de base de datos

## Paquetes Nuguet 馃洜锔?
```
AutoMapper.Extensions.Microsoft.DependencyInjection
FluentValidation.AspNetCore
Microsoft.AspNetCore.Mvc.NewtonsoftJson
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Swashbuckle.AspnetCore
```
## Autores 鉁掞笍

* **Danilo Estuardo Itzep Luna** 



