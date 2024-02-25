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
  . .NET Core 3.1 ou posterior
  . Docker
  . Seq (para logs, apontados na configuração do Serilog)
  . PostgreSQL (para banco de dados)
```
Imagens Docker
Este projeto usa duas imagens Docker: Seq e PostgreSQL. Aqui estão as instruções para puxar e executar essas imagens:
```bash
docker run --name Banco_App_Todo_Dev -e POSTGRES_USER=bruno.fiori -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres
AND 
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5431:80 datalust/seq
``` -v C:\Logs\Seq:/data
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
  . .NET Core 3.1 or later
  . Docker
  . Seq (for logs, pointed in the Serilog configuration)
  . PostgreSQL (for database)
```
Docker Images
This project uses two Docker images: Seq and PostgreSQL. Here are the instructions to pull and run these images:
```bash
docker run --name Banco_App_Todo_Dev -e POSTGRES_USER=bruno.fiori -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres
AND 
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
```