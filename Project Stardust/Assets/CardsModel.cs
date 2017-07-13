using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace StarDust
{
  public class CardsModel
  {
    public int NumberOfCardOnHand { get { return _cardsOnHand.Count; } private set { } }
    private int _maxCardsOnHand = 5;
    private List<Card> _cardsOnHand;

    // Card model events:
    public event Action<Card> OnNewCardCreated;
    public event Action<Card> OnCardReleased;
    public event Action<UnitCard> OnNewUnitCreated;
       
    CardFactory cardFactory;
    /* ok, this is to be discussed:
     - should model maintain position of last released card?
     OR
     - should cardPlayedAction() get this as parameter?
     OR
     - should view hold this data?
     OR
     - should card hold this data just in case it is needed?
     OR
     - should CardsPanelView hold data what is dragged?
     OR
     - should some other view on scene take care of placing models?
     */
    public PointerEventData lastCardEventData;

    public CardsModel(CardFactory cardFactory)
    {
      this.cardFactory = cardFactory;
      _cardsOnHand = new List<Card>(); 
    }

    public void AddNewCard()
    {
      // UnitCard c = cardFactory.CreateCardByName<UnitCard>(CardListNames.BattleCruiser);
      Card c = cardFactory.CreateRandomCard();
      AddCardInternal(c);
    }

    public void ReleaseCard(Card c)
    {
      Debug.Log("Card released: "+c.CardName);
      
      if(c.Type == CardType.UNIT)
      {
       if(OnNewUnitCreated != null) OnNewUnitCreated(c as UnitCard);
      }
    }



    private void AddCardInternal(Card newCard)
    {
      if (NumberOfCardOnHand < _maxCardsOnHand)
      {
        _cardsOnHand.Add(newCard);
        if (OnNewCardCreated != null) OnNewCardCreated(newCard);
      }
    }
  }
}