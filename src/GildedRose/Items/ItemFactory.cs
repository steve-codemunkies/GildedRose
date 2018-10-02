namespace GildedRose.Items
{
    public class ItemFactory : IItemFactory
    {
        public IItem Build(string itemName, int sellin, int quality)
        {
            switch (itemName.ToUpperInvariant())
            {
                case "AGED BRIE":
                    return new AgedBrieItem(itemName, sellin, quality);    
                case "NORMAL ITEM":
                    return new NormalItem(itemName, sellin, quality);
                case "SULFURAS":
                    return new SulfurasItem(itemName, sellin, quality);
                case "BACKSTAGE PASSES":
                    return new BackstagePassItem(itemName, sellin, quality);
                case "CONJURED":
                    return new ConjuredItem(itemName, sellin, quality);
                default:
                    return new NoSuchItem();
            }
        }
    }
}