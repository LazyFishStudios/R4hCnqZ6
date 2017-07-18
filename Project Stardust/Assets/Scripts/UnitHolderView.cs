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

    [Inject]
    UnitView.Factory _unitViewFactory;

       private void Start()
    {
      _cardsModel.OnNewUnitCreated += _cardsModel_OnNewUnitCreated;
    }

    private void RepositionUnitViews()
    {
      for (int i = 0; i < _cardsModel.UnitsOwned; i++)
      {
        float viewXPos = (i+1)/ ((float)_cardsModel.UnitsOwned + 1.0f);
        transform.GetChild(i).position = Camera.main.ViewportToWorldPoint(new Vector3(viewXPos, .3f, 15));
      }
    }

    private void _cardsModel_OnNewUnitCreated(UnitCard unitCard)
    {
      UnitView uv = _unitViewFactory.Create();
      uv.FillValues(unitCard);
     
      RepositionUnitViews();
    }
  }
}