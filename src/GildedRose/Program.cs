using System;
using System.Collections.Generic;
using GildedRose.Items;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<IItem>();
            IItemFactory itemFactory = new ItemFactory();

            items.Add(itemFactory.Build("Aged Brie", 1, 1));
            items.Add(itemFactory.Build("Backstage passes", -1, 2));
            items.Add(itemFactory.Build("Backstage passes", 9, 2));
            items.Add(itemFactory.Build("Sulfuras", 2, 2));
            items.Add(itemFactory.Build("Normal Item", -1, 55));
            items.Add(itemFactory.Build("Normal Item", 2, 2));
            items.Add(itemFactory.Build("INVALID ITEM", 2, 2));
            items.Add(itemFactory.Build("Conjured", 2, 2));
            items.Add(itemFactory.Build("Conjured", -1, 5));

            Console.WriteLine("Test input:");
            foreach(var item in items)
            {
                Console.WriteLine(item);
                item.AgeOneDay();
            }

            Console.WriteLine();
            Console.WriteLine("Output after aging:");
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
