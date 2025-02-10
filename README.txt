# Servidor ASP .NET Core Web API - Lista de Tarefas

Este projeto é um servidor ASP .NET Core Web API que gerencia uma lista de tarefas. Ele fornece endpoints para operações CRUD (Create, Read, Update, Delete) e utiliza **Entity Framework Core** com **SQL Server** para a persistência de dados.

## Estrutura do Projeto

O projeto está organizado em diferentes camadas para separar as responsabilidades:

- **Services**: Implementação dos serviços de aplicação.
- **Controllers**: Controladores que lidam com as requisições HTTP.
- **Domain**: Contém as entidades e interfaces de repositório.
  - **Entities**: Definição das entidades do domínio.
  - **Repositories**: Interfaces de repositório.
- **Infrastructure**: Contém a implementação da infraestrutura.
  - **Data**: Configuração e acesso a dados.
  - **Repositories**: Implementação dos repositórios.
  - **Migrations**: Migrações do banco de dados.
- **appsettings.json**: Configurações da aplicação, incluindo a string de conexão com o banco de dados.

## Banco de Dados - SQL Server

O projeto utiliza **SQL Server** como banco de dados. O Entity Framework Core é configurado para se conectar ao SQL Server.

### Migrations

As migrações foram habilitadas para garantir a consistência do banco de dados. Isso permite que o esquema do banco de dados seja versionado e atualizado conforme o modelo de dados evolui.

#### Como Aplicar Migrações

1. Certifique-se de que a string de conexão com o banco de dados está correta no arquivo `appsettings.json`.
2. Execute o seguinte comando no terminal para aplicar as migrações:
database update