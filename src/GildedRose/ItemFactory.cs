
using System.Xml.Linq;

namespace GildedRoseKata;

public class ItemFactory
{
    public static LegendaryItem LegendaryItem(string name, int quality, int sellIn)
    {
        return new LegendaryItem { Name = name, Quality = quality, SellIn = sellIn };
    }

    public static QualityIncrementItem QualityIncrementItem(string name, int quality, int sellIn)
    {
        return new QualityIncrementItem { Name = name, Quality = quality, SellIn = sellIn };
    }

    public static BackstagePassItem BackstagePassItem(string name, int quality, int sellIn)
    {
        return new BackstagePassItem { Name = name, Quality = quality, SellIn = sellIn };
    }

    public static ConjuredItem ConjuredItem(string name, int quality, int sellIn)
    {
        return new ConjuredItem { Name = name, Quality = quality, SellIn = sellIn };
    }
}
