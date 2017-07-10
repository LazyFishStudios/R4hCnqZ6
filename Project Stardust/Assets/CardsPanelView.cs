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
      Debug.Log(_cardsModel.NumberOfCardOnHand);
    }
  }
}