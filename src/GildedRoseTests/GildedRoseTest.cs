using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    private class TestItem : Item
    {
        public bool QualityUpdated { get; set; }

        public override void UpdateItemQuality()
        {
            QualityUpdated = true;
        }
    }

    [Fact]
    public void TheGildedRoseShouldCallUpdateItemQualityForEachItem()
    {
        List<Item> items = [new TestItem(), new TestItem(), new TestItem()];

        foreach (TestItem item in items)
        {
            Assert.False(item.QualityUpdated);
        }

        var app = new GildedRose(items);
        app.UpdateQuality();

        foreach (TestItem item in items)
        {
            Assert.True(item.QualityUpdated);
        }
    }
}
