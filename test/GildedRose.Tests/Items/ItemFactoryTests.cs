using System;
using AutoFixture;
using FluentAssertions;
using GildedRose.Items;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class ItemFactoryTests
    {
        public ItemFactoryTests()
        {
            AutoFixture = new Fixture();
            Random = new Random((int)DateTime.Now.Ticks);
        }

        public Fixture AutoFixture { get; }
        public Random Random { get; }

        [Fact]
        public void WhenIBuildAnAgedBrieIGetBackAnAgedBrieItemObject()
        {
            // Arrange
            var sellin = Random.Next(-1000, 1000);
            var quality = Random.Next(0, 1000);

            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build("Aged Brie", sellin, quality);

            // Result
            result.Should().BeOfType<AgedBrieItem>();
        }
    }

    public class ItemFactory : IItemFactory
    {
        public IItem Build(string itemName, int sellin, int quality)
        {
            return new AgedBrieItem(itemName, sellin, quality);
        }
    }

    public interface IItemFactory
    {
        IItem Build(string itemName, int sellin, int quality);
    }
}