# CrudApplication_DotNet_Mysql

A **CRUD** (Create, Read, Update, Delete) application built using **ASP.NET Core** and **MySQL**, demonstrating a layered architecture for a simple employee information system. The application follows a **3-layer architecture**: **Controller**, **Service Layer**, and **Repository Layer**, ensuring separation of concerns and maintainability.

## 🌟 Features
- **Create:** Add new user information with fields like UserName, EmailID, MobileNumber, Salary, and Gender.
- **Read:** Retrieve all user records or get specific information by ID.
- **Update:** Modify existing user information based on the provided user ID.
- **Delete:** Remove user information using the user ID.
- **Exception Handling:** Robust error handling with meaningful messages for failed operations.
- **Database Integration:** Uses **MySQL** as the backend with efficient data retrieval using ADO.NET.
- **Configuration:** Connection strings and other settings are configured using `appsettings.json`.

## 🛠️ Technologies Used
- **Backend Framework:** ASP.NET Core 6
- **Database:** MySQL
- **Language:** C#
- **ORM/Database Access:** ADO.NET
- **Dependency Injection:** Built-in support in .NET Core
- **API Format:** JSON-based RESTful API

## 🔍 Project Structure
The project follows a **3-layer architecture**:

1. **Controllers Layer:** Handles API requests and maps them to service methods.
2. **Service Layer:** Contains business logic and interacts with the repository layer.
3. **Repository Layer:** Manages database operations using ADO.NET.

### Folder Structure