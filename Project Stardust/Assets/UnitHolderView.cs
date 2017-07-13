using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class UnitHolderView : MonoBehaviour
  {
    [Inject]
    CardsModel _cardsModel;
    private void Start()
    {
      _cardsModel.OnCardReleased += _cardsModel_OnCardReleased;
    }

    private void _cardsModel_OnCardReleased(Card obj)
    {
     
    }
  }
}