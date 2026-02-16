<div align="center">

# 🔐 AuthMS

**Authentication Microservice built with DDD on .NET 10**

[![.NET](https://img.shields.io/badge/.NET-10-512bd4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-13-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

</div>

---

## 📖 Overview

REST API микросервис аутентификации, построенный по принципам **Domain-Driven Design (DDD)** на .NET 10.

| Layer | Technology |
|-------|-----------|
| **API** | ASP.NET Core Minimal API |
| **Application** | MediatR · FluentValidation |
| **Domain** | DDD · Value Objects · Entities |
| **Infrastructure** | EF Core · JWT |
| **Tests** | xUnit |

---

## 🚀 Quick Start

```bash
git clone https://github.com/<your-username>/AuthMS.git
cd AuthMS
dotnet restore
dotnet build
dotnet run --project AuthMS.Api
```

---

## 📁 Project Structure

```
AuthMS/
├── AuthMS.slnx
├── AuthMS.Api/                 # Presentation layer
│   ├── Program.cs              # App entry point & configuration
│   ├── appsettings.json
│   └── Properties/
├── AuthMS.Application/         # Application layer (use cases)
├── AuthMS.Domain/              # Domain layer (core business logic)
│   ├── Entities/
│   │   └── UserEntity.cs       # User aggregate root
│   └── ValueObjects/
│       ├── UserId.cs
│       ├── Login.cs
│       ├── PasswordHash.cs
│       └── JwtToken.cs
├── AuthMS.Infrastructure/      # Infrastructure layer (implementations)
├── AuthMS.Tests/               # Unit & integration tests
└── README.md
```

---

## 🏗 Architecture

Проект следует принципам **DDD** с разделением на слои:

```
API → Application → Domain ← Infrastructure
```

- **Domain** — ядро приложения: сущности, value objects, доменные правила. Не зависит ни от чего.
- **Application** — сценарии использования, интерфейсы репозиториев, сервисы.
- **Infrastructure** — реализация репозиториев, работа с БД, внешние сервисы.
- **API** — точка входа, эндпоинты, конфигурация DI.

---

## 🧪 Tests

```bash
dotnet test
```

---

## ⚙️ Environment Variables

Конфигурация задаётся в `appsettings.json` / `appsettings.Development.json`.

---

## 📝 License

MIT
