using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarDust
{
  public class CardsModel
  {
    public int NumberOfCardOnHand { get { return _cardsOnHand.Count; } private set { } }
    private int _maxCardsOnHand = 5;
    private List<Card> _cardsOnHand;
    public event Action<Card> OnNewCardAdded;

    public CardsModel()
    {
      _cardsOnHand = new List<Card>();
    }

    public void AddCard(Card newCard)
    {
      if (NumberOfCardOnHand < _maxCardsOnHand)
      {
        _cardsOnHand.Add(newCard);
        if (OnNewCardAdded != null) OnNewCardAdded(newCard);
      }
    }
  }
}