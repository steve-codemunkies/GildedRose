using FluentAssertions;
using Xunit;

namespace GildedRose.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void WhenISetupTheRequestedInventoryIAmAbleToGetTheExpectedOutput()
        {
            // Arrange
            IStockList stockList = new StockList();

            stockList.AddItem("Aged Brie", 1, 1);
            stockList.AddItem("Backstage passes", -1, 2);
            stockList.AddItem("Backstage passes", 9, 2);
            stockList.AddItem("Sulfuras", 2, 2);
            stockList.AddItem("Normal Item", -1, 55);
            stockList.AddItem("Normal Item", 2, 2);
            stockList.AddItem("INVALID ITEM", 2, 2);
            stockList.AddItem("Conjured", 2, 2);
            stockList.AddItem("Conjured", -1, 5);

            // Act
            var outputString = stockList.ToString();

            // Assert
            outputString.Should().Be("Aged Brie 1 1\r\nBackstage passes -1 2\r\nBackstage passes 9 2\r\nSulfuras 2 2\r\nNormal Item -1 55\r\nNormal Item 2 2\r\nNO SUCH ITEM\r\nConjured 2 2\r\nConjured -1 5\r\n");
        }

        [Fact]
        public void WhenISetupTheRequestedInventoryAndAgeItIAmAbleToGetTheExpectedOutput()
        {
            // Arrange
            IStockList stockList = new StockList();

            stockList.AddItem("Aged Brie", 1, 1);
            stockList.AddItem("Backstage passes", -1, 2);
            stockList.AddItem("Backstage passes", 9, 2);
            stockList.AddItem("Sulfuras", 2, 2);
            stockList.AddItem("Normal Item", -1, 55);
            stockList.AddItem("Normal Item", 2, 2);
            stockList.AddItem("INVALID ITEM", 2, 2);
            stockList.AddItem("Conjured", 2, 2);
            stockList.AddItem("Conjured", -1, 5);

            // Act
            stockList.AgeInventory();
            var outputString = stockList.ToString();

            // Assert
            outputString.Should().Be("Aged Brie 0 2\r\nBackstage passes -2 0\r\nBackstage passes 8 4\r\nSulfuras 2 2\r\nNormal Item -2 50\r\nNormal Item 1 1\r\nNO SUCH ITEM\r\nConjured 1 0\r\nConjured -2 1");
        }
    }
}