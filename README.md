# NewsWebApp

This is a project on a News Web Application. 
Using This project a user can Create, View, Update and Delete News Articles. 
You can also register and Login as Users in this application. 
Unregistered users can view articles while registered users can do the same, as well as Create, Update and Delete articles based on the user Roles.


## Prerequisites:
* [.NET SDK](https://dotnet.microsoft.com/en-us/download)
* [PostgreSQL](https://www.postgresql.org/download/)

## Usage

### Connection String
* In `appsettings.json` change the connection string based on your Postgres Username, password and port number

### Apply Migrations
To Add Migrations, first open the Nuget Package Manager Console
* For Article Table type:
```
Add-Migration MigrationName -Context ApplicationDBContext
```

* For Users Table type:
```
Add-Migration MigrationName -Context UserDBContext
```

### Running the Program
* In visual studio you can run the program after opening `NewsWebApp.sln` file
* Either a browser window pops up by itself or go to `localhost:7138`

### Creating Articles
* First, goto register and create a new user. This user will have `BROWSER` role by default.
* Open the database using [PGAdmin](https://www.pgadmin.org/)
* Open the `UserRoles` table and assign the **`RoleId`** of `CREATOR` to the **`UserId`** of the required user.
* Log In as the user with `Creator` role and go to **Article Dashboard**
* Go to **Create New Article** and here you can create the article
