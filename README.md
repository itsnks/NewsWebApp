# NewsWebApp

## Prerequisites:
* [.NET SDK](https://dotnet.microsoft.com/en-us/download)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Usage

### Connection String
* In `appsettings.json` change the connection string according to your SQL server connection string

### Apply Migrations
To Add Migrations, first open the Nuget Package Manager Console
* For Article Table type:
```Add-Migration MigrationName -Context ApplicationDBContext```

* For Users Table type:
```Add-Migration MigrationName -Context UserDBContext```

### Running the Program
* In visual studio you can run the program after opening `NewsWebApp.sln` file
* Either a browser window pops up by itself or go to `localhost:7138`

### Creating Articles
* First, goto register and create a new user. This user will have `BROWSER` role by default.
* Open the database using [SQL Server Management Studio](https://learn.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms)
* Open the `UserRoles` table and assign the **RoleId** of `CREATOR` to the **UserId** of the required user.
* Log In as the user with `Creator` role and go to **Article Dashboard**
* Go to **Create New Article** and here you can create the article
