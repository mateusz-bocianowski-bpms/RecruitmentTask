using FluentAssertions;

using CardProcessing.Domain.Specifications;

namespace CardProcessing.Domain.UnitTests.Specifications;

[TestFixture]
public class CardStatusSpecificationTests
{
    private CardStatusSpecification? sut;

    [SetUp]
    public void SetUp()
    {
        var cardStatuses = new List<CardStatus> { CardStatus.Active };

        sut = new CardStatusSpecification(cardStatuses);
    }

    [TearDown]
    public void CleanUp()
    {
        sut = null;
    }

    [Test]
    [TestCase(CardStatus.Active, true)]
    [TestCase(CardStatus.Inactive, false)]
    public void IsSatisfiedBy(CardStatus cardStatus, bool expectedSatisfied)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithCardStatus(cardStatus)
            .Build();

        // Act
        var satisfied = sut!.IsSatisfiedBy(cardDetails);

        // Assert
        satisfied.Should().Be(expectedSatisfied);
    }
}