using GildedRoseKata;

namespace GildedRoseTests
{
    public class LegendaryItemTest
    {
        private static readonly Random _random = new Random();

        [Fact]
        public void LegendaryItemsHaveQuality80AndSameSellinAfterUpdate()
        {
            var expectedName = "Test name";
            var expectedSellIn = _random.Next(1, 100);
            var quality = _random.Next(1, 100);

            var item = new LegendaryItem { Name = expectedName, Quality = quality, SellIn = expectedSellIn };

            item.UpdateItemQuality();

            Assert.Equal(expectedName, item.Name);
            Assert.Equal(80, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
