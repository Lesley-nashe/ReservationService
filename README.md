# 🍽️ Reservation API

This is a RESTful .NET API for managing table availability and reservations in a restaurant environment. 
---

## 🚀 Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQL Server / SQLite (customizable)
- Swagger (for API testing)

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or VS Code

---

### 🔧 Setup

```bash
# Clone the repository
git clone https://github.com/Lesley-nashe/TableService.git
cd table-service-api

# Restore dependencies
dotnet restore

# Apply EF Core migrations (if needed)
dotnet ef database update

# Run the API
dotnet run
