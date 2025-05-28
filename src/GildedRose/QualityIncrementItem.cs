using static GildedRoseKata.Item;

namespace GildedRoseKata
{
    public class QualityIncrementItem : Item
    {
        private const int MinimumItemQuality = 0;
        private const int MaximumItemQuality = 50;

        public override void UpdateItemQuality()
        {
            SellIn = SellIn - 1;

            var increment = SellIn < 0 ? 2 : 1;

            Quality = Math.Min(Quality + increment, MaximumItemQuality);
        }
    }
}