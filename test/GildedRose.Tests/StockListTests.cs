using AutoFixture;
using FluentAssertions;
using Moq;
using Xunit;

namespace GildedRose.Tests
{
    public class StockListTests
    {
        public Fixture AutoFixture {get;set;}

        public StockListTests()
        {
            AutoFixture = new Fixture();
        }

        [Fact]
        public void WhenIAddAnItemThatAFactoryIsAvailableForThatItemIsReturned()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = AutoFixture.Create<int>();

            var itemMock = new Mock<IItem>();

            var itemFactoryMock = new Mock<IBuildItem>();
            itemFactoryMock.Setup(fac => fac.CanBuildItem(itemName)).Returns(true);
            itemFactoryMock.Setup(fac => fac.BuildItem(itemName, sellIn, quality)).Returns(itemMock.Object);

            IStockList subject = new StockList(new []{itemFactoryMock.Object});

            // Act
            var result = subject.AddItem(itemName, sellIn, quality);

            // Assert
            result.Should().Be(itemMock.Object);
        }
    }
}