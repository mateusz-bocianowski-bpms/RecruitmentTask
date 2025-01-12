using Common.Domain.Specifications;

using CardProcessing.Domain.Specifications;

namespace CardProcessing.Domain;

public class CardAction
{
    public string Name { get; private set; }

    private readonly List<CardType> supportedCardTypes;
    private readonly List<CardStatus> supportedCardStatuses;
    private readonly List<CardStatus> supportedCardStatusesWithPin;
    private readonly List<CardStatus> supportedCardStatusesWithoutPin;

    private readonly ISpecification<CardDetails> allowSpecification;

    public CardAction(string name)
    {
        Name = name;

        supportedCardTypes = new List<CardType>();
        supportedCardStatuses = new List<CardStatus>();
        supportedCardStatusesWithPin = new List<CardStatus>();
        supportedCardStatusesWithoutPin = new List<CardStatus>();

        var cardTypeSpecification = new CardTypeSpecification(supportedCardTypes);

        var cardStatusSpecification = new CardStatusSpecification(supportedCardStatuses);

        var cardStatusSpecificationWithPin = new AndSpecification<CardDetails>(
            new CardStatusSpecification(supportedCardStatusesWithPin), new PinSpecification());

        var cardStatusSpecificationWithoutPin = new AndSpecification<CardDetails>(
            new CardStatusSpecification(supportedCardStatusesWithoutPin), new NotSpecification<CardDetails>(new PinSpecification()));

        var totalCardStatusSpecification = new OrSpecification<CardDetails>(
            cardStatusSpecification,
            new OrSpecification<CardDetails>(cardStatusSpecificationWithPin, cardStatusSpecificationWithoutPin));

        allowSpecification = new AndSpecification<CardDetails>(cardTypeSpecification, totalCardStatusSpecification);
    }

    public void AddSupportedCardTypes(IEnumerable<CardType> cardTypes)
    {
        supportedCardTypes.AddRange(cardTypes);
    }

    public void AddSupportedCardStatuses(IEnumerable<CardStatus> cardStatuses)
    {
        supportedCardStatuses.AddRange(cardStatuses);
    }

    public void AddSupportedCardStatusesWithPin(IEnumerable<CardStatus> cardStatuses)
    {
        supportedCardStatusesWithPin.AddRange(cardStatuses);
    }

    public void AddSupportedCardStatusesWithoutPin(IEnumerable<CardStatus> cardStatuses)
    {
        supportedCardStatusesWithoutPin.AddRange(cardStatuses);
    }

    public bool IsAllowedFor(CardDetails cardDetails) => allowSpecification.IsSatisfiedBy(cardDetails);
}