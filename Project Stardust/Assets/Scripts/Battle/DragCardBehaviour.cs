using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace StarDust
{
  /// <summary>
  /// Added to ugui card representation.
  /// Added to card views prefabs. UnitCardView and InstantCardView.
  /// </summary>
  public class DragCardBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
  {
    [Inject]
    Canvas c;

    RectTransform rt;
    Camera mainCamera;

  //  [Inject]
  //  CardsModel _cardsModel;

    [Inject]
    CardsPanelView _cardsPanelView;

    CardView thisCardView;

    [Inject(Id ="Bottom")]
    UnitHolderView _unitHolderView;

    void Start()
    {
      rt = GetComponent<RectTransform>();
      thisCardView = GetComponent<CardView>();
      mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      _cardsPanelView.SetCurrentDraggedCard(thisCardView);
      if (thisCardView.type == CardType.UNIT)
        _unitHolderView.SetFreeUnitSlotsVisibility(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
      rt.anchoredPosition += eventData.delta * 1 / c.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      ReleasedCardData data = new ReleasedCardData();
      data.ReleasedCard = _cardsPanelView.GetCardFromCardView(thisCardView);

      Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      bool hitSuccess = Physics.Raycast(cameraRay, out hit);

      if (thisCardView.type == CardType.UNIT)
        _unitHolderView.SetFreeUnitSlotsVisibility(false);

      if (hitSuccess)
      {
        UnitView target = null;
        target = hit.transform.GetComponent<UnitView>();

        if (target != null)
        {
          data.Target = target.unitCard;
        //  _cardsModel.ReleaseCardOverUnit(data);
        }


        UnitSlotView unitSlot = null;
        unitSlot = hit.transform.GetComponent<UnitSlotView>();
        if (unitSlot != null)
        {
       //   _cardsModel.ReleaseCardOverUnitSlot(_cardsPanelView.GetCardFromCardView(thisCardView),unitSlot.SlotId);
        }
      }



      ResetCardPosition();
      _cardsPanelView.SetCurrentDraggedCard(null);
    }

    private void ResetCardPosition()
    {
      rt.offsetMin = rt.offsetMax = Vector2.zero;
    }
  }
}