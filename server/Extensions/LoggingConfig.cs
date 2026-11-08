using Serilog;


namespace server.Extensions
{
    public static class LoggingConfig
    {

        public static void Configure() {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

            if (!Directory.Exists(logPath)){
                Directory.CreateDirectory(logPath);
             }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(
                path:Path.Combine(logPath,"error-log-.txt"),
                rollingInterval:RollingInterval.Day,
                outputTemplate:"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
        }

    }
}
