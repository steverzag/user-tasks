# UsersTasks

This is a simple and modular .NET Aspire Web API project designed to manage Users and their associated Tasks. Built using .NET Aspire’s application model, it serves as a base template for testing features, building proof-of-concepts (POCs), or experimenting with modern cloud-native patterns in a clean, structured environment.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server Database

## Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/steverzag/user-tasks.git
   cd <repository-folder>
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the application:
   ```sh
   dotnet build
   ```
4. Apply Database Migrations:
  ```sh
  dotnet ef database update --project ./UsersTasks/UsersTasks.API.csproj
  ```
  Make sure you have the EF Core tools installed globally:
  ```sh
  dotnet tool install --global dotnet-ef
  ```


## Running the Application
To run the application locally:
   ```sh
   dotnet run --project ./UsersTasks/UsersTasks.API.csproj
   ```

Or to run the application using [Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
   ```
   dotnet run --project ./UsersTasks.AppHost/UsersTasks.AppHost.csproj
   ```

By default, the application will be available at `http://localhost:5000` (or `https://localhost:5001` for HTTPS).

## Usage
The application exposes the endpoints that allows to create or modify users and tasks. Check ./UserTasks.http file for detailed information.
    