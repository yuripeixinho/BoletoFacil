
<div align="center">


<img width="380" height="843" alt="logotipo" src="https://github.com/user-attachments/assets/e5b113d8-156e-4200-89fc-e9e0477a3203" />

  **Da planilha ao CNAB em segundos. Simples para o usuário, arquiteturalmente sólido por dentro.**

  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white" />
</div>


# Objetivo do projeto
O BoletoFácil é uma aplicação backend desenvolvida para automatizar a geração de arquivos de cobrança bancária (CNAB) a partir de uma planilha estruturada.
A partir de um único arquivo corretamente preenchido, o sistema é capaz de:
- Interpretar dados financeiros e cadastrais
- Identificar layout e banco específico
- Aplicar regras bancárias específicas por banco
- Gerar arquivos CNAB 400 e CNAB 240 compatíveis com os padrões oficiais de cada banco
- Persistir as informações relevantes em banco de dados


# Porque o projeto existe?
O projeto nasceu da necessidade de aplicar meus conhecimentos em um contexto real e tangível. Layouts bancários possuem regras rígidas, estruturas previsíveis, validações críticas e um ciclo bem definido (entrada -> processamento -> saída). Esse contexto me permitiu focar em uma arquitetura limpa e extensível, separação clara de responsablidades, modelagem de domínio realista. Então, em vez de criar regras artificiais, o projeto se apoia em regras reais do mercado, comuns em sistema bancários, ERPs e plataformas financeiras.
<br/>

Desde sua concepção, o BoletoFácil foi projetado para crescer sem impacto no core da aplicação, permitindo a inclusão de novos bancos, layouts e fluxos com baixo acoplamento.

# Como usar?
O fluxo de uso foi pensado para ser extremamente simples para quem consome a API, mesmo lidando com um domínio complexo.

### 1️. Exportar planilha de exemplo
A aplicação disponibiliza, via Swagger, um endpoint que gera uma planilha base oficial.
Essa planilha:
- Já vem com datas preenchidas automaticamente
- Contém valores e dados fictícios
- Respeita fielmente o layout CNAB esperado
- Serve como modelo padrão de preenchimento

<img width="800" height="600" src="https://github.com/user-attachments/assets/11258d12-3716-43ad-9709-31ff98eb4cf6" />

### 2️. Gerar arquivo de cobrança bancária (CNAB)
Após o preenchimento da planilha, o usuário realiza o upload do arquivo no endpoint de geração de remessas.
O sistema irá:
- Ler e validar os dados da planilha
- Aplicar regras específicas do banco e do layout
- Gerar o arquivo CNAB (.txt) pronto para envio bancário
- Persistir os dados relevantes para rastreabilidade
<img width="800" height="600" alt="image" src="https://github.com/user-attachments/assets/c927ac6f-951d-478f-9d96-b6049b0fa6af" />


  
# Arquitetura
O **BoletoFácil** foi estruturado com foco em **arquitetura de alto nível**, priorizando **isolamento das regras de negócio**, **baixo acoplamento** e **facilidade de evolução**, especialmente considerando a necessidade de escalar para múltiplos **bancos** e **layouts bancários (CNAB)**. Como dito anteriormente, simples para o usuário e robusto por dentro.
A arquitetura adotada combina conceitos de **Clean Architecture**, **Domain-Driven Design (DDD)**, **CQRS** + **Mediator Pattern**, **Service Layer** e padrões clássicos de design, garantindo um sistema flexível e preparado para crescimento.


### Padrões Arquiteturais
- Clean Architecture
- Domain-Driven Design (DDD)
    - Bounded Contexts
    - Aggregates
- CQRS + Mediator Pattern
- Service Layer
- Repository Pattern
- Factory & Strategy
- Tratamento global de exceções (`ProblemDetails` – padrão Microsoft)


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


# Modelagem do Sistema
<img width="1906" height="1155" alt="image" src="https://github.com/user-attachments/assets/be80c332-7722-4dc7-add8-8d81446a594e" />


# Possíveis Evoluções
- Inclusão de novos bancos
- Débito autorizado
- Pagamentos
- Leitura de retornos bancários
- Camada de validação para os endereços (busca CEP)
- Testes unitários

