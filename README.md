[![](https://img.shields.io/nuget/v/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
Serilog `LoggerConfiguration` extensions for wiring Application Insights sinks, levels, and telemetry behavior from application configuration.

## Installation

```bash
dotnet add package Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
```

## Usage

```csharp
using Soenneker.Extensions.LoggerConfiguration.ApplicationInsights;

builder.Services.AddApplicationInsightsTelemetry();

builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    loggerConfiguration.AddApplicationInsightsLogging(services, context.Configuration);
});
```

Enable the sink through application configuration:

```json
{
  "Azure": {
    "AppInsights": {
      "Enable": true
    }
  },
  "Log": {
    "Levels": {
      "Default": "Information"
    }
  }
}
```

When `Azure:AppInsights:Enable` is absent or `false`, the method returns without resolving services or changing the logger configuration. When enabled, it:

- Resolves `TelemetryConfiguration` from the supplied service provider.
- Adds an Application Insights sink using `TelemetryConverter.Traces`.
- Sets the sink's minimum level from `Log:Levels:Default`, then the legacy `Log:DefaultLogLevel`, then `Information`.
- Wraps telemetry writes in Serilog's asynchronous sink.

This extension does not call `AddApplicationInsightsTelemetry()`, configure an Application Insights connection string, or create `Log.Logger`. Register and configure Application Insights before the Serilog callback, then create/host the logger through the application's normal Serilog setup. Missing `TelemetryConfiguration` causes service resolution to throw when the feature is enabled.

The minimum level is read when the sink is added; changing configuration later does not update this sink automatically. Call the method once per `LoggerConfiguration`, because each call adds another sink and can duplicate telemetry.

Serilog's default async wrapper does not block producers when its buffer is full, so events can be dropped under sustained pressure. Application Insights telemetry can also leave the process; do not include credentials, tokens, or personal data in log properties unless collection and retention are explicitly approved.
