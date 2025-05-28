using GildedRoseKata;

namespace GildedRoseTests
{
    public class ItemFactoryTest
    {
        [Fact]
        public void TheItemFactoryLegendaryItemFunctionBuildsALegendaryItem()
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
        public void TheItemFactoryQualityIncrementItemFunctionBuildsAQualityIncrementItem()
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

        [Fact]
        public void TheItemFactoryBackstagePassItemFunctionBuildsABackstagePassItem()
        {
            var expectedName = "Backstage passes to a TAFKAL80ETC concert";
            var expectedSellIn = 25;
            var expectedQuality = 25;

            var item = ItemFactory.BackstagePassItem(expectedName, expectedQuality, expectedSellIn);

            Assert.IsType<BackstagePassItem>(item);
            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void TheItemFactoryConjuredItemFunctionBuildsAConjuredItem()
        {
            var expectedName = "Conjured Mana Cake";
            var expectedSellIn = 25;
            var expectedQuality = 25;

            var item = ItemFactory.ConjuredItem(expectedName, expectedQuality, expectedSellIn);

            Assert.IsType<ConjuredItem>(item);
            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void TheItemFactoryNormalItemFunctionBuildsAnItem()
        {
            var expectedName = "Normal Item";
            var expectedSellIn = 25;
            var expectedQuality = 25;

            var item = ItemFactory.NormalItem(expectedName, expectedQuality, expectedSellIn);

            Assert.IsType<Item>(item);
            Assert.Equal(expectedName, item.Name);
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
