## 1 - Services
- The application’s external interface layer
- Project configuration files and controllers
 
## 2 - Application
- Handles calls from the Services layer
- Contains the AppService files

## 3 - Domain
- Entity classes, enums, and repository interfaces

## 4.1 - Infra.Data
- Database connection configuration and repository classes
- Handles communication with the database

## 4.2 - Infra.CrossCutting.Dto
- DTO classes

## 4.2 - Infra.CrossCutting.Ioc
- Dependency injection configuration, used in Startup.cs 
