namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    private const int MinimumItemQuality = 0;

    public virtual void UpdateItemQuality()
    {
        SellIn = SellIn - 1;

        var decrement = SellIn < 0 ? 2 : 1;

        Quality = Math.Max(Quality - decrement, MinimumItemQuality);
    }
}
