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
        /// Асинхронный возврат всех товаров с логированием времени выполнения
        /// </summary>
        public async Task<BindingList<Product>> GetAllAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                return await mainService.GetAllAsync();
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс",
                    nameof(GetAllAsync),
                    stopwatch.ElapsedMilliseconds
                );
            }
        }

        /// <summary>
        /// Асинхронное добавление нового товара с логированием времени выполнения
        /// </summary>
        public async Task AddAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await mainService.AddAsync(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(AddAsync),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }

        /// <summary>
        /// Асинхронное обновление существующего товара с логированием времени выполнения
        /// </summary>
        public async Task UpdateAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await mainService.UpdateAsync(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(UpdateAsync),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }

        /// <summary>
        /// Асинхронное удаление товара с логированием времени выполнения
        /// </summary>
        public async Task DeleteAsync(Product product)
        {
            var stopwatch = Stopwatch.StartNew();
            try
            {
                await mainService.DeleteAsync(product);
            }
            finally
            {
                stopwatch.Stop();
                logger.LogInformation(
                    "Производительность: метод {MethodName} выполнен за {ElapsedMilliseconds} мс. Товар: {ProductName}",
                    nameof(DeleteAsync),
                    stopwatch.ElapsedMilliseconds,
                    product.ProductName
                );
            }
        }
    }
}
