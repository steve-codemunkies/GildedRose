using GildedRoseKata;

namespace GildedRoseTests;

public class BackstagePassItemTest
{
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
    public void BackstagePassItemManagesQualityAndSellInCorrectly(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new BackstagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
