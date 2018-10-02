using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class NormalItemTests
    {
        public NormalItemTests()
        {
            AutoFixture = new Fixture();
            Random = new Random((int)DateTime.Now.Ticks);
        }

        public Fixture AutoFixture { get; }
        public Random Random { get; }

        [Fact]
        public void WhenICallToStringOnANormalItemIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(0, 1000);

            IItem subject = new NormalItem(itemName, sellIn, quality);

            // Act
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn} {quality}");
        }
    }

    public class NormalItem : IItem
    {
        private string _itemName;
        private int _sellIn;
        private int _quality;

        public NormalItem(string itemName, int sellIn, int quality)
        {
            _itemName = itemName;
            _sellIn = sellIn;
            _quality = quality;
        }

        public override string ToString()
        {
            return $"{_itemName} {_sellIn} {_quality}";
        }
    }

    public interface IItem
    {
    }
}