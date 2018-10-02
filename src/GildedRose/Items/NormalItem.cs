using System;

namespace GildedRose.Items
{
    public abstract class BaseItem : IItem
    {
        protected string _itemName;
        protected int _sellIn;
        protected int _quality;

        public BaseItem(string itemName, int sellIn, int quality)
        {
            if(quality < 0)
            {
                throw new ArgumentException("Cannot be negative", nameof(quality));
            }

            _itemName = itemName;
            _sellIn = sellIn;
            _quality = quality;
        }

        public abstract void AgeOneDay();

        public override string ToString()
        {
            return $"{_itemName} {_sellIn} {_quality}";
        }
    }

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