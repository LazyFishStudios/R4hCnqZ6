using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class UnitHolderView : MonoBehaviour
  {
    [SerializeField]
    GameObject UnitViewBkgPrefab;

    [Inject]
    CardsModel _cardsModel;

    [Inject]
    UnitView.Factory _unitViewFactory;

    private List<UnitSlotView> unitViewSlots;

    private void Start()
    {
      unitViewSlots = new List<UnitSlotView>();

      for (int i = 0; i < 4; i++)
      {
        float viewXPos = (i + 1) / ((float)4 + 1.0f);
        UnitSlotView newUnitSlot = Instantiate(UnitViewBkgPrefab).GetComponent<UnitSlotView>();
        newUnitSlot.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewXPos, .3f, 15));
        newUnitSlot.transform.SetParent(transform);
        newUnitSlot.SlotId = i;
        unitViewSlots.Add(newUnitSlot);
      }

      SetFreeUnitSlotsVisibility(false);
      _cardsModel.OnNewUnitCreated += _cardsModel_OnNewUnitCreated;
    }

    private void _cardsModel_OnNewUnitCreated(UnitCard unitCard,UnitSlotView usv)
    {
      UnitView uv = _unitViewFactory.Create();
      uv.FillValues(unitCard);
      uv.transform.position = usv.transform.position;
      usv.used = true;
    }

    public void SetFreeUnitSlotsVisibility(bool visibility)
    {
      foreach(UnitSlotView uvs in unitViewSlots)
      {
        uvs.SetVisiblity(visibility && !uvs.used);
      }
    }
  }
}