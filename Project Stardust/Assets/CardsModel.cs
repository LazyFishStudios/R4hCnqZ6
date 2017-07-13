using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace StarDust
{
  public class CardsModel : IInitializable
  {
    private int _deckSize = 20;

    public int NumberOfCardOnHand { get { return _cardsOnHand.Count; } private set { } }
    private int _maxCardsOnHand = 5;
    private List<Card> _cardsOnHand;
    private List<Card> _cardsOnTable;
    private Queue<Card> _playersDeck;

    // Card model events:
    public event Action<Card> OnNewCardOnHand;
    public event Action<Card> OnCardReleased;
    public event Action<Card> OnCardRemovedFromHand;
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
    // public PointerEventData lastCardEventData;

    public CardsModel(CardFactory cardFactory)
    {
      this.cardFactory = cardFactory;
      _playersDeck = new Queue<Card>();
      _cardsOnTable = new List<Card>();
      _cardsOnHand = new List<Card>();
    }

    public void Initialize()
    {
      CreateRandomCardDeck();

      for (int i = 0; i < 5; i++)
      {
        AddTopCardFromDeckToHand();
      }
    }

    private void CreateRandomCardDeck()
    {
      for (int i = 0; i < _deckSize; i++)
      {
        Card newCard = cardFactory.CreateRandomCard();
        _playersDeck.Enqueue(newCard);
      }
    }

    public void RemoveCardFromHand(Card card)
    {
      // Inform UI to remove card from hand slot
      _cardsOnHand.Remove(card);
      if (OnCardRemovedFromHand != null) OnCardRemovedFromHand(card);
    }

    public void AddTopCardFromDeckToHand()
    {
      // UnitCard c = cardFactory.CreateCardByName<UnitCard>(CardListNames.BattleCruiser);
      AddCardToHandInternal(_playersDeck.Dequeue());
    }

    /// <summary>
    /// When player stops draging a card.
    /// </summary>
    /// <param name="c"></param>
    public void ReleaseCard(Card c)
    {
      Debug.Log("Card released: " + c.CardName);

      switch (c.Type)
      {
        case (CardType.UNIT):
          {
            if (OnNewUnitCreated != null) OnNewUnitCreated(c as UnitCard);
            RemoveCardFromHand(c);
            break;
          }
        case (CardType.INSTANT):
          {
            RemoveCardFromHand(c);
            break;
          }
      }
    }

    private void AddCardToHandInternal(Card newCard)
    {
      if (NumberOfCardOnHand < _maxCardsOnHand)
      {
        _cardsOnHand.Add(newCard);
        if (OnNewCardOnHand != null) OnNewCardOnHand(newCard);
      }
      else
      {
        Debug.Log("Can not add more cards, because player has " + _cardsOnHand.Count + " cards on hand");
      }
    }
  }
}