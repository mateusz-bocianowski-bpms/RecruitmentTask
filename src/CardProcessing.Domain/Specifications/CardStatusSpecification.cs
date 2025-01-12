using Common.Domain.Specifications;

namespace CardProcessing.Domain.Specifications;

public class CardStatusSpecification : ISpecification<CardDetails>
{
    private readonly IEnumerable<CardStatus> cardStatuses;

    public CardStatusSpecification(IEnumerable<CardStatus> cardStatuses)
    {
        this.cardStatuses = cardStatuses;
    }

    public bool IsSatisfiedBy(CardDetails cardDetails) => cardStatuses.Contains(cardDetails.CardStatus);
}