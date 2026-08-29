[![](https://img.shields.io/nuget/v/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
Serilog LoggerConfiguration extension methods related to Application Insights.

## Installation

```bash
dotnet add package Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
```

## Quick start

```csharp
using Soenneker.Extensions.LoggerConfiguration.ApplicationInsights;

// Given an existing Serilog.LoggerConfiguration named loggerConfiguration:
loggerConfiguration.AddApplicationInsightsLogging(services, config);
```

## Common operations

- `AddApplicationInsightsLogging()` - Adds the Application Insights sink (asynchronously) unless the config says that we shouldn't.
