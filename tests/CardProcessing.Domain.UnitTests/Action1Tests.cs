using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

[TestFixture]
public class Action1Tests
{
    private CardAction? cardAction1;

    [SetUp]
    public void SetUp()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();

        cardAction1 = new CardAction("ACTION1");
        cardAction1.AddSupportedCardTypes(allCardTypes);
        cardAction1.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Active });
    }

    [TearDown]
    public void CleanUp()
    {
        cardAction1 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, false)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, false)]
    [TestCase(CardType.Prepaid, CardStatus.Active, true)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, false)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, false)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, false)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, false)]
    [TestCase(CardType.Debit, CardStatus.Inactive, false)]
    [TestCase(CardType.Debit, CardStatus.Active, true)]
    [TestCase(CardType.Debit, CardStatus.Restricted, false)]
    [TestCase(CardType.Debit, CardStatus.Blocked, false)]
    [TestCase(CardType.Debit, CardStatus.Expired, false)]
    [TestCase(CardType.Debit, CardStatus.Closed, false)]
    [TestCase(CardType.Credit, CardStatus.Ordered, false)]
    [TestCase(CardType.Credit, CardStatus.Inactive, false)]
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
        var allowed = cardAction1!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}