namespace GildedRose.Items
{
    public class SulfurasItem : BaseItem
    {
        public SulfurasItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
            if(_quality>50)
            {
                _quality = 50;
            }
        }

        public override void AgeOneDay()
        {
            // Deliberately doing nothing
        }
    }
}