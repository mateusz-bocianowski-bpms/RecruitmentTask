using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

public class Action9Tests
{
    private CardAction? cardAction9;

    [SetUp]
    public void SetUp()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();
        var allCardStatuses = Enum.GetValues(typeof(CardStatus)).Cast<CardStatus>();

        cardAction9 = new CardAction("ACTION9");
        cardAction9.AddSupportedCardTypes(allCardTypes);
        cardAction9.AddSupportedCardStatuses(allCardStatuses);
    }

    [TearDown]
    public void CleanUp()
    {
        cardAction9 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, true)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, true)]
    [TestCase(CardType.Prepaid, CardStatus.Active, true)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, true)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, true)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, true)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, true)]
    [TestCase(CardType.Debit, CardStatus.Ordered, true)]
    [TestCase(CardType.Debit, CardStatus.Inactive, true)]
    [TestCase(CardType.Debit, CardStatus.Active, true)]
    [TestCase(CardType.Debit, CardStatus.Restricted, true)]
    [TestCase(CardType.Debit, CardStatus.Blocked, true)]
    [TestCase(CardType.Debit, CardStatus.Expired, true)]
    [TestCase(CardType.Debit, CardStatus.Closed, true)]
    [TestCase(CardType.Credit, CardStatus.Ordered, true)]
    [TestCase(CardType.Credit, CardStatus.Inactive, true)]
    [TestCase(CardType.Credit, CardStatus.Active, true)]
    [TestCase(CardType.Credit, CardStatus.Restricted, true)]
    [TestCase(CardType.Credit, CardStatus.Blocked, true)]
    [TestCase(CardType.Credit, CardStatus.Expired, true)]
    [TestCase(CardType.Credit, CardStatus.Closed, true)]
    public void IsAllowedFor(CardType cardType, CardStatus cardStatus, bool expectedAllowed)
    {
        // Arrange
        var cardDetails = new CardDetailsBuilder()
            .WithCardType(cardType)
            .WithCardStatus(cardStatus)
            .Build();

        // Act
        var allowed = cardAction9!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}