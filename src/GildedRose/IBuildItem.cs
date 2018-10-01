namespace GildedRose
{
    public interface IBuildItem
    {
        bool CanBuildItem(string itemName);
        IItem BuildItem(string itemName, int sellIn, int quality);
    }
}