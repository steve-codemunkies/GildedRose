
using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemFactoryTest
    {
        [Fact]
        public void TheItemFactoryLegendaryItemClassBuildsALegendaryItem()
        {
            var expectedName = "Sulfuras, Hand of Ragnaros";
            var expectedSellIn = 0;
            var expectedQuality = 80;

            var item = ItemFactory.LegendaryItem(expectedName, expectedQuality, expectedSellIn);

            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }

    internal class ItemFactory
    {
        internal static LegendaryItem LegendaryItem(string expectedName, int expectedQuality, int expectedSellIn)
        {
            throw new NotImplementedException();
        }
    }

    internal class LegendaryItem : Item
    {
    }
}
