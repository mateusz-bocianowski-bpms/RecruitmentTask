namespace CardProcessing.Domain;

public interface IRepository
{
    Task<List<CardAction>> GetCardActionsAsync();
}