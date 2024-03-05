# Eviction Case Filing API

The Eviction Case Filing API is a web service that enables the filing of eviction cases and integration with the E-Filing API. This API allows users to create new eviction cases, upload documents, submit filing fees, and receive notifications from the E-Filing Manager (EFM).

## Table of Contents

- [Eviction Case Filing API](#eviction-case-filing-api)
  - [Table of Contents](#table-of-contents)
  - [Getting Started](#getting-started)
  - [API Endpoints](#api-endpoints)
  - [File Structure](#file-structure)
  - [Configuration](#configuration)
  - [Error Handling and Logging](#error-handling-and-logging)
  - [Testing](#testing)

## Getting Started

To get started with the Eviction Case Filing API, follow these steps:

1. Clone the repository:

```
https://github.com/vvonchain/dotnet_project
```

2. Install the required dependencies:

```
cd EvictionCaseFilingAPI
dotnet restore
```

1. Configure the API settings in the `appsettings.json` file.

2. Build and run the API:

5. The API will be accessible at `https://localhost:5001`.

## API Endpoints

The Eviction Case Filing API provides the following endpoints:

- `POST /api/EvictionCaseFiling/CreateNewCase`: Creates a new eviction case.
- `POST /api/EFiling/NotifyFilingReviewComplete`: Receives notifications from the EFM when filing review is complete.
- `GET /api/EFiling/GetFilingService`: Retrieves SMTP logs for e-service.
- `GET /api/EFiling/GetServiceInformation`: Retrieves service contacts for a given case or case party.
- `POST /api/EFiling/NotifyServiceComplete`: Receives notifications from the EFM when service is complete.

For detailed information about request and response formats, refer to the API documentation.

## File Structure

The repository has the following file structure:

- `src/EvictionCaseFilingAPI/`: Contains the main API project.
- `Controllers/`: Contains the API controllers.
 - `EFilingController.cs`: Handles E-Filing API endpoints.
 - `EvictionCaseFilingController.cs`: Handles eviction case filing endpoints.
- `Models/`: Contains the data models used by the API.
 - `CreateCaseRequest.cs`: Represents the request model for creating a new case.
 - `CreateCaseResponse.cs`: Represents the response model for creating a new case.
 - Other models based on the EFSP guide.
- `Services/`: Contains the service classes that implement the API logic.
 - `IEvictionCaseFilingService.cs`: Defines the interface for the eviction case filing service.
 - `EvictionCaseFilingService.cs`: Implements the eviction case filing service.
 - `IEFilingService.cs`: Defines the interface for the E-Filing service.
 - `EFilingService.cs`: Implements the E-Filing service.
 - `ConfigurationService.cs`: Handles configuration retrieval and caching.
 - `CallbackService.cs`: Handles asynchronous callbacks to the EFM.
- `Startup.cs`: Configures the API services and middleware.
- `Program.cs`: The entry point of the API application.
- `appsettings.json`: Contains the API configuration settings.
- `src/EvictionCaseFilingAPI.Tests/`: Contains the unit tests for the API.
- `EvictionCaseFilingServiceTests.cs`: Contains unit tests for the eviction case filing service.
- `.gitignore`: Specifies files and directories to be ignored by Git.
- `README.md`: Provides information and documentation about the API.

## Configuration

The API configuration is stored in the `appsettings.json` file. The following settings are available:

- `Serilog`: Configures the Serilog logging settings.
- `X509Certificate`: Specifies the path and password for the X.509 certificate used for message signing.
- Other settings specific to the API and its dependencies.

Make sure to update the configuration file with the appropriate values before running the API.

## Error Handling and Logging

The API utilizes Serilog for logging and implements error handling mechanisms. Errors and exceptions are logged with relevant information for debugging and auditing purposes.

The logs are output to the console by default, but you can configure additional sinks and log destinations as needed.

## Testing

The API includes unit tests to verify the functionality of the eviction case filing service. The tests are located in the `src/EvictionCaseFilingAPI.Tests/` directory.

To run the tests, execute the following command: