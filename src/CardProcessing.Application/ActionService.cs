using Common.Exceptions;
using Common.Domain;

using CardProcessing.Domain;
using CardProcessing.Application.Contract;

namespace CardProcessing.Application;

public class ActionService : IActionService
{
    private readonly ICardService cardService;
    private readonly ICardProcessingService cardProcessingService;

    public ActionService(ICardService cardService, ICardProcessingService cardProcessingService)
    {
        this.cardService = cardService;
        this.cardProcessingService = cardProcessingService;
    }

    public async Task<List<string>> GenerateAllowedCardActionsAsync(string userId, string cardNumber)
    {
        ValidateInput(userId, cardNumber);

        var cardDetails = await cardService.GetCardDetailsAsync(userId, cardNumber);

        if (cardDetails == null)
        {
            throw new EntityNotFoundException($"Card not found. UserId: {userId}, CardNumber: {cardNumber}.");
        }

        var allowedCardActions = await cardProcessingService.GenerateAllowedCardActionsAsync(cardDetails);

        return allowedCardActions;
    }

    private static void ValidateInput(string userId, string cardNumber)
    {
        if (userId.Length > Constraints.UserId_MaxLength)
        {
            throw new ErrorException($"UserId exceeds the maximum length of {Constraints.UserId_MaxLength} characters.");
        }

        if (cardNumber.Length > Constraints.CardNumber_MaxLength)
        {
            throw new ErrorException($"CardNumber exceeds the maximum length of {Constraints.CardNumber_MaxLength} characters.");
        }
    }
}