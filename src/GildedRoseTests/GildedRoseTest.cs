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
}
