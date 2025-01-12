using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

[TestFixture]
public class Action6Tests
{
    private CardAction? cardAction6;

    [SetUp]
    public void SetUp()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();

        cardAction6 = new CardAction("ACTION6");
        cardAction6.AddSupportedCardTypes(allCardTypes);
        cardAction6.AddSupportedCardStatusesWithPin(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked });
    }

    [TearDown]
    public void CleanUp()
    {
        cardAction6 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, true, true)]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, false, false)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, true, true)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, false, false)]
    [TestCase(CardType.Prepaid, CardStatus.Active, true, true)]
    [TestCase(CardType.Prepaid, CardStatus.Active, false, false)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, true,false)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, true, true)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, false,false)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, true,false)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, true, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, true, true)]
    [TestCase(CardType.Debit, CardStatus.Ordered, false, false)]
    [TestCase(CardType.Debit, CardStatus.Inactive, true, true)]
    [TestCase(CardType.Debit, CardStatus.Inactive, false, false)]
    [TestCase(CardType.Debit, CardStatus.Active, true, true)]
    [TestCase(CardType.Debit, CardStatus.Active, false, false)]
    [TestCase(CardType.Debit, CardStatus.Restricted, true,false)]
    [TestCase(CardType.Debit, CardStatus.Blocked, true, true)]
    [TestCase(CardType.Debit, CardStatus.Blocked, false,false)]
    [TestCase(CardType.Debit, CardStatus.Expired, true,false)]
    [TestCase(CardType.Debit, CardStatus.Closed, true, false)]
    [TestCase(CardType.Credit, CardStatus.Ordered, true, true)]
    [TestCase(CardType.Credit, CardStatus.Ordered, false, false)]
    [TestCase(CardType.Credit, CardStatus.Inactive, true, true)]
    [TestCase(CardType.Credit, CardStatus.Inactive, false, false)]
    [TestCase(CardType.Credit, CardStatus.Active, true, true)]
    [TestCase(CardType.Credit, CardStatus.Active, false, false)]
    [TestCase(CardType.Credit, CardStatus.Restricted, true,false)]
    [TestCase(CardType.Credit, CardStatus.Blocked, true, true)]
    [TestCase(CardType.Credit, CardStatus.Blocked, false,false)]
    [TestCase(CardType.Credit, CardStatus.Expired, true,false)]
    [TestCase(CardType.Credit, CardStatus.Closed, true, false)]
    public void IsAllowedFor(CardType cardType, CardStatus cardStatus, bool isPinSet, bool expectedAllowed)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithCardType(cardType)
            .WithCardStatus(cardStatus)
            .WithIsPinSet(isPinSet)
            .Build();

        // Act
        var allowed = cardAction6!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}