README.md
Passos para Compilação do Projeto
```
  . Certifique-se de ter a versão mais recente do seu IDE preferido instalado (recomenda-se o Visual Studio para este projeto).
  . Clone o repositório para sua máquina local.
  . Abra o arquivo de solução no seu IDE.
  . Compile a solução clicando em Build -> Build Solution no menu ou pressionando Ctrl+Shift+B.
```
Dependências
Este projeto depende do seguinte:
```
  . Docker
  . PostgreSQL (para o banco de dados)
  . .NET Core 3.1 or later
  . Seq (para logs, apontado nas configurações do Serilog) -v 6.0.0
  . Entity Framework Core PostgreSQL -v 8.0.2
  . Entity Framework Tools -v 8.0.2
  . Serilog -v 8.0.1
  . Serilog Expressions -v 4.0.0
  . Swagger -v 6.5.0
  . AutoMapper
```
Imagens Docker
Este projeto usa duas imagens Docker: Seq e PostgreSQL. Aqui estão as instruções para puxar e executar essas imagens:
```bash
docker run --name Banco_App_Todo_Dev -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres:latest
AND 
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5431:80 datalust/seq:latest
``` 
---
Step to compile the project
```
  . Make sure you have the latest version of your preferred IDE installed (Visual Studio is recommended for this project).
  . Clone the repository to your local machine.
  . Open the solution file in your IDE.
  . Compile the solution by clicking Build -> Build Solution in the menu or pressing Ctrl+Shift+B.
```
Dependencies
This project depends on the following:
```   
  . Docker
  . PostgreSQL (for database)
  . .NET Core 3.1 or later
  . Seq (for logs, pointed in the Serilog configuration) -v 6.0.0
  . Entity Framework Core PostgreSQL -v 8.0.2
  . Entity Framework Tools -v 8.0.2
  . Serilog -v 8.0.1
  . Serilog Expressions -v 4.0.0
  . Swagger -v 6.5.0
  . AutoMapper
```
Docker Images
This project uses two Docker images: Seq and PostgreSQL. Here are the instructions to pull and run these images:
```bash
docker run --name Banco_App_Todo_Dev -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres:latest
AND 
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
```
This project uses Entity Framework, an ORM (Object-Relational Mapper) that allows .NET developers to work with a database using .NET objects. It eliminates the need for most of the data access code that developers usually need to write.
Running Migrations
Entity Framework Migrations allow you to keep your database schema in sync with your application's data model by managing incremental changes.
To run the migrations, you need to use the following commands in Visual Studio's integrated terminal:
1.	To add a new migration:
```
  . Add-Migration <migration_name>
```
2.	To update the database with the latest migration:
```
  . Update-Database
```
Remember to replace <migration_name> with the name you want to give your migration.
Note: These commands are for Entity Framework Core. If you are using an older version of Entity Framework, the commands may be slightly different.