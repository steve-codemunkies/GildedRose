using GildedRoseKata;

namespace GildedRoseTests;

public class ItemTest
{
    private static readonly Random _random = new Random();

    [Theory]
    [InlineData(10, 20, 9, 19)]
    [InlineData(10, 1, 9, 0)]
    [InlineData(10, 0, 9, 0)]
    [InlineData(1, 10, 0, 9)]
    [InlineData(0, 9, -1, 7)]
    [InlineData(-4, 1, -5, 0)]
    public void NormalItemDecreasesSellInAndQuality(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item { Name = "Normal Item", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(20, 10, 19, 11)]
    [InlineData(20, 49, 19, 50)]
    [InlineData(20, 50, 19, 50)]
    [InlineData(11, 10, 10, 12)]
    [InlineData(11, 48, 10, 50)]
    [InlineData(11, 49, 10, 50)]
    [InlineData(11, 50, 10, 50)]
    [InlineData(6, 10, 5, 13)]
    [InlineData(6, 47, 5, 50)]
    [InlineData(6, 48, 5, 50)]
    [InlineData(6, 49, 5, 50)]
    [InlineData(6, 50, 5, 50)]
    [InlineData(1, 10, 0, 13)]
    [InlineData(1, 47, 0, 50)]
    [InlineData(1, 48, 0, 50)]
    [InlineData(1, 49, 0, 50)]
    [InlineData(1, 50, 0, 50)]
    [InlineData(0, 50, -1, 0)]
    [InlineData(-5, 0, -6, 0)]
    [InlineData(-5, 50, -6, 0)]
    public void BackstagePassesIncreasesQualityAndDecreasesSellIn(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

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
        var item = new Item { Name = "Conjured Mana Cake", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
