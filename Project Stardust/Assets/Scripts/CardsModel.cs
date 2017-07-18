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

    private const int MaxUnits = 4;

    private int _unitsOwned = 0;


    public int UnitsOwned
    {
      get
      {
        return _unitsOwned;
      }

      set
      {
        _unitsOwned = value;
      }
    }

    public int NumberOfCardOnHand { get { return _cardsOnHand.Count; } private set { } }
    private int _maxCardsOnHand = 5;
    private List<Card> _cardsOnHand;
    private List<Card> _cardsOnField;
    private Queue<Card> _playersDeck;

    public ReleasedCardData LastFieldInteraction;

    // Card model events:
    public event Action<Card> OnNewCardOnHand;
    public event Action<Card> OnCardReleased;
    public event Action<Card> OnCardRemovedFromHand;
    public event Action<UnitCard> OnNewUnitCreated;

    CardFactory cardFactory;

    [Inject]
    DefendingPlayer _playerModel;

    public CardsModel(CardFactory cardFactory)
    {
      this.cardFactory = cardFactory;
      _playersDeck = new Queue<Card>();
      _cardsOnField = new List<Card>();
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
    /// When player stops draging a card and releases it on field.
    /// </summary>
    /// <param name="c"></param>
    public void ReleaseCardOverUnit(ReleasedCardData data)
    {
      LastFieldInteraction = data;
      Debug.Log("Card released: " + data.ReleasedCard.CardName);

      if (data.ReleasedCard.Type == CardType.UNIT)
      {
        UnitsOwned++;
        if (OnNewUnitCreated != null) OnNewUnitCreated(data.ReleasedCard as UnitCard);
        RemoveCardFromHand(data.ReleasedCard);
      }

      if (data.Target != null && data.ReleasedCard.Type == CardType.INSTANT)
      {
        Debug.Log("Instant card " + data.ReleasedCard.CardName + " released over: " + data.Target.CardName);
        RemoveCardFromHand(data.ReleasedCard);
        data.ReleasedCard.OnCardPlayed();
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

    private void MoveCardFromHandToDeck(Card c)
    {
      _cardsOnHand.Remove(c);
      _playersDeck.Enqueue(c);
    }
  }
}