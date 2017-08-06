using System;
using Zenject;
/*
 Classes related with creating card

  Why this is working this way?
  based on: https://github.com/modesttree/Zenject/blob/master/Documentation/Factories.md

*/
namespace StarDust
{

  // List of all available cards in game:
  public enum CardListNames
  {
    BattleCruiser,
    Carrier,
    DeathStar,
    Refuel,
  }


  public class CardFactoryController
  {
    public CardListNames NextCardName { get; private set; }

    public void SetRandomCard()
    {
      NextCardName = CardListNames.BattleCruiser;
    }

    public void SetNextCardName(CardListNames nextCardName)
    {
      NextCardName = nextCardName;
    }
  }

  public class BaseCardFactory : Factory<Card>
  {

  }

  public class CardFactoryInternal : IFactory<Card>
  {
    DiContainer _container;
    [Inject]
    CardFactoryController _factroryController;

    public CardFactoryInternal(DiContainer container)
    {
      _container = container;
    }

    public Card Create()
    {
      Card nextCard = null;

      switch (_factroryController.NextCardName)
      {
        case (CardListNames.BattleCruiser):
          {
            nextCard = _container.Instantiate<BattleCruiserCard>();
            break;
          }
        case (CardListNames.Carrier):
          {
            nextCard = _container.Instantiate<CarrierCard>();
            break;
          }
        case (CardListNames.DeathStar):
          {
            nextCard = _container.Instantiate<DeathStarCard>();
            break;
          }
        case (CardListNames.Refuel):
          {
            nextCard = _container.Instantiate<RefuelCard>();
            break;
          }
      }
      return nextCard;
    }
  }

  public class CardFactory
  {
    [Inject]
    BaseCardFactory cardFactory;

    [Inject]
    CardFactoryController factoryController;

    Random rand = new Random();
    // T gives you option to cast the card to correct type here. (It also gives option to make wrong casting)
    public T CreateCardByName<T>(CardListNames nextCardName) where T : Card
    {
      factoryController.SetNextCardName(nextCardName);
      return cardFactory.Create() as T;
    }

    // T won't work here, because you won't know type of returned card. Will it be instant or unit.
    public Card CreateRandomCard()
    {
      CardListNames nextCardName = GetRandomCardName();
      factoryController.SetNextCardName(nextCardName);
      return cardFactory.Create();
    }

    private CardListNames GetRandomCardName()
    {
      var v = Enum.GetValues(typeof(CardListNames));
      return (CardListNames)v.GetValue(rand.Next(v.Length));
    }
  }
}