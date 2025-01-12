using FluentAssertions;

using CardProcessing.Domain.Specifications;

namespace CardProcessing.Domain.UnitTests.Specifications;

[TestFixture]
public class CardTypeSpecificationTests
{
    private CardTypeSpecification? sut;

    [SetUp]
    public void SetUp()
    {
        var cardTypes = new List<CardType> { CardType.Prepaid };

        sut = new CardTypeSpecification(cardTypes);
    }

    [TearDown]
    public void CleanUp()
    {
        sut = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, true)]
    [TestCase(CardType.Debit, false)]
    public void IsSatisfiedBy(CardType cardType, bool expectedSatisfied)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithCardType(cardType)
            .Build();

        // Act
        var satisfied = sut!.IsSatisfiedBy(cardDetails);

        // Assert
        satisfied.Should().Be(expectedSatisfied);
    }
}