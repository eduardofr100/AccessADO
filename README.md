# AccessADO
 En caso de usar DataBaseFirst por EntityFramework utilizar los siguientes comandos

## Comamdo para conexion de base de datos de SqlServer con DataBaseFirst por EntityFramework

Scaffold-DbContext "Server=name;Database=base;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models

Scaffold-DbContext "Server=LAPTOP-SP22435M;Database=MusicSchool;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

Este comendo solo se utiliza si se actualiza la base de datos.....

Scaffold-DbContext "Server=name;Database=base;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models -force 




## Comamdo para conexion de base de datos de Oracle con DataBaseFirst por EntityFramework 

Scaffold-DbContext "User Id=usuario;Password=contraseña;Data Source=servidor:puerto/servicio" Oracle.EntityFrameworkCore -OutputDir Models

ejemplo => Scaffold-DbContext "User Id=HR;Password=oracle123;Data Source=localhost:1521/XEPDB1" Oracle.EntityFrameworkCore -OutputDir Models
