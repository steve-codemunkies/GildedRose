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

            if(_quality > 50)
            {
                _quality = 50;
            }
            else if(_sellIn<0)
            {
                _quality-=2;
            }
            else
            {
                _quality--;
            }

            if(_quality < 0)
            {
                _quality = 0;
            }
        }
    }
}