# NWUTechTrends Management System

## Overview

The NWUTechTrends Management System is designed to track and manage the time and cost savings associated with automations created by NWU Tech Trends. This is achieved through a RESTful API that connects to a SQL Server database to record and retrieve telemetry data.

### Project Description

NWUTechTrends requires a solution to identify how much time is saved each time an automation runs. This time savings is associated with a cost and is grouped by project and client. The telemetry data is recorded whenever an automation is executed, and can be managed through a REST API.

The RESTful API architecture enables efficient data transport between systems, environments, and applications. This API will support CRUD operations and include methods for calculating time and cost savings based on telemetry data.

## Prerequisites

Before starting the project, ensure the following:

- Access to the NWU Azure tenant by logging into the Azure Portal with your MS Fed account: `12345678@student365.msfed.nwu.ac.za`.
- Creation of a resource group for logically grouping your work.
- Installation of Visual Studio 2022 Community edition and .NET 8.

## Requirements

### Functional Requirements

- Create a CRUD RESTful API to connect to a database storing telemetry data.
- Implement at least one GET, POST, PATCH, and DELETE method per resource.

### Non-Functional Requirements

- Follow good software practices and ensure the API is secure and well-documented.

## Project Setup

### 1. GitHub Administration

- **Create and Configure GitHub Repository**: Create a repository named `CMPG 323 Project 2 - <Your Student Number>`.
- **Create README.md**: Describe your project and how stakeholders can use the report.

### 2. Prepare the Data Source

- **Configure the Database**: Set up a SQL Server with a secure service account username and password.
- **Run SQL Script**: Execute the provided SQL script to create the necessary tables.

### 3. Project Setup

- **Clone Repository**: Clone your GitHub repository to your local machine.
- **Create .NET Web API Project**: Initialize a new .NET Web API project.
- **Connect API to Data Source**: Scaffold the database into the project and configure the connection.
- **Apply Dependency Injection**: Add the scaffolded `DbContext` to the `Startup.cs`.

### 4. Functionality

- **GET All Telemetry**: Retrieve all telemetry entries from the database.
- **GET Telemetry by ID**: Retrieve a single telemetry entry based on the ID.
- **POST Create Telemetry**: Add a new telemetry entry to the database.
- **PATCH Update Telemetry**: Update an existing telemetry entry.
- **DELETE Telemetry**: Remove a telemetry entry from the database.
- **Check Telemetry Existence**: Implement a private method to check if a telemetry entry exists before editing or deleting.
- **Get Savings by Project**: Query telemetry per project and calculate cumulative time and cost saved based on Project ID and date range.
- **Get Savings by Client**: Query telemetry per client and calculate cumulative time and cost saved based on Client ID and date range.

### 5. Project Close-out

- **Security**: Set up authentication to restrict API access and ensure no credentials are stored on GitHub.
- **Web API Cloud Hosting**: Create an API service on Azure, connect it to an F1 tier service plan, and publish the API.
- **Documentation**: Update the `README.md` file with usage instructions, list all endpoints, and create a reference list document in Harvard style.

## API Endpoints

### Telemetry Endpoints

- **GET** `/api/jobtelemetries` - Retrieve all telemetry entries.
- **GET** `/api/jobtelemetries/{id}` - Retrieve telemetry entry by ID.
- **POST** `/api/jobtelemetries` - Create a new telemetry entry.
- **PATCH** `/api/jobtelemetries/{id}` - Update an existing telemetry entry.
- **DELETE** `/api/jobtelemetries/{id}` - Delete a telemetry entry.

### Savings Endpoints

- **GET** `/api/jobtelemetries/savings/project` - Calculate time and cost savings per project.
- **GET** `/api/jobtelemetries/savings/client` - Calculate time and cost savings per client.

## References

- [Microsoft Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core RESTful API Documentation](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0)
- [Azure Hosting Documentation](https://docs.microsoft.com/en-us/azure/app-service/)




