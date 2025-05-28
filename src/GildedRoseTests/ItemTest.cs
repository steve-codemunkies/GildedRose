using GildedRoseKata;

namespace GildedRoseTests;

public class ItemTest
{
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
}
