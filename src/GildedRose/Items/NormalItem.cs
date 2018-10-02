using System;

namespace GildedRose.Items
{
    public class NormalItem : IItem
    {
        private string _itemName;
        private int _sellIn;
        private int _quality;

        public NormalItem(string itemName, int sellIn, int quality)
        {
            if(quality < 0)
            {
                throw new ArgumentException("Cannot be negative", nameof(quality));
            }

            _itemName = itemName;
            _sellIn = sellIn;
            _quality = quality;
        }

        public void AgeOneDay()
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

        public override string ToString()
        {
            return $"{_itemName} {_sellIn} {_quality}";
        }
    }
}