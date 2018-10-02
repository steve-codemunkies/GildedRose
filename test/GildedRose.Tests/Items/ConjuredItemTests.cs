using System;
using AutoFixture;
using FluentAssertions;
using GildedRose.Items;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class ConjuredItemTests
    {
        public ConjuredItemTests()
        {
            AutoFixture = new Fixture();
            Random = new Random((int)DateTime.Now.Ticks);
        }

        public Fixture AutoFixture { get; }
        public Random Random { get; }

        [Fact]
        public void WhenICallToStringOnAConjuredItemIGetOutputInTheExpectedFormat()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(0, 1000);

            IItem subject = new ConjuredItem(itemName, sellIn, quality);

            // Act
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn} {quality}");
        }

        [Fact]
        public void WhenITryToCreateAConjuredItemWithANegativeQualityItShouldThrowAnArgumentException()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = AutoFixture.Create<int>();
            var quality = Random.Next(-1000, 0);

            // Act
            var exception = Assert.Throws<ArgumentException>(() => new ConjuredItem(itemName, sellIn, quality));

            // Assert
            exception.ParamName.Should().Be("quality");
            exception.Message.Should().StartWith("Cannot be negative");
        }

        [Fact]
        public void WhenICallAgeAConjuredItemIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);
            var quality = Random.Next(1, 51);

            IItem subject = new ConjuredItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} {quality - 2}");
        }

        [Fact]
        public void WhenICallAgeOnAConjuredItemWithQualityGreaterThan50TheQualityIsSetTo50AndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);
            var quality = Random.Next(51, 1000);

            IItem subject = new ConjuredItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 50");
        }

        [Fact]
        public void WhenICallAgeOnAConjuredItemPastItsSellInQualityIsDecrementedBy4AndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 0);
            var quality = Random.Next(4, 51);

            IItem subject = new ConjuredItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} {quality - 4}");
        }

        [Fact]
        public void WhenICallAgeOnAConjuredItemWithQuality0TheQualityIsNotDecrementedAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);

            IItem subject = new ConjuredItem(itemName, sellIn, 0);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }

        [Fact]
        public void WhenICallAgeOnAConjuredItemPastItsSellInWithQuality0TheQualityIsNotDecrementedAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 1);

            IItem subject = new ConjuredItem(itemName, sellIn, 0);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }

        [Fact]
        public void WhenICallAgeOnAConjuredItemPastItsSellInWithQualityBetween1And3TheQualityIsSetToZeroAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 1);
            var quality = Random.Next(1, 4);

            IItem subject = new ConjuredItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }
    }
}