# AI Usage Notes

## Tools Used

I used ChatGPT to assist with understanding the assignment, planning the project, learning ASP.NET Core and Entity Framework Core, generating example code, troubleshooting errors, and preparing automated tests.

## How I Used AI

- Received guidance on creating an ASP.NET Core Web API.
- Learned how to configure SQLite using Entity Framework Core.
- Used suggested code as a starting point for database models, controllers, frontend functionality, and tests.
- Debugged compilation and database initialization issues.
- Learned how to send HTTP POST requests using PowerShell.

## An AI Mistake or Confusing Suggestion

The initial implementation guidance did not correctly account for the naming conflict between the `StockTransfer` namespace and the `StockTransfer` model class.

The compiler reported that `StockTransfer` was a namespace being used as a type.

I investigated the error and resolved it by explicitly identifying the model type using a C# type alias.

I also encountered database initialization issues while configuring the application and used compiler output and startup diagnostics to investigate them.

## What Was New to Me

Before this assessment, I was mainly familiar with Java and the Spring Boot framework for backend development. I had no practical experience building applications using C# and ASP.NET Core.

With the help of ChatGPT, I was able to learn the basics of .NET and develop a small working stock-transfer application. During this process, I learned how to create REST API endpoints using ASP.NET Core, configure a SQLite database with Entity Framework Core, implement business logic, and connect the backend to a simple frontend.

Some concepts were familiar because of my experience with Spring Boot, but the C# syntax, project structure, dependency injection configuration, and Entity Framework Core were new to me.

I faced a few errors during development, especially with namespaces and database initialization. With AI guidance, I was able to understand the issues, make corrections, and get the application working.

This assessment gave me my first hands-on experience with .NET development and showed me how I could apply my existing backend knowledge to a different technology stack while using AI as a learning and development assistant.

## How I Learned

I worked through the project incrementally, ran the application, examined error messages, tested the API endpoints, and verified the database and stock changes.

## Reflection

AI helped speed up development and troubleshooting, but generated code still needed to be compiled, tested, and checked against the assessment requirements.
