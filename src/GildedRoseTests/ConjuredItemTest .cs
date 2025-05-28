using GildedRoseKata;

namespace GildedRoseTests;

public class ConjuredItemTest
{
    [Theory]
    [InlineData(10, 20, 9, 18)]
    [InlineData(10, 2, 9, 0)]
    [InlineData(10, 1, 9, 0)]
    [InlineData(10, 0, 9, 0)]
    [InlineData(1, 10, 0, 8)]
    [InlineData(0, 9, -1, 5)]
    [InlineData(-4, 3, -5, 0)]
    [InlineData(-4, 2, -5, 0)]
    [InlineData(-4, 1, -5, 0)]
    [InlineData(-4, 0, -5, 0)]
    public void ConjuredItemsDecreasesQualityAtDoubleSpeedAndSellInAtNormalSpeed(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new ConjuredItem { Name = "Conjured Mana Cake", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
