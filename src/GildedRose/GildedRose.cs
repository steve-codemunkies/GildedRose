namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    private const int MinimumItemQuality = 0;
    private const int MaximumItemQuality = 50;
    private const int SulfurasItemQuality = 80;

    public enum ItemType
    {
        NormalItem,
        QualityIncrementItem,
        BackstagePasses,
        LegendaryItem
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            var itemType = GetItemType(item);

            if (itemType == ItemType.LegendaryItem)
            {
                item.Quality = SulfurasItemQuality;
                continue;
            }
            
            item.SellIn = item.SellIn - 1;

            if (itemType == ItemType.QualityIncrementItem)
            {
                var increment = item.SellIn < 0 ? 2 : 1;

                item.Quality = Math.Min(item.Quality + increment, MaximumItemQuality);
            }
            else if (itemType == ItemType.BackstagePasses)
            {
                item.Quality = item.SellIn switch
                {
                    < 0 => MinimumItemQuality,
                    < 6 => Math.Min(item.Quality + 3, MaximumItemQuality),
                    < 11 => Math.Min(item.Quality + 2, MaximumItemQuality),
                    _ => Math.Min(item.Quality + 1, MaximumItemQuality),
                };
            }
            else
            {
                var decrement = item.SellIn < 0 ? 2 : 1;

                item.Quality = Math.Max(item.Quality - decrement, MinimumItemQuality);
            }
        }
    }

    private ItemType GetItemType(Item item)
    {
        return item.Name switch
        {
            "Sulfuras, Hand of Ragnaros" => ItemType.LegendaryItem,
            "Aged Brie" => ItemType.QualityIncrementItem,
            "Backstage passes to a TAFKAL80ETC concert" => ItemType.BackstagePasses,
            _ => ItemType.NormalItem
        };
    }
}
