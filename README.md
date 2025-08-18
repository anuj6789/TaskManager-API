# Task Manager API

A secure and robust RESTful API for a task management application, built from scratch using C# and the ASP.NET Core framework. This project serves as the backend for a full-stack task management system.

## Features

-   **Secure User Authentication:** User registration and login functionality using JWT (JSON Web Tokens). Passwords are never stored in plain text; they are securely hashed and salted.
-   **Protected Endpoints:** All task-related endpoints are protected, requiring a valid JWT to access.
-   **Full CRUD Functionality:** Complete Create, Read, Update, and Delete operations for managing tasks.
-   **User-Specific Data:** Users can only view and manage the tasks that they have created.

## Tech Stack

-   **Framework:** ASP.NET Core 8
-   **Language:** C#
-   **Database:** SQL Server
-   **ORM:** Entity Framework Core (using a Code-First approach)
-   **Authentication:** JWT (JSON Web Tokens)
-   **Architecture:** RESTful API

## API Endpoints

| Method | Endpoint                  | Description                        | Protected |
| :----- | :------------------------ | :--------------------------------- | :-------- |
| `POST` | `/api/auth/register`      | Register a new user.               | No        |
| `POST` | `/api/auth/login`         | Log in and receive a JWT.          | No        |
| `GET`  | `/api/tasks`              | Get all tasks for the logged-in user. | Yes       |
| `POST` | `/api/tasks`              | Create a new task.                 | Yes       |
| `PUT`  | `/api/tasks/{id}`         | Update an existing task.           | Yes       |
| `DELETE`| `/api/tasks/{id}`         | Delete a task.                     | Yes       |

## Setup and Installation

To run this project locally, you will need [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and Visual Studio 2022.

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/TaskManager-API.git](https://github.com/your-username/TaskManager-API.git)
    ```
2.  **Open the solution** in Visual Studio 2022.
3.  **Update the database connection string** in `appsettings.json` if necessary.
4.  **Create the database** using Entity Framework Core migrations. Open the Package Manager Console and run:
    ```powershell
    update-database
    ```
5.  **Run the project** by pressing F5 or clicking the "Start Debugging" button. The API will be running and accessible at the specified `localhost` address.

