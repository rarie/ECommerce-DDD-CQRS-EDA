# ECommerce-DDD-CQRS-EDA

## Description

A study project for:

- Domain-Driven Design
- Event-Driven Architecture
- Command Query Responsibility Segregation
- .NET Core

## Table of Contents

- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)

## Requirements

1. .NET Core
2. Entity Framework Core
3. Docker (for RabbitMQ)

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/rarie/ECommerce-DDD-CQRS-EDA.git
   ```
2. Navigate to the project directory:
   ```bash
   cd repository
   ```
3. Install dependencies:
   ```bash
   dotnet restore
   ```
4. Run database migration:
   ```bash
   dotnet ef database update
   ```

## Usage

```bash
dotnet run
```
