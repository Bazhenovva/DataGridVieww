using DataGridView.Models;
using FluentAssertions;
using Xunit;

namespace DataGridView.Storage.InMemory.Tests
{
     /// <summary>
     /// Класс тестов для InMemoryProductStorage
     /// </summary>
    public class InMemoryStorageTests
    {
        /// <summary>
        /// Тест проверяет что конструктор создает четыре товара с идентификаторами 1,2,3,4
        /// </summary>
        [Fact]
        public void ConstructorShouldSetCorrectIds()
        {
            // arrange и act
            var storage = new InMemoryProductStorage();

            // assert
            storage.GetAll().Select(p => p.Id).Should().Equal(1, 2, 3, 4);
        }

        /// <summary>
        /// Тест проверяет что метод GetAll возвращает ту же коллекцию
        /// </summary>
        [Fact]
        public void GetAllShouldReturnProducts()
        {
            // arrange
            var storage = new InMemoryProductStorage();
            var expected = storage.GetAll();

            // act
            var result = storage.GetAll();

            // assert
            result.Should().BeSameAs(expected);
        }

        /// <summary>
        /// Тест проверяет что метод Add добавляет товар в коллекцию
        /// </summary>
        [Fact]
        public void AddShouldAddProductToCollection()
        {
             // Arrange
             var storage = new InMemoryProductStorage();
             var newProduct = new Product
             {
                 ProductName = "гвозди",
                 ProductSize = ProductSize.M6,
                 Material = Material.Steel,
                 Price = 23,
                 Quantity = 34,
                 MinQuantity = 1
                };

             // Act
             storage.Add(newProduct);

             // Assert
             storage.GetAll().Should().Contain(newProduct);

        }

        /// <summary>
        /// Тест проверяет что при обновлении существующего товара он заменяется новым
        /// </summary>
        [Fact]
        public void UpdateShouldReplaceExistingProduct()
        {
            // Arrange
            var storage = new InMemoryProductStorage();
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

            // Act
            storage.Update(updatedProduct);

            // Assert
            var productInStorage = storage.GetAll().First(p => p.Id == 1);
            productInStorage.ProductName.Should().Be("Шурупы");
            productInStorage.ProductSize.Should().Be(ProductSize.M8);
            productInStorage.Material.Should().Be(Material.Copper);
            productInStorage.Price.Should().Be(23);
            productInStorage.Quantity.Should().Be(20);
            productInStorage.MinQuantity.Should().Be(22);
        }

        /// <summary>
        /// Тест проверяет что при обновлении несуществующего товара коллекция не изменяется
        /// </summary>
        [Fact]
        public void UpdateShouldNotUpdateAnythingWhenProductNotFound()
        {
            // Arrange
            var storage = new InMemoryProductStorage();
            var originalProduct = storage.GetAll().First(p => p.Id == 1);
            var nonExistentProduct = new Product
            {
                Id = 999,
                ProductName = "Несуществующий",
                ProductSize = ProductSize.M10,
                Material = Material.Iron,
                Price = 999,
                Quantity = 999,
                MinQuantity = 999
            };

            // Act
            storage.Update(nonExistentProduct);

            // Assert
            var productInStorage = storage.GetAll().First(p => p.Id == 1);
            productInStorage.ProductName.Should().Be(originalProduct.ProductName);
            productInStorage.ProductSize.Should().Be(originalProduct.ProductSize);
            productInStorage.Material.Should().Be(originalProduct.Material);
            productInStorage.Price.Should().Be(originalProduct.Price);
            productInStorage.Quantity.Should().Be(originalProduct.Quantity);
            productInStorage.MinQuantity.Should().Be(originalProduct.MinQuantity);
        }

        /// <summary>
        /// Тест проверяет что метод Delete удаляет товар из коллекции
        /// </summary>
        [Fact]
        public void DeleteShouldRemoveProduct()
        {
            // Arrange
            var storage = new InMemoryProductStorage();
            var product = storage.GetAll().First();

            // Act
            storage.Delete(product);

            // Assert
            storage.GetAll().Count.Should().Be(3);
        }

        /// <summary>
        /// Тест проверяет что метод GetNextId возвращает увеличивающиеся идентификаторы
        /// </summary>
        [Fact]
        public void GetNextIdShouldReturnIncreasingIds()
        {
            // Arrange
            var storage = new InMemoryProductStorage();

            // Act
            var firstId = storage.GetNextId();
            var secondId = storage.GetNextId();

            // Assert
            secondId.Should().Be(firstId + 1);
        }

    }

}
