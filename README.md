# DapperExample.API

`DapperExample.API` is a simple API that demonstrates how to integrate **Dapper** with **ASP.NET Core** using the **Repository Pattern** for data access, along with **Swagger UI** for easy API documentation and testing. This project also customizes Swagger's appearance using a custom CSS file for a modern and attractive UI.

## Features

- **Dapper Integration:** Demonstrates how to use Dapper with SQL Server to perform CRUD operations.
- **Repository Pattern:** Implements the repository pattern to manage data access and keep the code clean and maintainable.
- **Swagger UI Customization:** Includes custom CSS for an attractive and modern Swagger UI design.
- **SQL Stored Procedures:** The application utilizes stored procedures for database operations, providing a robust and scalable approach to interact with the database.
- **EF Core (for migrations):** Uses EF Core for managing database schema migrations and model mapping.

## Why Use Dapper?

Dapper is a lightweight, high-performance Object-Relational Mapper (ORM) for .NET. It's designed to be fast and efficient, making it a popular choice when working with databases. Here are some key reasons why you might choose Dapper for your project:

### 1. **Performance**
   Dapper is known for its high performance compared to traditional ORMs like Entity Framework. It uses raw SQL queries and maps the results to objects directly, reducing overhead and improving execution speed.

### 2. **Simplicity and Flexibility**
   Dapper provides a simple API for executing SQL queries and mapping the results to strongly-typed objects. It doesn't require complex configuration or setup, making it easy to use in smaller projects or when you need fine-grained control over your SQL.

### 3. **Minimal Overhead**
   Unlike heavier ORMs, Dapper adds minimal overhead to your queries. It doesn't track entity states or change tracking, making it more lightweight and suitable for high-performance applications.

### 4. **Control Over SQL Queries**
   Dapper gives developers full control over their SQL queries. While ORMs like Entity Framework abstract SQL generation, Dapper lets you write raw SQL queries, which is especially useful for complex queries or when you need fine-tuned performance optimization.

### 5. **Support for Multiple Databases**
   Dapper supports various database systems, including SQL Server, MySQL, PostgreSQL, SQLite, and more. This makes it a great choice for applications that need to work with different databases.

### 6. **Easy Integration with Existing Code**
   Dapper is easy to integrate into existing projects, especially if you already have complex or legacy SQL queries. It doesn’t require a complete rewrite of your data access code, making it ideal for projects that require incremental improvements.

### 7. **Lightweight and Minimalist**
   Dapper has a very small footprint, meaning it won't bloat your application. It’s simple, focused, and doesn’t impose unnecessary complexity, making it a great choice when you need a fast and efficient data access layer.

### 8. **Active Community and Widely Used**
   Dapper has a large and active community. It is well-maintained and widely adopted in production environments. Many developers use Dapper in real-world applications, which means it has been battle-tested and optimized over time.

---

### When to Use Dapper?
Dapper is a great choice when you need:
- High-performance data access with minimal overhead.
- Fine-grained control over SQL queries.
- Simplicity and ease of use without complex ORM features.
- To integrate into an existing project with minimal changes.

If your application doesn’t require advanced ORM features like change tracking, lazy loading, or automatic migrations, Dapper provides a simple and fast alternative to other ORMs like Entity Framework.


## Technologies Used

- **ASP.NET Core 6/7**: Backend framework to build RESTful APIs.
- **Dapper**: A lightweight ORM used for database operations.
- **SQL Server**: Relational database used for data storage.
- **Swagger UI**: Used for API documentation and testing.
- **Entity Framework Core (EF Core)**: Used for managing database schema migrations and model mapping.

## Getting Started

Follow these steps to get your development environment set up:

### Prerequisites

- .NET 6.0 SDK or later
- SQL Server (local or remote)
- Visual Studio Code or Visual Studio (Optional)

### 1. Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/mehedihasan9339/DapperExample.API.git
```


### 2. Set Up the Database

Ensure you have a SQL Server instance running. The project uses stored procedures, and the schema will be created using **Entity Framework Core** migrations.

#### Connection String

Make sure to update your connection string in the `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=Mehedi;Database=DapperExampleDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```


You can create the necessary tables and stored procedures manually or use **EF Core Migrations**.

#### Seed Data

In the `OnModelCreating` method of `AppDbContext`, there is a seeding logic for initial data setup. Ensure that this data is loaded when you run the application.

### 3. Run the Project

1. Restore the NuGet packages:

    ```bash
    dotnet restore
    ```

2. Apply migrations to create the database schema:

    ```bash
    dotnet ef database update
    ```

3. Run the application:

    ```bash
    dotnet run
    ```

   The API will be hosted on `https://localhost:5001` (by default).

### 4. Access the Swagger UI

Once the application is running, open your browser and go to:

https://localhost:5001/swagger


This will load the Swagger UI where you can test the available API endpoints.

### 5. Interact with the API

You can now use the **Swagger UI** to interact with the API. The `CategoryController` is exposed for CRUD operations on categories, and each action has corresponding buttons (e.g., `Try it out`, `Execute`) to test the endpoints directly.

### 6. Custom Swagger UI Styling

This project customizes the default Swagger UI with a custom CSS file. The following styles have been applied:

- Modern gradient background.
- Custom button colors and hover effects.
- Updated header and operation block styles for better readability and aesthetics.
- Responsive design for a better user experience.

### 7. Using Dapper and Stored Procedures

This project demonstrates the use of **Dapper** for querying the database and using stored procedures for all CRUD operations. The following stored procedures are created to manage categories:

### Stored Procedures

Here are the stored procedures used in this project:

#### `sp_GetAllCategories`

```sql
CREATE OR ALTER PROCEDURE sp_GetAllCategories
AS
BEGIN
    SELECT Id, Name
    FROM Categories
    ORDER BY Name;
END
```

#### `sp_GetCategoryById`

```sql
CREATE OR ALTER PROCEDURE sp_GetCategoryById
    @CategoryId INT
AS
BEGIN
    SELECT Id, Name
    FROM Categories
    WHERE Id = @CategoryId;
END
```

#### `sp_InsertCategory`

```sql
CREATE OR ALTER PROCEDURE sp_InsertCategory
    @Name NVARCHAR(100)
AS
BEGIN
    INSERT INTO Categories (Name)
    VALUES (@Name);
END
```

#### `sp_UpdateCategory`

```sql
CREATE OR ALTER PROCEDURE sp_UpdateCategory
    @CategoryId INT,
    @Name NVARCHAR(100)
AS
BEGIN
    UPDATE Categories
    SET Name = @Name
    WHERE Id = @CategoryId;
END
```

#### `sp_DeleteCategory`

```sql
CREATE OR ALTER PROCEDURE sp_DeleteCategory
    @CategoryId INT
AS
BEGIN
    DELETE FROM Categories
    WHERE Id = @CategoryId;
END
```

### API Endpoints

The API exposes the following endpoints:

- `GET /api/categories`: Retrieves all categories.
- `GET /api/categories/{id}`: Retrieves a category by its ID.
- `POST /api/categories`: Adds a new category.
- `PUT /api/categories/{id}`: Updates an existing category.
- `DELETE /api/categories/{id}`: Deletes a category.

## Project Structure

Here’s a quick overview of the project structure:

![Project Structure](https://github.com/mehedihasan9339/DapperExample.API/blob/master/wwwroot/images/project-structure.png?raw=true)

## Project Overview

Here’s a screenshot showing the overview of the project:

![Project Overview](https://github.com/mehedihasan9339/DapperExample.API/blob/master/wwwroot/images/project-overview.png?raw=true)
