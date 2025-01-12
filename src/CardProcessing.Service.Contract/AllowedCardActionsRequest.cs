namespace CardProcessing.Service.Contract;

public class AllowedCardActionsRequest
{
    public string UserId { get; init; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
}