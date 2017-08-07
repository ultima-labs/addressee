namespace Addressee.UnitTests
{
    using System.Globalization;
    using FluentAssertions;
    using Xunit;

    public sealed class SupportedLanguageFixture
    {
        [Fact]
        public void ShouldSupportInvariant()
        {
            // Assert
            SupportedLanguage.Invariant.Should().NotBeNull();
            SupportedLanguage.Invariant.Should().Be(CultureInfo.InvariantCulture);
        }

        [Fact]
        public void ShouldSupportEnglish()
        {
            // Assert
            SupportedLanguage.English.Should().NotBeNull();
            SupportedLanguage.English.IsNeutralCulture.Should().BeTrue();
            SupportedLanguage.English.Name.Should().Be("en");
        }

        [Fact]
        public void ShouldHaveDefaultEnglish()
        {
            // Assert
            SupportedLanguage.Default.Should().NotBeNull();
            SupportedLanguage.Default.IsNeutralCulture.Should().BeTrue();
            SupportedLanguage.Default.Name.Should().Be("en");
            SupportedLanguage.Default.Should().Be(SupportedLanguage.English);
        }

        [Fact]
        public void ShouldHaveCollectionOfAll()
        {
            // Assert
            SupportedLanguage.All.Should().NotBeNull();
            SupportedLanguage.All.Should().HaveCount(2);
            SupportedLanguage.All.Should().Contain(SupportedLanguage.Invariant);
            SupportedLanguage.All.Should().Contain(SupportedLanguage.English);
        }
    }
}
