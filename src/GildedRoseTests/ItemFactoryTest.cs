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

            Assert.IsType<LegendaryItem>(item);
            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void TheItemFactoryQualityIncrementItemClassBuildsAQualityIncrementItem()
        {
            var expectedName = "Aged Brie";
            var expectedSellIn = 25;
            var expectedQuality = 25;

            var item = ItemFactory.QualityIncrementItem(expectedName, expectedQuality, expectedSellIn);

            Assert.IsType<QualityIncrementItem>(item);
            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
