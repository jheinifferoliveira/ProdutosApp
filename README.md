# ProdutosApp

O **ProdutosApp** é um sistema de gerenciamento de produtos e fornecedores desenvolvido em ASP.NET API utilizando o Entity Framework.

## Pré-requisitos

Para executar este projeto, você precisará do seguinte:

- Visual Studio 2022 com .NET 8 instalado.
- Um banco de dados SQL Server. Você precisará criar um banco de dados local e atualizar a string de conexão no arquivo `DataContext.cs`.

## Configuração do Banco de Dados

1. **Configuração do Banco de Dados Local:**
   - Crie um banco de dados local no SQL Server.
   - Atualize a string de conexão no arquivo `DataContext.cs` para apontar para o seu banco de dados local.

2. **Aplicação das Migrações:**
   - Abra o Console do Gerenciador de Pacotes do Visual Studio.
   - Execute o comando `Update-Database` para aplicar as migrações e criar as tabelas necessárias no banco de dados.

## Documentação

- [Documentação do ASP.NET API](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0)
- [Documentação do Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

---

