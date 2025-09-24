@echo off
REM ================================================
REM por temor a que se pierda este comando, lo dejo en un archivo .bat
REM para regenerar los modelos de EF a partir de la base de datos
REM ejecutar este archivo desde la carpeta Datos (donde está el .csproj)
REM asegurarse de tener instalado el paquete Microsoft.EntityFrameworkCore.Tools y Microsoft.EntityFrameworkCore.SqlServer, sino no servirá
REM para instalar los paquetes, ejecutar:
REM   dotnet add package Microsoft.EntityFrameworkCore.Tools
REM   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
REM ojo: esto sobreescribirá los modelos y el contexto, asi que si se hicieron cambios manuales, se perderán
REM ojo2: la cadena de conexión está quemada, cambiarla si es necesario
REM ojo3: el comando está dividido en varias líneas para mayor legibilidad, pero se puede poner en una sola línea
REM ojo4: el comando usa SQL Server, cambiarlo si se usa otro motor
REM ojo5: usa --no-onconfiguring para no generar OnConfiguring
REM ojo6: usa --use-database-names para mantener los nombres tal cual en BD
REM ojo7: usa --no-pluralize para que no pluralice entidades
REM ojo8: usa --force para sobreescribir archivos existentes
REM ojo9: usa --namespace para definir namespace de los modelos
REM ojo10: usa --output-dir para definir carpeta de modelos
REM ojo11: usa --context-dir para definir carpeta del contexto
REM ojo12: usa --context para definir nombre del contexto
REM ojo13: asegurarse de que la cadena de conexión sea correcta
REM ojo14: este comando es para EF Core, no EF 6
REM ojo15: válido en proyectos .NET Core / .NET 5+ (no .NET Framework)
REM ojo16: si hay muchas tablas, puede tardar bastante
REM ojo17: usar --table para incluir solo tablas específicas
REM ojo18: usar --exclude-table para excluir tablas específicas
REM ojo19: para ejecutarlo: abrir consola en la carpeta Datos/EF/
REM         cd Datos/EF/
REM         y luego escribir: scaffold.bat

REM ojo20: si cambian la ruta de archivos, entonces tendran que comentar todas las clases que dependa de esta capa de datos, 
REM        porque el puto VS2022 no permitira ejecutar EF scaffold hasta que no haya errores
REM	       si alguien sabe como hacer que VS2022 ignore los errores de compilacion en ciertas carpetas, que me avise XD
REM SUERTE Y QUE LA FUERZA LOS ACOMPAÑE :D

REM ================================================





dotnet ef dbcontext scaffold "Server=.;Database=OpenSuiteBD;User Id=sa;Password=Synapse13;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer ^
--context-dir EF/Context ^
--output-dir EF/Modelos ^
--namespace Datos.EF.Modelos ^
--context-namespace Datos.EF.Context ^
--context OpenSuiteDbContext ^
--no-onconfiguring ^
--use-database-names ^
--no-pluralize ^
--force
pause