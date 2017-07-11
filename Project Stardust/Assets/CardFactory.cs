using Zenject;
/*
 Classes related with creating card

  Why this is working this way?
  based on: https://github.com/modesttree/Zenject/blob/master/Documentation/Factories.md

*/
namespace StarDust
{
  
  public class CardFactoryController
  {
    public int NextCardIndex { get; private set; }

    public void SetRandomCardIndex()
    {
      NextCardIndex = 1;
    }

    public void SetCardIndex(int index)
    {
      NextCardIndex = index;
    }
  }
  
  public class BaseCardFactory : Factory<Card>
  {

  }

  public class CardFactoryInternal : IFactory<Card>
  {
    DiContainer _container;
    [Inject]
    CardFactoryController _fc;
    
    public CardFactoryInternal(DiContainer container)
    {
      _container = container;
    }

    public Card Create()
    {
      if (_fc.NextCardIndex == 0)
        return _container.Instantiate<BattleCruiserCard>();
      else
        return _container.Instantiate<BattleCruiserCard>();
    }
  }

  public class CardFactory
  {
    [Inject]
    BaseCardFactory cef;

    [Inject]
    CardFactoryController fc;

    public T CreateCard<T>() where T:Card
    {
      fc.SetCardIndex(1);
      return cef.Create() as T;
    }
    public Card CreateCat()
    {
      fc.SetRandomCardIndex();
      return cef.Create();
    }
  }
}