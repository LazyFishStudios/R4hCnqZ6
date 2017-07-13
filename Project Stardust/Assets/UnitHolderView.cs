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
      _cardsModel.OnNewUnitCreated += _cardsModel_OnNewUnitCreated;
    }

    private void _cardsModel_OnNewUnitCreated(UnitCard obj)
    {
      Instantiate(obj.Prefab);
    }
  }
}