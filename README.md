# sales-tracker
Demo sales recording web application for learning ASP.NET Core 6 MVC.

## Technology Stack
- .NET 6
- ASP.NET Core 6 (MVC)
- Entity Framework Core 6
- Bootstrap 5

## Architecture
- Web application uses MVC architectural pattern (Model-View-Controller)
- Projects are divided into main folders by functionality (Customers, Products, Sales etc.)
- CQRS pattern is used for accessing database (via Entity Framework Core 6)
- Single database is used both writing and reading (commands and queries)
