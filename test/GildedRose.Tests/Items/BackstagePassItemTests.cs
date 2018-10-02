using System;
using AutoFixture;
using FluentAssertions;
using GildedRose.Items;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class BackstagePassItemTests
    {
        public BackstagePassItemTests()
        {
            AutoFixture = new Fixture();
            Random = new Random((int)DateTime.Now.Ticks);
        }

        public Fixture AutoFixture { get; }
        public Random Random { get; }

        [Fact]
        public void WhenICallToStringOnABackstagePassItemIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(0, 1000);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn} {quality}");
        }

        [Fact]
        public void WhenITryToCreateABackstagePassItemWithANegativeQualityItShouldThrowAnArgumentException()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(-1000, 0);

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new BackstagePassItem(itemName, sellIn, quality));

            // Assert
            exception.ParamName.Should().Be("quality");
            exception.Message.Should().StartWith("Cannot be negative");
        }
    }

    public class BackstagePassItem : BaseItem
    {
        public BackstagePassItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
        }

        public override void AgeOneDay()
        {
            throw new NotImplementedException();
        }
    }
}