using System;
using AutoFixture;
using FluentAssertions;
using GildedRose.Items;
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

        [Fact]
        public void WhenICallAgeOnANormalItemWithQualityGreaterThan50TheQualityIsSetTo50AndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);
            var quality = Random.Next(51, 1000);

            IItem subject = new NormalItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 50");
        }

        [Fact]
        public void WhenICallAgeOnANormalItemPastItsSellInQualityIsDecrementedBy2AndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 0);
            var quality = Random.Next(1, 51);

            IItem subject = new NormalItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} {quality - 2}");
        }

        [Fact]
        public void WhenICallAgeOnANormalItemWithQuality0TheQualityIsNotDecrementedAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 1000);

            IItem subject = new NormalItem(itemName, sellIn, 0);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }

        [Fact]
        public void WhenICallAgeOnANormalItemPastItsSellInWithQuality0TheQualityIsNotDecrementedAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 1);

            IItem subject = new NormalItem(itemName, sellIn, 0);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }

        [Fact]
        public void WhenICallAgeOnANormalItemPastItsSellInWithQuality1TheQualityIsSetToZeroAndIGetOutputWithTheExpectedValues()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 1);

            IItem subject = new NormalItem(itemName, sellIn, 1);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn - 1} 0");
        }
    }
}