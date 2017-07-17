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

    CardView cardView;


    void Start()
    {
      rt = GetComponent<RectTransform>();
      cardView = GetComponent<CardView>();
      mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
      _cardsPanelView.SetCurrentDraggedCard(cardView);
    }

    public void OnDrag(PointerEventData eventData)
    {
      rt.anchoredPosition += eventData.delta * 1 / c.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      UnitView target = null;

      Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      bool hitSuccess = Physics.Raycast(cameraRay, out hit);


      if (hitSuccess)
      {
        Debug.Log(hit.transform.gameObject);
        target = hit.transform.gameObject.GetComponent<UnitView>();
      }

      Card c = _cardsPanelView.GetCardFromCardView(cardView);
      _cardsModel.ReleaseCardOverUnit(c);


      _cardsPanelView.SetCurrentDraggedCard(null);
    }

    private void ResetCardPosition()
    {
      rt.offsetMin = rt.offsetMax = Vector2.zero;
    }
  }
}