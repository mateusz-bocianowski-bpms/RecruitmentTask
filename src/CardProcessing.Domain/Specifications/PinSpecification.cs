using Common.Domain.Specifications;

namespace CardProcessing.Domain.Specifications;

public class PinSpecification : ISpecification<CardDetails>
{
    public bool IsSatisfiedBy(CardDetails cardDetails) => cardDetails.IsPinSet;
}