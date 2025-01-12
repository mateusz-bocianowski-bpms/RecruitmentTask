using Common.Exceptions;

namespace Common.Validation.FluentValidation;

public class FluentValidator<TModel> : IValidator<TModel>
    where TModel : class, new()
{
    private readonly global::FluentValidation.IValidator<TModel> validator;

    public FluentValidator(global::FluentValidation.IValidator<TModel> validator)
    {
        this.validator = validator;
    }

    public void Validate(TModel model)
    {
        if (model is null)
        {
            throw new InvalidArgumentException("Model can not be null during validation.");
        }

        var validationResult = validator.Validate(model);

        if ((validationResult == null) || validationResult.IsValid)
        {
            return;
        }

        var error = validationResult.Errors.First();
        throw new InvalidArgumentException(error.ErrorMessage);
    }
}