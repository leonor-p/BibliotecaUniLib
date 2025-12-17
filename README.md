<div align="center">

# BibliotecaUniLib
### Digital Library Management System

![.NET](https://img.shields.io/badge/.NET-6.0-purple)
![C#](https://img.shields.io/badge/C%23-10.0-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-red)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-green)

**BibliotecaUniLib** is a full-stack digital library platform built with C#, .NET, and SQL Server, allowing users to browse, manage, and access digital books and academic resources through a clean and responsive interface.

</div>

---

### Table of Contents

- [About the Project](#about-the-project)
- [Key Features](#key-features)
- [Technology Stack](#technology-stack)
- [User Roles and Security](#user-roles-and-security)
- [Installation and Configuration](#installation-and-configuration)
- [Project Structure](#project-structure)
- [Key Models](#key-models)

---

## About the Project

BibliotecaUniLib is a university library management system developed as a Web and Database Laboratory project. The platform offers complete functionalities for book administration, user management, book requests, and organization by categories and academic courses.

---

## Key Features

The system provides a comprehensive set of tools for both administrators and students:

* **Book Management:** Add, edit, and remove books from the catalog.
* **Authentication System:** User registration and login with role support (Admin, User).
* **Search and Filters:** Search for books by category, course, and other criteria.
* **Request System:** Management of book loans and requests.
* **Course Organization:** Categorization of resources by academic areas.
* **Categories:** Intuitive organization of the bibliographic collection.
* **User Profiles:** Management of personalized user profiles.

---

## Technology Stack

### Backend
* **ASP.NET Core MVC:** Web framework for building the application.
* **Entity Framework Core:** ORM for database operations.
* **ASP.NET Core Identity:** Authentication and user management.
* **ASP.NET Core Session:** Session state management.

### Frontend
* **HTML5 & CSS3:** Structure and styling.
* **JavaScript:** Client-side interactivity.

### Database
* **SQL Server:** Relational database management system.

---

## User Roles and Security

### Roles

The system implements two distinct user types:

| Role | Permissions |
| :--- | :--- |
| **Administrator** | Full system management (CRUD for books, categories, courses). |
| **Librarian** | Manage book catalog (CRUD), categories, courses, and process book requests. |
| **User** | View catalog, manage profile, and request books. |

### Security Features

* **Authentication:** Secure login via ASP.NET Core Identity.
* **Authorization:** Role-based access control (RBAC).
* **Account Verification:** Mandatory account confirmation.
* **Route Protection:** Protection of sensitive routes and controllers.
* **Session Management:** Secure session handling with a 10-minute timeout.

---

## Installation and Configuration

### Prerequisites
* .NET SDK 6.0 or higher
* SQL Server
* Visual Studio 2022 or Visual Studio Code

### 1. Clone the Repository

```bash
git clone [https://github.com/leonor-p/BibliotecaUniLib.git](https://github.com/leonor-p/BibliotecaUniLib.git)
cd BibliotecaUniLib
```

### 2. Configure Connection String

Edit the `appsettings.json` file and configure the connection to your SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BibliotecaUniLib;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Run Database Migrations

Apply the Entity Framework migrations to create the database schema:

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

### 5. Access the Application

Open your browser and navigate to: `https://localhost:5001` or `http://localhost:5000`.

---

## Project Structure

```
BibliotecaUniLib/
├── Areas/              # Application areas (Identity)
├── Controllers/        # MVC Controllers
├── Data/               # Database context and initialization
├── Models/             # Data models
│   ├── BookRequests.cs
│   ├── BookViewModel.cs
│   ├── Category.cs
│   ├── Course.cs
│   └── Perfil.cs
├── Views/              # Razor Views
├── wwwroot/            # Static files (CSS, JS, images)
├── Program.cs          # Application entry point
└── appsettings.json    # Application configuration
```

---

## Key Models

| Model | Description |
| :--- | :--- |
| **BookRequests** | Manages book loan requests and status. |
| **BookViewModel** | Data Transfer Object (DTO) for displaying books in views. |
| **Category** | Defines the categories available in the library. |
| **Course** | Represents academic courses associated with books. |
| **Perfil** | Stores extended user profile information. |

---

<div align="center">

**BibliotecaUniLib** - Developed by **leonor-p**

[Back to top](#bibliotecaunilib)

</div>
