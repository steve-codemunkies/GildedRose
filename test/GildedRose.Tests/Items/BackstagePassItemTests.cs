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

        [Fact]
        public void WhenAgeABackstagePassWithMoreThan10DaysSellinTheQualityIncreasesBy1()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(12, 1000);
            var quality = Random.Next(0, 50);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} {quality+1}");
        }

        [Fact]
        public void WhenAgeABackstagePassWithMoreThan10DaysSellinAndQualityGreaterThan50TheQualityIsResetTo50()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(12, 1000);
            var quality = Random.Next(51, 1000);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }

        [Fact]
        public void WhenAgeABackstagePassWithBetween6And10DaysSellinIncTheQualityIncreasesBy2()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(7, 11);
            var quality = Random.Next(0, 48);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} {quality+2}");
        }

        [Fact]
        public void WhenAgeABackstagePassWithBetween6And10DaysSellinIncAndQualityWas49TheQualityIsSetTo50()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(7, 11);

            IItem subject = new BackstagePassItem(itemName, sellIn, 49);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }
        [Fact]
        public void WhenAgeABackstagePassWithBetween6And10DaysSellinIncAndQualityOver50TheQualityIsSetTo50()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(7, 11);
            var quality = Random.Next(51, 1000);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }

        [Fact]
        public void WhenAgeABackstagePassWithBetween0And5DaysSellinIncTheQualityIncreasesBy3()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 6);
            var quality = Random.Next(0, 48);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} {quality+3}");
        }

        [Fact]
        public void WhenAgeABackstagePassWithBetween0And5DaysSellinIncAndQualityWas48Or49TheQualityIsSetTo50()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 6);
            var quality = Random.Next(48, 50);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }
        [Fact]
        public void WhenAgeABackstagePassWithBetween0And5DaysSellinIncAndQualityOver50TheQualityIsSetTo50()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(1, 6);
            var quality = Random.Next(51, 1000);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 50");
        }

        [Fact]
        public void WhenAgeABackstagePassWithLessThan0DaysSellinTheQualityIsZero()
        {
            // Arrange
            var itemName = AutoFixture.Create<string>();
            var sellIn = Random.Next(-1000, 0);
            var quality = Random.Next(1, 1000);

            IItem subject = new BackstagePassItem(itemName, sellIn, quality);

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be($"{itemName} {sellIn-1} 0");
        }
    }

    public class BackstagePassItem : BaseItem
    {
        public BackstagePassItem(string itemName, int sellIn, int quality) : base(itemName, sellIn, quality)
        {
        }

        public override void AgeOneDay()
        {
            _sellIn--;

            if(_sellIn > 10)
            {
                _quality++;
            }
            else if(_sellIn > 5 && _sellIn <= 10)
            {
                _quality+=2;
            }
            else if (_sellIn >= 0 && _sellIn <= 5)
            {
                _quality+=3;
            }
            else
            {
                _quality = QualityFloorInclusive;
            }

            if(_quality > QualityCeilingInclusive)
            {
                _quality = QualityCeilingInclusive;
            }
        }
    }
}