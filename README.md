# Learning Management System

A layered ASP.NET Core Web API for managing students, courses, and course enrollments. The project separates API controllers, business logic, data access, and DTO mapping to keep responsibilities organized and maintainable.

## Features

- Student management: create, view, update, delete, search by name, and view student dashboards/enrollments
- Course management: create, view, update, delete, and sort courses by duration
- Enrollment management: create, view, update, and delete enrollments
- REST-style HTTP endpoints with validation and appropriate HTTP responses
- Entity Framework Core with SQL Server for data access
- Swagger/OpenAPI support for API exploration during development
- Three-layer structure: Web API, Business Logic Layer (BLL), and Data Access Layer (DAL)

## Tech Stack

| Technology | Purpose |
|---|---|
| C# | Application development |
| ASP.NET Core 8 | Web API |
| Entity Framework Core | ORM / data access |
| SQL Server | Database |
| AutoMapper | Entity/DTO mapping |
| Swagger / Swashbuckle | API documentation and testing |

## Architecture

```text
LearningManagementSystem/
├── LearningManagementSystem/   # ASP.NET Core Web API
│   ├── Controllers/
│   ├── Program.cs
│   ├── appsettings.json
│   └── Properties/
├── BLL/                        # Business Logic Layer
│   ├── DTOs/
│   ├── Services/
│   └── MapperConfig.cs
├── DAL/                        # Data Access Layer
│   ├── EF/
│   └── Repos/
└── LearningManagementSys.slnx
```

### Request flow

```text
Client
  ↓
API Controller
  ↓
BLL Service
  ↓
DAL Repository
  ↓
Entity Framework Core
  ↓
SQL Server
```

## API Endpoints

### Students

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Student/all` | Get all students |
| GET | `/api/Student/{id}` | Get a student by ID |
| POST | `/api/Student/create` | Create a student |
| PUT | `/api/Student/update` | Update a student |
| DELETE | `/api/Student/delete/{id}` | Delete a student |
| GET | `/api/Student/seeEnrollments/{id}` | View student enrollments |
| GET | `/api/Student/dashboard/{id}` | Get student dashboard data |
| GET | `/api/Student/searchByName?name={name}` | Search students by name |

### Courses

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Course/all` | Get all courses |
| GET | `/api/Course/{id}` | Get a course by ID |
| POST | `/api/Course/create` | Create a course |
| PUT | `/api/Course/update` | Update a course |
| DELETE | `/api/Course/delete/{id}` | Delete a course |
| GET | `/api/Course/sortedByDuration` | Get courses sorted by duration |

### Enrollments

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Enrollment/all` | Get all enrollments |
| GET | `/api/Enrollment/{id}` | Get an enrollment by ID |
| POST | `/api/Enrollment/create` | Create an enrollment |
| PUT | `/api/Enrollment/update` | Update an enrollment |
| DELETE | `/api/Enrollment/delete/{id}` | Delete an enrollment |

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server or SQL Server Express
- Visual Studio 2022, Visual Studio Code, or another .NET-compatible IDE

### 1. Clone the repository

```bash
git clone https://github.com/Zihadul68/LearningManagementSystem.git
cd LearningManagementSystem
```

### 2. Configure the database

Set the SQL Server connection string in:

```text
LearningManagementSystem/appsettings.json
```

The repository intentionally does not contain database credentials. Use your own local or environment-specific connection string.

Example:

```json
{
  "ConnectionStrings": {
    "DbConn": "Server=YOUR_SERVER;Database=LearningManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 3. Restore and build

```bash
dotnet restore
dotnet build LearningManagementSys.slnx
```

### 4. Run the API

```bash
dotnet run --project LearningManagementSystem
```

When running in the Development environment, Swagger is available through the application URL at `/swagger`.

## Development Notes

- The Web API uses dependency injection for services and repositories.
- DTOs are used between the API/business layer and database entities.
- Development Swagger is enabled in `Program.cs`.
- Database configuration should be supplied locally rather than committed with real credentials.

## Project Status

This project is a portfolio-ready academic/backend project demonstrating layered ASP.NET Core Web API development, CRUD operations, business services, repository-based data access, and SQL Server integration.

## Author

**Zihadul Islam**

GitHub: [@Zihadul68](https://github.com/Zihadul68)
