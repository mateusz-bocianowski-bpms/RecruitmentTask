using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

[TestFixture]
public class Action5Tests
{
    private CardAction? cardAction5;

    [SetUp]
    public void SetUp()
    {
        var allCardStatuses = Enum.GetValues(typeof(CardStatus)).Cast<CardStatus>();        

        cardAction5 = new CardAction("ACTION5");
        cardAction5.AddSupportedCardTypes(new List<CardType> { CardType.Credit });
        cardAction5.AddSupportedCardStatuses(allCardStatuses);
    }

    [TearDown]
    public void CleanUp()
    {
        cardAction5 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, false)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, false)]
    [TestCase(CardType.Prepaid, CardStatus.Active, false)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, false)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, false)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, false)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, false)]
    [TestCase(CardType.Debit, CardStatus.Inactive, false)]
    [TestCase(CardType.Debit, CardStatus.Active, false)]
    [TestCase(CardType.Debit, CardStatus.Restricted, false)]
    [TestCase(CardType.Debit, CardStatus.Blocked, false)]
    [TestCase(CardType.Debit, CardStatus.Expired, false)]
    [TestCase(CardType.Debit, CardStatus.Closed, false)]
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
        var allowed = cardAction5!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}