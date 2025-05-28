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

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                item.Quality = SulfurasItemQuality;
                continue;
            }
            
            item.SellIn = item.SellIn - 1;

            if (item.Name == "Aged Brie")
            {
                var increment = item.SellIn < 0 ? 2 : 1;

                item.Quality = Math.Min(item.Quality + increment, MaximumItemQuality);
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

                if (item.SellIn < 0)
                {
                    item.Quality = MinimumItemQuality;
                }
            }
            else
            {
                var decrement = item.SellIn < 0 ? 2 : 1;

                item.Quality = Math.Max(item.Quality - decrement, MinimumItemQuality);
            }
        }
    }
}
