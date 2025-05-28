namespace GildedRoseKata;

public class GildedRose(IList<Item> Items)
{
    public void UpdateQuality()
    {
        foreach (Item item in Items)
        {
            item.UpdateItemQuality();
        }
    }
}
