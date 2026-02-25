<div align="center">

# 🔐 AuthMS

**Authentication microservice built with .NET 10 and DDD architecture**

[![.NET](https://img.shields.io/badge/.NET-10-512bd4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com)
[![C#](https://img.shields.io/badge/C%23-13-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Status](https://img.shields.io/badge/Status-In%20Development-orange)]()

</div>

> ⚠️ **This project is under active development and is not production-ready yet.**

---

## 📖 Overview

A REST API microservice for user authentication, built following **Domain-Driven Design (DDD)** principles on .NET 10.

**Features:**
- ✅ User registration with password hashing (BCrypt)
- 🔜 Authentication (login/password)
- 🔜 JWT token generation & validation
- 🔜 Refresh tokens
- 🔜 Password management

| Layer | Technology |
|-------|-----------|
| **API** | ASP.NET Core Minimal API |
| **Application** | MediatR (CQRS) |
| **Domain** | DDD · Value Objects · Entities |
| **Infrastructure** | EF Core · PostgreSQL · BCrypt |
| **Tests** | xUnit |

---

## 📍 Roadmap

| # | Stage | Status | Description |
|---|-------|--------|-------------|
| 1 | **Domain Layer** | ✅ Done | Entities, Value Objects, domain exceptions, interfaces |
| 2 | **Application Layer** | ✅ Done | Register command & handler (MediatR CQRS) |
| 3 | **Infrastructure Layer** | ✅ Done | EF Core, PostgreSQL, repositories, BCrypt password hasher, migrations |
| 4 | **API Layer** | ✅ Done | Endpoints, exception middleware, DI configuration |
| 5 | **Login Feature** | ⏳ Planned | Login command, JWT generation |
| 6 | **Testing** | ⏳ Planned | Unit tests, integration tests |
| 7 | **Docker & CI/CD** | ⏳ Planned | Containerization, pipelines |

### Completed

- [x] Clean Architecture project structure (DDD)
- [x] `UserEntity` aggregate with Value Objects (`UserId`, `Login`, `PasswordHash`, `JwtToken`)
- [x] Domain exceptions hierarchy
- [x] Repository & password hasher interfaces
- [x] `RegisterUserCommand` + `RegisterUserCommandHandler` (MediatR)
- [x] `AppDbContext` with EF Core Value Object conversions
- [x] `UserRepository` (PostgreSQL via Npgsql)
- [x] `BCryptPasswordHasher`
- [x] EF Core migrations
- [x] `POST /api/auth/register` endpoint
- [x] Global exception handling middleware
- [x] DI registration via extension methods

### Up Next

- [ ] Login feature (`POST /api/auth/login`)
- [ ] JWT token generation & validation
- [ ] Refresh tokens
- [ ] Unit & integration tests
- [ ] Docker support

---

## 🚀 Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/)
- [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`

### Setup

```bash
git clone https://github.com/<your-username>/AuthMS.git
cd AuthMS
dotnet restore
```

### Configure the database

Update the connection string in `AuthMS.Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=authms;Username=postgres;Password=your_password"
  }
}
```

### Apply migrations & run

```bash
dotnet ef database update --project AuthMS.Infrastructure --startup-project AuthMS.Api
dotnet run --project AuthMS.Api
```

### Test the register endpoint

```bash
curl -X POST https://localhost:5001/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"name": "John", "login": "john@example.com", "password": "SecurePass123"}'
```

---

## 📁 Project Structure

```
AuthMS/
├── AuthMS.slnx
├── AuthMS.Api/                     # Presentation layer
│   ├── Program.cs                  # App entry point (clean & minimal)
│   ├── Endpoints/
│   │   └── AuthEndpoints.cs        # Auth route mappings
│   ├── Extensions/
│   │   ├── ServiceCollectionExtensions.cs  # DI registration
│   │   └── MiddlewareExtensions.cs         # Middleware helpers
│   ├── Middlewares/
│   │   └── ExceptionMiddleware.cs  # Global error handling
│   ├── appsettings.json
│   └── appsettings.Development.json
├── AuthMS.Application/             # Application layer (use cases)
│   ├── Commands/
│   │   └── RegisterUser/
│   │       ├── RegisterUserCommand.cs
│   │       └── RegisterUserCommandHandler.cs
│   └── DTOs/
│       └── RegisterUserResponse.cs
├── AuthMS.Domain/                  # Domain layer (core business logic)
│   ├── Entities/
│   │   └── UserEntity.cs           # User aggregate root
│   ├── Exceptions/
│   │   ├── DomainException.cs
│   │   ├── UserException.cs
│   │   └── ValueObjectsException.cs
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── IUserRepository.cs
│   │   └── IPasswordHasher.cs
│   └── ValueObjects/
│       ├── UserId.cs
│       ├── Login.cs
│       ├── PasswordHash.cs
│       └── JwtToken.cs
├── AuthMS.Infrastructure/          # Infrastructure layer
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   └── Configurations/
│   │       └── UserEntityConfiguration.cs
│   ├── Migrations/
│   ├── Repositories/
│   │   └── UserRepository.cs
│   └── Services/
│       └── BCryptPasswordHasher.cs
├── AuthMS.Tests/                   # Tests
└── README.md
```

---

## 🏗 Architecture

The project follows **DDD** principles with Clean Architecture layering:

```
API → Application → Domain ← Infrastructure
```

- **Domain** — Core business logic: entities, value objects, domain rules. Zero external dependencies.
- **Application** — Use cases, CQRS commands/queries via MediatR.
- **Infrastructure** — Repository implementations, EF Core, external services.
- **API** — Entry point, endpoints, DI composition, middleware.

---

## 🧪 Tests

```bash
dotnet test
```

---

## ⚙️ Configuration

Configuration is managed via `appsettings.json` / `appsettings.Development.json`.

| Key | Description |
|-----|-------------|
| `ConnectionStrings:DefaultConnection` | PostgreSQL connection string |

> **Note:** Never commit real credentials. Use `appsettings.Development.json` (gitignored) or environment variables for secrets.

---

## 📝 License

MIT
