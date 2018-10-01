using System;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            IStockList stockList = new StockList();

            stockList.AddItem("Aged Brie", 1, 1);
            stockList.AddItem("Backstage passes", -1, 2);
            stockList.AddItem("Backstage passes", 9, 2);
            stockList.AddItem("Sulfuras", 2, 2);
            stockList.AddItem("Normal Item", -1, 55);
            stockList.AddItem("Normal Item", 2, 2);
            stockList.AddItem("INVALID ITEM", 2, 2);
            stockList.AddItem("Conjured", 2, 2);
            stockList.AddItem("Conjured", -1, 5);

            Console.WriteLine("Test input:");
            Console.WriteLine(stockList.ToString());

            stockList.AgeInventory();

            Console.WriteLine("Output after aging:");
            Console.WriteLine(stockList.ToString());
        }
    }
}
