namespace Common.Validation;

public interface IValidator<TModel> where TModel : class, new()
{
    void Validate(TModel model);
}