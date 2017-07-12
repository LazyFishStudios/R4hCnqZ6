using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class CardsPanelView : MonoBehaviour
  {
    [Inject]
    CardsModel _cardsModel;

    [Inject]
    CardViewsFactory _cardsViewsFactory;

    List<Slot> cardSlots;

    void Start()
    {
      cardSlots = new List<Slot>();
      foreach (Transform t in transform)
      {
        cardSlots.Add(new Slot() { card = null, slot = t });
      }
      _cardsModel.OnNewCardAdded += _cardsModel_OnNewCardAdded;
    }

    private void _cardsModel_OnNewCardAdded(Card newCard)
    {
      Slot s = GetFirstFreeSlot();
      s.card = newCard;
      _cardsViewsFactory.CreateView(s);

      Debug.Log(newCard.Type);
    }

    private Slot GetFirstFreeSlot()
    {
      return cardSlots.First(s => s.card == null);
    }


  }
  public class Slot
  {
    public Transform slot;
    public Card card;
  }
}