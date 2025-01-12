using AutoFixture;

namespace CardProcessing.Domain.UnitTests;

public class CardDetailsBuilder
{
    private string cardNumber;
    private CardType cardType;
    private CardStatus cardStatus;
    private bool isPinSet;

    public CardDetailsBuilder()
    {
        var fixture = new Fixture();

        cardNumber = fixture.Create<string>();
        cardType = fixture.Create<CardType>();
        cardStatus = fixture.Create<CardStatus>();
        isPinSet = fixture.Create<bool>();
    }

    public CardDetailsBuilder WithCardType(CardType cardType)
    {
        this.cardType = cardType;
        return this;
    }

    public CardDetailsBuilder WithCardStatus(CardStatus cardStatus)
    {
        this.cardStatus = cardStatus;
        return this;
    }

    public CardDetailsBuilder WithIsPinSet(bool isPinSet)
    {
        this.isPinSet = isPinSet;
        return this;
    }

    public CardDetails Build()
    {
        return new CardDetails(
            CardNumber: cardNumber,
            CardType: cardType,
            CardStatus: cardStatus,
            IsPinSet: isPinSet
        );
    }
}