using Serilog;

namespace WorldImporters.Configuration;

public static class LoggerConfigurationExtension
{
    public static IHostBuilder AddLogger(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
                        .ReadFrom
                        .Configuration(builder.Configuration)
                        .CreateLogger();

        return builder.Host.UseSerilog();
    }
}
