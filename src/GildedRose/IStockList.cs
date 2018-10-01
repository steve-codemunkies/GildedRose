namespace GildedRose
{
    public interface IStockList
    {
        IItem AddItem(string itemName, int sellIn, int quality);
        void AgeInventory();
    }
}