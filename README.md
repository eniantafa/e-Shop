# e-Commerce
eCommerce App build on top of Asp.Net Core MVC framework. 

Technologies used: • ASP.NET Core 1.1 • Entity Framework Core • Entity Framework Migrations – Code First

Installing .NET Core To install .NET Core please follow the steps on the official web site https://dotnet.microsoft.com/download/dotnet-core

Opening project -Open the solution in VS 2017

-Open Package Manager Console on the project by going to: Tools > Nuget Package Manager > Package Manager Console

-On the start up class modify the database connection string (connection) to reflect your database environment

-Run the following commands (they will create the database schema on your database environment):

dotnet ef migrations add FirstMigration

dotnet ef database update
Build and Run You could test the API using POSTMAN which can be downloaded from here: https://www.getpostman.com/
