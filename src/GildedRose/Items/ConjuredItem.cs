namespace GildedRose.Items
{
    public class ConjuredItem : BaseItem
    {
        public ConjuredItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
        }

        public override void AgeOneDay()
        {
            _sellIn--;

            if(_quality > QualityCeilingInclusive)
            {
                _quality = QualityCeilingInclusive;
            }
            else if(_sellIn<0)
            {
                _quality-=4;
            }
            else
            {
                _quality-=2;
            }

            if(_quality < QualityFloorInclusive)
            {
                _quality = QualityFloorInclusive;
            }
        }
    }
}