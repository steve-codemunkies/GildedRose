namespace GildedRoseKata;

public class Program
{
    private const int DefaultDays = 1;
    private const int ExclusiveMinimumDays = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        List<Item> Items =
        [
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            ItemFactory.QualityIncrementItem("Aged Brie", 0, 2),
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            ItemFactory.LegendaryItem("Sulfuras, Hand of Ragnaros", 80, 0),
            ItemFactory.LegendaryItem("Sulfuras, Hand of Ragnaros", 80, -1),
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },

            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },

            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet

            new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
        ];

        var app = new GildedRose(Items);

        var days = DefaultDays;
        if (args.Length > 0 && int.TryParse(args[0], out var parsedValue) && parsedValue > ExclusiveMinimumDays)
        {
            days = parsedValue;
        }

        for (var i = 0; i <= days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");

            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }

            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
}
