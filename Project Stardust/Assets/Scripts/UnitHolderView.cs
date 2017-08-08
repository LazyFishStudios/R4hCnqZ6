using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace StarDust
{
  public class UnitHolderView : MonoBehaviour
  {

    [SerializeField]
    float posY;
    [SerializeField]
    GameObject UnitViewBkgPrefab;

    [Inject(Id ="d")]
    CardsModel _cardsModel;

    [Inject]
    UnitView.Factory _unitViewFactory;

    private List<UnitSlotView> unitSlotViews;
    
    public UnitSlotView SelectedSlot;

    private void RegisterEvents()
    {
      Debug.Log("Unit holder view RegisterEvents()");
      _cardsModel.OnNewUnitCreated += _cardsModel_OnNewUnitCreated;
    }

    private void Start()
    {
      unitSlotViews = new List<UnitSlotView>();

      for (int i = 0; i < 4; i++)
      {
        float viewXPos = (i + 1) / ((float)4 + 1.0f);
        UnitSlotView newUnitSlot = Instantiate(UnitViewBkgPrefab).GetComponent<UnitSlotView>();
        newUnitSlot.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(viewXPos, posY, 15));
        newUnitSlot.transform.SetParent(transform);
        newUnitSlot.SlotId = i;
        unitSlotViews.Add(newUnitSlot);
      }

      SetFreeUnitSlotsVisibility(false);
      RegisterEvents();
    }

    private void _cardsModel_OnNewUnitCreated(UnitCard unitCard, int slotId)
    {
      UnitView uv = _unitViewFactory.Create();
      uv.FillValues(unitCard);
      UnitSlotView usv = GetSlotById(slotId);
      uv.transform.position = usv.transform.position;
      usv.used = true;
    }

    public void SetFreeUnitSlotsVisibility(bool visibility)
    {
      foreach (UnitSlotView uvs in unitSlotViews)
      {
        uvs.SetVisiblity(visibility && !uvs.used);
      }
    }

    public UnitSlotView GetSlotById(int id)
    {
      return unitSlotViews[id];
    }
  }
}