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

        Assert.Equal(expectedQuality, item.Quality);
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
}
