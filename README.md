# CorePayAPI


[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 📖 Sobre o Projeto

O **CorePayAPI** é uma API RESTful desenvolvida em **ASP.NET Core** que simula um sistema de transferência de fundos e gerenciamento de usuários. O projeto foi arquitetado com foco em **Separação de Preocupações** (Separation of Concerns) e utiliza o padrão de **Arquitetura em Camadas** (Layered Architecture) para garantir manutenibilidade e escalabilidade.

### 🚀 Funcionalidades Principais

*   **Gerenciamento de Usuários:** Consulta de dados básicos de usuários.
*   **Transferência de Fundos:** Lógica transacional para débito e crédito entre contas de usuários.
*   **Transações Atômicas:** Utilização de transações explícitas no banco de dados para garantir a atomicidade das transferências.

## 🛠️ Tecnologias Utilizadas

O projeto é construído sobre o ecossistema .NET e utiliza as seguintes tecnologias:

| Categoria | Tecnologia | Descrição |
| :--- | :--- | :--- |
| **Framework** | ASP.NET Core | Framework principal para construção da API. |
| **Banco de Dados** | SQL Server (Configurável) | Banco de dados relacional para persistência de dados. |
| **ORM** | Entity Framework Core | Mapeamento Objeto-Relacional. |
| **Arquitetura** | Arquitetura em Camadas | Separação entre Domínio, Aplicação, Infraestrutura (Database) e Apresentação (API). |
| **Injeção de Dependência** | .NET Core Built-in DI | Gerenciamento de dependências via Inversão de Controle (IoC). |

## 🏗️ Estrutura do Projeto

O projeto está organizado em múltiplos projetos para garantir a separação de responsabilidades:

| Projeto | Responsabilidade |
| :--- | :--- |
| `CorePayAPI` | Camada de Apresentação (Controllers, Configurações da API). |
| `CorePay.API.Application` | Camada de Aplicação (Lógica de Negócio, Serviços, DTOs). |
| `CorePay.API.Domain` | Camada de Domínio (Entidades, Enums, Interfaces de Repositório). |
| `CorePay.API.Database` | Camada de Infraestrutura (Implementação dos Repositórios, Contexto do EF Core, Migrations). |
| `CorePay.IOC` | Configuração da Injeção de Dependência (Registro de Serviços e Repositórios). |
| `CorePay.API.Shared` | Configurações compartilhadas (e.g., `DbConfig`). |

## ⚙️ Como Configurar e Executar

### Pré-requisitos

*   [.NET SDK](https://dotnet.microsoft.com/download) (Versão 8.0 ou superior)
*   [SQL Server] (ou qualquer outro banco de dados suportado pelo EF Core)

### Passos de Execução

1.  **Clonar o Repositório:**
    ```bash
    git clone https://github.com/Namanosbad/CorePayAPI.git
    cd CorePayAPI
    ```

2.  **Configurar o Banco de Dados:**
    *   Abra o arquivo `CorePayAPI/appsettings.json`.
    *   Atualize a `ConnectionString` dentro da seção `DbConfig` para apontar para sua instância do SQL Server.

3.  **Aplicar Migrations:**
    *   Certifique-se de que o projeto `CorePay.API.Database` está selecionado como projeto de *startup* no Visual Studio, ou use o seguinte comando na raiz do projeto (`CorePayAPI/`):
    ```bash
    dotnet ef database update --project CorePay.API.Database --startup-project CorePayAPI
    ```

4.  **Executar a Aplicação:**
    ```bash
    dotnet run --project CorePayAPI/CorePayAPI.csproj
    ```
    A API estará disponível em `https://localhost:7000` (ou porta configurada no `launchSettings.json`).

## 🧪 Testes

O projeto utiliza o **xUnit** como *framework* de testes e **Moq** para simulação de dependências.

| Projeto de Teste | Tipo de Teste | Foco |
| :--- | :--- | :--- |
| `CorePay.API.Tests` | **Unitário** | Lógica de Negócio (Services) e Regras de Domínio (Entities). |
| `CorePay.API.IntegrationTests` | **Integração** | Fluxo completo da API (Controller -> Service -> Repository -> DB). |

### Como Executar os Testes

Na raiz do projeto (`CorePayAPI/`), execute o seguinte comando:

```bash
dotnet test
```

---
*Desenvolvido com ASP.NET Core e paixão por código limpo.*
