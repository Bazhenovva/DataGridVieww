using DataGridView.Services.Services;
using DataGridView.Storage.InMemory;
using DataGridView.WinForms.Forms;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataGridView.WinForms
{
    static internal class Program
    {
        [STAThread]
        private static void Main()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/product-.log", rollingInterval: RollingInterval.Day)
                .WriteTo.Seq(
                "http://localhost:5341",
                apiKey: "DeKeedfm9oE5YTPf4XVg",
                restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
                )
                .CreateLogger();

            var microsoftLogger = new SerilogLoggerFactory(logger)
                .CreateLogger<ProductLoggerService>();

            ApplicationConfiguration.Initialize();

            var storage = new InMemoryProductStorage();
            var productService = new ProductService(storage);

            var productLoggerService = new ProductLoggerService(productService, microsoftLogger);

            Application.Run(new ProductsForm(productLoggerService));
        }
    }
}
