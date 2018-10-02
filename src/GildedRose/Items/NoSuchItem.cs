namespace GildedRose.Items
{
    public class NoSuchItem : IItem
    {
        public void AgeOneDay()
        {
            // Deliberately do nothing...
        }

        public override string ToString()
        {
            return "NO SUCH ITEM";
        }
    }
}