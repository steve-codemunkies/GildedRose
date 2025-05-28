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

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                        }
                    }
                    break;
                default:
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = Math.Max(item.Quality - 1, MinimumItemQuality);
                    }
                    break;
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = Math.Max(item.Quality - 1, MinimumItemQuality);
                        }
                    }
                    else
                    {
                        item.Quality = MinimumItemQuality;
                    }
                }
                else
                {
                    item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                }
            }
        }
    }
}
