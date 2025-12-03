# Healthcare_App
A full-stack clinic management system built with .NET MAUI for the frontend and C# Web API + PostgreSQL + Entity Framework Core for the backend.
The application allows clinic staff to manage patients, physicians, and appointments, with scheduling rules ensuring appointments can only be booked during valid business hours.

## Features
### Physician Management

* Add new physicians
* Edit existing physicians
* Delete existing physicians
* View physician list
* Used when scheduling appointments

### Patient Management

* Create and list patients
* Edit and delete existing patients
* Select a patient when scheduling an appointment

### Appointment Scheduling

* Create appointments between patients and physicians
* Edit and delete scheduled appointments
* Validates that scheduling is:
  * Monday–Friday
  * Between 9:00 AM and 5:00 PM
* Prevents invalid or out-of-range appointment times

### Frontend (MAUI)

* Built using .NET MAUI XAML
* MVVM architecture
* Navigation using Shell + Query Properties

### Backend (Web API)

* ASP.NET Core Web API
* Entity Framework Core for data access
* PostgreSQL as the relational database
* Runs independently — must be started before the MAUI app

## 1. Clone the Repository
```
git clone <your-repo-url>
cd clinic-app
```
## 2. Configure PostgreSQL Connection

In the Web API project, update appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=clinicdb;Username=postgres;Password=yourpassword"
}
```
## 3. Apply Entity Framework Migrations

If migrations already exist:
```
dotnet ef database update
```

If no migrations exist yet (first-time setup):
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This automatically creates tables for:

* Physicians

## 4. Run the Server
```
dotnet run
```
Keep it running — the MAUI app requires the API to be online.
## 6. Run the MAUI Application

Mac:
```
dotnet maui run macos
```

Windows:
```
dotnet maui run windows
```

Android (if supported):
```
dotnet maui run android
```
## Architecture Overview
```
/ClinicApp
  /Frontend (MAUI)
    - Views (XAML pages)
    - ViewModels (MVVM + CommunityToolkit)
    - Services (REST API consumption)

  /Backend (ASP.NET Core Web API)
    - Controllers
    - EF Core DbContext
    - Migrations
    - PostgreSQL database
```
## Future Improvements

* Expand EF Core models with validations & relationships

* Add authentication (JWT or Identity)

* Add physician availability schedules

* Add dashboard analytics

* Add search & filter for patients and physicians

## Notes

* The backend must be running before opening the MAUI app.

* The project uses EF Core, so tables are created/updated with migrations.

* Ensure PostgreSQL is installed and running locally.
