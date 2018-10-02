namespace GildedRose.Items
{

    public class NormalItem : BaseItem
    {
        public NormalItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
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
                _quality-=2;
            }
            else
            {
                _quality--;
            }

            if(_quality < QualityFloorInclusive)
            {
                _quality = QualityFloorInclusive;
            }
        }
    }
}