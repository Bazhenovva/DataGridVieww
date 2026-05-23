using System.ComponentModel;
using System.Diagnostics;
using DataGridView.Models;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace DataGridView.Services.Services
{
    /// <summary>
    /// Декоратор для логирования производительности методов ProductService
    /// </summary>
    public class ProductLoggerService : IProductService
    {
        private readonly IProductService mainService;
        private readonly ILogger<ProductLoggerService> logger;

        /// <summary>
        /// Инициализация нового экземпляра с основным сервисом и логгером
        /// </summary>
        public ProductLoggerService(IProductService mainService, ILogger<ProductLoggerService> logger)
        {
            this.mainService = mainService;
            this.logger = logger;
        }

        /// <summary>
        /// Возврат всех товаров с логированием времени выполнения
        /// </summary>
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

        /// <summary>
        /// Добавление нового товара с логированием времени выполнения
        /// </summary>
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

        /// <summary>
        /// Обновление существующий товар с логированием времени выполнения
        /// </summary>
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

        /// <summary>
        /// Удаление товара с логированием времени выполнения
        /// </summary>
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
