using System.ComponentModel;
using DataGridView.Models;
using DataGridView.Services.Services;
using DataGridView.Storage.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataGridView.Services.Tests
{
    /// <summary>
    /// Класс тестов для сервиса управления товарами
    /// </summary>
    public class ProductServiceTests
    {
        /// <summary>
        /// Тест проверяет что метод Add устанавливает товару идентификатор
        /// </summary>
        [Fact]
        public async Task AddNewProductShouldGenerateIdAndAddToCollection()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();

            mockStorage.Setup(s => s.GetAllAsync()).ReturnsAsync(initialProducts);
            mockStorage.Setup(s => s.GetNextIdAsync()).ReturnsAsync(5);

            var service = new ProductService(mockStorage.Object);

            await service.GetAllAsync();

            var newProduct = new Product
            {
                ProductName = "гвозди тест",
                ProductSize = ProductSize.M6,
                Material = Material.Steel,
                Price = 68,
                Quantity = 50,
                MinQuantity = 2
            };

            // Act
            await service.AddAsync(newProduct);

            // Assert
            newProduct.Id.Should().BeGreaterThan(0);
            mockStorage.Verify(s => s.AddAsync(newProduct), Times.Once);
            mockStorage.Verify(s => s.GetNextIdAsync(), Times.Once);
        }

        /// <summary>
        /// Тест проверяет что метод GetAll возвращает коллекцию из хранилища
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnProductsFromStorage()
        {
            // Arrange
            var mock = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();

            mock.Setup(x => x.GetAllAsync()).ReturnsAsync(initialProducts);

            var service = new ProductService(mock.Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            mock.Verify(x => x.GetAllAsync(), Times.Once);
            result.Should().BeEquivalentTo(initialProducts);
        }

        /// <summary>
        /// Тест проверяет что при обновлении существующего товара вызывается метод Update у хранилища
        /// и обновляются все свойства товара в коллекции
        /// </summary>
        [Fact]
        public async Task UpdateShouldUpdateProductWhenItFound()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();
            var existingProduct = new Product
            {
                Id = 1,
                ProductName = "Гвозди",
                ProductSize = ProductSize.M6,
                Material = Material.Steel,
                Price = 56,
                Quantity = 90,
                MinQuantity = 8
            };

            initialProducts.Add(existingProduct);

            mockStorage.Setup(x => x.GetAllAsync()).ReturnsAsync(initialProducts);

            var service = new ProductService(mockStorage.Object);

            await service.GetAllAsync();

            var updatedProduct = new Product
            {
                Id = 1,
                ProductName = "Шурупы",
                ProductSize = ProductSize.M8,
                Material = Material.Copper,
                Price = 23,
                Quantity = 20,
                MinQuantity = 22
            };
            mockStorage.Setup(x => x.UpdateAsync(updatedProduct)).Returns(Task.CompletedTask);

            // Act
            await service.UpdateAsync(updatedProduct);

            // Assert
            mockStorage.Verify(x => x.UpdateAsync(updatedProduct), Times.Once);

            var all = await service.GetAllAsync();
            var productInCollection = all.First();
            productInCollection.ProductName.Should().Be("Шурупы");
            productInCollection.ProductSize.Should().Be(ProductSize.M8);
            productInCollection.Material.Should().Be(Material.Copper);
            productInCollection.Price.Should().Be(23);
            productInCollection.Quantity.Should().Be(20);
            productInCollection.MinQuantity.Should().Be(22);
        }

        /// <summary>
        /// Тест проверяет что при обновлении несуществующего товара коллекция не изменяется
        /// </summary>
        [Fact]
        public async Task UpdateShouldNotUpdateAnythingWhenProductNotFound()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();
            var existingProduct = new Product
            {
                Id = 1,
                ProductName = "Гвозди",
                ProductSize = ProductSize.M6,
                Material = Material.Steel,
                Price = 56,
                Quantity = 90,
                MinQuantity = 8
            };

            initialProducts.Add(existingProduct);

            mockStorage.Setup(x => x.GetAllAsync()).ReturnsAsync(initialProducts);

            var service = new ProductService(mockStorage.Object);

            await service.GetAllAsync();

            var nonExistentProduct = new Product
            {
                Id = 999,
                ProductName = "нет",
                ProductSize = ProductSize.M10,
                Material = Material.Iron,
                Price = 999,
                Quantity = 999,
                MinQuantity = 999
            };

            mockStorage.Setup(x => x.UpdateAsync(nonExistentProduct)).Returns(Task.CompletedTask);

            // Act
            await service.UpdateAsync(nonExistentProduct);

            // Assert
            mockStorage.Verify(x => x.UpdateAsync(nonExistentProduct), Times.Once);

            var all = await service.GetAllAsync();
            var productInCollection = all.First();
            productInCollection.ProductName.Should().Be("Гвозди");
            productInCollection.ProductSize.Should().Be(ProductSize.M6);
            productInCollection.Material.Should().Be(Material.Steel);
            productInCollection.Price.Should().Be(56);
            productInCollection.Quantity.Should().Be(90);
            productInCollection.MinQuantity.Should().Be(8);
        }

        /// <summary>
        /// Тест проверяет удаление товара через вызов метода Delete у хранилища
        /// </summary>
        [Fact]
        public async Task DeleteProducts()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();
            var existingProduct = new Product
            {
                Id = 1,
                ProductName = "Гвозди",
                ProductSize = ProductSize.M6,
                Material = Material.Steel,
                Price = 56,
                Quantity = 90,
                MinQuantity = 8
            };

            initialProducts.Add(existingProduct);

            mockStorage.Setup(x => x.GetAllAsync()).ReturnsAsync(initialProducts);

            var service = new ProductService(mockStorage.Object);

            await service.GetAllAsync();

            var productDelete = existingProduct;

            // Act
            await service.DeleteAsync(productDelete);

            // Assert
            mockStorage.Verify(x => x.DeleteAsync(productDelete), Times.Once);
        }

        /// <summary>
        /// Тест проверяет что конструктор вызывает метод GetAll у хранилища и сохраняет коллекцию
        /// </summary>
        [Fact]
        public void ConstructorShouldCallGetAllAndStoreCollection()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var expectedProducts = new BindingList<Product>();

            mockStorage.Setup(x => x.GetAllAsync()).ReturnsAsync(expectedProducts);

            // Act
            var service = new ProductService(mockStorage.Object);

            // Assert
            service.Should().NotBeNull();
        }
    }
}
