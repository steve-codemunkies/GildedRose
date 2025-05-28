namespace GildedRoseKata
{
    public class BackstagePassItem : Item
    {
        private const int MinimumItemQuality = 0;
        private const int MaximumItemQuality = 50;

        public override void UpdateItemQuality()
        {
            SellIn = SellIn - 1;

            Quality = SellIn switch
            {
                < 0 => MinimumItemQuality,
                < 6 => Math.Min(Quality + 3, MaximumItemQuality),
                < 11 => Math.Min(Quality + 2, MaximumItemQuality),
                _ => Math.Min(Quality + 1, MaximumItemQuality),
            };
        }
    }
}