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

    [Inject]
    CardFactory cardFactory;

    void Start()
    {
      Debug.Log(_cardsModel.NumberOfCardOnHand);
      UnitCard c = cardFactory.CreateCard<UnitCard>();
      Debug.Log(c.Description);
    }
  }
}