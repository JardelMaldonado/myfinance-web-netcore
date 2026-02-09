# MyFinance - Sistema de Gestão Financeira 💰

Este é um projeto de controle financeiro pessoal desenvolvido em **ASP.NET Core** com foco em boas práticas de arquitetura de software, padrões de projeto e Clean Code.

O sistema permite a gestão de Planos de Contas (Categorias) e o registro de Transações Financeiras (Receitas e Despesas), oferecendo uma visão clara do fluxo de caixa.

---

## 🚀 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** ASP.NET Core MVC (.NET 10)
* **Banco de Dados:** SQL Server
* **ORM:** Entity Framework Core
* **Frontend:** HTML, CSS, Tailwind, JavaScript
* **Versionamento:** Git & GitHub

---

## 🏗️ Arquitetura e Padrões de Projeto

O projeto foi estruturado seguindo os princípios da **Arquitetura em Camadas**, garantindo a separação de responsabilidades e facilitando a manutenção:

1.  **Domain:** Contém as entidades de negócio e modelos base.
2.  **Infra:** Responsável pela persistência de dados, implementando o **Repository Pattern**.
3.  **Service:** Camada intermediária que contém a lógica de negócio e orquestra as chamadas entre a Controller e a Infra.
4.  **Web (MVC):** Interface do usuário e controle de rotas.

### Destaques Técnicos:
* **Repository Pattern Genérico:** Implementação de uma base genérica para operações de CRUD, reduzindo a duplicação de código.
* **Polimorfismo:** Uso de métodos `virtual` e `override` para especializar o comportamento de repositórios específicos (ex: Eager Loading de relacionamentos com `.Include`).
* **Injeção de Dependência:** Configuração do container nativo do .NET para gestão de ciclo de vida de objetos (Scoped).
* **Clean Code:** Código organizado, tipado e seguindo as convenções de nomenclatura da comunidade C#.

---
