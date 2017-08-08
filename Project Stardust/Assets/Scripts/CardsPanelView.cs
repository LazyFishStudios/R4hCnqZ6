using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class CardsPanelView : MonoBehaviour
  {
    public const string dd = "d";
    [Inject(Id = dd)]
    CardsModel _cardsModel;

    [Inject]
    CardViewsFactory _cardsViewsFactory;

    List<Slot> cardSlots;

    CardView currentDraggedCardView;

    void Awake()
    {
      cardSlots = new List<Slot>();
      foreach (Transform t in transform)
      {
        cardSlots.Add(new Slot() { card = null, slot = t });
      }
      _cardsModel.OnNewCardOnHand += _cardsModel_OnNewCardAdded;
      _cardsModel.OnCardRemovedFromHand += _cardsModel_OnCardRemovedFromHand;
    }

    private void _cardsModel_OnCardRemovedFromHand(Card obj)
    {
      Slot toClear = GetSlotWithCard(obj);
      Destroy(toClear.cardView.gameObject);
      toClear.card = null;
    }

    public void SetCurrentDraggedCard(CardView draggedCardView)
    {
      currentDraggedCardView = draggedCardView;
    }

    public Card GetCardFromCardView(CardView cardView)
    {
      foreach (Slot s in cardSlots)
      {
        if (s.cardView == cardView)
          return s.card;
      }
      return null;
    }


    private void _cardsModel_OnNewCardAdded(Card newCard)
    {
      Slot s = GetFirstFreeSlot();
      s.card = newCard;
      CardView newCardView = _cardsViewsFactory.CreateView(s);
      s.cardView = newCardView;
    }

    private Slot GetFirstFreeSlot()
    {
      return cardSlots.First(s => s.card == null);
    }

    private Slot GetSlotWithCard(Card c)
    {
      return cardSlots.First(s => s.card == c);
    }
  }
  public class Slot
  {
    public Transform slot;
    public Card card;
    public CardView cardView;
  }
}