# {C# Dr.Sillystringz Factory}

#### By _**Tyler Emmerson**_  

#### _MVC application to keep track of machine repairs_  

---
## Technologies Used

* _GitHub_
* _Bash_
* _Node_
* _C#_
* _.NET_
* _HTML_
* _CSS_
* _SQL Workbench_
* _Entity Framework_
* _MVC_

---
## Description

_This program will provide a way for Dr.SillyStringz to keep track of machine repairs._

---
## Setup/Installation Requirements
* Install *`Microsoft .NET SDK`*
* Install *`MySQL Workbench`*
<details>
<summary><strong>Add appsettings.json</strong></summary>
Navigate to  
    <pre>Dr.SillyStringz_Solution
    ├── <strong>Factory</strong></pre>

* $ touch appsettings.json 
* Open the appsettings.json and enter:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=Localhost;Port=3306;database=[Database-Name];uid=root;pwd=[YOUR-PASSWORD];"
    }
}
``` 

</details>

<details>
<summary><strong>For Running</strong></summary>
Navigate to  
    <pre>Dr.SillyStringz_Solution
    ├── <strong>Factory</strong></pre>


 Run ```$ dotnet restore``` in the console 
 Run ```$ dotnet ef migration add Initial``` in the console 
 Run ```$ dotnet ef database update``` in the console  
 Run ```$ dotnet run``` in the console
 Visit <http://localhost:5000>
 
</details>

<br>

This program was built using *`Microsoft .NET SDK 5.0.401`*, and may not be compatible with other versions.

---
## Known Bugs

* _None._

## License

[MIT](/LICENSE)
