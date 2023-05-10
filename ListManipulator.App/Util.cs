using Microsoft.Extensions.Logging;

namespace ListManipulator.App
{
    public static class Util
    {
        public static ILogger<ListManRepository> CreateLogger()
        {
            using var loggerFactory = LoggerFactory.Create(b =>
            {
                b.AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("App.ListManipulator", LogLevel.Warning)
                    .AddConsole();
            });

            return loggerFactory.CreateLogger<ListManRepository>();
        }
    }
}