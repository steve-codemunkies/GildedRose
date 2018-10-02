using System;

namespace GildedRose.Items
{
    public abstract class BaseItem : IItem
    {
        public const int QualityFloorInclusive = 0;
        public const int QualityCeilingInclusive = 50;

        protected string _itemName;
        protected int _sellIn;
        protected int _quality;

        public BaseItem(string itemName, int sellIn, int quality)
        {
            if(quality < QualityFloorInclusive)
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
}