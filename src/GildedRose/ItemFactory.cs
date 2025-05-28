namespace GildedRoseKata;

public class ItemFactory
{
    public static LegendaryItem LegendaryItem(string name, int quality, int sellIn)
    {
        return new LegendaryItem { Name = name, Quality = quality, SellIn = sellIn };
    }
}
