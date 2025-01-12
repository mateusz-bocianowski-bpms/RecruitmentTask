using FluentAssertions;

using CardProcessing.Domain.Specifications;

namespace CardProcessing.Domain.UnitTests.Specifications;

[TestFixture]
public class PinSpecificationTests
{
    private PinSpecification? sut;

    [SetUp]
    public void SetUp()
    {
        sut = new PinSpecification();
    }

    [TearDown]
    public void CleanUp()
    {
        sut = null;
    }

    [Test]
    [TestCase(true, true)]
    [TestCase(false, false)]
    public void IsSatisfiedBy(bool isPinSet, bool expectedSatisfied)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithIsPinSet(isPinSet)
            .Build();

        // Act
        var satisfied = sut!.IsSatisfiedBy(cardDetails);

        // Assert
        satisfied.Should().Be(expectedSatisfied);
    }
}