using CardProcessing.Domain;

namespace CardProcessing.Application.Contract;

public interface ICardService
{
    Task<CardDetails?> GetCardDetailsAsync(string userId, string cardNumber);
}