# NotesAPI

REST API для управления заметками, разработанный на ASP.NET Core с использованием Entity Framework Core и PostgreSQL.

## 🛠 Стек технологий
- **Платформа:** .NET 8/10 (ASP.NET Core Web API)
- **ORM:** Entity Framework Core
- **База данных:** PostgreSQL
- **Документация:** Swagger / OpenAPI
- **Контейнеризация:** Docker, Docker Compose

## 📁 Структура проекта
- `Contracts/` — DTO для запросов и ответов (`CreateNoteRequest`, `GetNotesRequest`, `GetNotesResponse`, `NoteDto`).
- `Controllers/` — обработка HTTP-запросов (`NotesController`).
- `DataAccess/` — контекст базы данных (`NotesDbContext`).
- `Models/` — доменная модель (`Note`).
- `Program.cs` — настройка DI, Swagger и запуск приложения.
