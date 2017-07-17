using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace StarDust
{
  public class DragCardBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
  {
    [Inject]
    Canvas c;

    RectTransform rt;
    Camera mainCamera;

    [Inject]
    CardsModel _cardsModel;

    [Inject]
    CardsPanelView _cardsPanelView;

    CardView thisCardView;
    
    void Start()
    {
      rt = GetComponent<RectTransform>();
      thisCardView = GetComponent<CardView>();
      mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      _cardsPanelView.SetCurrentDraggedCard(thisCardView);
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
      
      if (hitSuccess)
      {
        UnitView target = null;
        // Debug.Log(hit.transform.gameObject);
        target = hit.transform.gameObject.GetComponent<UnitView>();
        data.Target = target.unitCard;
      }

      _cardsModel.ReleaseCardOverUnit(data);

      ResetCardPosition();
      _cardsPanelView.SetCurrentDraggedCard(null);
    }

    private void ResetCardPosition()
    {
      rt.offsetMin = rt.offsetMax = Vector2.zero;
    }
  }
}