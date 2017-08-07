namespace Addressee.UnitTests
{
    using FluentAssertions;
    using Xunit;

    public sealed class SupportedCountriesFixture
    {
        [Fact]
        public void ShouldSupportAustralia()
        {
            // Assert
            SupportedCountries.Australia.Should().NotBeNull();
            SupportedCountries.Australia.Name.Should().Be("AU");
        }

        [Fact]
        public void ShouldSupportRussia()
        {
            // Assert
            SupportedCountries.Russia.Should().NotBeNull();
            SupportedCountries.Russia.Name.Should().Be("RU");
        }
    }
}
