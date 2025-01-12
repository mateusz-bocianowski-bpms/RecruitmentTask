namespace CardProcessing.Application.Contract;

public interface IActionService
{
    Task<List<string>> GenerateAllowedCardActionsAsync(string userId, string cardNumber);
}