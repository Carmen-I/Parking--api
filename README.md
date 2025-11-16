# 🚗 Sensade Parking Management API

** ⚠️ Notes & Future Improvements **

This project was built quickly for an assignment in one weekend, so a few things are still missing:

Proper unit tests and integration tests

More detailed error handling

Input validation for some endpoints

More consistent responses for failed requests

---
The core functionality works and has been manually tested through Swagger, but the project would benefit from adding automated tests and stronger validation in the future.
This project is a **.NET 8 Web API** that manages parking areas and parking spaces.  
It allows users to:
- Create, read, update, and delete **parking areas**
- Create, read, update, and delete **parking spaces**
- Update parking space status (Free/Occupied)
- Count parking spaces by status (e.g., how many are free)

The API uses **PostgreSQL** for persistence and **Dapper** as the lightweight ORM.

---

## 🧱 Project Structure

```
SensadeProject2/
├── APISensade/           # Web API layer (controllers, Program.cs)
├── SensadeData/          # Data access layer (Dapper, models, repositories)
└── SensadeProject2.sln   # Solution file
```

---

## ⚙️ Database Connection

Your PostgreSQL connection string (in `appsettings.json`):

```json
"ConnectionStrings": {
  "SensadeConnection": "Host=localhost;Port=5432;Database=sensade_db;Username=postgres;Password=12tf56so"
}
```

Make sure PostgreSQL is running locally and that the `sensade_db` database exists.

---

## 🧠 Architecture Overview

This project follows a **3-layer architecture**:

| Layer | Description |
|-------|--------------|
| **API Layer** | ASP.NET controllers that define HTTP endpoints |
| **Business Logic Layer** | Classes that handle validation and business rules |
| **Data Access Layer** | Dapper-based repository classes for PostgreSQL |

---

## 🚀 How to Run

### Prerequisites
- .NET 8 SDK
- PostgreSQL installed and running locally
- Database created (`sensade_db`)
- Connection string updated in `appsettings.json`

### Steps
```bash
dotnet restore
dotnet build
dotnet run --project APISensade
```

The API will start and display:
```
Now listening on: https://localhost:5041
```

Then open your browser at:
👉 **https://localhost:5041/swagger**

---

## 🔗 API Endpoints

### 🅿️ Parking Areas

| Method | Endpoint | Description |
|--------|-----------|-------------|
| `GET` | `/api/parkingareas` | Get all parking areas |
| `GET` | `/api/parkingareas/{id}` | Get parking area by ID |
| `PUT` | `/api/parkingareas` | Update a parking area |
| `DELETE` | `/api/parkingareas/{id}` | Delete a parking area |

---

### 🚘 Parking Spaces

| Method | Endpoint | Description |
|--------|-----------|-------------|
| `GET` | `/api/parkingspaces` | Get all or a specific parking space |
| `GET` | `/api/parkingspaces/area/{areaId}` | Get spaces in a parking area |
| `POST` | `/api/parkingspaces` | Create a new parking space |
| `PUT` | `/api/parkingspaces` | Update parking space |
| `PATCH` | `/api/parkingspaces/{id}/status/{status}` | Update space status (Free/Occupied) |
| `GET` | `/api/parkingspaces/area/{areaId}/count/{status}` | Count spaces by status |
| `DELETE` | `/api/parkingspaces/{id}` | Delete parking space |

---

## 🧰 Technologies Used
- C# (.NET 8)
- ASP.NET Core Web API
- Dapper
- PostgreSQL
- Swagger / OpenAPI
- Dependency Injection

---

## 🧪 Example Usage

You can test all endpoints using **Swagger**, which is automatically enabled when the project runs.  
For example:
- Update parking space status → `PATCH /api/parkingspaces/{id}/status/{status}`  
- Get all parking areas → `GET /api/parkingareas`  
- Get spaces from area → `GET /api/parkingspaces/area/{areaId}`  

---

## 🐳 (Optional) Run PostgreSQL in Docker

You can use Docker instead of installing PostgreSQL manually:

```yaml
services:
  postgres:
    image: postgres:latest
    container_name: sensade_db
    environment:
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: 12tf56so
      POSTGRES_DB: sensade_db
    ports:
      - "5432:5432"
    volumes:
      - pgdata:/var/lib/postgresql/data

volumes:
  pgdata:
```

Start it with:
```bash
docker compose up -d
```

---
## 👩‍💻 Author

**Carmen [Bruger]**  
🎓 Datamatiker Student at UCN  
💡 Passionate about practical IT systems and software that improve business efficiency.  
🧠 Experience with C#, SQL, and software architecture.

---
