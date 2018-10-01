namespace GildedRose
{
    public interface IStockList
    {
        void AddItem(string itemName, int sellIn, int quality);
        void AgeInventory();
    }
}