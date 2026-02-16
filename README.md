<div align="center">

# 🔐 AuthMS

**Микросервис авторизации на .NET 10 с DDD-архитектурой**

[![.NET](https://img.shields.io/badge/.NET-10-512bd4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-13-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Status](https://img.shields.io/badge/Status-In%20Development-orange)]()

</div>

> ⚠️ **Проект находится в активной разработке и пока не готов к использованию в production.**

---

## 📖 Overview

REST API микросервис авторизации и аутентификации пользователей, построенный по принципам **Domain-Driven Design (DDD)** на .NET 10.

**Основные функции (планируемые):**
- Регистрация пользователей
- Аутентификация (логин/пароль)
- Выдача и валидация JWT-токенов
- Обновление токенов (refresh tokens)
- Управление паролями (смена пароля)

| Layer | Technology |
|-------|-----------|
| **API** | ASP.NET Core Minimal API |
| **Application** | MediatR · FluentValidation |
| **Domain** | DDD · Value Objects · Entities |
| **Infrastructure** | EF Core · JWT |
| **Tests** | xUnit |

---

## 📍 Roadmap

### Стадии разработки

| # | Стадия | Статус | Описание |
|---|--------|--------|----------|
| 1 | **Domain Layer** | 🔧 В процессе | Сущности, Value Objects, доменные исключения, интерфейсы |
| 2 | **Application Layer** | ⏳ Планируется | CQRS-команды/запросы, валидация, сервисы |
| 3 | **Infrastructure Layer** | ⏳ Планируется | EF Core, репозитории, JWT-генерация, хеширование паролей |
| 4 | **API Layer** | ⏳ Планируется | Эндпоинты, middleware, конфигурация DI |
| 5 | **Тестирование** | ⏳ Планируется | Unit-тесты домена, интеграционные тесты |
| 6 | **Docker & CI/CD** | ⏳ Планируется | Контейнеризация, пайплайны |

### Что сделано

- [x] Структура проекта (Clean Architecture / DDD)
- [x] `UserEntity` — агрегат пользователя
- [x] Value Objects: `UserId`, `Login`, `PasswordHash`, `JwtToken`
- [x] Доменные исключения: `DomainException`, `UserException`

### Что делается сейчас

- [ ] Доработка доменного слоя (интерфейсы репозиториев, доменные сервисы)
- [ ] Валидация доменных правил

### Что дальше

- [ ] Application Layer: команды регистрации и логина (MediatR)
- [ ] Infrastructure: EF Core DbContext, миграции, JWT-провайдер
- [ ] API: эндпоинты `/register`, `/login`, `/refresh`
- [ ] Тесты

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
│   ├── Exceptions/
│   │   ├── DomainException.cs
│   │   └── UserException.cs
│   ├── Interfaces/
│   ├── Services/
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
