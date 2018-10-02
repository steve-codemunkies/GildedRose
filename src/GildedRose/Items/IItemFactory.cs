namespace GildedRose.Items
{
    public interface IItemFactory
    {
        IItem Build(string itemName, int sellin, int quality);
    }
}