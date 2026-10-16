# TaskFlow (Gerenciador de Tarefas via Console)

Aplicação console desenvolvida em **.NET 10** para gerenciamento de tarefas pessoais (*To-Do List*), priorizando boas práticas de arquitetura de software, qualidade de código com testes unitários em **xUnit** e rastreabilidade com **Conventional Commits** (Git Semantic Flow).

---

## 📋 Sumário
* [Visão Geral](#-visão-geral)
* [Requisitos do Ambiente](#-requisitos-do-ambiente)
* [Estrutura da Solução](#-estrutura-da-solução)
* [Como Executar](#-como-executar)
  * [1. Restauração e Compilação](#1-restauração-e-compilação)
  * [2. Executar a Aplicação Console](#2-executar-a-aplicação-console)
  * [3. Executar a Suíte de Testes](#3-executar-a-suíte-de-testes)
* [Garantia de Qualidade (xUnit)](#-garantia-de-qualidade-xunit)
* [Padrão de Versionamento (Conventional Commits)](#-padrão-de-versionamento-conventional-commits)

---

## 🚀 Visão Geral

O **TaskFlow** oferece uma interface interativa em linha de comando (CLI) para criação, listagem e conclusão de tarefas com identificadores únicos (`Guid`). O projeto foi construído seguindo um ciclo evolutivo de desenvolvimento: estruturação, implementação de domínio, testes automatizados, tratamento e correção de bugs (*graceful degradation*), refatoração e documentação.

---

## 💻 Requisitos do Ambiente

* [.NET 10 SDK](https://www.google.com/search?q=https%3A%2F%2Fdotnet.microsoft.com%2F) (ou versão instalada compatível, como .NET 8 ou 9).
* Git para controle de versão.
* Terminal de linha de comando ou IDE de sua preferência (VS Code, Visual Studio, Rider).

---

## 📂 Estrutura da Solução

```text
taskflow-console/
│
├── TaskFlow.sln
│
├── TaskFlow.Console/             # Projeto Console (.NET 10)
│   ├── TaskItem.cs               # Entidade de domínio com lógica de conclusão e validação
│   ├── TaskManager.cs            # Gerenciador de tarefas em memória (CRUD básico)
│   ├── Program.cs                # Interface CLI com menu interativo em loop
│   └── TaskFlow.Console.csproj
│
└── TaskFlow.Tests/               # Projeto de Testes Unitários (xUnit)
    ├── TaskManagerTests.cs       # Suíte de testes para validação de regras de negócio
    └── TaskFlow.Tests.csproj
```

---

## 🛠️ Como Executar

Execute os comandos a partir da raiz da solução:

### 1. Restauração e Compilação

Para restaurar pacotes e compilar todos os projetos:

```bash
# Restaurar dependências
dotnet restore

# Compilar a solução
dotnet build
```

### 2. Executar a Aplicação Console

Para iniciar o menu interativo no terminal:

```bash
dotnet run --project TaskFlow.Console/TaskFlow.Console.csproj
```

**Funcionalidades disponíveis no menu:**
* **`1. Adicionar Tarefa:`** cadastra uma nova tarefa validando títulos nulos ou em branco.
* **`2. Listar Tarefas:`** exibe todas as tarefas cadastradas, indicando status (`[ ]` pendente / `[X]` concluída) e ID.
* **`3. Concluir Tarefa:`** marca uma tarefa como concluída a partir do seu `Guid`.
* **`0. Sair:`** finaliza o programa com segurança.

### 3. Executar a Suíte de Testes

Para rodar todos os testes automatizados e verificar a integridade da aplicação:

```bash
dotnet test
```

---

## 🧪 Garantia de Qualidade (xUnit)

A suíte de testes unitários em `TaskFlow.Tests` valida as principais regras de domínio e tratamento de exceções:

* `AddTask_Should_Add_Task_When_Title_Is_Valid`: assegura que tarefas válidas são inseridas com status inicial pendente (`IsCompleted == false`) e ID gerado.
* `AddTask_Should_Throw_Exception_When_Title_Is_Empty`: valida o lançamento de `ArgumentException` caso o título seja vazio ou formado apenas por espaços em branco.
* `GetById_Should_Return_Null_When_Task_Does_Not_Exist`: garante que a busca por um identificador inexistente retorne `null` graciosamente, sem lançar exceções não tratadas.

---

## 🌳 Padrão de Versionamento (Conventional Commits)

O repositório adota a convenção semântica `tipo(escopo): descrição`, refletindo com clareza o histórico evolutivo da solução:

1. `chore(core): initialize .NET 10 solution and console project structure`
2. `chore(test): add xUnit test project and reference to console Project`
3. `feat(domain): implement TaskItem entity with completion logic`
4. `feat(services): implement TaskManager logic for in-memory task management`
5. `test(unit): add xUnit test suite for TaskManager validation rules`
6. `fix(manager): handle missing task gracefully in search method`
7. `refactor(console): implement interactive menu loop in Program.cs`
8. `docs(readme): add build, run and test instructions`

Para inspecionar o grafo linear de commits:

```bash
git log --oneline --graph
```