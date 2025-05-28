using static GildedRoseKata.Item;

namespace GildedRoseKata
{
    public class ConjuredItem : Item
    {
        private const int MinimumItemQuality = 0;

        public override void UpdateItemQuality()
        {
            SellIn = SellIn - 1;

            var decrement = SellIn < 0 ? 4 : 2;

            Quality = Math.Max(Quality - decrement, MinimumItemQuality);
        }
    }
}