using System;
using AutoFixture;
using FluentAssertions;
using GildedRose.Items;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class AgedBrieItemTests
    {
        public AgedBrieItemTests()
        {
            AutoFixture = new Fixture();
            Random = new Random((int)DateTime.Now.Ticks);
        }

        public Fixture AutoFixture { get; }
        public Random Random { get; }

        [Fact]
        public void WhenICallToStringOnAnAgedBrieItemIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(0, 1000);

            IItem subject = new AgedBrieItem(itemName, sellIn, quality);

            // Act
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn} {quality}");
        }

        [Fact]
        public void WhenITryToCreateAnAgedBrieItemWithANegativeQualityItShouldThrowAnArgumentException()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(-1000, 0);

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new AgedBrieItem(itemName, sellIn, quality));

            // Assert
            exception.ParamName.Should().Be("quality");
            exception.Message.Should().StartWith("Cannot be negative");
        }

        [Fact]
        public void WhenIAgeAnAgedBrieItemTheQualityIncreasesAndIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(0, 50);

            IItem subject = new AgedBrieItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} {quality+1}");
        }

        [Fact]
        public void WhenIAgeAnAgedBrieItemWithQuality50TheQualityRemains50AndIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();

            IItem subject = new AgedBrieItem(itemName, sellIn, 50);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }

        [Fact]
        public void WhenIAgeAnAgedBrieItemWithQualityOver50TheQualityIsResetTo50AndIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(51, 1000);

            IItem subject = new AgedBrieItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }
    }
}