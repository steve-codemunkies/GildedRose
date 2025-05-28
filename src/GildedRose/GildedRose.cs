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
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }
            
            item.SellIn = item.SellIn - 1;

            if (item.Name == "Aged Brie")
            {
                item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);

                if (item.SellIn < 11)
                {
                    item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                }

                if (item.SellIn < 6)
                {
                    item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                }
            }
            else
            {
                item.Quality = Math.Max(item.Quality - 1, MinimumItemQuality);
            }

            
            if (item.Name == "Aged Brie")
            {
                if (item.SellIn < 0)
                {
                    item.Quality = Math.Min(item.Quality + 1, MaximumItemQuality);
                }
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.SellIn < 0)
                {
                    item.Quality = MinimumItemQuality;
                }
            }
            else
            {
                if (item.SellIn < 0)
                {
                    item.Quality = Math.Max(item.Quality - 1, MinimumItemQuality);
                }
            }
        }
    }
}
