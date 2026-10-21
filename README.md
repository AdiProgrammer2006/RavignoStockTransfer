# Mihira Stores — Stock Transfer System

A simple stock-transfer management application built with ASP.NET Core Web API, Entity Framework Core, SQLite, HTML, CSS, and JavaScript.

## Features

- View stock quantities for Colombo, Kandy, and Galle branches.
- Transfer products between branches.
- Reject transfers with insufficient stock, invalid quantities, invalid branches or products, or identical source and destination branches.
- Record successful transfers.
- View transfer history, newest first.
- Automatically initialize the database with sample data.

## Technologies

- C# / ASP.NET Core Web API
- Entity Framework Core
- SQLite
- HTML, CSS, JavaScript
- xUnit

## How to Run

### Requirements

- .NET SDK compatible with the project

### Start the application

From the repository root:

```bash
cd StockTransfer.Api
dotnet restore
dotnet run
```

Open the local URL displayed in the terminal to access the frontend.

The SQLite database is created automatically on first startup.

### Run automated tests

From the repository root:

```bash
dotnet test
```

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | /branches/{id}/stock | View branch stock |
| POST | /transfers | Transfer stock |
| GET | /transfers | View transfer history |

### Example transfer request

```json
{
  "fromBranchId": 1,
  "toBranchId": 2,
  "productId": 1,
  "quantity": 10
}
```

## Assumptions

- Branches and products are predefined.
- Each branch starts with 50 units of each product.
- Transfers happen immediately.
- Only successful transfers are recorded.
- Authentication is outside the assessment scope.

## Improvements With More Time

- Additional validation and automated tests.
- Stronger protection against simultaneous stock transfers.
- Database migrations.
- Improved frontend usability and dynamic product selection.

## Time Spent

[Enter your actual development time.]
