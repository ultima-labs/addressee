namespace Addressee.UnitTests
{
    using FluentAssertions;
    using Xunit;

    public sealed class StringExtensionsFixture
    {
        [Fact]
        public void TrimOrEmptyShouldNotChangeValidString()
        {
            // Arrange
            var source = "Just a string, mate";

            // Act
            var result = source.TrimOrEmpty();

            // Assert
            result.Should().Be("Just a string, mate");
        }

        [Fact]
        public void TrimOrEmptyShouldTrimLeadingSpaces()
        {
            // Arrange
            var source = "  With Leading Spaces";

            // Act
            var result = source.TrimOrEmpty();

            // Assert
            result.Should().Be("With Leading Spaces");
        }

        [Fact]
        public void TrimOrEmptyShouldTrimTrailingSpaces()
        {
            // Arrange
            var source = "With Trailing Spaces  ";

            // Act
            var result = source.TrimOrEmpty();

            // Assert
            result.Should().Be("With Trailing Spaces");
        }

        [Fact]
        public void TrimOrEmptyShouldTrimTabsAsWell()
        {
            // Arrange
            var source = "\tWith Tabs\t";

            // Act
            var result = source.TrimOrEmpty();

            // Assert
            result.Should().Be("With Tabs");
        }

        [Fact]
        public void TrimOrEmptyShouldConvertNullIntoEmpty()
        {
            // Act
            var result = default(string).TrimOrEmpty();

            // Assert
            result.Should().BeEmpty();
        }
    }
}
