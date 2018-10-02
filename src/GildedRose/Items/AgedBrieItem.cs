namespace GildedRose.Items
{
    public class AgedBrieItem : BaseItem
    {
        public AgedBrieItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
        }

        public override void AgeOneDay()
        {
            _sellIn--;
            _quality++;

            if(_quality>50)
            {
                _quality = 50;
            }
        }
    }
}