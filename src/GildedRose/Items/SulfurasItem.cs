namespace GildedRose.Items
{
    public class SulfurasItem : BaseItem
    {
        public SulfurasItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
            if(_quality > QualityCeilingInclusive)
            {
                _quality = QualityCeilingInclusive;
            }
        }

        public override void AgeOneDay()
        {
            // Deliberately doing nothing
        }
    }
}