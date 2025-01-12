namespace Common.Domain.Specifications;

public class NotSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> specification;

    public NotSpecification(ISpecification<T> specification)
    {
        this.specification = specification;
    }

    public bool IsSatisfiedBy(T item) => !specification.IsSatisfiedBy(item);
}