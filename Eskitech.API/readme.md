# Eskitech API - proof of concept API

## Project structure
Following Controller-Service-Repository pattern, the project is divided into the following projects:
- `Eskitech.API` --> WebAPI
- `Eskitech.Contracts` --> Data transfer objects (DTOs)
- `Eskitech.Data` --> Repositories (Data Access Layer)
- `Eskitech.Domain` --> Entities, services and specific seeding implementations
- `Eskitech.Domain.Shared` --> Shared domain constants, enums etc.
- `Eskitech.Infrastructure` --> DbContexts, Migrations, and data seeding system