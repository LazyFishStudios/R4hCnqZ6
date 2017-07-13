using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace StarDust
{
  public class drag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
  {
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
      c = FindObjectOfType<Canvas>(); // REMOVE THIS!!! It hurts my eyes -,-"
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
      Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      bool hitSuccess = Physics.Raycast(cameraRay, out hit);
      if (hitSuccess)
      {
        Debug.Log(hit.transform.gameObject);
        hit.transform.rotation = UnityEngine.Random.rotation;
      }
      else
      {
        rt.offsetMin = rt.offsetMax = Vector2.zero;
      }
      // TO DO: Find what card is dragged:
      Debug.Log(_cardsPanelView.name);
      Card c = _cardsPanelView.GetCardFromCardView(cardView);
      _cardsModel.ReleaseCard(c);
      _cardsPanelView.SetCurrentDraggedCard(null);
    }
  }
}