namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            bool isAgedBrie = item.Name == "Aged Brie";
            bool isBackstagePass = item.Name == "Backstage passes to a TAFKAL80ETC concert";

            if (isAgedBrie && item.Quality < 50)
            {
                item.Quality++;

            }
            else if (isBackstagePass)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;

                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
            else
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                if (isAgedBrie)
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
                else
                {
                    if (isBackstagePass)
                    {
                        item.Quality = 0;
                    }
                    else
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality--;
                        }
                    }
                }
            }
        }
    }
}
