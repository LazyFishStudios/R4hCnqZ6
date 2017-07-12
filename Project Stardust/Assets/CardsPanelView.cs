using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class CardsPanelView : MonoBehaviour
  {
    [Inject]
    CardsModel _cardsModel;
     
    void Start()
    {
      _cardsModel.OnNewCardAdded += _cardsModel_OnNewCardAdded;
    }

    private void _cardsModel_OnNewCardAdded(Card newCard)
    {
      switch(newCard.Type)
      {
        case (CardType.UNIT):
          {

            break;

          }
        case (CardType.INSTANT):
          {

            break;
          }
      }
      Debug.Log(newCard.Type);
    }
  }
}