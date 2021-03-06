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

        [Fact]
        public void WhenIBuildAnNormalItemIGetBackANormalItemObject()
        {
            // Arrange
            var sellin = Random.Next(-1000, 1000);
            var quality = Random.Next(0, 1000);

            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build("Normal Item", sellin, quality);

            // Result
            result.Should().BeOfType<NormalItem>();
        }

        [Fact]
        public void WhenIBuildASulfurasItemIGetBackASulfurasItemObject()
        {
            // Arrange
            var sellin = Random.Next(-1000, 1000);
            var quality = Random.Next(0, 1000);

            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build("Sulfuras", sellin, quality);

            // Result
            result.Should().BeOfType<SulfurasItem>();
        }

        [Fact]
        public void WhenIBuildABackstagePassItemIGetBackABackstagePassItemObject()
        {
            // Arrange
            var sellin = Random.Next(-1000, 1000);
            var quality = Random.Next(0, 1000);

            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build("Backstage passes", sellin, quality);

            // Result
            result.Should().BeOfType<BackstagePassItem>();
        }

        [Fact]
        public void WhenIBuildAConjuredItemIGetBackAConjuredItemObject()
        {
            // Arrange
            var sellin = Random.Next(-1000, 1000);
            var quality = Random.Next(0, 1000);

            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build("Conjured", sellin, quality);

            // Result
            result.Should().BeOfType<ConjuredItem>();
        }

        [Fact]
        public void WhenITryAndBuildAnUnknownItemIGetBackANoSuchItemObject()
        {
            // Arrange
            IItemFactory subject = new ItemFactory();

            // Act
            var result = subject.Build(AutoFixture.Create<string>(), AutoFixture.Create<int>(), AutoFixture.Create<int>());

            // Result
            result.Should().BeOfType<NoSuchItem>();
        }
    }
}