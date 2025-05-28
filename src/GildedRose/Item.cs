namespace GildedRoseKata;

public class Item
{
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }

    private const int MinimumItemQuality = 0;
    private const int MaximumItemQuality = 50;

    public enum ItemType
    {
        NormalItem,
        BackstagePasses,
        ConjuredItem
    }

    public virtual void UpdateItemQuality()
    {
        var itemType = GetItemType();

        SellIn = SellIn - 1;

        switch (itemType)
        {
            case ItemType.BackstagePasses:
                Quality = SellIn switch
                {
                    < 0 => MinimumItemQuality,
                    < 6 => Math.Min(Quality + 3, MaximumItemQuality),
                    < 11 => Math.Min(Quality + 2, MaximumItemQuality),
                    _ => Math.Min(Quality + 1, MaximumItemQuality),
                };
                break;

            case ItemType.ConjuredItem:
                var decrement = SellIn < 0 ? 4 : 2;

                Quality = Math.Max(Quality - decrement, MinimumItemQuality);
                break;

            case ItemType.NormalItem:
            default:
                decrement = SellIn < 0 ? 2 : 1;

                Quality = Math.Max(Quality - decrement, MinimumItemQuality);
                break;
        }

        return;
    }

    private ItemType GetItemType()
    {
        return Name switch
        {
            "Backstage passes to a TAFKAL80ETC concert" => ItemType.BackstagePasses,
            "Conjured Mana Cake" => ItemType.ConjuredItem,
            _ => ItemType.NormalItem
        };
    }

}
