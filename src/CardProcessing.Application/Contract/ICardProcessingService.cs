using CardProcessing.Domain;

namespace CardProcessing.Application.Contract;

public interface ICardProcessingService
{
    Task<List<string>> GenerateAllowedCardActionsAsync(CardDetails cardDetails);
}