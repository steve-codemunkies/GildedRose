using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private static readonly Random _random = new Random();

    [Fact]
    public void SulfurasIsALegendaryItemAndNeverChanges()
    {
        var expectedSellIn = _random.Next(1, 100);
        var expectedQuality = _random.Next(1, 100);

        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = expectedQuality, SellIn = expectedSellIn };

        var app = new GildedRose([item]);
        app.UpdateQuality();

        Assert.Equal(80, item.Quality);
        Assert.Equal(expectedSellIn, item.SellIn);
    }

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

        var app = new GildedRose([item]);
        app.UpdateQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(10, 20, 9, 21)]
    [InlineData(10, 49, 9, 50)]
    [InlineData(10, 50, 9, 50)]
    [InlineData(0, 20, -1, 22)]
    [InlineData(0, 48, -1, 50)]
    [InlineData(0, 49, -1, 50)]
    [InlineData(0, 50, -1, 50)]
    [InlineData(-5, 20, -6, 22)]
    [InlineData(-5, 48, -6, 50)]
    [InlineData(-5, 49, -6, 50)]
    [InlineData(-5, 50, -6, 50)]
    public void AgedBrieIncreasesQualityAndDecreasesSellIn(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new Item { Name = "Aged Brie", SellIn = initialSellIn, Quality = initialQuality };

        var app = new GildedRose([item]);
        app.UpdateQuality();

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

        var app = new GildedRose([item]);
        app.UpdateQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
