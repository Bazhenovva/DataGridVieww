using DataGridView.Services.Services;
using DataGridView.Storage.MsSql;
using DataGridView.WinForms.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace DataGridView.WinForms
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    static internal class Program
    {
        /// <summary>
        /// Главный метод приложения
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.Seq(
                    "http://localhost:5341",
                    apiKey: "DeKeedfm9oE5YTPf4XVg",
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
                )
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var microsoftLogger = new SerilogLoggerFactory(logger)
                .CreateLogger<ProductLoggerService>();

            ApplicationConfiguration.Initialize();

            var context = new MsSqlProductContext();
            var storage = new MsSqlProductStorage(context);

            var productService = new ProductService(storage);
            var productLoggerService = new ProductLoggerService(productService, microsoftLogger);

            Application.Run(new ProductsForm(productLoggerService));
        }
    }
}
