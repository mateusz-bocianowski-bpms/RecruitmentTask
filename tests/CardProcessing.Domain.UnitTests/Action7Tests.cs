using FluentAssertions;

namespace CardProcessing.Domain.UnitTests;

[TestFixture]
public class Action7Tests
{
    private CardAction? cardAction7;

    [SetUp]
    public void SetUp()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();

        cardAction7 = new CardAction("ACTION7");
        cardAction7.AddSupportedCardTypes(allCardTypes);
        cardAction7.AddSupportedCardStatusesWithPin(new List<CardStatus> { CardStatus.Blocked });
        cardAction7.AddSupportedCardStatusesWithoutPin(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });    }

    [TearDown]
    public void CleanUp()
    {
        cardAction7 = null;
    }

    [Test]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, true, false)]
    [TestCase(CardType.Prepaid, CardStatus.Ordered, false, true)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, true, false)]
    [TestCase(CardType.Prepaid, CardStatus.Inactive, false, true)]
    [TestCase(CardType.Prepaid, CardStatus.Active, true, false)]
    [TestCase(CardType.Prepaid, CardStatus.Active, false, true)]
    [TestCase(CardType.Prepaid, CardStatus.Restricted, true,false)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, true, true)]
    [TestCase(CardType.Prepaid, CardStatus.Blocked, false,false)]
    [TestCase(CardType.Prepaid, CardStatus.Expired, true,false)]
    [TestCase(CardType.Prepaid, CardStatus.Closed, true, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, true, false)]
    [TestCase(CardType.Debit, CardStatus.Ordered, false, true)]
    [TestCase(CardType.Debit, CardStatus.Inactive, true, false)]
    [TestCase(CardType.Debit, CardStatus.Inactive, false, true)]
    [TestCase(CardType.Debit, CardStatus.Active, true, false)]
    [TestCase(CardType.Debit, CardStatus.Active, false, true)]
    [TestCase(CardType.Debit, CardStatus.Restricted, true,false)]
    [TestCase(CardType.Debit, CardStatus.Blocked, true, true)]
    [TestCase(CardType.Debit, CardStatus.Blocked, false,false)]
    [TestCase(CardType.Debit, CardStatus.Expired, true,false)]
    [TestCase(CardType.Debit, CardStatus.Closed, true, false)]
    [TestCase(CardType.Credit, CardStatus.Ordered, true, false)]
    [TestCase(CardType.Credit, CardStatus.Ordered, false, true)]
    [TestCase(CardType.Credit, CardStatus.Inactive, true, false)]
    [TestCase(CardType.Credit, CardStatus.Inactive, false, true)]
    [TestCase(CardType.Credit, CardStatus.Active, true, false)]
    [TestCase(CardType.Credit, CardStatus.Active, false, true)]
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
        var allowed = cardAction7!.IsAllowedFor(cardDetails);

        // Assert
        allowed.Should().Be(expectedAllowed);
    }
}