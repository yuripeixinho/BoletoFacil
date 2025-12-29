# BoletoFácil - Gerador de CNABs eletrônicos via planilha

<div align="center">
  <img width="1408" height="736" alt="Gemini_Generated_Image_x9mpcwx9mpcwx9mp" src="https://github.com/user-attachments/assets/d60ea209-a39e-4711-802c-f5955ac2fac8" />

  **Da planilha ao CNAB em segundos. Simples para o usuário, robusto por dentro.**

  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white" />
</div>

# Objetivo
Este projeto tem como objetivo automatizar a geração de arquivos de cobrança bancária (CNAB) a partir de uma planilha de dados estruturada. A partir de uma planilha corretamente preenchida, o sistema é capaz de converter informações financeiras em arquivos bancários compatíveis com os padrões CNAB 400 e CNAB 240, prontos para envio às instituições financeiras e para persistência em nossa base de dados.

# Porque o projeto existe?
O projeto nasceu da necessidade de aplicar meus conhecimentos em um contexto real e tangível. Por ser baseado em layouts bancários, o BoletoFácil possui regras de negócio bem definidas, com início, meio e fim claramente estabelecidos. Isso permitiu concentrar o foco na técnica de programação, modelagem do sistema, estrutura de dados e arquitetura, em vez de investir tempo na criação de regras de negócio artificiais.
<br/>

Desde sua concepção, o projeto foi pensado para ser extensível, possibilitando a inclusão de novos bancos e layouts bancários sem impactos no core da aplicação.

# Como usar?
## Exportar planilha de exemplos bases

1. A API disponibiliza um endpoint para exportar planilhas bases para testes com as informações já populadas
- <img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/11258d12-3716-43ad-9709-31ff98eb4cf6" />

2. No final da exportação você terá um arquivo com datas e informações demonstrativas
- <img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/e4e7aa47-3ea2-438d-bb1c-743c3aca3b64" />

## Gerar arquivo de cobrança bancária (CNAB)

3. Após exportar os arquivos você poderá enviar no endpoint de gerar a remessa e o resultado será o arquivo
- <img width="600" height="400" alt="image" src="https://github.com/user-attachments/assets/c927ac6f-951d-478f-9d96-b6049b0fa6af" />







# Arquitetura
O **BoletoFácil** foi estruturado com foco em **arquitetura de alto nível**, priorizando **isolamento das regras de negócio**, **baixo acoplamento** e **facilidade de evolução**, especialmente considerando a necessidade de escalar para múltiplos **bancos** e **layouts bancários (CNAB)**. Como dito anteriormente, simples para o usuário e robusto por dentro.
A arquitetura adotada combina conceitos de **Clean Architecture**, **Domain-Driven Design (DDD)**, **CQRS** + **Mediator Pattern**, **Service Layer** e padrões clássicos de design, garantindo um sistema flexível e preparado para crescimento.

### Padrões Arquiteturais
- Clean Architecture
- Repository Pattern
- Domain-Driven Design (DDD), Bounded Contexts, Aggregates
- CQRS, Mediator
- Service Layer
- Simple Factory, Strategy Method
- Gobal Exceptions com o padrão Microsoft `DetailProblem`

### Visão Resumida da Estrutura

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

# Fluxo de processamento
[Devo colocar o fluxo de processamento da aplicação ou uma imagem do Escalidraw desse fluxo?]


# Modelagem e Persistência de dados
TODO
<img width="1906" height="1155" alt="image" src="https://github.com/user-attachments/assets/be80c332-7722-4dc7-add8-8d81446a594e" />




# Possíveis evoluções
- Inclusão de novos bancos
- Débito autorizado
- Pagamentos
- Leitura de retornos bancários
- Camada de validação para os endereços (busca CEP)
- Testes unitários



