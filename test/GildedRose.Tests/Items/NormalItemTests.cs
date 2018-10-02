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

        [Fact]
        public void WhenITryToCreateANormalItemWithANegativeQualityItShouldThrowAnArgumentException()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(-1000, 0);

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new NormalItem(itemName, sellIn, quality));

            // Assert
            exception.ParamName.Should().Be("quality");
            exception.Message.Should().StartWith("Cannot be negative");
        }

        [Fact]
        public void WhenICallAgeANormalItemIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);
            var quality = Random.Next(1, 51);

            IItem subject = new NormalItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} {quality - 1}");
        }
    }

    public class NormalItem : IItem
    {
        private string _itemName;
        private int _sellIn;
        private int _quality;

        public NormalItem(string itemName, int sellIn, int quality)
        {
            if(quality < 0)
            {
                throw new ArgumentException("Cannot be negative", nameof(quality));
            }

            _itemName = itemName;
            _sellIn = sellIn;
            _quality = quality;
        }

        public void AgeOneDay()
        {
            _sellIn--;
            _quality--;
        }

        public override string ToString()
        {
            return $"{_itemName} {_sellIn} {_quality}";
        }
    }

    public interface IItem
    {
        void AgeOneDay();
    }
}