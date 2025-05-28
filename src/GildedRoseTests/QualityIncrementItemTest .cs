using GildedRoseKata;

namespace GildedRoseTests;

public class QualityIncrementItemTest
{
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
    public void QualityIncrementItemsIncreasQualityWhileDecreasingSellIn(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
    {
        var item = new QualityIncrementItem { Name = "Aged Brie", SellIn = initialSellIn, Quality = initialQuality };

        item.UpdateItemQuality();

        Assert.Equal(expectedSellIn, item.SellIn);
        Assert.Equal(expectedQuality, item.Quality);
    }
}
