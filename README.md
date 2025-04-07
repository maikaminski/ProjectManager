# ProjectManager API

A simple project and task management REST API built with **.NET 8**, **Entity Framework Core**, and **MySQL**.

## 📌 Overview

This API allows basic operations to manage users, their projects, and associated tasks. It is currently under development and follows a clean architecture approach.

## 🛠️ Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- MySQL
- Pomelo MySQL Provider for EF Core
- Swagger / OpenAPI

## 🗃️ Current Features

- Project structure created with Models and a DbContext
- Database connection configured using `appsettings.Development.json`
- Initial database migration created and applied
- Tables: `Users`, `Projects`, `TaskItems`
- Relationships:
  - One `User` → many `Projects`
  - One `Project` → many `TaskItems`

## 🧩 Project Structure

