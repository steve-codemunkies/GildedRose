using FluentAssertions;
using GildedRose.Items;
using Xunit;

namespace GildedRose.Tests.Items
{
    public class NoSuchItemTests
    {
        [Fact]
        public void WhenICallToStringOnTheNoSuchItemIGetTheExpectedString()
        {
            // Arrange
            IItem subject = new NoSuchItem();

            // Act
            var result = subject.ToString();

            // Assert
            result.Should().Be("NO SUCH ITEM");
        }

        [Fact]
        public void WhenIAgeANoSuchItemNoExceptionIsThrownAndIGetTheExpectedString()
        {
            // Arrange
            IItem subject = new NoSuchItem();

            // Act
            subject.AgeOneDay();
            var result = subject.ToString();

            // Assert
            result.Should().Be("NO SUCH ITEM");
        }
    }

    public class NoSuchItem : IItem
    {
        public void AgeOneDay()
        {
            // Deliberately do nothing...
        }

        public override string ToString()
        {
            return "NO SUCH ITEM";
        }
    }
}