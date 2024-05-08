# Eskitech API - proof of concept API

## Project structure
Following Controller-Service-Repository pattern, the project is divided into the following projects:
- `Eskitech.API` --> WebAPI
- `Eskitech.Contracts` --> Data transfer objects (DTOs)
- `Eskitech.Domain` --> Services (Business Logic Layer)
- `Eskitech.Entities` --> Entities
- `Eskitech.Infrastructure` --> DbContexts, Migrations, Data seeding and Repositories (Data Access Layer)