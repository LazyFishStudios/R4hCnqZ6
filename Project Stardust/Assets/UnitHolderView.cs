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

    int numberOfUnits = 0;

    private void Start()
    {
      _cardsModel.OnNewUnitCreated += _cardsModel_OnNewUnitCreated;



    }

    private void RepositionUnitViews()
    {
      for (int i = 0; i < numberOfUnits; i++)
      {
        float viewXPos = (i+1)/ ((float)numberOfUnits + 1.0f);
        transform.GetChild(i).position = Camera.main.ViewportToWorldPoint(new Vector3(viewXPos, .3f, 15));
      }
    }

    private void _cardsModel_OnNewUnitCreated(UnitCard unitCard)
    {
      // Replace this with new model objects factory:
      // Instantiate(obj.Prefab);
      UnitView uv = _unitViewFactory.Create();
      uv.FillValues(unitCard);
      numberOfUnits++;
      RepositionUnitViews();
    }
  }
}