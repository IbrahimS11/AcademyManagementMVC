# 🎓 Academy Management System (ASP.NET Core MVC)

---

## 📌 Overview

This project is a **Student, Instructor, Course, and Department Management System** built using **ASP.NET Core MVC**.

The main goal of this project was **deeply understanding how ASP.NET MVC works internally**, rather than just building CRUD screens. The focus was on authentication & authorization, MVC lifecycle, filters pipeline, server-side validation, repository pattern, and AJAX-based communication.

This project represents a **strong learning-stage MVC application** with real-world scenarios and business rules.

---

## 🎯 Learning Focus & Key Concepts

### 🔄 ASP.NET MVC Lifecycle (Deep Understanding)

* Request routing and controller/action selection
* Model binding and validation flow
* ViewModel population and re-population
* Action execution → Result rendering
* Error handling through filters

---

### 🔐 Authentication & Authorization (ASP.NET Identity)

* Cookie-based authentication using **ASP.NET Core Identity**
* User registration and login via `UserManager` and `SignInManager`
* Role management using `RoleManager<IdentityRole>`
* Role-based authorization using `[Authorize]` and `[Authorize(Roles = "Admin")]`
* Claims-based authentication during login

---

### 🧩 Filters Pipeline

* Custom global error handling using `HandleErrorAttribute`
* Understanding filter execution order
* Cross-cutting concerns handled outside controllers

---

### ✅ Server-Side Validation

* Validation using ViewModels
* Custom validation attributes (e.g. uniqueness checks)
* Business-rule validation using `ModelState.AddModelError`
* Safe re-rendering of views when validation fails

---

### ⚡ AJAX Communication

* AJAX requests using `XMLHttpRequest`
* JSON-based responses for create/delete operations
* Dynamic UI updates without full page reload
* Server-side endpoints returning JSON for client-side logic

---

## 🚀 Core Features

### 👨‍🎓 Trainee Management

* Display trainee course results
* Pass/Fail calculation based on course minimum degree
* Color-based result rendering (Pass / Fail)

---

### 👨‍🏫 Instructor Management

* Create, update, list, and view instructors
* Assign instructors to departments and courses
* Dynamic dropdowns based on department selection
* Reusable ViewModel logic for Create/Edit scenarios
* Partial views for reusable UI components

---

### 📘 Course Management

* Secure access using `[Authorize]`
* Server-side pagination
* Course creation and editing with validation
* AJAX-based validation (MinDegree < Degree)
* Course results with trainee performance analysis
* Percentage calculation and visual feedback

---

### 🏢 Department Management

* AJAX-based department creation and deletion
* Business rules preventing deletion when related data exists
* Dynamic success/error feedback (JSON responses)
* Display related courses per department

---

### 🔐 Role Management

* Admin-only role creation
* Secure role management using ASP.NET Identity

---

## 🧱 Architecture & Design Patterns

* ASP.NET Core MVC Architecture
* Repository Pattern (per entity)
* Dependency Injection (constructor & method-level)
* Separation of concerns between Controllers, ViewModels, and Repositories
* Business logic handled at appropriate layers

---

## 🛠️ Tech Stack

* **Framework:** ASP.NET Core MVC
* **Language:** C#
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Authentication:** ASP.NET Core Identity (Cookies)
* **Authorization:** Roles & Claims
* **Frontend:** Razor Views, AJAX (XMLHttpRequest)
* **Design Patterns:** Repository Pattern

---

## 📂 Project Structure

```
Controllers/
│   ├── AccountController.cs
│   ├── CourseController.cs
│   ├── DepartmentController.cs
│   ├── InstructorController.cs
│   ├── TraineeController.cs
│   └── RoleController.cs
│
Filters/
│   └── HandleErrorAttribute.cs
│
Models/
│   ├── ApplicationUser.cs
│   ├── ErrorViewModel.cs
│   ├── UniqueAttribute.cs
│   └── Entities/
│       ├── Course.cs
│       ├── CrsResult.cs
│       ├── Department.cs
│       ├── Instructor.cs
│       └── Trainee.cs
│
Repository/
│   └── Entity repositories
│
ViewModel/
│   └── ViewModels for validation and UI binding
│
Views/
│   ├── Account/
│   ├── Course/
│   ├── Department/
│   ├── Instructor/
│   ├── Trainee/
│   └── Home/
│
Migrations/
│   └── EF Core migrations
```

---

## 🧪 Best Practices Applied

* Strong understanding of MVC request lifecycle
* Identity-based authentication and authorization
* Clean separation of responsibilities
* Business rules enforced at server side
* Secure handling of user input
* Improved UX using AJAX and partial views

---

## 📈 Future Enhancements

* Migrate project to ASP.NET Core Web API
* Replace cookie authentication with JWT
* Add refresh tokens
* Introduce unit and integration testing
* Enhance frontend using a modern JS framework

---

## 👤 Author

**Ibrahim Sameer**
Back-End .NET Developer

---

## ⭐ Notes

This project represents a **strong foundation in ASP.NET Core MVC** and demonstrates a clear learning path toward modern backend development using Web APIs, JWT authentication, and clean architecture.
