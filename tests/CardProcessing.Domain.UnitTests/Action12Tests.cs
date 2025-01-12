using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

public class Action12Tests
{
    private CardAction? cardAction12;

    [SetUp]
    public void SetUp()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();

        cardAction12 = new CardAction("ACTION12");
        cardAction12.AddSupportedCardTypes(allCardTypes);
        cardAction12.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });
    }

    [TearDown]
    public void CleanUp()
    {
        cardAction12 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, true)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, true)]
    [TestCase(CardType.Prepaid, CardStatus.Active, true)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, false)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, false)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, false)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, true)]
    [TestCase(CardType.Debit, CardStatus.Inactive, true)]
    [TestCase(CardType.Debit, CardStatus.Active, true)]
    [TestCase(CardType.Debit, CardStatus.Restricted, false)]
    [TestCase(CardType.Debit, CardStatus.Blocked, false)]
    [TestCase(CardType.Debit, CardStatus.Expired, false)]
    [TestCase(CardType.Debit, CardStatus.Closed, false)]
    [TestCase(CardType.Credit, CardStatus.Ordered, true)]
    [TestCase(CardType.Credit, CardStatus.Inactive, true)]
    [TestCase(CardType.Credit, CardStatus.Active, true)]
    [TestCase(CardType.Credit, CardStatus.Restricted, false)]
    [TestCase(CardType.Credit, CardStatus.Blocked, false)]
    [TestCase(CardType.Credit, CardStatus.Expired, false)]
    [TestCase(CardType.Credit, CardStatus.Closed, false)]
    public void IsAllowedFor(CardType cardType, CardStatus cardStatus, bool expectedAllowed)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithCardType(cardType)
            .WithCardStatus(cardStatus)
            .Build();

        // Act
        var allowed = cardAction12!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}