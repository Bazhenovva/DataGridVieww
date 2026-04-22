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
        public void AddNewProductShouldGenerateIdAndAddToCollection()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();

            mockStorage.Setup(s => s.GetAll()).Returns(initialProducts);
            mockStorage.Setup(s => s.GetNextId()).Returns(5);

            var service = new ProductService(mockStorage.Object);
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
            service.Add(newProduct);

            // Assert
            newProduct.Id.Should().Be(5);
            mockStorage.Verify(s => s.Add(newProduct), Times.Once);
            mockStorage.Verify(s => s.GetNextId(), Times.Once);
        }

         /// <summary>
         /// Тест проверяет что метод GetAll возвращает коллекцию из хранилища
         /// </summary>
        [Fact]
        public void GetAllShouldReturnProductsFromStorage()
        {
            //Arrange
            var mock = new Mock<IProductStorage>();
            var initialProducts = new BindingList<Product>();

            mock.Setup(x=>x.GetAll()).Returns(initialProducts);

            var service = new ProductService(mock.Object);

            //Act
            var result = service.GetAll();

            //Assert
            mock.Verify(x=>x.GetAll(),Times.Once);
            result.Should().BeSameAs(initialProducts);
        }

        /// <summary>
        /// Тест проверяет что при обновлении существующего товара вызывается метод Update у хранилищ и обновляются все свойства товара в коллекции
        /// </summary>
        [Fact]
        public void UpdateShouldUpdateProductWhenItFound()
        {
            //Arrange
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

            mockStorage.Setup(x=>x.GetAll()).Returns(initialProducts);

            var service = new ProductService(mockStorage.Object);
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
            mockStorage.Setup(x => x.Update(updatedProduct));

            // act
            service.Update(updatedProduct);

            //assert
            mockStorage.Verify(x => x.Update(updatedProduct), Times.Once);

            var productInCollection = service.GetAll().First();
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
        public void UpdateShouldNotUpdateAnythingWhenProductNotFound()
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

            mockStorage.Setup(x => x.GetAll()).Returns(initialProducts);

            var service = new ProductService(mockStorage.Object);
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

            mockStorage.Setup(x => x.Update(nonExistentProduct));

            // Act
            service.Update(nonExistentProduct);

            // Assert
            mockStorage.Verify(x => x.Update(nonExistentProduct), Times.Once);

            var productInCollection = service.GetAll().First();
            productInCollection.ProductName.Should().Be("Гвозди");
            productInCollection.ProductSize.Should().Be(ProductSize.M6);
            productInCollection.Material.Should().Be(Material.Steel);
            productInCollection.Price.Should().Be(56);
            productInCollection.Quantity.Should().Be(90);
            productInCollection.MinQuantity.Should().Be(8);
        }


        /// <summary>
        ///  Тест проверяет удаление товара через вызов метода Delete у хранилища
        /// </summary>
        [Fact]
        public void DeleteProducts()
        {
            // arrange
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

            mockStorage.Setup(x=>x.GetAll()).Returns(initialProducts);

            var service = new ProductService(mockStorage.Object);
            var productDelete = existingProduct;

            //act
            service.Delete(productDelete);

            //assert
            mockStorage.Verify(x => x.Delete(productDelete), Times.Once);
        }

        /// <summary>
        /// Тест проверяет что конструктор вызывает метод GetAll у хранилища и сохраняет коллекцию
        /// </summary>
        [Fact] public void ConstructorShouldCallGetAllAndStoreCollection()
        {
            // Arrange
            var mockStorage = new Mock<IProductStorage>();
            var expectedProducts = new BindingList<Product>();

            mockStorage.Setup(x => x.GetAll()).Returns(expectedProducts);

            // Act
            var service = new ProductService(mockStorage.Object);

            // Assert
            mockStorage.Verify(x => x.GetAll(), Times.Once);
            service.GetAll().Should().BeSameAs(expectedProducts);
        }
    }

}
