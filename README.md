# 🛒 Product Management System

This is a web-based **Product Management System** built using **.NET 7 (ASP.NET Core)** following the **Onion Architecture** and implementing the **Repository Design Pattern**. The application allows **Admins** to manage product data through full **CRUD operations** (Create, Read, Update, Delete) and supports product **categorization**, **filtering**, **pagination**, **search**, and **user role management** via **ASP.NET Identity**.

The system includes **secure access**, **error handling**, and is designed with modular and scalable practices.

---

## 🛠 Technologies & Frameworks Used

- **.NET 7** (ASP.NET Core)
- **Onion Architecture**
- **Entity Framework Core**
- **Repository Design Pattern**
- **ASP.NET Identity** for authentication and role-based access
- **SQL Server**
- **ASP.NET MVC**
- **Data Annotations** and Fluent Validation
- **Custom Exception Handling**
- **Logging** (built-in logging)

---

## 🧩 Features

✅ Admin-only CRUD operations for product management  
✅ Product categorization (categories seeded in the database)  
✅ Filtering products by category  
✅ Role-based access control using ASP.NET Identity  
✅ Global product list view  
✅ Product details view  
✅ Secure login with role privileges  
✅ Custom exception handling and error modeling  
✅ Model validation before processing  
✅ Pagination and search functionality  
✅ Scalable and maintainable project structure

---

## 🧱 Architecture Overview

The solution uses **Onion Architecture**, organizing the code into distinct layers:

- **Core Layer**: Entities and Interfaces  
- **Application Layer**: Services, DTOs, and business logic  
- **Infrastructure Layer**: Database context and EF Core implementation  
- **Presentation Layer**: ASP.NET MVC application (views/controllers)

---

## 🔐 Authentication & Authorization

- **Admin Role**: Full access to product management features (Add, Edit, Delete)
- **User Role**: Can view and filter product listings only
- **Authentication**: Managed using ASP.NET Core Identity

---

## 🔎 Product Categories

- Categories are **seeded into the database** and are **not editable** through the application interface
- Each product is linked to a predefined category
- Users can **filter** products by selected category

---

## 📋 Admin Dashboard

- View all products regardless of their current visibility rules
- Access control ensures only Admins can manage product data

---

## 🧪 Future Enhancements

- Improve UI/UX with frontend frameworks  
- Implement API layer for external integrations  
- Add audit logging for product operations

---

## 📂 Getting Started

1. Clone the repository  
2. Update the database connection string in `appsettings.json`  
3. Run the initial migration and update the database  
4. Run the project  

---


Model Validation

Custom Error Handling


