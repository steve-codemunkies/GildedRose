namespace GildedRoseKata;

public class LegendaryItem : Item
{
    private const int ExpectedQuality = 80;

    public override void UpdateItemQuality()
    {
        Quality = ExpectedQuality;
    }
}
