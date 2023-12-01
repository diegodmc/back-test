# Configurando um Ambiente Local com SQL Server e .NET Core
Este guia descreve como configurar um ambiente local para executar uma aplicação .NET Core com SQL Server usando Docker. Os passos incluirão a criação de um contêiner SQL Server, aplicação .NET Core e execução de migrações de banco de dados usando o Entity Framework Core.

# Pré-requisitos
Docker
.NET Core SDK 6.0

# Passos
1. Criar um Contêiner SQL Server
    docker build -t sqlserver:2022-latest .
    docker run -d --name sqlserver -p 1433:1433 sqlserver:2022-latest

2. Restaurar Aplicação .NET Core
    dotnet restore
    dotnet build

3. Configurar a Conexão com o Banco de Dados
    No arquivo appsettings.json, adicione a string de conexão para o SQL Server:

    {
        "ConnectionStrings": {
        "SqlServerConnection": "Server=localhost,1433;Database=master;User=sa;Password=Sql@2023;"
    },
    }

4. Adicionar Pacotes NuGet do Entity Framework Core

5. Criar as Migrações e Atualizar o Banco de Dados
    dotnet ef migrations add InitialCreate
    dotnet ef database update

6. Executar a Aplicação
    dotnet run

A aplicação será iniciada e conectará ao banco de dados SQL Server configurado no contêiner.

# Endpoints

CRUD produto
CRUD pedido

Endpoint get-by-name para pesquisar pedidos pelo nome do cliente
Endpoint getall para preencher o combo de produtos no formulario de cadastro de pedidos