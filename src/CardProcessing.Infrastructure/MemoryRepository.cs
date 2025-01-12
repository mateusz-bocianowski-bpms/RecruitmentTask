using CardProcessing.Domain;

namespace CardProcessing.Infrastructure;

public class MemoryRepository : IRepository
{
    public Task<List<CardAction>> GetCardActionsAsync()
    {
        var allCardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>();
        var allCardStatuses = Enum.GetValues(typeof(CardStatus)).Cast<CardStatus>();

        var cardActions = new List<CardAction>();

        var cardAction1 = new CardAction("ACTION1");
        cardAction1.AddSupportedCardTypes(allCardTypes);
        cardAction1.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Active });
        cardActions.Add(cardAction1);

        var cardAction2 = new CardAction("ACTION2");
        cardAction2.AddSupportedCardTypes(allCardTypes);
        cardAction2.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Inactive });
        cardActions.Add(cardAction2);

        var cardAction3 = new CardAction("ACTION3");
        cardAction3.AddSupportedCardTypes(allCardTypes);
        cardAction3.AddSupportedCardStatuses(allCardStatuses);
        cardActions.Add(cardAction3);

        var cardAction4 = new CardAction("ACTION4");
        cardAction4.AddSupportedCardTypes(allCardTypes);
        cardAction4.AddSupportedCardStatuses(allCardStatuses);
        cardActions.Add(cardAction4);

        var cardAction5 = new CardAction("ACTION5");
        cardAction5.AddSupportedCardTypes(new List<CardType> { CardType.Credit });
        cardAction5.AddSupportedCardStatuses(allCardStatuses);
        cardActions.Add(cardAction5);

        var cardAction6 = new CardAction("ACTION6");
        cardAction6.AddSupportedCardTypes(allCardTypes);
        cardAction6.AddSupportedCardStatusesWithPin(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked });
        cardActions.Add(cardAction6);

        var cardAction7 = new CardAction("ACTION7");
        cardAction7.AddSupportedCardTypes(allCardTypes);
        cardAction7.AddSupportedCardStatusesWithPin(new List<CardStatus> { CardStatus.Blocked });
        cardAction7.AddSupportedCardStatusesWithoutPin(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });
        cardActions.Add(cardAction7);

        var cardAction8 = new CardAction("ACTION8");
        cardAction8.AddSupportedCardTypes(allCardTypes);
        cardAction8.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active, CardStatus.Blocked });
        cardActions.Add(cardAction8);

        var cardAction9 = new CardAction("ACTION9");
        cardAction9.AddSupportedCardTypes(allCardTypes);
        cardAction9.AddSupportedCardStatuses(allCardStatuses);
        cardActions.Add(cardAction9);

        var cardAction10 = new CardAction("ACTION10");
        cardAction10.AddSupportedCardTypes(allCardTypes);
        cardAction10.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });
        cardActions.Add(cardAction10);

        var cardAction11 = new CardAction("ACTION11");
        cardAction11.AddSupportedCardTypes(allCardTypes);
        cardAction11.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Inactive, CardStatus.Active });
        cardActions.Add(cardAction11);

        var cardAction12 = new CardAction("ACTION12");
        cardAction12.AddSupportedCardTypes(allCardTypes);
        cardAction12.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });
        cardActions.Add(cardAction12);

        var cardAction13 = new CardAction("ACTION13");
        cardAction13.AddSupportedCardTypes(allCardTypes);
        cardAction13.AddSupportedCardStatuses(new List<CardStatus> { CardStatus.Ordered, CardStatus.Inactive, CardStatus.Active });
        cardActions.Add(cardAction13);

        return Task.FromResult(cardActions);
    }
}