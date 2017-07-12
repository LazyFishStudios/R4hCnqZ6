using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace StarDust
{
  public class CardsModel
  {
    public int NumberOfCardOnHand { get { return _cardsOnHand.Count; } private set { } }
    private int _maxCardsOnHand = 5;
    private List<Card> _cardsOnHand;
    public event Action<Card> OnNewCardAdded;

    
    CardFactory cardFactory;

    public CardsModel(CardFactory cardFactory)
    {
      this.cardFactory = cardFactory;
      _cardsOnHand = new List<Card>();

      

      

    }

    public void AddNewCard()
    {
      UnitCard c = cardFactory.CreateCardByName<UnitCard>(CardListNames.BattleCruiser);
      AddCardInternal(c);
    }

    private void AddCardInternal(Card newCard)
    {
      if (NumberOfCardOnHand < _maxCardsOnHand)
      {
        _cardsOnHand.Add(newCard);
        if (OnNewCardAdded != null) OnNewCardAdded(newCard);
      }
    }
  }
}