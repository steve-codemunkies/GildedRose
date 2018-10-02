namespace GildedRose.Items
{
    public class BackstagePassItem : BaseItem
    {
        public BackstagePassItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
        }

        public override void AgeOneDay()
        {
            _sellIn--;

            if(_sellIn > 10)
            {
                _quality++;
            }
            else if(_sellIn > 5 && _sellIn <= 10)
            {
                _quality+=2;
            }
            else if (_sellIn >= 0 && _sellIn <= 5)
            {
                _quality+=3;
            }
            else
            {
                _quality = QualityFloorInclusive;
            }

            if(_quality > QualityCeilingInclusive)
            {
                _quality = QualityCeilingInclusive;
            }
        }
    }
}