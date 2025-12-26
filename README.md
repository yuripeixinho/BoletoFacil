<p align="center"><img width="600" height="500" alt="boletofacillogo" src="https://github.com/user-attachments/assets/ca9cbd50-e553-44d6-bacb-1372de79604d" />

# 📌 Sumário
- [Visão Gera](#-visão-geral)
- [Objetivo do Projeto](#-objetivo-do-projeto)
- [Arquitetura](#-arquitetura)
- [Organização do Projeto](#-organização-do-projeto)
- [Tecnologias e Principais Abordagens](#-tecnologias-utilizadas)
- [Fluxo de Processamento](#-fluxo-de-processamento)
- [Persistência de Dados](#-persistência-de-dados)
- [Possíveis Evoluções](#-possíveis-evoluções)

# Visão Geral
O projeto nasceu da necessidade de aplicar meus conhecimentos em algo tangível. Por ser baseados em layouts bancários o BoletoFacil possuí regras de negócios diretas, com início, meio e fim bem disposto. Desse modo, concentro meu foco na técnica de programação, modelagem do sistema, dados, arquitetura ao invés de utilizar um projeto onde teria que criar essas regras de negócio do zero. Ele foi pensado pra ser extensível permitindo a inclusão de novos bancos e layouts sem impactos no core do sistema

# Objetivo do projeto
Este projeto tem como objetivo automatizar a geração de arquivos de cobrança bancária (CNAB) a partir de uma planilha de dados estruturada. Com apenas uma planilha corretamente preenchida, o sistema é capaz de transformar informações financeiras em arquivos bancários compatíveis com os padrões CNAB 400 e CNAB 240, prontos para envio aos bancos e persisti-los em nossa base de dados.

# Arquitetura
O **BoletoFácil** foi estruturado com foco em **arquitetura de alto nível**, priorizando **isolamento das regras de negócio**, **baixo acoplamento** e **facilidade de evolução**, especialmente considerando a necessidade de escalar para múltiplos **bancos** e **layouts bancários (CNAB)**.
A arquitetura adotada combina conceitos de **Clean Architecture**, **Domain-Driven Design (DDD)**, **CQRS** + **Mediator Pattern**, **Service Layer** e padrões clássicos de design, garantindo um sistema flexível e preparado para crescimento.


### 📐 Visão Geral da Estrutura

```text
BoletoFacil (Solution)
│
├── BoletoFacil.Api
│   ├── Controllers
│   │   └── RemessaController.cs
│   │
│   ├── appsettings.json
│   ├── Program.cs
│   └── WebApi.http
│
├── BoletoFacil.Application
│   │
│   ├── DTOs
│   │   ├── Common
│   │   └── BoundedContexts
│   │       └── Itau
│   │           └── CNAB400
│   │
│   ├── Interfaces
│   │   └── IRemessaService.cs
│   │
│   ├── Services
│   │   └── RemessaService.cs
│   │
│   ├── Factories
│   │   └── RemessaGeneratorFactory.cs
│   │
│   ├── Features
│   │   └── CreateRemessa
│   │
│   └── Strategies
│       └── CreateRemessa
│           └── BoundedContexts
│               └── Itau
│                   └── CNAB400
│                       ├── BancoItauRemessaGenerator.cs
│                       └── Layouts
│                           ├── HeaderItauCNAB400.cs
│                           ├── DetalheItauCNAB400.cs
│                           └── TrailerItauCNAB400.cs
│
├── BoletoFacil.Domain
│   │
│   ├── Core
│   │   ├── Entities
│   │   ├── ValueObjects
│   │   └── Enums
│   │
│   └── BoundedContexts
│       └── Remessa
│           ├── Header.cs
│           ├── Detalhe.cs
│           └── Trailer.cs
│
├── BoletoFacil.Infrastructure
│   │
│   ├── Data
│   │   ├── Context
│   │   │   └── BoletoFacilDbContext.cs
│   │   │
│   │   ├── EntitiesConfiguration
│   │   │   ├── RemessaConfiguration.cs
│   │   │   ├── HeaderConfiguration.cs
│   │   │   └── DetalheConfiguration.cs
│   │   │
│   │   └── Repositories
│   │       └── RemessaRepository.cs
│   │
│   └── IoC
│       └── DependencyInjection.cs
```

## 🛠️ Tecnologias Utilizadas e Principais Abordagens

- .NET
- ASP.NET Core Web API
- Entity Framework Core
- Dapper
- SQL Server
- FluentValidation
- AutoMapper
- Swagger / OpenAPI
  
- Strategy Pattern para layouts bancários
- Validações com FluentValidation
- DTOs para isolamento da API
- Regras críticas protegidas no domínio
- Fail Fast Validation
- Código orientado a extensibilidade  


# 🔁 Fluxo de Processamento

1. Cliente envia requisição HTTP
2. Controller recebe o DTO
3. Validações são aplicadas
4. Strategy correta é selecionada (ex: Banco + Layout)
5. Regras de domínio são executadas
6. Arquivo de remessa é gerado
7. Resposta é retornada ao cliente

# Modelagem e Persistnecia de dados

Aqui será a modelagem e


# 🚀 Possíveis Evoluções
- Inclusão de novos bancos
- Versionamento de layouts CNAB
- Cache
- Mensageria
- Autenticação JWT


