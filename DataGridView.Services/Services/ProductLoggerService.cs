using System.ComponentModel;
using System.Diagnostics;
using DataGridView.Models;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DataGridView.Services.Services
{
    /// <summary>
    /// Декоратор для логирования производительности методов ProductService
    /// Использует ILogger из Microsoft.Extensions.Logging
    /// </summary>
    public class ProductLoggerService : IProductService
    {
        private readonly IProductService mainService;
        private readonly ILogger<ProductLoggerService> logger;

        public ProductLoggerService(IProductService mainService, ILogger<ProductLoggerService> logger)
        {
            this.mainService = mainService;
            this.logger = logger;
        }

        public BindingList<Product> GetAll()
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                return mainService.GetAll();
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс",
                    nameof(GetAll),
                    stopwatch.ElapsedMilliseconds
                );
            }
        }

        public void Add(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                mainService.Add(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(Add),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }

        public void Update(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                mainService.Update(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(Update),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }

        public void Delete(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                mainService.Delete(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(Delete),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }
    }
}
