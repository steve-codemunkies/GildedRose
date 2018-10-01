using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class StockList : IStockList
    {
        private IEnumerable<IBuildItem> _buildItems;

        public StockList()
        {
        }

        public StockList(IEnumerable<IBuildItem> buildItems)
        {
            _buildItems = buildItems;
        }

        public IItem AddItem(string itemName, int sellIn, int quality)
        {
            foreach(var factory in _buildItems)
            {
                if(factory.CanBuildItem(itemName))
                {
                    return factory.BuildItem(itemName, sellIn, quality);
                }
            }

            return null;
        }

        public void AgeInventory()
        {
            throw new System.NotImplementedException();
        }
    }
}