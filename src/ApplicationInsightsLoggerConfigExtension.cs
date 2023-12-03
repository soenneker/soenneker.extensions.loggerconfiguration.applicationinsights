using System;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Soenneker.Utils.Logger;

namespace Soenneker.Extensions.LoggerConfiguration.ApplicationInsights;

/// <summary>
/// Serilog LoggerConfiguration extension methods related to Application Insights
/// </summary>
public static class ApplicationInsightsLoggerConfigExtension
{
    /// <summary>
    /// Adds the Application Insights sink (asynchronously) unless the config says that we shouldn't
    /// </summary>
    public static void AddApplicationInsightsLogging(this Serilog.LoggerConfiguration loggerConfiguration,
        IServiceProvider services, IConfigurationRoot configRoot)
    {
        var enabled = configRoot.GetValue<bool>("Azure:AppInsights:Enable");

        if (!enabled)
            return;

        LogEventLevel logEventLevel = LoggerUtil.GetLogEventLevelFromConfigRoot(configRoot);

        loggerConfiguration.WriteTo.Async(a => a.ApplicationInsights(
            services.GetRequiredService<TelemetryConfiguration>(),
            TelemetryConverter.Traces, logEventLevel));
    }
}