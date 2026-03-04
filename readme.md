# LivrariaPlus API 📚

Uma API robusta desenvolvida em **.NET 10** para o gerenciamento de uma livraria. O projeto foi desenhado focando em organização, manutenibilidade e separação de responsabilidades.

## 🚀 Tecnologias Utilizadas

- **C# / .NET 10**
- **Docker** (Configuração pronta via `docker-compose.yml`)
- _(Adicione aqui o banco de dados que você está usando, ex: Entity Framework Core, SQL Server, PostgreSQL)_
- _(Adicione aqui ferramentas adicionais, ex: Swagger para documentação)_

## 📂 Estrutura do Projeto

A arquitetura do projeto foi dividida para facilitar o entendimento e a evolução da aplicação:

- **`Communication/`**: Contratos de entrada e saída da API (Requests, Responses e DTOs).
- **`Controllers/`**: Controladores responsáveis por expor os endpoints da API.
- **`Data/`**: Camada de persistência, contextos de banco de dados e mapeamentos.
- **`Enuns/`**: Enumerações de domínio do sistema.
- **`Extensions/`**: Métodos de extensão para configuração de serviços e injeção de dependência.
- **`Filters/`**: Filtros globais (ex: tratamento de exceções, validações).
- **`Models/`**: Entidades principais que representam o domínio da aplicação.
- **`UseCases/`**: Contém as regras de negócio e lógicas de aplicação específicas (ex: operações do módulo `Books`).

## 🛠️ Pré-requisitos

Para executar este projeto localmente, você precisará ter instalado:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker](https://www.docker.com/products/docker-desktop) (Caso deseje rodar a infraestrutura em containers)

## ⚙️ Como Executar o Projeto

Você pode iniciar a aplicação através da interface de linha de comando (CLI) do .NET ou utilizando o Docker Compose.

### Opção 1: Via .NET CLI

1. Clone este repositório:
   ```bash
   git clone [https://github.com/LukeUp2/LivrariaPlus.Api.git](https://github.com/LukeUp2/LivrariaPlus.Api.git)
   ```
