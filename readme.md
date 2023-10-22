<!--
*** Readme template extracted from https://github.com/othneildrew/Best-README-Template
-->

<br />
<div align="center">
  <h3 align="center">Entity Framework Core (EF Core)</h3>

  <p align="center">
    Knowledge management for entity framework core, a popular Object Relational Mapping (ORM) framework for .NET development. 
  </p>
</div>

<!-- ABOUT THE PROJECT -->
## About The Project

In this repository, we will be covering the basics of EF Core which you can refer to setup on your projects.

### Built With
- .NET 7
- EFCore 7
- SqlServer

 
# Code First
Code first, as the name implies, you will write the database schemas in your codebase and migrate to the actual database. This could be your local database instance or containerized instance.

Steps taken:

1. Add NuGet Packages - EntityFrameworkCore and EntityFrameworkCore.SqlServer to (CodeFirst.Persistence)

    ```console
    PM > Install-Package Microsoft.EntityFrameworkCore
    PM > Install-Package Microsoft.EntityFrameworkCore.SqlServer
    ```

2. Add NuGet Package - EntityFrameworkCore.Tools to startup project (CodeFirst.Api)
    ```console
    PM > Install-Package Microsoft.EntityFrameworkCore.Tools
    ```
3. Add Project Reference -> From: CodeFirst.Api to CodeFirst.Persistence

4. Create files:
    - Weather.cs (Entity)
    - WeatherConfiguration.cs (Schema design)
    - ApplicationDbContext.cs (Inherits from DbContext)
    - Add database context into DI container
    - Provide connection string from startup project (Api)
    - Seed database
    - Expose endpoint to retrieve weather records

5. Time to migrate the defined schemas into your database. Click [here](efcore-tools) for more information regarding the commands for EFCore.Tools

    - Add Migration (This will generate the migration file and not apply to the database yet)
    ```console
    PM> Add-Migration InitialCreate -p CodeFirst.Persistence -s CodeFirst.Api
    ```

    - Update Database (This will apply the migration into your database. At this point, you should have configured a valid connection string.)
    ```console
    PM> Update-Database -p CodeFirst.Persistence -s CodeFirst.Api
    ```


# Database First
Database first will require you to first set up the schemas in your database (or use an existing database) and you will be scaffolding it into your codebase.

Steps taken:

1. Add NuGet Packages - EntityFrameworkCore and EntityFrameworkCore.SqlServer (or any other database)

    ```console
    PM> Install-Package Microsoft.EntityFrameworkCore
    PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
    ```

2. Add NuGet Package - EntityFrameworkCore.Tools to startup project (DatabaseFirst.Api)
    ```console
    PM > Install-Package Microsoft.EntityFrameworkCore.Tools
    ```

3. Add Project Reference -> From: DatabaseFirst.Api to DatabaseFirst.Persistence

4. Setup your database (if not already exists) in your environment.

5. Add connection string to appsettings.json in DatabaseFirst.Api

6. Scaffold your database (Fetch and create the table models from existing database)

    ```console
    PM> Scaffold-DbContext name=Database Microsoft.EntityFrameworkCore.SqlServer -ContextDir . -Context ApplicationDbContext -OutputDir Weathers -StartupProject DatabaseFirst.Api -Project DatabaseFirst.Persistence
    ```
    Click [here](efcore-tools) for additional parameters to configure your scaffold.

7. Add database context into DI container

8. Expose endpoint to retrieve weather records

<!-- GETTING STARTED -->
### Installation

To install and test on your local machine:

1. Clone the repo
   ```sh
   git clone https://github.com/darrenleeyx/KM_EFCore
   ```

2. Code First
    - Update the connection string in appsettings.json (CodeFirst.Api)
    - Update your database with the current migration
       ```console
       PM> Update-Database -p CodeFirst.Persistence -s CodeFirst.Api
       ```
    - Run CodeFirst.Api
 
 3. Database First
    - Create the database using the script
    ```sql
    CREATE DATABASE [Weather_DatabaseFirst];
	
	CREATE TABLE [Weather_DatabaseFirst].[dbo].[Weathers](
	    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	    [DateTime] [datetime2](7) NOT NULL,
	    [Description] [nvarchar](max) NOT NULL);

    INSERT INTO [Weather_DatabaseFirst].[dbo].[Weathers] VALUES
    ('77c376d8-d7a8-474d-b62a-4cc3b4d156bf', '2023-10-22 04:24:56.1222162', 'Cloudy');
    ```
    - Update the connection string in appsettings.json (DatabaseFirst.Api)
    - Run DatabaseFirst.Api

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[efcore-tools]: https://learn.microsoft.com/en-us/ef/core/cli/powershell
