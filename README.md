# ForumApp
Project created for the purpose of practicing TDD, SOLID Principles and Clean Code.

_It is still under development._ :)

### Technologies

* **ASP.NET Core**
    - xUnit for unit testing
    - Swagger for documentation
    - Data stored using Entity Framework Core, in a SQL Server database.
* **React.js + Redux**

---
#### Running the projects

##### First of all, change the Connection String at _AspNetCore-Api/ForumApp.Web/appsettings.Development.json_
##### ASP.NET Core
*Using .NET Core CLI*
- cd into _AspNetCore-Api/ForumApp.Web_ folder and run the following commands  
```dotnet restore```  
```dotnet run```

*Using Visual Studio*
- Set the ForumApp.Web project as Startup project and run it.

##### React.js
*Using npm*
- cd into _/React-App/forum-app/_ and run the following commands  
```npm install```  
```npm start```

---
#### Running Tests

*Using .NET Core CLI*
- cd into _AspNetCore-Api/ForumApp.Tests_ and run

```dotnet test ForumApp.Tests.csproj```

*Using Visual Studio*
- You can also run the tests using the VS built-in test runner (Test Explorer).


