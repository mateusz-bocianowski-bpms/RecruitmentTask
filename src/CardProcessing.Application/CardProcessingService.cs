using CardProcessing.Domain;
using CardProcessing.Application.Contract;

namespace CardProcessing.Application;

public class CardProcessingService : ICardProcessingService
{
    private readonly IRepository repository;

    public CardProcessingService(IRepository repository)
    {
        this.repository = repository;
    }

    public async Task<List<string>> GenerateAllowedCardActionsAsync(CardDetails cardDetails)
    {
        var cardActions = await repository.GetCardActionsAsync();

        var allowedActions = new List<string>();

        foreach (var cardAction in cardActions)
        {
            var allowed = cardAction.IsAllowedFor(cardDetails);

            if (allowed)
            {
                allowedActions.Add(cardAction.Name);
            }
        }

        return allowedActions;
    }
}