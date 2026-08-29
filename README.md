[![](https://img.shields.io/nuget/v/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.loggerconfiguration.applicationinsights.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.loggerconfiguration.applicationinsights/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.loggerconfiguration.applicationinsights/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
Conditionally adds an asynchronous Serilog Application Insights trace sink from application configuration.

## Installation

```bash
dotnet add package Soenneker.Extensions.LoggerConfiguration.ApplicationInsights
```

## Usage

```csharp
using Soenneker.Extensions.LoggerConfiguration.ApplicationInsights;

loggerConfiguration.AddApplicationInsightsLogging(serviceProvider, configuration);
```

The sink is added only when `Azure:AppInsights:Enable` is `true`. It resolves `TelemetryConfiguration` from the supplied service provider, uses `TelemetryConverter.Traces`, and wraps the sink with Serilog's async sink.

The minimum level comes from the shared logging configuration extension (`GetLogEventLevel()`). When disabled, the method makes no change. When enabled, `TelemetryConfiguration` must already be registered or service resolution throws.
