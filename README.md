# Minimal API TodoList (ASP.NET Core)

A lightweight and high-performance backend application for managing a task list, built using **ASP.NET Minimal APIs**. This project represents a migration from the previous console-based implementation to a web service.

## Features
* **REST API Architecture:** Implements standard HTTP methodologies.
* **Full CRUD Functionality:** Supports creating, reading, updating (status toggling), and deleting tasks.
* **Data Persistence:** Automatically serializes and deserializes application state using a local `tasks.json` file via `System.Text.Json`.
* **Error Handling:** Validates task identifiers and returns proper HTTP status codes (e.g., 404 Not Found) instead of risking runtime exceptions.

## Architecture
The application is structured into logical layers to maintain clean separation of concerns:
* `Program.cs` — Application entry point, Dependency Injection configuration (`TaskService` registered as a Singleton), and endpoint mapping.
* `Services/TaskService.cs` — Core business logic, data state management, and file I/O operations.
* `Models/TaskModel.cs` — The task data structure.

## API Endpoints
* `GET /tasks` — Retrieve all tasks.
* `GET /tasks/{id}` — Retrieve a specific task by its unique identifier.
* `POST /tasks` — Create a new task.
* `PUT /tasks/{id}/finish` — Toggle the completion status of a task.
* `DELETE /tasks/{id}` — Remove a task from the system.

## Local Deployment
1. Clone the repository to your local machine.
2. Execute the application using the .NET CLI:
   ```bash
   dotnet run