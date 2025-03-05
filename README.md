# API Controle Usuarios
A API Controle Usuarios é uma API para autenticação de usuário feito em .Net 7.0, padrão de desenvolvimento DDD, com testes unitários, 
ASP.NET Core MVC, Entity Framework e SGBD SqlServer.

## Pré-requisitos

Antes de executar o projeto, verifique se você atende aos seguintes pré-requisitos:

- **Visual Studio 2022:** Baixe e instale o [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/downloads/).

- **SQL Server 2012:** Baixe e instale o [SQL Server 2012](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

## Configuração

1. Clone o repositório LanchesApp em sua máquina local.

2. Abra o projeto no Visual Studio 2022.

3. Abra o arquivo `DataContext.cs` no projeto e modifique a string de conexão para apontar para o seu servidor SQL Server.

4. Abra o Console do Gerenciador de Pacotes no Visual Studio e execute o seguinte comando para aplicar as migrações do Entity Framework e criar o banco de dados: update-database
