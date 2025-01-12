using Common.Domain.Specifications;

namespace CardProcessing.Domain.Specifications;

public class CardTypeSpecification : ISpecification<CardDetails>
{
    private readonly IEnumerable<CardType> cardTypes;

    public CardTypeSpecification(IEnumerable<CardType> cardTypes)
    {
        this.cardTypes = cardTypes;
    }

    public bool IsSatisfiedBy(CardDetails cardDetails) => cardTypes.Contains(cardDetails.CardType);
}